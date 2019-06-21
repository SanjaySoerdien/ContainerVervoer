using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using ContainerVervoer.Enums;

namespace ContainerVervoer.Classes
{
    public class Ship
    {
        #region Fields
        private readonly int length;
        private readonly int width;
        private readonly int maxWeight;

        private int currentWeight;
        private int weightLeft;
        private int weightRight;

        private readonly List<Container> containers;
        private readonly List<Layer> layers;
        private ShipMath shipMath;
        #endregion

        #region Properties
        public int Length => length;
        public int Width => width;
        public int MaxWeight => maxWeight;
        public int CurrentWeight => currentWeight;
        public double Balance => (double) weightLeft / weightRight;//todo Cast unneccesacry?
        public int WeightLeft => weightLeft;
        public int WeightRight => weightRight;
        public List<Container> Containers => containers;
        public List<Layer> Layers => layers;
        #endregion

        #region Methods
        public Ship(int width, int length)
        {
            containers = new List<Container>();
            this.length = length;
            this.width = width;
            maxWeight = length * width * 150000;
            layers = new List<Layer>();
            shipMath = new ShipMath();
            layers.Add(new Layer(this.length, width));
        }

        public Status AddContainer(Container container)
        {
            Status result = Status.Succes;
            if (currentWeight + container.Weight >= maxWeight)
            {
                return Status.TooHeavy;
            }
            containers.Add(container);
            currentWeight += container.Weight;
            return result;
        }

        public void RemoveContainer(int index)
        {
            containers.RemoveAt(index);
        }

        public void RemoveAllContainers()
        {
            containers.Clear();
        }

        public void GenerateRandomContainers(int amount)
        {
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                int weight = rnd.Next(4000, 30000);
                bool valuable = rnd.Next(1, 15).Equals(2);
                bool cooled = rnd.Next(1, 15).Equals(2);
                Container cont = new Container(weight, valuable, cooled);
                AddContainer(cont);
            }
        }

        public bool CheckWeight()
        {
            int totalWeight = 0;

            foreach (Container container in Containers)
            {
                totalWeight += container.Weight;
            }
            if (totalWeight < (maxWeight / 2))
            {
                return false;
            }
            return true;
        }

        public void AddWeight(Space space, Container container)
        {
            currentWeight += container.Weight;
            if (space.Position == Positon.Left)
            {
                weightLeft += container.Weight;
                return;
            }
            weightRight += container.Weight;
        }

        #region Algortihm
        private List<Container> normalContainers;
        private List<Container> cooledContainers;
        private List<Container> valuableContainers;
        private List<Container> cooledAndValuableContainers;

        private List<Container> GetAllNormalContainers()
        {
            return containers.Where(x => !x.Valuable && !x.Cooled).OrderBy(x => x.Weight).Reverse().ToList();

        }

        private List<Container> GetAllValueableContainers()
        {
            return containers.Where(x => x.Valuable && !x.Cooled).OrderBy(x => x.Weight).Reverse().ToList();
        }

        private List<Container> GetAllCooledContainers()
        {
            return containers.Where(x => x.Cooled && !x.Valuable).OrderBy(x => x.Weight).Reverse().ToList();
        }

        private List<Container> GetAllValueableAndCooledContainers()
        {
            return containers.Where(x => x.Valuable && x.Cooled).OrderBy(x => x.Weight).Reverse().ToList();
        }

        private int TotalcontainersToDistrubute()
        {
            return normalContainers.Count +
                   cooledContainers.Count +
                   valuableContainers.Count +
                   cooledAndValuableContainers.Count;
        }

        public Status[] PlaceContainersInShip()
        {
            normalContainers = GetAllNormalContainers();
            cooledContainers = GetAllCooledContainers();
            valuableContainers = GetAllValueableContainers();
            cooledAndValuableContainers = GetAllValueableAndCooledContainers();
            int index = 0;
            while (FillLayer(index))
            {
                index++;
                layers.Add(new Layer(this.length, width));
            }

            return GetResult();
        }


        private Status[] GetResult()
        {
            bool failure = false;
            Status[] result =
            {
                Status.Succes,
                Status.TooManyContainers,
                Status.TooManyValuable,
                Status.TooManyCooled,
                Status.TooManyValueableAndCooled,
            };

            // ReSharper disable ReturnValueOfPureMethodIsNotUsed
            if (normalContainers.Count <= 0)
            {
                failure = true;
               result.Where(x => x != Status.TooManyContainers).ToArray();
            }
            if (cooledContainers.Count <= 0)
            {
                failure = true;
                result.Where(x => x != Status.TooManyCooled).ToArray();
            }
            if (valuableContainers.Count <= 0)
            {
                failure = true;
                result.Where(x => x != Status.TooManyValuable).ToArray();
            }
            if (cooledAndValuableContainers.Count <= 0)
            {
                failure = true;
                result.Where(x => x != Status.TooManyValueableAndCooled).ToArray();
            }
            if (failure)
            {
                result.Where(x => x != Status.Succes).ToArray();
            }
            return result;
        }

        private bool FillLayer(int layer)
        {
            int containersToDistrubute = TotalcontainersToDistrubute();
            if (containersToDistrubute>0)
            {
                for (int column = 0; column < width - 1; column++)
                {
                    if (column == 0)
                    {
                        FillFirstColumn(layer, column);
                    }
                    else if (column > 0)
                    {
                        FillColumns(layer, column);
                    }
                }
                if (TotalcontainersToDistrubute()< TotalcontainersToDistrubute()) //TODO dit aanpassen , suggeties Tim?
                {
                    layers.RemoveAt(layer);
                    return false;
                }
            }
            return true;
        }

        private void FillFirstColumn(int layer, int column) 
        {
            for (int i = 0; i < length - 1; i++)
            {
                int row = shipMath.GenerateRowNr(i,length);
                if (normalContainers.Count + cooledContainers.Count > 0)
                {
                    if (cooledContainers.Count > 0)
                    {
                        PlaceCooledContainer(layer, column, row);
                    }
                    else if (normalContainers.Count > 0)
                    {
                        PlaceNormalContainer(layer, column, row);
                    }
                    else if (cooledAndValuableContainers.Count > 0)
                    {
                        PlaceNormalContainer(layer, column, row);
                    }
                    else if (valuableContainers.Count > 0)
                    {
                        PlaceNormalContainer(layer, column, row);
                    }
                }
            }
        }

        private void FillColumns(int layer, int column)
        {
            for (int i = 0; i < length - 1; i++)
            {
                int row = shipMath.GenerateRowNr(i,length-1);
                if (normalContainers.Count > 0)
                {
                    PlaceNormalContainer(layer, column, row);
                }
                else if (valuableContainers.Count > 0)
                {
                    PlaceNormalContainer(layer, column, row);
                }
            }
        }

        private void PlaceCooledContainer(int layer, int column, int row)
        {
            if (CheckIfContainerIsPlaceable(cooledContainers[0], layer, column, row) == Placeability.Placeable)
            {
                cooledContainers = PlaceContainer(cooledContainers, layer, column, row);
            }
        }

        private void PlaceNormalContainer(int layer, int column, int row)
        {
            if (CheckIfContainerIsPlaceable(cooledContainers[0], layer, column, row) == Placeability.Placeable)
            {
                cooledContainers = PlaceContainer(cooledContainers, layer, column, row);
            }
        }

        private void PlaceValuableContainer(int layer, int column, int row)
        {
            if (CheckIfContainerIsPlaceable(valuableContainers[0], layer, column, row) == Placeability.Placeable)
            {
                valuableContainers = PlaceContainer(valuableContainers, layer, column, row);
            }
        }

        private void PlaceCooledAndValueableContainer(int layer, int column, int row)
        {
            if (CheckIfContainerIsPlaceable(cooledAndValuableContainers[0], layer, column, row) == Placeability.Placeable)
            {
                cooledAndValuableContainers = PlaceContainer(cooledAndValuableContainers, layer, column, row);
            }
        }

        private Placeability CheckIfContainerIsPlaceable(Container container, int layer, int column, int row)
        {
            Placeability result = Placeability.Placeable; //TODO check dit
            result = CheckIfContainerIsPlaceableBasedOnWeight(container, layer, column, row);
            if (result == Placeability.Placeable)
            {
                result = CheckIfContainerIsOnTopOfValuable(layer, column, row);
            }
            if (container.Valuable && result == Placeability.Placeable)
            {
                result = CheckIfContainerIsPlaceableBasedOnValuable(layer, column, row);
            }

            if (container.Cooled && result == Placeability.Placeable)
            {
                result = CheckIfContainerIsPlaceableBasedOnCooled(row);
            }
            return result;
        }

        private Placeability CheckIfContainerIsPlaceableBasedOnWeight(Container container, int layer, int column, int row)
        {
            if (layer > 0)
            {
                Space spaceUnder = layers[layer - 1].GetSpace(column, row);
                if (container.Weight < spaceUnder.WeightAllowedOnTop)
                {
                    return Placeability.Placeable;
                }
                return Placeability.Unplaceable;
            }
            return Placeability.Placeable;
        }

        private Placeability CheckIfContainerIsOnTopOfValuable(int layer, int column, int row)
        {
            if (layer > 0)
            {
                Space spaceUnder = layers[layer - 1].GetSpace(column, row);
                if (spaceUnder.Container.Valuable)
                {
                    return Placeability.Unplaceable;
                }
            }
            return Placeability.Placeable;
        }

        /// <summary>
        /// Checks the positions for valueable containers and returns an enum if its placeability or not
        /// </summary>
        private Placeability CheckIfContainerIsPlaceableBasedOnValuable(int layer, int column, int row)
        {
            Placeability result = Placeability.Placeable;
            if (row > 0) //it can always be placed on first row 
            {
                result = CheckPositionsForValuables(layer, column, row);
            }
            return result;
        }


        /// <summary>
        /// Calls different methods based on column and returns Placeability or not.
        /// </summary>
        private Placeability CheckPositionsForValuables(int layer, int column, int row)
        {
            Placeability result = Placeability.Placeable; 
            if (CheckIfContainerIsPlaced(layer, column - 1, row)&& column >= 1) //check if there is container in front of the container if we are in the second column
            {
                if (CheckIfContainerIsPlaced(layer, column+1, row))
                {
                    return Placeability.Unplaceable;
                }

                if (column >= 2 && CheckIfContainerIsPlaced(layer, column - 2, row)) //check if there is a container 2 rows in front of the container if we are in the third column
                {
                    Container containerInFront = layers[layer].GetContainer(column, row);
                    result = CheckForNotBlockingValuableTwoRowsInfront(containerInFront, layer, column, row); 
                }
            }
            return result;
        }

        /// <summary>
        /// This method checks if there is a valueable 2 rows infront so it does not block it from behind.
        /// </summary>
        private Placeability CheckForNotBlockingValuableTwoRowsInfront(Container containerInFront,int layer, int column, int row) 
        {
            Container containerInFrontOfInFront = layers[layer - 1].GetContainer(column -2, row);
            if (containerInFront != null && containerInFrontOfInFront.Valuable)
            {
                return Placeability.Unplaceable;
            }
            return Placeability.Placeable;
        }

        /// <summary>
        /// This Method returns true if there is container placed.
        /// </summary>
        private bool CheckIfContainerIsPlaced(int layer, int column, int row)
        {
            if (layers[layer].GetContainer(column - 2, row) != null)
            {
                return true;
            }
            return false;
        }

        private Placeability CheckIfContainerIsPlaceableBasedOnCooled(int row)
        {
            if (row == 0) // TODO dit is een dubbele check? sneller maar minder leesbaar als in FillCollum; Vraag mening tim
            {
                return Placeability.Placeable;
            }

            return Placeability.Placeable;
        }

        private List<Container> PlaceContainer(List<Container> containerList, int layer, int column, int row)
        {
            Container containerToAdd = containerList[0];
            int weightUnder = 0;
            if (layer > 0)
            {
                Space spaceUnder = layers[layer - 1].GetSpace(column,row);
                weightUnder = spaceUnder.TotalStackWeight;
            }

            Space spaceToAdd = layers[layer].GetSpace(column,row);
            spaceToAdd.PlaceContainer(containerToAdd, weightUnder);
            AddWeight(spaceToAdd, containerToAdd);
            containerList.RemoveAt(0);
            return containerList;
        }
        #endregion
        #endregion
    }
}

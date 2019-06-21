using System;
using System.Collections.Generic;
using System.Linq;
using ContainerVervoer.Enums;

namespace ContainerVervoer.Classes
{
    public class Ship
    {
        #region Fields
        private int length;
        private int width;
        private int heigth;
        private int maxWeight;
        private int currentWeight;
        private double balance;//TODO maak in view ? enzo? idk maybe remove
        private int weightLeft;
        private int weightRight;
     
        private List<Container> containers;
        private List<Layer> layers;
        #endregion

        #region Properties
        public int Length => length;
        public int Width => width;
        public int Heigth => heigth;
        public int MaxWeight => maxWeight;
        public int CurrentWeight => currentWeight;
        public double Balance => balance;
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
        }

        public ErrorMessage AddContainer(Container container)
        {
            ErrorMessage result = ErrorMessage.Succes;
            if (currentWeight + container.Weight >= maxWeight)
            {
                return ErrorMessage.TooHeavy;
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
            int weightToCheck = maxWeight / 2;

            foreach (Container container in Containers)
            {
                totalWeight += container.Weight;
            }
            if (totalWeight < maxWeight / 2)
            {
                return false;
            }
            return true;
        }
        #region Algortihm
        private List<Container> normalContainers;
        private List<Container> cooledContainers;
        private List<Container> valueableContainers;
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
                       valueableContainers.Count +
                       cooledAndValuableContainers.Count;
        }

        public void PlaceContainersInShip()
        {
            List<Container> normalContainers = GetAllNormalContainers();
            List<Container> cooledContainers = GetAllCooledContainers();
            List<Container> valueableContainers = GetAllValueableContainers();
            List<Container> cooledAndValuableContainers = GetAllValueableAndCooledContainers();
            int index = -1;
            while (TotalcontainersToDistrubute()>0)
            {
                index++;
                FillLayer(index);
                layers.Add(new Layer(this.length,width));
            }
        }

        private void FillLayer(int layer)
        {
            for (int column = 0; column < width - 1; column++) //todo maak logische for die over de collum looped
            {
                if (column == 0) 
                {
                    FillFirstColumn(layer,column);
                }
                else
                {
                    FillColums(layer, column);
                }
            }
        }

        private void FillFirstColumn(int layer,int column)
        {
            for (int i = 0; i < length - 1; i++) //todo maak logische for die over de collum looped
            {
                int row = GenerateRowNr(i);
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
                }
            }
        }
        private void FillColums(int layer, int column)
        {
            for (int i = 0; i < length - 1; i++) //todo maak logische for die over de collum looped
            {
                int row = GenerateRowNr(i);
                if (normalContainers.Count > 0)
                {
                    PlaceNormalContainer(layer, column, row);
                }
            }
        }

        private void PlaceCooledContainer(int layer, int column, int row)
        {
            if (CheckIfContainerIsPlaceable(cooledContainers[0], layer, column, row))
            {
                cooledContainers = PlaceContainer(cooledContainers, layer, column, row);
            }
        }

        private void PlaceNormalContainer(int layer, int column, int row)
        {
            if (CheckIfContainerIsPlaceable(cooledContainers[0], layer, column, row))
            {
                cooledContainers = PlaceContainer(cooledContainers, layer, column, row);
            }
        }

        private void PlaceValuableContainer(int layer, int column, int row)
        {
            if (CheckIfContainerIsPlaceable(valueableContainers[0], layer, column, row))
            {
                valueableContainers = PlaceContainer(valueableContainers, layer, column, row);
            }
        }

        private void PlaceCooledAndValueableContainer(int layer, int column, int row)
        {
            if (CheckIfContainerIsPlaceable(cooledAndValuableContainers[0], layer, column, row))
            {
                cooledAndValuableContainers = PlaceContainer(cooledAndValuableContainers, layer, column, row);
            }
        }

        private bool CheckIfContainerIsPlaceable(Container container ,int layer,int column, int row)
        {
            bool result = true;
            result = CheckIfContainerIsPlaceableBasedOnWeight(container, layer,  column,  row);

            if (container.Valuable && result)
            {
               result = CheckIfContainerIsPlaceableBasedOnValuable(container, layer, column, row);
            }

            if (container.Cooled && result)
            {
                result = CheckIfContainerIsPlaceableBasedOnCooled(container, layer, column, row);
            }
            return result ;
        }

        private bool CheckIfContainerIsPlaceableBasedOnWeight(Container container, int layer, int column, int row)
        {
            if (layer > 0)
            {
                Space spaceUnder = layers[layer - 1].LayerLayout[column][row];
                if (container.Weight < spaceUnder.WeightAllowedOnTop)
                {
                    return true;
                }
                return false;
            }
            return true;
        }

        private bool CheckIfContainerIsPlaceableBasedOnValuable(Container container, int layer, int column, int row)
        {
            bool result = true;
            if (layer > 0)
            {
                Space spaceUnder = layers[layer - 1].LayerLayout[column][row];
                if (containerToAdd.Weight < spaceUnder.WeightAllowedOnTop)   //TODO FIX DIT
                {
                    return true;
                }
                return false;
            }
            return result;
        }

        private bool CheckIfContainerIsPlaceableBasedOnCooled(Container container, int layer, int column, int row)
        {
            bool result = true;
            if (layer > 0) 
            {
                Space spaceUnder = layers[layer - 1].LayerLayout[column][row];
                if (containerToAdd.Weight < spaceUnder.WeightAllowedOnTop)   //TODO FIX DIT
                {
                    return true;
                }
                return false;
            }
            return result;
        }


        private List<Container> PlaceContainer(List<Container> containerList,int layer, int column, int row)
        {
            Container containerToAdd = containerList[0];
            int weightUnder = 0;
            if (layer > 0)
            {
                Space spaceUnder = layers[layer - 1].LayerLayout[column][row];
                weightUnder= spaceUnder.TotalStackWeight;
            }

            Space spaceToAdd = layers[layer].LayerLayout[column][row];
            spaceToAdd.PlaceContainer(containerToAdd, weightUnder);
            AddWeight(spaceToAdd, containerToAdd);
            containerList.RemoveAt(0);
            return containerList;
        }

        private void AddWeight(Space space , Container container)
        {
            
        }

        private int GenerateRowNr(int index)
        {
            if (index == 0)
            {
                return GetMiddle();
            }
            return IndexAlternator(index);
            
        }
        private int IndexAlternator(int index)
        {
            if (index % 2 == 0)
            {
                return index;
            }
            return -index;
        }
        private int GetMiddle()
        {
            double value = Convert.ToDouble(length);
            if (length % 2 == 0)
            {
                return length / 2;
            }
            return (int)(value / 2 + 0.5);
        }
        #endregion
        #endregion
    }
}

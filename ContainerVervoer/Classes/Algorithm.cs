using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ContainerVervoer.Enums;

namespace ContainerVervoer.Classes
{
    public class Algorithm
    {
        #region Fields
        private Ship ship;
        private List<Container> normalContainers;
        private List<Container> cooledContainers;
        private List<Container> valuableContainers;
        private List<Container> cooledAndValuableContainers;
        #endregion

        #region Constructor
        public Algorithm(Ship ship)
        {
            this.ship = ship;
        }
        #endregion

        #region Methods
        public List<Container> GetAllNormalContainers()
        {
            return ship.Containers.Where(x => !x.Valuable && !x.Cooled).OrderBy(x => x.Weight).Reverse().ToList();
        }

        public List<Container> GetAllValueableContainers()
        {
            return ship.Containers.Where(x => x.Valuable && !x.Cooled).OrderBy(x => x.Weight).Reverse().ToList();
        }

        public List<Container> GetAllCooledContainers()
        {
            return ship.Containers.Where(x => x.Cooled && !x.Valuable).OrderBy(x => x.Weight).Reverse().ToList();
        }

        public List<Container> GetAllValueableAndCooledContainers()
        {
            return ship.Containers.Where(x => x.Valuable && x.Cooled).OrderBy(x => x.Weight).Reverse().ToList();
        }

        public int TotalcontainersToDistrubute()
        {
            return normalContainers.Count +
                   cooledContainers.Count +
                   valuableContainers.Count +
                   cooledAndValuableContainers.Count;
        }

        public Ship ExecuteAlgoritm()
        {
            normalContainers = GetAllNormalContainers();
            cooledContainers = GetAllCooledContainers();
            valuableContainers = GetAllValueableContainers();
            cooledAndValuableContainers = GetAllValueableAndCooledContainers();
            int index = -1;
            bool done = true;
            while (done)
            {
                index++;
                ship.Layers.Add(new Layer(ship.Length, ship.Width));
                done = FillLayersUntilDone(index);
            }
            
            ship.Layers.RemoveAt(index);
            return ship;
        }

        public List<Status> GetResult()
        {
            List<Status> result = new List<Status>();
            if (CheckSuccessfulPlacement(normalContainers))
            {
                result.Add(Status.TooManyContainers);
            }
            if (CheckSuccessfulPlacement(cooledContainers))
            {
                result.Add(Status.TooManyCooled);
            }
            if (CheckSuccessfulPlacement(valuableContainers))
            {
                result.Add(Status.TooManyValuable);
            }
            if (CheckSuccessfulPlacement(cooledAndValuableContainers))
            {
                result.Add(Status.TooManyValueableAndCooled);
            }
            if (result.Count == 0)
            {
                result.Add(Status.Succes);
            }
            return result;
        }

        public bool CheckSuccessfulPlacement(List<Container> listToCheck) //TODO Check when awake
        {
            if (listToCheck.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool FillLayersUntilDone(int layer)
        {
            int containersToDistribute = TotalcontainersToDistrubute();
            if (containersToDistribute > 0)
            {
                for (int column = 0; column < ship.Length; column++)
                {
                    FillColumns(layer, column);
                    if (TotalcontainersToDistrubute() == 0)
                    {
                        return false;
                    }
                }
                if (!CheckIfAnyPlaced(containersToDistribute))
                {
                    ship.Layers.RemoveAt(layer);
                    return false;
                }
            }
            return true;
        }

        public bool CheckIfAnyPlaced(int containersThisLayers)
        {
            if (TotalcontainersToDistrubute() == containersThisLayers)
            {
                List<Container> leftOverContainers = normalContainers.Concat(cooledContainers)
                                                                 .Concat(valuableContainers)
                                                                 .Concat(cooledAndValuableContainers).ToList();
                ship.Containers = leftOverContainers;
                return false;
            }
            return true;
        }

        public void FillColumns(int layer, int column)
        {
            for (int i = 0; i < ship.Width; i++)
            {
                int row = GenerateRowNr(i, ship.Width-1);
                bool placed = false;
                if (cooledContainers.Count > 0 && column == 0 && !placed)
                {
                    placed = PlaceCooledContainer(layer, column, row);
                }
                if (normalContainers.Count > 0 && !placed)
                {
                    placed = PlaceNormalContainer(layer, column, row);
                }
                if (cooledAndValuableContainers.Count > 0 && column == 0 && !placed)
                {
                    placed = PlaceCooledAndValuableContainer(layer, column, row);
                }
                if (valuableContainers.Count > 0 && !placed)
                {
                    placed = PlaceValuableContainer(layer, column, row);
                }
            }
        }

        //TODO refactor
        public bool PlaceCooledContainer(int layer, int column, int row)
        {
            if (CheckIfContainerIsPlaceable(cooledContainers[0], layer, column, row))
            {
                cooledContainers = PlaceContainer(cooledContainers, layer, column, row);
                return true;
            }
            return false;
        }

        public bool PlaceNormalContainer(int layer, int column, int row) 
        {
            if (CheckIfContainerIsPlaceable(normalContainers[0], layer, column, row))
            {
                normalContainers = PlaceContainer(normalContainers, layer, column, row);
                return true;
            }
            return false;
        }

        public bool PlaceValuableContainer(int layer, int column, int row)
        {
            if (CheckIfContainerIsPlaceable(valuableContainers[0], layer, column, row))
            {
                valuableContainers = PlaceContainer(valuableContainers, layer, column, row);
                return true;
            }
            return false;
        }

        public bool PlaceCooledAndValuableContainer(int layer, int column, int row)
        {
            if (CheckIfContainerIsPlaceable(cooledAndValuableContainers[0], layer, column, row))
            {
                cooledAndValuableContainers = PlaceContainer(cooledAndValuableContainers, layer, column, row);
                return true;
            }
            return false;
        }

        /// <summary>
        /// In fill column we already set priorities by cooled>normal>cooled and valuable>valuable
        /// For this reason we only look if we have a container below
        /// And if we are blocking a valuable container
        /// </summary>
        /// <returns>Returns bool true if its placeable</returns>
        public bool CheckIfContainerIsPlaceable(Container container, int layer, int column, int row) //TODO Hier shit fixen
        {
            if (!CheckBelowContainer(container, layer, column, row) || !CheckNextToContainersIfCanBePlaced(layer, column, row))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Does the necessary checks for the container below
        /// </summary>
        /// <returns>Returns bool true if its placeable</returns>
        public bool CheckBelowContainer(Container container, int layer, int column, int row) //TODO Refactor naar 2 containers.
        {
            if (layer > 0)
            {
                if (!CheckIfContainerIsPlaceableBasedOnWeight(container, layer, column, row) || //check if the its allowed by weight
                    !CheckContainerBelowIfPlaceable(layer, column, row)) //check if there is a container below and if its valuable
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check if there is a container can be placed based on the leftover weight of the space.
        /// </summary>
        /// <returns>Returns bool true if its placeable</returns>
        public bool CheckIfContainerIsPlaceableBasedOnWeight(Container container, int layer, int column, int row) //TODO Refactor naar container en space
        {
            Space spaceUnder = ship.Layers[layer - 1].GetSpace(column, row);
            if (container.Weight < spaceUnder.WeightAllowedOnTop)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if there is a container below to be placed on which it can be place on top of.
        /// </summary>
        public bool CheckContainerBelowIfPlaceable(int layer, int column, int row) //TODO Refactor naar space
        {
            Space spaceUnder = ship.Layers[layer - 1].GetSpace(column, row);
            if (spaceUnder.Container != null && !spaceUnder.Container.Valuable)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Calls different methods based on column.
        /// </summary>
        public bool CheckNextToContainersIfCanBePlaced(int layer, int column, int row)
        {
            if (column < 2) // if your on row 0 or 1, you can always place
            {
                return true;
            }

            //At least in 3rd column so we can check if there are containers next to us;
            if (CheckIfContainerIsPlaced(layer, column - 2, row) && CheckIfContainerIsPlaced(layer, column - 1, row))
            {
                Container containerInFront = ship.Layers[layer].GetContainer(column-1, row);
                Container containerTwoInfront = ship.Layers[layer].GetContainer(column - 2, row);
                if (CheckOtherContainersToSeeIfYouCanPlace(containerInFront,containerTwoInfront))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if your not blocking a valuable container.
        /// </summary>
        public bool CheckOtherContainersToSeeIfYouCanPlace(Container containerInfront , Container containerTwoInfront)
        {
            if (!containerInfront.Valuable ||                                 // The assumption can be made that the valuable has space on the left
                containerInfront.Valuable && containerTwoInfront == null)     // Otherwise it would not have been placed.
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This Method returns true if there is container placed on te position.
        /// </summary>
        public bool CheckIfContainerIsPlaced(int layer, int column, int row)
        {
            if (ship.Layers[layer].GetContainer(column, row) != null)
            {
                return true;
            }
            return false;
        }

        public List<Container> PlaceContainer(List<Container> containerList, int layer, int column, int row)
        {
            Container containerToAdd = containerList[0];
            int weightUnder = 0;
            if (layer > 0)
            {
                Space spaceUnder = ship.Layers[layer - 1].GetSpace(column, row);
                weightUnder = spaceUnder.TotalStackWeight;
            }
            Space spaceToAdd = ship.Layers[layer].GetSpace(column, row);
            spaceToAdd.PlaceContainer(containerToAdd, weightUnder);
            ship.AddWeight(spaceToAdd, containerToAdd);
            containerList.RemoveAt(0);
            return containerList;
        }

        public int GenerateRowNr(int index, int width)
        {
            int val1 = Convert.ToInt32(Math.Round((decimal)index / 2, MidpointRounding.AwayFromZero));
            int val2 = Convert.ToInt32(Math.Round((decimal)width / 2, MidpointRounding.AwayFromZero));
            if (index % 2 == 0)
            {
                return val2 + val1;
            }
            return val2 - val1;
        }
        #endregion
    }
}

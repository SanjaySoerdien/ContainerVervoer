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

        private int layer = 0;
        private int column = 0;
        private int row = 0;
        #endregion

        #region Constructor
        public Algorithm(Ship ship)
        {
            this.ship = ship;
        }
        #endregion

        #region Methods

        public List<Container> GetContainersByTypeAndSorted(ContainerType type)
        {
           return ship.Containers.Where(x => x.Type == type).OrderBy(x => x.Weight).Reverse().ToList();
        }

        public int TotalContainersToDistribute()
        {
            return normalContainers.Count +
                   cooledContainers.Count +
                   valuableContainers.Count +
                   cooledAndValuableContainers.Count;
        }

        public Ship ExecuteAlgorithm()
        {
            normalContainers = GetContainersByTypeAndSorted(ContainerType.Normal);
            cooledContainers = GetContainersByTypeAndSorted(ContainerType.Cooled);
            valuableContainers = GetContainersByTypeAndSorted(ContainerType.Valuable);
            cooledAndValuableContainers = GetContainersByTypeAndSorted(ContainerType.CooledValuable);
            layer= -1;
            bool done = true;
            while (done)
            {
                layer++;
                ship.Layers.Add(new Layer(ship.Length, ship.Width));
                done = FillLayersUntilDone();
            }
            return ship;
        }

        public bool FillLayersUntilDone()
        {
            int containersToDistribute = TotalContainersToDistribute();
            if (containersToDistribute > 0)
            {
                for (column = 0; column < ship.Length; column++)
                {
                    FillColumns();
                    if (TotalContainersToDistribute() <= 0)
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

        /// <summary>
        /// Checks if there were any containers placed in this layer
        /// </summary>
        public bool CheckIfAnyPlaced(int containersThisLayers)
        {
            if (TotalContainersToDistribute() == containersThisLayers)
            {
                List<Container> leftOverContainers = normalContainers.Concat(cooledContainers)
                                                                 .Concat(valuableContainers)
                                                                 .Concat(cooledAndValuableContainers).ToList();
                ship.Containers = leftOverContainers;
                return false;
            }
            return true;
        }

        public void FillColumns()
        {
            for (int i = 0; i < ship.Width; i++)
            {
                row = GenerateRowNr(i,ship.Width); 
                TryToPlaceContainer();
            }
        }

        public void TryToPlaceContainer() //TODO refactor
        {
            bool placed = false;
            if (cooledContainers.Count > 0 && column == 0 && !placed)
            {
                placed = PlaceCooledContainer();
            }
            if (normalContainers.Count > 0 && !placed)
            {
                placed = PlaceNormalContainer();
            }
            if (cooledAndValuableContainers.Count > 0 && column == 0 && !placed)
            {
                placed = PlaceCooledAndValuableContainer();
            }
            if (valuableContainers.Count > 0 && !placed)
            {
                placed = PlaceValuableContainer();
            }
        }

        //TODO refactor
        public bool PlaceCooledContainer()
        {
            if (CheckIfContainerIsPlaceable(cooledContainers[0]))
            {
                cooledContainers = PlaceContainer(cooledContainers);
                return true;
            }
            return false;
        }

        public bool PlaceNormalContainer() 
        {
            if (CheckIfContainerIsPlaceable(normalContainers[0]))
            {
                normalContainers = PlaceContainer(normalContainers);
                return true;
            }
            return false;
        }

        public bool PlaceValuableContainer()
        {
            if (CheckIfContainerIsPlaceable(valuableContainers[0]))
            {
                valuableContainers = PlaceContainer(valuableContainers);
                return true;
            }
            return false;
        }

        public bool PlaceCooledAndValuableContainer()
        {
            if (CheckIfContainerIsPlaceable(cooledAndValuableContainers[0]))
            {
                cooledAndValuableContainers = PlaceContainer(cooledAndValuableContainers);
                return true;
            }
            return false;
        }

        /// <summary>
        /// In fill column we already set priorities by cooled>normal>cooled and valuable>valuable
        /// For this reason we only look if we have a container below
        /// And if we are blocking a valuable container
        /// </summary>
        /// <returns>Returns a boolean representing placeablity</returns>
        public bool CheckIfContainerIsPlaceable(Container container)
        {
            if (!CheckBelowContainer(container) || !CheckNextToContainersIfCanBePlaced())
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Does the necessary checks for the container below
        /// </summary>
        ///<returns>Returns a boolean representing placeablity</returns>
        public bool CheckBelowContainer(Container container) 
        {
            if (layer > 0)
            {
                Space spaceUnder = ship.Layers[layer - 1].GetSpace(column, row);
                if (!CheckIfContainerIsPlaceableBasedOnWeight(container) || //check if the its allowed by weight
                    !CheckContainerBelowIfPlaceable(spaceUnder)) //check if there is a container below and if its valuable
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check if there is a container can be placed based on the leftover weight of the space.
        /// </summary>
        /// <returns>Returns a boolean representing placeablity</returns>
        public bool CheckIfContainerIsPlaceableBasedOnWeight(Container container) //TODO Refactor naar container en space
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
        /// <returns>Returns a boolean representing placeablity</returns>
        public bool CheckContainerBelowIfPlaceable(Space spaceUnder)
        {
            if (spaceUnder.Container != null && spaceUnder.Container.Type != ContainerType.Valuable &&
                spaceUnder.Container.Type != ContainerType.CooledValuable)
            {
                return true;
            }
            if(spaceUnder.Container != null && spaceUnder.Container.Type != ContainerType.CooledValuable)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Calls different methods to check if container can be placed
        /// </summary>
        /// <returns>Returns a boolean representing placeablity</returns>
        public bool CheckNextToContainersIfCanBePlaced()
        {
            if (column < 2) // if your on row 0 or 1, you can always place
            {
                return true;
            }

            if (!CheckIfContainerIsPlaced(column - 1)) //if there is an open space on the left , we can always plays.
            {
                return true;
          
            }

            //At least in 3rd column so we can check if there are containers next to us;
            if (CheckIfContainerIsPlaced(column - 2) && CheckIfContainerIsPlaced(column - 1))
            {
                Container containerInFront = ship.Layers[layer].GetContainer(column - 1, row);
                Container containerTwoInfront = ship.Layers[layer].GetContainer(column - 2, row);
                if (CheckOtherContainersToSeeIfYouCanPlace(containerInFront, containerTwoInfront)) // If there are containers
                                                                                                   // We retrieve them and check if we are allowed
                                                                                                   // to place them
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
            if (containerInfront != null && containerInfront.Type != ContainerType.Valuable ||     // The assumption can be made that the valuable has space on the left
                containerInfront != null && containerInfront.Type != ContainerType.CooledValuable) // Otherwise it would not have been placed.
            {
                return true;
            }                             
            if(containerInfront != null &&  containerInfront.Type == ContainerType.Valuable && containerTwoInfront == null || //if its valuable check if there is room on the other side so you can place it
               containerInfront != null && containerInfront.Type == ContainerType.CooledValuable && containerTwoInfront == null)     
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This Method returns true if there is container placed on te position.
        /// </summary>
        public bool CheckIfContainerIsPlaced(int columnToCheck)
        {
            return ship.Layers[layer].GetContainer(columnToCheck, row) == null;
        }

        /// <summary>
        /// Places the container on a space
        /// </summary>
        public List<Container> PlaceContainer(List<Container> containerList)
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


        /// <summary>
        /// Inverts the index to work from the inside out. Takes a width and index and inverts accordingly
        /// </summary>
        public int GenerateRowNr(int index,int width)
        {
            int val1 = Convert.ToInt32(Math.Round((decimal) index / 2, MidpointRounding.AwayFromZero));
            int val2 = Convert.ToInt32(Math.Round((decimal) (width- 1) / 2, MidpointRounding.AwayFromZero));
            if (index % 2 == 0)
            {
                return val2 + val1;
            }
            return val2 - val1;
        }

        /// <summary>
        /// Check if a list is fully emptied
        /// </summary>
        /// <returns>Returns a boolean if the list is fully emptied</returns>
        public bool CheckSuccessfulPlacement(List<Container> listToCheck) //TODO Check when awake
        {
            if (listToCheck.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if all containers are placed.
        /// </summary>
        /// <returns>Return a list of statuses</returns>
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
        #endregion
    }
}

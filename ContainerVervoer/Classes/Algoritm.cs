using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContainerVervoer.Enums;

namespace ContainerVervoer.Classes
{
    public class Algoritm
    {
        #region Fields
        private Ship ship;
        private List<Container> normalContainers;
        private List<Container> cooledContainers;
        private List<Container> valuableContainers;
        private List<Container> cooledAndValuableContainers;
        #endregion

        #region Constructor
        public Algoritm(Ship ship)
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
            int index = 0;
            while (FillLayer(index))
            {
                index++;
                ship.Layers.Add(new Layer(ship.Length, ship.Width));
            }
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

        public bool CheckSuccessfulPlacement(List<Container> listToCheck)
        {
            if (listToCheck.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool FillLayer(int layer)
        {
            int containersToDistrubute = TotalcontainersToDistrubute();
            if (containersToDistrubute > 0)
            {
                for (int column = 0; column < ship.Length - 1; column++)
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

                if (TotalcontainersToDistrubute() == containersToDistrubute)
                {
                    ship.Layers.RemoveAt(layer);
                    return false;
                }
            }
            return true;
        }

        public void FillFirstColumn(int layer, int column)
        {
            for (int i = 0; i < ship.Width - 1; i++)
            {
                int row = ship.ShipMath.GenerateRowNr(i, ship.Width -1);
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
                        PlaceCooledAndValueableContainer(layer, column, row);
                    }
                    else if (valuableContainers.Count > 0)
                    {
                        PlaceValuableContainer(layer, column, row);
                    }
                }
            }
        }

        public void FillColumns(int layer, int column)
        {
            for (int i = 0; i < ship.Width - 1; i++)
            {
                int row = ship.ShipMath.GenerateRowNr(i, ship.Width - 1);
                if (normalContainers.Count > 0)
                {
                    PlaceNormalContainer(layer, column, row);
                }
                else if (valuableContainers.Count > 0)
                {
                    PlaceValuableContainer(layer, column, row);
                }
            }
        }

        public void PlaceCooledContainer(int layer, int column, int row)
        {
            if (CheckIfContainerIsPlaceable(cooledContainers[0], layer, column, row) == Placeability.Placeable)
            {
                cooledContainers = PlaceContainer(cooledContainers, layer, column, row);
            }
        }

        public void PlaceNormalContainer(int layer, int column, int row)
        {
            if (CheckIfContainerIsPlaceable(normalContainers[0], layer, column, row) == Placeability.Placeable)
            {
                cooledContainers = PlaceContainer(normalContainers, layer, column, row);
            }
        }

        public void PlaceValuableContainer(int layer, int column, int row)
        {
            if (CheckIfContainerIsPlaceable(valuableContainers[0], layer, column, row) == Placeability.Placeable)
            {
                valuableContainers = PlaceContainer(valuableContainers, layer, column, row);
            }
        }

        public void PlaceCooledAndValueableContainer(int layer, int column, int row)
        {
            if (CheckIfContainerIsPlaceable(cooledAndValuableContainers[0], layer, column, row) == Placeability.Placeable)
            {
                cooledAndValuableContainers = PlaceContainer(cooledAndValuableContainers, layer, column, row);
            }
        }

        public Placeability CheckIfContainerIsPlaceable(Container container, int layer, int column, int row)
        {
            Placeability result = CheckIfContainerIsPlaceableBasedOnWeight(container, layer, column, row);
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

        public Placeability CheckIfContainerIsPlaceableBasedOnWeight(Container container, int layer, int column, int row)
        {
            if (layer > 0)
            {
                Space spaceUnder = ship.Layers[layer - 1].GetSpace(column, row);
                if (container.Weight < spaceUnder.WeightAllowedOnTop)
                {
                    return Placeability.Placeable;
                }
                return Placeability.Unplaceable;
            }
            return Placeability.Placeable;
        }

        public Placeability CheckIfContainerIsOnTopOfValuable(int layer, int column, int row)
        {
            if (layer > 0)
            {
                Space spaceUnder = ship.Layers[layer - 1].GetSpace(column, row);
                if (spaceUnder.Container != null && spaceUnder.Container.Valuable)
                {
                    return Placeability.Unplaceable;
                }
            }
            return Placeability.Placeable;
        }

        /// <summary>
        /// Checks the positions for valueable containers and returns an enum if its placeability or not
        /// </summary>
        public Placeability CheckIfContainerIsPlaceableBasedOnValuable(int layer, int column, int row)
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
        public Placeability CheckPositionsForValuables(int layer, int column, int row)
        {
            Placeability result = Placeability.Placeable;
            if (CheckIfContainerIsPlaced(layer, column - 1, row) && column >= 1) //check if there is container in front of the container if we are in the second column
            {
                if (CheckIfContainerIsPlaced(layer, column + 1, row))
                {
                    return Placeability.Unplaceable;
                }

                if (column >= 2 && CheckIfContainerIsPlaced(layer, column - 2, row)) //check if there is a container 2 rows in front of the container if we are in the third column
                {
                    result = CheckForNotBlockingValuableTwoRowsInfront( layer, column, row);
                }
            }
            return result;
        }

        /// <summary>
        /// This method checks if there is a valueable 2 rows infront so it does not block it from behind.
        /// </summary>
        public Placeability CheckForNotBlockingValuableTwoRowsInfront(int layer, int column, int row)
        {
            Container containerInFront = ship.Layers[layer].GetContainer(column - 1, row);
            Container containerInFrontOfInFront = ship.Layers[layer].GetContainer(column - 2, row);
            if (containerInFront != null && containerInFrontOfInFront.Valuable)
            {
                return Placeability.Unplaceable;
            }
            return Placeability.Placeable;
        }

        /// <summary>
        /// This Method returns true if there is container placed.
        /// </summary>
        public bool CheckIfContainerIsPlaced(int layer, int column, int row)
        {
            if (ship.Layers[layer].GetContainer(column, row) != null)
            {
                return true;
            }
            return false;
        }

        public Placeability CheckIfContainerIsPlaceableBasedOnCooled(int row)
        {
            if (row == 0) // TODO dit is een dubbele check? sneller maar minder leesbaar als in FillCollum; Vraag mening tim
            {
                return Placeability.Placeable;
            }

            return Placeability.Placeable;
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
        #endregion
    }
}

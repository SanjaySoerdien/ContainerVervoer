﻿using ContainerVervoer.Enums;

namespace ContainerVervoer.Classes
{
    
    public class Space
    {
        private readonly int maxWeightOnContainers = 120000;

        private Positon position;
        private Container container;
        private int totalStackWeight = 0;

        public int WeightAllowedOnTop => maxWeightOnContainers - totalStackWeight;

        public Space(Positon position)
        {
            this.position = position;
        }

        public int TotalStackWeight => totalStackWeight;
        public void PlaceContainer(Container container, int weightUnder)
        {
            this.totalStackWeight = weightUnder+container.Weight;
            this.container = container;
        }
        public void DELETEDIT()
        {
            //TODO delete deze method
        }
    }
}
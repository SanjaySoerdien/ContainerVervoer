using ContainerVervoer.Enums;

namespace ContainerVervoer.Classes
{
    
    public class Space
    {
        private readonly int maxWeightOnContainers = 120000;

        private Positon position;
        private Container container = null;
        private int totalStackWeight = 0;

        public Positon Position => position;

        public Container Container => container;
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
    }
}

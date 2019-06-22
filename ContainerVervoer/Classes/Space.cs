using ContainerVervoer.Enums;

namespace ContainerVervoer.Classes
{
    public class Space
    {
        #region Fields
        private const int maxWeightOnSpace = 150000;
        private readonly Positon position;
        private  Container container = null;
        private int weightOnFirstContainer = 0;
        #endregion

        #region Properties
        public Positon Position => position;
        public Container Container => container;
        public int WeightOnFirstContainer => weightOnFirstContainer;
        public int WeightAllowedOnTop => maxWeightOnSpace - weightOnFirstContainer;
        #endregion

        #region Constructor
        public Space(Positon position)
        {
            this.position = position;
        }
        #endregion

        #region Methods
        public void PlaceContainer(Container container, int weightUnder)
        {
            int totalWeight = weightUnder + container.Weight;
            this.weightOnFirstContainer = totalWeight;
            this.container = container;
        }

        public override string ToString()
        {
            return Container + "  \n  " + position;
        }
        #endregion

    }
}

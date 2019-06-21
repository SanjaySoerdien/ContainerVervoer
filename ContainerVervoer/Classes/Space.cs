using ContainerVervoer.Enums;

namespace ContainerVervoer.Classes
{
    public class Space
    {
        #region Fields
        private  readonly int maxWeightOnSpace = 120000;
        private readonly Positon position;
        private  Container container = null;
        private int weightOnFirstContainer = 0;
        #endregion

        #region Properties
        public Positon Position => position;
        public Container Container => container;
        public int TotalStackWeight => weightOnFirstContainer;
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
            this.weightOnFirstContainer = weightUnder + container.Weight;
            this.container = container;
        }
        #endregion

    }
}

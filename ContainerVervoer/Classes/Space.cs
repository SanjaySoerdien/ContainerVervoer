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
        public Space(Positon position,int weightUnderneath)
        {
            this.position = position;
            this.weightOnFirstContainer = weightUnderneath;
        }
        #endregion

        #region Methods
        public void PlaceContainer(Container container)
        {
            weightOnFirstContainer += container.Weight;
            this.container = container;
        }

        public override string ToString()
        {
            return Container + "  \n  " + position;
        }
        #endregion

    }
}

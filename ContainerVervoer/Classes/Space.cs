using ContainerVervoer.Enums;

namespace ContainerVervoer.Classes
{
    public class Space
    {
        #region Fields
        private const int maxWeightOnSpace = 150000;
        private readonly Positon position;
        private  Container container = null;
        private int weightOnSpace = 0;
        #endregion

        #region Properties
        public Positon Position => position;
        public Container Container => container;
        public int WeightOnSpace => weightOnSpace;
        public int WeightAllowedOnTop => maxWeightOnSpace - weightOnSpace;
        #endregion

        #region Constructor
        public Space(Positon position,int weightUnderneath)
        {
            this.position = position;
            this.weightOnSpace = weightUnderneath;
        }
        #endregion

        #region Methods
        public void PlaceContainer(Container container)
        {
            weightOnSpace += container.Weight;
            this.container = container;
        }

        public override string ToString()
        {
            return Container + "  \n  " + position;
        }
        #endregion

    }
}

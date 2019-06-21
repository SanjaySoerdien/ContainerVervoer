using ContainerVervoer.Enums;

namespace ContainerVervoer.Classes
{
    public class Space
    {
        #region Fields
        private  readonly int maxWeightOnContainers = 120000;
        private readonly Positon position;
        private  Container container = null;
        private int totalStackWeight = 0;
        #endregion

        #region Properties
        public Positon Position => position;

        public Container Container => container;
        public int TotalStackWeight => totalStackWeight;

        public int WeightAllowedOnTop => maxWeightOnContainers - totalStackWeight;
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
            this.totalStackWeight = weightUnder + container.Weight;
            this.container = container;
        }
        #endregion

    }
}

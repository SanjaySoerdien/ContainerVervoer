namespace ContainerVervoer.Classes
{
    public class Container
    {
        #region Fields
        private int weight;
        private bool valuable;
        private bool cooled;
        #endregion

        #region Properties
        public int Weight => weight;
        public bool Valuable => valuable;
        public bool Cooled => cooled;
        #endregion

        #region Constuctor
        public Container(int weight, bool valuable, bool cooled)
        {
            this.weight = weight;
            this.valuable = valuable;
            this.cooled = cooled;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            if (cooled && valuable)
            {
                return $"C:{weight}kg C&V";

            }
            else if(cooled)
            {
                return $"C:{weight}kg C";
            }
            else if (valuable)
            {
                return $"C:{weight}kg V";
            }
            return $"C:{weight}kg";
        }
        #endregion
    }
}

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
                return $"Cooled & Valuable Container \t \n Weight:{weight}kg";

            }
            else if(cooled)
            {
                return $"Cooled Container \t \t \n Weight:{weight}kg";
            }
            else if (valuable)
            {
                return $"Valuable Container \t \t \n Weight:{weight}kg";
            }
            return $"Container \t \t \n Weight:{weight}kg";
        }
        #endregion
    }
}

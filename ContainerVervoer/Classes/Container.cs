using ContainerVervoer.Enums;

namespace ContainerVervoer.Classes
{
    public class Container
    {
        #region Fields
        private int weight;
        private ContainerType type;
        /* private bool valuable;
        private bool cooled;*/
        #endregion

        #region Properties
        public int Weight => weight;
        public ContainerType Type => type;
        /*public bool Valuable => valuable;
        public bool Cooled => cooled;*/
        #endregion

        #region Constuctor
        /*public Container(int weight, bool valuable, bool cooled)
        {
            this.weight = weight;
            this.valuable = valuable;
            this.cooled = cooled;
        }*/

        public Container(int weight, ContainerType type)
        {
            this.weight = weight;
            this.type = type;
        }
        #endregion

        #region Methods
        /*        public override string ToString()
                {
                    if (cooled && valuable)
                    {
                        return $"{weight}kg C&V";
                    }
                    else if(cooled)
                    {
                        return $"{weight}kg C";
                    }
                    else if (valuable)
                    {
                        return $"{weight}kg V";
                    }
                    return $"{weight}kg";
                }*/

        public override string ToString()
        {
            if (type == ContainerType.CooledValuable)
            {
                return $"{weight}kg C&V";
            }
            else if (type == ContainerType.Cooled)
            {
                return $"{weight}kg C";
            }
            else if (type == ContainerType.Valuable)
            {
                return $"{weight}kg V";
            }
            return $"{weight}kg";
        }
        #endregion
    }
}

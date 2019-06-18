using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer
{
    public class Container
    {
        #region Fields
        private int weight;
        private bool valueable;
        private bool cooled;
        #endregion

        #region Properties
        public int Weight => weight;
        public bool Valueable => valueable;
        public bool Cooled => cooled;
        #endregion

        public Container(int weight, bool valuable, bool cooled)
        {
            this.weight = weight;
            this.valueable = valuable;
            this.cooled = cooled;
        }

        public override string ToString()
        {
            if (cooled && valueable)
            {
                return $"Cooled & valueable Container \n Weight:{weight}kg";

            }
            else if(cooled)
            {
                return $"Cooled Container \n Weight:{weight}kg";
            }
            else if (valueable)
            {
                return $"Valueable Container \n Weight:{weight}kg";
            }
            return $"Container \n Weight:{weight}kg";
        }
    }
}

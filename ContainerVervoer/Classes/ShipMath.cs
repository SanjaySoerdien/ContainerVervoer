using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContainerVervoer.Enums;

namespace ContainerVervoer.Classes
{
    public class ShipMath
    {
        #region Methods
        public int GenerateRowNr(int index,int width)
        {
            int val1 = Convert.ToInt32(Math.Round((decimal)index / 2, MidpointRounding.AwayFromZero));
            int val2 = Convert.ToInt32(Math.Round((decimal)width / 2, MidpointRounding.AwayFromZero));
            if (index % 2 == 0)
            {
                return val2 + val1;
            }
            return val2 - val1;
        }
        #endregion
    }
}

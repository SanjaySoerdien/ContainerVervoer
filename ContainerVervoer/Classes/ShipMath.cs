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
            if (index == 0)
            {
                return Convert.ToInt32(GetMiddle(Convert.ToDouble(width)));
            }
            return IndexAlternator(index, width);
        }

        public int IndexAlternator(int index,int width)
        {
            double dividableNumber = Convert.ToDouble(index);
            if (index % 2 == 0)
            {
                dividableNumber = index / 2;
                return Convert.ToInt32(GetMiddle(width) + dividableNumber);
            }
            dividableNumber = Math.Round((double) index / 2, MidpointRounding.AwayFromZero);
            return Convert.ToInt32(GetMiddle(width) - (int)dividableNumber);
        }

        public double GetMiddle(double width)
        {
            if (width % 2 == 0)
            {
                return width / 2;
            }
            return Math.Round(width / 2, MidpointRounding.AwayFromZero);
        }
        #endregion
    }
}

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
                return GetMiddle(width);
            }
            return IndexAlternator(index, width);
        }

        public int IndexAlternator(int index,int width)
        {
            double dividedNumber= index/2;
            if (index % 2 == 0)
            {
                dividedNumber = index / 2;
            }
            else
            {
                dividedNumber = Math.Round((double) index / 2, MidpointRounding.AwayFromZero);
            }

            if (index % 2 == 0)
            {
                return GetMiddle(width) + (int)dividedNumber;
            }

            return GetMiddle(width) - (int)dividedNumber;
        }
        public int GetMiddle(int length)
        {
            double value = Convert.ToDouble(length);
            if (value % 2 == 0)
            {
                return (int)value / 2;
            }
            return Convert.ToInt32((value / 2 )+ 0.5);
        }
        #endregion
    }
}

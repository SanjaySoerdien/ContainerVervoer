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
        public int GenerateRowNr(int index,int length)
        {
            if (index == 0)
            {
                return GetMiddle(length);
            }
            return IndexAlternator(index, length);
        }

        public int IndexAlternator(int index,int length)
        {
            double dividedNumber= index/2;
            if (index % 2 == 0)
            {
                dividedNumber = index / 2;
            }
            else
            {
                dividedNumber = (index / 2 + 0.5);
                dividedNumber = Math.Round((double) index / 2, MidpointRounding.AwayFromZero);
            }

            if (index % 2 == 0)
            {
                return GetMiddle(length) + (int)dividedNumber;
            }

            return GetMiddle(length) - (int)dividedNumber;
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
    }
}

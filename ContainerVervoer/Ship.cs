using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer
{
    public class Ship
    {
        private int shipLenght = -1;
        private int shipWidth = -1;
        private int shipHeigth = -1;
        private int shipMaxWeight = -1;
        private int shipCurrentWeight = -1;
        private int shipBalance = -1;//TODO maak in view ? enzo? idk maybe remove

        public Ship(int width, int lenght)
        {
            shipLenght = lenght;
            shipWidth = width;
            shipMaxWeight = lenght * width * 150;
        }
    }
}

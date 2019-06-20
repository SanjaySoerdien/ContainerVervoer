using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer
{
    class Space
    {
        private Container container;
        private int weightAllowedOnTop;

        private void placeContainer(Container container, int weightUnder)
        {
            weightAllowedOnTop = 120000 - weightUnder;
            this.container = container;
        }
        public void DELETEDIT()
        {
            //TODO delete deze method
        }
    }
}

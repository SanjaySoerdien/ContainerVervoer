using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer
{
    class Layer
    {
        private List<List<Space>> layerLayout;
        public List<List<Space>> LayerLayout => layerLayout;

        public Layer(int length)
        {
            for (int I = 0; I < length; I++)
            {
                List<Space> collumn = new List<Space>();
                layerLayout.Add(collumn);
            }
        }
    }
}

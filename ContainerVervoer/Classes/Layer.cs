using System.Collections.Generic;
using ContainerVervoer.Enums;

namespace ContainerVervoer.Classes
{
    public class Layer
    {
        private List<List<Space>> layerLayout;
        public List<List<Space>> LayerLayout => layerLayout;

        public Layer(int length,int width)
        {
            for (int x = 0; x < length; x++)
            {
                List<Space> column = new List<Space>();
                for (int y = 0; y < width; y++)
                {
                    double halfwaymark = width / 2;
                    if (y < width / 2)
                    {
                        column.Add(new Space(Positon.Left));
                    }
                    else
                    {
                        //todo HIER BEN JE
                    }

                }
                layerLayout.Add(column);
            }
        }

    }
}

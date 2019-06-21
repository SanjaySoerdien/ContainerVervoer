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
            layerLayout = new List<List<Space>>();
            for (int x = 0; x < length; x++)
            {
                List<Space> column = new List<Space>();
                for (int y = 0; y < width; y++)
                {
                    double halfwaymark = width / 2;
                    if (y < halfwaymark)
                    {
                        column.Add(new Space(Positon.Left));
                    }
                    else
                    {
                        column.Add(new Space(Positon.Right));
                    }
                }
                layerLayout.Add(column);
            }
        }

        public Container GetContainer(int column, int row) //TODO use this one more
        {
            return layerLayout[column][row].Container;

        }

        public Space GetSpace(int column, int row) //TODO use this one more
        {
            return layerLayout[column][row];
        }
}
}

﻿using System;
using System.Collections.Generic;
using ContainerVervoer.Enums;

namespace ContainerVervoer.Classes
{
    public class Layer
    {
        #region Fields
        private List<List<Space>> layerLayout;
        #endregion

        #region Properties
        public List<List<Space>> LayerLayout => layerLayout;
        #endregion

        #region Constructor
        public Layer(int length,int width)
        {
            layerLayout = new List<List<Space>>(); 
            for (int x = 0; x < length ; x++)
            {
                //Create columns
                List<Space> column = new List<Space>();
                for (int y = 0; y < width; y++)
                {
                    //Create rows
                    int middleValue = Convert.ToInt32(Math.Floor((decimal)width / 2)); 
                    if (y == middleValue && width % 2 == 1)
                    {
                        column.Add(new Space(Positon.Middle));
                    }
                    else if(y >= middleValue)
                    {
                        column.Add(new Space(Positon.Right));
                    }
                    else if (y < middleValue)
                    {
                        column.Add(new Space(Positon.Left));
                    }
                }
                layerLayout.Add(column);
            }
        }
        #endregion

        #region Methods
        public Container GetContainer(int column, int row) 
        {
            return layerLayout[column][row].Container;
        }

        public Space GetSpace(int column, int row) 
        {
            return layerLayout[column][row];
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using ContainerVervoer.Enums;

namespace ContainerVervoer.Classes
{
    public class Ship
    {
        #region Fields
        private int length;
        private int width;
        private int maxWeight;

        private int currentWeight;
        private int weightLeft;
        private int weightRight;

        private List<Container> containers;
        private List<Layer> layers;

        private Algorithm algoritm;
        #endregion

        #region Properties
        public int Length => length;
        public int Width => width;
        public int MaxWeight => maxWeight;
        public int CurrentWeight => currentWeight;
        public decimal Marge => Math.Round(Convert.ToDecimal(((double)weightLeft / weightRight)-1)*100 , 2);
        public int WeightLeft => weightLeft;
        public int WeightRight => weightRight;

        public List<Container> Containers
        {
            get => containers;
            set => containers = value;
        }
        public List<Layer> Layers => layers;
        #endregion

        #region Constructors
        public Ship(int width, int length)
        {
            containers = new List<Container>();
            this.length = length;
            this.width = width;
            maxWeight = length * width * 150000;
            layers = new List<Layer>();
            layers.Add(new Layer(this.length, this.width));
        }
        #endregion

        #region Methods
        public Status AddContainer(Container container)
        {
            if ((currentWeight + container.Weight) >= maxWeight)
            {
                return Status.TooHeavy;
            }
            currentWeight += container.Weight;
            containers.Add(container);
            return Status.Succes;
        }

        public void RemoveContainer(int index)
        {
            containers.RemoveAt(index);
        }

        public void RemoveAllContainers()
        {
            containers.Clear();
            currentWeight = 0;
            weightLeft = 0;
            weightRight = 0;
        }

        public void ClearLayers()
        {
            layers = new List<Layer> {new Layer(this.length, this.width)};
        }

        public Status GenerateRandomContainers(int amount)
        {
            Status result = Status.Succes;
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                int weight = rnd.Next(4000, 30000);
                ContainerType type = ContainerType.Normal;
                if (rnd.Next(1, 12).Equals(7))
                {
                    if (rnd.Next(1, 15).Equals(1))
                    {
                        type = ContainerType.CooledValuable;
                    }
                    else
                    {
                        type = (ContainerType)rnd.Next(0, 2);
                    }
                }
                Container cont = new Container(weight,type);
                result = AddContainer(cont);
                if (result != Status.Succes)
                {
                    return result;
                }
            }
            return result;
        }

        public bool CheckWeight()
        {
            int totalWeight = 0;

            foreach (Container container in Containers)
            {
                totalWeight += container.Weight;
            }
            if (totalWeight < (maxWeight / 2))
            {
                return false;
            }
            return true;
        }

        public void AddWeight(Space space, Container container)
        {
            currentWeight += container.Weight;
            if (space.Position == Positon.Middle)
            {
                return;
            }
            if (space.Position == Positon.Left)
            {
                weightLeft += container.Weight;
                return;
            }
            weightRight += container.Weight;
        }

        public List<Status> ExecuteAlgoritm()
        {
            this.currentWeight = 0;
            this.weightLeft = 0;
            this.weightRight = 0;
            algoritm = new Algorithm(this);
            Ship resultShip = algoritm.ExecuteAlgorithm();
            this.length = resultShip.length;
            this.width = resultShip.width;
            this.maxWeight = resultShip.maxWeight;
            this.currentWeight = resultShip.currentWeight;
            this.weightLeft = resultShip.weightLeft;
            this.weightRight = resultShip.weightRight;
            this.containers = resultShip.containers;
            this.layers = resultShip.layers;
            return algoritm.GetResult();
        }
        #endregion
    }
}

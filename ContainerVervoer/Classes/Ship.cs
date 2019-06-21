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

        private Algoritm algoritm;
        #endregion

        #region Properties
        public int Length => length;
        public int Width => width;
        public int MaxWeight => maxWeight;
        public int CurrentWeight => currentWeight;
        public double Balance => Math.Round(Convert.ToDouble((double)weightLeft / weightRight), 2);
        public int WeightLeft => weightLeft;
        public int WeightRight => weightRight;
        public List<Container> Containers => containers;
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
            Status result = Status.Succes;
            if (currentWeight + container.Weight >= maxWeight)
            {
                return Status.TooHeavy;
            }
            containers.Add(container);
            currentWeight += container.Weight;
            return result;
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

        public void GenerateRandomContainers(int amount)
        {
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                int weight = rnd.Next(4000, 30000);
                bool valuable = rnd.Next(1, 15).Equals(2);
                bool cooled = rnd.Next(1, 15).Equals(2);
                Container cont = new Container(weight, valuable, cooled);
                AddContainer(cont);
            }
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
            algoritm = new Algoritm(this);
            Ship resultShip = algoritm.ExecuteAlgoritm();
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

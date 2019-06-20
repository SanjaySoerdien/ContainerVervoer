using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer
{
    public class Ship
    {
        #region Fields
        private int length;
        private int width;
        private int heigth;
        private int maxWeight;
        private int currentWeight;
        private int balance;//TODO maak in view ? enzo? idk maybe remove
        private int weightLeft;
        private int weightRight;
     
        private List<Container> containers;
        private List<Layer> layers;
        #endregion

        #region Properties
        public int Length => length;
        public int Width => width;
        public int Heigth => heigth;
        public int MaxWeight => maxWeight;
        public int CurrentWeight => currentWeight;
        public int Balance => balance;
        public int WeightLeft => weightLeft;
        public int WeightRight => weightRight;
        public List<Container> Containers => containers;
        #endregion
   
        public Ship(int width, int length)
        {
            containers = new List<Container>();
            this.length = length;
            this.width = width;
            maxWeight = length * width * 150000;
            layers = new List<Layer>();
        }

        public ErrorMessage addContainer(Container container)
        {
            ErrorMessage result = ErrorMessage.Succes;
            if (currentWeight + container.Weight >= maxWeight)
            {
                return ErrorMessage.TooHeavy;
            }
            containers.Add(container);
            currentWeight += container.Weight;
            return result;
        }

        public void removeContainer(int index)
        {
            containers.RemoveAt(index);
        }

        public void removeAllContainers()
        {
            containers.Clear();
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
                addContainer(cont);
            }
        }

        public bool checkWeight()
        {
            int totalWeight = 0;
            int weightToCheck = maxWeight / 2;

            foreach (Container container in Containers)
            {
                totalWeight += container.Weight;
            }
            if (totalWeight < maxWeight / 2)
            {
                return false;
            }
            return true;
        }

        private List<Container> GetAllNormalContainers()
        {
            return containers.Where(x => !x.Valuable && !x.Cooled).OrderBy(x => x.Weight).Reverse().ToList();

        }

        private List<Container> GetAllValueableContainers()
        {
            return containers.Where(x => x.Valuable && !x.Cooled).OrderBy(x => x.Weight).Reverse().ToList();
        }

        private List<Container> GetAllCooledContainers()
        {
            return containers.Where(x => x.Cooled && !x.Valuable).OrderBy(x => x.Weight).Reverse().ToList();
        }

        private List<Container> GetAllValueableAndCooledContainers()
        {
            return containers.Where(x => x.Valuable && x.Cooled).OrderBy(x => x.Weight).Reverse().ToList();
        }

        private List<Container> normalContainers;
        private List<Container> cooledContainers;
        private List<Container> valueableContainers;
        private List<Container> cooledAndValueableContainers;

        private int totalcontainersToDistrubute()
        {
                return normalContainers.Count +
                       cooledContainers.Count +
                       valueableContainers.Count +
                       cooledAndValueableContainers.Count;
        }

        public void PlaceContainersInShip()
        {
            List<Container> normalContainers = GetAllNormalContainers();
            List<Container> cooledContainers = GetAllCooledContainers();
            List<Container> valueableContainers = GetAllValueableContainers();
            List<Container> cooledAndValueableContainers = GetAllValueableAndCooledContainers();
            int index = -1;
            while (totalcontainersToDistrubute()>0)
            {
                index++;
                layers.Add(new Layer(this.length));
                fillLayer(index);
            }
        }

        private void fillLayer(int index)
        {
            
            for (int collumn = 0; collumn < 12; collumn++) //todo maak logische for die over de collum looped
            {
                if (collumn == 0)
                {
                    fillFirstCollumn();
                }
                else
                {
                    fillCollums();
                }
            }
        }

        private void fillFirstCollumn()
        {
            if (normalContainers.Count + cooledContainers.Count > 0)
            {
                if (cooledContainers.Count > 0)
                {
                    PlaceCooled();
                }
                else if (normalContainers.Count > 0)
                {
                    PlaceNormal();
                }
            }
        }

        private void fillCollums()
        {

        }
        private void PlaceCooled()
        {
            weightLeft++;
            weightRight++;
        }

        private void PlaceNormal()
        {
            weightLeft++;
            weightRight++;
        }

   
    }
}

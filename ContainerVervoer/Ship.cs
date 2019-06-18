using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer
{
    public class Ship
    {
        private int length;
        private int width;
        private int heigth;
        private int maxWeight;
        private int currentWeight;
        private int balance;//TODO maak in view ? enzo? idk maybe remove
        private int weightLeft;
        private int weightRight;
     
        private List<Container> containers;
        private List<List<List<Container>>> shipLayout = new List<List<List<Container>>>();

        private int amountCooled;
        private int amountValueable;
        private int maxValueables;
        private int maxCooled;

        public int Length => length;
        public int Width => width;
        public int Heigth => heigth;
        public int MaxWeight => maxWeight;
        public int CurrentWeight => currentWeight;
        public int Balance => balance;
        public int WeightLeft => weightLeft;
        public int WeightRight => weightRight;
        public List<Container> Containers => containers;
   

        public Ship(int width, int length)
        {
            containers = new List<Container>();
            this.length = length;
            this.width = width;
            maxWeight = length * width * 150000;
            maxValueables = length * width;
            InstanceAllLists();
        }

        private void InstanceAllLists()
        {
            for (int i = 0; i < width; i++)
            {
                List<List<Container>> columnList = new List<List<Container>>();
                for (int x = 0; x < length; x++)
                {
                    columnList.Add(new List<Container>());
                }
                shipLayout.Add(columnList);
            }
        }

        public string addContainer(Container container)
        {
            string result = "Succes";
            if (currentWeight + container.Weight >= maxWeight)
            {
                return "Too heavy";
            }
            else if (container.Valueable)
            {
                if (amountValueable > maxValueables)
                {
                    return "Too many valueables";
                }
                amountValueable++;
            }
            else if (container.Cooled)
            {
                amountCooled++;
            }
            containers.Add(container);
            currentWeight += container.Weight;
            return result;
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

        private List<Container> sortContainers()
        {
            List<Container> templist = new List<Container>();
            foreach (Container c in containers.OrderBy(x => x.Valueable).ThenBy(x => x.Cooled).ThenBy(x => x.Weight).Reverse())
            {
                templist.Add(c);
            }
            return templist;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ExceptionServices;
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
        private int layers;
     
        private List<Container> containers;
        private List<List<List<Container>>> shipLayout = new List<List<List<Container>>>();

        private int amountValueable = 0;
        private int maxValueables = 0;

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
            InstanceLists();
        }

        private void InstanceLists()
        {
            for (int i = 0; i < width; i++)
            {
                List<List<Container>> rowList = new List<List<Container>>();
                for (int x = 0; x < length; x++)
                {
                    List<Container> collum = new List<Container>();
                    rowList.Add(collum);
                }
                shipLayout.Add(rowList);
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
                if (amountValueable >= maxValueables)
                {
                    return "Too many valueables";
                }
                amountValueable++;
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

        public int checkWeight()
        {
            int totalWeight = 0;
            int weightToCheck = maxWeight / 2;

            foreach (Container container in Containers)
            {
                totalWeight += container.Weight;
            }
            if (totalWeight < maxWeight / 2)
            {
                return  weightToCheck - totalWeight;
            }
            return -1;
        }

        private List<Container> GetAllNormalContainers()
        {
            List<Container> result = new List<Container>();
            foreach (Container container in containers.Where(x => !x.Valueable && !x.Cooled).OrderBy(x => x.Weight).Reverse())
            {
                result.Add(container);
            }
            return result;
        }

        private List<Container> GetAllValueableContainers()
        {
            List<Container> result = new List<Container>();
            foreach (Container container in containers.Where(x => x.Valueable && !x.Cooled).OrderBy(x => x.Weight).Reverse())
            {
                result.Add(container);
            }
            return result;
        }

        private List<Container> GetAllCooledContainers()
        {
            List<Container> result = new List<Container>();
            foreach (Container container in containers.Where(x => x.Cooled && !x.Valueable).OrderBy(x => x.Weight).Reverse())
            {
                result.Add(container);
            }
            return result;
        }

        private List<Container> GetAllValueableAndCooledContainers()
        {
            List<Container> result = new List<Container>();
            foreach (Container container in containers.Where(x => x.Valueable && x.Cooled).OrderBy(x => x.Weight).Reverse())
            {
                result.Add(container);
            }
            return result;
        }

        private List<Container> normalContainers;
        private List<Container> cooledContainers;
        private List<Container> valueableContainers;
        private List<Container> cooledAndValueableContainers;

        public void PlaceContainersInShip()
        {
            List<Container> normalContainers = GetAllNormalContainers();
            List<Container> cooledContainers = GetAllCooledContainers();
            List<Container> valueableContainers = GetAllValueableContainers();
            List<Container> cooledAndValueableContainers = GetAllValueableAndCooledContainers();
            //todo fillship hier ofzo? even kijken

        }

        private void fillShip()
        {
            layers = 0;
            while (normalContainers.Count + 
                   cooledContainers.Count + 
                   valueableContainers.Count +
                   cooledAndValueableContainers.Count > 0) //TODO maybe implement detectie voor laatste laag hier?
            {
                for (int row = 0; row < shipLayout[layers].Count - 1; row++)
                {
                    for (int collum = 0; collum < shipLayout[layers][row].Count - 1; collum++) 
                    {
                        if (row == 0 || row == length - 1) 
                        {
                            if (cooledContainers.Count > 0)
                            {
                                shipLayout[layers][row].Add(cooledContainers[0]);
                                cooledContainers.RemoveAt(0);
                            }
                            else if (normalContainers.Count > 0)
                            {
                                //todo CHECK voor gewicht onder? gelimiteerd door inputs?
                                shipLayout[layers][row].Add(normalContainers[0]);
                                normalContainers.RemoveAt(0);
                            }
                            else if (cooledAndValueableContainers.Count > 0)
                            {
                                //todo check voor bovenste laag en plek naast 
                            }
                            else if (valueableContainers.Count > 0)
                            {
                                //todo check voor bovenste laag
                            }
                        }
                        else
                        {
                            if (normalContainers.Count > 0)
                            {
                                //todo CHECK voor gewicht onder? gelimiteerd door inputs?
                                shipLayout[layers][row].Add(normalContainers[0]);
                                normalContainers.RemoveAt(0);
                            }
                            else if (cooledAndValueableContainers.Count > 0)
                            {
                                //todo check voor bovenste laag en plek naast 
                            }
                            else if (valueableContainers.Count > 0)
                            {
                                //todo check voor bovenste laag
                            }
                        }
                    }
                }
                if (false) //TODO statement to check if adding is even possible cuz cooled stuff 
                {
                    layers++;
                    shipLayout.Add(new List<List<Container>>());
                }
                else
                {
                    return;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ContainerVervoer.Classes;
using NUnit.Framework;

namespace ContainerTests
{
    class ShipTests
    {
        private Ship ship;
        private Ship ship2;

        List<Container> containers = new List<Container>
        {
            new Container(14000,true,false)
        };

        [SetUp]
        public void Setup()
        {
            ship = new Ship(2,2);
            ship2 = new Ship(4, 4);
            
            ship2.GenerateRandomContainers(100);
        }

        [Test]
        public void Test1()
        {
            ship.AddContainer()
        }

        
    }
}

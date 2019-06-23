using System;
using System.Collections.Generic;
using System.Text;
using ContainerVervoer.Classes;
using ContainerVervoer.Enums;
using NUnit.Framework;

namespace ContainerTests
{
    class ShipTests
    {
        private Ship ship1;
        private Ship ship2;

        List<Container> containers = new List<Container>
        {
            new Container(14000,ContainerType.Normal)
        };

        [SetUp]
        public void Setup()
        {
            ship1 = new Ship(2,2);
            ship2 = new Ship(10, 5);
        }

        [Test]
        public void GenerateContainers_100_returnCount100()
        {
            var ship = ship2;
            ship.GenerateRandomContainers(100);
            var result = ship.Containers.Count;
            Assert.That(result,Is.EqualTo(100));
        }
    }
}

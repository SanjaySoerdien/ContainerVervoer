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

        [Test]
        public void GenerateContainers_2000_returnTooHeavy()
        {
            var ship = ship1;
            var result = ship.GenerateRandomContainers(2000);
            Assert.That(result, Is.EqualTo(Status.TooHeavy));
        }


        [Test]
        public void RemoveAllContainers_120ThenRemoveAll_returnCount0()
        {
            var ship = ship2;
            ship.GenerateRandomContainers(120);
            ship.RemoveAllContainers();
            var result = ship.Containers.Count;
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void RemoveContainer_Add1ContainerThenRemove_return0()
        {
            var ship = ship2;
            ship.AddContainer(new Container(0, ContainerType.Normal));
            ship.RemoveContainer(0);
            var result = ship.Containers.Count;
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CheckWeight_TooHeavy_returnfalse()
        {
            var ship = ship1;
            List<Container> tooHeavyContainers = new List<Container>
            {
                new Container(300005, ContainerType.Valuable), // is 600010 weight
                new Container(300005, ContainerType.Normal)    // min is 300 000 max is 600 000
            };
            ship.Containers = tooHeavyContainers;
            var result = ship.CheckWeight();
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CheckWeight_TooLight_returnfalse()
        {
            var ship = ship1;
            List<Container> tooLightContainers = new List<Container>
            {
                new Container(4000, ContainerType.Valuable), // is 8000 weight
                new Container(4000, ContainerType.Normal)    //min is 300 000 max is 600 000
            };
            ship.Containers = tooLightContainers;
            var result = ship.CheckWeight();
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CheckWeight_350000_returntrue()
        {
            var ship = ship1;
            List<Container> validContainers = new List<Container>
            {
                new Container(175000, ContainerType.Valuable), // is 350000 weight
                new Container(175000, ContainerType.Normal)    // min is 300 000 max is 600 000
            };
            ship.Containers = validContainers;
            var result = ship.CheckWeight();
            Assert.That(result, Is.EqualTo(true));
        }

    }
}

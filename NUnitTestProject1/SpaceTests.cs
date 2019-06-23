using System;
using System.Collections.Generic;
using System.Text;
using ContainerVervoer.Classes;
using ContainerVervoer.Enums;
using NUnit.Framework;

namespace ContainerTests
{
    class SpaceTests
    {
        private Space MiddleSpace;
        private Space LeftSpace;
        private Space RightSpace;

        [SetUp]
        public void Setup()
        {
            MiddleSpace = new Space(Positon.Left,100000);
            LeftSpace = new Space(Positon.Middle,72000);
            RightSpace = new Space(Positon.Right,50000);
        }

        [Test]
        public void PlaceContainer_Container12000kgValuableLeftSpace_ReturnContainer()
        {
            Container containerToPlace = new Container(12000,ContainerType.Valuable);
            LeftSpace.PlaceContainer(containerToPlace);
            Assert.That(LeftSpace.Container, Is.EqualTo(containerToPlace));
        }

        [Test]
        public void PlaceContainer_Container15000kgCooledValuableMiddleSpace_ReturnContainer()
        {
            Container containerToPlace = new Container(15000, ContainerType.CooledValuable);
            MiddleSpace.PlaceContainer(containerToPlace);
            Assert.That(MiddleSpace.Container, Is.EqualTo(containerToPlace));
        }

        [Test]
        public void PlaceContainer_Container15000kgNormalRightSpace_ReturnContainer()
        {
            Container containerToPlace = new Container(15000, ContainerType.Normal);
            RightSpace.PlaceContainer(containerToPlace);
            Assert.That(RightSpace.Container, Is.EqualTo(containerToPlace));
        }
    }
}

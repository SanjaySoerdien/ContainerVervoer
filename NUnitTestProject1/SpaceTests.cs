using System;
using System.Collections.Generic;
using System.Text;
using ContainerVervoer.Classes;
using ContainerVervoer.Enums;
using NUnit.Framework;

namespace NUnitTestProject1
{
    class SpaceTests
    {
        private Space MiddleSpace = new Space(Positon.Left);
        private Space LeftSpace = new Space(Positon.Middle);
        private Space RightSpace = new Space(Positon.Right);
        [SetUp]
        public void Setup()
        {
            MiddleSpace = new Space(Positon.Left);
            LeftSpace = new Space(Positon.Middle);
            RightSpace = new Space(Positon.Right);
        }

        [Test]
        public void PlaceContainer_Container12000kgValueable_ReturnContainer()
        {
            Container containerToPlace = new Container(12000,ContainerType.Valuable);
            MiddleSpace.PlaceContainer(containerToPlace,4000);
            Assert.That(MiddleSpace.Container, Is.EqualTo(containerToPlace));
        }

        public void PlaceContainer_Container15000kgCooledValueable_ReturnContainer()
        {
            Container containerToPlace = new Container(15000, ContainerType.CooledValuable);
            MiddleSpace.PlaceContainer(containerToPlace, 7000);
            Assert.That(MiddleSpace.Container, Is.EqualTo(containerToPlace));
        }
    }
}

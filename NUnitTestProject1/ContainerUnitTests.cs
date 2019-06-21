using System;
using System.Collections.Generic;
using System.Text;
using ContainerVervoer.Classes;
using NUnit.Framework;

namespace NUnitTestProject1
{
    class ContainerUnitTests
    {
        private Ship ship;
        [SetUp]
        public void Setup()
        {
            ship=new Ship(12,14);
            ship.GenerateRandomContainers(500);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}

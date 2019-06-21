using System;
using System.Collections.Generic;
using System.Text;
using ContainerVervoer.Classes;
using NUnit.Framework;

namespace NUnitTestProject1
{
    class MathTests
    {
        private ShipMath shipMath;
        [SetUp]
        public void Setup()
        {
            shipMath = new ShipMath();
        }

        [Test]
        public void GenerateRowNrEven_index0width20_returnMiddle10()
        {
            var result = shipMath.GenerateRowNr(0, 20);
            Assert.That(result,Is.EqualTo(10));
        }

        [Test]
        public void GenerateRowNrEven_index4width20_return12()
        {
            var result = shipMath.GenerateRowNr(4, 20);
            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void GenerateRowNrOdd_index4width41_return23()
        {
            var result = shipMath.GenerateRowNr(4, 41);
            Assert.That(result, Is.EqualTo(23));
        }

        [Test]
        public void GenerateRowNrOdd_index15width53_return19()
        {
            var result = shipMath.GenerateRowNr(15, 53);
            Assert.That(result, Is.EqualTo(19));
        }

        [Test]
        public void IndexAlternatorOdd_index3width18_return7()
        {
            var result = shipMath.IndexAlternator(3,18);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void IndexAlternatorEven_index6width9_return8()
        {
            var result = shipMath.IndexAlternator(6,9);
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void IndexAlternatorOdd_index10width11_return11()
        {
            var result = shipMath.IndexAlternator(10,11);
            Assert.That(result, Is.EqualTo(11));
        }

        [Test]
        public void IndexAlternatorOdd_index2width15_return9()
        {
            var result = shipMath.IndexAlternator(2,15);
            Assert.That(result, Is.EqualTo(9));
        }

        [Test]
        public void GetMiddleEve_index4width8_return4()
        {
            var result = shipMath.GetMiddle(8);
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void GetMiddleOdd_width9_return5()
        {
            var result = shipMath.GetMiddle(9);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void GenerateRowNrOdd_index0width53_return27()
        {
            var result = shipMath.GenerateRowNr(0, 53);
            Assert.That(result, Is.EqualTo(27));
        }

        [Test]
        public void GenerateRowNrOdd_index1width53_return26()
        {
            int result = shipMath.GenerateRowNr(1, 53);
            Assert.That(result, Is.EqualTo(26));
        }

        [Test]
        public void GenerateRowNrOdd_index2width53_return28()
        {
            int result = shipMath.GenerateRowNr(2, 53);
            Assert.That(result, Is.EqualTo(28));
        }

        [Test]
        public void GenerateRowNrOdd_index01width0_return5()
        {
            int result = shipMath.GenerateRowNr(0, 10);
            Assert.That(result, Is.EqualTo(5));
        }
    }
}

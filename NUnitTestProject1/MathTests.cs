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
        public void GenerateRowNrEven_index0length20_returnMiddle10()
        {
            int result = shipMath.GenerateRowNr(0, 20);
            Assert.That(result,Is.EqualTo(10));
        }

        [Test]
        public void GenerateRowNrEven_index4length20_return()
        {
            int result = shipMath.GenerateRowNr(4, 20);
            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void GenerateRowNrOdd_index4length41_return()
        {
            int result = shipMath.GenerateRowNr(4, 41);
            Assert.That(result, Is.EqualTo(23));
        }

        [Test]
        public void GenerateRowNrOdd_index15length53_return12()
        {
            int result = shipMath.GenerateRowNr(15, 53);
            Assert.That(result, Is.EqualTo(19));
        }

        [Test]
        public void IndexAlternatorOdd_index3length18_return7()
        {
            var result = shipMath.IndexAlternator(3,18);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void IndexAlternatorEven_index6length9_return()
        {
            var result = shipMath.IndexAlternator(6,9);
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void IndexAlternatorOdd_index10length11_return()
        {
            var result = shipMath.IndexAlternator(10,11);
            Assert.That(result, Is.EqualTo(11));
        }

        [Test]
        public void IndexAlternatorOdd_index2length15_returnNegative()
        {
            var result = shipMath.IndexAlternator(2,15);
            Assert.That(result, Is.EqualTo(9));
        }


        [Test]
        public void GetMiddleEve_index4length8_return4()
        {
            int result = shipMath.GetMiddle(8);
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void GetMiddleOdd_length9_return5()
        {
            int result = shipMath.GetMiddle(9);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void GenerateRowNrOdd_index0length53_return27()
        {
            int result = shipMath.GenerateRowNr(0, 53);
            Assert.That(result, Is.EqualTo(27));
        }

        [Test]
        public void GenerateRowNrOdd_index1length53_return26()
        {
            int result = shipMath.GenerateRowNr(1, 53);
            Assert.That(result, Is.EqualTo(26));
        }

        [Test]
        public void GenerateRowNrOdd_index2length53_return28()
        {
            int result = shipMath.GenerateRowNr(2, 53);
            Assert.That(result, Is.EqualTo(28));
        }
    }
}

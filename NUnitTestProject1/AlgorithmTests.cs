using System;
using System.Collections.Generic;
using System.Text;
using ContainerVervoer.Classes;
using NUnit.Framework;

namespace NUnitTestProject1
{
    class AlgorithmTests
    {
        private Algorithm algoritm;
        [SetUp]
        public void Setup()
        {
            algoritm = new Algorithm(new Ship(5,10));
        }

        [Test]
        public void GenerateRowNrEven_index0width20_returnMiddle10()
        {
            var result = algoritm.GenerateRowNr(0, 20);
            Assert.That(result,Is.EqualTo(10));
        }

        [Test]
        public void GenerateRowNrEven_index4width20_return12()
        {
            var result = algoritm.GenerateRowNr(4, 20);
            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void GenerateRowNrOdd_index4width41_return22()
        {
            var result = algoritm.GenerateRowNr(4, 41);
            Assert.That(result, Is.EqualTo(22));
        }

        [Test]
        public void GenerateRowNrOdd_index15width53_return18()
        {
            var result = algoritm.GenerateRowNr(15, 53);
            Assert.That(result, Is.EqualTo(18));
        }

        [Test]
        public void IndexAlternatorOdd_index3width18_return7()
        {
            var result = algoritm.GenerateRowNr(3,18);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void IndexAlternatorEven_index6width9_return7()
        {
            var result = algoritm.GenerateRowNr(6,9);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void IndexAlternatorOdd_index10width11_return10()
        {
            var result = algoritm.GenerateRowNr(10,11);
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void IndexAlternatorOdd_index2width15_return8()
        {
            var result = algoritm.GenerateRowNr(2,15);
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void GenerateRowNrOdd_index0width53_return26()
        {
            var result = algoritm.GenerateRowNr(0, 53);
            Assert.That(result, Is.EqualTo(26));
        }

        [Test]
        public void GenerateRowNrOdd_index1width53_return25()
        {
            int result = algoritm.GenerateRowNr(1, 53);
            Assert.That(result, Is.EqualTo(25));
        }

        [Test]
        public void GenerateRowNrOdd_index2width53_return27()
        {
            int result = algoritm.GenerateRowNr(2, 53);
            Assert.That(result, Is.EqualTo(27));
        }

        [Test]
        public void GenerateRowNrOdd_index01width0_return5()
        {
            int result = algoritm.GenerateRowNr(0, 10);
            Assert.That(result, Is.EqualTo(5));
        }
    }
}

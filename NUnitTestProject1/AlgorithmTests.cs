using System;
using System.Collections.Generic;
using System.Text;
using ContainerVervoer.Classes;
using ContainerVervoer.Enums;
using NUnit.Framework;

namespace ContainerTests
{
    class AlgorithmTests
    {
        private Algorithm algorithm;
        private Space spaceValuable;
        private Space spaceEmpty;
        private Space spaceCooled;
        private Space spaceCooledValuable;
        private Space spaceNormal;

        private Container containerValuable;
        private Container containerEmpty;
        private Container containerCooled;
        private Container containerCooledValuable;
        private Container containerNormal;

        [SetUp]
        public void Setup()
        {
            algorithm = new Algorithm(new Ship(5, 10));

            spaceValuable = new Space(Positon.Left, 1200);
            spaceEmpty = new Space(Positon.Middle,0);
            spaceCooled = new Space(Positon.Middle,0);
            spaceCooledValuable = new Space(Positon.Right,10000);
            spaceNormal = new Space(Positon.Right,1634);

            containerValuable = new Container(24000, ContainerType.Valuable);
            containerEmpty = null;
            containerCooled = new Container(22222, ContainerType.Cooled);
            containerCooledValuable = new Container(12400, ContainerType.CooledValuable);
            containerNormal = new Container(12121, ContainerType.Normal);

            spaceValuable.PlaceContainer(containerValuable);
            spaceCooled.PlaceContainer(containerCooled);
            spaceNormal.PlaceContainer(containerNormal);
            spaceCooledValuable.PlaceContainer(containerCooledValuable);
        }

        [Test]
        public void CheckBelowContainer_CooledContOnCooledSpace_returnTrue()
        {
            var result = algorithm.CheckBelowContainer(containerCooled,spaceCooled);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CheckBelowContainer_CoolValContOnValSpace_returnFalse()
        {
            var result = algorithm.CheckBelowContainer(containerCooledValuable, spaceValuable);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CheckBelowContainer_ValContOnCooledValSpace_False()
        {
            var result = algorithm.CheckBelowContainer(containerValuable, spaceCooledValuable);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CheckBelowContainer_NormalContOnValSpace_False()
        {
            var result = algorithm.CheckBelowContainer(containerNormal, spaceValuable);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CheckBelowContainer_NormalContOnEmptySpace_False()
        {
            var result = algorithm.CheckBelowContainer(containerNormal, spaceEmpty);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CheckBelowContainer_NormalContOnNormalSpace_True()
        {
            var result = algorithm.CheckBelowContainer(containerNormal,spaceNormal);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CheckBelowContainer_ValContOnCooledSpace_True()
        {
            var result = algorithm.CheckBelowContainer(containerValuable, spaceCooled);
            Assert.That(result, Is.EqualTo(true));

        }

        [Test]
        public void CheckIfContainerIsPlaceableBasedOnWeight_30000ContOn14000kgSpace_True()
        {
            var result = algorithm.CheckIfContainerIsPlaceableBasedOnWeight(new Container(30000,ContainerType.Normal), new Space(Positon.Middle,14000));
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CheckIfContainerIsPlaceableBasedOnWeight_30000ContOn130000kgSpace_False()  //TODO maybe increase readability?
        {
            Space space = new Space(Positon.Middle, 130000);
            Container cont = new Container(5000, ContainerType.Normal);
            space.PlaceContainer(cont);
            var result = algorithm.CheckIfContainerIsPlaceableBasedOnWeight(new Container(30000, ContainerType.Normal),space );
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CheckOtherContainersToSeeIfYouCanPlace_FirstEmptySecondVal_True()
        {
            var result = algorithm.CheckOtherContainersToSeeIfYouCanPlace(containerEmpty, containerValuable);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CheckOtherContainersToSeeIfYouCanPlace_FirstValSecondVal_False()
        {
            var result = algorithm.CheckOtherContainersToSeeIfYouCanPlace(containerValuable, containerValuable);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CheckOtherContainersToSeeIfYouCanPlace_FirstCooledValSecondNormal_False()
        {
            var result = algorithm.CheckOtherContainersToSeeIfYouCanPlace(containerCooledValuable, containerNormal);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CheckOtherContainersToSeeIfYouCanPlace_FirstValSecondCooledVal_False()
        {
            var result = algorithm.CheckOtherContainersToSeeIfYouCanPlace(containerCooledValuable, containerCooledValuable);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CheckOtherContainersToSeeIfYouCanPlace_FirstValSecondNormal_False()
        {
            var result = algorithm.CheckOtherContainersToSeeIfYouCanPlace(containerCooledValuable, containerNormal);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CheckOtherContainersToSeeIfYouCanPlace_FirstCooledValSecondEmpty_True()
        {
            var result = algorithm.CheckOtherContainersToSeeIfYouCanPlace(containerCooledValuable, containerEmpty);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CheckOtherContainersToSeeIfYouCanPlace()
        {
            var result = algorithm.CheckOtherContainersToSeeIfYouCanPlace(containerEmpty, containerValuable);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CheckContainerBelowIfPlaceable_SpaceValuable_False()
        {
            var result = algorithm.CheckContainerBelowIfPlaceable(spaceValuable);
            Assert.That(result, Is.EqualTo(false));
        }


        [Test]
        public void CheckContainerBelowIfPlaceable_SpaceCooled_True()
        {
            var result = algorithm.CheckContainerBelowIfPlaceable(spaceCooled);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CheckContainerBelowIfPlaceable_SpaceCooledValuable_False()
        {
            var result = algorithm.CheckContainerBelowIfPlaceable(spaceCooledValuable);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CheckContainerBelowIfPlaceable_SpaceNormal_True()
        {
            var result = algorithm.CheckContainerBelowIfPlaceable(spaceNormal);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CheckContainerBelowIfPlaceable_SpaceEmpty_False()
        {
            var result = algorithm.CheckContainerBelowIfPlaceable(spaceEmpty);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void GenerateRowNrEven_index0width20_Return10()
        {
            var result = algorithm.GenerateRowNr(0, 20);
            Assert.That(result, Is.EqualTo(10));
        }


        [Test]
        public void GenerateRowNrEven_index4width20_Return12()
        {
            var result = algorithm.GenerateRowNr(4, 20);
            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void GenerateRowNrOdd_index4width41_Return22()
        {
            var result = algorithm.GenerateRowNr(4, 41);
            Assert.That(result, Is.EqualTo(22));
        }

        [Test]
        public void GenerateRowNrOdd_index15width53_Return18()
        {
            var result = algorithm.GenerateRowNr(15, 53);
            Assert.That(result, Is.EqualTo(18));
        }

        [Test]
        public void IndexAlternatorOdd_index3width18_Return7()
        {
            var result = algorithm.GenerateRowNr(3, 18);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void IndexAlternatorEven_index6width9_Return7()
        {
            var result = algorithm.GenerateRowNr(6, 9);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void IndexAlternatorOdd_index10width11_Return10()
        {
            var result = algorithm.GenerateRowNr(10, 11);
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void IndexAlternatorOdd_index2width15_Return8()
        {
            var result = algorithm.GenerateRowNr(2, 15);
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void GenerateRowNrOdd_index0width53_Return26()
        {
            var result = algorithm.GenerateRowNr(0, 53);
            Assert.That(result, Is.EqualTo(26));
        }

        [Test]
        public void GenerateRowNrOdd_index1width53_Return25()
        {
            int result = algorithm.GenerateRowNr(1, 53);
            Assert.That(result, Is.EqualTo(25));
        }

        [Test]
        public void GenerateRowNrOdd_index2width53_Return27()
        {
            int result = algorithm.GenerateRowNr(2, 53);
            Assert.That(result, Is.EqualTo(27));
        }

        [Test]
        public void GenerateRowNrOdd_index01width0_Return5()
        {
            int result = algorithm.GenerateRowNr(0, 10);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void GenerateRowNrOdd_index11width12M_Return0()
        {
            int result = algorithm.GenerateRowNr(11, 12);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void ContainersByTypeAndSorted_AddRandomAndCooled_returnListOnlyValAndSorted()
        {
            var ship = new Ship(20,25);
            ContainerType containerTypeToSortFor = ContainerType.Valuable;

            ship.GenerateRandomContainers(400);
            ship.AddContainer(new Container(5000, containerTypeToSortFor));
            ship.AddContainer(new Container(5000, ContainerType.Cooled));

            var localAlgorithm = new Algorithm(ship);
            var containerList = localAlgorithm.GetContainersByTypeAndSorted(containerTypeToSortFor);
            int lastWeight = 0;
            var resultType = true;
            var resultSorted = true;

            foreach (var container in containerList)
            {
                if (container.Weight < lastWeight && resultSorted)
                {
                    lastWeight = container.Weight;
                    resultSorted = false;
                }
                if (container.Type != ContainerType.Valuable)
                {
                    resultType = false;
                }
                
            }
            Assert.Multiple(() =>
            {
                Assert.That(resultType,Is.EqualTo(true));
                Assert.That(resultSorted, Is.EqualTo(true));
            });
        }

        public void ContainersByTypeAndSorted_AddRandomAndValuable_returnListSortedByWeightAndNormal()
        {
            var ship = new Ship(20, 25);
            ContainerType containerTypeToSortFor = ContainerType.Normal;
            ship.GenerateRandomContainers(400);
            ship.AddContainer(new Container(5000, containerTypeToSortFor));
            ship.AddContainer(new Container(5000, ContainerType.Valuable));

            var localAlgorithm = new Algorithm(ship);
            var containerList = localAlgorithm.GetContainersByTypeAndSorted(containerTypeToSortFor);
            int lastWeight = 0;
            var resultType = true;
            var resultSorted = true;
            foreach (var container in containerList)
            {
                if (container.Weight < lastWeight && resultSorted)
                {
                    lastWeight = container.Weight;
                    resultSorted = false;
                }
                if (container.Type != containerTypeToSortFor)
                {
                    resultType = false;
                }

            }
            Assert.Multiple(() =>
            {
                Assert.That(resultType, Is.EqualTo(true));
                Assert.That(resultSorted, Is.EqualTo(true));
            });
        }
    }
}

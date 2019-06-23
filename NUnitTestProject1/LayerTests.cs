using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ContainerVervoer.Classes;
using ContainerVervoer.Enums;
using NUnit.Framework;

namespace ContainerTests
{
    class LayerTests
    {
        private int length = 2;
        private int width = 2;
        private Layer layerBottom ;
        private Layer layer1;
        private Layer layer2;

        private Container containerLayerBottom;
        private Container containerLayer1;
        private Container containerLayer2;
            
        [SetUp]
        public void Setup()
        {
            containerLayerBottom = new Container(5000, ContainerType.Normal);
            containerLayer1 = new Container(10000, ContainerType.Normal);
            containerLayer2 = new Container(20000, ContainerType.Valuable);

            layerBottom = new Layer(length, width);
            layerBottom = FillLayer(layerBottom, containerLayerBottom);
            layer1 = new Layer(length, width, layerBottom);
            layer1 = FillLayer(layer1, containerLayer1);
            layer2 = new Layer(length, width, layer1);
            layer2 = FillLayer(layer2, containerLayer2);
        }

        private Layer FillLayer(Layer result,Container container)
        {
            for (int column = 0; column < length; column++)
            {
                for (int row = 0; row < width; row++)
                {
                    result.LayerLayout[column][row].PlaceContainer(container);
                }
            }
            return result;
        }

        [Test]
        public void GetContainer_LayerBottomC1R1_ReturnContainerBottom()
        {
            var result = layerBottom.GetContainer(1, 1);
            Assert.That(result , Is.EqualTo(containerLayerBottom));
        }

        [Test]
        public void GetContainer_Layer1C0R1_ReturnContainer1()
        {
            var result = layer1.GetContainer(0, 1);
            Assert.That(result, Is.EqualTo(containerLayer1));
        }

        [Test]
        public void GetContainer_Layer1C2R0_ReturnContainer2()
        {
            var result = layer2.GetContainer(1, 0);
            Assert.That(result, Is.EqualTo(containerLayer2));
        }


        [Test]
        public void GetSpace_LayerBottomC1R1_ReturnReturnWeightSpace5000()
        {
            var space = layerBottom.GetSpace(1, 1);
            var result = space.WeightOnSpace;
            Assert.That(result, Is.EqualTo(5000));
        }

        [Test]
        public void GetSpace_Layer1C0R1_ReturnWeightOnSpace15000()
        {
            var space = layer1.GetSpace(0, 1);
            var result = space.WeightOnSpace;
            Assert.That(result, Is.EqualTo(15000));
        }

        [Test]
        public void GetSpace_Layer2C2R0_ReturnWeightOnSpace35000()
        {
            var space = layer2.GetSpace(1, 0);
            var result = space.WeightOnSpace;
            Assert.That(result, Is.EqualTo(35000));
        }

/*        [Test]
        public void GetSpace_Layer2C2R0_ReturnWeightOnSpace35000()
        {
            var space = layer2.GetSpace(1, 0);
            var result = space.WeightOnSpace;
            Assert.That(result, Is.EqualTo(35000));
        }*/
    }
}

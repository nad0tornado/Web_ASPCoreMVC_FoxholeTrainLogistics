using FoxholeItemAPI.Interfaces;
using FoxholeItemAPI.Models;
using FoxholeItemAPI.Utils;
using FoxholeTrainLogistics.Interfaces;
using FoxholeTrainLogistics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeTrainLogistics_Tests.Services.ContainerFactoryTests
{
    public class ContainerFactoryUnitTests
    {
        [Fact]
        public void CreatePackagedItemContainer()
        {
            var mockItem = new Item()
            {
                IconName = "Test"
            };

            var container = ContainerFactory.CreatePackagedItemContainer(mockItem);

            Assert.Equal("Test", container.Image);
            Assert.Equal(ShippingType.PackagedItem, container.Type);
            Assert.Equal("Packaged Item", container.DisplayName);
            Assert.Equal(1, container.Capacity);
            Assert.Single(container.Contents);
        }

        [Fact]
        public void CreatePackagedItemContainerWithNullItem()
        {
            Item? mockItem = null;
            Assert.Throws<NullReferenceException>(() =>
            {
                ContainerFactory.CreatePackagedItemContainer(mockItem);
            }
            );
        }

        [Fact]
        public void CreateNonImplementedContainer()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                ContainerFactory.CreateContainer(ShippingType.PackagedItem);
            });
        }

        [Fact]
        public void CreateContainerWhereItemsHaveDifferentTypes()
        {
            var badItems = new List<IItem>()
            {
                new Item() {ShippingType = ShippingType.ShippingContainer},
                new Item() {ShippingType = ShippingType.LiquidContainer}
            };

            Assert.Throws<ArgumentException>(() =>
            {
                ContainerFactory.CreateContainer(ShippingType.ShippingContainer, badItems);
            });
        }

        [Fact]
        public void GetMultiItemContainerTemplates()
        {
            var multiItemContainerTemplates = ContainerFactory.GetMultiItemContainerTemplates();
            
        }

        [Fact]
        public void ContainersToDictionaryByShippingType()
        {

        }
    }
}

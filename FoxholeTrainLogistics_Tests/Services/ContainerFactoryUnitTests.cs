using FoxholeItemAPI.Interfaces;
using FoxholeItemAPI.Models;
using FoxholeItemAPI.Utils;
using FoxholeTrainLogistics;
using FoxholeTrainLogistics.Interfaces;
using FoxholeTrainLogistics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeTrainLogistics_Tests.Services
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

        [Theory]
        [InlineData(ShippingType.ShippingContainer, "Shipping Container", "Shipping_Container.png", 60)]
        [InlineData(ShippingType.LiquidContainer, "Liquid Container", "Fuel_Container.png", 100)]
        [InlineData(ShippingType.ResourceContainer, "Resource Container", "Resource_Container.png", 5000)]
        [InlineData(ShippingType.Pallet, "Pallet", "Material_Pallet.png", 120)]
        [InlineData(ShippingType.Crate, "Crate", "Crate.png", 3)]
        public void CreateContainer(ShippingType shippingType, string displayName, string image, int capacity)
        {
            var container = ContainerFactory.CreateContainer(shippingType);
            Assert.Equal(shippingType, container.Type);
            Assert.Equal(displayName, container.DisplayName);
            Assert.Equal(image, container.Image);
            Assert.Equal(capacity, container.Capacity);
            Assert.Empty(container.Contents);
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
            var actualTemplateTypes = multiItemContainerTemplates.Select(t => t.Type);

            // .. any containers can be returned, but:

            // .. containers for these types MUST be returned at minimum
            var expectedTemplateTypes = new List<ShippingType>()
            {
                ShippingType.ShippingContainer,
                ShippingType.LiquidContainer,
                ShippingType.ResourceContainer,
                ShippingType.Pallet,
                ShippingType.Crate,
            };

            // .. containers for these types must NOT be returned
            var unexpectedTemplateTypes = new List<ShippingType>()
            {
                ShippingType.PackagedItem,
                ShippingType.CrateOrPackage
            };

            foreach (ShippingType unexpectedType in unexpectedTemplateTypes)
                Assert.DoesNotContain(unexpectedType, actualTemplateTypes);

            foreach (ShippingType expectedType in expectedTemplateTypes)
                Assert.Contains(expectedType, actualTemplateTypes);
        }

        [Fact]
        public void ContainersToDictionaryByShippingType()
        {
            var containerA = ContainerFactory.CreateContainer(ShippingType.ShippingContainer);
            var containerB = ContainerFactory.CreateContainer(ShippingType.LiquidContainer);
            var containers = new List<IContainer>() { containerA, containerB };

            var containersToDictionary = containers.ToDictionary();
            Assert.True(containersToDictionary.ContainsKey(ShippingType.ShippingContainer));
            Assert.True(containersToDictionary.ContainsKey(ShippingType.LiquidContainer));

            var shippingContainer = containersToDictionary[ShippingType.ShippingContainer];
            var liquidContainer = containersToDictionary[ShippingType.LiquidContainer];
            
            Assert.Equal(containerA, shippingContainer);
            Assert.Equal(containerB, liquidContainer);
        }

        [Fact]
        public void ContainerTemplatesConvertibleToDictionary()
        {
            var containerTemplates = ContainerFactory.GetMultiItemContainerTemplates();
            var containerTemplatesJson = containerTemplates.ToJson();

            var containerTemplatesDictionary = containerTemplates.ToDictionary();
            var containerTemplatesDictionaryJson = containerTemplatesDictionary.ToJson();

            Assert.Equal(containerTemplatesJson, containerTemplatesDictionaryJson);

            foreach (IContainer template in containerTemplates)
                Assert.True(containerTemplatesDictionary.ContainsValue(template));
        }
    }
}

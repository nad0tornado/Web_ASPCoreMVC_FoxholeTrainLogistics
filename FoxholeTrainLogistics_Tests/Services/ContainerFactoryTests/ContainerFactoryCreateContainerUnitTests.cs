using FoxholeItemAPI.Utils;
using FoxholeTrainLogistics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeTrainLogistics_Tests.Services.ContainerFactoryTests
{
    public class ContainerFactoryCreateContainerUnitTests
    {
        [Fact]
        public void CreateShippingContainer()
        {
            var shippingContainer = ContainerFactory.CreateContainer(ShippingType.ShippingContainer);
            Assert.Equal(ShippingType.ShippingContainer, shippingContainer.Type);
            Assert.Equal("Shipping Container", shippingContainer.DisplayName);
            Assert.Equal("Shipping_Container.png", shippingContainer.Image);
            Assert.Equal(60, shippingContainer.Capacity);
            Assert.Empty(shippingContainer.Contents);
        }

        [Fact]
        public void CreateLiquidContainer()
        {
            var liquidContainer = ContainerFactory.CreateContainer(ShippingType.LiquidContainer);
            Assert.Equal(ShippingType.LiquidContainer, liquidContainer.Type);
            Assert.Equal("Liquid Container", liquidContainer.DisplayName);
            Assert.Equal("Fuel_Container.png", liquidContainer.Image);
            Assert.Equal(100, liquidContainer.Capacity);
            Assert.Empty(liquidContainer.Contents);
        }

        [Fact]
        public void CreateResourceContainer()
        {
            var resourceContainer = ContainerFactory.CreateContainer(ShippingType.ResourceContainer);
            Assert.Equal(ShippingType.ResourceContainer, resourceContainer.Type);
            Assert.Equal("Resource Container", resourceContainer.DisplayName);
            Assert.Equal("Resource_Container.png", resourceContainer.Image);
            Assert.Equal(5000, resourceContainer.Capacity);
            Assert.Empty(resourceContainer.Contents);
        }

        [Fact]
        public void CreatePallet()
        {
            var pallet = ContainerFactory.CreateContainer(ShippingType.Pallet);
            Assert.Equal(ShippingType.Pallet, pallet.Type);
            Assert.Equal("Pallet", pallet.DisplayName);
            Assert.Equal("Material_Pallet.png", pallet.Image);
            Assert.Equal(120, pallet.Capacity);
            Assert.Empty(pallet.Contents);
        }

        [Fact]
        public void CreateCrate()
        {
            var crate = ContainerFactory.CreateContainer(ShippingType.Crate);
            Assert.Equal(ShippingType.Crate, crate.Type);
            Assert.Equal("Crate", crate.DisplayName);
            Assert.Equal("Crate.png", crate.Image);
            Assert.Equal(3, crate.Capacity);
            Assert.Empty(crate.Contents);
        }
    }
}

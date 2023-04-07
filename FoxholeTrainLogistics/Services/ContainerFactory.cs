using FoxholeItemAPI.Interfaces;
using FoxholeItemAPI.Utils;
using FoxholeTrainLogistics.Interfaces;
using FoxholeTrainLogistics.Interfaces.Trains;
using System.Text.Json;
using static FoxholeTrainLogistics.Services.TrainCarFactory;

namespace FoxholeTrainLogistics.Services
{
    public static class ContainerFactory
    {
        private struct Container : IContainer
        {
            public ShippingType Type { get; private set; }

            public string Image { get; private set; }

            public List<IItem> Contents { get; private set; }

            public Container(ShippingType type, string image, List<IItem>? contents = null)
            {
                Type = type;
                Image = image;
                Contents = contents ?? new();
            }
        }

        public static IContainer CreateContainer(ShippingType type)
            => type switch
            {
                ShippingType.ShippingContainer => new Container(type, "Shipping_Container.png"),
                ShippingType.LiquidContainer => new Container(type, "Fuel_Container.png"),
                ShippingType.ResourceContainer => new Container(type, "Resource_Container.png"),
                ShippingType.Pallet => new Container(type, "Material_Pallet.png"),
                ShippingType.Crate => new Container(type, "Crate.png"),
                ShippingType.None => new Container(type, ""),
                _ => throw new NotImplementedException()
            };
    }
}

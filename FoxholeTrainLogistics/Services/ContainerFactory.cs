using FoxholeItemAPI.Interfaces;
using FoxholeItemAPI.Models;
using FoxholeItemAPI.Utils;
using FoxholeTrainLogistics.Interfaces;
using System.Text.Json;
using static FoxholeTrainLogistics.Services.TrainCarFactory;

namespace FoxholeTrainLogistics.Services
{
    public static class ContainerFactory
    {
        private struct Container : IContainer
        {
            public ShippingType Type { get; private set; }
            
            public string DisplayName { get; }

            public string Image { get; private set; }

            public int Capacity { get; private set; }
            public List<IItem> Contents { get; private set; }

            public Container(ShippingType type, string image, List<IItem>? contents = null)
            {
                Type = type;
                DisplayName = Type.GetDisplayName();
                Image = image;
                Capacity = type.ToCapacity();
                Contents = contents ?? new();
            }
        }

        public static IContainer CreatePackagedItemContainer(IItem item)
        {
            if (item == null)
                throw new NullReferenceException("item cannot be null");

            return new Container(ShippingType.PackagedItem, item.IconName, new List<IItem>() { item });
        }

        private static IContainer createContainer(ShippingType containerType, string imageName, List<IItem>? contents = null)
        {
            if(contents == null)
                contents = new List<IItem>();
            else if (contents.Any(c => c.ShippingType != containerType))
                throw new ArgumentException("All container contents MUST have the same shipping type");

            return new Container(containerType, imageName, contents);
        }

        public static IContainer CreateContainer(ShippingType type, List<IItem>? contents = null)
            => type switch
            {
                ShippingType.ShippingContainer => createContainer(type, "Shipping_Container.png",contents),
                ShippingType.LiquidContainer => createContainer(type, "Fuel_Container.png", contents),
                ShippingType.ResourceContainer => createContainer(type, "Resource_Container.png", contents),
                ShippingType.Pallet => createContainer(type, "Material_Pallet.png", contents),
                ShippingType.Crate => createContainer(type, "Crate.png", contents),
                _ => throw new NotImplementedException()
            };

        public static List<IContainer> GetMultiItemContainerTemplates()
        {
            var nonMultiItemContainers = new[] { ShippingType.PackagedItem, ShippingType.CrateOrPackage };
            var containerTypes = Utils.GetEnumTypes<ShippingType>();
            var multiItemContainerTypes = containerTypes.Where(t => !nonMultiItemContainers.Contains(t));
            return multiItemContainerTypes.Select(t => CreateContainer(t)).ToList();
        }

        public static Dictionary<ShippingType, IContainer> ToDictionary(this IEnumerable<IContainer> containers)
            => containers.ToDictionary(c => c.Type, c => c);
    }
}

using FoxholeItemAPI.Interfaces;
using FoxholeItemAPI.Utils;

namespace FoxholeTrainLogistics.Interfaces
{
    public interface IContainer
    {
        public ShippingType Type { get; }

        public int Capacity { get; }

        public string Image { get; }

        public List<IItem> Contents { get; }
    }
}

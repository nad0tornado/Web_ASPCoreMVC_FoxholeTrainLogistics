using FoxholeItemAPI.Interfaces;
using FoxholeItemAPI.Utils;
using static FoxholeTrainLogistics.Services.TrainCarFactory;

namespace FoxholeTrainLogistics.Interfaces.Trains
{
    public interface IContainer
    {
        public ShippingType Type { get; }

        public string Image { get; }

        public List<IItem> Contents { get; }
    }
}

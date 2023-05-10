using FoxholeItemAPI.Utils;
using FoxholeTrainLogistics;
using FoxholeTrainLogistics.Interfaces;

namespace FoxholeTrainLogistics_Tests
{
    public class TrainUtilsUnitTests
    {
        [Theory]
        [InlineData(ShippingType.Crate,"Crate")]
        [InlineData(ShippingType.ResourceContainer,"Resource Container")]
        public void GetContainerDisplayName(ShippingType containerType, string expectedDisplayName)
        {
            var displayName = containerType.GetDisplayName();
            Assert.Equal(expectedDisplayName, displayName);
        }

        [Theory]
        [InlineData(TrainCarType.EngineCar, "Engine")]
        [InlineData(TrainCarType.CabooseCar, "Caboose")]
        [InlineData(TrainCarType.FlatbedCar, "Flatbed Car")]
        public void GetTrainCarDisplayName(TrainCarType trainCarType, string expectedDisplayName)
        {
            var displayName = trainCarType.GetDisplayName();
            Assert.Equal(expectedDisplayName, displayName);
        }

        [Theory]
        [InlineData(TrainStatus.Parked,"Parked")]
        [InlineData(TrainStatus.InTransit,"In Transit")]
        public void GetTrainStatusDisplayName(TrainStatus trainStatus, string expectedDisplayName)
        {
            var displayName = trainStatus.GetDisplayName();
            Assert.Equal(expectedDisplayName, displayName);
        }
    }
}
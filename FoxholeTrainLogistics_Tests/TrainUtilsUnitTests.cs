using FoxholeItemAPI.Utils;
using FoxholeTrainLogistics;

namespace FoxholeTrainLogistics_Tests
{
    public class TrainUtilsUnitTests
    {
        [Theory]
        [InlineData(ShippingType.Crate,"Crate")]
        [InlineData(ShippingType.ResourceContainer,"Resource Container")]
        public void GetContainerDisplayNameUnitTest(ShippingType containerType, string expectedDisplayName)
        {
            var displayName = containerType.GetDisplayName();
            Assert.Equal(expectedDisplayName, displayName);
        }

        [Theory]
        [InlineData(TrainCarType.EngineCar, "Engine")]
        [InlineData(TrainCarType.CabooseCar, "Caboose")]
        [InlineData(TrainCarType.FlatbedCar, "Flatbed Car")]
        public void GetTrainCarDisplayNameUnitTest(TrainCarType trainCarType, string expectedDisplayName)
        {
            var displayName = trainCarType.GetDisplayName();
            Assert.Equal(expectedDisplayName, displayName);
        }
    }
}
using FoxholeItemAPI.Utils;
using FoxholeTrainLogistics;
using FoxholeTrainLogistics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeTrainLogistics_Tests.Services
{
    public class TrainCarFactoryUnitTests
    {
        [Theory]
        [InlineData(TrainCarType.EngineCar,"engineCarBlack_side.png","Engine",2)]
        [InlineData(TrainCarType.CoalCar, "coalCarBlack_side.png","Coal Car", 0)]
        [InlineData(TrainCarType.InfantryCar, "infantryCarBlack_side.png","Infantry Car", 6)]
        [InlineData(TrainCarType.FlatbedCar, "flatbedCarBlack_side.png","Flatbed Car", 0)]
        [InlineData(TrainCarType.CabooseCar, "cabooseCarBlack_side.png","Caboose", 6)]
        public void CreateTrainCar(TrainCarType trainCarType, string expectedImageName, string expectedDisplayName, int expectedCrewCapacity)
        {
            var trainCar = TrainCarFactory.CreateTrainCar(trainCarType);
            Assert.Equal(trainCarType, trainCar.Type);
            Assert.Equal(expectedImageName, trainCar.Image);
            Assert.Equal(expectedDisplayName, trainCar.DisplayName);
            Assert.Equal(expectedCrewCapacity, trainCar.Crew);
        }

        [Fact]
        public void CreateNonImplementedTrainCar()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                TrainCarFactory.CreateTrainCar(TrainCarType.Unknown);
            });
        }

        [Fact]
        public void GetTrainCarTemplates()
        {
            var trainCarTemplates = TrainCarFactory.GetTrainCarTemplates();
            var actualTemplateTypes = trainCarTemplates.Select(t => t.Type);

            // .. any containers can be returned, but:

            // .. train cars for these types MUST be returned at minimum
            var expectedTemplateTypes = new List<TrainCarType>()
            {
                TrainCarType.EngineCar,
                TrainCarType.CoalCar,
                TrainCarType.InfantryCar,
                TrainCarType.FlatbedCar,
                TrainCarType.CabooseCar,
            };

            // .. train cars for these types must NOT be returned
            var unexpectedTemplateTypes = new List<TrainCarType>()
            {
                TrainCarType.Unknown
            };

            foreach (TrainCarType unexpectedType in unexpectedTemplateTypes)
                Assert.DoesNotContain(unexpectedType, actualTemplateTypes);

            foreach (TrainCarType expectedType in expectedTemplateTypes)
                Assert.Contains(expectedType, actualTemplateTypes);
        }

        [Fact]
        public void TrainCarTemplates()
        {
            /* var containerTemplates = ContainerFactory.GetMultiItemContainerTemplates();

            var containerTemplatesDictionary = containerTemplates.ToDictionary();

            foreach (IContainer template in containerTemplates)
                Assert.True(containerTemplatesDictionary.ContainsValue(template));*/
        }

    }
}

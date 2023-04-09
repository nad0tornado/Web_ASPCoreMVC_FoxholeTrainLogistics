﻿using FoxholeItemAPI.Interfaces;
using FoxholeItemAPI.Utils;
using FoxholeTrainLogistics.Interfaces;
using FoxholeTrainLogistics.Interfaces.Trains;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FoxholeTrainLogistics
{
    public enum TrainCarType { EngineCar, CoalCar, FlatbedCar, InfantryCar, CabooseCar }
}
namespace FoxholeTrainLogistics.Services
{
    public static class TrainCarFactory
    {
        private class TrainCar : ITrainCar
        {
            public TrainCarType Type { get; }

            public string Image { get; }

            public int Crew { get; }

            public TrainCar(TrainCarType type, string image, int crew = 0)
            {
                Type = type;
                Image = image;
                Crew = crew;
            }

            public override string ToString()
            {
                var options = new JsonSerializerOptions
                {
                    Converters =
                {
                    new JsonStringEnumConverter()
                }
                };

                return JsonSerializer.Serialize(this, options);
            }
        }

        private class FlatbedCar : TrainCar, IFlatbedCar
        {
            public IContainer? Container { get; private set; }

            public FlatbedCar(IContainer? container = null) : base(TrainCarType.FlatbedCar, "flatbedCarBlack_side.png")
            {
                Container = container;
            }

            public void AddContainer(ShippingType shippingType, List<IItem>? contents = null)
            {
                Container = ContainerFactory.CreateContainer(shippingType, contents);
            }

            public override string ToString()
            {
                var options = new JsonSerializerOptions
                {
                    Converters =
                {
                    new JsonStringEnumConverter()
                }
                };

                return JsonSerializer.Serialize(this, options);
            }
        }


        public static ITrainCar CreateTrainCar(TrainCarType type)
            => type switch
            {
                TrainCarType.EngineCar => new TrainCar(type, "engineCarBlack_side.png", 2),
                TrainCarType.CoalCar => new TrainCar(type, "coalCarBlack_side.png"),
                TrainCarType.InfantryCar => new TrainCar(type, "infantryCarBlack_side.png", 6),
                TrainCarType.FlatbedCar => new FlatbedCar(),
                TrainCarType.CabooseCar => new TrainCar(type, "cabooseCarBlack_side.png", 6),
                _ => throw new NotImplementedException()
            };

        public static IFlatbedCar CreateFlatbedCar(ShippingType containerType)
            => new FlatbedCar(ContainerFactory.CreateContainer(containerType));

        public static List<ITrainCar> GetAllTypes()
            => Enum.GetValues(typeof(TrainCarType)).Cast<TrainCarType>().Select(t => CreateTrainCar(t)).ToList();
    }
}

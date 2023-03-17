using FoxholeTrainLogistics.Interfaces;
using Newtonsoft.Json;

namespace FoxholeTrainLogistics.Services
{
    public static class TrainCarFactory
    {

        private struct TrainCar : ITrainCar
        {
            public string Type { get; }
            public string Image { get; }
            public int Crew { get; }

            public TrainCar(TrainCarType type, string image, int crew = 0)
            {
                Type = type.ToString();
                Image = image;
                Crew = crew;
            }

            public override string ToString()
                => JsonConvert.SerializeObject(this);
        }

        public static ITrainCar CreateTrainCar(TrainCarType type)
            => type switch
            {
                TrainCarType.EngineCar => new TrainCar(type, "engineCarBlack_side.png", 2),
                TrainCarType.CoalCar => new TrainCar(type, "coalCarBlack_side.png"),
                TrainCarType.InfantryCar => new TrainCar(type, "infantryCarBlack_side.png", 6),
                TrainCarType.FlatbedCar => new TrainCar(type, "flatbedCarBlack_side.png"),
                TrainCarType.CabooseCar => new TrainCar(type, "cabooseCarBlack_side.png", 6),
                _ => throw new NotImplementedException()
            };

        public static List<ITrainCar> GetAllTrainCarTypes()
            => Enum.GetValues(typeof(TrainCarType)).Cast<TrainCarType>().Select(t => CreateTrainCar(t)).ToList();
    }
}

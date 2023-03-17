using static FoxholeTrainLogistics.Services.TrainCarFactory;

namespace FoxholeTrainLogistics.Interfaces
{
    public enum TrainCarType { EngineCar, CoalCar, FlatbedCar, InfantryCar, CabooseCar }
    public interface ITrainCar
    {
        public string Type { get; }
        public string Image { get; }
        public int Crew { get; }

        public string ToString();
    }
}

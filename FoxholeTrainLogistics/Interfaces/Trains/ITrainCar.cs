using FoxholeTrainLogistics.Interfaces.Trains;

namespace FoxholeTrainLogistics.Interfaces
{
    public interface ITrainCar
    {
        public TrainCarType Type { get; }

        public string Image { get; }

        public int Crew { get; }

        public string ToString();
    }
}

namespace FoxholeTrainLogistics.Interfaces.Trains
{
    public interface IFlatbedCar : ITrainCar
    {
        public IContainer? Container { get; }
    }
}

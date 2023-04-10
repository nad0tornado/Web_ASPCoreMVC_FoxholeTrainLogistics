namespace FoxholeTrainLogistics.Interfaces
{
    public interface IFlatbedCar : ITrainCar
    {
        public IContainer? Container { get; }
    }
}

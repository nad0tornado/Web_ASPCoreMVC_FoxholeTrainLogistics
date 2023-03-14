namespace FoxholeTrainLogistics.Trains
{
    public enum TrainStatus { Parked, InTransit, Stopped }
    public enum TrainCar { Engine, CoalCar, FlatbedCar, InfantryCar, Caboose }

    public interface ITrain
    {
        public Guid TrainId { get; set; }
        public TrainStatus Status { get; set; }
        public List<TrainCar> Cars { get; set; }
    }
}

using FoxholeTrainLogistics.Interfaces;
using FoxholeTrainLogistics.Models;

namespace FoxholeTrainLogistics.Trains
{
    public enum TrainStatus { Parked, InTransit, Stopped }

    public interface ITrain
    {
        public Guid TrainId { get; set; }
        public TrainStatus Status { get; set; }
        public List<ITrainCar> Cars { get; set; }
    }
}

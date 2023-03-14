using FoxholeTrainLogistics.Trains;

namespace FoxholeTrainLogistics.Models
{
    public class Train : ITrain
    {
        public Guid TrainId { get; set; }
        public TrainStatus Status { get; set; }
        public int NumberOfCars { get; set; }
    }
}

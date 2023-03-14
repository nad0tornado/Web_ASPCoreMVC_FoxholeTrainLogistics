using FoxholeTrainLogistics.Trains;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoxholeTrainLogistics.Models
{
    public class Train : ITrain
    {
        public Guid TrainId { get; set; }
        public TrainStatus Status { get; set; }

        [NotMapped] // .. TODO: this should probably be a many-to-many relationship between other "Cars" in the database
        public List<TrainCar> Cars { get; set; } = new List<TrainCar>();
    }
}

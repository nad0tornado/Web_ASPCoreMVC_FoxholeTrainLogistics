using FoxholeTrainLogistics.Trains;

namespace FoxholeTrainLogistics.Models
{
    public static class Extensions
    {
        public static string Image(this TrainCar car) =>
            car switch
            {
                TrainCar.Engine => "trainBlack_side.png",
                TrainCar.CoalCar => "coalCarBlack_side.png",
                TrainCar.InfantryCar => "infantryCarBlack_side.png",
                TrainCar.FlatbedCar => "flatbedCarBlack_side.png",
                TrainCar.Caboose => "cabooseCarBlack_side.png",
                _ => throw new NotImplementedException("No image found for TrainCar \"" + car + "\"")
            };
    }
    public class TrainViewModel
    {
        public ITrain Train;
        public string StatusDisplayName => GetStatusDisplayName();
        public int NumberOfCars => Train.Cars.Count;
        public bool Interactable = false;

        public TrainViewModel(ITrain _train, bool interactable = false)
        {
            Train = _train;
            Interactable = interactable;
        }

        private string GetStatusDisplayName()
        {
            if (Train.Status == TrainStatus.InTransit)
                return "In Transit";
            else
                return Train.Status.ToString();
        }
    }
}

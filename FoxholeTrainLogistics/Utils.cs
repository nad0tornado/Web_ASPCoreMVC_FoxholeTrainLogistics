namespace FoxholeTrainLogistics
{
    public static class Utils
    {
        public static string DisplayName(this TrainCarType type) =>
            type switch
            {
                TrainCarType.EngineCar => "Engine",
                TrainCarType.CoalCar => "Coal Car",
                TrainCarType.InfantryCar => "Infantry Car",
                TrainCarType.FlatbedCar => "Flatbed Car",
                TrainCarType.CabooseCar => "Caboose",
                _ => throw new NotImplementedException()
            };
    }
}

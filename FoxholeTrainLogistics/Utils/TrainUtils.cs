using FoxholeItemAPI.Utils;
using Microsoft.VisualBasic;
using System.ComponentModel;

namespace FoxholeTrainLogistics
{
    public static class TrainUtils
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

        public static int ToCapacity(this ShippingType shippingType) =>
        shippingType switch
        {
                ShippingType.ShippingContainer => 60,
                ShippingType.LiquidContainer => 100,
                ShippingType.ResourceContainer => 5000,
                ShippingType.Pallet => 120,
                ShippingType.Crate => 3,
                ShippingType.PackagedItem => 1,
                _ => throw new NotImplementedException()
            };
    }
}

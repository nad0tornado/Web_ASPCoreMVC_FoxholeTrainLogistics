using FoxholeItemAPI.Utils;
using FoxholeTrainLogistics.Interfaces;
using System.Text.RegularExpressions;

namespace FoxholeTrainLogistics
{
    public static class TrainUtils
    {
        public static string GetDisplayName(this Enum _type) {
            var typeString = _type.ToString();

            return typeString switch {
                "EngineCar" => "Engine",
                "CabooseCar" => "Caboose",
                _=> string.Join(" ",Regex.Split(typeString,@"(?<!^)(?=[A-Z])"))
            };
        }

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

        public static string ToAlert(this TrainStatus status) =>
            status switch
            {
                TrainStatus.Parked => "alert-info",
                TrainStatus.InTransit => "alert-success",
                TrainStatus.Stopped => "alert-danger",
                _ => throw new NotImplementedException()
            };

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeItemAPI.Utils
{
    internal static class Utils
    {
        public static Category ToCategory(this string? value) =>
            value switch
            {
                "small_arms" => Category.SmallArms,
                "heavy_arms" => Category.HeavyArms,
                "heavy_ammunition" => Category.HeavyAmmunition,
                "utilities" => Category.Utilities,
                "supplies" => Category.Supplies,
                "medical" => Category.Medical,
                "uniforms" => Category.Uniforms,
                "vehicles" => Category.Vehicles,
                "shipables" => Category.Shippables,
                _ => Category.Unknown
            };

        public static ShippingType ToShippingType(this Category value) =>
            value switch
            {
                Category.SmallArms => ShippingType.ShippingContainer,
                Category.HeavyArms => ShippingType.ShippingContainer,
                Category.HeavyAmmunition => ShippingType.Pallet,
                Category.Utilities => ShippingType.ShippingContainer,
                Category.Supplies => ShippingType.ShippingContainer,
                Category.Medical => ShippingType.ShippingContainer,
                Category.Uniforms => ShippingType.ShippingContainer,
                Category.Vehicles => ShippingType.CrateOrPackage,
                Category.Shippables => ShippingType.CrateOrPackage,
                _ => ShippingType.Unknown
            };
    }
}

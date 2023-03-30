using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeItemAPI
{
    internal static class CategoryUtils
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
    }
}

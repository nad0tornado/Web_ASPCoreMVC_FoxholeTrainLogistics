using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeItemAPI.Utils
{
    public enum Category
    {
        SmallArms, HeavyArms, HeavyAmmunition, Utilities, Supplies, Medical, Uniforms, Vehicles, Shippables, Unknown
    };

    public enum Faction { Warden, Colonial, Neutral }

    public enum ShippingType { ShippingContainer, Pallet, CrateOrPackage, Unknown };
}

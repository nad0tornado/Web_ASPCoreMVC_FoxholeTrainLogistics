using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeItemAPI
{
    public enum Category
    {
        Ammunition, Base_Upgrade, Building, Event, Facility, Map, Medical, Research, Resource, Shippable,
        Supplie, Tool, UI, Uniform, Vehicle, Weapon, None 
    };

    public enum ShippingType { ShippingContainer, Pallet, CrateOrPackage};
}

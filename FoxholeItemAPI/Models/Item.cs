using FoxholeItemAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeItemAPI.Models
{
    internal class Item : IItem
    {
        public string Icon { get; private set; }

        public string DisplayName { get; private set; }

        public Category Category { get; private set; }

        public ShippingType ShippingType { get; private set; }
    }
}

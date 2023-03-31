using FoxholeItemAPI.Interfaces;
using FoxholeItemAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeItemAPI.Models
{
    internal class Item : IItem
    {
        public string IconName { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;

        public Category Category { get; set; }

        public ShippingType ShippingType { get; set; }
    }
}

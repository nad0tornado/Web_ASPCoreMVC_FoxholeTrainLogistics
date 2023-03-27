using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeItemAPI
{
    namespace Interfaces
    {
        internal interface IItem
        {
            public string Icon { get; }
            public string DisplayName { get; }
            public Category Category { get; }
            public ShippingType ShippingType { get; }
        }
    }
}

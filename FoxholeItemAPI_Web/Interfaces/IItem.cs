using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxholeItemAPI.Utils;

namespace FoxholeItemAPI
{
    namespace Interfaces
    {
        public interface IItem
        {
            public string IconName { get; }

            public string DisplayName { get; }

            public Category Category { get; }

            public ShippingType ShippingType { get; }
        }
    }
}

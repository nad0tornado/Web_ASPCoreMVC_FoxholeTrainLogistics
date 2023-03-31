using FoxholeItemAPI.Interfaces;
using FoxholeItemAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeItemAPI.Services
{
    internal class FoxholeItemAPIService : IFoxholeItemAPIService
    {
        public static List<IItem> GetItems()
        {
            return new();
        }

        public static List<IItem> GetItemsInCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}

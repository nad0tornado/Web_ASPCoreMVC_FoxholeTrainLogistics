using FoxholeItemAPI.Interfaces;
using FoxholeItemAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeItemAPI.Services
{
    internal class FoxholeItemAPIService<Repository> : IFoxholeItemAPIService where Repository : IFoxholeItemAPIRepository
    {
        private FoxholeItemAPIService() { }
        public static List<IItem> GetItems()
        {
            throw new NotImplementedException();
        }

        public static List<IItem> GetItemsInCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}

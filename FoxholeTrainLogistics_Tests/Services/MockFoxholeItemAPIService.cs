using FoxholeItemAPI.Interfaces;
using FoxholeItemAPI.Models;
using FoxholeItemAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeTrainLogistics_Tests.Services
{
    internal class MockFoxholeItemAPIService : IFoxholeItemAPIService<Item>
    {
        public Task<List<Item>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetItemsInCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}

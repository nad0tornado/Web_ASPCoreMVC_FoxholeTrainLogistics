using FoxholeItemAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using FoxholeItemAPI;
using FoxholeItemAPI.Repositories;
using FoxholeItemAPI.Models;

namespace FoxholeItemAPI_Tests.Repositories
{
    internal class MockFoxholeItemAPIRepository : AbstractFoxholeItemAPIRepository, IFoxholeItemAPIRepository
    {
        private List<FoxholeItemAPIItem> data = new();

        public MockFoxholeItemAPIRepository() { _LoadData(); }

        protected override void _LoadData()
        {
            using(var file = File.OpenRead("./foxholeSample.json"))
            {
                data = JsonSerializer.Deserialize<List<FoxholeItemAPIItem>>(file) ?? new();
            }
        }
        public List<IItem> GetItems()
        {
            throw new NotImplementedException();
        }

        public List<IItem> GetItemsInCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}

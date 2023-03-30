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

namespace FoxholeItemAPI_Tests.Repositories
{
    internal class MockFoxholeItemAPIRepository : AbstractFoxholeItemAPIRepository, IFoxholeItemAPIRepository
    {
        private string data = string.Empty;
        protected override void _LoadData()
        {

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

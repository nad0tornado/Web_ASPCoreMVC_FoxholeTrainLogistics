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
        private readonly List<Item> _items = new();

        public void AddMockItem(Item item)
        {
            _items.Add(item);
        }

        public Task<IEnumerable<Item>> GetItems()
        {
            return Task.Run<IEnumerable<Item>>(() => _items);
        }

        public Task<IEnumerable<Item>> GetItemsInCategory(Category category)
        {
            return Task.Run(() => _items.Where(item => item.Category == category));
        }
    }
}

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
using System.Text.RegularExpressions;
using System.ComponentModel;
using FoxholeItemAPI.Converters;

namespace FoxholeItemAPI_Tests.Repositories
{
    internal class MockFoxholeItemAPIRepository : AbstractFoxholeItemAPIRepository, IFoxholeItemAPIRepository
    {
        private List<IItem> items = new();

        public MockFoxholeItemAPIRepository() { 
            _LoadData(); 
        }

        protected override void _LoadData()
        {
            if (!File.Exists("./foxholeSample.json"))
                return;

            using (var file = File.OpenRead("./foxholeSample.json"))
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new ItemConverter());
                items = (JsonSerializer.Deserialize<List<Item>>(file, options) ?? new()).ToList<IItem>();
            }
        }

        public List<IItem> GetItems() => items;

        public List<IItem> GetItemsInCategory(Category category) 
            => items.Where(i => i.Category == category).ToList();
    }
}

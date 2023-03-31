﻿using FoxholeItemAPI.Interfaces;
using System.Text.Json;
using FoxholeItemAPI;
using FoxholeItemAPI.Repositories;
using FoxholeItemAPI.Models;
using FoxholeItemAPI.Converters;

namespace FoxholeItemAPI.Repositories
{
    internal class FoxholeItemAPIRepository : AbstractFoxholeItemAPIRepository, IFoxholeItemAPIRepository
    {
        private List<IItem> items = new();

        public FoxholeItemAPIRepository()
        {
            _LoadData();
        }

        protected override void _LoadData()
        {
            if (!File.Exists("./foxhole.json"))
                return;

            using (var file = File.OpenRead("./foxhole.json"))
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

using FoxholeItemAPI.Interfaces;
using FoxholeItemAPI.Models;
using FoxholeItemAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text.Json;

namespace FoxholeTrainLogistics_Tests.Services
{
    internal class FoxholeItemAPIService<Item> : IFoxholeItemAPIService<Item> where Item : IItem
    {
        public async Task<List<Item>> GetItems()
        {
            var httpClient = new HttpClient();
            var foxholeApiItemsResponse = await httpClient.GetAsync("https://localhost:7118/api/items");
            foxholeApiItemsResponse.EnsureSuccessStatusCode();
            var foxholeApiItemsJson = await foxholeApiItemsResponse.Content.ReadAsStringAsync();
            foxholeApiItemsJson = Regex.Replace(foxholeApiItemsJson, @"\b\w", m => m.Value.ToUpper());

            var foxholeApiItems = JsonSerializer.Deserialize<List<Item>>(foxholeApiItemsJson) ?? new();

            return foxholeApiItems;
        }
        public async Task<List<Item>> GetItemsInCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}

using FoxholeItemAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FoxholeItemAPI.Repositories
{
    internal class FoxholeItemAPIRepository : IFoxholeItemAPIRepository
    {
        public object? LoadData()
        {
            using (var fileStream = File.OpenRead("./foxhole.json"))
            {
                var result = JsonSerializer.DeserializeAsync<Dictionary<string, string>[]>(fileStream).Result;
                return result ?? Array.Empty<Dictionary<string,string>>();
            }
        }
    }
}

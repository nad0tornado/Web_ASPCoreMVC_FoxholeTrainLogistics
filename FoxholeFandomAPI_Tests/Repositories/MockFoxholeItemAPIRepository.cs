using FoxholeItemAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace FoxholeItemAPI_Tests.Repositories
{
    internal class MockFoxholeItemAPIRepository : IFoxholeItemAPIRepository
    {
        public object? LoadData()
        {
            using (var fileStream = File.OpenRead("./sampleFoxholeAPI.json"))
            {
                return JsonSerializer.DeserializeAsync<object>(fileStream).Result;
            }
        }
    }
}

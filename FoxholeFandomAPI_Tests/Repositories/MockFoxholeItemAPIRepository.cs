using FoxholeItemAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeItemAPI_Tests.Repositories
{
    internal class MockFoxholeItemAPIRepository : IFoxholeItemAPIRepository
    {
        public string LoadData()
        {
            throw new NotImplementedException();
        }
    }
}

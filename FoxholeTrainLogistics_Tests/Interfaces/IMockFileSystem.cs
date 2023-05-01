using FoxholeTrainLogistics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeTrainLogistics_Tests.Interfaces
{
    public interface IMockFileSystem : IFileSystem, IDisposable
    {
        public void CreateMockFile(string path);
    }
}

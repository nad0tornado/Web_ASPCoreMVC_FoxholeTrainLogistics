using FoxholeTrainLogistics_Tests.Interfaces;

namespace FoxholeTrainLogistics_Tests.Services
{
    internal class MockFileSystem : IMockFileSystem
    {
        private List<string> _files = new();
        private List<string> _directories = new();

        public MockFileSystem(List<string>? files = null, List<string>? directories = null)
        {
            _files = files ?? new();
            _directories = directories ?? new();
        }

        public void CreateMockFile(string path)
        {
            if(!_files.Contains(path))
                _files.Add(path);
        }

        public void CreateDirectory(string path)
        {
            if(!_directories.Contains(path))
                _directories.Add(path);
        }

        public bool Exists(string path)
        {
            if(_files.Contains(path))
                return true;
            if (_directories.Contains(path))
                return true;

            return false;
        }

        public string[] GetFiles(string root)
            => _files.Where(f => f.StartsWith(root)).ToArray();

        public void Dispose()
        {
            _files.Clear();
            _directories.Clear();
        }
    }
}

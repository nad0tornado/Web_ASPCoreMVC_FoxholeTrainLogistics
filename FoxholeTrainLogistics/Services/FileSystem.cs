using FoxholeTrainLogistics.Interfaces;

namespace FoxholeTrainLogistics.Services
{
    public class FileSystem : IFileSystem
    {
        public bool Exists(string path)
            => Directory.Exists(path);

        public void CreateDirectory(string path)
            => Directory.CreateDirectory(path);

        public string[] GetFiles(string root)
            => Directory.GetFiles(root,"*.*",SearchOption.AllDirectories);
    }
}

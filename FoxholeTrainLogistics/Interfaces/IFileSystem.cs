namespace FoxholeTrainLogistics.Interfaces
{
    public interface IFileSystem
    {
        public bool Exists(string path);
        public void CreateDirectory(string path);
        public string[] GetFiles(string root);
    }
}

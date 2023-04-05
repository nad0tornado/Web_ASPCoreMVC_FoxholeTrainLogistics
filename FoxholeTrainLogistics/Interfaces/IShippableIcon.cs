namespace FoxholeTrainLogistics.Interfaces
{
    public enum ShippableIconType { Category, Item}
    public interface IShippableIcon
    {
        public string ImagePath { get;  }
        public string Name { get;}
        public string DisplayName { get; }
    }
}

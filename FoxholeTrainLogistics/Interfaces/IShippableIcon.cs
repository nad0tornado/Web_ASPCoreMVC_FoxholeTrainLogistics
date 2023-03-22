namespace FoxholeTrainLogistics.Interfaces
{
    public enum ShippableIconType { Category, Item}
    public interface IShippableIcon
    {
        public ShippableIconType Type { get; }
        public string ImagePath { get;  }
        public string Name { get;}
        public string DisplayName { get; }
    }
}

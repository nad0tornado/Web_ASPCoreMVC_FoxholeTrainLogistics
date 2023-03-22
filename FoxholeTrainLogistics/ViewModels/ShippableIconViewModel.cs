using FoxholeTrainLogistics.Interfaces;

namespace FoxholeTrainLogistics.ViewModels
{
    public class ShippableIconViewModel : IShippableIcon
    {
        public ShippableIconType Type { get; private set; }
        public string ImagePath { get; private set; }
        public string Name { get; private set; }
        public string DisplayName { get; private set; }

        public ShippableIconViewModel(ShippableIconType type, string imagePath, string name, string displayName)
        {
            Type = type;
            ImagePath = imagePath;
            Name = name;
            DisplayName = displayName;
        }
    }
}

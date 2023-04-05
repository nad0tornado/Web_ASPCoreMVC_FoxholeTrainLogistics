using FoxholeTrainLogistics.Interfaces;

namespace FoxholeTrainLogistics.ViewModels
{
    public class ShippableIconViewModel : IShippableIcon
    {
        public string ImagePath { get; private set; }
        public string Name { get; private set; }
        public string DisplayName { get; private set; }

        public ShippableIconViewModel(string imagePath, string name, string displayName)
        {
            ImagePath = imagePath;
            Name = name;
            DisplayName = displayName;
        }
    }
}

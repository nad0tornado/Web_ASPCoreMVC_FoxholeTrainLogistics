using FoxholeTrainLogistics.ViewModels;

namespace FoxholeTrainLogistics.Interfaces
{
    public interface IShippableToolbarService
    {
        public List<IShippableIcon> GetShippableCategories();
        public Dictionary<string, List<IShippableIcon>> GetShippableItems();
    }
}

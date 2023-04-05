using FoxholeItemAPI.Interfaces;

namespace FoxholeTrainLogistics.Interfaces
{
    public interface IShippableToolbarService
    {
        public List<IShippableIcon> GetShippableCategories();
        public Task<Dictionary<string, List<IItem>>> GetShippableItems();
    }
}

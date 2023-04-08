using FoxholeItemAPI.Interfaces;
using FoxholeTrainLogistics.Interfaces;

namespace FoxholeTrainLogistics.Interfaces
{
    public interface IShippableToolbarService
    {
        public List<IShippableIcon> GetShippableCategories();

        public Task<Dictionary<string, List<IItem>>> GetShippableItems();

        public void LoadItemOntoTrain(IItem shippableItem);
    }
}

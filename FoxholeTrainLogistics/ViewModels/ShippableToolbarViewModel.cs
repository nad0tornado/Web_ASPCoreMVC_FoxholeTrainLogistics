using FoxholeItemAPI.Interfaces;
using FoxholeItemAPI.Utils;
using FoxholeTrainLogistics.Interfaces;

namespace FoxholeTrainLogistics.ViewModels
{
    public class ShippableToolbarViewModel
    {
        private IShippableToolbarService _shippableToolbarService;

        public List<IShippableIcon> ShippableCategories { get; private set; }

        public Dictionary<string, List<IItem>>? _shippableItems = null;

        public ShippableToolbarViewModel(IShippableToolbarService shippableToolbarService)
        {
            ShippableCategories = shippableToolbarService.GetShippableCategories();

            _shippableToolbarService = shippableToolbarService;
        }

        public async Task<Dictionary<string, List<IItem>>> GetShippableItems()
        {
            if(_shippableItems == null)
                _shippableItems = await _shippableToolbarService.GetShippableItems();

            return _shippableItems;
        }
    }
}

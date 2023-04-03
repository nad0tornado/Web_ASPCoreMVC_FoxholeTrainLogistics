using FoxholeTrainLogistics.Interfaces;
using FoxholeTrainLogistics.Services;
using System.Linq;
using System.Text.RegularExpressions;

namespace FoxholeTrainLogistics.ViewModels
{
    public class ShippableToolbarViewModel
    {
        private IShippableToolbarService _shippableToolbarService;  
        public List<IShippableIcon> ShippableCategories { get; private set; }

        public Dictionary<string, List<IShippableIcon>>? _shippableItems = null;

        public ShippableToolbarViewModel(IShippableToolbarService shippableToolbarService)
        {
            ShippableCategories = shippableToolbarService.GetShippableCategories();
            _shippableToolbarService = shippableToolbarService;
        }

        public async Task<Dictionary<string, List<IShippableIcon>>> GetShippableItems()
        {
            if(_shippableItems == null)
                _shippableItems = await _shippableToolbarService.GetShippableItems();

            return _shippableItems;
        }
    }
}

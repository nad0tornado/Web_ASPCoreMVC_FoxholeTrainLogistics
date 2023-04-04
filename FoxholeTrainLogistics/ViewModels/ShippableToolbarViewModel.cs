using FoxholeTrainLogistics.Interfaces;
using FoxholeTrainLogistics.Services;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text.RegularExpressions;

namespace FoxholeTrainLogistics.ViewModels
{
    public class ShippableToolbarViewModel
    {
        private IConfiguration _configuration;
        private IShippableToolbarService _shippableToolbarService;  
        public List<IShippableIcon> ShippableCategories { get; private set; }

        public Dictionary<string, List<IShippableIcon>>? _shippableItems = null;

        public ShippableToolbarViewModel(IShippableToolbarService shippableToolbarService, IConfiguration configuration)
        {
            ShippableCategories = shippableToolbarService.GetShippableCategories();
            _shippableToolbarService = shippableToolbarService;
            _configuration = configuration;

        }

        public async Task<Dictionary<string, List<IShippableIcon>>> GetShippableItems()
        {
            if(_shippableItems == null)
                _shippableItems = await _shippableToolbarService.GetShippableItems();

            var shippableIconsAggregate = _shippableItems.Values.SelectMany(l => l);

            var iconShadowsConfig = _configuration.GetValue<string>("Logging");
            foreach (IShippableIcon icon in shippableIconsAggregate)
            {
                
            }

            return _shippableItems;
        }
    }
}

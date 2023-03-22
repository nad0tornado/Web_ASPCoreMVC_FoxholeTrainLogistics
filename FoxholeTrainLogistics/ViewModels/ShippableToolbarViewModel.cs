using FoxholeTrainLogistics.Interfaces;
using FoxholeTrainLogistics.Services;
using System.Linq;
using System.Text.RegularExpressions;

namespace FoxholeTrainLogistics.ViewModels
{
    public class ShippableToolbarViewModel
    {
       
        public List<IShippableIcon> ShippableCategories { get; private set; }
        private List<string> shippableCategoriesNames { get; } = new List<string>();

        public Dictionary<string,List<IShippableIcon>> ShippableItems { get; } = new Dictionary<string, List<IShippableIcon>>();

        public ShippableToolbarViewModel(IShippableToolbarService shippableToolbarService)
        {
            ShippableCategories = shippableToolbarService.GetShippableCategories();
        }

        
    }
}

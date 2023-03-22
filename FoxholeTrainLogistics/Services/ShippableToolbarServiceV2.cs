using FoxholeTrainLogistics.Interfaces;
using FoxholeTrainLogistics.ViewModels;
using System.Text.RegularExpressions;

namespace FoxholeTrainLogistics.Services
{
    public class ShippableToolbarServiceV2 : IShippableToolbarService
    {
        const string contentRoot = "./wwwroot";
        const string shippableContentRoot = contentRoot + "/img/shippable";

        private static List<IShippableIcon> shippableCategories = new List<IShippableIcon>();
        private static Dictionary<string, List<IShippableIcon>> shippableItems = new Dictionary<string, List<IShippableIcon>>();

        public ShippableToolbarServiceV2()
        {
            setupCategories();
            setupItems();
        }

        public List<IShippableIcon> GetShippableCategories() => shippableCategories;

        public Dictionary<string, List<IShippableIcon>> GetShippableItems() => shippableItems;

        private void setupCategories()
        {
            var categoriesImagePaths = Directory.GetFiles(shippableContentRoot + "/categories/");

            foreach (var path in categoriesImagePaths)
            {
                var localPath = path.Replace(contentRoot, ".");
                var nameIndex = localPath.LastIndexOf('/') + 1;
                var name = Path.GetFileNameWithoutExtension(localPath.Substring(nameIndex));

                name = name[0].ToString().ToLower() + name.Substring(1);

                if (!Directory.Exists(shippableContentRoot + "/" + name))
                    Directory.CreateDirectory(shippableContentRoot + "/" + name);

                var indexOfUppers = Regex.Matches(name, "[A-Z]");

                var displayName = name;

                for (int i = 0; i < displayName.Length; i++)
                {
                    if (indexOfUppers.Any(m => m.Index == i) && i != 0)
                        displayName = displayName.Insert(i, " ");
                }

                displayName = Regex.Replace(displayName, @"\b\w", m => m.Value.ToUpper());
                shippableCategories.Add(new ShippableIconViewModel(ShippableIconType.Category, localPath, name, displayName));
            }
        }

        private void setupItems()
        {
            foreach(IShippableIcon category in shippableCategories)
            {
                var categoriesImagePaths = Directory.GetFiles(shippableContentRoot + "/categories/" + category.Name +"/");
            }
        }
    }
}

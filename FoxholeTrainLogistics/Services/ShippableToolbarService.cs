using FoxholeTrainLogistics.Interfaces;
using FoxholeTrainLogistics.ViewModels;
using System.Text.RegularExpressions;

namespace FoxholeTrainLogistics.Services
{
    public class ShippableToolbarService : IShippableToolbarService
    {
        const string contentRoot = "./wwwroot";
        const string shippableContentRoot = contentRoot + "/img/shippable";

        public ShippableToolbarService() { }

        public List<IShippableIcon> GetShippableCategories()
        {
            var categories = new List<IShippableIcon>();
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

                for (int i = 0; i < name.Length; i++)
                {
                    if (indexOfUppers.Any(m => m.Index == i) && i != 0)
                        name = name.Insert(i, " ");
                }

                name = Regex.Replace(name, @"\b\w", m => m.Value.ToUpper());
                categories.Add(new ShippableIconViewModel(ShippableIconType.Category, localPath, name));
            }

            return categories;
        }

        public Dictionary<string,List<IShippableIcon>> GetShippableItems()
        {
            var shippableItems = new Dictionary<string,List<IShippableIcon>>();

            return shippableItems;
        }
    }
}

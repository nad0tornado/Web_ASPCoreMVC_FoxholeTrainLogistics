using FoxholeItemAPI.Models;
using FoxholeItemAPI.Utils;
using FoxholeTrainLogistics.Interfaces;
using FoxholeTrainLogistics.ViewModels;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace FoxholeTrainLogistics.Services
{
    public class ShippableToolbarService : IShippableToolbarService
    {
        const string contentRoot = "./wwwroot";
        const string shippableContentRoot = contentRoot + "/img/shippable";

        public ShippableToolbarService() { 
            
        }

        private string getNameFromPath(string path)
        {
            var nameIndex = path.LastIndexOf('/') + 1;
            var name = Path.GetFileNameWithoutExtension(path.Substring(nameIndex));

            name = name[0].ToString().ToLower() + name.Substring(1);

            return name;
        }

        private string getDisplayNameFromName(string name)
        {
            var indexOfUppers = Regex.Matches(name, "[A-Z]");

            var displayName = name;

            for (int i = 0; i < displayName.Length; i++)
            {
                if (indexOfUppers.Any(m => m.Index == i) && i != 0)
                    displayName = displayName.Insert(i, " ");
            }

            displayName = Regex.Replace(displayName, @"\b\w", m => m.Value.ToUpper());

            return displayName;
        }

        public List<IShippableIcon> GetShippableCategories()
        {
            var categories = new List<IShippableIcon>();
            var categoriesImagePaths = Directory.GetFiles(shippableContentRoot + "/categories/");

            foreach (var path in categoriesImagePaths)
            {
                var localPath = path.Replace(contentRoot, ".");
                var name = getNameFromPath(localPath);
                var category = name.ToCategory();
                var displayName = getDisplayNameFromName(category.ToString());

                if (!Directory.Exists(shippableContentRoot + "/" + name))
                    Directory.CreateDirectory(shippableContentRoot + "/" + name);

                categories.Add(new ShippableIconViewModel(ShippableIconType.Category, localPath, name, displayName));
            }

            return categories;
        }

        public async Task<Dictionary<string,List<IShippableIcon>>> GetShippableItems()
        {
            var shippableItems = new Dictionary<string, List<IShippableIcon>>();
            var httpClient = new HttpClient();

            // .. this code will need to become a separate "service" and "mocked" to be able to be tested
            var foxholeApiItemsResponse = await httpClient.GetAsync("https://localhost:7118/api/items");
            foxholeApiItemsResponse.EnsureSuccessStatusCode();
            var foxholeApiItemsJson = await foxholeApiItemsResponse.Content.ReadAsStringAsync();
            foxholeApiItemsJson = Regex.Replace(foxholeApiItemsJson, @"\b\w", m => m.Value.ToUpper());

            var foxholeApiItems = JsonSerializer.Deserialize<List<Item>>(foxholeApiItemsJson) ?? new();

            foreach (IShippableIcon category in GetShippableCategories())
            {
                var itemsImagePaths = Directory.GetFiles(shippableContentRoot + "/" + category.Name + "/", "*.*", SearchOption.AllDirectories);
                var itemsInCategory = foxholeApiItems.Where(i => i.Category.ToString().ToLower() == category.Name.Replace(" ", "").ToLower()).ToList();
                var items = new List<IShippableIcon>();

                foreach (string path in itemsImagePaths)
                {
                    var localPath = path.Replace(contentRoot, ".");
                    var name = getNameFromPath(localPath);
                    var itemInCategory = itemsInCategory.FirstOrDefault(i => i.IconName.ToLower().Contains(name.ToLower()));
                    var displayName = itemInCategory?.DisplayName;

                    if (displayName == null)
                        throw new NullReferenceException("DisplayName cannot be null");

                    items.Add(new ShippableIconViewModel(ShippableIconType.Item, localPath, name, displayName));
                }

                shippableItems.Add(category.Name, items);
            }

            return shippableItems;
        }
    }
}

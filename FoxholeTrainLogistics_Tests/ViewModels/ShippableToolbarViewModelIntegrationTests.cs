using FoxholeItemAPI.Utils;
using FoxholeTrainLogistics.Interfaces;
using FoxholeTrainLogistics.Services;
using FoxholeTrainLogistics.ViewModels;
using FoxholeTrainLogistics_Tests.Fixtures;
using FoxholeTrainLogistics_Tests.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeTrainLogistics_Tests.ViewModels
{
    [Collection("FoxholeTrainLogisticsTestCollection")]
    public class ShippableToolbarViewModelIntegrationTests
    {
        private IMockFileSystem _fileSystem;
        private IShippableToolbarService _shippableToolbarService;

        const string contentRoot = "./wwwroot";
        const string shippableContentRoot = contentRoot + "/img";

        public ShippableToolbarViewModelIntegrationTests(FoxholeTrainLogisticsTestsFixture fixture)
        {
            _fileSystem = fixture.MockFileSystem;
            _shippableToolbarService = fixture.ShippableToolbarService;
        }

        [Theory]
        [InlineData(new string[] { "smallArms.png", "smallArmItem.png" }, new string[] { "shippables.png", "shippableItem.png" })]
        public async void GetShippableItems(string[] category1, string[] category2)
        {
            var categoriesRoot = shippableContentRoot + "/itemCategories";
            _fileSystem.CreateMockFile(categoriesRoot + "/" + category1[0]);
            _fileSystem.CreateMockFile(categoriesRoot + "/" + category2[0]);

            var itemsRoot = shippableContentRoot + "/items";

            var category1Name = Path.GetFileNameWithoutExtension(itemsRoot + "/" + category1[0]);
            var category2Name = Path.GetFileNameWithoutExtension(itemsRoot + "/" + category2[0]);
            var file1Path = itemsRoot + "/" + category1Name + "/" + category1[1];
            var file2Path = itemsRoot + "/" + category2Name + "/" + category2[1];

            _fileSystem.CreateMockFile(file1Path);
            _fileSystem.CreateMockFile(file2Path);

            var shippableToolbarViewModel = new ShippableToolbarViewModel(_shippableToolbarService);
            var shippableItems = await shippableToolbarViewModel.GetShippableItems();
            var shippableItemsIconNames = shippableItems.Values.SelectMany(i => i).Select(i => i.IconName);

            var file1ExpectedIconName = "./img/items/" + category1Name + "/" + category1[1];
            var file2ExpectedIconName = "./img/items/" + category2Name + "/" + category2[1];

            Assert.Contains(file1ExpectedIconName, shippableItemsIconNames);
            Assert.Contains(file2ExpectedIconName, shippableItemsIconNames);
        }
    }
}

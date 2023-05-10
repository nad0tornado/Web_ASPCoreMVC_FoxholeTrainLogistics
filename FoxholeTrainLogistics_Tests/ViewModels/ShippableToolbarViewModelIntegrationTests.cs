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
            _fileSystem.CreateMockFile(itemsRoot + "/" + category1[0] + "/" + category1[1]);
            _fileSystem.CreateMockFile(itemsRoot + "/" + category2[0] + "/" + category2[1]);

            var shippableToolbarViewModel = new ShippableToolbarViewModel(_shippableToolbarService);
            var shippableItems = await shippableToolbarViewModel.GetShippableItems();
        }
    }
}

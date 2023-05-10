using FoxholeItemAPI.Interfaces;
using FoxholeItemAPI.Models;
using FoxholeTrainLogistics.Interfaces;
using FoxholeTrainLogistics.Services;
using FoxholeTrainLogistics.ViewModels;
using FoxholeTrainLogistics_Tests.Fixtures;
using FoxholeTrainLogistics_Tests.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeTrainLogistics_Tests.Services
{
    [Collection("FoxholeTrainLogisticsTestCollection")]
    public class ShippableToolbarServiceUnitTests
    {
        private IMockFileSystem _fileSystem;
        private IShippableToolbarService _shippableToolbarService;

        const string contentRoot = "./wwwroot";
        const string shippableContentRoot = contentRoot + "/img";

        public ShippableToolbarServiceUnitTests(FoxholeTrainLogisticsTestsFixture fixture)
        {
            _fileSystem = fixture.MockFileSystem;
            _shippableToolbarService = fixture.ShippableToolbarService;
        }

        [Fact]
        public void GetShippableCategoriesWhenNoneExist()
        {
            var shippableCategories = _shippableToolbarService.GetShippableCategories();
            Assert.Empty(shippableCategories);
        }

        [Theory]
        [InlineData("smallArms.png", "./img/itemCategories/smallArms.png","smallArms","Small Arms")]
        public void GetOneShippableCategoryAndTestItsProperties(
            string categoryFilename, string expectedImagePath, string expectedName, string expectedDisplayName)
        {
            var categoriesRoot = shippableContentRoot + "/itemCategories";
            _fileSystem.CreateMockFile(categoriesRoot + "/" + categoryFilename);

            var shippableCategories = _shippableToolbarService.GetShippableCategories();
            Assert.Contains(shippableCategories, c => c.ImagePath.EndsWith(categoryFilename));

            var shippableCategory = shippableCategories.FirstOrDefault();
            Assert.NotNull(shippableCategory);

            if (shippableCategory != null)
            {
                Assert.Equal(expectedImagePath, shippableCategory.ImagePath);
                Assert.Equal(expectedName, shippableCategory.Name);
                Assert.Equal(expectedDisplayName, shippableCategory.DisplayName);
            }

            _fileSystem.Dispose();
        }

        [Theory]
        [InlineData("smallArms.png","shippables.png")]
        public void GetShippableCategoriesWhenTwoCategoriesExist(string category1Filename, string category2Filename)
        {
            var categoriesRoot = shippableContentRoot + "/itemCategories";
            _fileSystem.CreateMockFile(categoriesRoot + "/" + category1Filename);
            _fileSystem.CreateMockFile(categoriesRoot + "/" + category2Filename);

            var shippableCategories = _shippableToolbarService.GetShippableCategories();
            Assert.Contains(shippableCategories, c => c.ImagePath.EndsWith(category1Filename));
            Assert.Contains(shippableCategories, c => c.ImagePath.EndsWith(category2Filename));

            _fileSystem.Dispose();
        }

        [Theory]
        [InlineData("smallArms.png", "smallArms.png")]
        public void GetShippableCategoriesWhenDuplicateCategoriesExist(string category1Filename, string category2Filename)
        {
            var categoriesRoot = shippableContentRoot + "/itemCategories";
            _fileSystem.CreateMockFile(categoriesRoot + "/" + category1Filename);
            _fileSystem.CreateMockFile(categoriesRoot + "/" + category2Filename);

            var shippableCategories = _shippableToolbarService.GetShippableCategories();

            Assert.Single(shippableCategories);

            _fileSystem.Dispose();
        }

        [Fact]
        public async void GetShippableItemsWhereNoneExist()
        {
            var shippableItems = await _shippableToolbarService.GetShippableItems();
            Assert.Empty(shippableItems);
        }
    }
}

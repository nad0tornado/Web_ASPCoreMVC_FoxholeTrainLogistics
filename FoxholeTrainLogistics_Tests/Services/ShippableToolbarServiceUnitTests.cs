using FoxholeTrainLogistics.Interfaces;
using FoxholeTrainLogistics.Services;
using FoxholeTrainLogistics.ViewModels;
using FoxholeTrainLogistics_Tests.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeTrainLogistics_Tests.Services
{
    public class ShippableToolbarServiceUnitTestsFixture : IDisposable
    {
        public IMockFileSystem MockFileSystem;
        public IShippableToolbarService ShippableToolbarService;

        // This method is called once before any tests in this fixture are run
        public ShippableToolbarServiceUnitTestsFixture()
        {
            IConfiguration appSettingsConfig = new ConfigurationBuilder()
            .AddJsonFile("appsettings_test.json", optional: true, reloadOnChange: true)
            .Build();

            MockFileSystem = new MockFileSystem();
            ShippableToolbarService = new ShippableToolbarService(appSettingsConfig, MockFileSystem);
        }

        // This method is called once after all tests in this fixture are run
        public void Dispose()
        {
            MockFileSystem.Dispose();
        }
    }

    // This attribute defines the name of the fixture collection
    [CollectionDefinition("ShippableToolbarServiceUnitTestCollection")]
    public class ShippableToolbarServiceUnitTestCollection : ICollectionFixture<ShippableToolbarServiceUnitTestsFixture>
    {
        // This interface doesn't have any members, it's just used to associate the fixture class with this collection
    }

    [Collection("ShippableToolbarServiceUnitTestCollection")]
    public class ShippableToolbarServiceUnitTests
    {
        private IMockFileSystem _fileSystem;
        private IShippableToolbarService _shippableToolbarService;

        const string contentRoot = "./wwwroot";
        const string shippableContentRoot = contentRoot + "/img";

        public ShippableToolbarServiceUnitTests(ShippableToolbarServiceUnitTestsFixture fixture)
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
    }
}

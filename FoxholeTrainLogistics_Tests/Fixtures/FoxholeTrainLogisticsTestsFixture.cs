using FoxholeItemAPI.Interfaces;
using FoxholeItemAPI.Models;
using FoxholeTrainLogistics.Interfaces;
using FoxholeTrainLogistics.Services;
using FoxholeTrainLogistics_Tests.Interfaces;
using FoxholeTrainLogistics_Tests.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeTrainLogistics_Tests.Fixtures
{
    public class FoxholeTrainLogisticsTestsFixture
    {
        public IMockFileSystem MockFileSystem;
        public IShippableToolbarService ShippableToolbarService;
        public IFoxholeItemAPIService<Item> FoxholeItemApiService;

        // This method is called once before any tests in this fixture are run
        public FoxholeTrainLogisticsTestsFixture()
        {
            IConfiguration appSettingsConfig = new ConfigurationBuilder()
            .AddJsonFile("appsettings_test.json", optional: true, reloadOnChange: true)
            .Build();

            MockFileSystem = new MockFileSystem();
            FoxholeItemApiService = new MockFoxholeItemAPIService();

            ShippableToolbarService = new ShippableToolbarService(appSettingsConfig, MockFileSystem, FoxholeItemApiService);
        }

        // This method is called once after all tests in this fixture are run
        public void Dispose()
        {
            MockFileSystem.Dispose();
        }
    }

    // This attribute defines the name of the fixture collection
    [CollectionDefinition("FoxholeTrainLogisticsTestCollection")]
    public class ShippableToolbarServiceUnitTestCollection : ICollectionFixture<FoxholeTrainLogisticsTestsFixture> { }
}

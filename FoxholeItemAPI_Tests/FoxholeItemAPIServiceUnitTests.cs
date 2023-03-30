using FoxholeItemAPI_Tests.Interfaces;
using FoxholeItemAPI;
using FoxholeItemAPI.Services;
using FoxholeItemAPI_Tests.Repositories;
using FoxholeItemAPI.Repositories;

namespace FoxholeItemAPI_Tests
{
    public class FoxholeItemAPIServiceUnitTests : IFoxholeItemAPIServiceUnitTest
    {
        [Fact]
        public void TestGetAllItems()
        {
            // .. Get all of the items
            var repo = new FoxholeItemAPIRepository();
            var items = repo.GetItems();

            // .. Make sure that the list is not empty and contains items of at least two different types
            Assert.NotEmpty(items);
            Assert.Contains(items, (i => i.Category == Category.Ammunition));
            Assert.Contains(items, (i => i.Category == Category.Shippable));
        }

        [Theory]
        [InlineData(Category.Ammunition,Category.Shippable)]
        public void TestGetItemsInCategory(Category categoryA, Category categoryB)
        {
            // .. GET Icons (Category : Enum) -> return a list of all items in the JSON file matching [category]

            // .. Get all of the items in [categoryA]
            var itemsInCategory = FoxholeItemAPIService.GetItemsInCategory(categoryA);

            // .. Make sure the list is non-empty, contains at least one item in [categoryA] and NO ITEMS in any other category
            Assert.NotEmpty(itemsInCategory);
            Assert.Contains(itemsInCategory, (i => i.Category == categoryA));
            Assert.DoesNotContain(itemsInCategory, (i => i.Category != categoryA));

            // .. Get all of the items in [categoryB]
            itemsInCategory = FoxholeItemAPIService.GetItemsInCategory(categoryB);

            // .. Make sure the list is non-empty, contains at least one item in [categoryB] and NO ITEMS in any other category
            Assert.NotEmpty(itemsInCategory);
            Assert.Contains(itemsInCategory, (i => i.Category == categoryB));
            Assert.DoesNotContain(itemsInCategory, (i => i.Category != categoryB));
        }
    }
}
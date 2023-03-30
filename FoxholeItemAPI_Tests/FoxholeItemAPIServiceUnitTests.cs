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
            var repo = new MockFoxholeItemAPIRepository();
            var items = repo.GetItems();

            // .. Make sure that the list is not empty and contains items of at least two different types
            Assert.NotEmpty(items);
            Assert.Contains(items, (i => i.Category == Category.SmallArms));
            Assert.Contains(items, (i => i.Category == Category.Shippables));
        }

        [Theory]
        [InlineData(Category.SmallArms,Category.Shippables)]
        public void TestGetItemsInCategory(Category categoryA, Category categoryB)
        {
            // .. GET Icons (Category : Enum) -> return a list of all items in the JSON file matching [category]

            // .. Get all of the items in [categoryA]
            var repo = new MockFoxholeItemAPIRepository();
            var itemsInCategory = repo.GetItemsInCategory(categoryA);

            // .. Make sure the list is non-empty, contains at least one item in [categoryA] and NO ITEMS in any other category
            Assert.NotEmpty(itemsInCategory);
            Assert.Contains(itemsInCategory, (i => i.Category == categoryA));
            Assert.DoesNotContain(itemsInCategory, (i => i.Category != categoryA));

            // .. Get all of the items in [categoryB]
            itemsInCategory = repo.GetItemsInCategory(categoryB);

            // .. Make sure the list is non-empty, contains at least one item in [categoryB] and NO ITEMS in any other category
            Assert.NotEmpty(itemsInCategory);
            Assert.Contains(itemsInCategory, (i => i.Category == categoryB));
            Assert.DoesNotContain(itemsInCategory, (i => i.Category != categoryB));
        }
    }
}
using FoxholeItemAPI_Tests.Interfaces;
using FoxholeItemAPI;

namespace FoxholeFandomAPI_Tests
{
    // .. https://foxhole.fandom.com/wiki/Category:Icons
    public class FoxholeFandomAPIServiceUnitTests : IFoxholeItemAPIServiceUnitTest
    {
        [Fact(Skip ="Skipped due to not being implemented")]
        public void TestGetAllItems()
        {
            // .. GET Icons -> return a list of all items under https://foxhole.fandom.com/wiki/Category:Icons
            // - Icon links will be scanned for tags to find the singular "info" page about that item
            throw new NotImplementedException();
        }

        [Theory(Skip = "Skipped due to not being implemented")]
        [InlineData(Category.Ammunition, Category.Shippable)]
        public void TestGetItemsInCategory(Category categoryA, Category categoryB)
        {
            // .. GET Icons (Category : Enum) -> return a list of all items under [WIKIROOT]/Category:[CATEGORY]
            throw new NotImplementedException();
        }
    }
}

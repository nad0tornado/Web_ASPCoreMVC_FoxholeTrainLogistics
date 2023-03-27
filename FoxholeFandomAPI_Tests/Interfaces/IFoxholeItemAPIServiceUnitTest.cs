using FoxholeItemAPI;
using FoxholeItemAPI.Core;

namespace FoxholeItemAPI_Tests.Interfaces
{
    public interface IFoxholeItemAPIServiceUnitTest
    {
        [Fact]
        public void TestGetAllItems();

        [Theory]
        [InlineData(null, null)]
        public void TestGetItemsInCategory(Category categoryA, Category categoryB);
    }
}

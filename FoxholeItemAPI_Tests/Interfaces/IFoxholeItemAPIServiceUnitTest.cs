using FoxholeItemAPI.Utils;

namespace FoxholeItemAPI_Tests.Interfaces
{
    public interface IFoxholeItemAPIServiceUnitTest
    {
        [Fact]
        public void TestGetAllItems();

        [Theory]
        [InlineData(Category.Unknown, Category.Unknown)]
        public void TestGetItemsInCategory(Category categoryA, Category categoryB);
    }
}

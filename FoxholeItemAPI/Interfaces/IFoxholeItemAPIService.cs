using FoxholeItemAPI.Core;

namespace FoxholeItemAPI.Interfaces
{
    internal interface IFoxholeItemAPIService
    {
        public static List<IItem> GetItems() {  throw new NotImplementedException(); }
        public static List<IItem> GetItemsInCategory(Category category) { throw new NotImplementedException(); }
    }
}

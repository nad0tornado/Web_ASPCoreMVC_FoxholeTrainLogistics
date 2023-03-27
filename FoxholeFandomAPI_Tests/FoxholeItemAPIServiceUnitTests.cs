namespace FoxholeFandomAPI_Tests
{
    // .. https://foxhole.fandom.com/wiki/Category:Icons
    public class FoxholeItemAPIServiceUnitTests
    {
        // .. Enum => Category {
        // Ammunition, Base_Upgrade, Building, Event, Facility, Map, Medical, Research, Resource, Shippable,
        // Supplie, Tool, UI, Uniform, Vehicle, Weapon, None }

        // .. Enum => ShippingType {
        // ShippingContainer, Pallet, CrateOrPackage
        //}

        // INTERFACE => IItem
        // - Icon => string
        // - DisplayName => string
        // - 
        // - ShippingType => enum

        // INTERFACE => IItemService
        // - GetAllItems => List<IItem>
        // - GetItemsInCategory (Category: Enum) => List<IItem>

        [Fact]
        public void TestGetAllItems()
        {
            // .. GET Icons -> return a list of all items under https://foxhole.fandom.com/wiki/Category:Icons

            var itemService = new FoxholeAPIItemService();
            var items = itemService.GetAllItems();

            Assert.NotEmpty(items);
        }

        [Fact]
        public void TestGetItemsInCategory()
        {
            // .. GET Icons (Category : Enum) -> return a list of all items under [WIKIROOT]/Category:[CATEGORY]
        }
    }
}
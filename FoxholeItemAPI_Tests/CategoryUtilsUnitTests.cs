using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxholeItemAPI.Utils;

namespace FoxholeItemAPI_Tests
{
    public class CategoryUtilsUnitTests
    {
        [Theory]
        [InlineData("small_arms", Category.SmallArms)]
        [InlineData("shipables",Category.Shippables)]
        [InlineData("barneythedinosaur", Category.Unknown)]
        public void ToCategoryUnitTest(string value,Category expectedCategory)
        {
            Category category = value.ToCategory();
            Assert.Equal(expectedCategory, category);
        }
    }
}

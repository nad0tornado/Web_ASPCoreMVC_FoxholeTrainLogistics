using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FoxholeItemAPI;
using FoxholeItemAPI.Converters;
using FoxholeItemAPI.Models;

namespace FoxholeItemAPI_Tests
{
    public class ItemConverterUnitTests
    {
        [Fact]
        public void Read_MissingProperty_ThrowsException()
        {
            string json = "{ " +
                "\"imgName\": \"testImg\"," +
                "\"itemCategory\": \"small_arms\""+
            "}";

            var options = new JsonSerializerOptions();
            options.Converters.Add(new ItemConverter());

            Assert.Throws<NullReferenceException>(() =>
            {
                JsonSerializer.Deserialize<Item>(json, options);
            });
        }

        [Fact]
        public void Read_ReturnsItem()
        {
            string json = "{ " +
                "\"itemName\": \"test\"," +
                "\"imgName\": \"testImg\"," +
                "\"itemCategory\": \"small_arms\"" +
            "}";

            var options = new JsonSerializerOptions();
            options.Converters.Add(new ItemConverter());

            Item? item = JsonSerializer.Deserialize<Item>(json, options);

            Assert.NotNull(item);
            Assert.Equal("test", item?.DisplayName);
            Assert.Equal("testImg", item?.IconName);
            Assert.Equal(Category.SmallArms, item?.Category);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using FoxholeItemAPI.Models;

namespace FoxholeItemAPI.Converters
{
    internal class ItemConverter : JsonConverter<Item>
    {
        public override Item Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Read the JSON object into a dictionary
            var jsonDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(ref reader, options);

            if (jsonDict == null)
                throw new NullReferenceException("Failed to map Item data. Check input and try again");

            if (!jsonDict.ContainsKey("itemName"))
                throw new NullReferenceException("\"itemName\" is required");
            if (!jsonDict.ContainsKey("imgName"))
                throw new NullReferenceException("\"imgName\" is required");
            if (!jsonDict.ContainsKey("itemCategory"))
                throw new NullReferenceException("\"itemCategory\" is required");

            // Extract the name and age properties from the dictionary
            string iconName = jsonDict["imgName"].GetString() ?? string.Empty;
            string displayName = jsonDict["itemName"].GetString() ?? string.Empty;
            string? categoryStr = jsonDict["itemCategory"].GetString();

            // Create a new Person object and return it
            return new Item { IconName = iconName, DisplayName = displayName, Category = categoryStr.ToCategory() };
        }

        public override void Write(Utf8JsonWriter writer, Item value, JsonSerializerOptions options)
        {
            // Write the Person object as a JSON object with name and age properties
            writer.WriteStartObject();
            writer.WriteString("imgName", value.IconName);
            writer.WriteString("itemName", value.DisplayName);
            writer.WriteString("itemCategory", value.Category.ToString());
            writer.WriteEndObject();
        }
    }
}

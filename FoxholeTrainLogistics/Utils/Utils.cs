using System.Text.Json.Serialization;
using System.Text.Json;
using FoxholeTrainLogistics.Interfaces;
using FoxholeItemAPI.Utils;

namespace FoxholeTrainLogistics
{
    public static class Utils
    {
        public static string ToJson<T>(this IEnumerable<T> collection)
        {
            var options = new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonStringEnumConverter()
                }
            };

            var collectionJson = JsonSerializer.Serialize(collection, options);
            return collectionJson;
        }

        public static string ToJson<K, V>(this Dictionary<K, V> collection) where K : notnull
        {
            var options = new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonStringEnumConverter()
                }
            };

            var collectionJson = JsonSerializer.Serialize(collection, options);
            return collectionJson;
        }

        public static IEnumerable<E> GetEnumTypes<E>() where E : Enum
            => Enum.GetValues(typeof(E)).Cast<E>();
    }
}

using System.Text.Json.Serialization;
using System.Text.Json;
using FoxholeTrainLogistics.Interfaces;
using FoxholeItemAPI.Utils;

namespace FoxholeTrainLogistics
{
    public static class Utils
    {
        private static string toJson<T>(this T _object)
        {
            var options = new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonStringEnumConverter()
                }
            };

            return JsonSerializer.Serialize(_object, options);
        }
        public static string ToJson<T>(this T _object) => toJson(_object);
        public static string ToJson<T>(this IEnumerable<T> collection) => toJson(collection);
        public static string ToJson<K, V>(this Dictionary<K, V> collection) where K : notnull {
            return toJson(collection);
        }

        public static IEnumerable<E> GetEnumTypes<E>() where E : Enum
            => Enum.GetValues(typeof(E)).Cast<E>();

        public static string GetNameFromPath(this string path)
        {
            var nameIndex = path.LastIndexOf('/') + 1;
            var name = Path.GetFileNameWithoutExtension(path.Substring(nameIndex));

            name = name[0].ToString().ToLower() + name.Substring(1);

            return name;
        }
    }
}

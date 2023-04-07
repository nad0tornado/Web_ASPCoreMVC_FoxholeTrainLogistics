using FoxholeTrainLogistics.Interfaces;
using System.Text.Json;

namespace FoxholeTrainLogistics.Models
{
    public static class Extensions
    {
        public static string ToJson<T>(this IEnumerable<T> collection)
        {
            var collectionJson = JsonSerializer.Serialize(collection);
            return collectionJson; // Regex.Replace(collectionJson,@"\[|\]","");
        }

    }
    public class TrainViewModel
    {
        public ITrain Train;
        public string StatusDisplayName => GetStatusDisplayName();
        public int NumberOfCars => Train.Cars.Count;
        public bool Interactable = false;

        public TrainViewModel(ITrain _train, bool interactable = false)
        {
            Train = _train;
            Interactable = interactable;
        }

        private string GetStatusDisplayName()
        {
            if (Train.Status == TrainStatus.InTransit)
                return "In Transit";
            else
                return Train.Status.ToString();
        }
    }
}

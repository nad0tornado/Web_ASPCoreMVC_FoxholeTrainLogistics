﻿namespace FoxholeTrainLogistics.Interfaces
{
    public interface ITrainCar
    {
        public TrainCarType Type { get; }

        public string DisplayName { get; }

        public string Image { get; }

        public int Crew { get; }

        public string ToString();
    }
}

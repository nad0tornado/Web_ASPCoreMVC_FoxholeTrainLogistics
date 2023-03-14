using FoxholeTrainLogistics.Models;
using Microsoft.EntityFrameworkCore;

namespace FoxholeTrainLogistics.Interfaces
{
    public interface ITrainsDbContext
    {
        public DbSet<Train> Trains { get; }

        public int SaveChanges();
    }
}

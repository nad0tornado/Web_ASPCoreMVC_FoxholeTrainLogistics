using FoxholeTrainLogistics.Models;
using Microsoft.EntityFrameworkCore;
using FoxholeTrainLogistics.Trains;
using FoxholeTrainLogistics.Interfaces;

namespace FoxholeTrainLogistics.Contexts
{
    /// <summary>
    /// Represents the database in use by the Foxhole Trains Logistics application
    /// </summary>
    public class TrainsInMemoryContext : DbContext, ITrainsDbContext
    {
        public DbSet<Train> Trains => Set<Train>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TrainsInMemoryDb");

            base.OnConfiguring(optionsBuilder);
        }
    }
}

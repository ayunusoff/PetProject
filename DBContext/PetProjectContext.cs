using Microsoft.EntityFrameworkCore;
using PetProject.Models;

namespace PetProject.DBContext
{
    public class PetProjectContext : DbContext
    {
        public PetProjectContext(DbContextOptions<PetProjectContext> options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>()
            .HasNoKey();
        }
        public DbSet<Product>? Products { get; set; }
        public DbSet<WeatherForecast>? WeatherForecasts { get; set; }
    }
}
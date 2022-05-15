using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options) :
            base(options)
        { }
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<PointOfInterest> PointsOfInterest { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City("New York City")
                {
                    Id = 1,
                    Description = "Test1"
                },
                new City("Kathmandu")
                {
                    Id = 2,
                    Description = "Test2"
                });
            modelBuilder.Entity<PointOfInterest>().HasData(new PointOfInterest("Central Park")
            {
                Id = 1,
                CityId = 1,
                Description = "Apple1"
            },
            new PointOfInterest("Temple")
            {
                Id = 2,
                CityId = 2,
                Description = "Oh love"
            });
        }
    }
}

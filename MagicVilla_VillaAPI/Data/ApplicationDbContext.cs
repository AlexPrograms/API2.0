using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car()
                {
                    Id = 1,
                    Model = "Phantom",
                    Brand = "Rolls Royce",
                    Price = 1000000,
                    Description = "You already know what it is",
                    MaxSpeed = 300,
                    CountryOfOrigin = "England",
                    CreatedDate = DateTime.Now
                },

                new Car()
                {
                    Id = 2,
                    Model = "S",
                    Brand = "Tesla",
                    Price = 200000,
                    Description = "You already know what it is",
                    MaxSpeed = 200,
                   CountryOfOrigin ="US",
                    CreatedDate = DateTime.Now
                },

                new Car()
                {
                    Id = 3,
                    Model = "Trash",
                    Brand = "S",
                    Price = 55,
                    Description = "You already know what it is",
                    MaxSpeed = 500,
                    CountryOfOrigin = "England",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}

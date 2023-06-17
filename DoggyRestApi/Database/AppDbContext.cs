using DoggyRestApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace DoggyRestApi.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<TouristRoute> TouristRoutes { get; set; }
        public DbSet<TouristRoutePicture> TouristRoutePictures { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<TouristRoute>().HasKey(i => i.Id);
            //modelBuilder.Entity<TouristRoute>().Property(i => i.Title).HasMaxLength(100).IsRequired();
            //modelBuilder.Entity<TouristRoute>().Property(i => i.Description).HasMaxLength(1500).IsRequired();
            //modelBuilder.Entity<TouristRoute>().Property(i => i.OriginalPrice).HasColumnType("decimal(18,2)").IsRequired();


            string touristRouteJson = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Database/touristRoutesMockData.json");
            IList<TouristRoute>? touristRoute = JsonConvert.DeserializeObject<IList<TouristRoute>>(touristRouteJson);
            if (touristRoute != null && touristRoute.Count > 0)
                modelBuilder.Entity<TouristRoute>().HasData(touristRoute);


            string touristRoutePicturesJson = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Database/touristRoutePicturesMockData.json");
            IList<TouristRoutePicture>? touristRoutePictures = JsonConvert.DeserializeObject<IList<TouristRoutePicture>>(touristRoutePicturesJson);
            if (touristRoutePictures != null && touristRoutePictures.Count > 0)
                modelBuilder.Entity<TouristRoutePicture>().HasData(touristRoutePictures);

            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }


    }
}

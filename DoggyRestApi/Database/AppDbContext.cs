using DoggyRestApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json;
using System.Xml;

namespace DoggyRestApi.Database
{
    public class AppDbContext : DbContext//  IdentityDbContext<ProjectIdentityUser>  
    {

        public DbSet<TouristRoute> TouristRoutes { get; set; }

        public DbSet<TouristRoutePicture> TouristRoutePictures { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Import tourist routes for test
            string touristRouteJson = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Database/touristRoutesMockData.json");
            IList<TouristRoute>? touristRoute = JsonConvert.DeserializeObject<IList<TouristRoute>>(touristRouteJson);
            if (touristRoute != null && touristRoute.Count > 0)
                modelBuilder.Entity<TouristRoute>().HasData(touristRoute);

            //Import tourist routes' pictures for test
            string touristRoutePicturesJson = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Database/touristRoutePicturesMockData.json");
            IList<TouristRoutePicture>? touristRoutePictures = JsonConvert.DeserializeObject<IList<TouristRoutePicture>>(touristRoutePicturesJson);
            if (touristRoutePictures != null && touristRoutePictures.Count > 0)
                modelBuilder.Entity<TouristRoutePicture>().HasData(touristRoutePictures);

#if false


            modelBuilder.Entity<ProjectIdentityUser>(u =>
                                                        u.HasMany(x => x.UserRoles).
                                                        WithOne().
                                                        HasForeignKey(ur => ur.UserId).
                                                        IsRequired());
                                                        IsRequired());


            //Create a test admin role
            string adminRoleId = "3517dc69-c27d-46c8-91c9-be03898edbba";
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "Admin".ToUpper()
            });

            //Create a test admin user
            string adminUserId = "c530a290-8c97-4f5d-a6ed-30a0bc3908d3";
            ProjectIdentityUser adminUser01 = new ProjectIdentityUser()
            {
                Id = adminUserId,
                UserName = "admin01@gmail.com",
                NormalizedUserName = "admin01@gmail.com".ToUpper(),
                Email = "admin01@gmail.com",
                NormalizedEmail = "admin01@gmail.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                PhoneNumber = "0201912077",
                PhoneNumberConfirmed = false
            };
            //Hash password
            adminUser01.PasswordHash = new PasswordHasher<ProjectIdentityUser>().HashPassword(adminUser01, "!!!Admin01");
            modelBuilder.Entity<ProjectIdentityUser>().HasData(adminUser01);

            //configure the relationship between admin role Id and admin user Id 
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            }); 
#endif


            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, minimumLevel: LogLevel.Information);
        }


    }
}

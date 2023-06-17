using DoggyRestApi.Database;
using DoggyRestApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Web;
using System;
using System.Diagnostics;

namespace DoggyRestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            //logger.Debug("init main");
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                //Configure NLog
                builder.Logging.ClearProviders();
                builder.Host.UseNLog();

                builder.Services.AddDbContext<AppDbContext>(optitons =>
                {
                    string? conn = builder.Configuration["DbContext:ConnectionString"];//in secret file.json
                    if (string.IsNullOrWhiteSpace(conn))
                        throw new Exception("Database connection string is null!");
                    optitons.UseSqlServer(conn);
                }
                );
                builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                builder.Services.AddScoped<ITouristRouteRepository, TouristRouteRepository>();

                // Add services to the container.
                builder.Services.AddControllers(
                    opt =>
                    opt.ReturnHttpNotAcceptable = true)//return http code 406(unacceptable) for undefined format
                    .AddNewtonsoftJson()
                    .AddXmlDataContractSerializerFormatters();//allow respinsing in xml format

                //logger.Info("Enter builder.Build()");
                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=TouristRoutes}");

                app.Run();
            }
            catch (Exception ex)
            {
                //logger.Error(ex, "Stopped program because of exception");
            }
            finally
            {
                //LogManager.Shutdown();

            }
        }
    }
}
using DoggyRestApi.Database;
using DoggyRestApi.Models;
using DoggyRestApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NLog;
using NLog.Web;
using System.Text;

namespace DoggyRestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Info("Initialize NLog");
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                //Configure NLog
                builder.Logging.ClearProviders();
                builder.Host.UseNLog();

                //Configure DBContext
                builder.Services.AddDbContext<AppDbContext>(optitons =>
                {
                    string? conn = builder.Configuration["DbContext:ConnectionString"];//in secret file.json
                    if (string.IsNullOrWhiteSpace(conn))
                        throw new Exception("Database connection string is null!");
                    optitons.UseSqlServer(conn);
                }
                );

                //Configure Identity DBContext
                builder.Services.AddIdentity<ProjectIdentityUser, IdentityRole>().
                    AddEntityFrameworkStores<AppDbContext>();

                //AutoMapper
                builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                //TouristRoute repository
                builder.Services.AddScoped<ITouristRouteRepository, TouristRouteRepository>();

                //JWT
                builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                    AddJwtBearer(options =>
                    {
                        byte[] secreteKeyBytes = Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretKey"]);
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidIssuer = builder.Configuration["Authentication:Issuer"],

                            ValidateAudience = true,
                            ValidAudience = builder.Configuration["Authentication:Audience"],

                            ValidateLifetime = true,

                            IssuerSigningKey = new SymmetricSecurityKey(secreteKeyBytes)
                        };
                    });

                // Add services to the container.
                builder.Services.AddControllers(
                    opt =>
                   {
                       opt.RespectBrowserAcceptHeader = true;
                       opt.ReturnHttpNotAcceptable = true;//return http code 406(unacceptable) for undefined format
                   })
                    .AddNewtonsoftJson()
                    .AddXmlDataContractSerializerFormatters() //allow responsing in xml format
                    .ConfigureApiBehaviorOptions(setupAction =>
                    {
                        setupAction.InvalidModelStateResponseFactory = context =>
                        {
                            var problemDetail = new ValidationProblemDetails(context.ModelState)
                            {
                                Type = "DataValidation",
                                Title = "DataValidationFailure",
                                Status = StatusCodes.Status422UnprocessableEntity,
                                Detail = "Please see the details",
                                Instance = context.HttpContext.Request.Path
                            };
                            problemDetail.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

                            logger.Error(JsonConvert.SerializeObject(problemDetail));

                            return new UnprocessableEntityObjectResult(problemDetail)
                            {
                                ContentTypes = { "application/problem+json" }
                            };
                        };
                    });

                //Add httpclient for internal http request
                builder.Services.AddHttpClient();

                builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

                //
                builder.Services.Configure<MvcOptions>(config =>
                {
                    var newtonsoftJsonOutputFormatter = config.OutputFormatters.
                                                               OfType<NewtonsoftJsonOutputFormatter>()?.
                                                               FirstOrDefault();
                    if (newtonsoftJsonOutputFormatter != null)
                        newtonsoftJsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.Tuanyang.hateoas+json");
                }
                );


                logger.Info("Enter builder.Build()");
                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    //app.UseStatusCodePagesWithReExecute("/Error/HandleErrorCode/{0}");
                    app.UseExceptionHandler("/Error/HandleGlobalException");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();
                app.UseAuthentication();
                app.UseAuthorization();



                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=TouristRoutes}");

                app.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
            }
            finally
            {
                LogManager.Shutdown();

            }
        }
    }
}
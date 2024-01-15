using Serilog;
using Serilog.Events;
using Serilog.AspNetCore;
using System;
using System.Reflection;
using Versta24.Application;
using Versta24.Application.Common.Mappings;
using Versta24.Application.interfaces;
using Versta24.Persistence;
using Versta24.WebApi.Middleware;

namespace Versta24.WebApi
{
    public class Program
    {
       
        
        public static void Main(string[] args)
        {
            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //    .WriteTo.File("Versta24WebAppLog-.txt", rollingInterval:
            //    RollingInterval.Day)
            //    .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);
            Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console() // Используем console sink, можно заменить на другой по вашему выбору
    .CreateLogger();
            builder.Host.UseSerilog();
            builder.Services.AddAutoMapper(config => 
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IOrdersDbContext).Assembly));
            });
            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddCors(opt=>
            {
                opt.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
            builder.Services.AddSwaggerGen(cfg=>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                cfg.IncludeXmlComments(xmlPath);
            });
            
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<OrdersDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex) 
                {
                    //Log.Fatal(ex, "An error ocured while app init");
                }
            }
      

            app.UseSwagger();
            app.UseSwaggerUI(config=>
            {
                config.RoutePrefix = string.Empty;
                config.SwaggerEndpoint("swagger/v1/swagger.json", "Orders");
            });
            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.Run();
        }
    }
}

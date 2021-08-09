using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;


namespace HotelsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                .WriteTo.File(
                path: "/home/vinicius/Documents/Projects/HotelsApi/Logs/log-.txt",
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                rollingInterval: RollingInterval.Day,
                restrictedToMinimumLevel: LogEventLevel.Information
                ).CreateLogger();
            try
            {
                Log.Information("Application is starting");
                CreateHostBuilder(args).Build().Run();
            }

            catch (Exception ex)
            {
                Log.Fatal(ex, "Application failed to start");
                throw;
            }
            finally{
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

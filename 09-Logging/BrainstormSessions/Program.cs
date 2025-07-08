using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;
using System.Collections.Generic;

namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var emailSinkOptions = new EmailSinkOptions
            {
                From = "quickmaildispatch@gmail.com",
                To = new List<string> { "lotushotmail111@gmail.com" },
                Host = "localhost",
                Port = 25,
            };

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("C:\\Users\\lotus_biswas\\Documents\\net-mentoring\\09-Logging\\log.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Email(
                    emailSinkOptions,
                    restrictedToMinimumLevel: LogEventLevel.Error
                )
                .CreateLogger();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((hostingContext, loggerConfiguration) =>
                    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

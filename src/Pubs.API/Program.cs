using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using Pubs.Application.Infrastructure.Extensions;
using System;
using MsoftLoggingExt = Microsoft.Extensions.Logging;

namespace Pubs.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            /*
             * NLog: Register custom logging layout renderers
             */

            //NLog.LogManager.Setup()
            //    .SetupExtensions(s => s.RegisterLayoutRenderer<UserIdLayoutRenderer>("pubs-user-identity-id"))
            //    .SetupExtensions(s => s.RegisterLayoutRenderer<EncryptedSessionIdLayoutRenderer>("pubs-encrypted-session-id"))

            var logger = LogManager.Setup()
                                    .LoadConfigurationFromAppSettings()
                                    .GetCurrentClassLogger();
            try
            {
                if (string.IsNullOrEmpty(environment))
                {
                    environment = "None";
                }

                //logger.WithProperty("EventId_Id", Convert.ToInt32(LoggingEventId.ApplicationStartup))
                //    .WithProperty("EventId_Name", LoggingEventId.ApplicationStartup.GetDisplayName())
                //    .Info($"Program startup (Environment: {environment})");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                // NLog: catch setup errors
                logger.Error(ex, "Program stopped due to an exception");
                throw;
            }
            finally
            {
                // Log application shutdown event
                //logger.WithProperty("EventId_Id", Convert.ToInt32(LoggingEventId.ApplicationShutdown))
                //    .WithProperty("EventId_Name", LoggingEventId.ApplicationShutdown.GetDisplayName())
                //    .Info("Program shutdown");

                // NLog: shutdown the logger
                LogManager.Shutdown();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hc, builder) =>
                {
                    if (hc.HostingEnvironment.IsOneOfOurDevelopmentEnvironments())
                    {
                        builder.AddUserSecrets<Program>();
                    }
                })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(MsoftLoggingExt.LogLevel.Trace);
                })
                .UseNLog();
    }
}

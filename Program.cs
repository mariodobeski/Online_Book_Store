using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace OnlineBookstore
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                //NLog: setup the logger first to catch all errors
                logger.Debug("init main");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                //Nlog: catch setup errors
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                //Ensure to flush and stop internal timers/threads before application-exit (avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
            //BuildWebHost(args).Run();
        }

     //   public static IWebHost BuildWebHost(string[] args) =>
    //WebHost.CreateDefaultBuilder(args)
    //    .UseStartup<Startup>()
   //     .Build();
         public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>()
                      .ConfigureLogging(logging =>
                      {
                          logging.ClearProviders();
                          logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                      })
                      .UseNLog(); //NLog : Setup NLog for dependency
                 });
    }
}

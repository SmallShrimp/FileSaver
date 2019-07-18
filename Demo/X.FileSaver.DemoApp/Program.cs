using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace X.FileSaver.DemoApp
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.File($"Logs/log-.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                Log.Information("Starting web host.");
                BuildWebHostInternal(args).Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly!");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost BuildWebHostInternal(string[] args)
        {
            var _params_ = Read(args);
            string url = _params_.ContainsKey("url") ? _params_["url"] : $"http://*:{(_params_.ContainsKey("port") ? _params_["port"] : "21021")}";
            return new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls(url)
                .UseStartup<Startup>()
                .UseSerilog()
                .Build();
        }


        public static IDictionary<string, string> Read(string[] args)
        {
            Dictionary<string, string> _params = new Dictionary<string, string>();
            for (var i = 0; i < args.Length; i++)
            {
                var p = args[i];
                if (p.StartsWith("--"))
                {
                    //参数
                    _params.Add(p.Replace("--", ""),
                        ((i < args.Length - 1) && !args[i + 1].StartsWith("--")) ? args[i + 1] : "TRUE");
                }
            }
            return _params;
        }
    }
}

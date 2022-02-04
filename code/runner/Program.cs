using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace kcar.runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            IConfiguration Config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
			

            model.Settings.Load(Config,"myAppSettings");

            var a = model.Settings.Instance;
            
            Log.Information($"config sample field:{a.Sample}");
        }
    }
}
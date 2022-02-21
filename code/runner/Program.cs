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
using kcar.interfaces.Reader;

namespace kcar.runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Verbose()
                .CreateLogger();

            IConfiguration Config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
			

            model.Settings.Load(Config,"myAppSettings");

            
            
            var cReader = new CaledosReader();
            cReader.Initialize(model.Settings.Instance);

            //GPS
            //var res = cReader.ReadActivity("65b98a0a-3aac-42d3-a6b5-000007d06a9a");

            // HR
            var res = cReader.ReadActivity("69ba14ec-99e5-469c-b5da-7cbbec4e1075");

            var a = model.Settings.Instance;
            Log.Information($"config sample field:{a.Sample}");
        }
    }
}
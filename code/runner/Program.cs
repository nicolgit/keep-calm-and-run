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
using kcar.interfaces;

namespace kcar.runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                //.MinimumLevel.Verbose()
                .MinimumLevel.Information()
                .CreateLogger();

            IConfiguration Config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
			

            model.Settings.Load(Config,"myAppSettings");
            
            var cReader = new CaledosReader();
            cReader.Initialize(model.Settings.Instance);

            int current=0;
            IEnumerable<IActivity> activities;

            do
            {
                activities = cReader.ReadActivities (null,null, current, 10);

                Log.Information($"Read {activities.Count()} activities");
                foreach (var activity in activities)
                {
                    Log.Information($">>> {activity.ToShortString()}");
                }
                
                current += activities.Count();

            } while (activities.Count() > 0);
            
            //GPS
            //var res = cReader.ReadActivity("65b98a0a-3aac-42d3-a6b5-000007d06a9a");

            var res = cReader.ReadActivity("69ba14ec-99e5-469c-b5da-7cbbec4e1075");

            Log.Information($"ACTIVITY type:{res.Type}");
            Log.Information($"ACTIVITY provider:{res.Provider}");
            Log.Information($"ACTIVITY providerversion:{res.ProviderVersion}");


            //var a = model.Settings.Instance;
            //Log.Information($"config sample field:{a.Sample}");
        }
    }
}
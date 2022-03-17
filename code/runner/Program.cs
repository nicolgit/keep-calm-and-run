using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.Configuration;
using kcar.interfaces;
using Microsoft.ApplicationInsights.Extensibility;
using kcar.Reader;
using kcar.Writer;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse;

namespace kcar.runner
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IConfiguration Config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
            
            model.Settings.Load(Config,"myAppSettings");

            TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
            configuration.ConnectionString = model.Settings.Instance.ApplicationInsightConnectionString;
            configuration.TelemetryInitializers.Add(new HttpDependenciesParsingTelemetryInitializer());
            configuration.TelemetryInitializers.Add(new OperationCorrelationTelemetryInitializer());
            QuickPulseTelemetryProcessor ?processor = null;

            configuration.TelemetryProcessorChainBuilder
                .Use((next) =>
                {
                    processor = new QuickPulseTelemetryProcessor(next);
                    return processor;
                })
                .Build();

            var QuickPulse = new QuickPulseTelemetryModule();
            QuickPulse.Initialize(configuration);
            QuickPulse.RegisterTelemetryProcessor(processor);


            //var telemetryClient = new TelemetryClient(configuration);
            
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.ApplicationInsights(configuration, TelemetryConverter.Traces)
                //.MinimumLevel.Verbose()
                .MinimumLevel.Information()
                .CreateLogger();
            
            var cReader = new CaledosReader();
            var diskWriter = new DiskWriter();

            await cReader.Initialize(model.Settings.Instance);
            await diskWriter.Initialize(model.Settings.Instance);

            //var res = await cReader.ReadActivity("42AD6013-78F6-4452-BB0A-71BA74C0F6B9");

            int skip=0;
            IEnumerable<IActivity> activities;
            do
            {
                activities = await cReader.ReadActivities (null,null, skip, 20);

                foreach (var activity in activities)
                {
                    Log.Information($">>> {activity.ToShortString()}");

                    var fullActivity = await cReader.ReadActivity(activity.Id);

                    await diskWriter.WriteActivity(fullActivity);

                    await Task.Delay(500);
                }
                
                skip += activities.Count();

            } while (activities.Count() > 0);
            Log.Information($"{skip} activities processed.");

            //GPS
            //var res = cReader.ReadActivity("65b98a0a-3aac-42d3-a6b5-000007d06a9a");

            //var res = cReader.ReadActivity("69ba14ec-99e5-469c-b5da-7cbbec4e1075");

            //var a = model.Settings.Instance;
            //Log.Information($"config sample field:{a.Sample}");
        }

       
    }
}
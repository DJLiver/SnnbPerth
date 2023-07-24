using CollectorService;
using Flurl.Http.Configuration;

using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;

using SnnbDB.Models;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "SNNB Collector Service";
});

//LoggerProviderOptions.RegisterProviderOptions<
//    EventLogSettings, EventLogLoggerProvider>(builder.Services);

//SnnbFoContext sc = new SnnbFoContext();
//List<HSpectralNetGroup> _spectralNetGroups = sc.HSpectralNetGroups.Where(m => m.Enabled).ToList();
//HSystemParam _hSystemParam = sc.HSystemParams.First();

//List<GetRestData> clients = new List<GetRestData>();

//foreach (var item in _spectralNetGroups)
//{
//    var c = new GetRestData( _hSystemParam, item);
//    clients.Add(c);

//}

//foreach (var client in clients)
//{
//    builder.Services.AddSingleton(client);

//}
builder.Services.AddHostedService<Service>();


builder.Services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();


// See: https://github.com/dotnet/runtime/issues/47303
builder.Logging.AddConfiguration(
    builder.Configuration.GetSection("Logging"));

IHost host = builder.Build();
host.Run();
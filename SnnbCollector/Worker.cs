using RestSharp;
using System.Threading;

using SnnbDB.Models;
using System.Text.Json;

namespace SnnbCollector;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    internal Action<object, SnnbCommPack> SNDataEvent;

    private RestClient client;
    private PeriodicTimer? _collectTimer;
    private PeriodicTimer? _cancelTimer;

    private HSystemParam _hSystemParam;
    private List<HSpectralNetGroup> _spectralNetGroups;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        SnnbFoContext sc = new SnnbFoContext();
        _spectralNetGroups = sc.HSpectralNetGroups.Where(m => m.Enabled).ToList();
        _hSystemParam = sc.HSystemParams.First();

        client = new RestClient();


        _collectTimer = new(TimeSpan.FromMilliseconds(_hSystemParam.PollPeriod));
        _cancelTimer = new(TimeSpan.FromMilliseconds(_hSystemParam.Timeout));

        return base.StartAsync(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        return base.StopAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }

    private async Task Collect()
    {

        var TaskList = new List<Task>();

        try
        {
            if (_spectralNetGroups is null)
            {
                return;
            }

            foreach (HSpectralNetGroup item in _spectralNetGroups)
            {
                if (item.Enabled)
                {
                    TaskList.Add(GetSNData(item));
                    //await Task.Run(GetSNData(item));
                    //TaskList.Add(GetHealthData(item));
                }
            }
            Task.WaitAll(TaskList.ToArray());

        }
        catch (Exception ex)
        {
            // ExLog.Log(ex);
        }


    }


    private async Task GetSNData(HSpectralNetGroup specNetGroup)
    {
        RestResponse response = null!;
        SnnbCommPack scp = new SnnbCommPack();

        try
        {
            RestClientOptions rco = new RestClientOptions().;    
            RestRequest restRequest = new RestRequest().
            

            response = await client.ExecuteGetAsync(new RestRequest(_hSystemParam.RestQuery) { Timeout = _hSystemParam.Timeout });

            if (response is not null)
            {
                scp.DateStamp = DateTime.Now;
                    
                scp.SpectralNetGroup = specNetGroup;

                scp.Error = !response.IsSuccessful;
                scp.ErrorText = response.ResponseStatus.ToString() ?? "No description";

                if (response.IsSuccessful)
                {
                    if (response.Content is not null)
                    {
                        try
                        {
                            sNWBRest.restRoot = JsonSerializer.Deserialize<SnRest>(response.Content);
                        }
                        catch (Exception ex)
                        {
                            sNWBRest.Error = true;
                            sNWBRest.ErrorText = ex.Message;
                        }
                    }
                }
                else
                {

                }
                specNetGroup.ProcessRestData(sNWBRest);

            }

        }
        catch (Exception ex)
        {
            ExLog.Log(ex);
        }
    }

}

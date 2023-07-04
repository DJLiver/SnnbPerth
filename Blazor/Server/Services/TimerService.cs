using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RestSharp;
using SnnbDB.ModelExt;
using SnnbDB.Models;
using SnnbDB.Rest;
using SnnbFailover.Server.Hubs;

namespace SnnbFailover.Server.Services;


public class TimerService : BackgroundService, IDisposable
{

    private readonly ILogger<TimerService> _logger;

    private PeriodicTimer _periodicTimer;

    private readonly IHubContext<UpdateHub> _updateHub;


    public TimerService(ILogger<TimerService> logger, IHubContext<UpdateHub> updateHub)
    {
        _logger = logger;
        _updateHub = updateHub;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _periodicTimer = new PeriodicTimer(TimeSpan.FromMilliseconds(5000));

        return base.StartAsync(cancellationToken);
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (_periodicTimer == null)
        {
            return;
        }
        while (await _periodicTimer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
        {
            //await Collect(stoppingToken);
            await GetRestData(stoppingToken);
            _logger.LogInformation(new EventId(15), "Collection completed");
            rtStatus rt = new rtStatus();
            rt.Fill();

            await _updateHub.Clients.All.SendAsync("RT Status", rt);

        }

    }

    private Task SendStatus()
    {
        return Task.CompletedTask;
    }

    private async Task GetRestData(CancellationToken stoppingToken)
    {
        SnnbFoContext sc = new SnnbFoContext();
        List<HSpectralNetGroup> t = sc.HSpectralNetGroups.ToList();
        var TaskList = new List<Task>();

        foreach (HSpectralNetGroup specNetGroup in t)
        {
            if (specNetGroup.Enabled)
            {
                TaskList.Add(GetSNDataAndStoreInDB(specNetGroup));
            }
        }
        Task.WaitAll(TaskList.ToArray());
    }

    private async Task GetSNDataAndStoreInDB(HSpectralNetGroup specNetGroup)
    {
        RestClient client;
        RestResponse response = null!;
        SnnbCommPack scp = new SnnbCommPack();
        scp.SpectralNetGroup = specNetGroup;
        scp.Error = false;
        scp.ErrorText = "";

        try
        {
            client = new RestClient(specNetGroup.PreIpAddress + specNetGroup.IpAddress);
            response = await client.ExecuteGetAsync(new RestRequest(specNetGroup.RestQuery) { Timeout = specNetGroup.Timeout });

            if (response is null) throw new Exception($"Response is NULL: {specNetGroup.UnitId} ");

            if (!response.IsSuccessful) throw new Exception($"Response is not successful: {specNetGroup.UnitId}");

            if (response.Content is null) throw new Exception($"Content is NULL: {specNetGroup.UnitId}");

            RestMain restMain = JsonConvert.DeserializeObject<RestMain>(response.Content);
            scp.RestMain = restMain;


        }
        catch (Exception ex)
        {
            scp.Error = true;
            scp.ErrorText = ex.Message;
        }
        finally
        {
            scp.PopulateDB();
        }
    }

    //private async Task Collect(CancellationToken stoppingToken)
    //{
    //    // SnnbFoContext c = new SnnbFoContext();
    //    SNNBStatus sNNBStatus = new SNNBStatus() { DateTime = DateTime.Now };

    //    SNNBStatusContext c = new SNNBStatusContext();
    //    try
    //    {
    //        sNNBStatus.Site1Status = c.Site1Statuses.ToList();
    //        sNNBStatus.Site2Status = c.Site2Statuses.ToList();
    //        sNNBStatus.SiteAttrLimit = c.SiteAttrLimits.ToList();
    //    }
    //    catch (Exception ex)
    //    {

    //      //  throw;
    //     }

    //    //List<MetricSite1Summary> s1 = c.MetricSite1Summaries.ToList();
    //    //s1.Sort(sort_1);
    //    //List<MetricSite2Summary> s2 = c.MetricSite2Summaries.ToList();
    //    //s2.Sort(sort_2);
    //    //foreach (var item in s1)
    //    //{
    //    //    item.RfoutmeasuredDelay = item.RfoutmeasuredDelay / 1000000;
    //    //    item.RfoutmeasuredNetworkRate = item.RfoutmeasuredNetworkRate / 1000000;
    //    //}
    //    //foreach (var item in s2)
    //    //{
    //    //    item.RfoutmeasuredDelay = item.RfoutmeasuredDelay / 1000000;
    //    //    item.RfoutmeasuredNetworkRate = item.RfoutmeasuredNetworkRate / 1000000;
    //    //}

    //    await _updateHub.Clients.All.SendAsync("UpdateSummary", sNNBStatus);

    //}

    //private int sort_1(MetricSite1Summary x, MetricSite1Summary y)
    //{
    //    if (x.ExtDisplayOrder > y.ExtDisplayOrder)
    //    {
    //        return 1;
    //    }
    //    return -1;
    //}
    //private int sort_2(MetricSite2Summary x, MetricSite2Summary y)
    //{
    //    if (x.ExtDisplayOrder > y.ExtDisplayOrder)
    //    {
    //        return 1;
    //    }
    //    return -1;
    //}
}
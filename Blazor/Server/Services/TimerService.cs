using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RestSharp;
using SnnbDB.ModelExt;
using SnnbDB.Models;
using SnnbDB.Rest;
using SnnbFailover.Server.Hubs;

using System.Diagnostics;
using System.Linq.Dynamic.Core;

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
        SnnbCommPack.CleanDB();

        _periodicTimer = new PeriodicTimer(TimeSpan.FromMilliseconds(5000));

        return base.StartAsync(cancellationToken);
    }

    bool _reEntry = false;
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (_periodicTimer == null)
        {
            return;
        }
        while (await _periodicTimer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
        {

            if (!_reEntry)
            {
                _reEntry = true;
                await GetRestData(stoppingToken);

                RtStatus rt = new();
                rt.Fill();

                await _updateHub.Clients.All.SendAsync("RT Status", rt);

                _reEntry = false;
            }

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
        HSystemParam hSystemParam = sc.HSystemParams.First();

        var TaskList = new List<Task>();

        foreach (HSpectralNetGroup specNetGroup in t)
        {
            if (specNetGroup.Enabled)
            {
                TaskList.Add(GetSNDataAndStoreInDB(specNetGroup,hSystemParam));
            }
        }
        Task.WaitAll(TaskList.ToArray());
    }

    private async Task GetSNDataAndStoreInDB(HSpectralNetGroup specNetGroup, HSystemParam hSystemParam)
    {
        RestClient client;
        RestResponse response = null!;
        SnnbCommPack scp = new SnnbCommPack();
        scp.SpectralNetGroup = specNetGroup;
        scp.Error = false;
        scp.ErrorText = "None";
        Stopwatch _stopwatch = new Stopwatch();

        try
        {
            _stopwatch.Start();
            client = new RestClient(hSystemParam.PreIpAddress + specNetGroup.IpAddress);
            //response = client.Get(new RestRequest(hSystemParam.RestQuery) { Timeout = 300 });
            response = await client.ExecuteGetAsync(new RestRequest(hSystemParam.RestQuery) { Timeout = 3000 });
            _stopwatch.Stop();
            scp.ResponseTime = (int)_stopwatch.ElapsedMilliseconds;
            if (response is null) throw new Exception($"Response is NULL: {specNetGroup.UnitId} ");

            if (!response.IsSuccessful) throw new Exception($"Response is not successful - {specNetGroup.UnitId}:{response.ResponseStatus}");

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
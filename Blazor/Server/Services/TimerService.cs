using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RestSharp;
using SnnbDB.ModelExt;
using SnnbDB.Models;
using SnnbDB.Rest;
using SnnbFailover.Server.Hubs;
using SnnbDB.DataProcessing;
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

    public override Task StopAsync(CancellationToken cancellationToken)
    {

        return base.StopAsync(cancellationToken);
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {

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
            //TODO  Do the client update here
            if (!_reEntry)
            {
                _reEntry = true;

                RtStatus rt = new();
                rt.Fill();

                await _updateHub.Clients.All.SendAsync("RT Status", rt);

                _reEntry = false;
            }

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


using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

using SnnbFailover.Server.Data;
using SnnbFailover.Server.Hubs;
using SnnbFailover.Server.Models.SNNBStatus;
using SnnbFailover.Shared.Models;

namespace SnnbFailover.Server.Services;

//public class JobExecutedEventArgs : EventArgs { }


public class TimerService : BackgroundService, IDisposable
{
    [Inject] SNNBStatusService SNNBStatusService { get; set; }  

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
        _periodicTimer = new PeriodicTimer(TimeSpan.FromMilliseconds(10000));

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
            await Collect(stoppingToken);
            _logger.LogInformation(new EventId(15), "Collection completed");
        }

    }

    private async Task Collect(CancellationToken stoppingToken)
    {
        // SnnbContext c = new SnnbContext();
        SNNBStatus sNNBStatus = new SNNBStatus() { DateTime = DateTime.Now };

        SNNBStatusContext c = new SNNBStatusContext();
        try
        {
            //sNNBStatus.Site1Status = (await SNNBStatusService.GetSite1Statuses()).ToList();

            
            sNNBStatus.Site1Status = c.Site1Statuses.ToList();
            sNNBStatus.Site2Status = c.Site2Statuses.ToList();
            sNNBStatus.SiteAttrLimit = c.SiteAttrLimits.ToList();
        }
        catch (Exception ex)
        {

          //  throw;
         }

        //List<MetricSite1Summary> s1 = c.MetricSite1Summaries.ToList();
        //s1.Sort(sort_1);
        //List<MetricSite2Summary> s2 = c.MetricSite2Summaries.ToList();
        //s2.Sort(sort_2);
        //foreach (var item in s1)
        //{
        //    item.RfoutmeasuredDelay = item.RfoutmeasuredDelay / 1000000;
        //    item.RfoutmeasuredNetworkRate = item.RfoutmeasuredNetworkRate / 1000000;
        //}
        //foreach (var item in s2)
        //{
        //    item.RfoutmeasuredDelay = item.RfoutmeasuredDelay / 1000000;
        //    item.RfoutmeasuredNetworkRate = item.RfoutmeasuredNetworkRate / 1000000;
        //}

        await _updateHub.Clients.All.SendAsync("UpdateSummary", sNNBStatus);

    }

    private int sort_1(MetricSite1Summary x, MetricSite1Summary y)
    {
        if (x.ExtDisplayOrder > y.ExtDisplayOrder)
        {
            return 1;
        }
        return -1;
    }
    private int sort_2(MetricSite2Summary x, MetricSite2Summary y)
    {
        if (x.ExtDisplayOrder > y.ExtDisplayOrder)
        {
            return 1;
        }
        return -1;
    }
}
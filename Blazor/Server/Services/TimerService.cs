using Microsoft.AspNetCore.SignalR;
using SnnbFailover.Server.Hubs;
using SnnbDB.ModelExt;
using SnnbDB.ModelHub;

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

                RtSnapShot rtSnapShot = new RtSnapShot();
                rtSnapShot.Fill();

                RtSpectrum rtSpectrum = new RtSpectrum(false);
                rtSpectrum.FillSpectrum(rtSnapShot);

                RtMainLayout rtMainLayout = RtMainLayout.GetRtLayout(rtSnapShot);

                RtMonitor rtMonitor = RtMonitor.GetRtMonitor(rtSnapShot);

                await _updateHub.Clients.All.SendAsync("RT Monitor", rtMonitor);
                await _updateHub.Clients.All.SendAsync("RT MainLayout", rtMainLayout);
                await _updateHub.Clients.All.SendAsync("RT Spectrum", rtSpectrum);

                _reEntry = false;
            }

        }

    }


}
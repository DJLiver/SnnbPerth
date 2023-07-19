using SnnbDB.DataProcessing;
using SnnbDB.Models;

using SnnbFailover.Server.Services;

namespace CollectorService;

public sealed class Service : BackgroundService
{
    private readonly ILogger<Service> _logger;
    private List<HSpectralNetGroup> targets;
    private HSystemParam hSystemParam;
    private CollectManager cm = null;
    private DatabaseQueue dbq = null;
    //private ErrorQueue eq = null;

    public Service(ILogger<Service> logger)
    {
        _logger = logger;
    }

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            SnnbCommPack.CleanDB();

            cm = new CollectManager();
            dbq = new DatabaseQueue();

            cm.SNDataEvent += dbq.Add;
            //cm.ErrorEvent += dbq.Add;

            dbq.Start();
            cm.Start();

            SnnbFoContext sc = new SnnbFoContext();
            targets = sc.HSpectralNetGroups.ToList();
            hSystemParam = sc.HSystemParams.First();
        }
        catch (Exception)
        {

            throw;
        }        
        
        await base.StartAsync(cancellationToken);
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        if (cm != null)
            cm.Stop();
        if (dbq != null)
            dbq.Stop();
        await base.StopAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                await Task.Delay(TimeSpan.FromMilliseconds(hSystemParam.PollPeriod), stoppingToken);
            }
        }
        catch (TaskCanceledException)
        {
            // When the stopping token is canceled, for example, a call made from services.msc,
            // we shouldn't exit with a non-zero exit code. In other words, this is expected...
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Message}", ex.Message);

            // Terminates this process and returns an exit code to the operating system.
            // This is required to avoid the 'BackgroundServiceExceptionBehavior', which
            // performs one of two scenarios:
            // 1. When set to "Ignore": will do nothing at all, errors cause zombie services.
            // 2. When set to "StopHost": will cleanly stop the host, and log errors.
            //
            // In order for the Windows Service Management system to leverage configured
            // recovery options, we need to terminate the process with a non-zero exit code.
            Environment.Exit(1);
        }
    }
}

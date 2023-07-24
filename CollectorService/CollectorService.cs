using Flurl.Http;
using Flurl.Http.Configuration;

using RestSharp;

using SnnbDB.DataProcessing;
using SnnbDB.Models;

using SnnbFailover.Server.Services;

namespace CollectorService;

public class Service : BackgroundService
{
    private readonly ILogger<Service> _logger;
    private readonly IServiceProvider serviceProvider;
    private List<HSpectralNetGroup> _spectralNetGroups;
    private HSystemParam _hSystemParam;
    private CollectManager cm;
    private DatabaseQueue dbq;
    //private ErrorQueue eq = null;
   //private readonly IFlurlClient _flurlClient;
    private readonly IFlurlClientFactory _flurlClientFac;
 //   private List<GetRestData> _clients;
   // IEnumerable<IHostedService> allHostedServices;
    public Service(ILogger<Service> logger, IFlurlClientFactory flurlClientFac)
    {
        _flurlClientFac = flurlClientFac;
        // _flurlClient =  flurlClientFac.Get("url");
        _logger = logger;
    }
    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            SnnbCommPack.CleanDB();


            SnnbFoContext sc = new SnnbFoContext();
            _spectralNetGroups = sc.HSpectralNetGroups.Where(m => m.Enabled).ToList();
            _hSystemParam = sc.HSystemParams.First();

            cm = new CollectManager(_spectralNetGroups, _hSystemParam, _flurlClientFac);

            dbq = new DatabaseQueue();

            cm.SNDataEvent += dbq.Add;
            //cm.ErrorEvent += dbq.Add;

            dbq.Start();
            cm.Start();

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

                await Task.Delay(TimeSpan.FromMilliseconds(_hSystemParam.PollPeriod), stoppingToken);
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
    

    //public override async Task StartAsync(CancellationToken cancellationToken)
    //{
    //    try
    //    {
    //        allHostedServices = serviceProvider.GetServices<GetRestData>();
    //       //SnnbCommPack.CleanDB();


    //        //SnnbFoContext sc = new SnnbFoContext();
    //        //_spectralNetGroups = sc.HSpectralNetGroups.Where(m => m.Enabled).ToList();
    //        //_hSystemParam = sc.HSystemParams.First();

    //        //_clients = new List<GetRestData>();
    //        //foreach (var item in _spectralNetGroups)
    //        //{
    //        //    var c = new GetRestData(_hSystemParam, item );

    //        //    _clients.Add(c);

    //        //}

    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }        

    //    await base.StartAsync(cancellationToken);
    //}

    //public override async Task StopAsync(CancellationToken cancellationToken)
    //{

    //    await base.StopAsync(cancellationToken);
    //}

    //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    //{
    //    try
    //    {
    //        while (!stoppingToken.IsCancellationRequested)
    //        {
    //            foreach (var item in allHostedServices)
    //            {
    //                //item.
    //            } 
    //            // await PerformTasks();
    //            await Task.Delay(TimeSpan.FromMilliseconds(2000), stoppingToken);
    //        }
    //    }
    //    catch (TaskCanceledException)
    //    {
    //        // When the stopping token is canceled, for example, a call made from services.msc,
    //        // we shouldn't exit with a non-zero exit code. In other words, this is expected...
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "{Message}", ex.Message);

    //        // Terminates this process and returns an exit code to the operating system.
    //        // This is required to avoid the 'BackgroundServiceExceptionBehavior', which
    //        // performs one of two scenarios:
    //        // 1. When set to "Ignore": will do nothing at all, errors cause zombie services.
    //        // 2. When set to "StopHost": will cleanly stop the host, and log errors.
    //        //
    //        // In order for the Windows Service Management system to leverage configured
    //        // recovery options, we need to terminate the process with a non-zero exit code.
    //        Environment.Exit(1);
    //    }
    //}

    //private Task PerformTasks()
    //{
    //    var TaskList = new List<Task>();

    //    foreach (var group in _spectralNetGroups)
    //    {

    //    }
    //    return Task.CompletedTask;

    //}








}
//public class GetRestData: BackgroundService
//{

//    // flurlClient = flurlClientFac.Get(hSystemParam.PreIpAddress + spectralNetGroup.IpAddress);
//    private IFlurlClient flurlClient;
//    private HSystemParam hSystemParam;
//    private HSpectralNetGroup spectralNetGroup;

//    public GetRestData( HSystemParam hSystemParam, HSpectralNetGroup item)
//    {
//        this.hSystemParam = hSystemParam;
//        this.spectralNetGroup = item;
//    }

//    public override Task StartAsync(CancellationToken cancellationToken)
//    {
//        return base.StartAsync(cancellationToken);
//    }

//    public override Task StopAsync(CancellationToken cancellationToken)
//    {
//        return base.StopAsync(cancellationToken);
//    }

//    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//    {
//        try
//        {
//            while (!stoppingToken.IsCancellationRequested)
//            {
//                Console.WriteLine("yyy");
//                await Task.Delay(TimeSpan.FromMilliseconds(hSystemParam.PollPeriod), stoppingToken);
//            }
//        }
//        catch (TaskCanceledException)
//        {
//        }
//        catch (Exception ex)
//        {
//            Environment.Exit(1);
//        }
//    }
//}
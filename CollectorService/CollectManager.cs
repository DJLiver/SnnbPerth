using Common;

using Flurl.Http.Configuration;

using SnnbDB.Models;

namespace SnnbFailover.Server.Services;

class CollectManager : iStartStop
{
    internal Action<object, SnnbCommPack> SNDataEvent;
    //internal Action<object, HLog> ErrorEvent;
    private readonly List<CollectTimer> collectTimers = new List<CollectTimer>();
    private HSystemParam hSystemParam;
    private List<HSpectralNetGroup> spectralNetGroups;
    private IFlurlClientFactory _flurlClientFac;
    public CollectManager()
    {
    }

    public CollectManager(List<HSpectralNetGroup> spectralNetGroups, HSystemParam hSystemParam, IFlurlClientFactory flurlClientFac)
    {
        this.spectralNetGroups = spectralNetGroups;
        this.hSystemParam = hSystemParam;
        _flurlClientFac = flurlClientFac;   
    }

    public void Start()
    {
        foreach (var unit in spectralNetGroups)
        {
            CollectTimer collectTimer = new CollectTimer(unit, hSystemParam, _flurlClientFac);
            collectTimer.SNDataEvent += SNDataEvent;
            //collectTimer.ErrorEvent += ErrorEvent;
            collectTimers.Add(collectTimer);
        }
        foreach (var t in collectTimers)
        {
            t.Start();
        }
    }

    public void Stop()
    {
        foreach (var t in collectTimers)
        {
            t.Stop();
        }
    }
}

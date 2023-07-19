using Common;

using SnnbDB.Models;

namespace SnnbFailover.Server.Services;

class CollectManager : iStartStop
{
    internal Action<object, SnnbCommPack> SNDataEvent;
    //internal Action<object, HLog> ErrorEvent;
    private readonly List<CollectTimer> collectTimers = new List<CollectTimer>();
    private List<HSpectralNetGroup> targets;
    private HSystemParam hSystemParam;
    public CollectManager()
    {
        //this.targets = targets;
    }

    public void Start()
    {
        SnnbFoContext sc = new SnnbFoContext();
        targets = sc.HSpectralNetGroups.ToList();
        hSystemParam = sc.HSystemParams.First();


        foreach (var unit in targets)
        {
            CollectTimer collectTimer = new CollectTimer
            {
                target = unit,
                hSystemParam = hSystemParam
            };
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

using Common;

using SnnbDB.Models;

namespace SnnbFailover.Server.Services;

class CollectManager : iStartStop
{
    //internal Action<object, SNdata> SNDataEvent;
    //internal Action<object, ErrorData> ErrorEvent;
    private readonly List<CollectTimer> collectTimers = new List<CollectTimer>();
    private readonly List<HSpectralNetGroup> targets;

    public CollectManager(List<HSpectralNetGroup> targets)
    {
        this.targets = targets;
    }

    public void Start()
    {
        foreach (var unit in targets)
        {
            CollectTimer collectTimer = new CollectTimer
            {
                target = unit,
            };
            //collectTimer.SNDataEvent += SNDataEvent;
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

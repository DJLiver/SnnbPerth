using Common;

using SnnbDB.Models;

namespace SnnbDB.DataProcessing;

class MonitorQueue : QueueThread<SnnbCommPack>
{
    List<Target> targets = null;
    Dictionary<string, MonitorData> databank;


    public MonitorQueue(List<Target> targets)
    {
        this.targets = targets;
    }

    #region IStartStop Members

    public new void Start()
    {
        // Create dictionary entry for each unit
        databank = new Dictionary<string, MonitorData>(targets.Count);

        foreach (var item in targets)
        {
            databank.Add(item.Name, new MonitorData());
        }

        base.Start(); 
    }


    public new void Stop()
    {
        base.Stop();
    }
    #endregion

    public override void processItem(SnnbCommPack t)
    {
        MonitorData monitorData = databank[t.Name];
        monitorData.ProcessNewData(t);
        base.Next();
    }
}

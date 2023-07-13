using Common;

using SnnbDB.Models;

namespace SnnbDB.DataProcessing;

public class DatabaseQueue : QueueThread<SnnbCommPack>
{
    private List<HSpectralNetGroup> targets = null;
   // Dictionary<string, MonitorData> databank;


    public DatabaseQueue()
    {
    }

    #region IStartStop Members

    public new void Start()
    {
        SnnbFoContext sc = new SnnbFoContext();
        targets = sc.HSpectralNetGroups.ToList();
        base.Start();
        // Create dictionary entry for each unit
        //databank = new Dictionary<string, MonitorData>(targets.Count);

        //foreach (var item in targets)
        //{
        //    databank.Add(item.Name, new MonitorData());
        //}

        //base.Start(); 
    }


    public new void Stop()
    {
        base.Stop();
    }
    #endregion

    public override void processItem(SnnbCommPack t)
    {
        //MonitorData monitorData = databank[t.Name];
        //monitorData.ProcessNewData(t);
        t.PopulateDB();
        Next();
    }
}

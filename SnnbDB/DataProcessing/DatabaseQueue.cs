using Common;

using SnnbDB.Models;

namespace SnnbDB.DataProcessing;

public class DatabaseQueue : QueueThread<SnnbCommPack>
{
    public DatabaseQueue()
    {
    }

    #region IStartStop Members

    //public new void Start()
    //{
    //    base.Start();
    //}


    //public new void Stop()
    //{
    //    base.Stop();
    //}
    #endregion

    public override void processItem(SnnbCommPack scp)
    {
        scp.PopulateDB();
        base.Next();
    }
}

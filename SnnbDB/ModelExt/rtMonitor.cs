using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnnbDB.ModelExt;
public class RtMonitor
{
    public int UnitId { get; set; }
    public string UnitName { get; set; }
    public string RemoteUnit { get; set; }
    public string PeerUnit { get; set; }
    public string CommsOk { get; set; }
    public string CommMessage { get; set; }
    public string MeasuredDelay { get; set; } // In RfOutputStream
    public string MeasuredNetworkRate { get; set; } // In RfOutputStream
    public string TenMhzLocked { get; set; } // In Module
    public string OnePpsPresent { get; set; } // In Module
    public string StreamEnable { get; set; } //In RfInputStream
    public string RfOutputEnable { get; set; } // In Module RfOutputEnable
    public int DisplayOrder { get; set; }
}

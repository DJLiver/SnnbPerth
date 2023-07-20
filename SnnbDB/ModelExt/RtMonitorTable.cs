using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnnbDB.ModelExt;
public class RtMonitorTable
{
    public string DateTimeStamp { get; set; }
    public bool DateTimeStampAlert { get; set; } = false;
    public int UnitId { get; set; }
    public string UnitName { get; set; }
    public string RemoteUnit { get; set; }
    public string PeerUnit { get; set; }
    public string CommsOk { get; set; }
    public bool CommsOkAlert  { get; set; }
    public string CommMessage { get; set; }
    public string MeasuredDelay { get; set; } // In RfOutputStream
    public bool MeasuredDelayAlert { get; set; } // In RfOutputStream
    public string MeasuredNetworkRate { get; set; } // In RfOutputStream
    public bool MeasuredNetworkRateAlert { get; set; } // In RfOutputStream
    public string TenMhzLocked { get; set; } // In Module
    public bool TenMhzLockedAlert { get; set; } // In Module
    public string OnePpsPresent { get; set; } // In Module
    public bool OnePpsPresentAlert { get; set; } // In Module
    public string StreamEnable { get; set; } //In RfInputStream
    public bool StreamEnableAlert { get; set; } //In RfInputStream
    public string RfOutputEnable { get; set; } // In Module RfOutputEnable
    public bool RfOutputEnableAlert { get; set; } // In Module RfOutputEnable
    public int DisplayOrder { get; set; }

}

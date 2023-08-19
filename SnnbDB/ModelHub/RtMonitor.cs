using SnnbDB.Models;

namespace SnnbDB.ModelExt;

public class RtMonitor
{
    #region Properties
    public List<RtMonitorTable> monitorTable201 { get; set; }
    public List<RtMonitorTable> monitorTable202 { get; set; }
    public List<RtMonitorTable> monitorTable203 { get; set; }
    public List<RtMonitorTable> monitorTable204 { get; set; }
    #endregion

    public static RtMonitor GetRtMonitor(RtSnapShot rtSnapShot)
    {
        RtMonitor rtMonitor = new RtMonitor(); 
        rtMonitor.monitorTable201 = GetRtMonitorByGroup(201, rtSnapShot);
        rtMonitor.monitorTable202 = GetRtMonitorByGroup(202, rtSnapShot);
        rtMonitor.monitorTable203 = GetRtMonitorByGroup(203, rtSnapShot);
        rtMonitor.monitorTable204 = GetRtMonitorByGroup(204, rtSnapShot);
        return rtMonitor;
    }
    public static List<RtMonitorTable> GetRtMonitorByGroup(int groupId, RtSnapShot rtSnapShot)
    {
        List<RtMonitorTable> rtMonitors = new List<RtMonitorTable>();

        foreach (MSpectralNetGroup sng in rtSnapShot.SpecNetGroups)
        {
            if (sng.GroupId == groupId)
            {
                var r = new RtMonitorTable();

                r.UnitId = sng.UnitId;
                r.UnitName = sng.UnitName;
                r.RemoteUnit = sng.RemoteUnit;
                r.PeerUnit = sng.PeerUnit;
                r.CommMessage = sng.ErrorText;
                r.CommsOk = (!sng.Error).ToString();
                r.CommsOkAlert = sng.Error;
                r.DisplayOrder = sng.DisplayOrder;

                r.DateTimeStamp = sng.DateStamp.ToString("ddMMMyy HH:mm:ss");
                double TimeDiff = (sng.DateStamp - rtSnapShot.DateTimeStamp).TotalSeconds;
                r.DateTimeStampAlert = (Math.Abs(TimeDiff) > 10.0);
                r.NetworkPath = sng.NetworkPath;
                rtMonitors.Add(r);

            }
        }
        foreach (RtMonitorTable rm in rtMonitors)
        {
            FillData(rm, rtSnapShot);
        }
        rtMonitors.Sort(delegate (RtMonitorTable x, RtMonitorTable y)
        {
            if (x.DisplayOrder > y.DisplayOrder)
                return 1;
            else if (x.DisplayOrder < y.DisplayOrder)
                return -1;
            else
                return 0;
        });
        return rtMonitors;
    }
    private static void FillData(RtMonitorTable rm, RtSnapShot rtSnapShot)
    {
        if (rm.CommsOkAlert)
        {
            rm.MeasuredDelay = "NA";
            rm.MeasuredDelayAlert = true;
            rm.MeasuredNetworkRate = "NA";
            rm.MeasuredNetworkRateAlert = true;
            rm.StreamEnable = "NA";
            rm.StreamEnableAlert = true;
            rm.RfOutputEnable = "NA";
            rm.RfOutputEnableAlert = true;
            rm.TenMhzLocked = "NA";
            rm.TenMhzLockedAlert = true;
            rm.OnePpsPresent = "NA";
            rm.OnePpsPresentAlert = true;
        }
        else
        {
            decimal v = (from s in rtSnapShot.RfOutputStreams
                         where s.UnitId == rm.UnitId
                         select s.MeasuredDelay).Single();

            rm.MeasuredDelay = (v / 1000000).ToString((v > 100000000) ? "N0" : "N2") + "ms";

            rm.MeasuredDelayAlert = (v > 2100000) ? true : false;

            v = (from s in rtSnapShot.RfOutputStreams
                 where s.UnitId == rm.UnitId
                 select s.MeasuredNetworkRate).Single();
            rm.MeasuredNetworkRate = (v / 1000000).ToString("N0") + "Mbps";
            rm.MeasuredNetworkRateAlert = (v > 555000000) ? true : false;

            bool b = (from s in rtSnapShot.RfInputStreams
                      where s.UnitId == rm.UnitId
                      select s.StreamEnable).Single();
            rm.StreamEnable = b.ToString();
            rm.StreamEnableAlert = !b;

            b = (from s in rtSnapShot.Modules
                 where s.UnitId == rm.UnitId
                 select s.RfOutputEnable).Single();
            rm.RfOutputEnable = b.ToString();
            rm.RfOutputEnableAlert = !b;

            b = (from s in rtSnapShot.Modules
                 where s.UnitId == rm.UnitId
                 select s.TenMhzLocked).Single();
            rm.TenMhzLocked = b.ToString();
            rm.TenMhzLockedAlert = !b;

            b = (from s in rtSnapShot.Modules
                 where s.UnitId == rm.UnitId
                 select s.OnePpsPresent).Single();
            rm.OnePpsPresent = b.ToString();
            rm.OnePpsPresentAlert = !b;
        }
    }

} 

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using SnnbDB.Models;
using SnnbDB.Rest;

namespace SnnbDB.ModelExt;
public class RtStatus
{
    public DateTime DateTimeStamp { get; set; } = DateTime.Now;
    public List<MSpectralNetGroup> SpecNetGroups { get; set; }
    public List<MModule> Modules { get; set; }
    public List<MInputRfSpectrum> InputRfSpectrums { get; set; }
    public List<MOutputRfSpectrum> OutputRfSpectrums { get; set; }
    public List<MRfInputStream> RfInputStreams { get; set; }
    public List<MRfOutputStream> RfOutputStreams { get; set; }
    public List<MAvailableStream> AvailableStreams { get; set; }


    public List<RtMonitorTable> GetRtMonitor(string NetworkPath)
    {
        List<RtMonitorTable> rtMonitors = new List<RtMonitorTable>();

        foreach (MSpectralNetGroup sng in SpecNetGroups)
        {
            if (sng.NetworkPath == NetworkPath)
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
                double TimeDiff = (sng.DateStamp - DateTimeStamp).TotalSeconds;
                r.DateTimeStampAlert = (Math.Abs(TimeDiff) > 10.0);

                rtMonitors.Add(r);

            }        
        }

        foreach (RtMonitorTable rm in rtMonitors)
        {
            FormatData(rm);
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

    private void FormatData(RtMonitorTable rm)
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
            decimal v = (from s in RfOutputStreams
                         where s.UnitId == rm.UnitId
                         select s.MeasuredDelay).Single();

            rm.MeasuredDelay = (v / 1000000).ToString((v > 100000000) ? "N0" : "N2") + "ms";

            rm.MeasuredDelayAlert = (v > 2100000)? true : false;

            v = (from s in RfOutputStreams
                      where s.UnitId == rm.UnitId
                      select s.MeasuredNetworkRate).Single();
            rm.MeasuredNetworkRate = (v / 1000000).ToString("N0") + "Mbps";
            rm.MeasuredNetworkRateAlert = (v > 555000000)? true : false;

            bool b = (from s in RfInputStreams
                      where s.UnitId == rm.UnitId
                      select s.StreamEnable).Single();
            rm.StreamEnable = b.ToString();
            rm.StreamEnableAlert = !b;

            b = (from s in Modules
                 where s.UnitId == rm.UnitId
                 select s.RfOutputEnable).Single();
            rm.RfOutputEnable = b.ToString();
            rm.RfOutputEnableAlert = !b; 

            b = (from s in Modules
                 where s.UnitId == rm.UnitId
                 select s.TenMhzLocked).Single();
            rm.TenMhzLocked = b.ToString();
            rm.TenMhzLockedAlert = !b;

            b = (from s in Modules
                 where s.UnitId == rm.UnitId
                 select s.OnePpsPresent).Single();
            rm.OnePpsPresent = b.ToString();
            rm.OnePpsPresentAlert = !b;
        }
    }

    public void Fill()
    {
        using SnnbFoContext c = new SnnbFoContext();

        try
        {
            SpecNetGroups = c.MSpectralNetGroups.ToList();
            Modules = c.MModules.ToList();
            InputRfSpectrums = c.MInputRfSpectrums.ToList();
            OutputRfSpectrums = c.MOutputRfSpectrums.ToList();
            RfInputStreams = c.MRfInputStreams.ToList();
            RfOutputStreams = c.MRfOutputStreams.ToList();
            AvailableStreams = c.MAvailableStreams.ToList();

           // c.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

}

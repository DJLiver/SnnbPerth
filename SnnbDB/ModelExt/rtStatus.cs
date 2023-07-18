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
    public DateTime DateTime { get; set; } = DateTime.Now;
    public List<MSpectralNetGroup> SpecNetGroups { get; set; }
    public List<MModule> Modules { get; set; }
    public List<MInputRfSpectrum> InputRfSpectrums { get; set; }
    public List<MOutputRfSpectrum> OutputRfSpectrums { get; set; }
    public List<MRfInputStream> RfInputStreams { get; set; }
    public List<MRfOutputStream> RfOutputStreams { get; set; }
    public List<MAvailableStream> AvailableStreams { get; set; }


    public List<RtMonitorTable> GetRtMonitor()
    {
        List<RtMonitorTable> rtMonitors = new List<RtMonitorTable>();

        foreach (MSpectralNetGroup sng in SpecNetGroups)
        {
            rtMonitors.Add(new RtMonitorTable()
            {
                DateTimeStamp = sng.DateStamp.ToString("ddMMMyy HH:mm:ss"),
                UnitId = sng.UnitId,
                UnitName = sng.UnitName,
                RemoteUnit = sng.RemoteUnit,
                PeerUnit = sng.PeerUnit,
                CommMessage = sng.ErrorText,
                CommsOk = (!sng.Error).ToString(),
                DisplayOrder = sng.DisplayOrder
            });

        }

        foreach (RtMonitorTable rm in rtMonitors)
        {
            if(rm.CommsOk == "True")
            {
                decimal v = (from s in RfOutputStreams
                                    where s.UnitId == rm.UnitId
                                    select s.MeasuredDelay).Single();
                rm.MeasuredDelay = (v/1000000).ToString("N2") + "ms";

                var v2 = (from s in RfOutputStreams
                                    where s.UnitId == rm.UnitId
                                    select s.MeasuredNetworkRate).Single();
                rm.MeasuredNetworkRate = (v2/1000000).ToString("N0") + "Mbps";

                rm.StreamEnable = (from s in RfInputStreams
                                   where s.UnitId == rm.UnitId
                                   select s.StreamEnable).Single().ToString();

                rm.RfOutputEnable = (from s in Modules
                                   where s.UnitId == rm.UnitId
                                   select s.RfOutputEnable).Single().ToString();
                rm.TenMhzLocked = (from s in Modules
                                   where s.UnitId == rm.UnitId
                                   select s.TenMhzLocked).Single().ToString();
                rm.OnePpsPresent = (from s in Modules
                                   where s.UnitId == rm.UnitId
                                   select s.OnePpsPresent).Single().ToString();
            }
            else
            {
                rm.MeasuredDelay = "NA";
                rm.MeasuredNetworkRate = "NA";
                rm.StreamEnable = "NA";
                rm.RfOutputEnable = "NA";
                rm.TenMhzLocked = "NA";
                rm.OnePpsPresent = "NA";
            }
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
    //public int SortBy(int name1, int name2)
    //{

    //    return name1.CompareTo(name2);
    //}

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

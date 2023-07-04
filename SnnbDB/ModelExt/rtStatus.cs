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
public class rtStatus
{
    public DateTime DateTime { get; set; } = DateTime.Now;
    public List<MSpectralNetGroup> SpecNetGroups { get; set; }
    public List<MModule> Modules { get; set; }
    public List<MInputRfSpectrum> InputRfSpectrums { get; set; }
    public List<MOutputRfSpectrum> OutputRfSpectrums { get; set; }
    public List<MRfInputStream> RfInputStreams { get; set; }
    public List<MRfOutputStream> RfOutputStreams { get; set; }
    public List<MAvailableStream> AvailableStreams { get; set; }


    public List<RtMonitor> GetRtMonitor()
    {
        List<RtMonitor> rtMonitors = new List<RtMonitor>();

        foreach (MSpectralNetGroup sng in SpecNetGroups)
        {
            rtMonitors.Add(new RtMonitor()
            {
                UnitId = sng.UnitId,
                UnitName = sng.UnitName,
                RemoteUnit = sng.RemoteUnit,
                PeerUnit = sng.PeerUnit,
                CommMessage = sng.ErrorText,
                CommsOk = sng.Error
            });

        }
        foreach (RtMonitor rm in rtMonitors)
        {
            var v = (from s in RfOutputStreams
                                where s.UnitId == rm.UnitId
                                select s.MeasuredDelay).Single();
            rm.MeasuredDelay = Decimal.ToUInt32(v);

            var v2 = (from s in RfOutputStreams
                                where s.UnitId == rm.UnitId
                                select s.MeasuredNetworkRate).Single();
            rm.MeasuredNetworkRate = Decimal.ToUInt32(v);

            rm.StreamEnable = (from s in RfInputStreams
                               where s.UnitId == rm.UnitId
                               select s.StreamEnable).Single();

            rm.RfOutputEnable = (from s in Modules
                               where s.UnitId == rm.UnitId
                               select s.RfOutputEnable).Single();
        }


        return rtMonitors;
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

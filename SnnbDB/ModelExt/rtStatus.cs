using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    public List<MInputRfSpectrum> InputRfSpectrum { get; set; }
    public List<MOutputRfSpectrum> OutputRfSpectrum { get; set; }
    public List<MRfInputStream> RfInputStream { get; set; }
    public List<MRfOutputStream> MRfOutputStream { get; set; }
    public List<MAvailableStream> AvailableStream { get; set; }


    public void Fill()
    {
        using SnnbFoContext c = new SnnbFoContext();

        try
        {
            SpecNetGroups = c.MSpectralNetGroups.ToList();
            Modules = c.MModules.ToList();
            InputRfSpectrum = c.MInputRfSpectrums.ToList();
            OutputRfSpectrum = c.MOutputRfSpectrums.ToList();
            RfInputStream = c.MRfInputStreams.ToList();
            MRfOutputStream = c.MRfOutputStreams.ToList();
            AvailableStream = c.MAvailableStreams.ToList();

           // c.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }
}

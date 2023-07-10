using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SnnbDB.Rest;

namespace SnnbDB.Models;
public class SnnbCommPack
{
    public bool Error { get; set; } = false;
    public string ErrorText { get; set; } = string.Empty;
    public HSpectralNetGroup SpectralNetGroup { get; set; }
    public RestMain RestMain { get; set; } = null!;
    public int UnitId
    {
        get
        {
            return SpectralNetGroup.UnitId;
        }
    }
    public int ResponseTime { get; set; }

    public static void CleanDB()
    {
        using (SnnbFoContext context = new SnnbFoContext())
        {
            context.MSpectralNetGroups.ExecuteDelete();

            context.MAvailableStreams.ExecuteDelete();
            context.MControlNics.ExecuteDelete();
            context.MDataNics.ExecuteDelete();
            context.MDependencies.ExecuteDelete();
            context.MModules.ExecuteDelete();
            context.MMulticastGroupSubscriptions.ExecuteDelete();
            context.MRfInputStreams.ExecuteDelete();
            context.MRfInputStreams.ExecuteDelete();
            context.MRoutes.ExecuteDelete();
            context.MInputRfSpectrums.ExecuteDelete();
            context.MInputRfPort1Spectrums.ExecuteDelete();
            context.MInputRfPort2Spectrums.ExecuteDelete();
            context.MOutputRfSpectrums.ExecuteDelete();
            context.MOutputRfPort1Spectrums.ExecuteDelete();
            context.MOutputRfPort2Spectrums.ExecuteDelete();

        }

    }

    public void PopulateDB()
    {
        new MSpectralNetGroup().SaveRestToDB(this);
        if (!Error)
        {
            Parallel.Invoke(
            () => { new MAvailableStream().SaveRestToDB(this); },
                () => { new MControlNic().SaveRestToDB(this); },
                () => { new MDataNic().SaveRestToDB(this); },
                () => { new MDependency().SaveRestToDB(this); },
                () => { new MModule().SaveRestToDB(this); },
                () => { new MMulticastGroupSubscription().SaveRestToDB(this); },
                () => { new MRfOutputStream().SaveRestToDB(this); },
                () => { new MRfInputStream().SaveRestToDB(this); },
                () => { new MRoute().SaveRestToDB(this); },
                () => { new MInputRfSpectrum().SaveRestToDB(this); },
                () => { new MInputRfPort1Spectrum().SaveRestToDB(this); },
                () => { new MInputRfPort2Spectrum().SaveRestToDB(this); },
                () => { new MOutputRfSpectrum().SaveRestToDB(this); },
                () => { new MOutputRfPort1Spectrum().SaveRestToDB(this); },
                () => { new MOutputRfPort2Spectrum().SaveRestToDB(this); });

        }
    }
}

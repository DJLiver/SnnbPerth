using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SnnbDB.Models;
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

    public static void CleanDB()
    {
        using (SnnbFoContext context = new SnnbFoContext())
        {
            context.MRfInputStreams.ExecuteDelete();

        }

    }

    public void PopulateDB()
    {
        new MSpectralNetGroup().SaveRestToDB(this);
        if (!Error)
        {
            new MAvailableStream().SaveRestToDB(this);
            new MControlNic().SaveRestToDB(this);
            new MDataNic().SaveRestToDB(this);
            new MDependency().SaveRestToDB(this);
            new MModule().SaveRestToDB(this);
            new MMulticastGroupSubscription().SaveRestToDB(this);
            new MRfOutputStream().SaveRestToDB(this);
            new MRfInputStream().SaveRestToDB(this);
            new MRoute().SaveRestToDB(this);
            new MSpectrum().SaveRestToDB(this);

        }
    }
}

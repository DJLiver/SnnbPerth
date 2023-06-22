using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SnnbDB.Models;
using SnnbDB.Rest;

namespace SnnbDB.Models;
public class SnnbCommPack
{
    public bool Error { get; set; } = false;
    public string ErrorText { get; set; } = string.Empty;
    public HSpecNetGroup specNetGroup { get; set; }
    public RestMain restRoot { get; set; } = null!;
    public int UnitId
    {
        get
        {
            return specNetGroup.UnitId;
        }
    }

    public static void CleanDB()
    {
        using (SnnbFoContext context = new SnnbFoContext())
        {
            //context.SnAvailableStreams.ExecuteDelete();
            //context.SnContextFreeStreams.ExecuteDelete();
            //context.SnDataNics.ExecuteDelete();
            //context.SnDependancies.ExecuteDelete();
            //context.SnEthernetStats.ExecuteDelete();
            //context.SnModules.ExecuteDelete();
            //context.SnRfCards.ExecuteDelete();
            //context.SnRfInputStreams.ExecuteDelete();
            //context.SnRfOutputStreams.ExecuteDelete();
            //context.SnRoutes.ExecuteDelete();
            //context.SnStreamAssignments.ExecuteDelete();

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Extensions;

using ExceptionLog;

using SnnbDB.Rest;

namespace SnnbDB.Models;
public partial class MMulticastGroupSubscription
{
    #region Ctor
    public MMulticastGroupSubscription()
    {

    }

    //public MModule(SnnbCommPack snnbCommPack)
    //{
    //    UpdateSelf(snnbCommPack);

    //}
    #endregion

    public void SaveRestToDB(SnnbCommPack snnbCommPack)
    {
        this.UnitId = snnbCommPack.SpectralNetGroup.UnitId;

        List<RestString> deps = snnbCommPack.RestMain.multicastGroupSubscriptions.array;

        SaveRestToDB(deps, snnbCommPack);
    }

    private void SaveRestToDB(List<RestString> deps, SnnbCommPack snnbCommPack)
    {
        using SnnbFoContext c = new SnnbFoContext();

        try
        {
            List<MMulticastGroupSubscription>? v = (from f in c.MMulticastGroupSubscriptions
                                 where f.UnitId == snnbCommPack.SpectralNetGroup.UnitId
                                 select f).ToList();

            v.Clear();
            foreach (var item in deps)
            {
                v.Add(new MMulticastGroupSubscription() { UnitId = snnbCommPack.SpectralNetGroup.UnitId, McastAddr = item.value });
            }
            c.SaveChanges();
        }
        catch (Exception ex)
        {
            ExLog.Log(ex);
            return;
        }
    }
}

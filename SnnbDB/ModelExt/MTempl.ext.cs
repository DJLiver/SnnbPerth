using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Extensions;

using ExceptionLog;

using SnnbDB.Rest;

namespace SnnbDB.Models;
public partial class MTempl
{
    #region Ctor
    public MTempl()
    {

    }

    //public MModule(SnnbCommPack snnbCommPack)
    //{
    //    UpdateSelf(snnbCommPack);

    //}
    #endregion
    private void UpdateSelf(SnnbCommPack snnbCommPack)
    {
        //this.UnitId = snnbCommPack.SpectralNetGroup.UnitId;
        //RestMain restMain = snnbCommPack.RestMain;
        ///* Excel lines below */

    }

    public void SaveRestToDB(SnnbCommPack snnbCommPack)
    {
        //using SnnbFoContext c = new SnnbFoContext();

        //try
        //{
        //    List<MModule>? v = (from f in c.MModules
        //             where f.UnitId == snnbCommPack.SpectralNetGroup.UnitId
        //             select f).ToList();
        //    MModule rm;
        //    switch (v.Count)
        //    {
        //        case 0:
        //            this.UpdateSelf(snnbCommPack);
        //            c.MModules.Add(this);
        //            break;
        //        case 1:
        //            rm = v[0];
        //            rm.UpdateSelf(snnbCommPack);
        //            break;
        //        default:
        //            for (int i = 1; i < v.Count; i++)
        //            {
        //                rm = v[i];
        //                c.MModules.Remove(rm);
        //            }
        //            rm = v[0];
        //            rm.UpdateSelf(snnbCommPack);
        //            break;
        //    }

        //    c.SaveChanges();
        //}
        //catch (Exception ex)
        //{
        //    ExLog.Log(ex);
        //    return;
        //}
    }
}

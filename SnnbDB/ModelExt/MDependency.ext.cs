using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Extensions;

using ExceptionLog;

using SnnbDB.Rest;

namespace SnnbDB.Models;
public partial class MDependency
{
    #region Ctor
    public MDependency()
    {

    }

    //public MModule(SnnbCommPack snnbCommPack)
    //{
    //    UpdateSelf(snnbCommPack);

    //}
    #endregion

    public void SaveRestToDB(SnnbCommPack snnbCommPack)
    {
        try
        {
            this.UnitId = snnbCommPack.SpectralNetGroup.UnitId;

            List<RestString> deps = snnbCommPack.RestMain.dependencies.array;

            SaveRestToDB(deps, snnbCommPack);

        }
        catch (Exception ex)
        {
            ExLog.Log(ex);
            return;
        }
    }

    private void SaveRestToDB(List<RestString> deps, SnnbCommPack snnbCommPack)
    {
        using SnnbFoContext c = new SnnbFoContext();

        try
        {
            List<MDependency>? v = (from f in c.MDependencies
                                 where f.UnitId == snnbCommPack.SpectralNetGroup.UnitId
                                 select f).ToList();

            c.MDependencies.RemoveRange(v);
            //foreach (var item in v)
            //{
            //}
            foreach (var item in deps)
            {
                c.MDependencies.Add(new MDependency() { UnitId = snnbCommPack.SpectralNetGroup.UnitId, Dependant = item.value });
            }
            c.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }
}

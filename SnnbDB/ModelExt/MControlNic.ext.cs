using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Extensions;

using ExceptionLog;

using SnnbDB.Rest;

namespace SnnbDB.Models;
public partial class MControlNic
{
    #region Ctor
    public MControlNic()
    {

    }

    private void UpdateSelf(IP4Config ipc)
    {
        //List<ArrayRfOutputStream> restMain = snnbCommPack.RestMain.rfOutputStream.array.ToList();
        ///* Excel lines below */
        this.Addresses = ipc.addresses.value.Truncate( 128);
        this.Address = ipc.address.value.Truncate(128);
        this.Netmask = ipc.netmask.value;

    }

    #endregion

    public void SaveRestToDB(SnnbCommPack snnbCommPack)
    {
        this.UnitId = snnbCommPack.SpectralNetGroup.UnitId;

        IP4Config ipc = snnbCommPack.RestMain.controlNic.structure;

        SaveRestToDB(ipc, snnbCommPack);
    }

    private void SaveRestToDB(IP4Config ipc, SnnbCommPack snnbCommPack)
    {
        using SnnbFoContext c = new SnnbFoContext();

        try
        {
            // one row per UnitId

            List<MControlNic>? v = (from f in c.MControlNics
                                    where f.UnitId == snnbCommPack.SpectralNetGroup.UnitId 
                                    select f).ToList();
            MControlNic rm;
            switch (v.Count)
            {
                case 0:
                    this.UpdateSelf(ipc);
                    c.MControlNics.Add(this);
                    break;
                case 1:
                    rm = v[0];
                    rm.UpdateSelf(ipc);
                    break;
                default:
                    for (int i = 1; i < v.Count; i++)
                    {
                        rm = v[i];
                        c.MControlNics.Remove(rm);
                    }
                    rm = v[0];
                    rm.UpdateSelf(ipc);
                    break;
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

using Common.Extensions;

using SnnbDB.Rest;

namespace SnnbDB.Models;
public partial class MDataNic
{
    #region Ctor
    public MDataNic()
    {

    }

    private void UpdateSelf(Nic nic)
    {
        //List<ArrayRfOutputStream> restMain = snnbCommPack.RestMain.rfOutputStream.array.ToList();
        ///* Excel lines below */
        try
        {
            this.Addresses = nic.structure.addresses.value.Truncate(128);
            this.Address = nic.structure.address.value.Truncate(128);
            this.Netmask = nic.structure.netmask.value;

        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion

    public void SaveRestToDB(SnnbCommPack snnbCommPack)
    {
        try
        {
            this.UnitId = snnbCommPack.SpectralNetGroup.UnitId;

            Nic nic = snnbCommPack.RestMain.dataNic;

            SaveRestToDB(nic, snnbCommPack);

        }
        catch (Exception ex)
        {
            HLog.AddEntry(ex);
            return;
        }    
    }

    private void SaveRestToDB(Nic nic, SnnbCommPack snnbCommPack)
    {
        using SnnbFoContext c = new SnnbFoContext();

        try
        {
            // one row per UnitId

            List<MDataNic>? v = (from f in c.MDataNics
                                    where f.UnitId == snnbCommPack.SpectralNetGroup.UnitId 
                                    select f).ToList();
            MDataNic rm;
            switch (v.Count)
            {
                case 0:
                    this.UpdateSelf(nic);
                    c.MDataNics.Add(this);
                    break;
                case 1:
                    rm = v[0];
                    rm.UpdateSelf(nic);
                    break;
                default:
                    for (int i = 1; i < v.Count; i++)
                    {
                        rm = v[i];
                        c.MDataNics.Remove(rm);
                    }
                    rm = v[0];
                    rm.UpdateSelf(nic);
                    break;
            }

            c.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }
}

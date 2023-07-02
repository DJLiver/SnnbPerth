using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Extensions;

using ExceptionLog;

using SnnbDB.Rest;

namespace SnnbDB.Models;
public partial class MInputRfSpectrum
{
    #region Ctor
    public MInputRfSpectrum()
    {

    }
    #endregion



    public void SaveRestToDB(SnnbCommPack snnbCommPack)
    {
        try
        {
            this.UnitId = snnbCommPack.SpectralNetGroup.UnitId;

            SaveRestToDB(snnbCommPack.RestMain.inputRfSpectrum.data.data, snnbCommPack);


        }
        catch (Exception ex)
        {
            ExLog.Log(ex);
            return;
        }
    }

    private void SaveRestToDB(string data, SnnbCommPack snnbCommPack)
    {
        using SnnbFoContext c = new SnnbFoContext();

        //try
        //{
        //    // Unique by Name
        //    List<MInputRfSpectrum>? v = (from f in c.MInputRfSpectrums
        //                               where f.UnitId == snnbCommPack.SpectralNetGroup.UnitId 
        //                               select f).ToList();
        //    MInputRfSpectrum rm;
        //    switch (v.Count)
        //    {
        //        case 0:
        //            this.Spectrum = data;
        //            c.MInputRfSpectrums.Add(this);
        //            break;
        //        case 1:
        //            rm = v[0];
        //            this.Spectrum = data;
        //            break;
        //        default:
        //            for (int i = 1; i < v.Count; i++)
        //            {
        //                rm = v[i];
        //                c.MInputRfSpectrums.Remove(rm);
        //            }
        //            rm = v[0];
        //            this.Spectrum = data;
        //            break;
        //    }

        //    c.SaveChanges();
        //}
        //catch (Exception)
        //{
        //    throw;
        //}
    }


}

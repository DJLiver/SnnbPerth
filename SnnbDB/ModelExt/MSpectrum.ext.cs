using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Extensions;

using ExceptionLog;

using SnnbDB.Rest;

namespace SnnbDB.Models;
public partial class MSpectrum
{
    #region Ctor
    public MSpectrum()
    {

    }
    #endregion

    private void UpdateSelf(NetworkRoute structure)
    {
        //List<ArrayRfOutputStream> restMain = snnbCommPack.RestMain.rfOutputStream.array.ToList();
        ///* Excel lines below */
    }


    public void SaveRestToDB(SnnbCommPack snnbCommPack)
    {
        this.UnitId = snnbCommPack.SpectralNetGroup.UnitId;

        Dictionary<string, string> Spectrums = new Dictionary<string, string>
        {
            { "inputRfSpectrum", snnbCommPack.RestMain.inputRfPort1Spectrum.data.data },
            { "inputRfPort1Spectrum", snnbCommPack.RestMain.inputRfPort1Spectrum.data.data },
            { "inputRfPort2Spectrum", snnbCommPack.RestMain.inputRfPort1Spectrum.data.data },
            { "outputRfSpectrum", snnbCommPack.RestMain.inputRfPort1Spectrum.data.data },
            { "outputRfPort1Spectrum", snnbCommPack.RestMain.inputRfPort1Spectrum.data.data },
            { "outputRfPort2Spectrum", snnbCommPack.RestMain.inputRfPort1Spectrum.data.data },
        };


            SaveRestToDB(Spectrums, snnbCommPack);
    }

    private void SaveRestToDB(Dictionary<string, string> spectrums, SnnbCommPack snnbCommPack)
    {
        using SnnbFoContext c = new SnnbFoContext();
        var v = (from f in c.MSpectrums
                                where f.UnitId == snnbCommPack.SpectralNetGroup.UnitId 
                                select f).ToList();
        try
        {
            if(v.Count != 6)
            {
                foreach (var item in v)
                {
                    c.MSpectrums.Remove(item);
                }
                foreach (var item in spectrums)
                {
                    c.MSpectrums.Add(new MSpectrum() { UnitId = snnbCommPack.SpectralNetGroup.UnitId, SpectrumType = item.Key, Spectrum = item.Value });
                }

            }
            else
            {
                foreach (var item in v)
                {
                    item.Spectrum = spectrums[item.SpectrumType];
                }
            }
            //c.SaveChanges();

            c.SaveChanges();
        }
        catch (Exception ex)
        {
            ExLog.Log(ex);
            return;
        }
    }
}

﻿namespace SnnbDB.Models;
public partial class MInputRfPort2Spectrum
{
    #region Ctor
    public MInputRfPort2Spectrum()
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
            HLog.AddEntry(ex);
            return;
        }
    }

    private void SaveRestToDB(string data, SnnbCommPack snnbCommPack)
    {
        using SnnbFoContext c = new SnnbFoContext();

        try
        {
            // Unique by Name
            List<MInputRfPort2Spectrum>? v = (from f in c.MInputRfPort2Spectrums
                                              where f.UnitId == snnbCommPack.SpectralNetGroup.UnitId
                                              select f).ToList();
            MInputRfPort2Spectrum rm;
            switch (v.Count)
            {
                case 0:
                    this.Spectrum = data;
                    c.MInputRfPort2Spectrums.Add(this);
                    break;
                case 1:
                    rm = v[0];
                    this.Spectrum = data;
                    break;
                default:
                    for (int i = 1; i < v.Count; i++)
                    {
                        rm = v[i];
                        c.MInputRfPort2Spectrums.Remove(rm);
                    }
                    rm = v[0];
                    this.Spectrum = data;
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

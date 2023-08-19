using System.Globalization;
using System.Text.RegularExpressions;

using SnnbDB.ModelExt;
using SnnbDB.Models;
using SnnbDB.Rest;

namespace SnnbDB.ModelHub;
public class RtSpectrum
{
    public List<RtSpectrumChart> Charts { get; set; } = new List<RtSpectrumChart>();

    #region Ctors
    public RtSpectrum()
    {
    }
    public RtSpectrum(bool fill)
    {
        if (fill)
        {
            for (int i = 0; i < 32; i++)
            {
                Charts.Add(new RtSpectrumChart());
            }
        }
    }

    #endregion

    public void FillSpectrum(RtSnapShot rtSnapShot)
    {
        RtSpectrumChart su;
        foreach (MSpectralNetGroup sng in rtSnapShot.SpecNetGroups)
        {
            su = new RtSpectrumChart();
            su.FillSpectrumChart(sng, true, rtSnapShot);
            Charts.Add(su);

            su = new RtSpectrumChart();
            su.FillSpectrumChart(sng, false, rtSnapShot);
            Charts.Add(su);
        }


    }
}


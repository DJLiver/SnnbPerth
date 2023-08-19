using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SnnbDB.ModelExt;

using SnnbDB.Models;

namespace SnnbDB.ModelHub;
public class RtSpectrumChart
{
    public string ClusterName { get; set; } = "AUC-LH1A";
    public string GroupName { get; set; } = "Group Name";
    public int UnitId { get; set; } = 2000;
    public string NetworkPath { get; set; } = "Primary";
    public bool IsInput { get; set; } = true;
    public float FrequencyOffset { get; set; } = -5000000.0f; //stream Hz
    public float StreamBandwidth { get; set; } = 20000000.0f; //stream Hz
    public float Centrefreq { get; set; } = 1350.5f;  //Modules Mhz
    public float RfDacSaturationPercent { get; set; } = 99.999f;  //Modules
    public float RfPower { get; set; } = -27.5f;  //Modules

    public string Title 
    { 
        get 
        {
            return ClusterName + " " + (IsInput ? "Input" : "Output") + " " + NetworkPath;
        }
        set {  }
    }


    //public List<Int16> LevelData { get; set; } = new List<Int16>() { -100, -100 };
    public List<DataItem> ChartData { get; set; } = new List<DataItem>();

    public RtSpectrumChart()
    {
        ChartData.Clear();
        for (int i = 0; i < 1024; i++)
        {
            float freqStep = 40 / 1024;
            DataItem di = new DataItem();
            di.Freq = 1300 + i * freqStep;
            di.Level = -95;
            ChartData.Add(di);
        }
    }


    //public void FillChartData()
    //{
    //    float FreqStep = StreamBandwidth / 1024000000;
    //    float StartFreq = Centrefreq +  - (StreamBandwidth / 2000000);
    //    ChartData.Clear();
    //    for (int i = 0; i < 1024; i++)
    //    {
    //        DataItem di = new DataItem();
    //        di.Freq = StartFreq + i * FreqStep;
    //        di.Level = LevelData[i];
    //        ChartData.Add(di);
    //    }

    //}
    internal void FillSpectrumChart(MSpectralNetGroup sng, bool isInput, RtSnapShot rtSnapShot)
    {
        ClusterName = sng.UnitName;
        GroupName = sng.GroupName;
        UnitId = sng.UnitId;
        NetworkPath = sng.NetworkPath;
        IsInput = isInput;

        if (IsInput)
        {
            FillInputChart(rtSnapShot);
        }
        else
        {
            FillOutputChart(rtSnapShot);
        }

    }

    private void FillInputChart( RtSnapShot rtSnapShot)
    {
        try
        {
            var ins = (from f in rtSnapShot.RfInputStreams
                       where f.UnitId == UnitId
                       select f).Single();
            FrequencyOffset = ins.FrequencyOffset;
            StreamBandwidth = (float)ins.StreamBandwidth;

            var mod = (from f in rtSnapShot.Modules
                       where f.UnitId == UnitId
                       select f).Single();
            Centrefreq = mod.InputRfCenterFrequency;
            RfDacSaturationPercent = mod.InputRfAdcSaturationPercent;
            RfPower = mod.InputRfPower;

            ChartData.Clear();
            short level = 0;
           // float FreqStep = StreamBandwidth / 1024000000;
            float FreqStep = 45.0f / 1024.0f;
            // ToDo Sys BW 40MHz chart - 45MHz
            //float StartFreq = Centrefreq + (FrequencyOffset / 1000000) - (StreamBandwidth / 2000000);
            float StartFreq = Centrefreq - 22.5f;
            
            var v = (from f in rtSnapShot.InputRfSpectrums
                     where f.UnitId == UnitId
                     select f.Spectrum).Single();

            for (int i = 0; i < 1024; i++)
            {
                DataItem di = new DataItem();
                level = Int16.Parse(v.Substring(2 + i * 4, 4), NumberStyles.HexNumber);
                di.Freq = StartFreq + i * FreqStep;
                di.Level = level;
                ChartData.Add(di);
            }

        }
        catch (Exception)
        {
        }
    }
    private void FillOutputChart( RtSnapShot rtSnapShot)
    {
        try
        {
            var ons = (from f in rtSnapShot.RfOutputStreams
                       where f.UnitId == UnitId
                       select f).Single();
            FrequencyOffset = ons.FrequencyOffset;
            StreamBandwidth = (float)ons.StreamBandwidth;

            var mod = (from f in rtSnapShot.Modules
                       where f.UnitId == UnitId
                       select f).Single();
            Centrefreq = (float)mod.OutputRfCenterFrequency;
            RfDacSaturationPercent = mod.OutputRfDacSaturationPercent;
            RfPower = mod.OutputRfPower;



            var v = (from f in rtSnapShot.OutputRfSpectrums
                     where f.UnitId == UnitId
                     select f.Spectrum).Single();
            ChartData.Clear();
            short level = 0;
            // ToDo Sys BW 40MHz chart - 45MHz
            float FreqStep = 45.0f/ 1024.0f;
            //float StartFreq = Centrefreq + (FrequencyOffset / 1000000) - (StreamBandwidth / 2000000);
            float StartFreq = Centrefreq - 22.5f;

            for (int i = 0; i < 1024; i++)
            {
                DataItem di = new DataItem();
                level = Int16.Parse(v.Substring(2 + i * 4, 4), NumberStyles.HexNumber);
                di.Freq = StartFreq + i * FreqStep;
                di.Level = level;
                ChartData.Add(di);
            }

        }
        catch (Exception)
        {
        }
    }

}
public class DataItem
{
    public float Freq { get; set; }
    public Int16 Level { get; set; }
}

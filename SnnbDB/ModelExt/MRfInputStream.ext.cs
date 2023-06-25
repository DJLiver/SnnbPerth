using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Extensions;

using ExceptionLog;

using SnnbDB.Rest;

namespace SnnbDB.Models;
public partial class MRfInputStream
{
    #region Ctor
    //public MRfInputStream(SnnbCommPack snnbCommPack)
    //{
    //    this.UnitId = snnbCommPack.SpectralNetGroup.UnitId;

    //}

    //public MRfInputStream()
    //{

    //}
    //public MModule(SnnbCommPack snnbCommPack)
    //{
    //    UpdateSelf(snnbCommPack);

    //}
    #endregion
    private void UpdateSelf(StructureRfInputStream structure)
    {
        //List<ArrayRfInputStream> restMain = snnbCommPack.RestMain.rfInputStream.array.ToList();
        ///* Excel lines below */
        this.Name = structure.name.value.Truncate(128);
        this.BitRate = structure.bitRate.value;
        this.DataSampleWidth = structure.dataSampleWidth.value;
        this.DestinationHost = structure.destinationHost.value.Truncate(128);
        this.DestinationPort = structure.destinationPort.value;
        this.FrequencyOffset = structure.frequencyOffset.value;
        this.MaximumPacketSize = structure.maximumPacketSize.value;
        this.MeasuredNetworkRate = structure.measuredNetworkRate.value;
        this.MeasuredPacketRate = structure.measuredPacketRate.value;
        this.MinimumProcessingDelay = structure.minimumProcessingDelay.value;
        this.PacketOverhead = structure.packetOverhead.value;
        this.PfecEnable = structure.pfecEnable.value;
        this.RouteSearch = structure.routeSearch.value.Truncate(128);
        this.SourcePort = structure.sourcePort.value;
        this.StreamBandwidth = structure.streamBandwidth.value;
        this.StreamEnable = structure.streamEnable.value;
        this.StreamGain = structure.streamGain.value;
        this.StreamId = structure.streamId.value;
        this.StreamSampleRate = structure.streamSampleRate.value;

    }

    public void SaveRestToDB(SnnbCommPack snnbCommPack)
    {
        this.UnitId = snnbCommPack.SpectralNetGroup.UnitId;

        List<ArrayRfInputStream> restMain = snnbCommPack.RestMain.rfInputStream.array.ToList();


        foreach (var item in restMain)
        {
            SaveRestToDB(item.structure, snnbCommPack);
        }
    }

    private void SaveRestToDB(StructureRfInputStream structure, SnnbCommPack snnbCommPack)
    {
        using SnnbFoContext c = new SnnbFoContext();

        try
        {
            // Unique by Name
            List<MRfInputStream>? v = (from f in c.MRfInputStreams
                                where f.UnitId == snnbCommPack.SpectralNetGroup.UnitId & 
                                    f.Name == structure.name.value
                                select f).ToList();
            MRfInputStream rm;
            switch (v.Count)
            {
                case 0:
                    this.UpdateSelf(structure);
                    c.MRfInputStreams.Add(this);
                    break;
                case 1:
                    rm = v[0];
                    rm.UpdateSelf(structure);
                    break;
                default:
                    for (int i = 1; i < v.Count; i++)
                    {
                        rm = v[i];
                        c.MRfInputStreams.Remove(rm);
                    }
                    rm = v[0];
                    rm.UpdateSelf(structure);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Extensions;

using ExceptionLog;

using SnnbDB.Rest;

namespace SnnbDB.Models;
public partial class MRfOutputStream
{
    #region Ctor
    //public MRfOutputStream(SnnbCommPack snnbCommPack)
    //{
    //    this.UnitId = snnbCommPack.SpectralNetGroup.UnitId;

    //}

    //public MRfOutputStream()
    //{

    //}
    //public MModule(SnnbCommPack snnbCommPack)
    //{
    //    UpdateSelf(snnbCommPack);

    //}
    #endregion
    private void UpdateSelf(StructureRfOutputStream structure)
    {
        //List<ArrayRfOutputStream> restMain = snnbCommPack.RestMain.rfOutputStream.array.ToList();
        ///* Excel lines below */

        try
        {
            this.Name = structure.name.value.Truncate(128);
            this.CurrentBuffer = structure.currentBuffer.value;
            this.DataSampleWidth = structure.dataSampleWidth.value;
            this.DataSource = structure.dataSource.value.Truncate(128);
            this.DesiredBuffer = structure.desiredBuffer.value;
            this.DesiredDelay = structure.desiredDelay.value;
            this.DestinationPort = structure.destinationPort.value;
            this.DroppedPackets = structure.droppedPackets.value;
            this.FrequencyOffset = structure.frequencyOffset.value;
            this.GapCount = structure.gapCount.value;
            this.MeasuredDelay = structure.measuredDelay.value;
            this.MeasuredNetworkRate = structure.measuredNetworkRate.value;
            this.MeasuredPacketRate = structure.measuredPacketRate.value;
            this.NetStreamGain = structure.netStreamGain.value;
            this.NetworkDelay = structure.networkDelay.value;
            this.PacketOverhead = structure.packetOverhead.value;
            this.PfecDecoderStatus = structure.pfecDecoderStatus.value.Truncate(128);
            this.PfecMissingSets = structure.pfecMissingSets.value;
            this.PfecRepairedPackets = structure.pfecRepairedPackets.value;
            this.PfecTotalPackets = structure.pfecTotalPackets.value;
            this.PfecUnrepairablePackets = structure.pfecUnrepairablePackets.value;
            this.PreserveLatency = structure.preserveLatency.value;
            this.PreserveLatencyLatePackets = structure.preserveLatencyLatePackets.value;
            this.PreserveLatencyMaxBurstLoss = structure.preserveLatencyMaxBurstLoss.value;
            this.PreserveLatencyMissingPackets = structure.preserveLatencyMissingPackets.value;
            this.PreserveLatencyOutOfOrderPackets = structure.preserveLatencyOutOfOrderPackets.value;
            this.PreserveLatencyReleaseMargin = structure.preserveLatencyReleaseMargin.value;
            this.ReleaseMode = structure.releaseMode.value.Truncate(128);
            this.SourceHost = structure.sourceHost.value.Truncate(128);
            this.SourcePort = structure.sourcePort.value;
            this.StreamBandwidth = structure.streamBandwidth.value;
            this.StreamEnable = structure.streamEnable.value;
            this.StreamId = structure.streamId.value;
            this.StreamSampleRate = structure.streamSampleRate.value;
            this.UnderflowCount = structure.underflowCount.value;
            this.UpstreamIrigLocked = structure.upstreamIrigLocked.value;
            this.UpstreamOnePpsLocked = structure.upstreamOnePpsLocked.value;
            this.UpstreamPathGain = structure.upstreamPathGain.value;
            this.UpstreamTenMhzLocked = structure.upstreamTenMhzLocked.value;
            this.UseLocalReference = structure.useLocalReference.value;

        }
        catch (Exception)
        {
            throw;
        }    
    }

    public void SaveRestToDB(SnnbCommPack snnbCommPack)
    {
        try
        {
            this.UnitId = snnbCommPack.SpectralNetGroup.UnitId;

            List<ArrayRfOutputStream> restMain = snnbCommPack.RestMain.rfOutputStream.array.ToList();

            foreach (var item in restMain)
            {
                SaveRestToDB(item.structure, snnbCommPack);
            }
        }
        catch (Exception ex)
        {
            ExLog.Log(ex);
            return;
        }
    }

    private void SaveRestToDB(StructureRfOutputStream structure, SnnbCommPack snnbCommPack)
    {
        using SnnbFoContext c = new SnnbFoContext();

        try
        {
            // Unique by Name
            List<MRfOutputStream>? v = (from f in c.MRfOutputStreams
                                where f.UnitId == snnbCommPack.SpectralNetGroup.UnitId & 
                                    f.Name == structure.name.value
                                select f).ToList();
            MRfOutputStream rm;
            switch (v.Count)
            {
                case 0:
                    this.UpdateSelf(structure);
                    c.MRfOutputStreams.Add(this);
                    break;
                case 1:
                    rm = v[0];
                    rm.UpdateSelf(structure);
                    break;
                default:
                    for (int i = 1; i < v.Count; i++)
                    {
                        rm = v[i];
                        c.MRfOutputStreams.Remove(rm);
                    }
                    rm = v[0];
                    rm.UpdateSelf(structure);
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

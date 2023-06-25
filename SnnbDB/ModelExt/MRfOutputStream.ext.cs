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
    public MRfOutputStream()
    {

    }

    //public MModule(SnnbCommPack snnbCommPack)
    //{
    //    UpdateSelf(snnbCommPack);

    //}
    #endregion
    private void UpdateSelf(SnnbCommPack snnbCommPack)
    {
        this.UnitId = snnbCommPack.SpectralNetGroup.UnitId;
        List<ArrayRfOutputStream> restMain = snnbCommPack.RestMain.rfOutputStream.array.ToList();
        ///* Excel lines below */
        
        //this.Name = restMain.name.value.Truncate(128);
        //this.CurrentBuffer = restMain.currentBuffer.value;
        //this.DataSampleWidth = restMain.dataSampleWidth.value;
        //this.DataSource = restMain.dataSource.value.Truncate();
        //this.DesiredBuffer = restMain.desiredBuffer.value;
        //this.DesiredDelay = restMain.desiredDelay.value;
        //this.DestinationPort = restMain.destinationPort.value;
        //this.DroppedPackets = restMain.droppedPackets.value;
        //this.FrequencyOffset = restMain.frequencyOffset.value;
        //this.GapCount = restMain.gapCount.value;
        //this.MeasuredDelay = restMain.measuredDelay.value;
        //this.MeasuredNetworkRate = restMain.measuredNetworkRate.value;
        //this.MeasuredPacketRate = restMain.measuredPacketRate.value;
        //this.NetStreamGain = restMain.netStreamGain.value;
        //this.NetworkDelay = restMain.networkDelay.value;
        //this.PacketOverhead = restMain.packetOverhead.value;
        //this.PfecDecoderStatus = restMain.pfecDecoderStatus.value.Truncate();
        //this.PfecMissingSets = restMain.pfecMissingSets.value;
        //this.PfecRepairedPackets = restMain.pfecRepairedPackets.value;
        //this.PfecTotalPackets = restMain.pfecTotalPackets.value;
        //this.PfecUnrepairablePackets = restMain.pfecUnrepairablePackets.value;
        //this.PreserveLatency = restMain.preserveLatency.value;
        //this.PreserveLatencyLatePackets = restMain.preserveLatencyLatePackets.value;
        //this.PreserveLatencyMaxBurstLoss = restMain.preserveLatencyMaxBurstLoss.value;
        //this.PreserveLatencyMissingPackets = restMain.preserveLatencyMissingPackets.value;
        //this.PreserveLatencyOutOfOrderPackets = restMain.preserveLatencyOutOfOrderPackets.value;
        //this.PreserveLatencyReleaseMargin = restMain.preserveLatencyReleaseMargin.value;
        //this.ReleaseMode = restMain.releaseMode.value.Truncate(128);
        //this.SourceHost = restMain.sourceHost.value.Truncate();
        //this.SourcePort = restMain.sourcePort.value;
        //this.StreamBandwidth = restMain.streamBandwidth.value;
        //this.StreamEnable = restMain.streamEnable.value;
        //this.StreamId = restMain.streamId.value;
        //this.StreamSampleRate = restMain.streamSampleRate.value;
        //this.UnderflowCount = restMain.underflowCount.value;
        //this.UpstreamIrigLocked = restMain.upstreamIrigLocked.value;
        //this.UpstreamOnePpsLocked = restMain.upstreamOnePpsLocked.value;
        //this.UpstreamPathGain = restMain.upstreamPathGain.value;
        //this.UpstreamTenMhzLocked = restMain.upstreamTenMhzLocked.value;
        //this.UseLocalReference = restMain.useLocalReference.value;

    }

    public void SaveRestToDB(SnnbCommPack snnbCommPack)
    {
        List<ArrayRfOutputStream> restMain = snnbCommPack.RestMain.rfOutputStream.array.ToList();


        foreach (var item in restMain)
        {
           // item.structure.
        }
        //using SnnbFoContext c = new SnnbFoContext();

        //try
        //{
        //    List<MModule>? v = (from f in c.MModules
        //             where f.UnitId == snnbCommPack.SpectralNetGroup.UnitId
        //             select f).ToList();
        //    MModule rm;
        //    switch (v.Count)
        //    {
        //        case 0:
        //            this.UpdateSelf(snnbCommPack);
        //            c.MModules.Add(this);
        //            break;
        //        case 1:
        //            rm = v[0];
        //            rm.UpdateSelf(snnbCommPack);
        //            break;
        //        default:
        //            for (int i = 1; i < v.Count; i++)
        //            {
        //                rm = v[i];
        //                c.MModules.Remove(rm);
        //            }
        //            rm = v[0];
        //            rm.UpdateSelf(snnbCommPack);
        //            break;
        //    }

        //    c.SaveChanges();
        //}
        //catch (Exception ex)
        //{
        //    ExLog.Log(ex);
        //    return;
        //}
    }
}

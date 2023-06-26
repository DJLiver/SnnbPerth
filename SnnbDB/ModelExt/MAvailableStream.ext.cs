using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Extensions;

using ExceptionLog;

using SnnbDB.Rest;

namespace SnnbDB.Models;
public partial class MAvailableStream
{
    #region Ctor
    public MAvailableStream()
    {

    }
    #endregion
    public void SaveRestToDB(SnnbCommPack snnbCommPack)
    {
        try
        {
            this.UnitId = snnbCommPack.SpectralNetGroup.UnitId;

            List<ArrayAvailableStreams> AAS = snnbCommPack.RestMain.availableStreams.array.ToList();


            foreach (var item in AAS)
            {
                SaveRestToDB(item.structure, snnbCommPack);
            }

        }
        catch (Exception ex)
        {
            ExLog.Log(ex);
        }            
    }

    private void UpdateSelf(StructureAvailableStreams structure)
    {
        //List<ArrayRfOutputStream> restMain = snnbCommPack.RestMain.rfOutputStream.array.ToList();
        ///* Excel lines below */
        try
        {
            this.SourceIpAddress = structure.sourceIpAddress.value.Truncate(128);
            this.SourcePort = structure.sourcePort.value.Truncate(128);
            this.StreamId = structure.streamId.value;
            this.CenterFrequency = structure.centerFrequency.value;
            this.Bandwidth = structure.bandwidth.value;
            this.SampleRate = structure.sampleRate.value;
            this.Gain = structure.gain.value;
            this.SampleWidth = structure.sampleWidth.value;
            this.PfecEnabled = structure.pfecEnabled.value;
            this.IrigLocked = structure.irigLocked.value;
            this.OnePpsPresent = structure.onePpsPresent.value;
            this.TenMhzLocked = structure.tenMhzLocked.value;

        }
        catch (Exception)
        {
            throw;
        }    
    }

    private void SaveRestToDB(StructureAvailableStreams structure, SnnbCommPack snnbCommPack)
    {
        using SnnbFoContext c = new SnnbFoContext();

        try
        {
            // Unique by       ,[sourceIpAddress]      ,[sourcePort]      ,[streamId]

            List<MAvailableStream>? v = (from f in c.MAvailableStreams
                                        where f.UnitId == snnbCommPack.SpectralNetGroup.UnitId &
                                        f.SourceIpAddress == structure.sourceIpAddress.value &
                                        f.SourcePort == structure.sourcePort.value &
                                        f.StreamId == structure.streamId.value
                                        select f).ToList();
            MAvailableStream rm;
            switch (v.Count)
            {
                case 0:
                    this.UpdateSelf(structure);
                    c.MAvailableStreams.Add(this);
                    break;
                case 1:
                    rm = v[0];
                    rm.UpdateSelf(structure);
                    break;
                default:
                    for (int i = 1; i < v.Count; i++)
                    {
                        rm = v[i];
                        c.MAvailableStreams.Remove(rm);
                    }
                    rm = v[0];
                    rm.UpdateSelf(structure);
                    break;
            }

            c.SaveChanges();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}

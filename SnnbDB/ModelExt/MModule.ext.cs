using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Extensions;

using ExceptionLog;

using SnnbDB.Rest;

namespace SnnbDB.Models;
public partial class MModule
{
    #region Ctor
    public MModule()
    {

    }

    public MModule(SnnbCommPack snnbCommPack)
    {
        UpdateSelf(snnbCommPack);

    }
    #endregion
    private void UpdateSelf(SnnbCommPack snnbCommPack)
    {
        this.UnitId = snnbCommPack.specNetGroup.UnitId;
        RestMain restMain = snnbCommPack.restRoot;
        /* Excel lines below */
        this.Active = restMain.active.value;
        this.Address = restMain.address.value.Truncate(128);

        this.CompositeStatus = restMain.compositeStatus.value.Truncate(128);
        this.CompositeStatusMsg = restMain.compositeStatusMsg.value.Truncate(512);
        this.ContextPacketState = restMain.contextPacketState.value.Truncate(128);

        this.CurrentGain = restMain.currentGain.value;


        this.DiscardedPackets = restMain.discardedPackets.value;
        this.EnableMulticastGroupSubscriptions = restMain.enableMulticastGroupSubscriptions.value;
        this.FanSpeed = restMain.fanSpeed.value;
        this.GainMode = restMain.gainMode.value.Truncate(128);
        this.Gateway = restMain.gateway.value.Truncate(128);
        this.HealthStatus = restMain.healthStatus.value.Truncate(128);
        this.HealthStatusMsg = restMain.healthStatusMsg.value.Truncate(512);
        this.InputRfAdcSaturation = restMain.inputRfAdcSaturation.value;
        this.InputRfAdcSaturationPercent = restMain.inputRfAdcSaturationPercent.value;
        this.InputRfBandwidth = restMain.inputRfBandwidth.value.Truncate(128);
        this.InputRfCenterFrequency = restMain.inputRfCenterFrequency.value;
        this.InputRfPort1AdcSaturation = restMain.inputRfPort1AdcSaturation.value;
        this.InputRfPort1AdcSaturationPercent = restMain.inputRfPort1AdcSaturationPercent.value;
        this.InputRfPort1MinimumGain = restMain.inputRfPort1MinimumGain.value;
        this.InputRfPort1Power = restMain.inputRfPort1Power.value;

        this.InputRfPort2AdcSaturation = restMain.inputRfPort2AdcSaturation.value;
        this.InputRfPort2AdcSaturationPercent = restMain.inputRfPort2AdcSaturationPercent.value;
        this.InputRfPort2MinimumGain = restMain.inputRfPort2MinimumGain.value;
        this.InputRfPort2Power = restMain.inputRfPort2Power.value;

        this.InputRfPortSelect = restMain.inputRfPortSelect.value.Truncate(128);
        this.InputRfPower = restMain.inputRfPower.value;
        this.InputRfSampleRate = restMain.inputRfSampleRate.value;

        this.InvertRfOutputSpectrum = restMain.invertRfOutputSpectrum.value;
        this.IrigDcLocked = restMain.irigDcLocked.value;
        this.IrigLocked = restMain.irigLocked.value;
        this.Label = restMain.label.value.Truncate(128);
        this.LogLevel = restMain.logLevel.value.Truncate(128);
        this.ManualGain = restMain.manualGain.value;
        this.MinimumGain = restMain.minimumGain.value;
        this.ModuleState = restMain.moduleState.value.Truncate(128);
        this.ModuleType = restMain.moduleType.value.Truncate(128);

        this.NtpStatus = restMain.ntpStatus.value.Truncate(128);
        this.OnePpsPresent = restMain.onePpsPresent.value;
        this.OutputAttenuation = restMain.outputAttenuation.value;
        this.OutputRfCenterFrequency = restMain.outputRfCenterFrequency.value;
        this.OutputRfDacSaturation = restMain.outputRfDacSaturation.value;
        this.OutputRfDacSaturationPercent = restMain.outputRfDacSaturationPercent.value;
        this.OutputRfPort1DacSaturation = restMain.outputRfPort1DacSaturation.value;
        this.OutputRfPort1DacSaturationPercent = restMain.outputRfPort1DacSaturationPercent.value;
        this.OutputRfPort1Power = restMain.outputRfPort1Power.value;

        this.OutputRfPort2DacSaturation = restMain.outputRfPort2DacSaturation.value;
        this.OutputRfPort2DacSaturationPercent = restMain.outputRfPort2DacSaturationPercent.value;
        this.OutputRfPort2Power = restMain.outputRfPort2Power.value;

        this.OutputRfPortSelect = restMain.outputRfPortSelect.value.Truncate(128);
        this.OutputRfPower = restMain.outputRfPower.value;

        this.OverrideOutputFrequency = restMain.overrideOutputFrequency.value;
        this.OverrideOutputFrequencyEnable = restMain.overrideOutputFrequencyEnable.value;
        this.PollInterval = restMain.pollInterval.value;
        this.PosixNanoseconds = restMain.posixNanoseconds.value;
        this.PosixSeconds = restMain.posixSeconds.value;
        this.RebootRequired = restMain.rebootRequired.value;
        this.ReplyWaitTime = restMain.replyWaitTime.value;
        this.RequiredReadPrivilege = restMain.requiredReadPrivilege.value.Truncate(128);
        this.RequiredWritePrivilege = restMain.requiredWritePrivilege.value.Truncate(128);

        this.RfOutputEnable = restMain.rfOutputEnable.value;
        this.RfOutputSource = restMain.rfOutputSource.value.Truncate(128);


        this.SecuritySource = restMain.securitySource.value.Truncate(128);
        this.SerialNumber = restMain.serialNumber.value.Truncate(128);
        this.ShortDescription = restMain.shortDescription.value.Truncate(128);
        this.Simulate = restMain.simulate.value;
        this.SquelchEnabled = restMain.squelchEnabled.value;
        this.SystemTemperature = restMain.systemTemperature.value;
        this.SystemTimeSource = restMain.systemTimeSource.value.Truncate(128);
        this.TenMhzLocked = restMain.tenMhzLocked.value;
        this.Version = restMain.version.value.Truncate(128);

    }



    public void ProcessRestData(SnnbCommPack snnbCommPack)
    {
        using SnnbFoContext c = new SnnbFoContext();

        try
        {
            List<MModule>? v = (from f in c.MModules
                     where f.UnitId == snnbCommPack.specNetGroup.UnitId
                     select f).ToList();
            MModule rm;
            switch (v.Count)
            {
                case 0:
                    this.UpdateSelf(snnbCommPack);
                    c.MModules.Add(this);
                    break;
                case 1:
                    rm = v[0];
                    rm.UpdateSelf(snnbCommPack);
                    break;
                default:
                    for (int i = 1; i < v.Count; i++)
                    {
                        rm = v[i];
                        c.MModules.Remove(rm);
                    }
                    rm = v[0];
                    rm.UpdateSelf(snnbCommPack);
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

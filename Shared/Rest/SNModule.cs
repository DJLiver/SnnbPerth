using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnnbFailover.Shared.Rest;
public class SNModule
{
    public RestBool Active { get; set; }
    public RestString Address { get; set; }
    //Array
    public AvailableStreams AvailableStreams { get; set; }
    public RestString CompositeStatus { get; set; }
    public RestString CompositeStatusMsg { get; set; }
    public RestString ContextPacketState { get; set; }
    public Nic controlNic { get; set; }
    public RestUInt32 currentGain { get; set; }
    public Nic dataNic { get; set; }
    public RestStringArray dependencies { get; set; }
    public RestUInt32 discardedPackets { get; set; } //UInt32
    public RestBool enableMulticastGroupSubscriptions { get; set; }
    public RestUInt16 fanSpeed { get; set; }//UInt16
    public RestString gainMode { get; set; }
    public RestString gateway { get; set; }
    public RestString healthStatus { get; set; } //Status
    public RestString healthStatusMsg { get; set; }
    public RestFloat inputRfAdcSaturation { get; set; } //float
    public RestFloat inputRfAdcSaturationPercent { get; set; }
    public RestString inputRfBandwidth { get; set; }
    public RestFloat inputRfCenterFrequency { get; set; }
    public RestFloat inputRfPort1AdcSaturation { get; set; }
    public RestFloat inputRfPort1AdcSaturationPercent { get; set; }
    public RestInt32 inputRfPort1MinimumGain { get; set; }
    public RestFloat inputRfPort1Power { get; set; }
    public Spectrum inputRfPort1Spectrum { get; set; }
    public RestFloat inputRfPort2AdcSaturation { get; set; }
    public RestFloat inputRfPort2AdcSaturationPercent { get; set; }
    public RestInt32 inputRfPort2MinimumGain { get; set; }
    public RestFloat inputRfPort2Power { get; set; }
    public Spectrum inputRfPort2Spectrum { get; set; }
    public RestString inputRfPortSelect { get; set; }
    public RestFloat inputRfPower { get; set; }
    public RestUInt32 inputRfSampleRate { get; set; }
    public Spectrum inputRfSpectrum { get; set; }

    public RestBool invertRfOutputSpectrum { get; set; }
    public RestBool irigDcLocked { get; set; }
    public RestBool irigLocked { get; set; }
    public RestString label { get; set; }
    public RestString logLevel { get; set; }
    public RestInt32 manualGain { get; set; }
    public RestInt32 minimumGain { get; set; }
    public RestString moduleState { get; set; }
    public RestString moduleType { get; set; }
    public RestStringArray multicastGroupSubscriptions { get; set; }
    public RestString ntpStatus { get; set; }
    public RestBool onePpsPresent { get; set; }
    public RestFloat outputAttenuation { get; set; }
    public RestDouble outputRfCenterFrequency { get; set; }
    public RestFloat outputRfDacSaturation { get; set; }
    public RestFloat outputRfDacSaturationPercent { get; set; }
    public RestFloat outputRfPort1DacSaturation { get; set; }
    public RestFloat outputRfPort1DacSaturationPercent { get; set; }
    public RestFloat outputRfPort1Power { get; set; }
    public Spectrum outputRfPort1Spectrum { get; set; }
    public RestFloat outputRfPort2DacSaturation { get; set; }
    public RestFloat outputRfPort2DacSaturationPercent { get; set; }
    public RestFloat outputRfPort2Power { get; set; }
    public Spectrum outputRfPort2Spectrum { get; set; }
    public RestString outputRfPortSelect { get; set; }
    public RestFloat outputRfPower { get; set; }
    public Spectrum outputRfSpectrum { get; set; }
    public RestFloat overrideOutputFrequency { get; set; }
    public RestBool overrideOutputFrequencyEnable { get; set; }
    public RestUInt32 pollInterval { get; set; }
    public RestUInt32 posixNanoseconds { get; set; }
    public RestUInt32 posixSeconds { get; set; }
    public RestBool rebootRequired { get; set; }
    public RestString ReplyWaitTime { get; set; }//check
    public RestString RequiredReadPrivilege { get; set; }
    public RestString RequiredWritePrivilege { get; set; }
    public RfInputStream RfInputStream { get; set; }
    public RestBool RfOutputEnable { get; set; }
    public RestString RfOutputSource { get; set; }
    public RfOutputStream RfOutputStream { get; set; }
    public Routes Routes { get; set; }
    public RestString SecuritySource { get; set; }
    public RestString SerialNumber { get; set; }
    public RestString ShortDescription { get; set; }
    public RestBool Simulate { get; set; }
    public RestBool SquelchEnabled { get; set; }

    public RestInt32 SystemTemperature { get; set; }
    public RestString SystemTimeSource { get; set; }
    public RestBool TenMhzLocked { get; set; }
    public RestString Version { get; set; }
}

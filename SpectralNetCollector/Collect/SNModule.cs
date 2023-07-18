using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectralNetCollector.Collect
{
    #region REST base classes
    public class RestBool
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public bool Value { get; set; }
    }
    public class RestFloat
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public float Value { get; set; }
    }
    public class RestUInt32
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public uint Value { get; set; }
    }
    public class RestUInt64
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public UInt64 Value { get; set; }
    }
    public class RestUInt16
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public ushort Value { get; set; }
    }
    public class RestUInt8
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public byte Value { get; set; }
    }

    public class RestString
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public string Value { get; set; }
    }

    public class RestDouble
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public double Value { get; set; }
    }

    public class RestInt64
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public Int64 Value { get; set; }
    }

    public class RestInt32
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public Int32 Value { get; set; }
    }

    #endregion

    #region SNModule
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
        public Dependencies dependencies { get; set; }
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
        public MulticastGroupSubscriptions multicastGroupSubscriptions { get; set; }
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

    #endregion

    #region AvailableStreams
    public class StructureAvailableStreams
    {
        public RestString sourceIpAddress { get; set; }
        public RestString sourcePort { get; set; }
        public RestUInt32 streamId { get; set; }
        public RestDouble centerFrequency { get; set; }
        public RestDouble bandwidth { get; set; }
        public RestDouble sampleRate { get; set; }
        public RestDouble gain { get; set; }
        public RestUInt8 sampleWidth { get; set; }
        public RestBool pfecEnabled { get; set; }
        public RestBool irigLocked { get; set; }
        public RestBool onePpsPresent { get; set; }
        public RestBool tenMhzLocked { get; set; }
    }

    public class ArrayAvailableStreams
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public StructureAvailableStreams structure { get; set; }
    }

    public class AvailableStreams
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public List<ArrayAvailableStreams> array { get; set; }
    }

    #endregion

    #region IP4Config
    public class IP4Config
    {
        public RestString Maunual_DHCP { get; set; }
        public RestString address { get; set; }
        public RestInt32 netmask { get; set; }
    }

    public class Nic
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public IP4Config IP4Config { get; set; }
    }

    #endregion

    #region Dependencies and Multicast
    public class Dependencies
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public List<RestString> array { get; set; }
    }

    public class MulticastGroupSubscriptions
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public List<RestString> array { get; set; }
    }

    #endregion

    #region Spectrum
    public class SpectrumData
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public string data { get; set; }
        public int bitLength { get; set; }
    }

    public class Spectrum
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public SpectrumData data { get; set; }
    }

    #endregion

    #region RfInputStreams
    public class StructureRfInputStream
    {
        public RestString name { get; set; }
        public RestUInt32 bitRate { get; set; }
        public RestUInt8 dataSampleWidth { get; set; }
        public RestString destinationHost { get; set; }
        public RestUInt16 destinationPort { get; set; }
        public RestInt64 frequencyOffset { get; set; }
        public RestUInt32 maximumPacketSize { get; set; }
        public RestUInt64 measuredNetworkRate { get; set; }
        public RestUInt32 measuredPacketRate { get; set; }
        public RestDouble minimumProcessingDelay { get; set; }
        public RestDouble packetOverhead { get; set; }
        public RestBool pfecEnable { get; set; }
        public RestString routeSearch { get; set; }
        public RestUInt16 sourcePort { get; set; }
        public RestUInt64 streamBandwidth { get; set; }
        public RestBool streamEnable { get; set; }
        public RestDouble streamGain { get; set; }
        public RestUInt32 streamId { get; set; }
        public RestDouble streamSampleRate { get; set; }
    }

    public class ArrayRfInputStream
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public StructureRfInputStream structure { get; set; }
    }

    public class RfInputStream
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public List<ArrayRfInputStream> array { get; set; }
    }

    #endregion

    #region RfOutputStreams
    public class StructureRfOutputStream
    {
        public RestString name { get; set; }
        public RestDouble currentBuffer { get; set; }
        public RestUInt8 dataSampleWidth { get; set; }
        public RestString dataSource { get; set; }
        public RestUInt32 desiredBuffer { get; set; }
        public RestUInt32 desiredDelay { get; set; }
        public RestUInt16 destinationPort { get; set; }
        public RestUInt32 droppedPackets { get; set; }
        public RestInt64 frequencyOffset { get; set; }
        public RestUInt32 gapCount { get; set; }
        public RestUInt32 measuredDelay { get; set; }
        public RestUInt64 measuredNetworkRate { get; set; }
        public RestUInt32 measuredPacketRate { get; set; }
        public RestDouble netStreamGain { get; set; }
        public RestDouble networkDelay { get; set; }
        public RestDouble packetOverhead { get; set; }
        public RestString pfecDecoderStatus { get; set; }
        public RestUInt32 pfecMissingSets { get; set; }
        public RestUInt32 pfecRepairedPackets { get; set; }
        public RestUInt64 pfecTotalPackets { get; set; }
        public RestUInt32 pfecUnrepairablePackets { get; set; }
        public RestBool preserveLatency { get; set; }
        public RestUInt32 preserveLatencyLatePackets { get; set; }
        public RestUInt32 preserveLatencyMaxBurstLoss { get; set; }
        public RestUInt32 preserveLatencyMissingPackets { get; set; }
        public RestUInt32 preserveLatencyOutOfOrderPackets { get; set; }
        public RestUInt32 preserveLatencyReleaseMargin { get; set; } //nSec
        public RestString releaseMode { get; set; }
        public RestString sourceHost { get; set; }
        public RestUInt16 sourcePort { get; set; }
        public RestDouble streamBandwidth { get; set; }
        public RestBool streamEnable { get; set; }
        public RestUInt32 streamId { get; set; }
        public RestDouble streamSampleRate { get; set; }
        public RestUInt32 underflowCount { get; set; }
        public RestBool upstreamIrigLocked { get; set; }
        public RestBool upstreamOnePpsLocked { get; set; }
        public RestDouble upstreamPathGain { get; set; }
        public RestBool upstreamTenMhzLocked { get; set; }
        public RestBool useLocalReference { get; set; }
    }

    public class ArrayRfOutputStream
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public StructureRfOutputStream structure { get; set; }
    }

    public class RfOutputStream
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public List<ArrayRfOutputStream> array { get; set; }
    }


    #endregion

    #region Routes
    public class Routes
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public List<NetworkRoutes> array { get; set; }
    }
    public class NetworkRoutes
    {
        public string Factory { get; set; }
        public string FactoryType { get; set; }
        public NetworkRoute networkRoute { get; set; }
    }
    public class NetworkRoute
    {
        public string destination { get; set; }
        public string gateway { get; set; }
        public RestInt32 netmask { get; set; }

    }

    #endregion

}

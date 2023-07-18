using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectralNetCollector.Collect
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    #region sub classes
    public class RestBool
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    //public class Address
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class SourceIpAddress
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class SourcePort
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class StreamId
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class CenterFrequency
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class Bandwidth
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class SampleRate
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class Gain
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class SampleWidth
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class PfecEnabled
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class IrigLocked
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class OnePpsPresent
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class TenMhzLocked
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class StructureAvailableStreams
    {
        public RestString sourceIpAddress { get; set; }
        public RestString sourcePort { get; set; }
        public StreamId streamId { get; set; }
        public CenterFrequency centerFrequency { get; set; }
        public Bandwidth bandwidth { get; set; }
        public SampleRate sampleRate { get; set; }
        public Gain gain { get; set; }
        public SampleWidth sampleWidth { get; set; }
        public PfecEnabled pfecEnabled { get; set; }
        public IrigLocked irigLocked { get; set; }
        public OnePpsPresent onePpsPresent { get; set; }
        public TenMhzLocked tenMhzLocked { get; set; }
    }

    public class ArrayAvailableStreams
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public StructureAvailableStreams structure { get; set; }
    }

    public class AvailableStreams
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public List<ArrayAvailableStreams> array { get; set; }
    }

    //public class CompositeStatus
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class CompositeStatusMsg
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class ContextPacketState
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class Addresses
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class Address2
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class Netmask
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class Structure2
    {
        public RestString addresses { get; set; }
        public RestString address { get; set; }
        public Netmask netmask { get; set; }
    }

    public class ControlNic
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public Structure2 structure { get; set; }
    }

    public class CurrentGain
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    //public class Addresses2
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class Address3
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class Netmask2
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class Structure3
    {
        public Addresses2 addresses { get; set; }
        public Address3 address { get; set; }
        public Netmask2 netmask { get; set; }
    }

    public class DataNic
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public Structure3 structure { get; set; }
    }

    //public class Array2
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class Dependencies
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public List<Array2> array { get; set; }
    }

    public class DiscardedPackets
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class EnableMulticastGroupSubscriptions
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class FanSpeed
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    //public class GainMode
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class Gateway
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class HealthStatus
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class HealthStatusMsg
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class InputRfAdcSaturation
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class InputRfAdcSaturationPercent
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    //public class InputRfBandwidth
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class InputRfCenterFrequency
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class InputRfPort1AdcSaturation
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class InputRfPort1AdcSaturationPercent
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class InputRfPort1MinimumGain
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class InputRfPort1Power
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class Data
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public string data { get; set; }
        public int bitLength { get; set; }
    }

    public class InputRfPort1Spectrum
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public Data data { get; set; }
    }

    public class InputRfPort2AdcSaturation
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class InputRfPort2AdcSaturationPercent
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class InputRfPort2MinimumGain
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class InputRfPort2Power
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class Data2
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public string data { get; set; }
        public int bitLength { get; set; }
    }

    public class InputRfPort2Spectrum
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public Data2 data { get; set; }
    }

    //public class InputRfPortSelect
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class InputRfPower
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class InputRfSampleRate
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class Data3
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public string data { get; set; }
        public int bitLength { get; set; }
    }

    public class InputRfSpectrum
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public Data3 data { get; set; }
    }

    public class InvertRfOutputSpectrum
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class IrigDcLocked
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class IrigLocked2
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    //public class Label
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class LogLevel
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class ManualGain
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class MinimumGain
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    //public class ModuleState
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class ModuleType
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class Array3
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class MulticastGroupSubscriptions
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public List<Array3> array { get; set; }
    }

    //public class NtpStatus
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class OnePpsPresent2
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class OutputAttenuation
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class OutputRfCenterFrequency
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class OutputRfDacSaturation
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class OutputRfDacSaturationPercent
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class OutputRfPort1DacSaturation
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class OutputRfPort1DacSaturationPercent
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class OutputRfPort1Power
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class Data4
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public string data { get; set; }
        public int bitLength { get; set; }
    }

    public class OutputRfPort1Spectrum
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public Data4 data { get; set; }
    }

    public class OutputRfPort2DacSaturation
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class OutputRfPort2DacSaturationPercent
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class OutputRfPort2Power
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class Data5
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public string data { get; set; }
        public int bitLength { get; set; }
    }

    public class OutputRfPort2Spectrum
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public Data5 data { get; set; }
    }

    //public class OutputRfPortSelect
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class OutputRfPower
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class Data6
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public string data { get; set; }
        public int bitLength { get; set; }
    }

    public class OutputRfSpectrum
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public Data6 data { get; set; }
    }

    public class OverrideOutputFrequency
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class OverrideOutputFrequencyEnable
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class PollInterval
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class PosixNanoseconds
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class PosixSeconds
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class RebootRequired
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    //public class ReplyWaitTime
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class RequiredReadPrivilege
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class RequiredWritePrivilege
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class Name
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class BitRate
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class DataSampleWidth
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    //public class DestinationHost
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class DestinationPort
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class FrequencyOffset
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class MaximumPacketSize
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class MeasuredNetworkRate
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class MeasuredPacketRate
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class MinimumProcessingDelay
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class PacketOverhead
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class PfecEnable
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    //public class RouteSearch
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class SourcePort2
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class StreamBandwidth
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class StreamEnable
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class StreamGain
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class StreamId2
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class StreamSampleRate
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class Structure4
    {
        public RestString name { get; set; }
        public BitRate bitRate { get; set; }
        public DataSampleWidth dataSampleWidth { get; set; }
        public RestString destinationHost { get; set; }
        public DestinationPort destinationPort { get; set; }
        public FrequencyOffset frequencyOffset { get; set; }
        public MaximumPacketSize maximumPacketSize { get; set; }
        public MeasuredNetworkRate measuredNetworkRate { get; set; }
        public MeasuredPacketRate measuredPacketRate { get; set; }
        public MinimumProcessingDelay minimumProcessingDelay { get; set; }
        public PacketOverhead packetOverhead { get; set; }
        public PfecEnable pfecEnable { get; set; }
        public RestString routeSearch { get; set; }
        public SourcePort2 sourcePort { get; set; }
        public StreamBandwidth streamBandwidth { get; set; }
        public StreamEnable streamEnable { get; set; }
        public StreamGain streamGain { get; set; }
        public StreamId2 streamId { get; set; }
        public StreamSampleRate streamSampleRate { get; set; }
    }

    public class Array4
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public Structure4 structure { get; set; }
    }

    public class RfInputStream
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public List<Array4> array { get; set; }
    }

    public class RfOutputEnable
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    //public class RfOutputSource
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class RestString
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public string value { get; set; }
    }

    public class RestDouble
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class DataSampleWidth2
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    //public class DataSource
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class DesiredBuffer
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class DesiredDelay
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class DestinationPort2
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class DroppedPackets
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class FrequencyOffset2
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class GapCount
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class MeasuredDelay
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class MeasuredNetworkRate2
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class MeasuredPacketRate2
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class NetStreamGain
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class NetworkDelay
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class PacketOverhead2
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    //public class PfecDecoderStatus
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class PfecMissingSets
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class PfecRepairedPackets
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class PfecTotalPackets
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class PfecUnrepairablePackets
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class PreserveLatency
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class PreserveLatencyLatePackets
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class PreserveLatencyMaxBurstLoss
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class PreserveLatencyMissingPackets
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class PreserveLatencyOutOfOrderPackets
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class PreserveLatencyReleaseMargin
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    //public class ReleaseMode
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class SourceHost
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class SourcePort3
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class StreamBandwidth2
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class StreamEnable2
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class StreamId3
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class StreamSampleRate2
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class UnderflowCount
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    public class UpstreamIrigLocked
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class UpstreamOnePpsLocked
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class UpstreamPathGain
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public double value { get; set; }
    }

    public class UpstreamTenMhzLocked
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class UseLocalReference
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class Structure5
    {
        public RestString name { get; set; }
        public RestDouble currentBuffer { get; set; }
        public DataSampleWidth2 dataSampleWidth { get; set; }
        public DataSource dataSource { get; set; }
        public DesiredBuffer desiredBuffer { get; set; }
        public DesiredDelay desiredDelay { get; set; }
        public DestinationPort2 destinationPort { get; set; }
        public DroppedPackets droppedPackets { get; set; }
        public FrequencyOffset2 frequencyOffset { get; set; }
        public GapCount gapCount { get; set; }
        public MeasuredDelay measuredDelay { get; set; }
        public MeasuredNetworkRate2 measuredNetworkRate { get; set; }
        public MeasuredPacketRate2 measuredPacketRate { get; set; }
        public NetStreamGain netStreamGain { get; set; }
        public NetworkDelay networkDelay { get; set; }
        public PacketOverhead2 packetOverhead { get; set; }
        public PfecDecoderStatus pfecDecoderStatus { get; set; }
        public PfecMissingSets pfecMissingSets { get; set; }
        public PfecRepairedPackets pfecRepairedPackets { get; set; }
        public PfecTotalPackets pfecTotalPackets { get; set; }
        public PfecUnrepairablePackets pfecUnrepairablePackets { get; set; }
        public PreserveLatency preserveLatency { get; set; }
        public PreserveLatencyLatePackets preserveLatencyLatePackets { get; set; }
        public PreserveLatencyMaxBurstLoss preserveLatencyMaxBurstLoss { get; set; }
        public PreserveLatencyMissingPackets preserveLatencyMissingPackets { get; set; }
        public PreserveLatencyOutOfOrderPackets preserveLatencyOutOfOrderPackets { get; set; }
        public PreserveLatencyReleaseMargin preserveLatencyReleaseMargin { get; set; }
        public ReleaseMode releaseMode { get; set; }
        public SourceHost sourceHost { get; set; }
        public SourcePort3 sourcePort { get; set; }
        public StreamBandwidth2 streamBandwidth { get; set; }
        public StreamEnable2 streamEnable { get; set; }
        public StreamId3 streamId { get; set; }
        public StreamSampleRate2 streamSampleRate { get; set; }
        public UnderflowCount underflowCount { get; set; }
        public UpstreamIrigLocked upstreamIrigLocked { get; set; }
        public UpstreamOnePpsLocked upstreamOnePpsLocked { get; set; }
        public UpstreamPathGain upstreamPathGain { get; set; }
        public UpstreamTenMhzLocked upstreamTenMhzLocked { get; set; }
        public UseLocalReference useLocalReference { get; set; }
    }

    public class Array5
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public Structure5 structure { get; set; }
    }

    public class RfOutputStream
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public List<Array5> array { get; set; }
    }

    public class Routes
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public List<object> array { get; set; }
    }

    //public class SecuritySource
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class SerialNumber
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    //public class ShortDescription
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class Simulate
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class SquelchEnabled
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    public class SystemTemperature
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public int value { get; set; }
    }

    //public class SystemTimeSource
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}

    public class TenMhzLocked2
    {
        public string factory { get; set; }
        public string factoryType { get; set; }
        public bool value { get; set; }
    }

    //public class Version
    //{
    //    public string factory { get; set; }
    //    public string factoryType { get; set; }
    //    public string value { get; set; }
    //}
    #endregion
    public class Root
    {
        public RestBool Active { get; set; }
        public RestString Address { get; set; }
        //Array
        public AvailableStreams AvailableStreams { get; set; }
        public RestString CompositeStatus { get; set; }
        public RestString compositeStatusMsg { get; set; }
        public RestString contextPacketState { get; set; }
        public ControlNic controlNic { get; set; }
        public CurrentGain currentGain { get; set; }
        public DataNic dataNic { get; set; }
        public Dependencies dependencies { get; set; }
        public DiscardedPackets discardedPackets { get; set; }
        public EnableMulticastGroupSubscriptions enableMulticastGroupSubscriptions { get; set; }
        public FanSpeed fanSpeed { get; set; }
        public RestString gainMode { get; set; }
        public RestString gateway { get; set; }
        public RestString healthStatus { get; set; } //Status
        public RestString healthStatusMsg { get; set; }
        #region InputRF ignore
        public InputRfAdcSaturation inputRfAdcSaturation { get; set; }
        public InputRfAdcSaturationPercent inputRfAdcSaturationPercent { get; set; }
        public InputRfBandwidth inputRfBandwidth { get; set; }
        public InputRfCenterFrequency inputRfCenterFrequency { get; set; }
        public InputRfPort1AdcSaturation inputRfPort1AdcSaturation { get; set; }
        public InputRfPort1AdcSaturationPercent inputRfPort1AdcSaturationPercent { get; set; }
        public InputRfPort1MinimumGain inputRfPort1MinimumGain { get; set; }
        public InputRfPort1Power inputRfPort1Power { get; set; }
        public InputRfPort1Spectrum inputRfPort1Spectrum { get; set; }
        public InputRfPort2AdcSaturation inputRfPort2AdcSaturation { get; set; }
        public InputRfPort2AdcSaturationPercent inputRfPort2AdcSaturationPercent { get; set; }
        public InputRfPort2MinimumGain inputRfPort2MinimumGain { get; set; }
        public InputRfPort2Power inputRfPort2Power { get; set; }
        public InputRfPort2Spectrum inputRfPort2Spectrum { get; set; }
        public InputRfPortSelect inputRfPortSelect { get; set; }
        public InputRfPower inputRfPower { get; set; }
        public InputRfSampleRate inputRfSampleRate { get; set; }
        public InputRfSpectrum inputRfSpectrum { get; set; }

        #endregion        public InvertRfOutputSpectrum invertRfOutputSpectrum { get; set; }
        public IrigDcLocked irigDcLocked { get; set; }
        public IrigLocked2 irigLocked { get; set; }
        public RestString label { get; set; }
        public RestString logLevel { get; set; }
        public ManualGain manualGain { get; set; }
        public MinimumGain minimumGain { get; set; }
        public RestString moduleState { get; set; }
        public RestString moduleType { get; set; }
        public MulticastGroupSubscriptions multicastGroupSubscriptions { get; set; }
        public RestString ntpStatus { get; set; }
        public OnePpsPresent2 onePpsPresent { get; set; }
        public OutputAttenuation outputAttenuation { get; set; }
        #region OutputRf ignore
        public OutputRfCenterFrequency outputRfCenterFrequency { get; set; }
        public OutputRfDacSaturation outputRfDacSaturation { get; set; }
        public OutputRfDacSaturationPercent outputRfDacSaturationPercent { get; set; }
        public OutputRfPort1DacSaturation outputRfPort1DacSaturation { get; set; }
        public OutputRfPort1DacSaturationPercent outputRfPort1DacSaturationPercent { get; set; }
        public OutputRfPort1Power outputRfPort1Power { get; set; }
        public OutputRfPort1Spectrum outputRfPort1Spectrum { get; set; }
        public OutputRfPort2DacSaturation outputRfPort2DacSaturation { get; set; }
        public OutputRfPort2DacSaturationPercent outputRfPort2DacSaturationPercent { get; set; }
        public OutputRfPort2Power outputRfPort2Power { get; set; }
        public OutputRfPort2Spectrum outputRfPort2Spectrum { get; set; }
        public RestString outputRfPortSelect { get; set; }
        public OutputRfPower outputRfPower { get; set; }
        public OutputRfSpectrum outputRfSpectrum { get; set; }

        #endregion     
        public OverrideOutputFrequency overrideOutputFrequency { get; set; }
        public OverrideOutputFrequencyEnable overrideOutputFrequencyEnable { get; set; }
        public PollInterval pollInterval { get; set; }
        public PosixNanoseconds posixNanoseconds { get; set; }
        public PosixSeconds posixSeconds { get; set; }
        public RebootRequired rebootRequired { get; set; }
        public RestString replyWaitTime { get; set; }
        public RestString requiredReadPrivilege { get; set; }
        public RestString requiredWritePrivilege { get; set; }
        public RfInputStream rfInputStream { get; set; }
        public RfOutputEnable rfOutputEnable { get; set; }
        public RestString rfOutputSource { get; set; }
        public RfOutputStream rfOutputStream { get; set; }
        public Routes routes { get; set; }
        public RestString securitySource { get; set; }
        public RestString serialNumber { get; set; }
        public RestString shortDescription { get; set; }
        public Simulate simulate { get; set; }
        public SquelchEnabled squelchEnabled { get; set; }

        public SystemTemperature systemTemperature { get; set; }
        public RestString systemTimeSource { get; set; }
        public TenMhzLocked2 tenMhzLocked { get; set; }
        public Version version { get; set; }
    }

}

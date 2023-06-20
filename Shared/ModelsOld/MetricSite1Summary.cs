using System;
using System.Collections.Generic;

namespace SnnbFailover.Shared.Models;

public partial class MetricSite1Summary
{
    public int Id { get; set; }

    public DateTime? ExtDateStamp { get; set; }

    public string? ExtSourceUnit { get; set; }

    public string? ExtDestUnit { get; set; }

    public string? ExtDirection { get; set; }

    public int? ExtDisplayOrder { get; set; }

    public bool? ExtCommError { get; set; }

    public bool? ComActive { get; set; }

    public string? ComAddress { get; set; }

    public string? ComCompositeStatus { get; set; }

    public string? ComCompositeStatusMsg { get; set; }

    public string? ComContextPacketState { get; set; }

    public double? ComcurrentGain { get; set; }

    public int? ComdiscardedPackets { get; set; }

    public bool? ComenableMulticastGroupSubscriptions { get; set; }

    public int? ComfanSpeed { get; set; }

    public string? ComgainMode { get; set; }

    public string? Comgateway { get; set; }

    public string? ComhealthStatus { get; set; }

    public string? ComhealthStatusMsg { get; set; }

    public double? CominputRfAdcSaturation { get; set; }

    public double? CominputRfAdcSaturationPercent { get; set; }

    public string? CominputRfBandwidth { get; set; }

    public double? CominputRfCenterFrequency { get; set; }

    public double? CominputRfPort1AdcSaturation { get; set; }

    public double? CominputRfPort1AdcSaturationPercent { get; set; }

    public double? CominputRfPort1MinimumGain { get; set; }

    public double? CominputRfPort1Power { get; set; }

    public double? CominputRfPort2AdcSaturation { get; set; }

    public double? CominputRfPort2AdcSaturationPercent { get; set; }

    public double? CominputRfPort2MinimumGain { get; set; }

    public double? CominputRfPort2Power { get; set; }

    public string? CominputRfPortSelect { get; set; }

    public double? CominputRfPower { get; set; }

    public double? CominputRfSampleRate { get; set; }

    public bool? CominvertRfOutputSpectrum { get; set; }

    public bool? ComirigDcLocked { get; set; }

    public bool? ComirigLocked { get; set; }

    public string? Comlabel { get; set; }

    public string? ComlogLevel { get; set; }

    public double? CommanualGain { get; set; }

    public double? ComminimumGain { get; set; }

    public string? CommoduleState { get; set; }

    public string? CommoduleType { get; set; }

    public string? ComntpStatus { get; set; }

    public bool? ComonePpsPresent { get; set; }

    public double? ComoutputAttenuation { get; set; }

    public double? ComoutputRfCenterFrequency { get; set; }

    public double? ComoutputRfDacSaturation { get; set; }

    public double? ComoutputRfDacSaturationPercent { get; set; }

    public double? ComoutputRfPort1DacSaturation { get; set; }

    public double? ComoutputRfPort1DacSaturationPercent { get; set; }

    public double? ComoutputRfPort1Power { get; set; }

    public double? ComoutputRfPort2DacSaturation { get; set; }

    public double? ComoutputRfPort2DacSaturationPercent { get; set; }

    public double? ComoutputRfPort2Power { get; set; }

    public string? ComoutputRfPortSelect { get; set; }

    public double? ComoutputRfPower { get; set; }

    public double? ComoverrideOutputFrequency { get; set; }

    public bool? ComoverrideOutputFrequencyEnable { get; set; }

    public int? CompollInterval { get; set; }

    public int? ComposixNanoseconds { get; set; }

    public int? ComposixSeconds { get; set; }

    public bool? ComrebootRequired { get; set; }

    public string? ComReplyWaitTime { get; set; }

    public string? ComRequiredReadPrivilege { get; set; }

    public string? ComRequiredWritePrivilege { get; set; }

    public bool? ComRfOutputEnable { get; set; }

    public string? ComRfOutputSource { get; set; }

    public string? ComSecuritySource { get; set; }

    public string? ComSerialNumber { get; set; }

    public string? ComShortDescription { get; set; }

    public bool? ComSimulate { get; set; }

    public bool? ComSquelchEnabled { get; set; }

    public int? ComSystemTemperature { get; set; }

    public string? ComSystemTimeSource { get; set; }

    public bool? ComTenMhzLocked { get; set; }

    public string? ComVersion { get; set; }

    public string? Rfinname { get; set; }

    public double? RfinbitRate { get; set; }

    public int? RfindataSampleWidth { get; set; }

    public string? RfindestinationHost { get; set; }

    public int? RfindestinationPort { get; set; }

    public double? RfinfrequencyOffset { get; set; }

    public double? RfinmaximumPacketSize { get; set; }

    public double? RfinmeasuredNetworkRate { get; set; }

    public double? RfinmeasuredPacketRate { get; set; }

    public double? RfinminimumProcessingDelay { get; set; }

    public double? RfinpacketOverhead { get; set; }

    public bool? RfinpfecEnable { get; set; }

    public string? RfinrouteSearch { get; set; }

    public int? RfinsourcePort { get; set; }

    public double? RfinstreamBandwidth { get; set; }

    public bool? RfinstreamEnable { get; set; }

    public double? RfinstreamGain { get; set; }

    public int? RfinstreamId { get; set; }

    public double? RfinstreamSampleRate { get; set; }

    public string? Rfoutname { get; set; }

    public double? RfoutcurrentBuffer { get; set; }

    public int? RfoutdataSampleWidth { get; set; }

    public string? RfoutdataSource { get; set; }

    public double? RfoutdesiredBuffer { get; set; }

    public double? RfoutdesiredDelay { get; set; }

    public int? RfoutdestinationPort { get; set; }

    public int? RfoutdroppedPackets { get; set; }

    public double? RfoutfrequencyOffset { get; set; }

    public int? RfoutgapCount { get; set; }

    public double? RfoutmeasuredDelay { get; set; }

    public double? RfoutmeasuredNetworkRate { get; set; }

    public double? RfoutmeasuredPacketRate { get; set; }

    public double? RfoutnetStreamGain { get; set; }

    public double? RfoutnetworkDelay { get; set; }

    public double? RfoutpacketOverhead { get; set; }

    public string? RfoutpfecDecoderStatus { get; set; }

    public int? RfoutpfecMissingSets { get; set; }

    public int? RfoutpfecRepairedPackets { get; set; }

    public int? RfoutpfecTotalPackets { get; set; }

    public int? RfoutpfecUnrepairablePackets { get; set; }

    public bool? RfoutpreserveLatency { get; set; }

    public int? RfoutpreserveLatencyLatePackets { get; set; }

    public int? RfoutpreserveLatencyMaxBurstLoss { get; set; }

    public int? RfoutpreserveLatencyMissingPackets { get; set; }

    public int? RfoutpreserveLatencyOutOfOrderPackets { get; set; }

    public int? RfoutpreserveLatencyReleaseMargin { get; set; }

    public string? RfoutreleaseMode { get; set; }

    public string? RfoutsourceHost { get; set; }

    public int? RfoutsourcePort { get; set; }

    public double? RfoutstreamBandwidth { get; set; }

    public bool? RfoutstreamEnable { get; set; }

    public int? RfoutstreamId { get; set; }

    public double? RfoutstreamSampleRate { get; set; }

    public int? RfoutunderflowCount { get; set; }

    public bool? RfoutupstreamIrigLocked { get; set; }

    public bool? RfoutupstreamOnePpsLocked { get; set; }

    public double? RfoutupstreamPathGain { get; set; }

    public bool? RfoutupstreamTenMhzLocked { get; set; }

    public bool? RfoutuseLocalReference { get; set; }
}

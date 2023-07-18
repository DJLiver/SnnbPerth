using SpectralNetCollector.Collect;
using SpectralNetCollector.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpectralNetCollector.Database
{
    partial class MetricEvent
    {
        internal static void Add(MetricEvent ms)
        {
            using (var cdc = new DataClasses1DataContext())
            {
                cdc.MetricEvent.InsertOnSubmit(ms);
                cdc.SubmitChanges();
            }
        }
    }

    partial class MetricSite2Summary
    {
        internal static MetricSite2Summary GetSourceRow(string unit)
        {
            using (var cdc = new DataClasses1DataContext())
            {
                var v = from f in cdc.MetricSite2Summaries
                        where f.ExtSourceUnit == unit
                        select f;
                return v.First();
            }
        }

        internal static MetricSite2Summary GetDestRow(string unit)
        {
            using (var cdc = new DataClasses1DataContext())
            {
                var v = from f in cdc.MetricSite2Summaries
                        where f.ExtDestUnit == unit
                        select f;
                return v.First();
            }
        }

        internal static void CreateRow(Target item)
        {
            using (var cdc = new DataClasses1DataContext())
            {
                var v = from f in cdc.MetricSite2Summaries
                        where f.ExtSourceUnit == item.Name
                        select f;
                if (v.Count() == 0)
                {
                    MetricSite2Summary ms = new MetricSite2Summary()
                    {
                        ExtSourceUnit = item.Name,
                        ExtDestUnit = item.RemoteUnit,
                        ExtDirection = item.Direction,
                        ExtDisplayOrder = item.DisplayOrder
                    };
                    cdc.MetricSite2Summaries.InsertOnSubmit(ms);
                    cdc.SubmitChanges();
                }
            }
        }

        internal static void UpdateSummary(SNdata sNdata)
        {
            using (var cdc = new DataClasses1DataContext())
            {
                var v = from f in cdc.MetricSite2Summaries
                        where f.ExtSourceUnit == sNdata.Name
                        select f;
                if (v.Count() != 1)
                {
                    return;
                }
                MetricSite2Summary ms = v.First();
                ms.ExtDateStamp = sNdata.DateStamp;
                ms.ComActive = sNdata.Data.Active.Value;
                ms.ComAddress = sNdata.Data.Address.Value;
                ms.ComCompositeStatus = sNdata.Data.CompositeStatus.Value;
                ms.ComCompositeStatusMsg = sNdata.Data.CompositeStatusMsg.Value;
                ms.ComContextPacketState = sNdata.Data.ContextPacketState.Value;
                ms.ComcurrentGain = sNdata.Data.currentGain.Value;
                ms.ComdiscardedPackets = (int)sNdata.Data.discardedPackets.Value;
                ms.ComenableMulticastGroupSubscriptions = sNdata.Data.enableMulticastGroupSubscriptions.Value;
                ms.ComfanSpeed = sNdata.Data.fanSpeed.Value;
                ms.ComgainMode = sNdata.Data.gainMode.Value;
                ms.Comgateway = sNdata.Data.gateway.Value;
                ms.ComhealthStatus = sNdata.Data.healthStatus.Value;
                ms.ComhealthStatusMsg = sNdata.Data.healthStatusMsg.Value;
                ms.CominputRfAdcSaturation = sNdata.Data.inputRfAdcSaturation.Value;
                ms.CominputRfAdcSaturationPercent = sNdata.Data.inputRfAdcSaturationPercent.Value;
                ms.CominputRfBandwidth = sNdata.Data.inputRfBandwidth.Value;
                ms.CominputRfCenterFrequency = sNdata.Data.inputRfCenterFrequency.Value;
                ms.CominputRfPort1AdcSaturation = sNdata.Data.inputRfPort1AdcSaturation.Value;
                ms.CominputRfPort1AdcSaturationPercent = sNdata.Data.inputRfPort1AdcSaturationPercent.Value;
                ms.CominputRfPort1MinimumGain = sNdata.Data.inputRfPort1MinimumGain.Value;
                ms.CominputRfPort1Power = sNdata.Data.inputRfPort1Power.Value;
                ms.CominputRfPort2AdcSaturation = sNdata.Data.inputRfPort2AdcSaturation.Value;
                ms.CominputRfPort2AdcSaturationPercent = sNdata.Data.inputRfPort2AdcSaturationPercent.Value;
                ms.CominputRfPort2MinimumGain = sNdata.Data.inputRfPort2MinimumGain.Value;
                ms.CominputRfPort2Power = sNdata.Data.inputRfPort2Power.Value;
                ms.CominputRfPortSelect = sNdata.Data.inputRfPortSelect.Value;
                ms.CominputRfPower = sNdata.Data.inputRfPower.Value;
                ms.CominputRfSampleRate = sNdata.Data.inputRfSampleRate.Value;

                ms.CominvertRfOutputSpectrum = sNdata.Data.invertRfOutputSpectrum.Value;
                ms.ComirigDcLocked = sNdata.Data.irigDcLocked.Value;
                ms.ComirigLocked = sNdata.Data.irigLocked.Value;
                ms.Comlabel = sNdata.Data.label.Value;
                ms.ComlogLevel = sNdata.Data.logLevel.Value;
                ms.CommanualGain = sNdata.Data.manualGain.Value;
                ms.ComminimumGain = sNdata.Data.minimumGain.Value;
                ms.CommoduleState = sNdata.Data.moduleState.Value;
                ms.CommoduleType = sNdata.Data.moduleType.Value;
                ms.ComntpStatus = sNdata.Data.ntpStatus.Value;
                ms.ComonePpsPresent = sNdata.Data.onePpsPresent.Value;
                ms.ComoutputAttenuation = sNdata.Data.outputAttenuation.Value;
                ms.ComoutputRfCenterFrequency = sNdata.Data.outputRfCenterFrequency.Value;
                ms.ComoutputRfDacSaturation = sNdata.Data.outputRfDacSaturation.Value;
                ms.ComoutputRfDacSaturationPercent = sNdata.Data.outputRfDacSaturationPercent.Value;
                ms.ComoutputRfPort1DacSaturation = sNdata.Data.outputRfPort1DacSaturation.Value;
                ms.ComoutputRfPort1DacSaturationPercent = sNdata.Data.outputRfPort1DacSaturationPercent.Value;
                ms.ComoutputRfPort1Power = sNdata.Data.outputRfPort1Power.Value;
                ms.ComoutputRfPort2DacSaturation = sNdata.Data.outputRfPort2DacSaturation.Value;
                ms.ComoutputRfPort2DacSaturationPercent = sNdata.Data.outputRfPort2DacSaturationPercent.Value;
                ms.ComoutputRfPort2Power = sNdata.Data.outputRfPort2Power.Value;
                ms.ComoutputRfPortSelect = sNdata.Data.outputRfPortSelect.Value;
                ms.ComoutputRfPower = sNdata.Data.outputRfPower.Value;
                ms.ComoverrideOutputFrequency = sNdata.Data.overrideOutputFrequency.Value;
                ms.ComoverrideOutputFrequencyEnable = sNdata.Data.overrideOutputFrequencyEnable.Value;
                ms.CompollInterval = (int)sNdata.Data.pollInterval.Value;
                ms.ComposixNanoseconds = (int)sNdata.Data.posixNanoseconds.Value;
                ms.ComposixSeconds = (int)sNdata.Data.posixSeconds.Value;
                ms.ComrebootRequired = sNdata.Data.rebootRequired.Value;
                ms.ComReplyWaitTime = sNdata.Data.ReplyWaitTime.Value;
                ms.ComRequiredReadPrivilege = sNdata.Data.RequiredReadPrivilege.Value;
                ms.ComRequiredWritePrivilege = sNdata.Data.RequiredWritePrivilege.Value;
                ms.ComRfOutputEnable = sNdata.Data.RfOutputEnable.Value;
                ms.ComRfOutputSource = sNdata.Data.RfOutputSource.Value;
                ms.ComSecuritySource = sNdata.Data.SecuritySource.Value;
                ms.ComSerialNumber = sNdata.Data.SerialNumber.Value;
                ms.ComShortDescription = sNdata.Data.ShortDescription.Value;
                ms.ComSimulate = sNdata.Data.Simulate.Value;
                ms.ComSquelchEnabled = sNdata.Data.SquelchEnabled.Value;
                ms.ComSystemTemperature = sNdata.Data.SystemTemperature.Value;
                ms.ComSystemTimeSource = sNdata.Data.SystemTimeSource.Value;
                ms.ComTenMhzLocked = sNdata.Data.TenMhzLocked.Value;
                ms.ComVersion = sNdata.Data.Version.Value;

                ms.RFinname = sNdata.Data.RfInputStream.array[0].structure.name.Value;
                ms.RFinbitRate = sNdata.Data.RfInputStream.array[0].structure.bitRate.Value;
                ms.RFindataSampleWidth = sNdata.Data.RfInputStream.array[0].structure.dataSampleWidth.Value;
                ms.RFindestinationHost = sNdata.Data.RfInputStream.array[0].structure.destinationHost.Value;
                ms.RFindestinationPort = sNdata.Data.RfInputStream.array[0].structure.destinationPort.Value;
                ms.RFinfrequencyOffset = sNdata.Data.RfInputStream.array[0].structure.frequencyOffset.Value;
                ms.RFinmaximumPacketSize = sNdata.Data.RfInputStream.array[0].structure.maximumPacketSize.Value;
                ms.RFinmeasuredNetworkRate = sNdata.Data.RfInputStream.array[0].structure.measuredNetworkRate.Value;
                ms.RFinmeasuredPacketRate = sNdata.Data.RfInputStream.array[0].structure.measuredPacketRate.Value;
                ms.RFinminimumProcessingDelay = sNdata.Data.RfInputStream.array[0].structure.minimumProcessingDelay.Value;
                ms.RFinpacketOverhead = sNdata.Data.RfInputStream.array[0].structure.packetOverhead.Value;
                ms.RFinpfecEnable = sNdata.Data.RfInputStream.array[0].structure.pfecEnable.Value;
                ms.RFinrouteSearch = sNdata.Data.RfInputStream.array[0].structure.routeSearch.Value;
                ms.RFinsourcePort = sNdata.Data.RfInputStream.array[0].structure.sourcePort.Value;
                ms.RFinstreamBandwidth = sNdata.Data.RfInputStream.array[0].structure.streamBandwidth.Value;
                ms.RFinstreamEnable = sNdata.Data.RfInputStream.array[0].structure.streamEnable.Value;
                ms.RFinstreamGain = sNdata.Data.RfInputStream.array[0].structure.streamGain.Value;
                ms.RFinstreamId = (int)sNdata.Data.RfInputStream.array[0].structure.streamId.Value;
                ms.RFinstreamSampleRate = sNdata.Data.RfInputStream.array[0].structure.streamSampleRate.Value;

                ms.RFoutname = sNdata.Data.RfOutputStream.array[0].structure.name.Value;
                ms.RFoutcurrentBuffer = sNdata.Data.RfOutputStream.array[0].structure.currentBuffer.Value;
                ms.RFoutdataSampleWidth = sNdata.Data.RfOutputStream.array[0].structure.dataSampleWidth.Value;
                ms.RFoutdataSource = sNdata.Data.RfOutputStream.array[0].structure.dataSource.Value;
                ms.RFoutdesiredBuffer = sNdata.Data.RfOutputStream.array[0].structure.desiredBuffer.Value;
                ms.RFoutdesiredDelay = sNdata.Data.RfOutputStream.array[0].structure.desiredDelay.Value;
                ms.RFoutdestinationPort = sNdata.Data.RfOutputStream.array[0].structure.destinationPort.Value;
                ms.RFoutdroppedPackets = (int)sNdata.Data.RfOutputStream.array[0].structure.droppedPackets.Value;
                ms.RFoutfrequencyOffset = sNdata.Data.RfOutputStream.array[0].structure.frequencyOffset.Value;
                ms.RFoutgapCount = (int)sNdata.Data.RfOutputStream.array[0].structure.gapCount.Value;
                ms.RFoutmeasuredDelay = sNdata.Data.RfOutputStream.array[0].structure.measuredDelay.Value;
                ms.RFoutmeasuredNetworkRate = sNdata.Data.RfOutputStream.array[0].structure.measuredNetworkRate.Value;
                ms.RFoutmeasuredPacketRate = sNdata.Data.RfOutputStream.array[0].structure.measuredPacketRate.Value;
                ms.RFoutnetStreamGain = sNdata.Data.RfOutputStream.array[0].structure.netStreamGain.Value;
                ms.RFoutnetworkDelay = sNdata.Data.RfOutputStream.array[0].structure.networkDelay.Value;
                ms.RFoutpacketOverhead = sNdata.Data.RfOutputStream.array[0].structure.packetOverhead.Value;
                ms.RFoutpfecDecoderStatus = sNdata.Data.RfOutputStream.array[0].structure.pfecDecoderStatus.Value;
                ms.RFoutpfecMissingSets = (int)sNdata.Data.RfOutputStream.array[0].structure.pfecMissingSets.Value;
                ms.RFoutpfecRepairedPackets = (int)sNdata.Data.RfOutputStream.array[0].structure.pfecRepairedPackets.Value;
                ms.RFoutpfecTotalPackets = (int)sNdata.Data.RfOutputStream.array[0].structure.pfecTotalPackets.Value;
                ms.RFoutpfecUnrepairablePackets = (int)sNdata.Data.RfOutputStream.array[0].structure.pfecUnrepairablePackets.Value;
                ms.RFoutpreserveLatency = sNdata.Data.RfOutputStream.array[0].structure.preserveLatency.Value;
                ms.RFoutpreserveLatencyLatePackets = (int)sNdata.Data.RfOutputStream.array[0].structure.preserveLatencyLatePackets.Value;
                ms.RFoutpreserveLatencyMaxBurstLoss = (int)sNdata.Data.RfOutputStream.array[0].structure.preserveLatencyMaxBurstLoss.Value;
                ms.RFoutpreserveLatencyMissingPackets = (int)sNdata.Data.RfOutputStream.array[0].structure.preserveLatencyMissingPackets.Value;
                ms.RFoutpreserveLatencyOutOfOrderPackets = (int)sNdata.Data.RfOutputStream.array[0].structure.preserveLatencyOutOfOrderPackets.Value;
                ms.RFoutpreserveLatencyReleaseMargin = (int)sNdata.Data.RfOutputStream.array[0].structure.preserveLatencyReleaseMargin.Value;
                ms.RFoutreleaseMode = sNdata.Data.RfOutputStream.array[0].structure.releaseMode.Value;
                ms.RFoutsourceHost = sNdata.Data.RfOutputStream.array[0].structure.sourceHost.Value;
                ms.RFoutsourcePort = sNdata.Data.RfOutputStream.array[0].structure.sourcePort.Value;
                ms.RFoutstreamBandwidth = sNdata.Data.RfOutputStream.array[0].structure.streamBandwidth.Value;
                ms.RFoutstreamEnable = sNdata.Data.RfOutputStream.array[0].structure.streamEnable.Value;
                ms.RFoutstreamId = (int)sNdata.Data.RfOutputStream.array[0].structure.streamId.Value;
                ms.RFoutstreamSampleRate = sNdata.Data.RfOutputStream.array[0].structure.streamSampleRate.Value;
                ms.RFoutunderflowCount = (int)sNdata.Data.RfOutputStream.array[0].structure.underflowCount.Value;
                ms.RFoutupstreamIrigLocked = sNdata.Data.RfOutputStream.array[0].structure.upstreamIrigLocked.Value;
                ms.RFoutupstreamOnePpsLocked = sNdata.Data.RfOutputStream.array[0].structure.upstreamOnePpsLocked.Value;
                ms.RFoutupstreamPathGain = sNdata.Data.RfOutputStream.array[0].structure.upstreamPathGain.Value;
                ms.RFoutupstreamTenMhzLocked = sNdata.Data.RfOutputStream.array[0].structure.upstreamTenMhzLocked.Value;
                ms.RFoutuseLocalReference = sNdata.Data.RfOutputStream.array[0].structure.useLocalReference.Value;

                cdc.SubmitChanges();
            }
        }
    }

    partial class MetricSite1Summary
    {
        internal static MetricSite1Summary GetSourceRow(string unit)
        {
            using (var cdc = new DataClasses1DataContext())
            {
                var v = from f in cdc.MetricSite1Summaries
                        where f.ExtSourceUnit == unit
                        select f;
                return v.First();
            }
        }

        internal static MetricSite1Summary GetDestRow(string unit)
        {
            using (var cdc = new DataClasses1DataContext())
            {
                var v = from f in cdc.MetricSite1Summaries
                        where f.ExtDestUnit == unit
                        select f;
                return v.First();
            }
        }

        internal static void CreateRow(Target item)
        {
            using (var cdc = new DataClasses1DataContext())
            {
                var v = from f in cdc.MetricSite1Summaries
                        where f.ExtSourceUnit == item.Name
                        select f;
                if (v.Count() == 0)
                {
                    MetricSite1Summary ms = new MetricSite1Summary()
                    {
                        ExtSourceUnit = item.Name,
                        ExtDestUnit = item.RemoteUnit,
                        ExtDirection = item.Direction,
                        ExtDisplayOrder = item.DisplayOrder
                    };
                    cdc.MetricSite1Summaries.InsertOnSubmit(ms);
                    cdc.SubmitChanges();
                }
            }
        }

        internal static void UpdateSummary(SNdata sNdata)
        {
            using (var cdc = new DataClasses1DataContext())
            {
                var v = from f in cdc.MetricSite1Summaries
                        where f.ExtSourceUnit == sNdata.Name
                        select f;
                if (v.Count() != 1)
                {
                    return;
                }
                MetricSite1Summary ms = v.First();
                ms.ExtDateStamp = sNdata.DateStamp;
                ms.ComActive = sNdata.Data.Active.Value;
                ms.ComAddress = sNdata.Data.Address.Value;
                ms.ComCompositeStatus = sNdata.Data.CompositeStatus.Value;
                ms.ComCompositeStatusMsg = sNdata.Data.CompositeStatusMsg.Value;
                ms.ComContextPacketState = sNdata.Data.ContextPacketState.Value;
                ms.ComcurrentGain = sNdata.Data.currentGain.Value;
                ms.ComdiscardedPackets = (int)sNdata.Data.discardedPackets.Value;
                ms.ComenableMulticastGroupSubscriptions = sNdata.Data.enableMulticastGroupSubscriptions.Value;
                ms.ComfanSpeed = sNdata.Data.fanSpeed.Value;
                ms.ComgainMode = sNdata.Data.gainMode.Value;
                ms.Comgateway = sNdata.Data.gateway.Value;
                ms.ComhealthStatus = sNdata.Data.healthStatus.Value;
                ms.ComhealthStatusMsg = sNdata.Data.healthStatusMsg.Value;
                ms.CominputRfAdcSaturation = sNdata.Data.inputRfAdcSaturation.Value;
                ms.CominputRfAdcSaturationPercent = sNdata.Data.inputRfAdcSaturationPercent.Value;
                ms.CominputRfBandwidth = sNdata.Data.inputRfBandwidth.Value;
                ms.CominputRfCenterFrequency = sNdata.Data.inputRfCenterFrequency.Value;
                ms.CominputRfPort1AdcSaturation = sNdata.Data.inputRfPort1AdcSaturation.Value;
                ms.CominputRfPort1AdcSaturationPercent = sNdata.Data.inputRfPort1AdcSaturationPercent.Value;
                ms.CominputRfPort1MinimumGain = sNdata.Data.inputRfPort1MinimumGain.Value;
                ms.CominputRfPort1Power = sNdata.Data.inputRfPort1Power.Value;
                ms.CominputRfPort2AdcSaturation = sNdata.Data.inputRfPort2AdcSaturation.Value;
                ms.CominputRfPort2AdcSaturationPercent = sNdata.Data.inputRfPort2AdcSaturationPercent.Value;
                ms.CominputRfPort2MinimumGain = sNdata.Data.inputRfPort2MinimumGain.Value;
                ms.CominputRfPort2Power = sNdata.Data.inputRfPort2Power.Value;
                ms.CominputRfPortSelect = sNdata.Data.inputRfPortSelect.Value;
                ms.CominputRfPower = sNdata.Data.inputRfPower.Value;
                ms.CominputRfSampleRate = sNdata.Data.inputRfSampleRate.Value;

                ms.CominvertRfOutputSpectrum = sNdata.Data.invertRfOutputSpectrum.Value;
                ms.ComirigDcLocked = sNdata.Data.irigDcLocked.Value;
                ms.ComirigLocked = sNdata.Data.irigLocked.Value;
                ms.Comlabel = sNdata.Data.label.Value;
                ms.ComlogLevel = sNdata.Data.logLevel.Value;
                ms.CommanualGain = sNdata.Data.manualGain.Value;
                ms.ComminimumGain = sNdata.Data.minimumGain.Value;
                ms.CommoduleState = sNdata.Data.moduleState.Value;
                ms.CommoduleType = sNdata.Data.moduleType.Value;
                ms.ComntpStatus = sNdata.Data.ntpStatus.Value;
                ms.ComonePpsPresent = sNdata.Data.onePpsPresent.Value;
                ms.ComoutputAttenuation = sNdata.Data.outputAttenuation.Value;
                ms.ComoutputRfCenterFrequency = sNdata.Data.outputRfCenterFrequency.Value;
                ms.ComoutputRfDacSaturation = sNdata.Data.outputRfDacSaturation.Value;
                ms.ComoutputRfDacSaturationPercent = sNdata.Data.outputRfDacSaturationPercent.Value;
                ms.ComoutputRfPort1DacSaturation = sNdata.Data.outputRfPort1DacSaturation.Value;
                ms.ComoutputRfPort1DacSaturationPercent = sNdata.Data.outputRfPort1DacSaturationPercent.Value;
                ms.ComoutputRfPort1Power = sNdata.Data.outputRfPort1Power.Value;
                ms.ComoutputRfPort2DacSaturation = sNdata.Data.outputRfPort2DacSaturation.Value;
                ms.ComoutputRfPort2DacSaturationPercent = sNdata.Data.outputRfPort2DacSaturationPercent.Value;
                ms.ComoutputRfPort2Power = sNdata.Data.outputRfPort2Power.Value;
                ms.ComoutputRfPortSelect = sNdata.Data.outputRfPortSelect.Value;
                ms.ComoutputRfPower = sNdata.Data.outputRfPower.Value;
                ms.ComoverrideOutputFrequency = sNdata.Data.overrideOutputFrequency.Value;
                ms.ComoverrideOutputFrequencyEnable = sNdata.Data.overrideOutputFrequencyEnable.Value;
                ms.CompollInterval = (int)sNdata.Data.pollInterval.Value;
                ms.ComposixNanoseconds = (int)sNdata.Data.posixNanoseconds.Value;
                ms.ComposixSeconds = (int)sNdata.Data.posixSeconds.Value;
                ms.ComrebootRequired = sNdata.Data.rebootRequired.Value;
                ms.ComReplyWaitTime = sNdata.Data.ReplyWaitTime.Value;
                ms.ComRequiredReadPrivilege = sNdata.Data.RequiredReadPrivilege.Value;
                ms.ComRequiredWritePrivilege = sNdata.Data.RequiredWritePrivilege.Value;
                ms.ComRfOutputEnable = sNdata.Data.RfOutputEnable.Value;
                ms.ComRfOutputSource = sNdata.Data.RfOutputSource.Value;
                ms.ComSecuritySource = sNdata.Data.SecuritySource.Value;
                ms.ComSerialNumber = sNdata.Data.SerialNumber.Value;
                ms.ComShortDescription = sNdata.Data.ShortDescription.Value;
                ms.ComSimulate = sNdata.Data.Simulate.Value;
                ms.ComSquelchEnabled = sNdata.Data.SquelchEnabled.Value;
                ms.ComSystemTemperature = sNdata.Data.SystemTemperature.Value;
                ms.ComSystemTimeSource = sNdata.Data.SystemTimeSource.Value;
                ms.ComTenMhzLocked = sNdata.Data.TenMhzLocked.Value;
                ms.ComVersion = sNdata.Data.Version.Value;

                ms.RFinname = sNdata.Data.RfInputStream.array[0].structure.name.Value;
                ms.RFinbitRate = sNdata.Data.RfInputStream.array[0].structure.bitRate.Value;
                ms.RFindataSampleWidth = sNdata.Data.RfInputStream.array[0].structure.dataSampleWidth.Value;
                ms.RFindestinationHost = sNdata.Data.RfInputStream.array[0].structure.destinationHost.Value;
                ms.RFindestinationPort = sNdata.Data.RfInputStream.array[0].structure.destinationPort.Value;
                ms.RFinfrequencyOffset = sNdata.Data.RfInputStream.array[0].structure.frequencyOffset.Value;
                ms.RFinmaximumPacketSize = sNdata.Data.RfInputStream.array[0].structure.maximumPacketSize.Value;
                ms.RFinmeasuredNetworkRate = sNdata.Data.RfInputStream.array[0].structure.measuredNetworkRate.Value;
                ms.RFinmeasuredPacketRate = sNdata.Data.RfInputStream.array[0].structure.measuredPacketRate.Value;
                ms.RFinminimumProcessingDelay = sNdata.Data.RfInputStream.array[0].structure.minimumProcessingDelay.Value;
                ms.RFinpacketOverhead = sNdata.Data.RfInputStream.array[0].structure.packetOverhead.Value;
                ms.RFinpfecEnable = sNdata.Data.RfInputStream.array[0].structure.pfecEnable.Value;
                ms.RFinrouteSearch = sNdata.Data.RfInputStream.array[0].structure.routeSearch.Value;
                ms.RFinsourcePort = sNdata.Data.RfInputStream.array[0].structure.sourcePort.Value;
                ms.RFinstreamBandwidth = sNdata.Data.RfInputStream.array[0].structure.streamBandwidth.Value;
                ms.RFinstreamEnable = sNdata.Data.RfInputStream.array[0].structure.streamEnable.Value;
                ms.RFinstreamGain = sNdata.Data.RfInputStream.array[0].structure.streamGain.Value;
                ms.RFinstreamId = (int)sNdata.Data.RfInputStream.array[0].structure.streamId.Value;
                ms.RFinstreamSampleRate = sNdata.Data.RfInputStream.array[0].structure.streamSampleRate.Value;

                ms.RFoutname = sNdata.Data.RfOutputStream.array[0].structure.name.Value;
                ms.RFoutcurrentBuffer = sNdata.Data.RfOutputStream.array[0].structure.currentBuffer.Value;
                ms.RFoutdataSampleWidth = sNdata.Data.RfOutputStream.array[0].structure.dataSampleWidth.Value;
                ms.RFoutdataSource = sNdata.Data.RfOutputStream.array[0].structure.dataSource.Value;
                ms.RFoutdesiredBuffer = sNdata.Data.RfOutputStream.array[0].structure.desiredBuffer.Value;
                ms.RFoutdesiredDelay = sNdata.Data.RfOutputStream.array[0].structure.desiredDelay.Value;
                ms.RFoutdestinationPort = sNdata.Data.RfOutputStream.array[0].structure.destinationPort.Value;
                ms.RFoutdroppedPackets = (int)sNdata.Data.RfOutputStream.array[0].structure.droppedPackets.Value;
                ms.RFoutfrequencyOffset = sNdata.Data.RfOutputStream.array[0].structure.frequencyOffset.Value;
                ms.RFoutgapCount = (int)sNdata.Data.RfOutputStream.array[0].structure.gapCount.Value;
                ms.RFoutmeasuredDelay = sNdata.Data.RfOutputStream.array[0].structure.measuredDelay.Value;
                ms.RFoutmeasuredNetworkRate = sNdata.Data.RfOutputStream.array[0].structure.measuredNetworkRate.Value;
                ms.RFoutmeasuredPacketRate = sNdata.Data.RfOutputStream.array[0].structure.measuredPacketRate.Value;
                ms.RFoutnetStreamGain = sNdata.Data.RfOutputStream.array[0].structure.netStreamGain.Value;
                ms.RFoutnetworkDelay = sNdata.Data.RfOutputStream.array[0].structure.networkDelay.Value;
                ms.RFoutpacketOverhead = sNdata.Data.RfOutputStream.array[0].structure.packetOverhead.Value;
                ms.RFoutpfecDecoderStatus = sNdata.Data.RfOutputStream.array[0].structure.pfecDecoderStatus.Value;
                ms.RFoutpfecMissingSets = (int)sNdata.Data.RfOutputStream.array[0].structure.pfecMissingSets.Value;
                ms.RFoutpfecRepairedPackets = (int)sNdata.Data.RfOutputStream.array[0].structure.pfecRepairedPackets.Value;
                ms.RFoutpfecTotalPackets = (int)sNdata.Data.RfOutputStream.array[0].structure.pfecTotalPackets.Value;
                ms.RFoutpfecUnrepairablePackets = (int)sNdata.Data.RfOutputStream.array[0].structure.pfecUnrepairablePackets.Value;
                ms.RFoutpreserveLatency = sNdata.Data.RfOutputStream.array[0].structure.preserveLatency.Value;
                ms.RFoutpreserveLatencyLatePackets = (int)sNdata.Data.RfOutputStream.array[0].structure.preserveLatencyLatePackets.Value;
                ms.RFoutpreserveLatencyMaxBurstLoss = (int)sNdata.Data.RfOutputStream.array[0].structure.preserveLatencyMaxBurstLoss.Value;
                ms.RFoutpreserveLatencyMissingPackets = (int)sNdata.Data.RfOutputStream.array[0].structure.preserveLatencyMissingPackets.Value;
                ms.RFoutpreserveLatencyOutOfOrderPackets = (int)sNdata.Data.RfOutputStream.array[0].structure.preserveLatencyOutOfOrderPackets.Value;
                ms.RFoutpreserveLatencyReleaseMargin = (int)sNdata.Data.RfOutputStream.array[0].structure.preserveLatencyReleaseMargin.Value;
                ms.RFoutreleaseMode = sNdata.Data.RfOutputStream.array[0].structure.releaseMode.Value;
                ms.RFoutsourceHost = sNdata.Data.RfOutputStream.array[0].structure.sourceHost.Value;
                ms.RFoutsourcePort = sNdata.Data.RfOutputStream.array[0].structure.sourcePort.Value;
                ms.RFoutstreamBandwidth = sNdata.Data.RfOutputStream.array[0].structure.streamBandwidth.Value;
                ms.RFoutstreamEnable = sNdata.Data.RfOutputStream.array[0].structure.streamEnable.Value;
                ms.RFoutstreamId = (int)sNdata.Data.RfOutputStream.array[0].structure.streamId.Value;
                ms.RFoutstreamSampleRate = sNdata.Data.RfOutputStream.array[0].structure.streamSampleRate.Value;
                ms.RFoutunderflowCount = (int)sNdata.Data.RfOutputStream.array[0].structure.underflowCount.Value;
                ms.RFoutupstreamIrigLocked = sNdata.Data.RfOutputStream.array[0].structure.upstreamIrigLocked.Value;
                ms.RFoutupstreamOnePpsLocked = sNdata.Data.RfOutputStream.array[0].structure.upstreamOnePpsLocked.Value;
                ms.RFoutupstreamPathGain = sNdata.Data.RfOutputStream.array[0].structure.upstreamPathGain.Value;
                ms.RFoutupstreamTenMhzLocked = sNdata.Data.RfOutputStream.array[0].structure.upstreamTenMhzLocked.Value;
                ms.RFoutuseLocalReference = sNdata.Data.RfOutputStream.array[0].structure.useLocalReference.Value;

                cdc.SubmitChanges();
            }
        }
    }


    partial class MetricCount
    {
        internal static void Add(MetricCount attrCount)
        {
            using (var cdc = new DataClasses1DataContext())
            {
                cdc.MetricCounts.InsertOnSubmit(attrCount);
                cdc.SubmitChanges();
            }
        }
    }

    partial class MetricConfig
    {
        internal static void Add(MetricConfig mc)
        {
            using (var cdc = new DataClasses1DataContext())
            {
                cdc.MetricConfigs.InsertOnSubmit(mc);
                cdc.SubmitChanges();
            }
        }
    }

    partial class DatabaseMaint
    {
        internal static DatabaseMaint GetDB_Maint()
        {
            using (var cdc = new DataClasses1DataContext())
            {
                var v = from f in cdc.DatabaseMaints
                        select f;
                if (v.Count() > 0)
                {
                    return v.First();
                }
                return null;
            }
        }
        internal static bool DeleteMonitor(int days)
        {
            using (var cdc = new DataClasses1DataContext())
            {
                var v = from f in cdc.MetricMonitors
#if TEST
            where f.DateStamp < DateTime.UtcNow.Subtract(TimeSpan.FromMinutes(5))
#else
                        where f.DateStamp < DateTime.UtcNow.Subtract(TimeSpan.FromDays(days))
#endif
                        select f;

                cdc.MetricMonitors.DeleteAllOnSubmit(v);
                cdc.SubmitChanges();
                return true;
            }
        }
    }

    partial class MetricMonitor
    {
        internal static void Add(MetricMonitor m)
        {
            DataClasses1DataContext cdc = new DataClasses1DataContext();
            cdc.MetricMonitors.InsertOnSubmit(m);
            cdc.SubmitChanges();
        }
    }

    partial class Target
    {
        private static DataClasses1DataContext cdc = new DataClasses1DataContext();
        internal static List<Target> GetTargets()
        {
            var v = from f in cdc.Targets
                    where f.Enabled == true
                    select f;
            return v.ToList();
        }
    }
}

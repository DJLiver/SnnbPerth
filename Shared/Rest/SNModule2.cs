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




//public class SNModule
//{
//    public Active active { get; set; }
//    public Address address { get; set; }
//    public Availablestreams availableStreams { get; set; }
//    public Compositestatus compositeStatus { get; set; }
//    public Compositestatusmsg compositeStatusMsg { get; set; }
//    public Contextpacketstate contextPacketState { get; set; }
//    public Controlnic controlNic { get; set; }
//    public Currentgain currentGain { get; set; }
//    public Datanic dataNic { get; set; }
//    public Dependencies dependencies { get; set; }
//    public Discardedpackets discardedPackets { get; set; }
//    public Enablemulticastgroupsubscriptions enableMulticastGroupSubscriptions { get; set; }
//    public Fanspeed fanSpeed { get; set; }
//    public Gainmode gainMode { get; set; }
//    public Gateway gateway { get; set; }
//    public Healthstatus healthStatus { get; set; }
//    public Healthstatusmsg healthStatusMsg { get; set; }
//    public Inputrfadcsaturation inputRfAdcSaturation { get; set; }
//    public Inputrfadcsaturationpercent inputRfAdcSaturationPercent { get; set; }
//    public Inputrfbandwidth inputRfBandwidth { get; set; }
//    public Inputrfcenterfrequency inputRfCenterFrequency { get; set; }
//    public Inputrfport1adcsaturation inputRfPort1AdcSaturation { get; set; }
//    public Inputrfport1adcsaturationpercent inputRfPort1AdcSaturationPercent { get; set; }
//    public Inputrfport1minimumgain inputRfPort1MinimumGain { get; set; }
//    public Inputrfport1power inputRfPort1Power { get; set; }
//    public Inputrfport1spectrum inputRfPort1Spectrum { get; set; }
//    public Inputrfport2adcsaturation inputRfPort2AdcSaturation { get; set; }
//    public Inputrfport2adcsaturationpercent inputRfPort2AdcSaturationPercent { get; set; }
//    public Inputrfport2minimumgain inputRfPort2MinimumGain { get; set; }
//    public Inputrfport2power inputRfPort2Power { get; set; }
//    public Inputrfport2spectrum inputRfPort2Spectrum { get; set; }
//    public Inputrfportselect inputRfPortSelect { get; set; }
//    public Inputrfpower inputRfPower { get; set; }
//    public Inputrfsamplerate inputRfSampleRate { get; set; }
//    public Inputrfspectrum inputRfSpectrum { get; set; }
//    public Invertrfoutputspectrum invertRfOutputSpectrum { get; set; }
//    public Irigdclocked irigDcLocked { get; set; }
//    public Iriglocked1 irigLocked { get; set; }
//    public Label label { get; set; }
//    public Loglevel logLevel { get; set; }
//    public Manualgain manualGain { get; set; }
//    public Minimumgain minimumGain { get; set; }
//    public Modulestate moduleState { get; set; }
//    public Moduletype moduleType { get; set; }
//    public Multicastgroupsubscriptions multicastGroupSubscriptions { get; set; }
//    public Ntpstatus ntpStatus { get; set; }
//    public Oneppspresent1 onePpsPresent { get; set; }
//    public Outputattenuation outputAttenuation { get; set; }
//    public Outputrfcenterfrequency outputRfCenterFrequency { get; set; }
//    public Outputrfdacsaturation outputRfDacSaturation { get; set; }
//    public Outputrfdacsaturationpercent outputRfDacSaturationPercent { get; set; }
//    public Outputrfport1dacsaturation outputRfPort1DacSaturation { get; set; }
//    public Outputrfport1dacsaturationpercent outputRfPort1DacSaturationPercent { get; set; }
//    public Outputrfport1power outputRfPort1Power { get; set; }
//    public Outputrfport1spectrum outputRfPort1Spectrum { get; set; }
//    public Outputrfport2dacsaturation outputRfPort2DacSaturation { get; set; }
//    public Outputrfport2dacsaturationpercent outputRfPort2DacSaturationPercent { get; set; }
//    public Outputrfport2power outputRfPort2Power { get; set; }
//    public Outputrfport2spectrum outputRfPort2Spectrum { get; set; }
//    public Outputrfportselect outputRfPortSelect { get; set; }
//    public Outputrfpower outputRfPower { get; set; }
//    public Outputrfspectrum outputRfSpectrum { get; set; }
//    public Overrideoutputfrequency overrideOutputFrequency { get; set; }
//    public Overrideoutputfrequencyenable overrideOutputFrequencyEnable { get; set; }
//    public Pollinterval pollInterval { get; set; }
//    public Posixnanoseconds posixNanoseconds { get; set; }
//    public Posixseconds posixSeconds { get; set; }
//    public Rebootrequired rebootRequired { get; set; }
//    public Replywaittime replyWaitTime { get; set; }
//    public Requiredreadprivilege requiredReadPrivilege { get; set; }
//    public Requiredwriteprivilege requiredWritePrivilege { get; set; }
//    public Rfinputstream rfInputStream { get; set; }
//    public Rfoutputenable rfOutputEnable { get; set; }
//    public Rfoutputsource rfOutputSource { get; set; }
//    public Rfoutputstream rfOutputStream { get; set; }
//    public Routes routes { get; set; }
//    public Securitysource securitySource { get; set; }
//    public Serialnumber serialNumber { get; set; }
//    public Shortdescription shortDescription { get; set; }
//    public Simulate simulate { get; set; }
//    public Squelchenabled squelchEnabled { get; set; }
//    public Systemtemperature systemTemperature { get; set; }
//    public Systemtimesource systemTimeSource { get; set; }
//    public Tenmhzlocked1 tenMhzLocked { get; set; }
//    public Version version { get; set; }
//}

//public class Active
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Address
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Availablestreams
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Array[] array { get; set; }
//}

//public class Array
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Structure structure { get; set; }
//}

//public class Structure
//{
//    public Sourceipaddress sourceIpAddress { get; set; }
//    public Sourceport sourcePort { get; set; }
//    public Streamid streamId { get; set; }
//    public Centerfrequency centerFrequency { get; set; }
//    public Bandwidth bandwidth { get; set; }
//    public Samplerate sampleRate { get; set; }
//    public Gain gain { get; set; }
//    public Samplewidth sampleWidth { get; set; }
//    public Pfecenabled pfecEnabled { get; set; }
//    public Iriglocked irigLocked { get; set; }
//    public Oneppspresent onePpsPresent { get; set; }
//    public Tenmhzlocked tenMhzLocked { get; set; }
//}

//public class Sourceipaddress
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Sourceport
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Streamid
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Centerfrequency
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Bandwidth
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Samplerate
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Gain
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Samplewidth
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Pfecenabled
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Iriglocked
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Oneppspresent
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Tenmhzlocked
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Compositestatus
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Compositestatusmsg
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Contextpacketstate
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Controlnic
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Structure1 structure { get; set; }
//}

//public class Structure1
//{
//    public Addresses addresses { get; set; }
//    public Address1 address { get; set; }
//    public Netmask netmask { get; set; }
//}

//public class Addresses
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Address1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Netmask
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Currentgain
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Datanic
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Structure2 structure { get; set; }
//}

//public class Structure2
//{
//    public Addresses1 addresses { get; set; }
//    public Address2 address { get; set; }
//    public Netmask1 netmask { get; set; }
//}

//public class Addresses1
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

//public class Netmask1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Dependencies
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Array1[] array { get; set; }
//}

//public class Array1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Discardedpackets
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Enablemulticastgroupsubscriptions
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Fanspeed
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Gainmode
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

//public class Healthstatus
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Healthstatusmsg
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Inputrfadcsaturation
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Inputrfadcsaturationpercent
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Inputrfbandwidth
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Inputrfcenterfrequency
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Inputrfport1adcsaturation
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Inputrfport1adcsaturationpercent
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Inputrfport1minimumgain
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Inputrfport1power
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Inputrfport1spectrum
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Data data { get; set; }
//}

//public class Data
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string data { get; set; }
//    public int bitLength { get; set; }
//}

//public class Inputrfport2adcsaturation
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Inputrfport2adcsaturationpercent
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Inputrfport2minimumgain
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Inputrfport2power
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Inputrfport2spectrum
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Data1 data { get; set; }
//}

//public class Data1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string data { get; set; }
//    public int bitLength { get; set; }
//}

//public class Inputrfportselect
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Inputrfpower
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Inputrfsamplerate
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Inputrfspectrum
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Data2 data { get; set; }
//}

//public class Data2
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string data { get; set; }
//    public int bitLength { get; set; }
//}

//public class Invertrfoutputspectrum
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Irigdclocked
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Iriglocked1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Label
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Loglevel
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Manualgain
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Minimumgain
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Modulestate
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Moduletype
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Multicastgroupsubscriptions
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Array2[] array { get; set; }
//}

//public class Array2
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Ntpstatus
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Oneppspresent1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Outputattenuation
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Outputrfcenterfrequency
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Outputrfdacsaturation
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Outputrfdacsaturationpercent
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Outputrfport1dacsaturation
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Outputrfport1dacsaturationpercent
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Outputrfport1power
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Outputrfport1spectrum
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Data3 data { get; set; }
//}

//public class Data3
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string data { get; set; }
//    public int bitLength { get; set; }
//}

//public class Outputrfport2dacsaturation
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Outputrfport2dacsaturationpercent
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Outputrfport2power
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Outputrfport2spectrum
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Data4 data { get; set; }
//}

//public class Data4
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string data { get; set; }
//    public int bitLength { get; set; }
//}

//public class Outputrfportselect
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Outputrfpower
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Outputrfspectrum
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Data5 data { get; set; }
//}

//public class Data5
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string data { get; set; }
//    public int bitLength { get; set; }
//}

//public class Overrideoutputfrequency
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Overrideoutputfrequencyenable
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Pollinterval
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Posixnanoseconds
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Posixseconds
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Rebootrequired
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Replywaittime
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Requiredreadprivilege
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Requiredwriteprivilege
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Rfinputstream
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Array3[] array { get; set; }
//}

//public class Array3
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Structure3 structure { get; set; }
//}

//public class Structure3
//{
//    public Name name { get; set; }
//    public Bitrate bitRate { get; set; }
//    public Datasamplewidth dataSampleWidth { get; set; }
//    public Destinationhost destinationHost { get; set; }
//    public Destinationport destinationPort { get; set; }
//    public Frequencyoffset frequencyOffset { get; set; }
//    public Maximumpacketsize maximumPacketSize { get; set; }
//    public Measurednetworkrate measuredNetworkRate { get; set; }
//    public Measuredpacketrate measuredPacketRate { get; set; }
//    public Minimumprocessingdelay minimumProcessingDelay { get; set; }
//    public Packetoverhead packetOverhead { get; set; }
//    public Pfecenable pfecEnable { get; set; }
//    public Routesearch routeSearch { get; set; }
//    public Sourceport1 sourcePort { get; set; }
//    public Streambandwidth streamBandwidth { get; set; }
//    public Streamenable streamEnable { get; set; }
//    public Streamgain streamGain { get; set; }
//    public Streamid1 streamId { get; set; }
//    public Streamsamplerate streamSampleRate { get; set; }
//}

//public class Name
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Bitrate
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Datasamplewidth
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Destinationhost
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Destinationport
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Frequencyoffset
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Maximumpacketsize
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Measurednetworkrate
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Measuredpacketrate
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Minimumprocessingdelay
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Packetoverhead
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Pfecenable
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Routesearch
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Sourceport1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Streambandwidth
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Streamenable
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Streamgain
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Streamid1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Streamsamplerate
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Rfoutputenable
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Rfoutputsource
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Rfoutputstream
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Array4[] array { get; set; }
//}

//public class Array4
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Structure4 structure { get; set; }
//}

//public class Structure4
//{
//    public Name1 name { get; set; }
//    public Currentbuffer currentBuffer { get; set; }
//    public Datasamplewidth1 dataSampleWidth { get; set; }
//    public Datasource dataSource { get; set; }
//    public Desiredbuffer desiredBuffer { get; set; }
//    public Desireddelay desiredDelay { get; set; }
//    public Destinationport1 destinationPort { get; set; }
//    public Droppedpackets droppedPackets { get; set; }
//    public Frequencyoffset1 frequencyOffset { get; set; }
//    public Gapcount gapCount { get; set; }
//    public Measureddelay measuredDelay { get; set; }
//    public Measurednetworkrate1 measuredNetworkRate { get; set; }
//    public Measuredpacketrate1 measuredPacketRate { get; set; }
//    public Netstreamgain netStreamGain { get; set; }
//    public Networkdelay networkDelay { get; set; }
//    public Packetoverhead1 packetOverhead { get; set; }
//    public Pfecdecoderstatus pfecDecoderStatus { get; set; }
//    public Pfecmissingsets pfecMissingSets { get; set; }
//    public Pfecrepairedpackets pfecRepairedPackets { get; set; }
//    public Pfectotalpackets pfecTotalPackets { get; set; }
//    public Pfecunrepairablepackets pfecUnrepairablePackets { get; set; }
//    public Preservelatency preserveLatency { get; set; }
//    public Preservelatencylatepackets preserveLatencyLatePackets { get; set; }
//    public Preservelatencymaxburstloss preserveLatencyMaxBurstLoss { get; set; }
//    public Preservelatencymissingpackets preserveLatencyMissingPackets { get; set; }
//    public Preservelatencyoutoforderpackets preserveLatencyOutOfOrderPackets { get; set; }
//    public Preservelatencyreleasemargin preserveLatencyReleaseMargin { get; set; }
//    public Releasemode releaseMode { get; set; }
//    public Sourcehost sourceHost { get; set; }
//    public Sourceport2 sourcePort { get; set; }
//    public Streambandwidth1 streamBandwidth { get; set; }
//    public Streamenable1 streamEnable { get; set; }
//    public Streamid2 streamId { get; set; }
//    public Streamsamplerate1 streamSampleRate { get; set; }
//    public Underflowcount underflowCount { get; set; }
//    public Upstreamiriglocked upstreamIrigLocked { get; set; }
//    public Upstreamoneppslocked upstreamOnePpsLocked { get; set; }
//    public Upstreampathgain upstreamPathGain { get; set; }
//    public Upstreamtenmhzlocked upstreamTenMhzLocked { get; set; }
//    public Uselocalreference useLocalReference { get; set; }
//}

//public class Name1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Currentbuffer
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Datasamplewidth1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Datasource
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Desiredbuffer
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Desireddelay
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Destinationport1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Droppedpackets
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Frequencyoffset1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Gapcount
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Measureddelay
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Measurednetworkrate1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Measuredpacketrate1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Netstreamgain
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Networkdelay
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Packetoverhead1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Pfecdecoderstatus
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Pfecmissingsets
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Pfecrepairedpackets
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Pfectotalpackets
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Pfecunrepairablepackets
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Preservelatency
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Preservelatencylatepackets
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Preservelatencymaxburstloss
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Preservelatencymissingpackets
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Preservelatencyoutoforderpackets
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Preservelatencyreleasemargin
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Releasemode
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Sourcehost
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Sourceport2
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Streambandwidth1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Streamenable1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Streamid2
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Streamsamplerate1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Underflowcount
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Upstreamiriglocked
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Upstreamoneppslocked
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Upstreampathgain
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public float value { get; set; }
//}

//public class Upstreamtenmhzlocked
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Uselocalreference
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Routes
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public object[] array { get; set; }
//}

//public class Securitysource
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Serialnumber
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Shortdescription
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Simulate
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Squelchenabled
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Systemtemperature
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}

//public class Systemtimesource
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Tenmhzlocked1
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public bool value { get; set; }
//}

//public class Version
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

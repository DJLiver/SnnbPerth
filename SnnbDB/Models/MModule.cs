﻿using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class MModule
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public bool Active { get; set; }

    public string Address { get; set; } = null!;

    public string CompositeStatus { get; set; } = null!;

    public string CompositeStatusMsg { get; set; } = null!;

    public string ContextPacketState { get; set; } = null!;

    public decimal CurrentGain { get; set; }

    public decimal DiscardedPackets { get; set; }

    public bool EnableMulticastGroupSubscriptions { get; set; }

    public decimal FanSpeed { get; set; }

    public string GainMode { get; set; } = null!;

    public string Gateway { get; set; } = null!;

    public string HealthStatus { get; set; } = null!;

    public string HealthStatusMsg { get; set; } = null!;

    public float InputRfAdcSaturation { get; set; }

    public float InputRfAdcSaturationPercent { get; set; }

    public string InputRfBandwidth { get; set; } = null!;

    public float InputRfCenterFrequency { get; set; }

    public float InputRfPort1AdcSaturation { get; set; }

    public float InputRfPort1AdcSaturationPercent { get; set; }

    public int InputRfPort1MinimumGain { get; set; }

    public float InputRfPort1Power { get; set; }

    public float InputRfPort2AdcSaturation { get; set; }

    public float InputRfPort2AdcSaturationPercent { get; set; }

    public int InputRfPort2MinimumGain { get; set; }

    public float InputRfPort2Power { get; set; }

    public string InputRfPortSelect { get; set; } = null!;

    public float InputRfPower { get; set; }

    public decimal InputRfSampleRate { get; set; }

    public bool InvertRfOutputSpectrum { get; set; }

    public bool IrigDcLocked { get; set; }

    public bool IrigLocked { get; set; }

    public string Label { get; set; } = null!;

    public string LogLevel { get; set; } = null!;

    public int ManualGain { get; set; }

    public int MinimumGain { get; set; }

    public string ModuleState { get; set; } = null!;

    public string ModuleType { get; set; } = null!;

    public string NtpStatus { get; set; } = null!;

    public bool OnePpsPresent { get; set; }

    public float OutputAttenuation { get; set; }

    public double OutputRfCenterFrequency { get; set; }

    public float OutputRfDacSaturation { get; set; }

    public float OutputRfDacSaturationPercent { get; set; }

    public float OutputRfPort1DacSaturation { get; set; }

    public float OutputRfPort1DacSaturationPercent { get; set; }

    public float OutputRfPort1Power { get; set; }

    public float OutputRfPort2DacSaturation { get; set; }

    public float OutputRfPort2DacSaturationPercent { get; set; }

    public float OutputRfPort2Power { get; set; }

    public string OutputRfPortSelect { get; set; } = null!;

    public float OutputRfPower { get; set; }

    public float OverrideOutputFrequency { get; set; }

    public bool OverrideOutputFrequencyEnable { get; set; }

    public decimal PollInterval { get; set; }

    public decimal PosixNanoseconds { get; set; }

    public decimal PosixSeconds { get; set; }

    public bool RebootRequired { get; set; }

    public string ReplyWaitTime { get; set; } = null!;

    public string RequiredReadPrivilege { get; set; } = null!;

    public string RequiredWritePrivilege { get; set; } = null!;

    public bool RfOutputEnable { get; set; }

    public string RfOutputSource { get; set; } = null!;

    public string SecuritySource { get; set; } = null!;

    public string SerialNumber { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;

    public bool Simulate { get; set; }

    public bool SquelchEnabled { get; set; }

    public int SystemTemperature { get; set; }

    public string SystemTimeSource { get; set; } = null!;

    public bool TenMhzLocked { get; set; }

    public string Version { get; set; } = null!;
}

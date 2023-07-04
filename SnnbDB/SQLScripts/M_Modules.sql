USE [snnb_FO]
GO

/****** Object:  Table [dbo].[M_Modules]    Script Date: 06Nov2022 12:15:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[M_Modules]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,

	[active] [bit] NOT NULL,
	[address] [nvarchar](128) NOT NULL,

	[compositeStatus] [nvarchar](128) NOT NULL,
	[compositeStatusMsg] [nvarchar](512) NOT NULL,
	[contextPacketState] [nvarchar](128) NOT NULL,

	[currentGain] [NUMERIC](10) NOT NULL,


	[discardedPackets] [NUMERIC](10) NOT NULL,
	[enableMulticastGroupSubscriptions] [bit] NOT NULL,
	[fanSpeed] [NUMERIC](5) NOT NULL,
	[gainMode] [nvarchar](128) NOT NULL,
	[gateway] [nvarchar](128) NOT NULL,
	[healthStatus] [nvarchar](128) NOT NULL,
	[healthStatusMsg] [nvarchar](512) NOT NULL,
	[inputRfAdcSaturation] [real] NOT NULL,
	[inputRfAdcSaturationPercent] [real] NOT NULL,
	[inputRfBandwidth] [nvarchar](128) NOT NULL,
	[inputRfCenterFrequency] [real] NOT NULL,
	[inputRfPort1AdcSaturation] [real] NOT NULL,
	[inputRfPort1AdcSaturationPercent] [real] NOT NULL,
	[inputRfPort1MinimumGain] [int] NOT NULL,
	[inputRfPort1Power] [real] NOT NULL,

	[inputRfPort2AdcSaturation] [real] NOT NULL,
	[inputRfPort2AdcSaturationPercent] [real] NOT NULL,
	[inputRfPort2MinimumGain] [int] NOT NULL,
	[inputRfPort2Power] [real] NOT NULL,

	[inputRfPortSelect] [nvarchar](128) NOT NULL,
	[inputRfPower] [real] NOT NULL,
	[inputRfSampleRate] [NUMERIC](10) NOT NULL,

	[invertRfOutputSpectrum] [bit] NOT NULL,
	[irigDcLocked] [bit] NOT NULL,
	[irigLocked] [bit] NOT NULL,
	[label] [nvarchar](128) NOT NULL,
	[logLevel] [nvarchar](128) NOT NULL,
	[manualGain] [int] NOT NULL,
	[minimumGain] [int] NOT NULL,
	[moduleState] [nvarchar](128) NOT NULL,
	[moduleType] [nvarchar](128) NOT NULL,

	[ntpStatus] [nvarchar](128) NOT NULL,
	[onePpsPresent] [bit] NOT NULL,
	[outputAttenuation] [real] NOT NULL,
	[outputRfCenterFrequency] [float] NOT NULL,
	[outputRfDacSaturation] [real] NOT NULL,
	[outputRfDacSaturationPercent] [real] NOT NULL,
	[outputRfPort1DacSaturation] [real] NOT NULL,
	[outputRfPort1DacSaturationPercent] [real] NOT NULL,
	[outputRfPort1Power] [real] NOT NULL,

	[outputRfPort2DacSaturation] [real] NOT NULL,
	[outputRfPort2DacSaturationPercent] [real] NOT NULL,
	[outputRfPort2Power] [real] NOT NULL,

	[outputRfPortSelect] [nvarchar](128) NOT NULL,
	[outputRfPower] [real] NOT NULL,

	[overrideOutputFrequency] [real] NOT NULL,
	[overrideOutputFrequencyEnable] [bit] NOT NULL,
	[pollInterval] [NUMERIC](10) NOT NULL,
	[posixNanoseconds] [NUMERIC](10) NOT NULL,
	[posixSeconds] [NUMERIC](10) NOT NULL,
	[rebootRequired] [bit] NOT NULL,
	[replyWaitTime] [nvarchar](32) NOT NULL,
	[requiredReadPrivilege] [nvarchar](128) NOT NULL,
	[requiredWritePrivilege] [nvarchar](128) NOT NULL,

	[rfOutputEnable] [bit] NOT NULL,
	[rfOutputSource] [nvarchar](128) NOT NULL,


	[securitySource] [nvarchar](128) NOT NULL,
	[serialNumber] [nvarchar](128) NOT NULL,
	[shortDescription] [nvarchar](128) NOT NULL,
	[simulate] [bit] NOT NULL,
	[squelchEnabled] [bit] NOT NULL,
	[systemTemperature] [int] NOT NULL,
	[systemTimeSource] [nvarchar](128) NOT NULL,
	[tenMhzLocked] [bit] NOT NULL,
	[version] [nvarchar](128) NOT NULL,


 CONSTRAINT [PK_M_Modules]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO

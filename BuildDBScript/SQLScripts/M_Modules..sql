USE [snnb_FO]
GO

/****** Object:  Table [dbo].[Modules]    Script Date: 06Nov2022 12:15:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[mModules]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
    [active] [bit] NULL,
    [address] [nvarchar](128) NULL,
    [compositeStatus] [nvarchar](128) NULL,
    [compositeStatusMsg] [nvarchar](128) NULL,
    [contextPacketState] [nvarchar](128) NULL,
    [discardedPackets] [NUMERIC](10) NULL,
    [enableMulticastGroupSubscriptions] [bit] NULL,
    [fanSpeed] [NUMERIC](5) NULL,
    [gainMode] [nvarchar](128) NULL,
    [gateway] [nvarchar](128) NULL,
    [healthStatus] [nvarchar](128) NULL,
    [healthStatusMsg] [nvarchar](128) NULL,
    [inputRfAdcSaturation] [real] NULL,
    [inputRfAdcSaturationPercent] [real] NULL,
    [inputRfBandwidth] [nvarchar](128) NULL,
    [inputRfCenterFrequency] [real] NULL,
    [inputRfPort1AdcSaturation] [real] NULL,
    [inputRfPort1AdcSaturationPercent] [real] NULL,
    [inputRfPort1MinimumGain] [int] NULL,
    [inputRfPort1Power] [real] NULL,
    [inputRfPort2AdcSaturation] [real] NULL,
    [inputRfPort2AdcSaturationPercent] [real] NULL,
    [inputRfPort2MinimumGain] [int] NULL,
    [inputRfPort2Power] [real] NULL,
    [inputRfPortSelect] [nvarchar](128) NULL,
    [inputRfPower] [real] NULL,
    [inputRfSampleRate] [NUMERIC](10) NULL,
    [invertRfOutputSpectrum] [bit] NULL,
    [irigDcLocked] [bit] NULL,
    [irigLocked] [bit] NULL,
    [label] [nvarchar](128) NULL,
    [logLevel] [nvarchar](128) NULL,
    [manualGain] [int] NULL,
    [minimumGain] [int] NULL,
    [moduleState] [nvarchar](128) NULL,
    [moduleType] [nvarchar](128) NULL,
    [ntpStatus] [nvarchar](128) NULL,
    [onePpsPresent] [bit] NULL,
    [outputAttenuation] [real] NULL,
    [outputRfCenterFrequency] [float] NULL,
    [outputRfDacSaturation] [real] NULL,
    [outputRfDacSaturationPercent] [real] NULL,
    [outputRfPort1DacSaturation] [real] NULL,
    [outputRfPort1DacSaturationPercent] [real] NULL,
    [outputRfPort1Power] [real] NULL,
    [outputRfPort2DacSaturation] [real] NULL,
    [outputRfPort2DacSaturationPercent] [real] NULL,
    [outputRfPort2Power] [real] NULL,
    [outputRfPortSelect] [nvarchar](128) NULL,
    [outputRfPower] [real] NULL,
    [overrideOutputFrequency] [real] NULL,
    [overrideOutputFrequencyEnable] [bit] NULL,
    [pollInterval] [NUMERIC](10) NULL,
    [posixNanoseconds] [NUMERIC](10) NULL,
    [posixSeconds] [NUMERIC](10) NULL,
    [rebootRequired] [bit] NULL,
    [replyWaitTime] [time] NULL,
    [requiredReadPrivilege] [nvarchar](128) NULL,
    [requiredWritePrivilege] [nvarchar](128) NULL,
    [rfOutputEnable] [bit] NULL,
    [rfOutputSource] [nvarchar](128) NULL,
    [securitySource] [nvarchar](128) NULL,
    [serialNumber] [nvarchar](128) NULL,
    [shortDescription] [nvarchar](128) NULL,
    [simulate] [bit] NULL,
    [squelchEnabled] [bit] NULL,
    [systemTemperature] [int] NULL,
    [systemTimeSource] [nvarchar](128) NULL,
    [tenMhzLocked] [bit] NULL,
    [version] [nvarchar](128) NULL,
 CONSTRAINT [PK_mModules]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO

USE [snnb_FO]
GO

/****** Object:  Table [dbo].[M_RfOutputStream]    Script Date: 06Nov2022 12:15:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[M_RfOutputStream]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
    [name] [nvarchar](128) NOT NULL,
    [currentBuffer] [float] NOT NULL,
    [dataSampleWidth] [NUMERIC](5) NOT NULL,
    [dataSource] [nvarchar](128) NOT NULL,
    [desiredBuffer] [NUMERIC](10) NOT NULL,
    [desiredDelay] [NUMERIC](10) NOT NULL,
    [destinationPort] [NUMERIC](5) NOT NULL,
    [droppedPackets] [NUMERIC](10) NOT NULL,
    [frequencyOffset] [bigint] NOT NULL,
    [gapCount] [NUMERIC](10) NOT NULL,
    [measuredDelay] [NUMERIC](10) NOT NULL,
    [measuredNetworkRate] [NUMERIC](20) NOT NULL,
    [measuredPacketRate] [NUMERIC](10) NOT NULL,
    [netStreamGain] [float] NOT NULL,
    [networkDelay] [float] NOT NULL,
    [packetOverhead] [float] NOT NULL,
    [pfecDecoderStatus] [nvarchar](128) NOT NULL,
    [pfecMissingSets] [NUMERIC](10) NOT NULL,
    [pfecRepairedPackets] [NUMERIC](10) NOT NULL,
    [pfecTotalPackets] [NUMERIC](20) NOT NULL,
    [pfecUnrepairablePackets] [NUMERIC](10) NOT NULL,
    [preserveLatency] [bit] NOT NULL,
    [preserveLatencyLatePackets] [NUMERIC](10) NOT NULL,
    [preserveLatencyMaxBurstLoss] [NUMERIC](10) NOT NULL,
    [preserveLatencyMissingPackets] [NUMERIC](10) NOT NULL,
    [preserveLatencyOutOfOrderPackets] [NUMERIC](10) NOT NULL,
    [preserveLatencyReleaseMargin] [NUMERIC](10) NOT NULL,
    [releaseMode] [nvarchar](128) NOT NULL,
    [sourceHost] [nvarchar](128) NOT NULL,
    [sourcePort] [NUMERIC](5) NOT NULL,
    [streamBandwidth] [float] NOT NULL,
    [streamEnable] [bit] NOT NULL,
    [streamId] [NUMERIC](10) NOT NULL,
    [streamSampleRate] [float] NOT NULL,
    [underflowCount] [NUMERIC](10) NOT NULL,
    [upstreamIrigLocked] [bit] NOT NULL,
    [upstreamOnePpsLocked] [bit] NOT NULL,
    [upstreamPathGain] [float] NOT NULL,
    [upstreamTenMhzLocked] [bit] NOT NULL,
    [useLocalReference] [bit] NOT NULL,
 CONSTRAINT [PK_M_RfOutputStream]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO

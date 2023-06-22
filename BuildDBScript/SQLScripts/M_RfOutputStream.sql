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
    [name] [nvarchar](128) NULL,
    [currentBuffer] [float] NULL,
    [dataSampleWidth] [NUMERIC](5) NULL,
    [dataSource] [nvarchar](128) NULL,
    [desiredBuffer] [NUMERIC](10) NULL,
    [desiredDelay] [NUMERIC](10) NULL,
    [destinationPort] [NUMERIC](5) NULL,
    [droppedPackets] [NUMERIC](10) NULL,
    [frequencyOffset] [bigint] NULL,
    [gapCount] [NUMERIC](10) NULL,
    [measuredDelay] [NUMERIC](10) NULL,
    [measuredNetworkRate] [NUMERIC](20) NULL,
    [measuredPacketRate] [NUMERIC](10) NULL,
    [netStreamGain] [float] NULL,
    [networkDelay] [float] NULL,
    [packetOverhead] [float] NULL,
    [pfecDecoderStatus] [nvarchar](128) NULL,
    [pfecMissingSets] [NUMERIC](10) NULL,
    [pfecRepairedPackets] [NUMERIC](10) NULL,
    [pfecTotalPackets] [NUMERIC](20) NULL,
    [pfecUnrepairablePackets] [NUMERIC](10) NULL,
    [preserveLatency] [bit] NULL,
    [preserveLatencyLatePackets] [NUMERIC](10) NULL,
    [preserveLatencyMaxBurstLoss] [NUMERIC](10) NULL,
    [preserveLatencyMissingPackets] [NUMERIC](10) NULL,
    [preserveLatencyOutOfOrderPackets] [NUMERIC](10) NULL,
    [preserveLatencyReleaseMargin] [NUMERIC](10) NULL,
    [releaseMode] [nvarchar](128) NULL,
    [sourceHost] [nvarchar](128) NULL,
    [sourcePort] [NUMERIC](5) NULL,
    [streamBandwidth] [float] NULL,
    [streamEnable] [bit] NULL,
    [streamId] [NUMERIC](10) NULL,
    [streamSampleRate] [float] NULL,
    [underflowCount] [NUMERIC](10) NULL,
    [upstreamIrigLocked] [bit] NULL,
    [upstreamOnePpsLocked] [bit] NULL,
    [upstreamPathGain] [float] NULL,
    [upstreamTenMhzLocked] [bit] NULL,
    [useLocalReference] [bit] NULL,
 CONSTRAINT [PK_M_RfOutputStream]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO

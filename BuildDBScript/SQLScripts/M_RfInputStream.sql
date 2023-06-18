USE [snnb_FO]
GO

/****** Object:  Table [dbo].[RfInputStream]    Script Date: 06Nov2022 12:15:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[mRfInputStream]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
    [name] [nvarchar](128) NULL,
    [bitRate] [NUMERIC](10) NULL,
    [dataSampleWidth] [NUMERIC](5) NULL,
    [destinationHost] [nvarchar](128) NULL,
    [destinationPort] [NUMERIC](5) NULL,
    [frequencyOffset] [bigint] NULL,
    [maximumPacketSize] [NUMERIC](10) NULL,
    [measuredNetworkRate] [NUMERIC](20) NULL,
    [measuredPacketRate] [NUMERIC](10) NULL,
    [minimumProcessingDelay] [float] NULL,
    [packetOverhead] [float] NULL,
    [pfecEnable] [bit] NULL,
    [routeSearch] [nvarchar](128) NULL,
    [sourcePort] [NUMERIC](5) NULL,
    [streamBandwidth] [NUMERIC](20) NULL,
    [streamEnable] [bit] NULL,
    [streamGain] [float] NULL,
    [streamId] [NUMERIC](10) NULL,
    [streamSampleRate] [float] NULL,
 CONSTRAINT [PK_mRfInputStream]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO

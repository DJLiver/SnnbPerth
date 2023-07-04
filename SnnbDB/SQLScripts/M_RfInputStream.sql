USE [snnb_FO]
GO

/****** Object:  Table [dbo].[M_RfInputStream]    Script Date: 06Nov2022 12:15:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[M_RfInputStream]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
    [name] [nvarchar](128) NOT NULL,
    [bitRate] [NUMERIC](10) NOT NULL,
    [dataSampleWidth] [NUMERIC](5) NOT NULL,
    [destinationHost] [nvarchar](128) NOT NULL,
    [destinationPort] [NUMERIC](5) NOT NULL,
    [frequencyOffset] [bigint] NOT NULL,
    [maximumPacketSize] [NUMERIC](10) NOT NULL,
    [measuredNetworkRate] [NUMERIC](20) NOT NULL,
    [measuredPacketRate] [NUMERIC](10) NOT NULL,
    [minimumProcessingDelay] [float] NOT NULL,
    [packetOverhead] [float] NOT NULL,
    [pfecEnable] [bit] NOT NULL,
    [routeSearch] [nvarchar](128) NOT NULL,
    [sourcePort] [NUMERIC](5) NOT NULL,
    [streamBandwidth] [NUMERIC](20) NOT NULL,
    [streamEnable] [bit] NOT NULL,
    [streamGain] [float] NOT NULL,
    [streamId] [NUMERIC](10) NOT NULL,
    [streamSampleRate] [float] NOT NULL,
 CONSTRAINT [PK_M_RfInputStream]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO

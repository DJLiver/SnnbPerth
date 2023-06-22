USE [snnb_FO]
GO

/****** Object:  Table [dbo].[M_AvailableStreams]    Script Date: 06Nov2022 12:15:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[M_AvailableStreams]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,

	[sourceIpAddress] [nvarchar](128) NOT NULL,
	[sourcePort] [nvarchar](128) NOT NULL,
	[streamId] [NUMERIC](10) NOT NULL,
	[centerFrequency] [float] NOT NULL,
	[bandwidth] [float] NOT NULL,
	[sampleRate] [float] NOT NULL,
	[gain] [float] NOT NULL,
	[sampleWidth] [NUMERIC](5) NOT NULL,
	[pfecEnabled] [bit] NOT NULL,
	[irigLocked] [bit] NOT NULL,
	[onePpsPresent] [bit] NOT NULL,
	[tenMhzLocked] [bit] NOT NULL,


 CONSTRAINT [PK_M_AvailableStreams]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO

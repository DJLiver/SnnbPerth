USE [snnb_FO]
GO

/****** Object:  Table [dbo].[M_DataNic]    Script Date: 06Nov2022 12:15:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[M_DataNic]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,

	[addresses] [nvarchar](128) NOT NULL,
	[address] [nvarchar](128) NOT NULL,
	[netmask] [int] NOT NULL,

 CONSTRAINT [PK_M_DataNic]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO

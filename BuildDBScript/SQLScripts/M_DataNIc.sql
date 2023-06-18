USE [snnb_FO]
GO

/****** Object:  Table [dbo].[ControlNic]    Script Date: 06Nov2022 12:15:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[mDataNic]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
    [addresses] [nvarchar](128) NULL,
    [address] [nvarchar](128) NULL,
    [netmask] [int] NULL,

 CONSTRAINT [PK_mDataNic]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO

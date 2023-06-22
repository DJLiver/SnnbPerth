USE [snnb_FO]
GO

/****** Object:  Table [dbo].[M_Routes]    Script Date: 06Nov2022 12:15:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[M_Routes]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
    [destination] [nvarchar](128) NULL,
    [gateway] [nvarchar](128) NULL,
    [netmask] [int] NULL,

 CONSTRAINT [PK_M_Routes]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO

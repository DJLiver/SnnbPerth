USE [snnb_FO]
GO

/****** Object:  Table [dbo].[M_OutputRfPort2Spectrum]    Script Date: 06Nov2022 12:15:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[M_OutputRfPort2Spectrum]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[Spectrum] [nvarchar](MAX) NOT NULL,
 CONSTRAINT [PK_M_OutputRfPort2Spectrum]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO

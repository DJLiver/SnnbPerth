USE [snnb_FO]
GO

/****** Object:  Table [dbo].[M_Dependencies]    Script Date: 06Nov2022 12:15:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[M_Dependencies]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
    [dependant] [nvarchar](128) NULL,

 CONSTRAINT [PK_M_Dependencies]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO

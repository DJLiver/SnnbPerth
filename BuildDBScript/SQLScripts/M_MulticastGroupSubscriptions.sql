USE [snnb_FO]
GO

/****** Object:  Table [dbo].[M_MulticastGroupSubscriptions]    Script Date: 06Nov2022 12:15:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[M_MulticastGroupSubscriptions]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
    [dependant] [nvarchar](128) NOT NULL,

 CONSTRAINT [PK_M_MulticastGroupSubscriptions]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO

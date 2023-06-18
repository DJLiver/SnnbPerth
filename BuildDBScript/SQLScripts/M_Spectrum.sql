﻿USE [snnb_FO]
GO

/****** Object:  Table [dbo].[Spectrum]    Script Date: 06Nov2022 12:15:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[mSpectrum]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
    [SpectrumType] [nvarchar](128) NULL,
	[inputRfPort1Spectrum] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_mSpectrum]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO

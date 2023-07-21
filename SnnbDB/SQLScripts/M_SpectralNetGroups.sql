USE [snnb_FO]
GO

/****** Object:  Table [dbo].[M_SpectralNetGroups]    Script Date: 21/07/2023 08:24:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[M_SpectralNetGroups]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateStamp] [datetime2](7) NOT NULL,
	[ClusterID] [int] NOT NULL,
	[ClusterName] [nvarchar](128) NOT NULL,
	[GroupID] [int] NOT NULL,
	[GroupName] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[Site] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[UnitId] [int] NOT NULL,
	[UnitName] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[RemoteUnit] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[PeerUnit] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[ChassisName] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[Location] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[IpAddress] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[NetworkPath] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Error] [bit] NOT NULL,
	[ErrorText] [nvarchar](512) COLLATE Latin1_General_CI_AS NOT NULL,
	[ReponseTime] [int] NOT NULL,

 CONSTRAINT [PK_M_SpectralNetGroups]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO



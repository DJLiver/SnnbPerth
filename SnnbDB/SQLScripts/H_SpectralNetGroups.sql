USE [snnb_FO]
GO

/****** Object:  Table [dbo].[H_SpectralNetGroups]    Script Date: 25Nov2022 8:18:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[H_SpectralNetGroups](
	[id] [int] IDENTITY(1,1) NOT NULL,
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
	[Direction] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Timeout] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,

 CONSTRAINT [PK_H_SpectralNetGroups] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT "H_SpectralNetGroups" VALUES(200,'Group Id 200','SiteA', 2000,'AUC-RH1A','WRW-RH1A','AUC-RH1B','AUC Chassis name','Auckland SAS','10.228.41.179','Forward', 1,500,'True')
INSERT "H_SpectralNetGroups" VALUES(200,'Group Id 200','SiteB', 2100,'WRW-RH1A','AUC-RH1A','WRW-RH1B','AUC Chassis name','Warkworth SAS','10.229.41.179','Return', 1,500,'False')
go

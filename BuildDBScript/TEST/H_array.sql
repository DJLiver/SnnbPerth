﻿USE [Test]
GO

/****** Object:  Table [dbo].[H_SpecNetGroups]    Script Date: 25Nov2022 8:18:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[H_SpecNetGroups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NOT NULL,
	[GroupName] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[Site] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[UnitId] [int] NOT NULL,
	[UnitName] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[ChassisName] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[Location] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[PreIpAddress] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[IpAddress] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[RestQuery] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[Direction] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,

 CONSTRAINT [PK_H_SpecNetGroups] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT "H_SpecNetGroups" VALUES(200,'Group Id 200','SiteA', 2000,'AUC Ant9 LHCP','AUC Chassis name','Auckland SAS','http://','10.228.41.179','rest/spectralNet/_attribute?_dive=true','Forward', 1,'True')
INSERT "H_SpecNetGroups" VALUES(200,'Group Id 200','SiteB', 2100,'WRW Ant3 LHCP','AUC Chassis name','Warkworth SAS','http://','10.229.41.179','rest/spectralNet/_attribute?_dive=true','Return', 1,'False')
go

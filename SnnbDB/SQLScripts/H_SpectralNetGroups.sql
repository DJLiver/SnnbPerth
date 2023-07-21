USE [snnb_FO]
GO

/****** Object:  Table [dbo].[H_SpectralNetGroups]    Script Date: 21/07/2023 07:52:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[H_SpectralNetGroups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ClusterID] [int] NOT NULL,
	[ClusterName] [nvarchar](128) NOT NULL,
	[GroupID] [int] NOT NULL,
	[GroupName] [nvarchar](128) NOT NULL,
	[Site] [nvarchar](128) NOT NULL,
	[UnitId] [int] NOT NULL,
	[UnitName] [nvarchar](128) NOT NULL,
	[RemoteUnit] [nvarchar](128) NOT NULL,
	[PeerUnit] [nvarchar](128) NOT NULL,
	[ChassisName] [nvarchar](128) NOT NULL,
	[Location] [nvarchar](128) NOT NULL,
	[IpAddress] [nvarchar](128) NOT NULL,
	[NetworkPath] [nvarchar](128) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Timeout] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_H_SpectralNetGroups] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT "H_SpectralNetGroups" VALUES(2, 'WRW ANT2',201,'AUC-WRW LH1','Baseband', 2000,'AUC-LH1A','WRW-LH1A','AUC-LH1B','AUC Chassis name','Auckland SAS','10.228.41.179','Primary', 1,500,'True')
INSERT "H_SpectralNetGroups" VALUES(2, 'WRW ANT2',201,'AUC-WRW LH1','Antenna', 2100,'WRW-LH1A','AUC-LH1A','WRW-LH1B','AUC Chassis name','Warkworth SAS','10.229.41.179','Primary', 51,500,'False')
INSERT "H_SpectralNetGroups" VALUES(2, 'WRW ANT2',201,'AUC-WRW LH1','Baseband', 2001,'AUC-LH1B','WRW-LH1B','AUC-LH1A','AUC Chassis name','Auckland SAS','10.228.41.160','Secondary', 2,500,'True')
INSERT "H_SpectralNetGroups" VALUES(2, 'WRW ANT2',201,'AUC-WRW LH1','Antenna', 2101,'WRW-LH1B','AUC-LH1B','WRW-LH1A','AUC Chassis name','Warkworth SAS','10.229.41.160','Secondary', 52,500,'False')

INSERT "H_SpectralNetGroups" VALUES(2, 'WRW ANT2',202,'AUC-WRW LH2','Baseband', 2002,'AUC-LH2A','WRW-LH2A','AUC-LH2B','AUC Chassis name','Auckland SAS','10.228.41.161','Primary', 3,500,'True')
INSERT "H_SpectralNetGroups" VALUES(2, 'WRW ANT2',202,'AUC-WRW LH2','Antenna', 2102,'WRW-LH2A','AUC-LH2A','WRW-LH2B','AUC Chassis name','Warkworth SAS','10.229.41.161','Primary', 53,500,'False')
INSERT "H_SpectralNetGroups" VALUES(2, 'WRW ANT2',202,'AUC-WRW LH2','Baseband', 2003,'AUC-LH2B','WRW-LH2B','AUC-LH2A','AUC Chassis name','Auckland SAS','10.228.41.162','Secondary', 4,500,'True')
INSERT "H_SpectralNetGroups" VALUES(2, 'WRW ANT2',202,'AUC-WRW LH2','Antenna', 2103,'WRW-LH2B','AUC-LH2B','WRW-LH2A','AUC Chassis name','Warkworth SAS','10.229.41.162','Secondary', 54,500,'False')

INSERT "H_SpectralNetGroups" VALUES(2, 'WRW ANT2',203,'AUC-WRW RH1','Baseband', 2004,'AUC-RH1A','WRW-RH1A','AUC-RH1B','AUC Chassis name','Auckland SAS','10.228.41.163','Primary', 5,500,'True')
INSERT "H_SpectralNetGroups" VALUES(2, 'WRW ANT2',203,'AUC-WRW RH1','Antenna', 2104,'WRW-RH1A','AUC-RH1A','WRW-RH1B','AUC Chassis name','Warkworth SAS','10.229.41.163','Primary', 55,500,'False')
INSERT "H_SpectralNetGroups" VALUES(2, 'WRW ANT2',203,'AUC-WRW RH1','Baseband', 2005,'AUC-RH1B','WRW-RH1B','AUC-RH1A','AUC Chassis name','Auckland SAS','10.228.41.164','Secondary', 6,500,'True')
INSERT "H_SpectralNetGroups" VALUES(2, 'WRW ANT2',203,'AUC-WRW RH1','Antenna', 2105,'WRW-RH1B','AUC-RH1B','WRW-RH1A','AUC Chassis name','Warkworth SAS','10.229.41.164','Secondary', 56,500,'False')

INSERT "H_SpectralNetGroups" VALUES(2, 'WRW ANT2',204,'AUC-WRW RH2','Baseband', 2006,'AUC-RH2A','WRW-RH2A','AUC-RH2B','AUC Chassis name','Auckland SAS','10.228.41.165','Primary', 7,500,'True')
INSERT "H_SpectralNetGroups" VALUES(2, 'WRW ANT2',204,'AUC-WRW RH2','Antenna', 2106,'WRW-RH2A','AUC-RH2A','WRW-RH2B','AUC Chassis name','Warkworth SAS','10.229.41.165','Primary', 57,500,'False')
INSERT "H_SpectralNetGroups" VALUES(2, 'WRW ANT2',204,'AUC-WRW RH2','Baseband', 2007,'AUC-RH2B','WRW-RH2B','AUC-RH2A','AUC Chassis name','Auckland SAS','10.228.41.166','Secondary', 8,500,'True')
INSERT "H_SpectralNetGroups" VALUES(2, 'WRW ANT2',204,'AUC-WRW RH2','Antenna', 2107,'WRW-RH2B','AUC-RH2B','WRW-RH2A','AUC Chassis name','Warkworth SAS','10.229.41.166','Secondary', 58,500,'False')
go


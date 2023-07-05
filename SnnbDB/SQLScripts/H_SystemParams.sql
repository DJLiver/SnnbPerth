USE [snnb_FO]
GO

/****** Object:  Table [dbo].[H_SystemParam]    Script Date: 25Nov2022 8:18:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[H_SystemParam](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PreIpAddress] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[RestQuery] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[PollPeriod] [int] NOT NULL,
	[Timeout] [int] NOT NULL,
	[Verbose] [bit] NOT NULL,
	[AutoOn] [bit] NOT NULL,
	[SwitchAll] [bit] NOT NULL,
	[SwitchDelay] [int] NOT NULL,
	[On_A_Path] [bit] NOT NULL,

 CONSTRAINT [PK_H_SystemParam] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT "H_SystemParam" VALUES('http://','rest/spectralNet/_attribute?_dive=true',2000, 500, 'True', 'False','False',3,'False')
go

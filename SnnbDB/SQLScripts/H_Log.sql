USE [snnb_FO]
GO

/****** Object:  Table [dbo].[H_Log]    Script Date: 4/07/2023 14:20:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[H_Log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateStamp] [datetime2](7) NOT NULL,
	[Application] [varchar](128) NOT NULL,
	[MemberName] [varchar](128) NOT NULL,
	[LineNumber] [int] NOT NULL,
	[Message] [varchar](1024) NOT NULL,
	[Additional] [varchar](1024) NOT NULL,
 CONSTRAINT [PK_H_Log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


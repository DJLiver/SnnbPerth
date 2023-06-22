USE [ExceptionLog]
GO

/****** Object:  Table [dbo].[Log]    Script Date: 3/01/2023 10:33:33 pm ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateStamp] [datetime2](7) NOT NULL,
	[Application] [varchar](128) NOT NULL,
	[MemberName] [varchar](128) NOT NULL,
	[LineNumber] int NOT NULL,
	[Message] [varchar](1024) NOT NULL,
	[Additional] [varchar](128) NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [snnb_FO]
GO

/****** Object:  Table [dbo].[RangeConfig]    Script Date: 3/07/2023 10:30:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[H_RangeConfig](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Table] [nvarchar](50) NOT NULL,
	[Attribute] [nvarchar](50) NOT NULL,
	[Lower] [float] NOT NULL,
	[Upper] [float] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[InRange] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



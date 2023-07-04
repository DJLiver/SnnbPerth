USE [snnb_FO]
GO

/****** Object:  Table [dbo].[H_FormatConfig]    Script Date: 3/07/2023 11:10:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[H_FormatConfig](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Table] [nvarchar](50) NULL,
	[Attribute] [nvarchar](50) NULL,
	[Access] [nvarchar](50) NULL,
	[Normal] [nvarchar](50) NULL,
	[Scale] [int] NULL,
	[Format] [nvarchar](50) NULL,
	[Units] [nvarchar](50) NULL,
	[Help] [nvarchar](512) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



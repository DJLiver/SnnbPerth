USE [master]
GO
/****** Object:  Database [snnb_FO]    Script Date: 26/07/2023 14:57:54 ******/
CREATE DATABASE [snnb_FO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'snnb_FO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\snnb_FO.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB ), 
 FILEGROUP [Mem_Opt_filegroup] CONTAINS MEMORY_OPTIMIZED_DATA  DEFAULT
( NAME = N'Mem_Opt_filegroup_file1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Data\Mem_Opt_filegroup_file1' , MAXSIZE = UNLIMITED)
 LOG ON 
( NAME = N'snnb_FO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\snnb_FO_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [snnb_FO] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [snnb_FO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [snnb_FO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [snnb_FO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [snnb_FO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [snnb_FO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [snnb_FO] SET ARITHABORT OFF 
GO
ALTER DATABASE [snnb_FO] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [snnb_FO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [snnb_FO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [snnb_FO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [snnb_FO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [snnb_FO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [snnb_FO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [snnb_FO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [snnb_FO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [snnb_FO] SET  DISABLE_BROKER 
GO
ALTER DATABASE [snnb_FO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [snnb_FO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [snnb_FO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [snnb_FO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [snnb_FO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [snnb_FO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [snnb_FO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [snnb_FO] SET RECOVERY FULL 
GO
ALTER DATABASE [snnb_FO] SET  MULTI_USER 
GO
ALTER DATABASE [snnb_FO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [snnb_FO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [snnb_FO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [snnb_FO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [snnb_FO] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [snnb_FO] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'snnb_FO', N'ON'
GO
ALTER DATABASE [snnb_FO] SET QUERY_STORE = OFF
GO
USE [snnb_FO]
GO
/****** Object:  Table [dbo].[H_FormatConfig]    Script Date: 26/07/2023 14:57:54 ******/
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
/****** Object:  Table [dbo].[H_Log]    Script Date: 26/07/2023 14:57:54 ******/
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
/****** Object:  Table [dbo].[H_RangeConfig]    Script Date: 26/07/2023 14:57:54 ******/
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
/****** Object:  Table [dbo].[H_SpectralNetGroups]    Script Date: 26/07/2023 14:57:54 ******/
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
/****** Object:  Table [dbo].[H_SystemParam]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[H_SystemParam](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PreIpAddress] [nvarchar](128) NOT NULL,
	[RestQuery] [nvarchar](128) NOT NULL,
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
/****** Object:  Table [dbo].[M_AvailableStreams]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_AvailableStreams]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[sourceIpAddress] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[sourcePort] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[streamId] [numeric](10, 0) NOT NULL,
	[centerFrequency] [float] NOT NULL,
	[bandwidth] [float] NOT NULL,
	[sampleRate] [float] NOT NULL,
	[gain] [float] NOT NULL,
	[sampleWidth] [numeric](5, 0) NOT NULL,
	[pfecEnabled] [bit] NOT NULL,
	[irigLocked] [bit] NOT NULL,
	[onePpsPresent] [bit] NOT NULL,
	[tenMhzLocked] [bit] NOT NULL,

 CONSTRAINT [PK_M_AvailableStreams]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO
/****** Object:  Table [dbo].[M_ControlNic]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_ControlNic]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[addresses] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[address] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[netmask] [int] NOT NULL,

 CONSTRAINT [PK_M_ControlNic]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO
/****** Object:  Table [dbo].[M_DataNic]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_DataNic]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[addresses] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[address] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[netmask] [int] NOT NULL,

 CONSTRAINT [PK_M_DataNic]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO
/****** Object:  Table [dbo].[M_Dependencies]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Dependencies]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[dependant] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,

 CONSTRAINT [PK_M_Dependencies]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO
/****** Object:  Table [dbo].[M_InputRfPort1Spectrum]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_InputRfPort1Spectrum]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[Spectrum] [nvarchar](max) COLLATE Latin1_General_CI_AS NOT NULL,

 CONSTRAINT [PK_M_InputRfPort1Spectrum]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO
/****** Object:  Table [dbo].[M_InputRfPort2Spectrum]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_InputRfPort2Spectrum]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[Spectrum] [nvarchar](max) COLLATE Latin1_General_CI_AS NOT NULL,

 CONSTRAINT [PK_M_InputRfPort2Spectrum]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO
/****** Object:  Table [dbo].[M_InputRfSpectrum]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_InputRfSpectrum]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[Spectrum] [nvarchar](max) COLLATE Latin1_General_CI_AS NOT NULL,

 CONSTRAINT [PK_M_InputRfSpectrum]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO
/****** Object:  Table [dbo].[M_Modules]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Modules]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[active] [bit] NOT NULL,
	[address] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[compositeStatus] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[compositeStatusMsg] [nvarchar](512) COLLATE Latin1_General_CI_AS NOT NULL,
	[contextPacketState] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[currentGain] [numeric](10, 0) NOT NULL,
	[discardedPackets] [numeric](10, 0) NOT NULL,
	[enableMulticastGroupSubscriptions] [bit] NOT NULL,
	[fanSpeed] [numeric](5, 0) NOT NULL,
	[gainMode] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[gateway] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[healthStatus] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[healthStatusMsg] [nvarchar](512) COLLATE Latin1_General_CI_AS NOT NULL,
	[inputRfAdcSaturation] [real] NOT NULL,
	[inputRfAdcSaturationPercent] [real] NOT NULL,
	[inputRfBandwidth] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[inputRfCenterFrequency] [real] NOT NULL,
	[inputRfPort1AdcSaturation] [real] NOT NULL,
	[inputRfPort1AdcSaturationPercent] [real] NOT NULL,
	[inputRfPort1MinimumGain] [int] NOT NULL,
	[inputRfPort1Power] [real] NOT NULL,
	[inputRfPort2AdcSaturation] [real] NOT NULL,
	[inputRfPort2AdcSaturationPercent] [real] NOT NULL,
	[inputRfPort2MinimumGain] [int] NOT NULL,
	[inputRfPort2Power] [real] NOT NULL,
	[inputRfPortSelect] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[inputRfPower] [real] NOT NULL,
	[inputRfSampleRate] [numeric](10, 0) NOT NULL,
	[invertRfOutputSpectrum] [bit] NOT NULL,
	[irigDcLocked] [bit] NOT NULL,
	[irigLocked] [bit] NOT NULL,
	[label] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[logLevel] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[manualGain] [int] NOT NULL,
	[minimumGain] [int] NOT NULL,
	[moduleState] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[moduleType] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[ntpStatus] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[onePpsPresent] [bit] NOT NULL,
	[outputAttenuation] [real] NOT NULL,
	[outputRfCenterFrequency] [float] NOT NULL,
	[outputRfDacSaturation] [real] NOT NULL,
	[outputRfDacSaturationPercent] [real] NOT NULL,
	[outputRfPort1DacSaturation] [real] NOT NULL,
	[outputRfPort1DacSaturationPercent] [real] NOT NULL,
	[outputRfPort1Power] [real] NOT NULL,
	[outputRfPort2DacSaturation] [real] NOT NULL,
	[outputRfPort2DacSaturationPercent] [real] NOT NULL,
	[outputRfPort2Power] [real] NOT NULL,
	[outputRfPortSelect] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[outputRfPower] [real] NOT NULL,
	[overrideOutputFrequency] [real] NOT NULL,
	[overrideOutputFrequencyEnable] [bit] NOT NULL,
	[pollInterval] [numeric](10, 0) NOT NULL,
	[posixNanoseconds] [numeric](10, 0) NOT NULL,
	[posixSeconds] [numeric](10, 0) NOT NULL,
	[rebootRequired] [bit] NOT NULL,
	[replyWaitTime] [nvarchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
	[requiredReadPrivilege] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[requiredWritePrivilege] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[rfOutputEnable] [bit] NOT NULL,
	[rfOutputSource] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[securitySource] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[serialNumber] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[shortDescription] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[simulate] [bit] NOT NULL,
	[squelchEnabled] [bit] NOT NULL,
	[systemTemperature] [int] NOT NULL,
	[systemTimeSource] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[tenMhzLocked] [bit] NOT NULL,
	[version] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,

 CONSTRAINT [PK_M_Modules]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO
/****** Object:  Table [dbo].[M_MulticastGroupSubscriptions]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_MulticastGroupSubscriptions]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[McastAddr] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,

 CONSTRAINT [PK_M_MulticastGroupSubscriptions]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO
/****** Object:  Table [dbo].[M_OutputRfPort1Spectrum]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_OutputRfPort1Spectrum]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[Spectrum] [nvarchar](max) COLLATE Latin1_General_CI_AS NOT NULL,

 CONSTRAINT [PK_M_OutputRfPort1Spectrum]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO
/****** Object:  Table [dbo].[M_OutputRfPort2Spectrum]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_OutputRfPort2Spectrum]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[Spectrum] [nvarchar](max) COLLATE Latin1_General_CI_AS NOT NULL,

 CONSTRAINT [PK_M_OutputRfPort2Spectrum]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO
/****** Object:  Table [dbo].[M_OutputRfSpectrum]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_OutputRfSpectrum]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[Spectrum] [nvarchar](max) COLLATE Latin1_General_CI_AS NOT NULL,

 CONSTRAINT [PK_M_OutputRfSpectrum]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO
/****** Object:  Table [dbo].[M_RfInputStream]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_RfInputStream]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[name] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[bitRate] [numeric](10, 0) NOT NULL,
	[dataSampleWidth] [numeric](5, 0) NOT NULL,
	[destinationHost] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[destinationPort] [numeric](5, 0) NOT NULL,
	[frequencyOffset] [bigint] NOT NULL,
	[maximumPacketSize] [numeric](10, 0) NOT NULL,
	[measuredNetworkRate] [numeric](20, 0) NOT NULL,
	[measuredPacketRate] [numeric](10, 0) NOT NULL,
	[minimumProcessingDelay] [float] NOT NULL,
	[packetOverhead] [float] NOT NULL,
	[pfecEnable] [bit] NOT NULL,
	[routeSearch] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[sourcePort] [numeric](5, 0) NOT NULL,
	[streamBandwidth] [numeric](20, 0) NOT NULL,
	[streamEnable] [bit] NOT NULL,
	[streamGain] [float] NOT NULL,
	[streamId] [numeric](10, 0) NOT NULL,
	[streamSampleRate] [float] NOT NULL,

 CONSTRAINT [PK_M_RfInputStream]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO
/****** Object:  Table [dbo].[M_RfOutputStream]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_RfOutputStream]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[name] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[currentBuffer] [float] NOT NULL,
	[dataSampleWidth] [numeric](5, 0) NOT NULL,
	[dataSource] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[desiredBuffer] [numeric](10, 0) NOT NULL,
	[desiredDelay] [numeric](10, 0) NOT NULL,
	[destinationPort] [numeric](5, 0) NOT NULL,
	[droppedPackets] [numeric](10, 0) NOT NULL,
	[frequencyOffset] [bigint] NOT NULL,
	[gapCount] [numeric](10, 0) NOT NULL,
	[measuredDelay] [numeric](10, 0) NOT NULL,
	[measuredNetworkRate] [numeric](20, 0) NOT NULL,
	[measuredPacketRate] [numeric](10, 0) NOT NULL,
	[netStreamGain] [float] NOT NULL,
	[networkDelay] [float] NOT NULL,
	[packetOverhead] [float] NOT NULL,
	[pfecDecoderStatus] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[pfecMissingSets] [numeric](10, 0) NOT NULL,
	[pfecRepairedPackets] [numeric](10, 0) NOT NULL,
	[pfecTotalPackets] [numeric](20, 0) NOT NULL,
	[pfecUnrepairablePackets] [numeric](10, 0) NOT NULL,
	[preserveLatency] [bit] NOT NULL,
	[preserveLatencyLatePackets] [numeric](10, 0) NOT NULL,
	[preserveLatencyMaxBurstLoss] [numeric](10, 0) NOT NULL,
	[preserveLatencyMissingPackets] [numeric](10, 0) NOT NULL,
	[preserveLatencyOutOfOrderPackets] [numeric](10, 0) NOT NULL,
	[preserveLatencyReleaseMargin] [numeric](10, 0) NOT NULL,
	[releaseMode] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[sourceHost] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[sourcePort] [numeric](5, 0) NOT NULL,
	[streamBandwidth] [float] NOT NULL,
	[streamEnable] [bit] NOT NULL,
	[streamId] [numeric](10, 0) NOT NULL,
	[streamSampleRate] [float] NOT NULL,
	[underflowCount] [numeric](10, 0) NOT NULL,
	[upstreamIrigLocked] [bit] NOT NULL,
	[upstreamOnePpsLocked] [bit] NOT NULL,
	[upstreamPathGain] [float] NOT NULL,
	[upstreamTenMhzLocked] [bit] NOT NULL,
	[useLocalReference] [bit] NOT NULL,

 CONSTRAINT [PK_M_RfOutputStream]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO
/****** Object:  Table [dbo].[M_Routes]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Routes]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[destination] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[gateway] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[netmask] [int] NOT NULL,

 CONSTRAINT [PK_M_Routes]  PRIMARY KEY NONCLUSTERED HASH 
(
	[id]
)WITH ( BUCKET_COUNT = 256)
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_ONLY )
GO
/****** Object:  Table [dbo].[M_SpectralNetGroups]    Script Date: 26/07/2023 14:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_SpectralNetGroups]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateStamp] [datetime2](7) NOT NULL,
	[ClusterID] [int] NOT NULL,
	[ClusterName] [nvarchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
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
SET IDENTITY_INSERT [dbo].[H_FormatConfig] ON 

INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (1, N'Module', N'active', N'RW', N'TRUE', NULL, NULL, NULL, N'Set whether module is active or not')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (2, N'Module', N'address', N'RW', N'', NULL, NULL, NULL, N'NTP Server Address')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (3, N'Module', N'compositeStatus', N'RO', N'good', NULL, NULL, NULL, N'Composite status for this module - a composite of both the health status and the operational status')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (4, N'Module', N'compositeStatusMsg', N'RO', N'', NULL, NULL, NULL, N'Reason for current composite status value')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (5, N'Module', N'contextPacketState', N'RO', N'Normal', NULL, NULL, NULL, N'Current state of received context packets')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (6, N'Module', N'currentGain', N'RO', N'39', NULL, NULL, NULL, N'Gain in 1dB steps. Maximum gain can be lower than 73dB at certain frequencies.')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (7, N'Module', N'discardedPackets', N'RO', N'98', NULL, NULL, NULL, N'Number of Ethernet packets discarded because they don’t match our filters')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (8, N'Module', N'enableMulticastGroupSubscriptions', N'RW', N'FALSE', NULL, NULL, NULL, N'Subscribe to groups in multicastGroupSubscriptions')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (9, N'Module', N'fanSpeed', N'RO', N'5280', NULL, NULL, N'RPM', N'Fan speed')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (10, N'Module', N'gainMode', N'RW', N'Manual', NULL, NULL, NULL, N'Gain mode')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (11, N'Module', N'gateway', N'RW', N'192.168.120.10', NULL, NULL, NULL, N'Default gateway')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (12, N'Module', N'healthStatus', N'RO', N'good', NULL, NULL, NULL, N'Health indicator for the module - is the module able to perform its function')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (13, N'Module', N'healthStatusMsg', N'RO', N'', NULL, NULL, NULL, N'Reason for current health status')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (14, N'Module', N'inputRfAdcSaturation', N'RO', N'-10.763101578', NULL, N'N1', N'dBFS', N'ADC saturation level')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (15, N'Module', N'inputRfAdcSaturationPercent', N'RO', N'92.783180237', NULL, N'N1', N'%', N'ADC saturation level')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (16, N'Module', N'inputRfBandwidth', N'RW', N'54.0', NULL, NULL, N'MHz', N'System RF input Bandwidth')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (17, N'Module', N'inputRfCenterFrequency', N'RW', N'1421.0500488', NULL, N'N4', N'MHz', N'The RF/IF center for all Rx channels')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (18, N'Module', N'inputRfPort1AdcSaturation', N'RO', N'-10.763101578', NULL, N'N1', N'dBFS', N'Port1 ADC saturation level')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (19, N'Module', N'inputRfPort1AdcSaturationPercent', N'RO', N'92.783180237', NULL, N'N1', N'%', N'Port1 ADC saturation level')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (20, N'Module', N'inputRfPort1MinimumGain', N'RO', N'71', NULL, NULL, N'dB', N'Port1 The min gain since entering AGC mode')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (21, N'Module', N'inputRfPort1Power', N'RO', N'-34.330123901', NULL, N'N1', N'dBm', N'Port1 Signal power')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (22, N'Module', N'inputRfPort2AdcSaturation', N'RO', N'-10.629526138', NULL, N'N1', NULL, N'Port2 ADC saturation level')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (23, N'Module', N'inputRfPort2AdcSaturationPercent', N'RO', N'92.985565186', NULL, N'N1', NULL, N'Port2 ADC saturation level')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (24, N'Module', N'inputRfPort2MinimumGain', N'RO', N'73', NULL, NULL, NULL, N'Port2 The min gain since entering AGC mode')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (25, N'Module', N'inputRfPort2Power', N'RO', N'4.8034496307', NULL, N'N1', NULL, N'Port2 Signal power')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (26, N'Module', N'inputRfPortSelect', N'RW', N'rfIn1', NULL, NULL, NULL, N'RF input port select')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (27, N'Module', N'inputRfPower', N'RO', N'-34.330123901', NULL, NULL, NULL, N'RF input power')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (28, N'Module', N'inputRfSampleRate', N'RO', N'60000000', 1000000, N'N2', N'Msps', N'Sample rate for complex samples on the Rx and Tx channels')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (29, N'Module', N'invertRfOutputSpectrum', N'RW', N'FALSE', NULL, NULL, NULL, N'Perform a spectral inversion on all Tx channels')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (30, N'Module', N'irigDcLocked', N'RO', N'FALSE', NULL, NULL, NULL, N'Whether the IRIG DC is locked')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (31, N'Module', N'irigLocked', N'RO', N'FALSE', NULL, NULL, NULL, N'Whether the IRIG is locked')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (32, N'Module', N'label', N'RW', N'spectralNet', NULL, NULL, NULL, N'The label for this module')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (33, N'Module', N'logLevel', N'RW', N'information', NULL, NULL, NULL, N'Current log level of module')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (34, N'Module', N'manualGain', N'RW', N'39', NULL, NULL, NULL, N'Manual gain of the currently selected RF input port')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (35, N'Module', N'minimumGain', N'RO', N'71', NULL, NULL, NULL, N'The min gain since entering AGC mode')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (36, N'Module', N'moduleState', N'RO', N'Operational', NULL, NULL, NULL, N'Current state of the module. It might be performing some operation, or be in standard operation')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (37, N'Module', N'moduleType', N'RO', N'SpectralNet Module', NULL, NULL, NULL, N'The type of this module')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (38, N'Module', N'ntpStatus', N'RO', N'Not Locked', NULL, NULL, NULL, N'NTP Status')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (39, N'Module', N'onePpsPresent', N'RO', N'TRUE', NULL, NULL, NULL, N'One PPS signal is present')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (40, N'Module', N'outputAttenuation', N'RW', N'0', NULL, NULL, NULL, N'The output attenuation in dB')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (41, N'Module', N'outputRfCenterFrequency', N'RO', N'1200', NULL, NULL, N'MHz', N'RF output center frequency')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (42, N'Module', N'outputRfDacSaturation', N'RO', N'-60', NULL, NULL, N'dBFS', N'DAC saturation level')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (43, N'Module', N'outputRfDacSaturationPercent', N'RO', N'18.181818008', NULL, N'N1', N'%', N'DAC saturation level')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (44, N'Module', N'outputRfPort1DacSaturation', N'RO', N'-60', NULL, NULL, N'dBFS', N'Port1 DAC saturation level')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (45, N'Module', N'outputRfPort1DacSaturationPercent', N'RO', N'18.181818008', NULL, N'N1', N'%', N'Port1 DAC saturation level')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (46, N'Module', N'outputRfPort1Power', N'RO', N'-50.241001129', NULL, N'N1', N'dBm', N'Port1 Signal power')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (47, N'Module', N'outputRfPort2DacSaturation', N'RO', N'-60', NULL, NULL, N'dBFS', N'Port2 DAC saturation level')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (48, N'Module', N'outputRfPort2DacSaturationPercent', N'RO', N'18.181818008', NULL, N'N1', N'%', N'Port2 DAC saturation level')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (49, N'Module', N'outputRfPort2Power', N'RO', N'-50.241001129', NULL, N'N1', N'dBm', N'Port2 Signal power')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (50, N'Module', N'outputRfPortSelect', N'RW', N'rfOut1', NULL, NULL, NULL, N'RF output port select')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (51, N'Module', N'outputRfPower', N'RO', N'-50.241001129', NULL, N'N1', N'dBm', N'Signal power')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (52, N'Module', N'overrideOutputFrequency', N'RW', N'1200', NULL, NULL, N'MHz', N'Manually specified RF Output frequency which is used when overrideOutputFrequencyEnable is true')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (53, N'Module', N'overrideOutputFrequencyEnable', N'RW', N'FALSE', NULL, NULL, NULL, N'Override the output frequency specified in IF Context packets')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (54, N'Module', N'pollInterval', N'RO', N'1000', NULL, NULL, N'ms', N'An interval to use when polling this module instead of using events')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (55, N'Module', N'posixNanoseconds', N'RO', N'577616640', NULL, NULL, NULL, N'The nanoseconds count of the current POSIX time')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (56, N'Module', N'posixSeconds', N'RO', N'1578202168', NULL, NULL, NULL, N'The seconds count of the current POSIX time')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (57, N'Module', N'rebootRequired', N'RO', N'FALSE', NULL, NULL, NULL, N'System reboot is required')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (58, N'Module', N'replyWaitTime', NULL, N'00:01:00', NULL, NULL, NULL, N'Time to wait for backing attributes to repond to messages')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (59, N'Module', N'requiredReadPrivilege', N'RO', N'', NULL, NULL, NULL, N'The privilege required for reading any attributes')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (60, N'Module', N'requiredWritePrivilege', N'RO', N'', NULL, NULL, NULL, N'The privilege required for writing any attributes')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (61, N'Module', N'rfOutputEnable', N'RW', N'FALSE', NULL, NULL, NULL, N'Whether the RF Output is enabled')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (62, N'Module', N'rfOutputSource', N'RW', N'Packets', NULL, NULL, NULL, N'RF Out Source')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (63, N'Module', N'securitySource', N'RW', N'No Certificate', NULL, NULL, NULL, N'Which certificate (if any) to use when identifying this system')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (64, N'Module', N'serialNumber', N'RO', N'RT-201106219', NULL, NULL, NULL, N'SpectralNet Serial Number')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (66, N'Module', N'simulate', N'RO', N'FALSE', NULL, NULL, NULL, N'When true the module is in simulation mode')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (67, N'Module', N'squelchEnabled', N'RO', N'FALSE', NULL, NULL, NULL, N'Whether squelch is currently active')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (68, N'Module', N'systemTemperature', N'RO', N'42', NULL, NULL, NULL, N'FPGA Temperature')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (69, N'Module', N'systemTimeSource', N'RW', N'IRIG', NULL, NULL, NULL, N'System time source')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (70, N'Module', N'tenMhzLocked', N'RO', N'TRUE', NULL, NULL, NULL, N'Locked to the 10MHz reference')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (71, N'Module', N'version', N'RO', N'1.7.4', NULL, NULL, NULL, N'SpectralNet Version')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (72, N'AvailableStreams', N'sourceIpAddress', N'RW', N'192.168.60.2', NULL, NULL, NULL, N'Source IP Address')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (73, N'AvailableStreams', N'sourcePort', N'RW', N'50000', NULL, NULL, NULL, N'Source Port')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (74, N'AvailableStreams', N'streamId', N'RW', N'0', NULL, NULL, NULL, N'Stream ID')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (75, N'AvailableStreams', N'centerFrequency', N'RW', N'1200000000', 1000000, N'N2', N'MHz', N'Center Frequency')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (76, N'AvailableStreams', N'bandwidth', N'RW', N'5000000', 1000000, N'N2', N'MHz', N'Bandwidth')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (77, N'AvailableStreams', N'sampleRate', N'RW', N'5625000', 1000000, N'N2', N'Msps', N'Sample Rate')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (78, N'AvailableStreams', N'gain', N'RW', N'10', NULL, NULL, N'dB', N'Gain')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (79, N'AvailableStreams', N'sampleWidth', N'RW', N'10', NULL, NULL, N'bits', N'Sample Width')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (80, N'AvailableStreams', N'pfecEnabled', N'RW', N'FALSE', NULL, NULL, NULL, N'PFEC Enabled')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (81, N'AvailableStreams', N'irigLocked', N'RW', N'FALSE', NULL, NULL, NULL, N'IRIG Locked')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (82, N'AvailableStreams', N'onePpsPresent', N'RW', N'TRUE', NULL, NULL, NULL, N'One PPS Present')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (83, N'AvailableStreams', N'tenMhzLocked', N'RW', N'TRUE', NULL, NULL, NULL, N'Ten MHz Locked')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (84, N'RfOutputStream', N'name', N'RO', N'netToRf0', NULL, NULL, NULL, N'Name given to this channel instance')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (85, N'RfOutputStream', N'currentBuffer', N'RO', N'9216000', 1000000, N'N1', N'mSec', N'Current buffer')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (86, N'RfOutputStream', N'dataSampleWidth', N'RO', N'10', NULL, NULL, NULL, N'Data packet sample size in bits')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (87, N'RfOutputStream', N'dataSource', N'RW', N'Network', NULL, NULL, NULL, N'Data source for this stream')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (88, N'RfOutputStream', N'desiredBuffer', N'RW', N'10000000', 1000000, N'N1', N'mSec', N'Amount of data to buffer before releasing')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (89, N'RfOutputStream', N'desiredDelay', N'RW', N'10000000', 1000000, N'N1', N'mSec', N'Amount of time to delay the first released packet from its creation time when using Programmed Delay')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (90, N'RfOutputStream', N'destinationPort', N'RW', N'50000', NULL, NULL, NULL, N'Destination UDP Port on which to listen for this stream')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (91, N'RfOutputStream', N'droppedPackets', N'RO', N'0', NULL, NULL, NULL, N'Number of packets dropped by this stream')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (92, N'RfOutputStream', N'frequencyOffset', N'RW', N'0', 1000000, N'N1', N'MHz', N'Stream frequency offset from the front end frequency')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (93, N'RfOutputStream', N'gapCount', N'RO', N'1', NULL, NULL, NULL, N'Number of gaps detected in the VITA 49 data packet stream')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (94, N'RfOutputStream', N'measuredDelay', N'RO', N'10000000', 1000000, N'N1', N'mSec', N'Actual delay achieved')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (95, N'RfOutputStream', N'measuredNetworkRate', N'RO', N'118273680', 1000000, N'N1', N'Mbps', N'Measured incoming network rate')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (96, N'RfOutputStream', N'measuredPacketRate', N'RO', N'9765', 1000, N'N1', N'kpps', N'Measured incoming packet rate')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (97, N'RfOutputStream', N'netStreamGain', N'RO', N'10', NULL, NULL, NULL, N'The total gain of this stream')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (98, N'RfOutputStream', N'networkDelay', N'RO', N'722560', 1000000, N'N1', N'mSec', N'Path Delay')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (99, N'RfOutputStream', N'packetOverhead', N'RO', N'4.8877146631', NULL, N'N1', N'%', N'Packet overhead given the current settings')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (100, N'RfOutputStream', N'pfecDecoderStatus', N'RO', N'bypass', NULL, NULL, NULL, N'Indicates if packets are being decoded')
GO
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (101, N'RfOutputStream', N'pfecMissingSets', N'RO', N'0', NULL, NULL, NULL, N'The number of sets that never showed up')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (102, N'RfOutputStream', N'pfecRepairedPackets', N'RO', N'0', NULL, NULL, NULL, N'The number of repaired packets')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (103, N'RfOutputStream', N'pfecTotalPackets', N'RO', N'0', NULL, NULL, NULL, N'The number of packets processed')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (104, N'RfOutputStream', N'pfecUnrepairablePackets', N'RO', N'0', NULL, NULL, NULL, N'The number of unrepaired packets')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (105, N'RfOutputStream', N'preserveLatency', N'RW', N'FALSE', NULL, NULL, NULL, N'Preserves latency by replacing missing packets and discarding late packets')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (106, N'RfOutputStream', N'preserveLatencyLatePackets', N'RO', N'0', NULL, NULL, NULL, N'Number of packets discarded due to late arrival when initially releasing data')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (107, N'RfOutputStream', N'preserveLatencyMaxBurstLoss', N'RO', N'1000', NULL, NULL, NULL, N'The max burst loss of packets to replace')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (108, N'RfOutputStream', N'preserveLatencyMissingPackets', N'RO', N'0', NULL, NULL, NULL, N'Number of missing packets that were replaced by fill data')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (109, N'RfOutputStream', N'preserveLatencyOutOfOrderPackets', N'RO', N'0', NULL, NULL, NULL, N'Number of packets discarded since they were out of order')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (110, N'RfOutputStream', N'preserveLatencyReleaseMargin', N'RW', N'1000', NULL, NULL, N'nSec', N'Packets exceeding this margin are declared late')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (111, N'RfOutputStream', N'releaseMode', N'RW', N'Programmed Delay', NULL, NULL, NULL, N'Release mode to use. Buffer mode will attempt to maintain a prescribed buffer. Time release mode will attempt to')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (112, N'RfOutputStream', N'sourceHost', N'RO', N'192.168.60.2', NULL, NULL, NULL, N'IP address of the source feeding this stream')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (113, N'RfOutputStream', N'sourcePort', N'RO', N'50000', NULL, NULL, NULL, N'Source UDP Port feeding this stream')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (114, N'RfOutputStream', N'streamBandwidth', N'RO', N'5000000', 1000000, N'N1', N'MHz', N'Stream bandwidth')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (115, N'RfOutputStream', N'streamEnable', N'RO', N'TRUE', NULL, NULL, NULL, N'Enable/disable of this stream')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (116, N'RfOutputStream', N'streamId', N'RW', N'0', NULL, NULL, NULL, N'VITA 49 Stream ID for this stream')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (117, N'RfOutputStream', N'streamSampleRate', N'RO', N'5625000', 1000000, N'N1', N'Msps', N'Current sample rate')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (118, N'RfOutputStream', N'underflowCount', N'RO', N'139', NULL, NULL, NULL, N'Number of times the release process ran out of data')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (119, N'RfOutputStream', N'upstreamIrigLocked', N'RO', N'FALSE', NULL, NULL, NULL, N'Whether the upstream IRIG is locked')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (120, N'RfOutputStream', N'upstreamOnePpsLocked', N'RO', N'TRUE', NULL, NULL, NULL, N'Whether the upstream 1 PPS is locked')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (121, N'RfOutputStream', N'upstreamPathGain', N'RO', N'10', NULL, NULL, NULL, N'The path gain in the upstream RF-to-Net portion')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (122, N'RfOutputStream', N'upstreamTenMhzLocked', N'RO', N'TRUE', NULL, NULL, NULL, N'Whether the upstream 10 MHz is locked')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (123, N'RfOutputStream', N'useLocalReference', N'RW', N'TRUE', NULL, NULL, NULL, N'Use local reference for clocking data. When disabled, this affects Rf-to-Net as well.')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (124, N'RfInputStream', N'name', N'RO', N'rfToNet0', NULL, NULL, NULL, N'Name given to this channel instance')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (125, N'RfInputStream', N'bitRate', N'RO', N'946250474', NULL, NULL, NULL, N'Calculated payload bit rate for this stream')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (126, N'RfInputStream', N'dataSampleWidth', N'RW', N'9', NULL, NULL, NULL, N'Data packet sample size in bits')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (127, N'RfInputStream', N'destinationHost', N'RW', N'192.168.60.2', NULL, NULL, NULL, N'IPv4 address of the destination for this stream')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (128, N'RfInputStream', N'destinationPort', N'RW', N'50000', NULL, NULL, NULL, N'UDP destination port number for packets sent by this stream')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (129, N'RfInputStream', N'frequencyOffset', N'RW', N'0', NULL, NULL, NULL, N'Stream frequency offset from the front end frequency')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (130, N'RfInputStream', N'maximumPacketSize', N'RW', N'1500', NULL, NULL, N'bytes', N'Maximum size of the IP data packet')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (131, N'RfInputStream', N'measuredNetworkRate', N'RO', N'946250000', 1000000, N'N1', N'Mbps', N'Measured rate being sent to the network')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (132, N'RfInputStream', N'measuredPacketRate', N'RO', N'78125', 1000, N'N1', N'kpps', N'Outgoing packet rate for this stream')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (133, N'RfInputStream', N'minimumProcessingDelay', N'RO', N'24799.9936', 1000000, N'N1', N'mSec', N'Minimum possible processing delay given the current settings')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (134, N'RfInputStream', N'packetOverhead', N'RO', N'4.8877146631', NULL, NULL, N'%', N'Packet overhead given the current settings')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (135, N'RfInputStream', N'pfecEnable', N'RW', N'FALSE', NULL, NULL, NULL, N'Enable or bypass the PFEC encoder')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (136, N'RfInputStream', N'routeSearch', N'RO', N'Found', NULL, NULL, NULL, N'Status of search for route to destination IP')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (137, N'RfInputStream', N'sourcePort', N'RW', N'50000', NULL, NULL, NULL, N'UDP source port number for packets sent by this stream')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (138, N'RfInputStream', N'streamBandwidth', N'RW', N'45000000', 1000000, N'N1', N'MHz', N'Stream bandwidth')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (139, N'RfInputStream', N'streamEnable', N'RO', N'TRUE', NULL, NULL, NULL, N'Enable/disable of this stream')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (140, N'RfInputStream', N'streamGain', N'RW', N'0', NULL, NULL, N'dB', N'Gain to apply to this stream')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (141, N'RfInputStream', N'streamId', N'RW', N'0', NULL, NULL, NULL, N'Data packet stream ID')
INSERT [dbo].[H_FormatConfig] ([Id], [Table], [Attribute], [Access], [Normal], [Scale], [Format], [Units], [Help]) VALUES (142, N'RfInputStream', N'streamSampleRate', N'RW', N'50000025', 1000000, N'N1', N'Msps', N'Sample rate of this stream')
SET IDENTITY_INSERT [dbo].[H_FormatConfig] OFF
GO
SET IDENTITY_INSERT [dbo].[H_RangeConfig] ON 

INSERT [dbo].[H_RangeConfig] ([Id], [Unit], [Table], [Attribute], [Lower], [Upper], [Enabled], [InRange]) VALUES (1, N'Default', N'Module', N'fanSpeed', 4000, 7000, 1, 1)
INSERT [dbo].[H_RangeConfig] ([Id], [Unit], [Table], [Attribute], [Lower], [Upper], [Enabled], [InRange]) VALUES (2, N'Default', N'Module', N'inputRfAdcSaturationPercent', 10, 96, 1, 1)
INSERT [dbo].[H_RangeConfig] ([Id], [Unit], [Table], [Attribute], [Lower], [Upper], [Enabled], [InRange]) VALUES (3, N'Default', N'Module', N'systemTemperature', 30, 60, 1, 1)
INSERT [dbo].[H_RangeConfig] ([Id], [Unit], [Table], [Attribute], [Lower], [Upper], [Enabled], [InRange]) VALUES (4, N'Default', N'RfOutputStream', N'measuredDelay', 1900000, 2100000, 1, 1)
INSERT [dbo].[H_RangeConfig] ([Id], [Unit], [Table], [Attribute], [Lower], [Upper], [Enabled], [InRange]) VALUES (5, N'Default', N'RfOutputStream', N'measuredNetworkRate', 10000000, 980000000, 1, 1)
INSERT [dbo].[H_RangeConfig] ([Id], [Unit], [Table], [Attribute], [Lower], [Upper], [Enabled], [InRange]) VALUES (6, N'Default', N'RfOutputStream', N'networkDelay', 600000, 900000, 1, 1)
INSERT [dbo].[H_RangeConfig] ([Id], [Unit], [Table], [Attribute], [Lower], [Upper], [Enabled], [InRange]) VALUES (7, N'Default', N'RfInputStream', N'bitRate', 10000000, 980000000, 1, 1)
SET IDENTITY_INSERT [dbo].[H_RangeConfig] OFF
GO
SET IDENTITY_INSERT [dbo].[H_SpectralNetGroups] ON 

INSERT [dbo].[H_SpectralNetGroups] ([id], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Timeout], [Enabled]) VALUES (1, 2, N'WRW ANT2', 201, N'AUC-WRW LH1', N'Baseband', 2000, N'AUC-LH1A', N'WRW-LH1A', N'AUC-LH1B', N'AUC Chassis name', N'Auckland SAS', N'10.228.41.179', N'Primary', 1, 500, 1)
INSERT [dbo].[H_SpectralNetGroups] ([id], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Timeout], [Enabled]) VALUES (2, 2, N'WRW ANT2', 201, N'AUC-WRW LH1', N'Antenna', 2100, N'WRW-LH1A', N'AUC-LH1A', N'WRW-LH1B', N'AUC Chassis name', N'Warkworth SAS', N'10.229.41.179', N'Primary', 51, 500, 1)
INSERT [dbo].[H_SpectralNetGroups] ([id], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Timeout], [Enabled]) VALUES (3, 2, N'WRW ANT2', 201, N'AUC-WRW LH1', N'Baseband', 2001, N'AUC-LH1B', N'WRW-LH1B', N'AUC-LH1A', N'AUC Chassis name', N'Auckland SAS', N'10.228.41.160', N'Secondary', 2, 500, 1)
INSERT [dbo].[H_SpectralNetGroups] ([id], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Timeout], [Enabled]) VALUES (4, 2, N'WRW ANT2', 201, N'AUC-WRW LH1', N'Antenna', 2101, N'WRW-LH1B', N'AUC-LH1B', N'WRW-LH1A', N'AUC Chassis name', N'Warkworth SAS', N'10.229.41.160', N'Secondary', 52, 500, 1)
INSERT [dbo].[H_SpectralNetGroups] ([id], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Timeout], [Enabled]) VALUES (5, 2, N'WRW ANT2', 202, N'AUC-WRW LH2', N'Baseband', 2002, N'AUC-LH2A', N'WRW-LH2A', N'AUC-LH2B', N'AUC Chassis name', N'Auckland SAS', N'10.228.41.161', N'Primary', 3, 500, 1)
INSERT [dbo].[H_SpectralNetGroups] ([id], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Timeout], [Enabled]) VALUES (6, 2, N'WRW ANT2', 202, N'AUC-WRW LH2', N'Antenna', 2102, N'WRW-LH2A', N'AUC-LH2A', N'WRW-LH2B', N'AUC Chassis name', N'Warkworth SAS', N'10.229.41.161', N'Primary', 53, 500, 1)
INSERT [dbo].[H_SpectralNetGroups] ([id], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Timeout], [Enabled]) VALUES (7, 2, N'WRW ANT2', 202, N'AUC-WRW LH2', N'Baseband', 2003, N'AUC-LH2B', N'WRW-LH2B', N'AUC-LH2A', N'AUC Chassis name', N'Auckland SAS', N'10.228.41.162', N'Secondary', 4, 500, 1)
INSERT [dbo].[H_SpectralNetGroups] ([id], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Timeout], [Enabled]) VALUES (8, 2, N'WRW ANT2', 202, N'AUC-WRW LH2', N'Antenna', 2103, N'WRW-LH2B', N'AUC-LH2B', N'WRW-LH2A', N'AUC Chassis name', N'Warkworth SAS', N'10.229.41.162', N'Secondary', 54, 500, 1)
INSERT [dbo].[H_SpectralNetGroups] ([id], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Timeout], [Enabled]) VALUES (9, 2, N'WRW ANT2', 203, N'AUC-WRW RH1', N'Baseband', 2004, N'AUC-RH1A', N'WRW-RH1A', N'AUC-RH1B', N'AUC Chassis name', N'Auckland SAS', N'10.228.41.163', N'Primary', 5, 500, 1)
INSERT [dbo].[H_SpectralNetGroups] ([id], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Timeout], [Enabled]) VALUES (10, 2, N'WRW ANT2', 203, N'AUC-WRW RH1', N'Antenna', 2104, N'WRW-RH1A', N'AUC-RH1A', N'WRW-RH1B', N'AUC Chassis name', N'Warkworth SAS', N'10.229.41.163', N'Primary', 55, 500, 1)
INSERT [dbo].[H_SpectralNetGroups] ([id], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Timeout], [Enabled]) VALUES (11, 2, N'WRW ANT2', 203, N'AUC-WRW RH1', N'Baseband', 2005, N'AUC-RH1B', N'WRW-RH1B', N'AUC-RH1A', N'AUC Chassis name', N'Auckland SAS', N'10.228.41.164', N'Secondary', 6, 500, 1)
INSERT [dbo].[H_SpectralNetGroups] ([id], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Timeout], [Enabled]) VALUES (12, 2, N'WRW ANT2', 203, N'AUC-WRW RH1', N'Antenna', 2105, N'WRW-RH1B', N'AUC-RH1B', N'WRW-RH1A', N'AUC Chassis name', N'Warkworth SAS', N'10.229.41.164', N'Secondary', 56, 500, 1)
INSERT [dbo].[H_SpectralNetGroups] ([id], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Timeout], [Enabled]) VALUES (13, 2, N'WRW ANT2', 204, N'AUC-WRW RH2', N'Baseband', 2006, N'AUC-RH2A', N'WRW-RH2A', N'AUC-RH2B', N'AUC Chassis name', N'Auckland SAS', N'10.228.41.165', N'Primary', 7, 500, 1)
INSERT [dbo].[H_SpectralNetGroups] ([id], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Timeout], [Enabled]) VALUES (14, 2, N'WRW ANT2', 204, N'AUC-WRW RH2', N'Antenna', 2106, N'WRW-RH2A', N'AUC-RH2A', N'WRW-RH2B', N'AUC Chassis name', N'Warkworth SAS', N'10.229.41.165', N'Primary', 57, 500, 1)
INSERT [dbo].[H_SpectralNetGroups] ([id], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Timeout], [Enabled]) VALUES (15, 2, N'WRW ANT2', 204, N'AUC-WRW RH2', N'Baseband', 2007, N'AUC-RH2B', N'WRW-RH2B', N'AUC-RH2A', N'AUC Chassis name', N'Auckland SAS', N'10.228.41.166', N'Secondary', 8, 500, 1)
INSERT [dbo].[H_SpectralNetGroups] ([id], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Timeout], [Enabled]) VALUES (16, 2, N'WRW ANT2', 204, N'AUC-WRW RH2', N'Antenna', 2107, N'WRW-RH2B', N'AUC-RH2B', N'WRW-RH2A', N'AUC Chassis name', N'Warkworth SAS', N'10.229.41.166', N'Secondary', 58, 500, 1)
SET IDENTITY_INSERT [dbo].[H_SpectralNetGroups] OFF
GO
SET IDENTITY_INSERT [dbo].[H_SystemParam] ON 

INSERT [dbo].[H_SystemParam] ([id], [PreIpAddress], [RestQuery], [PollPeriod], [Timeout], [Verbose], [AutoOn], [SwitchAll], [SwitchDelay], [On_A_Path]) VALUES (1, N'http://', N'/rest/spectralNet/_attribute?_dive=true', 2000, 500, 1, 0, 0, 3, 0)
SET IDENTITY_INSERT [dbo].[H_SystemParam] OFF
GO
SET IDENTITY_INSERT [dbo].[M_AvailableStreams] ON 

INSERT [dbo].[M_AvailableStreams] ([id], [UnitId], [sourceIpAddress], [sourcePort], [streamId], [centerFrequency], [bandwidth], [sampleRate], [gain], [sampleWidth], [pfecEnabled], [irigLocked], [onePpsPresent], [tenMhzLocked]) VALUES (12, 2000, N'192.168.201.10', N'50000', CAST(0 AS Numeric(10, 0)), 1350000000, 20000000, 22500000, 20, CAST(10 AS Numeric(5, 0)), 0, 0, 1, 1)
INSERT [dbo].[M_AvailableStreams] ([id], [UnitId], [sourceIpAddress], [sourcePort], [streamId], [centerFrequency], [bandwidth], [sampleRate], [gain], [sampleWidth], [pfecEnabled], [irigLocked], [onePpsPresent], [tenMhzLocked]) VALUES (13, 2100, N'192.168.200.10', N'50000', CAST(0 AS Numeric(10, 0)), 1355500000, 20000000, 22500000, 10, CAST(10 AS Numeric(5, 0)), 0, 0, 1, 1)
SET IDENTITY_INSERT [dbo].[M_AvailableStreams] OFF
GO
SET IDENTITY_INSERT [dbo].[M_ControlNic] ON 

INSERT [dbo].[M_ControlNic] ([id], [UnitId], [addresses], [address], [netmask]) VALUES (12, 2000, N'manual', N'10.228.41.179', 26)
INSERT [dbo].[M_ControlNic] ([id], [UnitId], [addresses], [address], [netmask]) VALUES (13, 2100, N'manual', N'10.229.41.179', 26)
SET IDENTITY_INSERT [dbo].[M_ControlNic] OFF
GO
SET IDENTITY_INSERT [dbo].[M_DataNic] ON 

INSERT [dbo].[M_DataNic] ([id], [UnitId], [addresses], [address], [netmask]) VALUES (12, 2000, N'manual', N'192.168.200.10', 24)
INSERT [dbo].[M_DataNic] ([id], [UnitId], [addresses], [address], [netmask]) VALUES (13, 2100, N'manual', N'192.168.201.10', 24)
SET IDENTITY_INSERT [dbo].[M_DataNic] OFF
GO
SET IDENTITY_INSERT [dbo].[M_Dependencies] ON 

INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23496, 2000, N'ntp')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23495, 2000, N'irig')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23493, 2000, N'ad936xController')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23498, 2000, N'scheduledSquelch')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23497, 2000, N'saturnModule')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23500, 2000, N'saturnBoard')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23494, 2000, N'rfTuner')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23491, 2000, N'rfToNet0')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23492, 2000, N'netToRf0')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23499, 2000, N'sampleCapture')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23506, 2100, N'ntp')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23505, 2100, N'irig')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23508, 2100, N'scheduledSquelch')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23503, 2100, N'ad936xController')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23507, 2100, N'saturnModule')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23502, 2100, N'netToRf0')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23501, 2100, N'rfToNet0')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23509, 2100, N'sampleCapture')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23510, 2100, N'saturnBoard')
INSERT [dbo].[M_Dependencies] ([id], [UnitId], [dependant]) VALUES (23504, 2100, N'rfTuner')
SET IDENTITY_INSERT [dbo].[M_Dependencies] OFF
GO
SET IDENTITY_INSERT [dbo].[M_InputRfPort1Spectrum] ON 

INSERT [dbo].[M_InputRfPort1Spectrum] ([id], [UnitId], [Spectrum]) VALUES (12, 2000, N'0xFFA6FFA7FFAAFFABFFABFFABFFABFFACFFAAFFAAFFAAFFABFFACFFADFFABFFABFFACFFADFFADFFADFFACFFACFFACFFADFFAEFFACFFA9FFA9FFABFFACFFACFFAAFFACFFAEFFAEFFABFFACFFADFFADFFADFFADFFACFFABFFAEFFB0FFAFFFADFFABFFA9FFABFFACFFAAFFA9FFAAFFABFFAAFFA8FFA7FFA9FFABFFADFFADFFADFFAAFFA7FFAAFFABFFAAFFABFFAAFFABFFAAFFA9FFAAFFABFFA9FFA7FFA8FFABFFAAFFAAFFAAFFA9FFAAFFABFFABFFABFFABFFAAFFA9FFA9FFA9FFA9FFABFFAAFFA8FFA9FFA8FFA5FFA3FFA6FFA7FFA8FFAAFFA9FFA7FFA8FFA8FFA7FFA8FFA7FFA7FFA6FFA8FFA9FFA9FFA6FFA6FFA6FFA7FFA7FFA4FFA5FFA6FFA6FFA8FFA8FFA8FFA8FFA7FFA6FFA6FFA7FFA6FFA8FFA6FFA4FFA5FFA4FFA4FFA5FFA6FFA6FFA6FFA6FFA7FFA6FFA3FFA3FFA6FFA6FFA5FFA4FFA2FFA4FFA4FFA4FFA6FFA6FFA6FFA7FFA6FFA5FFA6FFA6FFA7FFA7FFA7FFA4FFA4FFA0FFA0FFA2FFA5FFA4FFA6FFA6FFA3FFA1FFA3FFA4FFA6FFA6FFA4FFA4FFA4FFA3FFA3FFA3FFA4FFA3FFA4FFA5FFA2FFA1FFA2FFA4FFA4FFA4FFA4FFA4FFA6FFA6FFA4FFA4FFA3FFA2FFA2FFA2FFA2FFA2FFA4FFA3FFA3FFA3FFA4FFA6FFA4FFA2FFA3FFA4FFA5FFA3FFA3FFA4FFA3FFA4FFA5FFA4FFA1FFA4FFA4FFA2FFA3FFA3FFA6FFA5FFA3FFA1FFA4FFA3FFA4FFA4FFA4FFA2FFA4FFA3FFA3FFA2FFA3FFA4FFA2FFA2FFA5FFA3FFA2FFA3FFA4FFA2FFA4FFA4FFA4FFA4FFA4FFA6FFA7FFA6FFA4FFA3FFA5FFA3FFA1FFA1FFA4FFA5FFA5FFA5FFA4FFA3FFA4FFA4FFA5FFA4FFA5FFA8FFA7FFA5FFA6FFA4FFA1FFA2FFA2FFA3FFA4FFA4FFA4FFA2FFA4FFA2FFA2FFA3FFA4FFA3FFA1FFA3FFA1FFA3FFA3FFA4FFA5FFA4FFA3FFA2FFA3FFA3FFA3FFA5FFA4FFA3FFA1FFA1FFA2FFA3FFA3FFA5FFA3FFA2FFA2FFA5FFA5FFA6FFA3FFA0FFA3FFA4FFA5FFA3FFA2FFA3FFA4FFA4FFA5FFA4FFA2FFA3FFA3FFA6FFA3FFA2FFA1FFA2FFA5FFA3FFA6FFA6FFA6FFA4FFA4FFA4FFA3FFA0FFA3FFA3FFA5FFA5FFA7FFABFFACFFA9FFA5FFA5FFA4FFA4FFA5FFA6FFA9FFAAFFAAFFA9FFAAFFA8FFAAFFAAFFA9FFC6FFD9FFE3FFE5FFE0FFD4FFBBFFA8FFA9FFAAFFAAFFA9FFA9FFA7FFA8FFA9FFA7FFA5FFA2FFA4FFA4FFA3FFA8FFAAFFA7FFA5FFA4FFA1FFA1FFA5FFA6FFA5FFA6FFA5FFA4FFA5FFA5FFA6FFA6FFA2FFA4FFA4FFA2FFA4FFA4FFA3FFA4FFA2FFA3FFA5FFA4FFA6FFA6FFA3FFA3FFA4FFA4FFA4FFA4FFA4FFA3FFA3FFA3FFA5FFA7FFA6FFA4FFA5FFA4FFA2FFA3FFA3FFA4FFA1FFA2FFA5FFA5FFA4FFA3FFA0FFA4FFA3FFA1FFA3FFA4FFA4FFA3FFA1FFA2FFA3FFA3FFA4FFA4FFA5FFA7FFA7FFA6FFA4FFA4FFA4FFA3FFA3FFA5FFA5FFA4FFA5FFA4FFA4FFA2FFA5FFA5FFA4FFA3FFA3FFA2FFA4FFA5FFA3FFA1FFA1FFA2FFA3FFA2FFA1FF9FFFA5FFA6FFA8FFA8FFA5FFA4FFA4FFA2FFA3FFA1FFA5FFA4FFA6FFA6FFA5FFA3FFA6FFA6FFA2FFA2FFA2FFA2FFA4FFA5FFA4FFA1FFA4FFA6FFA4FFA5FFA4FFA3FFA1FFA1FFA2FFA3FFA3FFA2FFA1FFA4FFA5FFA5FFA4FFA1FFA3FFA4FFA4FFA4FFA2FFA3FFA2FFA2FFA0FFA2FFA5FFA5FFA2FFA2FFA4FFA4FFA3FFA3FFA5FFA3FFA2FFA2FFA3FFA4FFA3FFA3FFA4FFA2FFA3FFA1FFA2FFA2FFA4FFA3FFA0FFA2FFA3FFA4FFA4FFA3FFA2FFA4FFA4FFA4FFA4FFA3FFA4FFA4FFA3FFA0FFA2FFA4FFA1FFA3FFA5FFA5FFA4FFA2FF9FFFA2FFA4FFA5FFA5FFA2FFA1FFA4FFA4FFA2FFA4FFA5FFA6FFA5FFA4FFA4FFA3FFA4FFA5FFA6FFA4FFA3FFA3FFA3FFA2FFA5FFA5FFA4FFA3FFA3FFA4FFA4FFA1FFA2FFA2FFA3FFA2FFA3FFA3FFA3FFA3FFA3FFA2FFA2FFA3FFA3FFA1FFA1FFA3FFA3FFA1FFA3FFA2FFA4FFA5FFA3FFA2FFA1FFA3FFA5FFA4FFA1FFA1FFA3FFA4FFA3FFA4FFA6FFA6FFA5FFA5FFA5FFA1FFA1FFA3FFA3FFA2FF9EFFA3FFA4FFA3FFA3FFA5FFA5FFA5FFA3FFA2FFA1FFA3FFA3FFA3FFA5FFA5FFA4FFA4FFA3FFA3FFA2FFA3FFA2FFA3FFA3FFA5FFA1FFA1FFA0FFA2FFA3FFA3FFA4FFA6FFA6FFA4FFA2FFA0FFA1FFA4FFA4FFA3FFA4FFA3FFA2FFA3FFA3FFA4FFA5FFA4FFA6FFA5FFA5FFA6FFA4FFA3FFA3FFA2FFA4FFA4FFA3FFA1FFA1FFA2FFA2FFA2FFA4FFA5FFA4FFA4FFA5FFA1FFA1FFA3FFA3FFA2FFA5FFA3FF9FFF9FFFA0FFA3FFA3FFA2FFA1FFA2FFA4FFA3FFA3FFA4FFA4FFA4FFA6FFA4FFA3FFA4FFA5FFA4FFA5FFA4FFA4FFA2FFA4FFA4FFA4FFA7FFA5FFA3FFA5FFA3FFA5FFA5FFA4FFA4FFA4FFA2FFA2FFA4FFA3FFA5FFA5FFA6FFA5FFA2FFA2FFA3FFA2FFA3FFA6FFA6FFA5FFA4FFA5FFA4FFA5FFA6FFA7FFA6FFA5FFA6FFA4FFA2FFA4FFA5FFA5FFA4FFA5FFA5FFA5FFA4FFA4FFA4FFA5FFA3FFA4FFA5FFA5FFA4FFA2FFA1FFA3FFA6FFA6FFA7FFA6FFA6FFA6FFA7FFA4FFA4FFA4FFA5FFA6FFA7FFA7FFA6FFA5FFA3FFA5FFA7FFA6FFA6FFA7FFA7FFA7FFA8FFA9FFA7FFA3FFA5FFA6FFA4FFA6FFA5FFA4FFA4FFA5FFA5FFA5FFA5FFA6FFA6FFA4FFA7FFA2FFA3FFA4FFA7FFA9FFA7FFA4FFA4FFA7FFA7FFA6FFA8FFA9FFA8FFA7FFAAFFA6FFA5FFA7FFA4FFA6FFA9FFA8FFA8FFA8FFA9FFA7FF9EFFA5FFA7FFA8FFA8FFA8FFAAFFA8FFA7FFA7FFA9FFA9FFA8FFA6FFA7FFA6FFA9FFA8FFA9FFA8FFA7FFA9FFA9FFA8FFA9FFA9FFAAFFAAFFABFFACFFABFFAAFFAAFFABFFAAFFAAFFAAFFA9FFA9FFAAFFACFFABFFA9FFABFFABFFAAFFABFFACFFACFFABFFAAFFACFFACFFABFFAAFFAAFFAAFFABFFABFFADFFACFFA9FFA6FFA7FFACFFAEFFAEFFADFFACFFADFFAEFFABFFAAFFABFFACFFACFFABFFACFFACFFADFFADFFACFFADFFADFFADFFAAFFABFFADFFABFFACFFACFFABFFAAFFA8FFA9FFAAFFA9FFA9FFA8FFAAFFABFFAAFFA8FFA8FFA6')
INSERT [dbo].[M_InputRfPort1Spectrum] ([id], [UnitId], [Spectrum]) VALUES (13, 2100, N'0xFF9DFF9EFF9DFF9EFF9EFF9EFF9EFF9EFF9FFF9EFF9EFF9CFF9BFF9AFF9DFF9FFF9FFF9FFF9FFFA0FFA0FFA0FFA1FF9FFF9EFF9EFF9EFFA0FFA1FFA1FFA0FF9FFFA0FFA0FF9FFF9EFF9EFF9FFF9FFF9FFFA0FFA0FF9EFF9CFF9BFF9CFF9EFFA0FFA1FF9FFF9EFF9DFF9AFF9DFF9EFF9EFF9DFF9CFF9FFF9FFF9FFFA1FFA2FFA1FFA0FF9FFF9EFF9FFFA0FF9FFF9CFF9BFF9DFF9EFF9EFF9DFF9DFF9DFF9BFF9BFF9AFF9CFF9EFFA0FFA2FFA0FF9FFF9EFF9DFF9BFF9CFF9BFF9BFF9CFF99FF9AFF9DFF9CFF9DFF9CFF9BFF9CFF9DFF9CFF9BFF9DFF9DFF9CFF9BFF9CFF9DFF9DFF9EFF9DFF9BFF99FF9BFF9CFF99FF9AFF9CFF9CFF9BFF9BFF9CFF9CFF9CFF9AFF9CFF9DFF9CFF9BFF9AFF9BFF9CFF9BFF9CFF9CFF9CFF9CFF9BFF9DFF9DFF9BFF9AFF9AFF9AFF9BFF9CFF9DFF9BFF9BFF9CFF9BFF9BFF9AFF99FF9CFF9EFF9EFF9EFF9CFF9BFF9CFF9BFF9BFF9AFF9AFF9AFF99FF9BFF9EFF9EFF9CFF9BFF9CFF99FF99FF98FF98FF99FF9CFF99FF97FF99FF9BFF9DFF9CFF9BFF9BFF9BFF99FF99FF99FF9AFF99FF9AFF99FF98FF9AFF9BFF9CFF9AFF99FF99FF98FF99FF99FF98FF98FF97FF99FF9AFF9BFF9CFF9DFF9AFF99FF99FF98FF9AFF9BFF9CFF9BFF97FF99FF9CFF9BFF9CFF9BFF9AFF9BFF99FF98FF9AFF9CFF9CFF9CFF9CFF9CFF9BFF99FF9AFF9BFF9BFF9BFF9AFF9BFF9BFF99FF9BFF9CFF9BFF9BFF9CFF9DFF9DFF9BFF99FF9AFF9BFF99FF99FF98FF9AFF9CFF9CFF9BFF9AFF9AFF9BFF9DFF9CFF9AFF98FF98FF98FF98FF9AFF9BFF9CFF9BFF9BFF9AFF9AFF9BFF9CFF9CFF9AFF98FF9AFF9BFF9BFF9BFF9CFF9CFF9EFF9EFF9CFF9BFF9AFF9BFF9AFF98FF99FF99FF97FF99FF99FF99FF9AFF99FF97FF9AFF9AFF9BFF9CFF9CFF9BFF9DFF9CFF9AFF99FF98FF97FF99FF9AFF9BFF99FF99FF99FF9AFF99FF99FF99FF9AFF9BFF9BFF99FF99FF9AFF99FF98FF98FF9AFF9BFF9AFF9AFF9AFF9BFF9CFF9BFF9AFF99FF9AFF9AFF99FF9AFF9AFF99FF9AFF99FF97FF99FF99FF9AFF99FF9AFF9BFF9CFF9AFF98FF99FF9AFF9AFF99FF9BFF9BFF9BFF9CFF9CFF9BFF9BFF9BFF9BFF99FF9AFF9CFF9DFF9BFF98FF96FF98FF9AFF9AFF9AFF98FF9AFF9DFF9CFF9BFF9AFF99FF9AFF98FF99FF99FF98FF99FF97FF99FF99FF98FF99FF9AFF9BFF9CFF9CFF9BFF97FF99FF9AFF99FF98FF9BFF9CFF9CFF9DFF9CFF9AFF9CFF9CFF9BFF9BFF9CFF9CFF9DFF9EFF9DFF9BFF9CFF9CFF9AFF9AFF99FF98FF99FF98FF97FF99FF9BFF9BFF9AFF9AFF99FF99FF99FF98FF96FF97FF98FF9BFF9BFF9CFF9BFF99FF99FF98FF98FF9AFF9CFF9BFF9AFF9BFF9BFF9AFF99FF99FF9AFF99FF9BFF9BFF9BFF9BFF99FF99FF9BFF9AFF9AFF9AFF97FF98FF9AFF9BFF99FF98FF98FF99FF98FF98FF98FF9AFF9BFF99FF96FF99FF9BFF9BFF99FF97FF99FF9CFF9DFF9DFF9DFF9BFF97FF98FF9AFF9AFF97FF97FF98FF99FF99FF99FF9AFF99FF9AFF9AFF99FF9AFF9AFF99FF9AFF99FF98FF9AFF9BFF9CFF9CFF9AFF99FF96FF98FF99FF98FF99FF99FF99FF9AFF9AFF9BFF9CFF9CFF9AFF99FF98FF99FF9BFF9CFF9CFF9DFF9CFF9CFF9AFF98FF9BFF9AFF99FF97FF9AFF9BFF9AFF98FF99FF9CFF9BFF9BFF9CFF9BFF99FF97FF99FF9AFF99FF99FF9BFF9BFF9CFF9BFF9BFF99FF99FF9BFF9CFF9BFF9CFF9CFF99FF99FF9AFF9AFF9BFF9AFF9BFF9BFF9BFF9AFF99FF9AFF9AFF99FF99FF99FF99FF9BFF9BFF99FF98FF99FF99FF99FF97FFA6FFAEFFB0FFACFFA1FF99FF9BFF9BFF9BFF9CFF9BFF9CFF9CFF9CFF9BFF9AFF97FF99FF99FF98FF99FF98FF98FF97FF97FF9AFF9CFF9BFF9AFF9BFF99FF9AFF9CFF9DFF9CFF9BFF9AFF98FF99FF9AFF99FF9BFF9CFF9BFF9BFF9BFF9BFF9BFF9BFF9BFF99FF98FF99FF9BFF9BFF9AFF9AFF99FF98FF99FF98FF98FF98FF96FF99FF9CFF9DFF9BFF9BFF9CFF9AFF98FF98FF99FF9AFF9BFF9AFF9CFF9AFF96FF97FF98FF9AFF9BFF9BFF9CFF9CFF9BFF9BFF9AFF9CFF9CFF9CFF9CFF9BFF9AFF9BFF98FF96FF97FF99FF9AFF9AFF99FF99FF9AFF9CFF9DFF9BFF9BFF9BFF9AFF9BFF9AFF9AFF9CFF9CFF9BFF9BFF9BFF99FF97FF98FF9AFF9AFF9CFFA0FFA1FF9FFF9BFF9AFF98FF98FF9BFF9CFF9DFF9EFF9EFF9DFF9BFF9AFF9AFF9AFF9AFF99FF9AFF9BFF9BFF9AFF98FF97FF99FF9CFF9CFF9CFF9AFF99FF98FF98FF9AFF9DFF9CFF9AFF9AFF98FF97FF9AFF9CFF9AFF99FF9CFF9CFF9CFF9AFF99FF9AFF9BFF9CFF9DFF9BFF99FF99FF9AFF9AFF99FF9AFF9BFF9CFF9DFF9CFF9AFF99FF99FF99FF99FF98FF9AFF9BFF9BFF9BFF9AFF9CFF9DFF99FF99FF9BFF9AFF98FF9AFF9AFF99FF97FF96FF9AFF9AFF98FF99FF9BFF9BFF98FF98FF9AFF9AFF9AFF9AFF9BFF9DFF9DFF9BFF9AFF9AFF9BFF9BFF9BFF99FF9BFF9DFF9BFF98FF99FF99FF95FF99FF9CFF9DFF9CFF9AFF98FF99FF9BFF9CFF9DFF9BFF9AFF9DFF9DFF9CFF9BFF9DFF9DFF9DFF9CFF9CFF9CFF9AFF9BFF9CFF9BFF9BFF9CFF9CFF9CFF9CFF9CFF9BFF9CFF9DFF9EFF9DFF9CFF9CFF9CFF9DFF9CFF9CFF9CFF9BFF9CFF9DFF9CFF9EFFA0FFA0FF9DFF9DFF9EFF9CFF9AFF9BFF9DFF9EFF9EFF9DFF9DFF9EFF9FFF9EFF9CFF9CFF9DFF9EFF9EFF9CFF9DFF9EFF9EFF9EFF9EFF9EFF9CFF9CFF9AFF9CFF9FFF9FFF9DFF9DFF9EFF9EFF9EFF9DFF9DFF9DFF9FFFA0FFA0FF9FFFA0FF9FFF9FFFA0FFA0FF9EFF9FFF9FFF9EFF9EFF9EFF9CFF9CFF9EFF9FFFA0FFA1FFA0FF9FFF9FFF9EFF9EFF9FFFA0FF9FFF9FFF9EFF9FFFA0FF9FFF9FFFA0FFA0FFA0FF9FFF9EFF9CFF9EFF9FFF9EFF9FFF9DFF9DFF9EFF9DFF9CFF9BFF9CFF9BFF9DFF9CFF9DFF9FFF9FFF9EFF9DFF9DFF9EFF9DFF9FFF9FFF9CFF9B')
SET IDENTITY_INSERT [dbo].[M_InputRfPort1Spectrum] OFF
GO
SET IDENTITY_INSERT [dbo].[M_InputRfPort2Spectrum] ON 

INSERT [dbo].[M_InputRfPort2Spectrum] ([id], [UnitId], [Spectrum]) VALUES (13, 2100, N'0xFF9DFF9EFF9DFF9EFF9EFF9EFF9EFF9EFF9FFF9EFF9EFF9CFF9BFF9AFF9DFF9FFF9FFF9FFF9FFFA0FFA0FFA0FFA1FF9FFF9EFF9EFF9EFFA0FFA1FFA1FFA0FF9FFFA0FFA0FF9FFF9EFF9EFF9FFF9FFF9FFFA0FFA0FF9EFF9CFF9BFF9CFF9EFFA0FFA1FF9FFF9EFF9DFF9AFF9DFF9EFF9EFF9DFF9CFF9FFF9FFF9FFFA1FFA2FFA1FFA0FF9FFF9EFF9FFFA0FF9FFF9CFF9BFF9DFF9EFF9EFF9DFF9DFF9DFF9BFF9BFF9AFF9CFF9EFFA0FFA2FFA0FF9FFF9EFF9DFF9BFF9CFF9BFF9BFF9CFF99FF9AFF9DFF9CFF9DFF9CFF9BFF9CFF9DFF9CFF9BFF9DFF9DFF9CFF9BFF9CFF9DFF9DFF9EFF9DFF9BFF99FF9BFF9CFF99FF9AFF9CFF9CFF9BFF9BFF9CFF9CFF9CFF9AFF9CFF9DFF9CFF9BFF9AFF9BFF9CFF9BFF9CFF9CFF9CFF9CFF9BFF9DFF9DFF9BFF9AFF9AFF9AFF9BFF9CFF9DFF9BFF9BFF9CFF9BFF9BFF9AFF99FF9CFF9EFF9EFF9EFF9CFF9BFF9CFF9BFF9BFF9AFF9AFF9AFF99FF9BFF9EFF9EFF9CFF9BFF9CFF99FF99FF98FF98FF99FF9CFF99FF97FF99FF9BFF9DFF9CFF9BFF9BFF9BFF99FF99FF99FF9AFF99FF9AFF99FF98FF9AFF9BFF9CFF9AFF99FF99FF98FF99FF99FF98FF98FF97FF99FF9AFF9BFF9CFF9DFF9AFF99FF99FF98FF9AFF9BFF9CFF9BFF97FF99FF9CFF9BFF9CFF9BFF9AFF9BFF99FF98FF9AFF9CFF9CFF9CFF9CFF9CFF9BFF99FF9AFF9BFF9BFF9BFF9AFF9BFF9BFF99FF9BFF9CFF9BFF9BFF9CFF9DFF9DFF9BFF99FF9AFF9BFF99FF99FF98FF9AFF9CFF9CFF9BFF9AFF9AFF9BFF9DFF9CFF9AFF98FF98FF98FF98FF9AFF9BFF9CFF9BFF9BFF9AFF9AFF9BFF9CFF9CFF9AFF98FF9AFF9BFF9BFF9BFF9CFF9CFF9EFF9EFF9CFF9BFF9AFF9BFF9AFF98FF99FF99FF97FF99FF99FF99FF9AFF99FF97FF9AFF9AFF9BFF9CFF9CFF9BFF9DFF9CFF9AFF99FF98FF97FF99FF9AFF9BFF99FF99FF99FF9AFF99FF99FF99FF9AFF9BFF9BFF99FF99FF9AFF99FF98FF98FF9AFF9BFF9AFF9AFF9AFF9BFF9CFF9BFF9AFF99FF9AFF9AFF99FF9AFF9AFF99FF9AFF99FF97FF99FF99FF9AFF99FF9AFF9BFF9CFF9AFF98FF99FF9AFF9AFF99FF9BFF9BFF9BFF9CFF9CFF9BFF9BFF9BFF9BFF99FF9AFF9CFF9DFF9BFF98FF96FF98FF9AFF9AFF9AFF98FF9AFF9DFF9CFF9BFF9AFF99FF9AFF98FF99FF99FF98FF99FF97FF99FF99FF98FF99FF9AFF9BFF9CFF9CFF9BFF97FF99FF9AFF99FF98FF9BFF9CFF9CFF9DFF9CFF9AFF9CFF9CFF9BFF9BFF9CFF9CFF9DFF9EFF9DFF9BFF9CFF9CFF9AFF9AFF99FF98FF99FF98FF97FF99FF9BFF9BFF9AFF9AFF99FF99FF99FF98FF96FF97FF98FF9BFF9BFF9CFF9BFF99FF99FF98FF98FF9AFF9CFF9BFF9AFF9BFF9BFF9AFF99FF99FF9AFF99FF9BFF9BFF9BFF9BFF99FF99FF9BFF9AFF9AFF9AFF97FF98FF9AFF9BFF99FF98FF98FF99FF98FF98FF98FF9AFF9BFF99FF96FF99FF9BFF9BFF99FF97FF99FF9CFF9DFF9DFF9DFF9BFF97FF98FF9AFF9AFF97FF97FF98FF99FF99FF99FF9AFF99FF9AFF9AFF99FF9AFF9AFF99FF9AFF99FF98FF9AFF9BFF9CFF9CFF9AFF99FF96FF98FF99FF98FF99FF99FF99FF9AFF9AFF9BFF9CFF9CFF9AFF99FF98FF99FF9BFF9CFF9CFF9DFF9CFF9CFF9AFF98FF9BFF9AFF99FF97FF9AFF9BFF9AFF98FF99FF9CFF9BFF9BFF9CFF9BFF99FF97FF99FF9AFF99FF99FF9BFF9BFF9CFF9BFF9BFF99FF99FF9BFF9CFF9BFF9CFF9CFF99FF99FF9AFF9AFF9BFF9AFF9BFF9BFF9BFF9AFF99FF9AFF9AFF99FF99FF99FF99FF9BFF9BFF99FF98FF99FF99FF99FF97FFA6FFAEFFB0FFACFFA1FF99FF9BFF9BFF9BFF9CFF9BFF9CFF9CFF9CFF9BFF9AFF97FF99FF99FF98FF99FF98FF98FF97FF97FF9AFF9CFF9BFF9AFF9BFF99FF9AFF9CFF9DFF9CFF9BFF9AFF98FF99FF9AFF99FF9BFF9CFF9BFF9BFF9BFF9BFF9BFF9BFF9BFF99FF98FF99FF9BFF9BFF9AFF9AFF99FF98FF99FF98FF98FF98FF96FF99FF9CFF9DFF9BFF9BFF9CFF9AFF98FF98FF99FF9AFF9BFF9AFF9CFF9AFF96FF97FF98FF9AFF9BFF9BFF9CFF9CFF9BFF9BFF9AFF9CFF9CFF9CFF9CFF9BFF9AFF9BFF98FF96FF97FF99FF9AFF9AFF99FF99FF9AFF9CFF9DFF9BFF9BFF9BFF9AFF9BFF9AFF9AFF9CFF9CFF9BFF9BFF9BFF99FF97FF98FF9AFF9AFF9CFFA0FFA1FF9FFF9BFF9AFF98FF98FF9BFF9CFF9DFF9EFF9EFF9DFF9BFF9AFF9AFF9AFF9AFF99FF9AFF9BFF9BFF9AFF98FF97FF99FF9CFF9CFF9CFF9AFF99FF98FF98FF9AFF9DFF9CFF9AFF9AFF98FF97FF9AFF9CFF9AFF99FF9CFF9CFF9CFF9AFF99FF9AFF9BFF9CFF9DFF9BFF99FF99FF9AFF9AFF99FF9AFF9BFF9CFF9DFF9CFF9AFF99FF99FF99FF99FF98FF9AFF9BFF9BFF9BFF9AFF9CFF9DFF99FF99FF9BFF9AFF98FF9AFF9AFF99FF97FF96FF9AFF9AFF98FF99FF9BFF9BFF98FF98FF9AFF9AFF9AFF9AFF9BFF9DFF9DFF9BFF9AFF9AFF9BFF9BFF9BFF99FF9BFF9DFF9BFF98FF99FF99FF95FF99FF9CFF9DFF9CFF9AFF98FF99FF9BFF9CFF9DFF9BFF9AFF9DFF9DFF9CFF9BFF9DFF9DFF9DFF9CFF9CFF9CFF9AFF9BFF9CFF9BFF9BFF9CFF9CFF9CFF9CFF9CFF9BFF9CFF9DFF9EFF9DFF9CFF9CFF9CFF9DFF9CFF9CFF9CFF9BFF9CFF9DFF9CFF9EFFA0FFA0FF9DFF9DFF9EFF9CFF9AFF9BFF9DFF9EFF9EFF9DFF9DFF9EFF9FFF9EFF9CFF9CFF9DFF9EFF9EFF9CFF9DFF9EFF9EFF9EFF9EFF9EFF9CFF9CFF9AFF9CFF9FFF9FFF9DFF9DFF9EFF9EFF9EFF9DFF9DFF9DFF9FFFA0FFA0FF9FFFA0FF9FFF9FFFA0FFA0FF9EFF9FFF9FFF9EFF9EFF9EFF9CFF9CFF9EFF9FFFA0FFA1FFA0FF9FFF9FFF9EFF9EFF9FFFA0FF9FFF9FFF9EFF9FFFA0FF9FFF9FFFA0FFA0FFA0FF9FFF9EFF9CFF9EFF9FFF9EFF9FFF9DFF9DFF9EFF9DFF9CFF9BFF9CFF9BFF9DFF9CFF9DFF9FFF9FFF9EFF9DFF9DFF9EFF9DFF9FFF9FFF9CFF9B')
INSERT [dbo].[M_InputRfPort2Spectrum] ([id], [UnitId], [Spectrum]) VALUES (12, 2000, N'0xFFA6FFA7FFAAFFABFFABFFABFFABFFACFFAAFFAAFFAAFFABFFACFFADFFABFFABFFACFFADFFADFFADFFACFFACFFACFFADFFAEFFACFFA9FFA9FFABFFACFFACFFAAFFACFFAEFFAEFFABFFACFFADFFADFFADFFADFFACFFABFFAEFFB0FFAFFFADFFABFFA9FFABFFACFFAAFFA9FFAAFFABFFAAFFA8FFA7FFA9FFABFFADFFADFFADFFAAFFA7FFAAFFABFFAAFFABFFAAFFABFFAAFFA9FFAAFFABFFA9FFA7FFA8FFABFFAAFFAAFFAAFFA9FFAAFFABFFABFFABFFABFFAAFFA9FFA9FFA9FFA9FFABFFAAFFA8FFA9FFA8FFA5FFA3FFA6FFA7FFA8FFAAFFA9FFA7FFA8FFA8FFA7FFA8FFA7FFA7FFA6FFA8FFA9FFA9FFA6FFA6FFA6FFA7FFA7FFA4FFA5FFA6FFA6FFA8FFA8FFA8FFA8FFA7FFA6FFA6FFA7FFA6FFA8FFA6FFA4FFA5FFA4FFA4FFA5FFA6FFA6FFA6FFA6FFA7FFA6FFA3FFA3FFA6FFA6FFA5FFA4FFA2FFA4FFA4FFA4FFA6FFA6FFA6FFA7FFA6FFA5FFA6FFA6FFA7FFA7FFA7FFA4FFA4FFA0FFA0FFA2FFA5FFA4FFA6FFA6FFA3FFA1FFA3FFA4FFA6FFA6FFA4FFA4FFA4FFA3FFA3FFA3FFA4FFA3FFA4FFA5FFA2FFA1FFA2FFA4FFA4FFA4FFA4FFA4FFA6FFA6FFA4FFA4FFA3FFA2FFA2FFA2FFA2FFA2FFA4FFA3FFA3FFA3FFA4FFA6FFA4FFA2FFA3FFA4FFA5FFA3FFA3FFA4FFA3FFA4FFA5FFA4FFA1FFA4FFA4FFA2FFA3FFA3FFA6FFA5FFA3FFA1FFA4FFA3FFA4FFA4FFA4FFA2FFA4FFA3FFA3FFA2FFA3FFA4FFA2FFA2FFA5FFA3FFA2FFA3FFA4FFA2FFA4FFA4FFA4FFA4FFA4FFA6FFA7FFA6FFA4FFA3FFA5FFA3FFA1FFA1FFA4FFA5FFA5FFA5FFA4FFA3FFA4FFA4FFA5FFA4FFA5FFA8FFA7FFA5FFA6FFA4FFA1FFA2FFA2FFA3FFA4FFA4FFA4FFA2FFA4FFA2FFA2FFA3FFA4FFA3FFA1FFA3FFA1FFA3FFA3FFA4FFA5FFA4FFA3FFA2FFA3FFA3FFA3FFA5FFA4FFA3FFA1FFA1FFA2FFA3FFA3FFA5FFA3FFA2FFA2FFA5FFA5FFA6FFA3FFA0FFA3FFA4FFA5FFA3FFA2FFA3FFA4FFA4FFA5FFA4FFA2FFA3FFA3FFA6FFA3FFA2FFA1FFA2FFA5FFA3FFA6FFA6FFA6FFA4FFA4FFA4FFA3FFA0FFA3FFA3FFA5FFA5FFA7FFABFFACFFA9FFA5FFA5FFA4FFA4FFA5FFA6FFA9FFAAFFAAFFA9FFAAFFA8FFAAFFAAFFA9FFC6FFD9FFE3FFE5FFE0FFD4FFBBFFA8FFA9FFAAFFAAFFA9FFA9FFA7FFA8FFA9FFA7FFA5FFA2FFA4FFA4FFA3FFA8FFAAFFA7FFA5FFA4FFA1FFA1FFA5FFA6FFA5FFA6FFA5FFA4FFA5FFA5FFA6FFA6FFA2FFA4FFA4FFA2FFA4FFA4FFA3FFA4FFA2FFA3FFA5FFA4FFA6FFA6FFA3FFA3FFA4FFA4FFA4FFA4FFA4FFA3FFA3FFA3FFA5FFA7FFA6FFA4FFA5FFA4FFA2FFA3FFA3FFA4FFA1FFA2FFA5FFA5FFA4FFA3FFA0FFA4FFA3FFA1FFA3FFA4FFA4FFA3FFA1FFA2FFA3FFA3FFA4FFA4FFA5FFA7FFA7FFA6FFA4FFA4FFA4FFA3FFA3FFA5FFA5FFA4FFA5FFA4FFA4FFA2FFA5FFA5FFA4FFA3FFA3FFA2FFA4FFA5FFA3FFA1FFA1FFA2FFA3FFA2FFA1FF9FFFA5FFA6FFA8FFA8FFA5FFA4FFA4FFA2FFA3FFA1FFA5FFA4FFA6FFA6FFA5FFA3FFA6FFA6FFA2FFA2FFA2FFA2FFA4FFA5FFA4FFA1FFA4FFA6FFA4FFA5FFA4FFA3FFA1FFA1FFA2FFA3FFA3FFA2FFA1FFA4FFA5FFA5FFA4FFA1FFA3FFA4FFA4FFA4FFA2FFA3FFA2FFA2FFA0FFA2FFA5FFA5FFA2FFA2FFA4FFA4FFA3FFA3FFA5FFA3FFA2FFA2FFA3FFA4FFA3FFA3FFA4FFA2FFA3FFA1FFA2FFA2FFA4FFA3FFA0FFA2FFA3FFA4FFA4FFA3FFA2FFA4FFA4FFA4FFA4FFA3FFA4FFA4FFA3FFA0FFA2FFA4FFA1FFA3FFA5FFA5FFA4FFA2FF9FFFA2FFA4FFA5FFA5FFA2FFA1FFA4FFA4FFA2FFA4FFA5FFA6FFA5FFA4FFA4FFA3FFA4FFA5FFA6FFA4FFA3FFA3FFA3FFA2FFA5FFA5FFA4FFA3FFA3FFA4FFA4FFA1FFA2FFA2FFA3FFA2FFA3FFA3FFA3FFA3FFA3FFA2FFA2FFA3FFA3FFA1FFA1FFA3FFA3FFA1FFA3FFA2FFA4FFA5FFA3FFA2FFA1FFA3FFA5FFA4FFA1FFA1FFA3FFA4FFA3FFA4FFA6FFA6FFA5FFA5FFA5FFA1FFA1FFA3FFA3FFA2FF9EFFA3FFA4FFA3FFA3FFA5FFA5FFA5FFA3FFA2FFA1FFA3FFA3FFA3FFA5FFA5FFA4FFA4FFA3FFA3FFA2FFA3FFA2FFA3FFA3FFA5FFA1FFA1FFA0FFA2FFA3FFA3FFA4FFA6FFA6FFA4FFA2FFA0FFA1FFA4FFA4FFA3FFA4FFA3FFA2FFA3FFA3FFA4FFA5FFA4FFA6FFA5FFA5FFA6FFA4FFA3FFA3FFA2FFA4FFA4FFA3FFA1FFA1FFA2FFA2FFA2FFA4FFA5FFA4FFA4FFA5FFA1FFA1FFA3FFA3FFA2FFA5FFA3FF9FFF9FFFA0FFA3FFA3FFA2FFA1FFA2FFA4FFA3FFA3FFA4FFA4FFA4FFA6FFA4FFA3FFA4FFA5FFA4FFA5FFA4FFA4FFA2FFA4FFA4FFA4FFA7FFA5FFA3FFA5FFA3FFA5FFA5FFA4FFA4FFA4FFA2FFA2FFA4FFA3FFA5FFA5FFA6FFA5FFA2FFA2FFA3FFA2FFA3FFA6FFA6FFA5FFA4FFA5FFA4FFA5FFA6FFA7FFA6FFA5FFA6FFA4FFA2FFA4FFA5FFA5FFA4FFA5FFA5FFA5FFA4FFA4FFA4FFA5FFA3FFA4FFA5FFA5FFA4FFA2FFA1FFA3FFA6FFA6FFA7FFA6FFA6FFA6FFA7FFA4FFA4FFA4FFA5FFA6FFA7FFA7FFA6FFA5FFA3FFA5FFA7FFA6FFA6FFA7FFA7FFA7FFA8FFA9FFA7FFA3FFA5FFA6FFA4FFA6FFA5FFA4FFA4FFA5FFA5FFA5FFA5FFA6FFA6FFA4FFA7FFA2FFA3FFA4FFA7FFA9FFA7FFA4FFA4FFA7FFA7FFA6FFA8FFA9FFA8FFA7FFAAFFA6FFA5FFA7FFA4FFA6FFA9FFA8FFA8FFA8FFA9FFA7FF9EFFA5FFA7FFA8FFA8FFA8FFAAFFA8FFA7FFA7FFA9FFA9FFA8FFA6FFA7FFA6FFA9FFA8FFA9FFA8FFA7FFA9FFA9FFA8FFA9FFA9FFAAFFAAFFABFFACFFABFFAAFFAAFFABFFAAFFAAFFAAFFA9FFA9FFAAFFACFFABFFA9FFABFFABFFAAFFABFFACFFACFFABFFAAFFACFFACFFABFFAAFFAAFFAAFFABFFABFFADFFACFFA9FFA6FFA7FFACFFAEFFAEFFADFFACFFADFFAEFFABFFAAFFABFFACFFACFFABFFACFFACFFADFFADFFACFFADFFADFFADFFAAFFABFFADFFABFFACFFACFFABFFAAFFA8FFA9FFAAFFA9FFA9FFA8FFAAFFABFFAAFFA8FFA8FFA6')
SET IDENTITY_INSERT [dbo].[M_InputRfPort2Spectrum] OFF
GO
SET IDENTITY_INSERT [dbo].[M_InputRfSpectrum] ON 

INSERT [dbo].[M_InputRfSpectrum] ([id], [UnitId], [Spectrum]) VALUES (12, 2000, N'0xFFA6FFA7FFAAFFABFFABFFABFFABFFACFFAAFFAAFFAAFFABFFACFFADFFABFFABFFACFFADFFADFFADFFACFFACFFACFFADFFAEFFACFFA9FFA9FFABFFACFFACFFAAFFACFFAEFFAEFFABFFACFFADFFADFFADFFADFFACFFABFFAEFFB0FFAFFFADFFABFFA9FFABFFACFFAAFFA9FFAAFFABFFAAFFA8FFA7FFA9FFABFFADFFADFFADFFAAFFA7FFAAFFABFFAAFFABFFAAFFABFFAAFFA9FFAAFFABFFA9FFA7FFA8FFABFFAAFFAAFFAAFFA9FFAAFFABFFABFFABFFABFFAAFFA9FFA9FFA9FFA9FFABFFAAFFA8FFA9FFA8FFA5FFA3FFA6FFA7FFA8FFAAFFA9FFA7FFA8FFA8FFA7FFA8FFA7FFA7FFA6FFA8FFA9FFA9FFA6FFA6FFA6FFA7FFA7FFA4FFA5FFA6FFA6FFA8FFA8FFA8FFA8FFA7FFA6FFA6FFA7FFA6FFA8FFA6FFA4FFA5FFA4FFA4FFA5FFA6FFA6FFA6FFA6FFA7FFA6FFA3FFA3FFA6FFA6FFA5FFA4FFA2FFA4FFA4FFA4FFA6FFA6FFA6FFA7FFA6FFA5FFA6FFA6FFA7FFA7FFA7FFA4FFA4FFA0FFA0FFA2FFA5FFA4FFA6FFA6FFA3FFA1FFA3FFA4FFA6FFA6FFA4FFA4FFA4FFA3FFA3FFA3FFA4FFA3FFA4FFA5FFA2FFA1FFA2FFA4FFA4FFA4FFA4FFA4FFA6FFA6FFA4FFA4FFA3FFA2FFA2FFA2FFA2FFA2FFA4FFA3FFA3FFA3FFA4FFA6FFA4FFA2FFA3FFA4FFA5FFA3FFA3FFA4FFA3FFA4FFA5FFA4FFA1FFA4FFA4FFA2FFA3FFA3FFA6FFA5FFA3FFA1FFA4FFA3FFA4FFA4FFA4FFA2FFA4FFA3FFA3FFA2FFA3FFA4FFA2FFA2FFA5FFA3FFA2FFA3FFA4FFA2FFA4FFA4FFA4FFA4FFA4FFA6FFA7FFA6FFA4FFA3FFA5FFA3FFA1FFA1FFA4FFA5FFA5FFA5FFA4FFA3FFA4FFA4FFA5FFA4FFA5FFA8FFA7FFA5FFA6FFA4FFA1FFA2FFA2FFA3FFA4FFA4FFA4FFA2FFA4FFA2FFA2FFA3FFA4FFA3FFA1FFA3FFA1FFA3FFA3FFA4FFA5FFA4FFA3FFA2FFA3FFA3FFA3FFA5FFA4FFA3FFA1FFA1FFA2FFA3FFA3FFA5FFA3FFA2FFA2FFA5FFA5FFA6FFA3FFA0FFA3FFA4FFA5FFA3FFA2FFA3FFA4FFA4FFA5FFA4FFA2FFA3FFA3FFA6FFA3FFA2FFA1FFA2FFA5FFA3FFA6FFA6FFA6FFA4FFA4FFA4FFA3FFA0FFA3FFA3FFA5FFA5FFA7FFABFFACFFA9FFA5FFA5FFA4FFA4FFA5FFA6FFA9FFAAFFAAFFA9FFAAFFA8FFAAFFAAFFA9FFC6FFD9FFE3FFE5FFE0FFD4FFBBFFA8FFA9FFAAFFAAFFA9FFA9FFA7FFA8FFA9FFA7FFA5FFA2FFA4FFA4FFA3FFA8FFAAFFA7FFA5FFA4FFA1FFA1FFA5FFA6FFA5FFA6FFA5FFA4FFA5FFA5FFA6FFA6FFA2FFA4FFA4FFA2FFA4FFA4FFA3FFA4FFA2FFA3FFA5FFA4FFA6FFA6FFA3FFA3FFA4FFA4FFA4FFA4FFA4FFA3FFA3FFA3FFA5FFA7FFA6FFA4FFA5FFA4FFA2FFA3FFA3FFA4FFA1FFA2FFA5FFA5FFA4FFA3FFA0FFA4FFA3FFA1FFA3FFA4FFA4FFA3FFA1FFA2FFA3FFA3FFA4FFA4FFA5FFA7FFA7FFA6FFA4FFA4FFA4FFA3FFA3FFA5FFA5FFA4FFA5FFA4FFA4FFA2FFA5FFA5FFA4FFA3FFA3FFA2FFA4FFA5FFA3FFA1FFA1FFA2FFA3FFA2FFA1FF9FFFA5FFA6FFA8FFA8FFA5FFA4FFA4FFA2FFA3FFA1FFA5FFA4FFA6FFA6FFA5FFA3FFA6FFA6FFA2FFA2FFA2FFA2FFA4FFA5FFA4FFA1FFA4FFA6FFA4FFA5FFA4FFA3FFA1FFA1FFA2FFA3FFA3FFA2FFA1FFA4FFA5FFA5FFA4FFA1FFA3FFA4FFA4FFA4FFA2FFA3FFA2FFA2FFA0FFA2FFA5FFA5FFA2FFA2FFA4FFA4FFA3FFA3FFA5FFA3FFA2FFA2FFA3FFA4FFA3FFA3FFA4FFA2FFA3FFA1FFA2FFA2FFA4FFA3FFA0FFA2FFA3FFA4FFA4FFA3FFA2FFA4FFA4FFA4FFA4FFA3FFA4FFA4FFA3FFA0FFA2FFA4FFA1FFA3FFA5FFA5FFA4FFA2FF9FFFA2FFA4FFA5FFA5FFA2FFA1FFA4FFA4FFA2FFA4FFA5FFA6FFA5FFA4FFA4FFA3FFA4FFA5FFA6FFA4FFA3FFA3FFA3FFA2FFA5FFA5FFA4FFA3FFA3FFA4FFA4FFA1FFA2FFA2FFA3FFA2FFA3FFA3FFA3FFA3FFA3FFA2FFA2FFA3FFA3FFA1FFA1FFA3FFA3FFA1FFA3FFA2FFA4FFA5FFA3FFA2FFA1FFA3FFA5FFA4FFA1FFA1FFA3FFA4FFA3FFA4FFA6FFA6FFA5FFA5FFA5FFA1FFA1FFA3FFA3FFA2FF9EFFA3FFA4FFA3FFA3FFA5FFA5FFA5FFA3FFA2FFA1FFA3FFA3FFA3FFA5FFA5FFA4FFA4FFA3FFA3FFA2FFA3FFA2FFA3FFA3FFA5FFA1FFA1FFA0FFA2FFA3FFA3FFA4FFA6FFA6FFA4FFA2FFA0FFA1FFA4FFA4FFA3FFA4FFA3FFA2FFA3FFA3FFA4FFA5FFA4FFA6FFA5FFA5FFA6FFA4FFA3FFA3FFA2FFA4FFA4FFA3FFA1FFA1FFA2FFA2FFA2FFA4FFA5FFA4FFA4FFA5FFA1FFA1FFA3FFA3FFA2FFA5FFA3FF9FFF9FFFA0FFA3FFA3FFA2FFA1FFA2FFA4FFA3FFA3FFA4FFA4FFA4FFA6FFA4FFA3FFA4FFA5FFA4FFA5FFA4FFA4FFA2FFA4FFA4FFA4FFA7FFA5FFA3FFA5FFA3FFA5FFA5FFA4FFA4FFA4FFA2FFA2FFA4FFA3FFA5FFA5FFA6FFA5FFA2FFA2FFA3FFA2FFA3FFA6FFA6FFA5FFA4FFA5FFA4FFA5FFA6FFA7FFA6FFA5FFA6FFA4FFA2FFA4FFA5FFA5FFA4FFA5FFA5FFA5FFA4FFA4FFA4FFA5FFA3FFA4FFA5FFA5FFA4FFA2FFA1FFA3FFA6FFA6FFA7FFA6FFA6FFA6FFA7FFA4FFA4FFA4FFA5FFA6FFA7FFA7FFA6FFA5FFA3FFA5FFA7FFA6FFA6FFA7FFA7FFA7FFA8FFA9FFA7FFA3FFA5FFA6FFA4FFA6FFA5FFA4FFA4FFA5FFA5FFA5FFA5FFA6FFA6FFA4FFA7FFA2FFA3FFA4FFA7FFA9FFA7FFA4FFA4FFA7FFA7FFA6FFA8FFA9FFA8FFA7FFAAFFA6FFA5FFA7FFA4FFA6FFA9FFA8FFA8FFA8FFA9FFA7FF9EFFA5FFA7FFA8FFA8FFA8FFAAFFA8FFA7FFA7FFA9FFA9FFA8FFA6FFA7FFA6FFA9FFA8FFA9FFA8FFA7FFA9FFA9FFA8FFA9FFA9FFAAFFAAFFABFFACFFABFFAAFFAAFFABFFAAFFAAFFAAFFA9FFA9FFAAFFACFFABFFA9FFABFFABFFAAFFABFFACFFACFFABFFAAFFACFFACFFABFFAAFFAAFFAAFFABFFABFFADFFACFFA9FFA6FFA7FFACFFAEFFAEFFADFFACFFADFFAEFFABFFAAFFABFFACFFACFFABFFACFFACFFADFFADFFACFFADFFADFFADFFAAFFABFFADFFABFFACFFACFFABFFAAFFA8FFA9FFAAFFA9FFA9FFA8FFAAFFABFFAAFFA8FFA8FFA6')
INSERT [dbo].[M_InputRfSpectrum] ([id], [UnitId], [Spectrum]) VALUES (13, 2100, N'0xFF9DFF9EFF9DFF9EFF9EFF9EFF9EFF9EFF9FFF9EFF9EFF9CFF9BFF9AFF9DFF9FFF9FFF9FFF9FFFA0FFA0FFA0FFA1FF9FFF9EFF9EFF9EFFA0FFA1FFA1FFA0FF9FFFA0FFA0FF9FFF9EFF9EFF9FFF9FFF9FFFA0FFA0FF9EFF9CFF9BFF9CFF9EFFA0FFA1FF9FFF9EFF9DFF9AFF9DFF9EFF9EFF9DFF9CFF9FFF9FFF9FFFA1FFA2FFA1FFA0FF9FFF9EFF9FFFA0FF9FFF9CFF9BFF9DFF9EFF9EFF9DFF9DFF9DFF9BFF9BFF9AFF9CFF9EFFA0FFA2FFA0FF9FFF9EFF9DFF9BFF9CFF9BFF9BFF9CFF99FF9AFF9DFF9CFF9DFF9CFF9BFF9CFF9DFF9CFF9BFF9DFF9DFF9CFF9BFF9CFF9DFF9DFF9EFF9DFF9BFF99FF9BFF9CFF99FF9AFF9CFF9CFF9BFF9BFF9CFF9CFF9CFF9AFF9CFF9DFF9CFF9BFF9AFF9BFF9CFF9BFF9CFF9CFF9CFF9CFF9BFF9DFF9DFF9BFF9AFF9AFF9AFF9BFF9CFF9DFF9BFF9BFF9CFF9BFF9BFF9AFF99FF9CFF9EFF9EFF9EFF9CFF9BFF9CFF9BFF9BFF9AFF9AFF9AFF99FF9BFF9EFF9EFF9CFF9BFF9CFF99FF99FF98FF98FF99FF9CFF99FF97FF99FF9BFF9DFF9CFF9BFF9BFF9BFF99FF99FF99FF9AFF99FF9AFF99FF98FF9AFF9BFF9CFF9AFF99FF99FF98FF99FF99FF98FF98FF97FF99FF9AFF9BFF9CFF9DFF9AFF99FF99FF98FF9AFF9BFF9CFF9BFF97FF99FF9CFF9BFF9CFF9BFF9AFF9BFF99FF98FF9AFF9CFF9CFF9CFF9CFF9CFF9BFF99FF9AFF9BFF9BFF9BFF9AFF9BFF9BFF99FF9BFF9CFF9BFF9BFF9CFF9DFF9DFF9BFF99FF9AFF9BFF99FF99FF98FF9AFF9CFF9CFF9BFF9AFF9AFF9BFF9DFF9CFF9AFF98FF98FF98FF98FF9AFF9BFF9CFF9BFF9BFF9AFF9AFF9BFF9CFF9CFF9AFF98FF9AFF9BFF9BFF9BFF9CFF9CFF9EFF9EFF9CFF9BFF9AFF9BFF9AFF98FF99FF99FF97FF99FF99FF99FF9AFF99FF97FF9AFF9AFF9BFF9CFF9CFF9BFF9DFF9CFF9AFF99FF98FF97FF99FF9AFF9BFF99FF99FF99FF9AFF99FF99FF99FF9AFF9BFF9BFF99FF99FF9AFF99FF98FF98FF9AFF9BFF9AFF9AFF9AFF9BFF9CFF9BFF9AFF99FF9AFF9AFF99FF9AFF9AFF99FF9AFF99FF97FF99FF99FF9AFF99FF9AFF9BFF9CFF9AFF98FF99FF9AFF9AFF99FF9BFF9BFF9BFF9CFF9CFF9BFF9BFF9BFF9BFF99FF9AFF9CFF9DFF9BFF98FF96FF98FF9AFF9AFF9AFF98FF9AFF9DFF9CFF9BFF9AFF99FF9AFF98FF99FF99FF98FF99FF97FF99FF99FF98FF99FF9AFF9BFF9CFF9CFF9BFF97FF99FF9AFF99FF98FF9BFF9CFF9CFF9DFF9CFF9AFF9CFF9CFF9BFF9BFF9CFF9CFF9DFF9EFF9DFF9BFF9CFF9CFF9AFF9AFF99FF98FF99FF98FF97FF99FF9BFF9BFF9AFF9AFF99FF99FF99FF98FF96FF97FF98FF9BFF9BFF9CFF9BFF99FF99FF98FF98FF9AFF9CFF9BFF9AFF9BFF9BFF9AFF99FF99FF9AFF99FF9BFF9BFF9BFF9BFF99FF99FF9BFF9AFF9AFF9AFF97FF98FF9AFF9BFF99FF98FF98FF99FF98FF98FF98FF9AFF9BFF99FF96FF99FF9BFF9BFF99FF97FF99FF9CFF9DFF9DFF9DFF9BFF97FF98FF9AFF9AFF97FF97FF98FF99FF99FF99FF9AFF99FF9AFF9AFF99FF9AFF9AFF99FF9AFF99FF98FF9AFF9BFF9CFF9CFF9AFF99FF96FF98FF99FF98FF99FF99FF99FF9AFF9AFF9BFF9CFF9CFF9AFF99FF98FF99FF9BFF9CFF9CFF9DFF9CFF9CFF9AFF98FF9BFF9AFF99FF97FF9AFF9BFF9AFF98FF99FF9CFF9BFF9BFF9CFF9BFF99FF97FF99FF9AFF99FF99FF9BFF9BFF9CFF9BFF9BFF99FF99FF9BFF9CFF9BFF9CFF9CFF99FF99FF9AFF9AFF9BFF9AFF9BFF9BFF9BFF9AFF99FF9AFF9AFF99FF99FF99FF99FF9BFF9BFF99FF98FF99FF99FF99FF97FFA6FFAEFFB0FFACFFA1FF99FF9BFF9BFF9BFF9CFF9BFF9CFF9CFF9CFF9BFF9AFF97FF99FF99FF98FF99FF98FF98FF97FF97FF9AFF9CFF9BFF9AFF9BFF99FF9AFF9CFF9DFF9CFF9BFF9AFF98FF99FF9AFF99FF9BFF9CFF9BFF9BFF9BFF9BFF9BFF9BFF9BFF99FF98FF99FF9BFF9BFF9AFF9AFF99FF98FF99FF98FF98FF98FF96FF99FF9CFF9DFF9BFF9BFF9CFF9AFF98FF98FF99FF9AFF9BFF9AFF9CFF9AFF96FF97FF98FF9AFF9BFF9BFF9CFF9CFF9BFF9BFF9AFF9CFF9CFF9CFF9CFF9BFF9AFF9BFF98FF96FF97FF99FF9AFF9AFF99FF99FF9AFF9CFF9DFF9BFF9BFF9BFF9AFF9BFF9AFF9AFF9CFF9CFF9BFF9BFF9BFF99FF97FF98FF9AFF9AFF9CFFA0FFA1FF9FFF9BFF9AFF98FF98FF9BFF9CFF9DFF9EFF9EFF9DFF9BFF9AFF9AFF9AFF9AFF99FF9AFF9BFF9BFF9AFF98FF97FF99FF9CFF9CFF9CFF9AFF99FF98FF98FF9AFF9DFF9CFF9AFF9AFF98FF97FF9AFF9CFF9AFF99FF9CFF9CFF9CFF9AFF99FF9AFF9BFF9CFF9DFF9BFF99FF99FF9AFF9AFF99FF9AFF9BFF9CFF9DFF9CFF9AFF99FF99FF99FF99FF98FF9AFF9BFF9BFF9BFF9AFF9CFF9DFF99FF99FF9BFF9AFF98FF9AFF9AFF99FF97FF96FF9AFF9AFF98FF99FF9BFF9BFF98FF98FF9AFF9AFF9AFF9AFF9BFF9DFF9DFF9BFF9AFF9AFF9BFF9BFF9BFF99FF9BFF9DFF9BFF98FF99FF99FF95FF99FF9CFF9DFF9CFF9AFF98FF99FF9BFF9CFF9DFF9BFF9AFF9DFF9DFF9CFF9BFF9DFF9DFF9DFF9CFF9CFF9CFF9AFF9BFF9CFF9BFF9BFF9CFF9CFF9CFF9CFF9CFF9BFF9CFF9DFF9EFF9DFF9CFF9CFF9CFF9DFF9CFF9CFF9CFF9BFF9CFF9DFF9CFF9EFFA0FFA0FF9DFF9DFF9EFF9CFF9AFF9BFF9DFF9EFF9EFF9DFF9DFF9EFF9FFF9EFF9CFF9CFF9DFF9EFF9EFF9CFF9DFF9EFF9EFF9EFF9EFF9EFF9CFF9CFF9AFF9CFF9FFF9FFF9DFF9DFF9EFF9EFF9EFF9DFF9DFF9DFF9FFFA0FFA0FF9FFFA0FF9FFF9FFFA0FFA0FF9EFF9FFF9FFF9EFF9EFF9EFF9CFF9CFF9EFF9FFFA0FFA1FFA0FF9FFF9FFF9EFF9EFF9FFFA0FF9FFF9FFF9EFF9FFFA0FF9FFF9FFFA0FFA0FFA0FF9FFF9EFF9CFF9EFF9FFF9EFF9FFF9DFF9DFF9EFF9DFF9CFF9BFF9CFF9BFF9DFF9CFF9DFF9FFF9FFF9EFF9DFF9DFF9EFF9DFF9FFF9FFF9CFF9B')
SET IDENTITY_INSERT [dbo].[M_InputRfSpectrum] OFF
GO
SET IDENTITY_INSERT [dbo].[M_Modules] ON 

INSERT [dbo].[M_Modules] ([id], [UnitId], [active], [address], [compositeStatus], [compositeStatusMsg], [contextPacketState], [currentGain], [discardedPackets], [enableMulticastGroupSubscriptions], [fanSpeed], [gainMode], [gateway], [healthStatus], [healthStatusMsg], [inputRfAdcSaturation], [inputRfAdcSaturationPercent], [inputRfBandwidth], [inputRfCenterFrequency], [inputRfPort1AdcSaturation], [inputRfPort1AdcSaturationPercent], [inputRfPort1MinimumGain], [inputRfPort1Power], [inputRfPort2AdcSaturation], [inputRfPort2AdcSaturationPercent], [inputRfPort2MinimumGain], [inputRfPort2Power], [inputRfPortSelect], [inputRfPower], [inputRfSampleRate], [invertRfOutputSpectrum], [irigDcLocked], [irigLocked], [label], [logLevel], [manualGain], [minimumGain], [moduleState], [moduleType], [ntpStatus], [onePpsPresent], [outputAttenuation], [outputRfCenterFrequency], [outputRfDacSaturation], [outputRfDacSaturationPercent], [outputRfPort1DacSaturation], [outputRfPort1DacSaturationPercent], [outputRfPort1Power], [outputRfPort2DacSaturation], [outputRfPort2DacSaturationPercent], [outputRfPort2Power], [outputRfPortSelect], [outputRfPower], [overrideOutputFrequency], [overrideOutputFrequencyEnable], [pollInterval], [posixNanoseconds], [posixSeconds], [rebootRequired], [replyWaitTime], [requiredReadPrivilege], [requiredWritePrivilege], [rfOutputEnable], [rfOutputSource], [securitySource], [serialNumber], [shortDescription], [simulate], [squelchEnabled], [systemTemperature], [systemTimeSource], [tenMhzLocked], [version]) VALUES (13, 2100, 1, N'', N'good', N'', N'Normal', CAST(30 AS Numeric(10, 0)), CAST(266118 AS Numeric(10, 0)), 0, CAST(0 AS Numeric(5, 0)), N'Manual', N'10.229.41.129', N'good', N'', -57.25619, 22.3391037, N'40.0', 1350, -57.25619, 22.3391037, 73, -71.926796, -57.31868, 22.2444248, 73, -41.98928, N'rfIn1', -71.926796, CAST(45000000 AS Numeric(10, 0)), 0, 0, 0, N'spectralNet', N'information', 30, 73, N'Operational', N'SpectralNet Module', N'Not Locked', 1, 10, 1360.5, -22.35834, 75.21464, -22.35834, 75.21464, -27.31739, -22.3679, 75.20015, -27.32695, N'rfOut1', -27.31739, 1360.5, 1, CAST(1000 AS Numeric(10, 0)), CAST(633403160 AS Numeric(10, 0)), CAST(1672996368 AS Numeric(10, 0)), 0, N'00:01:00', N'', N'', 1, N'Packets', N'No Certificate', N'RT-194004404', N'A one stop shop for control and status of a single SpectralNet node', 0, 0, 39, N'IRIG', 1, N'1.7.4')
INSERT [dbo].[M_Modules] ([id], [UnitId], [active], [address], [compositeStatus], [compositeStatusMsg], [contextPacketState], [currentGain], [discardedPackets], [enableMulticastGroupSubscriptions], [fanSpeed], [gainMode], [gateway], [healthStatus], [healthStatusMsg], [inputRfAdcSaturation], [inputRfAdcSaturationPercent], [inputRfBandwidth], [inputRfCenterFrequency], [inputRfPort1AdcSaturation], [inputRfPort1AdcSaturationPercent], [inputRfPort1MinimumGain], [inputRfPort1Power], [inputRfPort2AdcSaturation], [inputRfPort2AdcSaturationPercent], [inputRfPort2MinimumGain], [inputRfPort2Power], [inputRfPortSelect], [inputRfPower], [inputRfSampleRate], [invertRfOutputSpectrum], [irigDcLocked], [irigLocked], [label], [logLevel], [manualGain], [minimumGain], [moduleState], [moduleType], [ntpStatus], [onePpsPresent], [outputAttenuation], [outputRfCenterFrequency], [outputRfDacSaturation], [outputRfDacSaturationPercent], [outputRfPort1DacSaturation], [outputRfPort1DacSaturationPercent], [outputRfPort1Power], [outputRfPort2DacSaturation], [outputRfPort2DacSaturationPercent], [outputRfPort2Power], [outputRfPortSelect], [outputRfPower], [overrideOutputFrequency], [overrideOutputFrequencyEnable], [pollInterval], [posixNanoseconds], [posixSeconds], [rebootRequired], [replyWaitTime], [requiredReadPrivilege], [requiredWritePrivilege], [rfOutputEnable], [rfOutputSource], [securitySource], [serialNumber], [shortDescription], [simulate], [squelchEnabled], [systemTemperature], [systemTimeSource], [tenMhzLocked], [version]) VALUES (12, 2000, 1, N'', N'good', N'', N'Normal', CAST(20 AS Numeric(10, 0)), CAST(1913 AS Numeric(10, 0)), 0, CAST(0 AS Numeric(5, 0)), N'Manual', N'10.228.41.129', N'good', N'', -22.3568535, 75.21689, N'40.0', 1360.5, -22.3568535, 75.21689, 73, -27.0147018, -22.3559, 75.21833, 73, -7.013752, N'rfIn1', -27.0147018, CAST(45000000 AS Numeric(10, 0)), 0, 0, 0, N'spectralNet', N'information', 20, 73, N'Operational', N'SpectralNet Module', N'Not Locked', 1, 11, 1350, -66.87659, 7.762747, -66.87659, 7.762747, -72.75498, -67.3645, 7.023482, -73.2429047, N'rfOut1', -72.75498, 1200, 0, CAST(1000 AS Numeric(10, 0)), CAST(528857128 AS Numeric(10, 0)), CAST(1672996380 AS Numeric(10, 0)), 0, N'00:01:00', N'', N'', 0, N'Packets', N'No Certificate', N'RT-191602282', N'A one stop shop for control and status of a single SpectralNet node', 0, 0, 43, N'IRIG', 1, N'1.7.4')
SET IDENTITY_INSERT [dbo].[M_Modules] OFF
GO
SET IDENTITY_INSERT [dbo].[M_OutputRfPort1Spectrum] ON 

INSERT [dbo].[M_OutputRfPort1Spectrum] ([id], [UnitId], [Spectrum]) VALUES (13, 2100, N'0xFF9DFF9EFF9DFF9EFF9EFF9EFF9EFF9EFF9FFF9EFF9EFF9CFF9BFF9AFF9DFF9FFF9FFF9FFF9FFFA0FFA0FFA0FFA1FF9FFF9EFF9EFF9EFFA0FFA1FFA1FFA0FF9FFFA0FFA0FF9FFF9EFF9EFF9FFF9FFF9FFFA0FFA0FF9EFF9CFF9BFF9CFF9EFFA0FFA1FF9FFF9EFF9DFF9AFF9DFF9EFF9EFF9DFF9CFF9FFF9FFF9FFFA1FFA2FFA1FFA0FF9FFF9EFF9FFFA0FF9FFF9CFF9BFF9DFF9EFF9EFF9DFF9DFF9DFF9BFF9BFF9AFF9CFF9EFFA0FFA2FFA0FF9FFF9EFF9DFF9BFF9CFF9BFF9BFF9CFF99FF9AFF9DFF9CFF9DFF9CFF9BFF9CFF9DFF9CFF9BFF9DFF9DFF9CFF9BFF9CFF9DFF9DFF9EFF9DFF9BFF99FF9BFF9CFF99FF9AFF9CFF9CFF9BFF9BFF9CFF9CFF9CFF9AFF9CFF9DFF9CFF9BFF9AFF9BFF9CFF9BFF9CFF9CFF9CFF9CFF9BFF9DFF9DFF9BFF9AFF9AFF9AFF9BFF9CFF9DFF9BFF9BFF9CFF9BFF9BFF9AFF99FF9CFF9EFF9EFF9EFF9CFF9BFF9CFF9BFF9BFF9AFF9AFF9AFF99FF9BFF9EFF9EFF9CFF9BFF9CFF99FF99FF98FF98FF99FF9CFF99FF97FF99FF9BFF9DFF9CFF9BFF9BFF9BFF99FF99FF99FF9AFF99FF9AFF99FF98FF9AFF9BFF9CFF9AFF99FF99FF98FF99FF99FF98FF98FF97FF99FF9AFF9BFF9CFF9DFF9AFF99FF99FF98FF9AFF9BFF9CFF9BFF97FF99FF9CFF9BFF9CFF9BFF9AFF9BFF99FF98FF9AFF9CFF9CFF9CFF9CFF9CFF9BFF99FF9AFF9BFF9BFF9BFF9AFF9BFF9BFF99FF9BFF9CFF9BFF9BFF9CFF9DFF9DFF9BFF99FF9AFF9BFF99FF99FF98FF9AFF9CFF9CFF9BFF9AFF9AFF9BFF9DFF9CFF9AFF98FF98FF98FF98FF9AFF9BFF9CFF9BFF9BFF9AFF9AFF9BFF9CFF9CFF9AFF98FF9AFF9BFF9BFF9BFF9CFF9CFF9EFF9EFF9CFF9BFF9AFF9BFF9AFF98FF99FF99FF97FF99FF99FF99FF9AFF99FF97FF9AFF9AFF9BFF9CFF9CFF9BFF9DFF9CFF9AFF99FF98FF97FF99FF9AFF9BFF99FF99FF99FF9AFF99FF99FF99FF9AFF9BFF9BFF99FF99FF9AFF99FF98FF98FF9AFF9BFF9AFF9AFF9AFF9BFF9CFF9BFF9AFF99FF9AFF9AFF99FF9AFF9AFF99FF9AFF99FF97FF99FF99FF9AFF99FF9AFF9BFF9CFF9AFF98FF99FF9AFF9AFF99FF9BFF9BFF9BFF9CFF9CFF9BFF9BFF9BFF9BFF99FF9AFF9CFF9DFF9BFF98FF96FF98FF9AFF9AFF9AFF98FF9AFF9DFF9CFF9BFF9AFF99FF9AFF98FF99FF99FF98FF99FF97FF99FF99FF98FF99FF9AFF9BFF9CFF9CFF9BFF97FF99FF9AFF99FF98FF9BFF9CFF9CFF9DFF9CFF9AFF9CFF9CFF9BFF9BFF9CFF9CFF9DFF9EFF9DFF9BFF9CFF9CFF9AFF9AFF99FF98FF99FF98FF97FF99FF9BFF9BFF9AFF9AFF99FF99FF99FF98FF96FF97FF98FF9BFF9BFF9CFF9BFF99FF99FF98FF98FF9AFF9CFF9BFF9AFF9BFF9BFF9AFF99FF99FF9AFF99FF9BFF9BFF9BFF9BFF99FF99FF9BFF9AFF9AFF9AFF97FF98FF9AFF9BFF99FF98FF98FF99FF98FF98FF98FF9AFF9BFF99FF96FF99FF9BFF9BFF99FF97FF99FF9CFF9DFF9DFF9DFF9BFF97FF98FF9AFF9AFF97FF97FF98FF99FF99FF99FF9AFF99FF9AFF9AFF99FF9AFF9AFF99FF9AFF99FF98FF9AFF9BFF9CFF9CFF9AFF99FF96FF98FF99FF98FF99FF99FF99FF9AFF9AFF9BFF9CFF9CFF9AFF99FF98FF99FF9BFF9CFF9CFF9DFF9CFF9CFF9AFF98FF9BFF9AFF99FF97FF9AFF9BFF9AFF98FF99FF9CFF9BFF9BFF9CFF9BFF99FF97FF99FF9AFF99FF99FF9BFF9BFF9CFF9BFF9BFF99FF99FF9BFF9CFF9BFF9CFF9CFF99FF99FF9AFF9AFF9BFF9AFF9BFF9BFF9BFF9AFF99FF9AFF9AFF99FF99FF99FF99FF9BFF9BFF99FF98FF99FF99FF99FF97FFA6FFAEFFB0FFACFFA1FF99FF9BFF9BFF9BFF9CFF9BFF9CFF9CFF9CFF9BFF9AFF97FF99FF99FF98FF99FF98FF98FF97FF97FF9AFF9CFF9BFF9AFF9BFF99FF9AFF9CFF9DFF9CFF9BFF9AFF98FF99FF9AFF99FF9BFF9CFF9BFF9BFF9BFF9BFF9BFF9BFF9BFF99FF98FF99FF9BFF9BFF9AFF9AFF99FF98FF99FF98FF98FF98FF96FF99FF9CFF9DFF9BFF9BFF9CFF9AFF98FF98FF99FF9AFF9BFF9AFF9CFF9AFF96FF97FF98FF9AFF9BFF9BFF9CFF9CFF9BFF9BFF9AFF9CFF9CFF9CFF9CFF9BFF9AFF9BFF98FF96FF97FF99FF9AFF9AFF99FF99FF9AFF9CFF9DFF9BFF9BFF9BFF9AFF9BFF9AFF9AFF9CFF9CFF9BFF9BFF9BFF99FF97FF98FF9AFF9AFF9CFFA0FFA1FF9FFF9BFF9AFF98FF98FF9BFF9CFF9DFF9EFF9EFF9DFF9BFF9AFF9AFF9AFF9AFF99FF9AFF9BFF9BFF9AFF98FF97FF99FF9CFF9CFF9CFF9AFF99FF98FF98FF9AFF9DFF9CFF9AFF9AFF98FF97FF9AFF9CFF9AFF99FF9CFF9CFF9CFF9AFF99FF9AFF9BFF9CFF9DFF9BFF99FF99FF9AFF9AFF99FF9AFF9BFF9CFF9DFF9CFF9AFF99FF99FF99FF99FF98FF9AFF9BFF9BFF9BFF9AFF9CFF9DFF99FF99FF9BFF9AFF98FF9AFF9AFF99FF97FF96FF9AFF9AFF98FF99FF9BFF9BFF98FF98FF9AFF9AFF9AFF9AFF9BFF9DFF9DFF9BFF9AFF9AFF9BFF9BFF9BFF99FF9BFF9DFF9BFF98FF99FF99FF95FF99FF9CFF9DFF9CFF9AFF98FF99FF9BFF9CFF9DFF9BFF9AFF9DFF9DFF9CFF9BFF9DFF9DFF9DFF9CFF9CFF9CFF9AFF9BFF9CFF9BFF9BFF9CFF9CFF9CFF9CFF9CFF9BFF9CFF9DFF9EFF9DFF9CFF9CFF9CFF9DFF9CFF9CFF9CFF9BFF9CFF9DFF9CFF9EFFA0FFA0FF9DFF9DFF9EFF9CFF9AFF9BFF9DFF9EFF9EFF9DFF9DFF9EFF9FFF9EFF9CFF9CFF9DFF9EFF9EFF9CFF9DFF9EFF9EFF9EFF9EFF9EFF9CFF9CFF9AFF9CFF9FFF9FFF9DFF9DFF9EFF9EFF9EFF9DFF9DFF9DFF9FFFA0FFA0FF9FFFA0FF9FFF9FFFA0FFA0FF9EFF9FFF9FFF9EFF9EFF9EFF9CFF9CFF9EFF9FFFA0FFA1FFA0FF9FFF9FFF9EFF9EFF9FFFA0FF9FFF9FFF9EFF9FFFA0FF9FFF9FFFA0FFA0FFA0FF9FFF9EFF9CFF9EFF9FFF9EFF9FFF9DFF9DFF9EFF9DFF9CFF9BFF9CFF9BFF9DFF9CFF9DFF9FFF9FFF9EFF9DFF9DFF9EFF9DFF9FFF9FFF9CFF9B')
INSERT [dbo].[M_OutputRfPort1Spectrum] ([id], [UnitId], [Spectrum]) VALUES (12, 2000, N'0xFFA6FFA7FFAAFFABFFABFFABFFABFFACFFAAFFAAFFAAFFABFFACFFADFFABFFABFFACFFADFFADFFADFFACFFACFFACFFADFFAEFFACFFA9FFA9FFABFFACFFACFFAAFFACFFAEFFAEFFABFFACFFADFFADFFADFFADFFACFFABFFAEFFB0FFAFFFADFFABFFA9FFABFFACFFAAFFA9FFAAFFABFFAAFFA8FFA7FFA9FFABFFADFFADFFADFFAAFFA7FFAAFFABFFAAFFABFFAAFFABFFAAFFA9FFAAFFABFFA9FFA7FFA8FFABFFAAFFAAFFAAFFA9FFAAFFABFFABFFABFFABFFAAFFA9FFA9FFA9FFA9FFABFFAAFFA8FFA9FFA8FFA5FFA3FFA6FFA7FFA8FFAAFFA9FFA7FFA8FFA8FFA7FFA8FFA7FFA7FFA6FFA8FFA9FFA9FFA6FFA6FFA6FFA7FFA7FFA4FFA5FFA6FFA6FFA8FFA8FFA8FFA8FFA7FFA6FFA6FFA7FFA6FFA8FFA6FFA4FFA5FFA4FFA4FFA5FFA6FFA6FFA6FFA6FFA7FFA6FFA3FFA3FFA6FFA6FFA5FFA4FFA2FFA4FFA4FFA4FFA6FFA6FFA6FFA7FFA6FFA5FFA6FFA6FFA7FFA7FFA7FFA4FFA4FFA0FFA0FFA2FFA5FFA4FFA6FFA6FFA3FFA1FFA3FFA4FFA6FFA6FFA4FFA4FFA4FFA3FFA3FFA3FFA4FFA3FFA4FFA5FFA2FFA1FFA2FFA4FFA4FFA4FFA4FFA4FFA6FFA6FFA4FFA4FFA3FFA2FFA2FFA2FFA2FFA2FFA4FFA3FFA3FFA3FFA4FFA6FFA4FFA2FFA3FFA4FFA5FFA3FFA3FFA4FFA3FFA4FFA5FFA4FFA1FFA4FFA4FFA2FFA3FFA3FFA6FFA5FFA3FFA1FFA4FFA3FFA4FFA4FFA4FFA2FFA4FFA3FFA3FFA2FFA3FFA4FFA2FFA2FFA5FFA3FFA2FFA3FFA4FFA2FFA4FFA4FFA4FFA4FFA4FFA6FFA7FFA6FFA4FFA3FFA5FFA3FFA1FFA1FFA4FFA5FFA5FFA5FFA4FFA3FFA4FFA4FFA5FFA4FFA5FFA8FFA7FFA5FFA6FFA4FFA1FFA2FFA2FFA3FFA4FFA4FFA4FFA2FFA4FFA2FFA2FFA3FFA4FFA3FFA1FFA3FFA1FFA3FFA3FFA4FFA5FFA4FFA3FFA2FFA3FFA3FFA3FFA5FFA4FFA3FFA1FFA1FFA2FFA3FFA3FFA5FFA3FFA2FFA2FFA5FFA5FFA6FFA3FFA0FFA3FFA4FFA5FFA3FFA2FFA3FFA4FFA4FFA5FFA4FFA2FFA3FFA3FFA6FFA3FFA2FFA1FFA2FFA5FFA3FFA6FFA6FFA6FFA4FFA4FFA4FFA3FFA0FFA3FFA3FFA5FFA5FFA7FFABFFACFFA9FFA5FFA5FFA4FFA4FFA5FFA6FFA9FFAAFFAAFFA9FFAAFFA8FFAAFFAAFFA9FFC6FFD9FFE3FFE5FFE0FFD4FFBBFFA8FFA9FFAAFFAAFFA9FFA9FFA7FFA8FFA9FFA7FFA5FFA2FFA4FFA4FFA3FFA8FFAAFFA7FFA5FFA4FFA1FFA1FFA5FFA6FFA5FFA6FFA5FFA4FFA5FFA5FFA6FFA6FFA2FFA4FFA4FFA2FFA4FFA4FFA3FFA4FFA2FFA3FFA5FFA4FFA6FFA6FFA3FFA3FFA4FFA4FFA4FFA4FFA4FFA3FFA3FFA3FFA5FFA7FFA6FFA4FFA5FFA4FFA2FFA3FFA3FFA4FFA1FFA2FFA5FFA5FFA4FFA3FFA0FFA4FFA3FFA1FFA3FFA4FFA4FFA3FFA1FFA2FFA3FFA3FFA4FFA4FFA5FFA7FFA7FFA6FFA4FFA4FFA4FFA3FFA3FFA5FFA5FFA4FFA5FFA4FFA4FFA2FFA5FFA5FFA4FFA3FFA3FFA2FFA4FFA5FFA3FFA1FFA1FFA2FFA3FFA2FFA1FF9FFFA5FFA6FFA8FFA8FFA5FFA4FFA4FFA2FFA3FFA1FFA5FFA4FFA6FFA6FFA5FFA3FFA6FFA6FFA2FFA2FFA2FFA2FFA4FFA5FFA4FFA1FFA4FFA6FFA4FFA5FFA4FFA3FFA1FFA1FFA2FFA3FFA3FFA2FFA1FFA4FFA5FFA5FFA4FFA1FFA3FFA4FFA4FFA4FFA2FFA3FFA2FFA2FFA0FFA2FFA5FFA5FFA2FFA2FFA4FFA4FFA3FFA3FFA5FFA3FFA2FFA2FFA3FFA4FFA3FFA3FFA4FFA2FFA3FFA1FFA2FFA2FFA4FFA3FFA0FFA2FFA3FFA4FFA4FFA3FFA2FFA4FFA4FFA4FFA4FFA3FFA4FFA4FFA3FFA0FFA2FFA4FFA1FFA3FFA5FFA5FFA4FFA2FF9FFFA2FFA4FFA5FFA5FFA2FFA1FFA4FFA4FFA2FFA4FFA5FFA6FFA5FFA4FFA4FFA3FFA4FFA5FFA6FFA4FFA3FFA3FFA3FFA2FFA5FFA5FFA4FFA3FFA3FFA4FFA4FFA1FFA2FFA2FFA3FFA2FFA3FFA3FFA3FFA3FFA3FFA2FFA2FFA3FFA3FFA1FFA1FFA3FFA3FFA1FFA3FFA2FFA4FFA5FFA3FFA2FFA1FFA3FFA5FFA4FFA1FFA1FFA3FFA4FFA3FFA4FFA6FFA6FFA5FFA5FFA5FFA1FFA1FFA3FFA3FFA2FF9EFFA3FFA4FFA3FFA3FFA5FFA5FFA5FFA3FFA2FFA1FFA3FFA3FFA3FFA5FFA5FFA4FFA4FFA3FFA3FFA2FFA3FFA2FFA3FFA3FFA5FFA1FFA1FFA0FFA2FFA3FFA3FFA4FFA6FFA6FFA4FFA2FFA0FFA1FFA4FFA4FFA3FFA4FFA3FFA2FFA3FFA3FFA4FFA5FFA4FFA6FFA5FFA5FFA6FFA4FFA3FFA3FFA2FFA4FFA4FFA3FFA1FFA1FFA2FFA2FFA2FFA4FFA5FFA4FFA4FFA5FFA1FFA1FFA3FFA3FFA2FFA5FFA3FF9FFF9FFFA0FFA3FFA3FFA2FFA1FFA2FFA4FFA3FFA3FFA4FFA4FFA4FFA6FFA4FFA3FFA4FFA5FFA4FFA5FFA4FFA4FFA2FFA4FFA4FFA4FFA7FFA5FFA3FFA5FFA3FFA5FFA5FFA4FFA4FFA4FFA2FFA2FFA4FFA3FFA5FFA5FFA6FFA5FFA2FFA2FFA3FFA2FFA3FFA6FFA6FFA5FFA4FFA5FFA4FFA5FFA6FFA7FFA6FFA5FFA6FFA4FFA2FFA4FFA5FFA5FFA4FFA5FFA5FFA5FFA4FFA4FFA4FFA5FFA3FFA4FFA5FFA5FFA4FFA2FFA1FFA3FFA6FFA6FFA7FFA6FFA6FFA6FFA7FFA4FFA4FFA4FFA5FFA6FFA7FFA7FFA6FFA5FFA3FFA5FFA7FFA6FFA6FFA7FFA7FFA7FFA8FFA9FFA7FFA3FFA5FFA6FFA4FFA6FFA5FFA4FFA4FFA5FFA5FFA5FFA5FFA6FFA6FFA4FFA7FFA2FFA3FFA4FFA7FFA9FFA7FFA4FFA4FFA7FFA7FFA6FFA8FFA9FFA8FFA7FFAAFFA6FFA5FFA7FFA4FFA6FFA9FFA8FFA8FFA8FFA9FFA7FF9EFFA5FFA7FFA8FFA8FFA8FFAAFFA8FFA7FFA7FFA9FFA9FFA8FFA6FFA7FFA6FFA9FFA8FFA9FFA8FFA7FFA9FFA9FFA8FFA9FFA9FFAAFFAAFFABFFACFFABFFAAFFAAFFABFFAAFFAAFFAAFFA9FFA9FFAAFFACFFABFFA9FFABFFABFFAAFFABFFACFFACFFABFFAAFFACFFACFFABFFAAFFAAFFAAFFABFFABFFADFFACFFA9FFA6FFA7FFACFFAEFFAEFFADFFACFFADFFAEFFABFFAAFFABFFACFFACFFABFFACFFACFFADFFADFFACFFADFFADFFADFFAAFFABFFADFFABFFACFFACFFABFFAAFFA8FFA9FFAAFFA9FFA9FFA8FFAAFFABFFAAFFA8FFA8FFA6')
SET IDENTITY_INSERT [dbo].[M_OutputRfPort1Spectrum] OFF
GO
SET IDENTITY_INSERT [dbo].[M_OutputRfPort2Spectrum] ON 

INSERT [dbo].[M_OutputRfPort2Spectrum] ([id], [UnitId], [Spectrum]) VALUES (13, 2100, N'0xFF9DFF9EFF9DFF9EFF9EFF9EFF9EFF9EFF9FFF9EFF9EFF9CFF9BFF9AFF9DFF9FFF9FFF9FFF9FFFA0FFA0FFA0FFA1FF9FFF9EFF9EFF9EFFA0FFA1FFA1FFA0FF9FFFA0FFA0FF9FFF9EFF9EFF9FFF9FFF9FFFA0FFA0FF9EFF9CFF9BFF9CFF9EFFA0FFA1FF9FFF9EFF9DFF9AFF9DFF9EFF9EFF9DFF9CFF9FFF9FFF9FFFA1FFA2FFA1FFA0FF9FFF9EFF9FFFA0FF9FFF9CFF9BFF9DFF9EFF9EFF9DFF9DFF9DFF9BFF9BFF9AFF9CFF9EFFA0FFA2FFA0FF9FFF9EFF9DFF9BFF9CFF9BFF9BFF9CFF99FF9AFF9DFF9CFF9DFF9CFF9BFF9CFF9DFF9CFF9BFF9DFF9DFF9CFF9BFF9CFF9DFF9DFF9EFF9DFF9BFF99FF9BFF9CFF99FF9AFF9CFF9CFF9BFF9BFF9CFF9CFF9CFF9AFF9CFF9DFF9CFF9BFF9AFF9BFF9CFF9BFF9CFF9CFF9CFF9CFF9BFF9DFF9DFF9BFF9AFF9AFF9AFF9BFF9CFF9DFF9BFF9BFF9CFF9BFF9BFF9AFF99FF9CFF9EFF9EFF9EFF9CFF9BFF9CFF9BFF9BFF9AFF9AFF9AFF99FF9BFF9EFF9EFF9CFF9BFF9CFF99FF99FF98FF98FF99FF9CFF99FF97FF99FF9BFF9DFF9CFF9BFF9BFF9BFF99FF99FF99FF9AFF99FF9AFF99FF98FF9AFF9BFF9CFF9AFF99FF99FF98FF99FF99FF98FF98FF97FF99FF9AFF9BFF9CFF9DFF9AFF99FF99FF98FF9AFF9BFF9CFF9BFF97FF99FF9CFF9BFF9CFF9BFF9AFF9BFF99FF98FF9AFF9CFF9CFF9CFF9CFF9CFF9BFF99FF9AFF9BFF9BFF9BFF9AFF9BFF9BFF99FF9BFF9CFF9BFF9BFF9CFF9DFF9DFF9BFF99FF9AFF9BFF99FF99FF98FF9AFF9CFF9CFF9BFF9AFF9AFF9BFF9DFF9CFF9AFF98FF98FF98FF98FF9AFF9BFF9CFF9BFF9BFF9AFF9AFF9BFF9CFF9CFF9AFF98FF9AFF9BFF9BFF9BFF9CFF9CFF9EFF9EFF9CFF9BFF9AFF9BFF9AFF98FF99FF99FF97FF99FF99FF99FF9AFF99FF97FF9AFF9AFF9BFF9CFF9CFF9BFF9DFF9CFF9AFF99FF98FF97FF99FF9AFF9BFF99FF99FF99FF9AFF99FF99FF99FF9AFF9BFF9BFF99FF99FF9AFF99FF98FF98FF9AFF9BFF9AFF9AFF9AFF9BFF9CFF9BFF9AFF99FF9AFF9AFF99FF9AFF9AFF99FF9AFF99FF97FF99FF99FF9AFF99FF9AFF9BFF9CFF9AFF98FF99FF9AFF9AFF99FF9BFF9BFF9BFF9CFF9CFF9BFF9BFF9BFF9BFF99FF9AFF9CFF9DFF9BFF98FF96FF98FF9AFF9AFF9AFF98FF9AFF9DFF9CFF9BFF9AFF99FF9AFF98FF99FF99FF98FF99FF97FF99FF99FF98FF99FF9AFF9BFF9CFF9CFF9BFF97FF99FF9AFF99FF98FF9BFF9CFF9CFF9DFF9CFF9AFF9CFF9CFF9BFF9BFF9CFF9CFF9DFF9EFF9DFF9BFF9CFF9CFF9AFF9AFF99FF98FF99FF98FF97FF99FF9BFF9BFF9AFF9AFF99FF99FF99FF98FF96FF97FF98FF9BFF9BFF9CFF9BFF99FF99FF98FF98FF9AFF9CFF9BFF9AFF9BFF9BFF9AFF99FF99FF9AFF99FF9BFF9BFF9BFF9BFF99FF99FF9BFF9AFF9AFF9AFF97FF98FF9AFF9BFF99FF98FF98FF99FF98FF98FF98FF9AFF9BFF99FF96FF99FF9BFF9BFF99FF97FF99FF9CFF9DFF9DFF9DFF9BFF97FF98FF9AFF9AFF97FF97FF98FF99FF99FF99FF9AFF99FF9AFF9AFF99FF9AFF9AFF99FF9AFF99FF98FF9AFF9BFF9CFF9CFF9AFF99FF96FF98FF99FF98FF99FF99FF99FF9AFF9AFF9BFF9CFF9CFF9AFF99FF98FF99FF9BFF9CFF9CFF9DFF9CFF9CFF9AFF98FF9BFF9AFF99FF97FF9AFF9BFF9AFF98FF99FF9CFF9BFF9BFF9CFF9BFF99FF97FF99FF9AFF99FF99FF9BFF9BFF9CFF9BFF9BFF99FF99FF9BFF9CFF9BFF9CFF9CFF99FF99FF9AFF9AFF9BFF9AFF9BFF9BFF9BFF9AFF99FF9AFF9AFF99FF99FF99FF99FF9BFF9BFF99FF98FF99FF99FF99FF97FFA6FFAEFFB0FFACFFA1FF99FF9BFF9BFF9BFF9CFF9BFF9CFF9CFF9CFF9BFF9AFF97FF99FF99FF98FF99FF98FF98FF97FF97FF9AFF9CFF9BFF9AFF9BFF99FF9AFF9CFF9DFF9CFF9BFF9AFF98FF99FF9AFF99FF9BFF9CFF9BFF9BFF9BFF9BFF9BFF9BFF9BFF99FF98FF99FF9BFF9BFF9AFF9AFF99FF98FF99FF98FF98FF98FF96FF99FF9CFF9DFF9BFF9BFF9CFF9AFF98FF98FF99FF9AFF9BFF9AFF9CFF9AFF96FF97FF98FF9AFF9BFF9BFF9CFF9CFF9BFF9BFF9AFF9CFF9CFF9CFF9CFF9BFF9AFF9BFF98FF96FF97FF99FF9AFF9AFF99FF99FF9AFF9CFF9DFF9BFF9BFF9BFF9AFF9BFF9AFF9AFF9CFF9CFF9BFF9BFF9BFF99FF97FF98FF9AFF9AFF9CFFA0FFA1FF9FFF9BFF9AFF98FF98FF9BFF9CFF9DFF9EFF9EFF9DFF9BFF9AFF9AFF9AFF9AFF99FF9AFF9BFF9BFF9AFF98FF97FF99FF9CFF9CFF9CFF9AFF99FF98FF98FF9AFF9DFF9CFF9AFF9AFF98FF97FF9AFF9CFF9AFF99FF9CFF9CFF9CFF9AFF99FF9AFF9BFF9CFF9DFF9BFF99FF99FF9AFF9AFF99FF9AFF9BFF9CFF9DFF9CFF9AFF99FF99FF99FF99FF98FF9AFF9BFF9BFF9BFF9AFF9CFF9DFF99FF99FF9BFF9AFF98FF9AFF9AFF99FF97FF96FF9AFF9AFF98FF99FF9BFF9BFF98FF98FF9AFF9AFF9AFF9AFF9BFF9DFF9DFF9BFF9AFF9AFF9BFF9BFF9BFF99FF9BFF9DFF9BFF98FF99FF99FF95FF99FF9CFF9DFF9CFF9AFF98FF99FF9BFF9CFF9DFF9BFF9AFF9DFF9DFF9CFF9BFF9DFF9DFF9DFF9CFF9CFF9CFF9AFF9BFF9CFF9BFF9BFF9CFF9CFF9CFF9CFF9CFF9BFF9CFF9DFF9EFF9DFF9CFF9CFF9CFF9DFF9CFF9CFF9CFF9BFF9CFF9DFF9CFF9EFFA0FFA0FF9DFF9DFF9EFF9CFF9AFF9BFF9DFF9EFF9EFF9DFF9DFF9EFF9FFF9EFF9CFF9CFF9DFF9EFF9EFF9CFF9DFF9EFF9EFF9EFF9EFF9EFF9CFF9CFF9AFF9CFF9FFF9FFF9DFF9DFF9EFF9EFF9EFF9DFF9DFF9DFF9FFFA0FFA0FF9FFFA0FF9FFF9FFFA0FFA0FF9EFF9FFF9FFF9EFF9EFF9EFF9CFF9CFF9EFF9FFFA0FFA1FFA0FF9FFF9FFF9EFF9EFF9FFFA0FF9FFF9FFF9EFF9FFFA0FF9FFF9FFFA0FFA0FFA0FF9FFF9EFF9CFF9EFF9FFF9EFF9FFF9DFF9DFF9EFF9DFF9CFF9BFF9CFF9BFF9DFF9CFF9DFF9FFF9FFF9EFF9DFF9DFF9EFF9DFF9FFF9FFF9CFF9B')
INSERT [dbo].[M_OutputRfPort2Spectrum] ([id], [UnitId], [Spectrum]) VALUES (12, 2000, N'0xFFA6FFA7FFAAFFABFFABFFABFFABFFACFFAAFFAAFFAAFFABFFACFFADFFABFFABFFACFFADFFADFFADFFACFFACFFACFFADFFAEFFACFFA9FFA9FFABFFACFFACFFAAFFACFFAEFFAEFFABFFACFFADFFADFFADFFADFFACFFABFFAEFFB0FFAFFFADFFABFFA9FFABFFACFFAAFFA9FFAAFFABFFAAFFA8FFA7FFA9FFABFFADFFADFFADFFAAFFA7FFAAFFABFFAAFFABFFAAFFABFFAAFFA9FFAAFFABFFA9FFA7FFA8FFABFFAAFFAAFFAAFFA9FFAAFFABFFABFFABFFABFFAAFFA9FFA9FFA9FFA9FFABFFAAFFA8FFA9FFA8FFA5FFA3FFA6FFA7FFA8FFAAFFA9FFA7FFA8FFA8FFA7FFA8FFA7FFA7FFA6FFA8FFA9FFA9FFA6FFA6FFA6FFA7FFA7FFA4FFA5FFA6FFA6FFA8FFA8FFA8FFA8FFA7FFA6FFA6FFA7FFA6FFA8FFA6FFA4FFA5FFA4FFA4FFA5FFA6FFA6FFA6FFA6FFA7FFA6FFA3FFA3FFA6FFA6FFA5FFA4FFA2FFA4FFA4FFA4FFA6FFA6FFA6FFA7FFA6FFA5FFA6FFA6FFA7FFA7FFA7FFA4FFA4FFA0FFA0FFA2FFA5FFA4FFA6FFA6FFA3FFA1FFA3FFA4FFA6FFA6FFA4FFA4FFA4FFA3FFA3FFA3FFA4FFA3FFA4FFA5FFA2FFA1FFA2FFA4FFA4FFA4FFA4FFA4FFA6FFA6FFA4FFA4FFA3FFA2FFA2FFA2FFA2FFA2FFA4FFA3FFA3FFA3FFA4FFA6FFA4FFA2FFA3FFA4FFA5FFA3FFA3FFA4FFA3FFA4FFA5FFA4FFA1FFA4FFA4FFA2FFA3FFA3FFA6FFA5FFA3FFA1FFA4FFA3FFA4FFA4FFA4FFA2FFA4FFA3FFA3FFA2FFA3FFA4FFA2FFA2FFA5FFA3FFA2FFA3FFA4FFA2FFA4FFA4FFA4FFA4FFA4FFA6FFA7FFA6FFA4FFA3FFA5FFA3FFA1FFA1FFA4FFA5FFA5FFA5FFA4FFA3FFA4FFA4FFA5FFA4FFA5FFA8FFA7FFA5FFA6FFA4FFA1FFA2FFA2FFA3FFA4FFA4FFA4FFA2FFA4FFA2FFA2FFA3FFA4FFA3FFA1FFA3FFA1FFA3FFA3FFA4FFA5FFA4FFA3FFA2FFA3FFA3FFA3FFA5FFA4FFA3FFA1FFA1FFA2FFA3FFA3FFA5FFA3FFA2FFA2FFA5FFA5FFA6FFA3FFA0FFA3FFA4FFA5FFA3FFA2FFA3FFA4FFA4FFA5FFA4FFA2FFA3FFA3FFA6FFA3FFA2FFA1FFA2FFA5FFA3FFA6FFA6FFA6FFA4FFA4FFA4FFA3FFA0FFA3FFA3FFA5FFA5FFA7FFABFFACFFA9FFA5FFA5FFA4FFA4FFA5FFA6FFA9FFAAFFAAFFA9FFAAFFA8FFAAFFAAFFA9FFC6FFD9FFE3FFE5FFE0FFD4FFBBFFA8FFA9FFAAFFAAFFA9FFA9FFA7FFA8FFA9FFA7FFA5FFA2FFA4FFA4FFA3FFA8FFAAFFA7FFA5FFA4FFA1FFA1FFA5FFA6FFA5FFA6FFA5FFA4FFA5FFA5FFA6FFA6FFA2FFA4FFA4FFA2FFA4FFA4FFA3FFA4FFA2FFA3FFA5FFA4FFA6FFA6FFA3FFA3FFA4FFA4FFA4FFA4FFA4FFA3FFA3FFA3FFA5FFA7FFA6FFA4FFA5FFA4FFA2FFA3FFA3FFA4FFA1FFA2FFA5FFA5FFA4FFA3FFA0FFA4FFA3FFA1FFA3FFA4FFA4FFA3FFA1FFA2FFA3FFA3FFA4FFA4FFA5FFA7FFA7FFA6FFA4FFA4FFA4FFA3FFA3FFA5FFA5FFA4FFA5FFA4FFA4FFA2FFA5FFA5FFA4FFA3FFA3FFA2FFA4FFA5FFA3FFA1FFA1FFA2FFA3FFA2FFA1FF9FFFA5FFA6FFA8FFA8FFA5FFA4FFA4FFA2FFA3FFA1FFA5FFA4FFA6FFA6FFA5FFA3FFA6FFA6FFA2FFA2FFA2FFA2FFA4FFA5FFA4FFA1FFA4FFA6FFA4FFA5FFA4FFA3FFA1FFA1FFA2FFA3FFA3FFA2FFA1FFA4FFA5FFA5FFA4FFA1FFA3FFA4FFA4FFA4FFA2FFA3FFA2FFA2FFA0FFA2FFA5FFA5FFA2FFA2FFA4FFA4FFA3FFA3FFA5FFA3FFA2FFA2FFA3FFA4FFA3FFA3FFA4FFA2FFA3FFA1FFA2FFA2FFA4FFA3FFA0FFA2FFA3FFA4FFA4FFA3FFA2FFA4FFA4FFA4FFA4FFA3FFA4FFA4FFA3FFA0FFA2FFA4FFA1FFA3FFA5FFA5FFA4FFA2FF9FFFA2FFA4FFA5FFA5FFA2FFA1FFA4FFA4FFA2FFA4FFA5FFA6FFA5FFA4FFA4FFA3FFA4FFA5FFA6FFA4FFA3FFA3FFA3FFA2FFA5FFA5FFA4FFA3FFA3FFA4FFA4FFA1FFA2FFA2FFA3FFA2FFA3FFA3FFA3FFA3FFA3FFA2FFA2FFA3FFA3FFA1FFA1FFA3FFA3FFA1FFA3FFA2FFA4FFA5FFA3FFA2FFA1FFA3FFA5FFA4FFA1FFA1FFA3FFA4FFA3FFA4FFA6FFA6FFA5FFA5FFA5FFA1FFA1FFA3FFA3FFA2FF9EFFA3FFA4FFA3FFA3FFA5FFA5FFA5FFA3FFA2FFA1FFA3FFA3FFA3FFA5FFA5FFA4FFA4FFA3FFA3FFA2FFA3FFA2FFA3FFA3FFA5FFA1FFA1FFA0FFA2FFA3FFA3FFA4FFA6FFA6FFA4FFA2FFA0FFA1FFA4FFA4FFA3FFA4FFA3FFA2FFA3FFA3FFA4FFA5FFA4FFA6FFA5FFA5FFA6FFA4FFA3FFA3FFA2FFA4FFA4FFA3FFA1FFA1FFA2FFA2FFA2FFA4FFA5FFA4FFA4FFA5FFA1FFA1FFA3FFA3FFA2FFA5FFA3FF9FFF9FFFA0FFA3FFA3FFA2FFA1FFA2FFA4FFA3FFA3FFA4FFA4FFA4FFA6FFA4FFA3FFA4FFA5FFA4FFA5FFA4FFA4FFA2FFA4FFA4FFA4FFA7FFA5FFA3FFA5FFA3FFA5FFA5FFA4FFA4FFA4FFA2FFA2FFA4FFA3FFA5FFA5FFA6FFA5FFA2FFA2FFA3FFA2FFA3FFA6FFA6FFA5FFA4FFA5FFA4FFA5FFA6FFA7FFA6FFA5FFA6FFA4FFA2FFA4FFA5FFA5FFA4FFA5FFA5FFA5FFA4FFA4FFA4FFA5FFA3FFA4FFA5FFA5FFA4FFA2FFA1FFA3FFA6FFA6FFA7FFA6FFA6FFA6FFA7FFA4FFA4FFA4FFA5FFA6FFA7FFA7FFA6FFA5FFA3FFA5FFA7FFA6FFA6FFA7FFA7FFA7FFA8FFA9FFA7FFA3FFA5FFA6FFA4FFA6FFA5FFA4FFA4FFA5FFA5FFA5FFA5FFA6FFA6FFA4FFA7FFA2FFA3FFA4FFA7FFA9FFA7FFA4FFA4FFA7FFA7FFA6FFA8FFA9FFA8FFA7FFAAFFA6FFA5FFA7FFA4FFA6FFA9FFA8FFA8FFA8FFA9FFA7FF9EFFA5FFA7FFA8FFA8FFA8FFAAFFA8FFA7FFA7FFA9FFA9FFA8FFA6FFA7FFA6FFA9FFA8FFA9FFA8FFA7FFA9FFA9FFA8FFA9FFA9FFAAFFAAFFABFFACFFABFFAAFFAAFFABFFAAFFAAFFAAFFA9FFA9FFAAFFACFFABFFA9FFABFFABFFAAFFABFFACFFACFFABFFAAFFACFFACFFABFFAAFFAAFFAAFFABFFABFFADFFACFFA9FFA6FFA7FFACFFAEFFAEFFADFFACFFADFFAEFFABFFAAFFABFFACFFACFFABFFACFFACFFADFFADFFACFFADFFADFFADFFAAFFABFFADFFABFFACFFACFFABFFAAFFA8FFA9FFAAFFA9FFA9FFA8FFAAFFABFFAAFFA8FFA8FFA6')
SET IDENTITY_INSERT [dbo].[M_OutputRfPort2Spectrum] OFF
GO
SET IDENTITY_INSERT [dbo].[M_OutputRfSpectrum] ON 

INSERT [dbo].[M_OutputRfSpectrum] ([id], [UnitId], [Spectrum]) VALUES (12, 2000, N'0xFFA6FFA7FFAAFFABFFABFFABFFABFFACFFAAFFAAFFAAFFABFFACFFADFFABFFABFFACFFADFFADFFADFFACFFACFFACFFADFFAEFFACFFA9FFA9FFABFFACFFACFFAAFFACFFAEFFAEFFABFFACFFADFFADFFADFFADFFACFFABFFAEFFB0FFAFFFADFFABFFA9FFABFFACFFAAFFA9FFAAFFABFFAAFFA8FFA7FFA9FFABFFADFFADFFADFFAAFFA7FFAAFFABFFAAFFABFFAAFFABFFAAFFA9FFAAFFABFFA9FFA7FFA8FFABFFAAFFAAFFAAFFA9FFAAFFABFFABFFABFFABFFAAFFA9FFA9FFA9FFA9FFABFFAAFFA8FFA9FFA8FFA5FFA3FFA6FFA7FFA8FFAAFFA9FFA7FFA8FFA8FFA7FFA8FFA7FFA7FFA6FFA8FFA9FFA9FFA6FFA6FFA6FFA7FFA7FFA4FFA5FFA6FFA6FFA8FFA8FFA8FFA8FFA7FFA6FFA6FFA7FFA6FFA8FFA6FFA4FFA5FFA4FFA4FFA5FFA6FFA6FFA6FFA6FFA7FFA6FFA3FFA3FFA6FFA6FFA5FFA4FFA2FFA4FFA4FFA4FFA6FFA6FFA6FFA7FFA6FFA5FFA6FFA6FFA7FFA7FFA7FFA4FFA4FFA0FFA0FFA2FFA5FFA4FFA6FFA6FFA3FFA1FFA3FFA4FFA6FFA6FFA4FFA4FFA4FFA3FFA3FFA3FFA4FFA3FFA4FFA5FFA2FFA1FFA2FFA4FFA4FFA4FFA4FFA4FFA6FFA6FFA4FFA4FFA3FFA2FFA2FFA2FFA2FFA2FFA4FFA3FFA3FFA3FFA4FFA6FFA4FFA2FFA3FFA4FFA5FFA3FFA3FFA4FFA3FFA4FFA5FFA4FFA1FFA4FFA4FFA2FFA3FFA3FFA6FFA5FFA3FFA1FFA4FFA3FFA4FFA4FFA4FFA2FFA4FFA3FFA3FFA2FFA3FFA4FFA2FFA2FFA5FFA3FFA2FFA3FFA4FFA2FFA4FFA4FFA4FFA4FFA4FFA6FFA7FFA6FFA4FFA3FFA5FFA3FFA1FFA1FFA4FFA5FFA5FFA5FFA4FFA3FFA4FFA4FFA5FFA4FFA5FFA8FFA7FFA5FFA6FFA4FFA1FFA2FFA2FFA3FFA4FFA4FFA4FFA2FFA4FFA2FFA2FFA3FFA4FFA3FFA1FFA3FFA1FFA3FFA3FFA4FFA5FFA4FFA3FFA2FFA3FFA3FFA3FFA5FFA4FFA3FFA1FFA1FFA2FFA3FFA3FFA5FFA3FFA2FFA2FFA5FFA5FFA6FFA3FFA0FFA3FFA4FFA5FFA3FFA2FFA3FFA4FFA4FFA5FFA4FFA2FFA3FFA3FFA6FFA3FFA2FFA1FFA2FFA5FFA3FFA6FFA6FFA6FFA4FFA4FFA4FFA3FFA0FFA3FFA3FFA5FFA5FFA7FFABFFACFFA9FFA5FFA5FFA4FFA4FFA5FFA6FFA9FFAAFFAAFFA9FFAAFFA8FFAAFFAAFFA9FFC6FFD9FFE3FFE5FFE0FFD4FFBBFFA8FFA9FFAAFFAAFFA9FFA9FFA7FFA8FFA9FFA7FFA5FFA2FFA4FFA4FFA3FFA8FFAAFFA7FFA5FFA4FFA1FFA1FFA5FFA6FFA5FFA6FFA5FFA4FFA5FFA5FFA6FFA6FFA2FFA4FFA4FFA2FFA4FFA4FFA3FFA4FFA2FFA3FFA5FFA4FFA6FFA6FFA3FFA3FFA4FFA4FFA4FFA4FFA4FFA3FFA3FFA3FFA5FFA7FFA6FFA4FFA5FFA4FFA2FFA3FFA3FFA4FFA1FFA2FFA5FFA5FFA4FFA3FFA0FFA4FFA3FFA1FFA3FFA4FFA4FFA3FFA1FFA2FFA3FFA3FFA4FFA4FFA5FFA7FFA7FFA6FFA4FFA4FFA4FFA3FFA3FFA5FFA5FFA4FFA5FFA4FFA4FFA2FFA5FFA5FFA4FFA3FFA3FFA2FFA4FFA5FFA3FFA1FFA1FFA2FFA3FFA2FFA1FF9FFFA5FFA6FFA8FFA8FFA5FFA4FFA4FFA2FFA3FFA1FFA5FFA4FFA6FFA6FFA5FFA3FFA6FFA6FFA2FFA2FFA2FFA2FFA4FFA5FFA4FFA1FFA4FFA6FFA4FFA5FFA4FFA3FFA1FFA1FFA2FFA3FFA3FFA2FFA1FFA4FFA5FFA5FFA4FFA1FFA3FFA4FFA4FFA4FFA2FFA3FFA2FFA2FFA0FFA2FFA5FFA5FFA2FFA2FFA4FFA4FFA3FFA3FFA5FFA3FFA2FFA2FFA3FFA4FFA3FFA3FFA4FFA2FFA3FFA1FFA2FFA2FFA4FFA3FFA0FFA2FFA3FFA4FFA4FFA3FFA2FFA4FFA4FFA4FFA4FFA3FFA4FFA4FFA3FFA0FFA2FFA4FFA1FFA3FFA5FFA5FFA4FFA2FF9FFFA2FFA4FFA5FFA5FFA2FFA1FFA4FFA4FFA2FFA4FFA5FFA6FFA5FFA4FFA4FFA3FFA4FFA5FFA6FFA4FFA3FFA3FFA3FFA2FFA5FFA5FFA4FFA3FFA3FFA4FFA4FFA1FFA2FFA2FFA3FFA2FFA3FFA3FFA3FFA3FFA3FFA2FFA2FFA3FFA3FFA1FFA1FFA3FFA3FFA1FFA3FFA2FFA4FFA5FFA3FFA2FFA1FFA3FFA5FFA4FFA1FFA1FFA3FFA4FFA3FFA4FFA6FFA6FFA5FFA5FFA5FFA1FFA1FFA3FFA3FFA2FF9EFFA3FFA4FFA3FFA3FFA5FFA5FFA5FFA3FFA2FFA1FFA3FFA3FFA3FFA5FFA5FFA4FFA4FFA3FFA3FFA2FFA3FFA2FFA3FFA3FFA5FFA1FFA1FFA0FFA2FFA3FFA3FFA4FFA6FFA6FFA4FFA2FFA0FFA1FFA4FFA4FFA3FFA4FFA3FFA2FFA3FFA3FFA4FFA5FFA4FFA6FFA5FFA5FFA6FFA4FFA3FFA3FFA2FFA4FFA4FFA3FFA1FFA1FFA2FFA2FFA2FFA4FFA5FFA4FFA4FFA5FFA1FFA1FFA3FFA3FFA2FFA5FFA3FF9FFF9FFFA0FFA3FFA3FFA2FFA1FFA2FFA4FFA3FFA3FFA4FFA4FFA4FFA6FFA4FFA3FFA4FFA5FFA4FFA5FFA4FFA4FFA2FFA4FFA4FFA4FFA7FFA5FFA3FFA5FFA3FFA5FFA5FFA4FFA4FFA4FFA2FFA2FFA4FFA3FFA5FFA5FFA6FFA5FFA2FFA2FFA3FFA2FFA3FFA6FFA6FFA5FFA4FFA5FFA4FFA5FFA6FFA7FFA6FFA5FFA6FFA4FFA2FFA4FFA5FFA5FFA4FFA5FFA5FFA5FFA4FFA4FFA4FFA5FFA3FFA4FFA5FFA5FFA4FFA2FFA1FFA3FFA6FFA6FFA7FFA6FFA6FFA6FFA7FFA4FFA4FFA4FFA5FFA6FFA7FFA7FFA6FFA5FFA3FFA5FFA7FFA6FFA6FFA7FFA7FFA7FFA8FFA9FFA7FFA3FFA5FFA6FFA4FFA6FFA5FFA4FFA4FFA5FFA5FFA5FFA5FFA6FFA6FFA4FFA7FFA2FFA3FFA4FFA7FFA9FFA7FFA4FFA4FFA7FFA7FFA6FFA8FFA9FFA8FFA7FFAAFFA6FFA5FFA7FFA4FFA6FFA9FFA8FFA8FFA8FFA9FFA7FF9EFFA5FFA7FFA8FFA8FFA8FFAAFFA8FFA7FFA7FFA9FFA9FFA8FFA6FFA7FFA6FFA9FFA8FFA9FFA8FFA7FFA9FFA9FFA8FFA9FFA9FFAAFFAAFFABFFACFFABFFAAFFAAFFABFFAAFFAAFFAAFFA9FFA9FFAAFFACFFABFFA9FFABFFABFFAAFFABFFACFFACFFABFFAAFFACFFACFFABFFAAFFAAFFAAFFABFFABFFADFFACFFA9FFA6FFA7FFACFFAEFFAEFFADFFACFFADFFAEFFABFFAAFFABFFACFFACFFABFFACFFACFFADFFADFFACFFADFFADFFADFFAAFFABFFADFFABFFACFFACFFABFFAAFFA8FFA9FFAAFFA9FFA9FFA8FFAAFFABFFAAFFA8FFA8FFA6')
INSERT [dbo].[M_OutputRfSpectrum] ([id], [UnitId], [Spectrum]) VALUES (13, 2100, N'0xFF9DFF9EFF9DFF9EFF9EFF9EFF9EFF9EFF9FFF9EFF9EFF9CFF9BFF9AFF9DFF9FFF9FFF9FFF9FFFA0FFA0FFA0FFA1FF9FFF9EFF9EFF9EFFA0FFA1FFA1FFA0FF9FFFA0FFA0FF9FFF9EFF9EFF9FFF9FFF9FFFA0FFA0FF9EFF9CFF9BFF9CFF9EFFA0FFA1FF9FFF9EFF9DFF9AFF9DFF9EFF9EFF9DFF9CFF9FFF9FFF9FFFA1FFA2FFA1FFA0FF9FFF9EFF9FFFA0FF9FFF9CFF9BFF9DFF9EFF9EFF9DFF9DFF9DFF9BFF9BFF9AFF9CFF9EFFA0FFA2FFA0FF9FFF9EFF9DFF9BFF9CFF9BFF9BFF9CFF99FF9AFF9DFF9CFF9DFF9CFF9BFF9CFF9DFF9CFF9BFF9DFF9DFF9CFF9BFF9CFF9DFF9DFF9EFF9DFF9BFF99FF9BFF9CFF99FF9AFF9CFF9CFF9BFF9BFF9CFF9CFF9CFF9AFF9CFF9DFF9CFF9BFF9AFF9BFF9CFF9BFF9CFF9CFF9CFF9CFF9BFF9DFF9DFF9BFF9AFF9AFF9AFF9BFF9CFF9DFF9BFF9BFF9CFF9BFF9BFF9AFF99FF9CFF9EFF9EFF9EFF9CFF9BFF9CFF9BFF9BFF9AFF9AFF9AFF99FF9BFF9EFF9EFF9CFF9BFF9CFF99FF99FF98FF98FF99FF9CFF99FF97FF99FF9BFF9DFF9CFF9BFF9BFF9BFF99FF99FF99FF9AFF99FF9AFF99FF98FF9AFF9BFF9CFF9AFF99FF99FF98FF99FF99FF98FF98FF97FF99FF9AFF9BFF9CFF9DFF9AFF99FF99FF98FF9AFF9BFF9CFF9BFF97FF99FF9CFF9BFF9CFF9BFF9AFF9BFF99FF98FF9AFF9CFF9CFF9CFF9CFF9CFF9BFF99FF9AFF9BFF9BFF9BFF9AFF9BFF9BFF99FF9BFF9CFF9BFF9BFF9CFF9DFF9DFF9BFF99FF9AFF9BFF99FF99FF98FF9AFF9CFF9CFF9BFF9AFF9AFF9BFF9DFF9CFF9AFF98FF98FF98FF98FF9AFF9BFF9CFF9BFF9BFF9AFF9AFF9BFF9CFF9CFF9AFF98FF9AFF9BFF9BFF9BFF9CFF9CFF9EFF9EFF9CFF9BFF9AFF9BFF9AFF98FF99FF99FF97FF99FF99FF99FF9AFF99FF97FF9AFF9AFF9BFF9CFF9CFF9BFF9DFF9CFF9AFF99FF98FF97FF99FF9AFF9BFF99FF99FF99FF9AFF99FF99FF99FF9AFF9BFF9BFF99FF99FF9AFF99FF98FF98FF9AFF9BFF9AFF9AFF9AFF9BFF9CFF9BFF9AFF99FF9AFF9AFF99FF9AFF9AFF99FF9AFF99FF97FF99FF99FF9AFF99FF9AFF9BFF9CFF9AFF98FF99FF9AFF9AFF99FF9BFF9BFF9BFF9CFF9CFF9BFF9BFF9BFF9BFF99FF9AFF9CFF9DFF9BFF98FF96FF98FF9AFF9AFF9AFF98FF9AFF9DFF9CFF9BFF9AFF99FF9AFF98FF99FF99FF98FF99FF97FF99FF99FF98FF99FF9AFF9BFF9CFF9CFF9BFF97FF99FF9AFF99FF98FF9BFF9CFF9CFF9DFF9CFF9AFF9CFF9CFF9BFF9BFF9CFF9CFF9DFF9EFF9DFF9BFF9CFF9CFF9AFF9AFF99FF98FF99FF98FF97FF99FF9BFF9BFF9AFF9AFF99FF99FF99FF98FF96FF97FF98FF9BFF9BFF9CFF9BFF99FF99FF98FF98FF9AFF9CFF9BFF9AFF9BFF9BFF9AFF99FF99FF9AFF99FF9BFF9BFF9BFF9BFF99FF99FF9BFF9AFF9AFF9AFF97FF98FF9AFF9BFF99FF98FF98FF99FF98FF98FF98FF9AFF9BFF99FF96FF99FF9BFF9BFF99FF97FF99FF9CFF9DFF9DFF9DFF9BFF97FF98FF9AFF9AFF97FF97FF98FF99FF99FF99FF9AFF99FF9AFF9AFF99FF9AFF9AFF99FF9AFF99FF98FF9AFF9BFF9CFF9CFF9AFF99FF96FF98FF99FF98FF99FF99FF99FF9AFF9AFF9BFF9CFF9CFF9AFF99FF98FF99FF9BFF9CFF9CFF9DFF9CFF9CFF9AFF98FF9BFF9AFF99FF97FF9AFF9BFF9AFF98FF99FF9CFF9BFF9BFF9CFF9BFF99FF97FF99FF9AFF99FF99FF9BFF9BFF9CFF9BFF9BFF99FF99FF9BFF9CFF9BFF9CFF9CFF99FF99FF9AFF9AFF9BFF9AFF9BFF9BFF9BFF9AFF99FF9AFF9AFF99FF99FF99FF99FF9BFF9BFF99FF98FF99FF99FF99FF97FFA6FFAEFFB0FFACFFA1FF99FF9BFF9BFF9BFF9CFF9BFF9CFF9CFF9CFF9BFF9AFF97FF99FF99FF98FF99FF98FF98FF97FF97FF9AFF9CFF9BFF9AFF9BFF99FF9AFF9CFF9DFF9CFF9BFF9AFF98FF99FF9AFF99FF9BFF9CFF9BFF9BFF9BFF9BFF9BFF9BFF9BFF99FF98FF99FF9BFF9BFF9AFF9AFF99FF98FF99FF98FF98FF98FF96FF99FF9CFF9DFF9BFF9BFF9CFF9AFF98FF98FF99FF9AFF9BFF9AFF9CFF9AFF96FF97FF98FF9AFF9BFF9BFF9CFF9CFF9BFF9BFF9AFF9CFF9CFF9CFF9CFF9BFF9AFF9BFF98FF96FF97FF99FF9AFF9AFF99FF99FF9AFF9CFF9DFF9BFF9BFF9BFF9AFF9BFF9AFF9AFF9CFF9CFF9BFF9BFF9BFF99FF97FF98FF9AFF9AFF9CFFA0FFA1FF9FFF9BFF9AFF98FF98FF9BFF9CFF9DFF9EFF9EFF9DFF9BFF9AFF9AFF9AFF9AFF99FF9AFF9BFF9BFF9AFF98FF97FF99FF9CFF9CFF9CFF9AFF99FF98FF98FF9AFF9DFF9CFF9AFF9AFF98FF97FF9AFF9CFF9AFF99FF9CFF9CFF9CFF9AFF99FF9AFF9BFF9CFF9DFF9BFF99FF99FF9AFF9AFF99FF9AFF9BFF9CFF9DFF9CFF9AFF99FF99FF99FF99FF98FF9AFF9BFF9BFF9BFF9AFF9CFF9DFF99FF99FF9BFF9AFF98FF9AFF9AFF99FF97FF96FF9AFF9AFF98FF99FF9BFF9BFF98FF98FF9AFF9AFF9AFF9AFF9BFF9DFF9DFF9BFF9AFF9AFF9BFF9BFF9BFF99FF9BFF9DFF9BFF98FF99FF99FF95FF99FF9CFF9DFF9CFF9AFF98FF99FF9BFF9CFF9DFF9BFF9AFF9DFF9DFF9CFF9BFF9DFF9DFF9DFF9CFF9CFF9CFF9AFF9BFF9CFF9BFF9BFF9CFF9CFF9CFF9CFF9CFF9BFF9CFF9DFF9EFF9DFF9CFF9CFF9CFF9DFF9CFF9CFF9CFF9BFF9CFF9DFF9CFF9EFFA0FFA0FF9DFF9DFF9EFF9CFF9AFF9BFF9DFF9EFF9EFF9DFF9DFF9EFF9FFF9EFF9CFF9CFF9DFF9EFF9EFF9CFF9DFF9EFF9EFF9EFF9EFF9EFF9CFF9CFF9AFF9CFF9FFF9FFF9DFF9DFF9EFF9EFF9EFF9DFF9DFF9DFF9FFFA0FFA0FF9FFFA0FF9FFF9FFFA0FFA0FF9EFF9FFF9FFF9EFF9EFF9EFF9CFF9CFF9EFF9FFFA0FFA1FFA0FF9FFF9FFF9EFF9EFF9FFFA0FF9FFF9FFF9EFF9FFFA0FF9FFF9FFFA0FFA0FFA0FF9FFF9EFF9CFF9EFF9FFF9EFF9FFF9DFF9DFF9EFF9DFF9CFF9BFF9CFF9BFF9DFF9CFF9DFF9FFF9FFF9EFF9DFF9DFF9EFF9DFF9FFF9FFF9CFF9B')
SET IDENTITY_INSERT [dbo].[M_OutputRfSpectrum] OFF
GO
SET IDENTITY_INSERT [dbo].[M_RfInputStream] ON 

INSERT [dbo].[M_RfInputStream] ([id], [UnitId], [name], [bitRate], [dataSampleWidth], [destinationHost], [destinationPort], [frequencyOffset], [maximumPacketSize], [measuredNetworkRate], [measuredPacketRate], [minimumProcessingDelay], [packetOverhead], [pfecEnable], [routeSearch], [sourcePort], [streamBandwidth], [streamEnable], [streamGain], [streamId], [streamSampleRate]) VALUES (12, 2000, N'rfToNet0', CAST(473125000 AS Numeric(10, 0)), CAST(10 AS Numeric(5, 0)), N'192.168.201.10', CAST(50000 AS Numeric(5, 0)), -5000000, CAST(1500 AS Numeric(10, 0)), CAST(473131056 AS Numeric(20, 0)), CAST(39063 AS Numeric(10, 0)), 37600, 4.8877146631439938, 0, N'Found', CAST(50000 AS Numeric(5, 0)), CAST(20000000 AS Numeric(20, 0)), 1, 0, CAST(0 AS Numeric(10, 0)), 22500000)
INSERT [dbo].[M_RfInputStream] ([id], [UnitId], [name], [bitRate], [dataSampleWidth], [destinationHost], [destinationPort], [frequencyOffset], [maximumPacketSize], [measuredNetworkRate], [measuredPacketRate], [minimumProcessingDelay], [packetOverhead], [pfecEnable], [routeSearch], [sourcePort], [streamBandwidth], [streamEnable], [streamGain], [streamId], [streamSampleRate]) VALUES (13, 2100, N'rfToNet0', CAST(473125000 AS Numeric(10, 0)), CAST(10 AS Numeric(5, 0)), N'192.168.200.10', CAST(50000 AS Numeric(5, 0)), 0, CAST(1500 AS Numeric(10, 0)), CAST(473131056 AS Numeric(20, 0)), CAST(39063 AS Numeric(10, 0)), 37600, 4.8877146631439938, 0, N'Found', CAST(50000 AS Numeric(5, 0)), CAST(20000000 AS Numeric(20, 0)), 1, 0, CAST(0 AS Numeric(10, 0)), 22500000)
SET IDENTITY_INSERT [dbo].[M_RfInputStream] OFF
GO
SET IDENTITY_INSERT [dbo].[M_RfOutputStream] ON 

INSERT [dbo].[M_RfOutputStream] ([id], [UnitId], [name], [currentBuffer], [dataSampleWidth], [dataSource], [desiredBuffer], [desiredDelay], [destinationPort], [droppedPackets], [frequencyOffset], [gapCount], [measuredDelay], [measuredNetworkRate], [measuredPacketRate], [netStreamGain], [networkDelay], [packetOverhead], [pfecDecoderStatus], [pfecMissingSets], [pfecRepairedPackets], [pfecTotalPackets], [pfecUnrepairablePackets], [preserveLatency], [preserveLatencyLatePackets], [preserveLatencyMaxBurstLoss], [preserveLatencyMissingPackets], [preserveLatencyOutOfOrderPackets], [preserveLatencyReleaseMargin], [releaseMode], [sourceHost], [sourcePort], [streamBandwidth], [streamEnable], [streamId], [streamSampleRate], [underflowCount], [upstreamIrigLocked], [upstreamOnePpsLocked], [upstreamPathGain], [upstreamTenMhzLocked], [useLocalReference]) VALUES (1, 2100, N'netToRf0', 1919999.9999999998, CAST(10 AS Numeric(5, 0)), N'Network', CAST(10000000 AS Numeric(10, 0)), CAST(2000000 AS Numeric(10, 0)), CAST(50000 AS Numeric(5, 0)), CAST(0 AS Numeric(10, 0)), -5000000, CAST(4435 AS Numeric(10, 0)), CAST(2000007 AS Numeric(10, 0)), CAST(473131056 AS Numeric(20, 0)), CAST(39063 AS Numeric(10, 0)), 0, 44167.000000000044, 4.8877146631439938, N'bypass', CAST(0 AS Numeric(10, 0)), CAST(0 AS Numeric(10, 0)), CAST(0 AS Numeric(20, 0)), CAST(0 AS Numeric(10, 0)), 1, CAST(117923 AS Numeric(10, 0)), CAST(1000 AS Numeric(10, 0)), CAST(5920 AS Numeric(10, 0)), CAST(101411 AS Numeric(10, 0)), CAST(1000 AS Numeric(10, 0)), N'Programmed Delay', N'192.168.200.10', CAST(50000 AS Numeric(5, 0)), 20000000, 1, CAST(0 AS Numeric(10, 0)), 22500000, CAST(8645 AS Numeric(10, 0)), 0, 1, 10, 1, 1)
INSERT [dbo].[M_RfOutputStream] ([id], [UnitId], [name], [currentBuffer], [dataSampleWidth], [dataSource], [desiredBuffer], [desiredDelay], [destinationPort], [droppedPackets], [frequencyOffset], [gapCount], [measuredDelay], [measuredNetworkRate], [measuredPacketRate], [netStreamGain], [networkDelay], [packetOverhead], [pfecDecoderStatus], [pfecMissingSets], [pfecRepairedPackets], [pfecTotalPackets], [pfecUnrepairablePackets], [preserveLatency], [preserveLatencyLatePackets], [preserveLatencyMaxBurstLoss], [preserveLatencyMissingPackets], [preserveLatencyOutOfOrderPackets], [preserveLatencyReleaseMargin], [releaseMode], [sourceHost], [sourcePort], [streamBandwidth], [streamEnable], [streamId], [streamSampleRate], [underflowCount], [upstreamIrigLocked], [upstreamOnePpsLocked], [upstreamPathGain], [upstreamTenMhzLocked], [useLocalReference]) VALUES (2, 2000, N'netToRf0', 445696000, CAST(10 AS Numeric(5, 0)), N'Network', CAST(10000000 AS Numeric(10, 0)), CAST(2000000 AS Numeric(10, 0)), CAST(50000 AS Numeric(5, 0)), CAST(0 AS Numeric(10, 0)), 0, CAST(59549 AS Numeric(10, 0)), CAST(1002000004 AS Numeric(10, 0)), CAST(473131056 AS Numeric(20, 0)), CAST(39063 AS Numeric(10, 0)), 9, 556278404, 4.8877146631439938, N'bypass', CAST(0 AS Numeric(10, 0)), CAST(0 AS Numeric(10, 0)), CAST(0 AS Numeric(20, 0)), CAST(0 AS Numeric(10, 0)), 0, CAST(0 AS Numeric(10, 0)), CAST(1000 AS Numeric(10, 0)), CAST(0 AS Numeric(10, 0)), CAST(0 AS Numeric(10, 0)), CAST(1000 AS Numeric(10, 0)), N'Programmed Delay', N'192.168.201.10', CAST(50000 AS Numeric(5, 0)), 20000000, 1, CAST(0 AS Numeric(10, 0)), 22500000, CAST(9733 AS Numeric(10, 0)), 0, 1, 20, 1, 1)
SET IDENTITY_INSERT [dbo].[M_RfOutputStream] OFF
GO
SET IDENTITY_INSERT [dbo].[M_Routes] ON 

INSERT [dbo].[M_Routes] ([id], [UnitId], [destination], [gateway], [netmask]) VALUES (12, 2000, N'192.168.201.0', N'192.168.200.1', 24)
INSERT [dbo].[M_Routes] ([id], [UnitId], [destination], [gateway], [netmask]) VALUES (13, 2100, N'192.168.200.0', N'192.168.201.1', 24)
SET IDENTITY_INSERT [dbo].[M_Routes] OFF
GO
SET IDENTITY_INSERT [dbo].[M_SpectralNetGroups] ON 

INSERT [dbo].[M_SpectralNetGroups] ([id], [DateStamp], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Error], [ErrorText], [ReponseTime]) VALUES (97, CAST(N'2023-07-25T20:19:03.6526918' AS DateTime2), 2, N'WRW ANT2', 204, N'AUC-WRW RH2', N'Baseband', 2006, N'AUC-RH2A', N'WRW-RH2A', N'AUC-RH2B', N'AUC Chassis name', N'Auckland SAS', N'10.228.41.165', N'Primary', 7, 1, N'Call timed out: GET http://10.228.41.165/rest/spectralNet/_attribute?_dive=true', 2201)
INSERT [dbo].[M_SpectralNetGroups] ([id], [DateStamp], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Error], [ErrorText], [ReponseTime]) VALUES (87, CAST(N'2023-07-25T20:19:03.5153628' AS DateTime2), 2, N'WRW ANT2', 201, N'AUC-WRW LH1', N'Baseband', 2001, N'AUC-LH1B', N'WRW-LH1B', N'AUC-LH1A', N'AUC Chassis name', N'Auckland SAS', N'10.228.41.160', N'Secondary', 2, 1, N'Call timed out: GET http://10.228.41.160/rest/spectralNet/_attribute?_dive=true', 2136)
INSERT [dbo].[M_SpectralNetGroups] ([id], [DateStamp], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Error], [ErrorText], [ReponseTime]) VALUES (94, CAST(N'2023-07-25T20:19:03.4863854' AS DateTime2), 2, N'WRW ANT2', 202, N'AUC-WRW LH2', N'Baseband', 2002, N'AUC-LH2A', N'WRW-LH2A', N'AUC-LH2B', N'AUC Chassis name', N'Auckland SAS', N'10.228.41.161', N'Primary', 3, 1, N'Call timed out: GET http://10.228.41.161/rest/spectralNet/_attribute?_dive=true', 2061)
INSERT [dbo].[M_SpectralNetGroups] ([id], [DateStamp], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Error], [ErrorText], [ReponseTime]) VALUES (86, CAST(N'2023-07-25T20:19:03.7619478' AS DateTime2), 2, N'WRW ANT2', 203, N'AUC-WRW RH1', N'Baseband', 2005, N'AUC-RH1B', N'WRW-RH1B', N'AUC-RH1A', N'AUC Chassis name', N'Auckland SAS', N'10.228.41.164', N'Secondary', 6, 1, N'Call timed out: GET http://10.228.41.164/rest/spectralNet/_attribute?_dive=true', 2230)
INSERT [dbo].[M_SpectralNetGroups] ([id], [DateStamp], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Error], [ErrorText], [ReponseTime]) VALUES (96, CAST(N'2023-07-25T20:19:03.7316014' AS DateTime2), 2, N'WRW ANT2', 203, N'AUC-WRW RH1', N'Baseband', 2004, N'AUC-RH1A', N'WRW-RH1A', N'AUC-RH1B', N'AUC Chassis name', N'Auckland SAS', N'10.228.41.163', N'Primary', 5, 1, N'Call timed out: GET http://10.228.41.163/rest/spectralNet/_attribute?_dive=true', 2213)
INSERT [dbo].[M_SpectralNetGroups] ([id], [DateStamp], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Error], [ErrorText], [ReponseTime]) VALUES (99, CAST(N'2023-07-25T20:19:03.7951274' AS DateTime2), 2, N'WRW ANT2', 202, N'AUC-WRW LH2', N'Baseband', 2003, N'AUC-LH2B', N'WRW-LH2B', N'AUC-LH2A', N'AUC Chassis name', N'Auckland SAS', N'10.228.41.162', N'Secondary', 4, 1, N'Call timed out: GET http://10.228.41.162/rest/spectralNet/_attribute?_dive=true', 2311)
INSERT [dbo].[M_SpectralNetGroups] ([id], [DateStamp], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Error], [ErrorText], [ReponseTime]) VALUES (90, CAST(N'2023-07-25T20:19:06.1914825' AS DateTime2), 2, N'WRW ANT2', 204, N'AUC-WRW RH2', N'Antenna', 2106, N'WRW-RH2A', N'AUC-RH2A', N'WRW-RH2B', N'AUC Chassis name', N'Warkworth SAS', N'10.229.41.165', N'Primary', 57, 1, N'Call timed out: GET http://10.229.41.165/rest/spectralNet/_attribute?_dive=true', 2693)
INSERT [dbo].[M_SpectralNetGroups] ([id], [DateStamp], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Error], [ErrorText], [ReponseTime]) VALUES (95, CAST(N'2023-07-25T20:19:06.3305351' AS DateTime2), 2, N'WRW ANT2', 201, N'AUC-WRW LH1', N'Antenna', 2101, N'WRW-LH1B', N'AUC-LH1B', N'WRW-LH1A', N'AUC Chassis name', N'Warkworth SAS', N'10.229.41.160', N'Secondary', 52, 1, N'Call timed out: GET http://10.229.41.160/rest/spectralNet/_attribute?_dive=true', 2848)
INSERT [dbo].[M_SpectralNetGroups] ([id], [DateStamp], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Error], [ErrorText], [ReponseTime]) VALUES (88, CAST(N'2023-07-25T20:19:06.2293910' AS DateTime2), 2, N'WRW ANT2', 204, N'AUC-WRW RH2', N'Baseband', 2007, N'AUC-RH2B', N'WRW-RH2B', N'AUC-RH2A', N'AUC Chassis name', N'Auckland SAS', N'10.228.41.166', N'Secondary', 8, 1, N'Call timed out: GET http://10.228.41.166/rest/spectralNet/_attribute?_dive=true', 2779)
INSERT [dbo].[M_SpectralNetGroups] ([id], [DateStamp], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Error], [ErrorText], [ReponseTime]) VALUES (89, CAST(N'2023-07-25T20:19:06.0632686' AS DateTime2), 2, N'WRW ANT2', 203, N'AUC-WRW RH1', N'Antenna', 2104, N'WRW-RH1A', N'AUC-RH1A', N'WRW-RH1B', N'AUC Chassis name', N'Warkworth SAS', N'10.229.41.163', N'Primary', 55, 1, N'Call timed out: GET http://10.229.41.163/rest/spectralNet/_attribute?_dive=true', 2670)
INSERT [dbo].[M_SpectralNetGroups] ([id], [DateStamp], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Error], [ErrorText], [ReponseTime]) VALUES (92, CAST(N'2023-07-25T20:19:05.9498511' AS DateTime2), 2, N'WRW ANT2', 202, N'AUC-WRW LH2', N'Antenna', 2102, N'WRW-LH2A', N'AUC-LH2A', N'WRW-LH2B', N'AUC Chassis name', N'Warkworth SAS', N'10.229.41.161', N'Primary', 53, 1, N'Call timed out: GET http://10.229.41.161/rest/spectralNet/_attribute?_dive=true', 2523)
INSERT [dbo].[M_SpectralNetGroups] ([id], [DateStamp], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Error], [ErrorText], [ReponseTime]) VALUES (93, CAST(N'2023-07-25T20:19:06.1219860' AS DateTime2), 2, N'WRW ANT2', 203, N'AUC-WRW RH1', N'Antenna', 2105, N'WRW-RH1B', N'AUC-RH1B', N'WRW-RH1A', N'AUC Chassis name', N'Warkworth SAS', N'10.229.41.164', N'Secondary', 56, 1, N'Call timed out: GET http://10.229.41.164/rest/spectralNet/_attribute?_dive=true', 2670)
INSERT [dbo].[M_SpectralNetGroups] ([id], [DateStamp], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Error], [ErrorText], [ReponseTime]) VALUES (98, CAST(N'2023-07-25T20:19:06.2861894' AS DateTime2), 2, N'WRW ANT2', 202, N'AUC-WRW LH2', N'Antenna', 2103, N'WRW-LH2B', N'AUC-LH2B', N'WRW-LH2A', N'AUC Chassis name', N'Warkworth SAS', N'10.229.41.162', N'Secondary', 54, 1, N'Call timed out: GET http://10.229.41.162/rest/spectralNet/_attribute?_dive=true', 2848)
INSERT [dbo].[M_SpectralNetGroups] ([id], [DateStamp], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Error], [ErrorText], [ReponseTime]) VALUES (91, CAST(N'2023-07-25T20:19:06.0223370' AS DateTime2), 2, N'WRW ANT2', 204, N'AUC-WRW RH2', N'Antenna', 2107, N'WRW-RH2B', N'AUC-RH2B', N'WRW-RH2A', N'AUC Chassis name', N'Warkworth SAS', N'10.229.41.166', N'Secondary', 58, 1, N'Call timed out: GET http://10.229.41.166/rest/spectralNet/_attribute?_dive=true', 2658)
INSERT [dbo].[M_SpectralNetGroups] ([id], [DateStamp], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Error], [ErrorText], [ReponseTime]) VALUES (85, CAST(N'2023-07-25T20:19:05.6579627' AS DateTime2), 2, N'WRW ANT2', 201, N'AUC-WRW LH1', N'Antenna', 2100, N'WRW-LH1A', N'AUC-LH1A', N'WRW-LH1B', N'AUC Chassis name', N'Warkworth SAS', N'10.229.41.179', N'Primary', 51, 0, N'No error', 286)
INSERT [dbo].[M_SpectralNetGroups] ([id], [DateStamp], [ClusterID], [ClusterName], [GroupID], [GroupName], [Site], [UnitId], [UnitName], [RemoteUnit], [PeerUnit], [ChassisName], [Location], [IpAddress], [NetworkPath], [DisplayOrder], [Error], [ErrorText], [ReponseTime]) VALUES (84, CAST(N'2023-07-25T20:19:05.4964426' AS DateTime2), 2, N'WRW ANT2', 201, N'AUC-WRW LH1', N'Baseband', 2000, N'AUC-LH1A', N'WRW-LH1A', N'AUC-LH1B', N'AUC Chassis name', N'Auckland SAS', N'10.228.41.179', N'Primary', 1, 0, N'No error', 143)
SET IDENTITY_INSERT [dbo].[M_SpectralNetGroups] OFF
GO
USE [master]
GO
ALTER DATABASE [snnb_FO] SET  READ_WRITE 
GO

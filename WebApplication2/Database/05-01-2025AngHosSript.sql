USE [master]
GO
/****** Object:  Database [HostpitalManagement]    Script Date: 1/5/2025 9:46:00 AM ******/
CREATE DATABASE [HostpitalManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HostpitalManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\HostpitalManagement.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HostpitalManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\HostpitalManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HostpitalManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HostpitalManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HostpitalManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HostpitalManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HostpitalManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HostpitalManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HostpitalManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [HostpitalManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HostpitalManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HostpitalManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HostpitalManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HostpitalManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HostpitalManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HostpitalManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HostpitalManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HostpitalManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HostpitalManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HostpitalManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HostpitalManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HostpitalManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HostpitalManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HostpitalManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HostpitalManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HostpitalManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HostpitalManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HostpitalManagement] SET  MULTI_USER 
GO
ALTER DATABASE [HostpitalManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HostpitalManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HostpitalManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HostpitalManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HostpitalManagement] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HostpitalManagement]
GO
/****** Object:  Table [dbo].[tbl_Accounts]    Script Date: 1/5/2025 9:46:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Accounts](
	[AccId] [int] IDENTITY(1,1) NOT NULL,
	[Pid] [int] NULL,
	[Payment] [decimal](18, 2) NULL,
	[Discount] [int] NULL,
	[PamentMode] [varchar](50) NULL,
	[AfterDisCountPayment] [decimal](18, 2) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_tbl_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Doctor]    Script Date: 1/5/2025 9:46:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Doctor](
	[DocId] [int] IDENTITY(1,1) NOT NULL,
	[DoctorName] [varchar](50) NULL,
	[DoctorPwd] [varchar](50) NULL,
	[Qualification] [varchar](50) NULL,
	[Specialization] [varchar](50) NULL,
	[Experience] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
	[Aadhar] [varchar](50) NULL,
	[Fees] [decimal](18, 2) NULL,
	[AvailabilityDates] [varchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_tbl_Doctor] PRIMARY KEY CLUSTERED 
(
	[DocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Patient]    Script Date: 1/5/2025 9:46:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Patient](
	[PId] [int] NOT NULL,
	[Pname] [varchar](50) NULL,
	[Gender] [nchar](10) NULL,
	[Contact] [nchar](10) NULL,
	[Reason] [varchar](50) NULL,
	[Medication] [varchar](50) NULL,
	[DoctorId] [int] NULL,
	[Height] [varchar](50) NULL,
	[Weight] [varchar](50) NULL,
	[Diagnosis] [varchar](50) NULL,
	[temp] [varchar](50) NULL,
	[Sugar_BP] [varchar](50) NULL,
	[Advice] [varchar](800) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_tbl_Patient] PRIMARY KEY CLUSTERED 
(
	[PId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tble_Role]    Script Date: 1/5/2025 9:46:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tble_Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_tble_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tble_User]    Script Date: 1/5/2025 9:46:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tble_User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Role] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_tble_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tble_User] ON 

INSERT [dbo].[tble_User] ([UserId], [UserName], [Password], [Role], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (1, N'Debasis', N'Deba', 2, 1, CAST(N'2025-05-01 00:00:00.000' AS DateTime), 1, CAST(N'2025-05-01 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tble_User] OFF
USE [master]
GO
ALTER DATABASE [HostpitalManagement] SET  READ_WRITE 
GO

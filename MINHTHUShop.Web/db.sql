USE [master]
GO
/****** Object:  Database [MINHTHUShop]    Script Date: 06/05/2023 4:43:16 CH ******/
CREATE DATABASE [MINHTHUShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MINHTHUShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MINHTHUShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MINHTHUShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MINHTHUShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MINHTHUShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MINHTHUShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MINHTHUShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MINHTHUShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MINHTHUShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MINHTHUShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MINHTHUShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [MINHTHUShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MINHTHUShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MINHTHUShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MINHTHUShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MINHTHUShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MINHTHUShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MINHTHUShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MINHTHUShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MINHTHUShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MINHTHUShop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MINHTHUShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MINHTHUShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MINHTHUShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MINHTHUShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MINHTHUShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MINHTHUShop] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MINHTHUShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MINHTHUShop] SET RECOVERY FULL 
GO
ALTER DATABASE [MINHTHUShop] SET  MULTI_USER 
GO
ALTER DATABASE [MINHTHUShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MINHTHUShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MINHTHUShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MINHTHUShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MINHTHUShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MINHTHUShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MINHTHUShop', N'ON'
GO
ALTER DATABASE [MINHTHUShop] SET QUERY_STORE = OFF
GO
USE [MINHTHUShop]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationCustomerLogins]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationCustomerLogins](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[Tb_Customer_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.ApplicationCustomerLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationCustomerRoles]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationCustomerRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
	[IdentityRole_Id] [nvarchar](128) NULL,
	[Tb_Customer_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.ApplicationCustomerRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityRoles]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.IdentityRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityUserClaims]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[Tb_Customer_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.IdentityUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_About]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_About](
	[AboutID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [char](10) NOT NULL,
	[Email] [varchar](250) NULL,
	[Fanpage] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [bit] NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescriptions] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.Tb_About] PRIMARY KEY CLUSTERED 
(
	[AboutID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Banner]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Banner](
	[BannerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](250) NOT NULL,
	[Link] [nvarchar](250) NULL,
	[Sort] [int] NULL,
	[Position] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_dbo.Tb_Banner] PRIMARY KEY CLUSTERED 
(
	[BannerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Brand]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Brand](
	[BrandID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BrandOrigin] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Tb_Brand] PRIMARY KEY CLUSTERED 
(
	[BrandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Config]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Config](
	[ConfigID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ValueNum] [int] NULL,
	[ValueString] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_dbo.Tb_Config] PRIMARY KEY CLUSTERED 
(
	[ConfigID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Customer]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Customer](
	[Email] [nvarchar](max) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[Gender] [bit] NULL,
	[DateOfBirth] [datetime] NULL,
	[Avatar] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[IsLoggedIn] [bit] NULL,
	[LastLogin] [datetime] NULL,
	[Status] [bit] NULL,
	[Id] [nvarchar](128) NOT NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Tb_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Error]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Error](
	[ErrorID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[StackTrace] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Tb_Error] PRIMARY KEY CLUSTERED 
(
	[ErrorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_FAQ]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_FAQ](
	[FAQID] [int] IDENTITY(1,1) NOT NULL,
	[FAQCateID] [int] NOT NULL,
	[Question] [nvarchar](250) NOT NULL,
	[Answer] [nvarchar](max) NOT NULL,
	[Status] [bit] NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescriptions] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.Tb_FAQ] PRIMARY KEY CLUSTERED 
(
	[FAQID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_FAQCategory]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_FAQCategory](
	[FAQCateID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Sort] [int] NULL,
	[ParentID] [int] NULL,
 CONSTRAINT [PK_dbo.Tb_FAQCategory] PRIMARY KEY CLUSTERED 
(
	[FAQCateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Feedback]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Feedback](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [nvarchar](128) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[CreateDate] [datetime] NULL,
	[IsRead] [bit] NULL,
 CONSTRAINT [PK_dbo.Tb_Feedback] PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Menu]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Menu](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[MenuGroupID] [int] NOT NULL,
	[TargetID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Icon] [nvarchar](250) NULL,
	[Description] [nvarchar](250) NULL,
	[Link] [nvarchar](250) NOT NULL,
	[Sort] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_dbo.Tb_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_MenuGroup]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_MenuGroup](
	[MenuGroup] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Sort] [int] NULL,
 CONSTRAINT [PK_dbo.Tb_MenuGroup] PRIMARY KEY CLUSTERED 
(
	[MenuGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_News]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_News](
	[NewsID] [int] IDENTITY(1,1) NOT NULL,
	[NewsCateID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreateDate] [datetime] NULL,
	[Status] [bit] NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescriptions] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.Tb_News] PRIMARY KEY CLUSTERED 
(
	[NewsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_NewsCategory]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_NewsCategory](
	[NewsCateID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Sort] [int] NULL,
	[ParentID] [int] NULL,
 CONSTRAINT [PK_dbo.Tb_NewsCategory] PRIMARY KEY CLUSTERED 
(
	[NewsCateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Order]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [nvarchar](128) NOT NULL,
	[StaffID] [int] NOT NULL,
	[OrderStatusID] [int] NOT NULL,
	[ShippingMethodID] [int] NOT NULL,
	[PaymentMethodID] [int] NOT NULL,
	[Total] [decimal](18, 2) NULL,
	[CreateDate] [datetime] NULL,
	[Note] [nvarchar](max) NULL,
	[IsCancel] [bit] NULL,
 CONSTRAINT [PK_dbo.Tb_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_OrderDetail]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_OrderDetail](
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Tb_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_OrderStatus]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_OrderStatus](
	[OrderStatusID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Tb_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[OrderStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Page]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Page](
	[PageID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[URL] [nvarchar](250) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescriptions] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.Tb_Page] PRIMARY KEY CLUSTERED 
(
	[PageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Payment]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Payment](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentAmount] [decimal](18, 2) NULL,
	[IsPaid] [bit] NULL,
 CONSTRAINT [PK_dbo.Tb_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_PaymentMethod]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_PaymentMethod](
	[PaymentMethodID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_dbo.Tb_PaymentMethod] PRIMARY KEY CLUSTERED 
(
	[PaymentMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Product]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[CateID] [int] NOT NULL,
	[BrandID] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Image] [nvarchar](250) NULL,
	[ListImg] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[PromotionPrice] [decimal](18, 2) NULL,
	[Description] [nvarchar](500) NULL,
	[Detail] [nvarchar](max) NULL,
	[Status] [bit] NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescriptions] [nvarchar](500) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Tb_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_ProductCategory]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_ProductCategory](
	[CateID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Sort] [int] NULL,
	[ParentID] [int] NULL,
 CONSTRAINT [PK_dbo.Tb_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[CateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_ProductComment]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_ProductComment](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[CustomerID] [nvarchar](128) NOT NULL,
	[Vote] [real] NOT NULL,
	[Comment] [nvarchar](500) NOT NULL,
	[CreateDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_dbo.Tb_ProductComment] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_RoleStaff]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_RoleStaff](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Tb_RoleStaff] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Shipping]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Shipping](
	[ShippingID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ShippingDate] [datetime] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsShipping] [bit] NULL,
 CONSTRAINT [PK_dbo.Tb_Shipping] PRIMARY KEY CLUSTERED 
(
	[ShippingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_ShippingMethod]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_ShippingMethod](
	[ShippingMethodID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Cost] [decimal](18, 2) NOT NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_dbo.Tb_ShippingMethod] PRIMARY KEY CLUSTERED 
(
	[ShippingMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Staff]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Staff](
	[StaffID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [varchar](250) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [char](10) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[Gender] [bit] NULL,
	[DateOfBirth] [datetime] NULL,
	[Avatar] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[IsLoggedIn] [bit] NULL,
	[LastLogin] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_dbo.Tb_Staff] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Tag]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Tag](
	[TagID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Tb_Tag] PRIMARY KEY CLUSTERED 
(
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_TagNews]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_TagNews](
	[TagNewsID] [int] IDENTITY(1,1) NOT NULL,
	[TagID] [int] NOT NULL,
	[NewsID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Tb_TagNews] PRIMARY KEY CLUSTERED 
(
	[TagNewsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_TagProduct]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_TagProduct](
	[TagProductID] [int] IDENTITY(1,1) NOT NULL,
	[TagID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Tb_TagProduct] PRIMARY KEY CLUSTERED 
(
	[TagProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Target]    Script Date: 06/05/2023 4:43:17 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Target](
	[TargetID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Tb_Target] PRIMARY KEY CLUSTERED 
(
	[TargetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tb_Customer_Id]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_Tb_Customer_Id] ON [dbo].[ApplicationCustomerLogins]
(
	[Tb_Customer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_IdentityRole_Id]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_IdentityRole_Id] ON [dbo].[ApplicationCustomerRoles]
(
	[IdentityRole_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tb_Customer_Id]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_Tb_Customer_Id] ON [dbo].[ApplicationCustomerRoles]
(
	[Tb_Customer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tb_Customer_Id]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_Tb_Customer_Id] ON [dbo].[IdentityUserClaims]
(
	[Tb_Customer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FAQCateID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_FAQCateID] ON [dbo].[Tb_FAQ]
(
	[FAQCateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CustomerID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_CustomerID] ON [dbo].[Tb_Feedback]
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MenuGroupID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_MenuGroupID] ON [dbo].[Tb_Menu]
(
	[MenuGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TargetID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_TargetID] ON [dbo].[Tb_Menu]
(
	[TargetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NewsCateID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_NewsCateID] ON [dbo].[Tb_News]
(
	[NewsCateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CustomerID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_CustomerID] ON [dbo].[Tb_Order]
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderStatusID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_OrderStatusID] ON [dbo].[Tb_Order]
(
	[OrderStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PaymentMethodID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_PaymentMethodID] ON [dbo].[Tb_Order]
(
	[PaymentMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ShippingMethodID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_ShippingMethodID] ON [dbo].[Tb_Order]
(
	[ShippingMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_StaffID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_StaffID] ON [dbo].[Tb_Order]
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_OrderID] ON [dbo].[Tb_OrderDetail]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_ProductID] ON [dbo].[Tb_OrderDetail]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_OrderID] ON [dbo].[Tb_Payment]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BrandID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_BrandID] ON [dbo].[Tb_Product]
(
	[BrandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CateID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_CateID] ON [dbo].[Tb_Product]
(
	[CateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CustomerID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_CustomerID] ON [dbo].[Tb_ProductComment]
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_ProductID] ON [dbo].[Tb_ProductComment]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_OrderID] ON [dbo].[Tb_Shipping]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_RoleID] ON [dbo].[Tb_Staff]
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NewsID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_NewsID] ON [dbo].[Tb_TagNews]
(
	[NewsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TagID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_TagID] ON [dbo].[Tb_TagNews]
(
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_ProductID] ON [dbo].[Tb_TagProduct]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TagID]    Script Date: 06/05/2023 4:43:17 CH ******/
CREATE NONCLUSTERED INDEX [IX_TagID] ON [dbo].[Tb_TagProduct]
(
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tb_Customer] ADD  DEFAULT ('') FOR [Id]
GO
ALTER TABLE [dbo].[Tb_Customer] ADD  DEFAULT ((0)) FOR [EmailConfirmed]
GO
ALTER TABLE [dbo].[Tb_Customer] ADD  DEFAULT ((0)) FOR [PhoneNumberConfirmed]
GO
ALTER TABLE [dbo].[Tb_Customer] ADD  DEFAULT ((0)) FOR [TwoFactorEnabled]
GO
ALTER TABLE [dbo].[Tb_Customer] ADD  DEFAULT ((0)) FOR [LockoutEnabled]
GO
ALTER TABLE [dbo].[Tb_Customer] ADD  DEFAULT ((0)) FOR [AccessFailedCount]
GO
ALTER TABLE [dbo].[ApplicationCustomerLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserLogins_dbo.Tb_Customer_Tb_Customer_Id] FOREIGN KEY([Tb_Customer_Id])
REFERENCES [dbo].[Tb_Customer] ([Id])
GO
ALTER TABLE [dbo].[ApplicationCustomerLogins] CHECK CONSTRAINT [FK_dbo.IdentityUserLogins_dbo.Tb_Customer_Tb_Customer_Id]
GO
ALTER TABLE [dbo].[ApplicationCustomerRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserRoles_dbo.IdentityRoles_IdentityRole_Id] FOREIGN KEY([IdentityRole_Id])
REFERENCES [dbo].[IdentityRoles] ([Id])
GO
ALTER TABLE [dbo].[ApplicationCustomerRoles] CHECK CONSTRAINT [FK_dbo.IdentityUserRoles_dbo.IdentityRoles_IdentityRole_Id]
GO
ALTER TABLE [dbo].[ApplicationCustomerRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserRoles_dbo.Tb_Customer_Tb_Customer_Id] FOREIGN KEY([Tb_Customer_Id])
REFERENCES [dbo].[Tb_Customer] ([Id])
GO
ALTER TABLE [dbo].[ApplicationCustomerRoles] CHECK CONSTRAINT [FK_dbo.IdentityUserRoles_dbo.Tb_Customer_Tb_Customer_Id]
GO
ALTER TABLE [dbo].[IdentityUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserClaims_dbo.Tb_Customer_Tb_Customer_Id] FOREIGN KEY([Tb_Customer_Id])
REFERENCES [dbo].[Tb_Customer] ([Id])
GO
ALTER TABLE [dbo].[IdentityUserClaims] CHECK CONSTRAINT [FK_dbo.IdentityUserClaims_dbo.Tb_Customer_Tb_Customer_Id]
GO
ALTER TABLE [dbo].[Tb_FAQ]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_FAQ_dbo.Tb_FAQCategory_FAQCateID] FOREIGN KEY([FAQCateID])
REFERENCES [dbo].[Tb_FAQCategory] ([FAQCateID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_FAQ] CHECK CONSTRAINT [FK_dbo.Tb_FAQ_dbo.Tb_FAQCategory_FAQCateID]
GO
ALTER TABLE [dbo].[Tb_Feedback]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_Feedback_dbo.Tb_Customer_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Tb_Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_Feedback] CHECK CONSTRAINT [FK_dbo.Tb_Feedback_dbo.Tb_Customer_CustomerID]
GO
ALTER TABLE [dbo].[Tb_Menu]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_Menu_dbo.Tb_MenuGroup_MenuGroupID] FOREIGN KEY([MenuGroupID])
REFERENCES [dbo].[Tb_MenuGroup] ([MenuGroup])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_Menu] CHECK CONSTRAINT [FK_dbo.Tb_Menu_dbo.Tb_MenuGroup_MenuGroupID]
GO
ALTER TABLE [dbo].[Tb_Menu]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_Menu_dbo.Tb_Target_TargetID] FOREIGN KEY([TargetID])
REFERENCES [dbo].[Tb_Target] ([TargetID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_Menu] CHECK CONSTRAINT [FK_dbo.Tb_Menu_dbo.Tb_Target_TargetID]
GO
ALTER TABLE [dbo].[Tb_News]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_News_dbo.Tb_NewsCategory_NewsCateID] FOREIGN KEY([NewsCateID])
REFERENCES [dbo].[Tb_NewsCategory] ([NewsCateID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_News] CHECK CONSTRAINT [FK_dbo.Tb_News_dbo.Tb_NewsCategory_NewsCateID]
GO
ALTER TABLE [dbo].[Tb_Order]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_Order_dbo.Tb_Customer_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Tb_Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_Order] CHECK CONSTRAINT [FK_dbo.Tb_Order_dbo.Tb_Customer_CustomerID]
GO
ALTER TABLE [dbo].[Tb_Order]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_Order_dbo.Tb_OrderStatus_OrderStatusID] FOREIGN KEY([OrderStatusID])
REFERENCES [dbo].[Tb_OrderStatus] ([OrderStatusID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_Order] CHECK CONSTRAINT [FK_dbo.Tb_Order_dbo.Tb_OrderStatus_OrderStatusID]
GO
ALTER TABLE [dbo].[Tb_Order]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_Order_dbo.Tb_PaymentMethod_PaymentMethodID] FOREIGN KEY([PaymentMethodID])
REFERENCES [dbo].[Tb_PaymentMethod] ([PaymentMethodID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_Order] CHECK CONSTRAINT [FK_dbo.Tb_Order_dbo.Tb_PaymentMethod_PaymentMethodID]
GO
ALTER TABLE [dbo].[Tb_Order]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_Order_dbo.Tb_ShippingMethod_ShippingMethodID] FOREIGN KEY([ShippingMethodID])
REFERENCES [dbo].[Tb_ShippingMethod] ([ShippingMethodID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_Order] CHECK CONSTRAINT [FK_dbo.Tb_Order_dbo.Tb_ShippingMethod_ShippingMethodID]
GO
ALTER TABLE [dbo].[Tb_Order]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_Order_dbo.Tb_Staff_StaffID] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Tb_Staff] ([StaffID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_Order] CHECK CONSTRAINT [FK_dbo.Tb_Order_dbo.Tb_Staff_StaffID]
GO
ALTER TABLE [dbo].[Tb_OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_OrderDetail_dbo.Tb_Order_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Tb_Order] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_OrderDetail] CHECK CONSTRAINT [FK_dbo.Tb_OrderDetail_dbo.Tb_Order_OrderID]
GO
ALTER TABLE [dbo].[Tb_OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_OrderDetail_dbo.Tb_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Tb_Product] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_OrderDetail] CHECK CONSTRAINT [FK_dbo.Tb_OrderDetail_dbo.Tb_Product_ProductID]
GO
ALTER TABLE [dbo].[Tb_Payment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_Payment_dbo.Tb_Order_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Tb_Order] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_Payment] CHECK CONSTRAINT [FK_dbo.Tb_Payment_dbo.Tb_Order_OrderID]
GO
ALTER TABLE [dbo].[Tb_Product]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_Product_dbo.Tb_Brand_BrandID] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Tb_Brand] ([BrandID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_Product] CHECK CONSTRAINT [FK_dbo.Tb_Product_dbo.Tb_Brand_BrandID]
GO
ALTER TABLE [dbo].[Tb_Product]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_Product_dbo.Tb_ProductCategory_CateID] FOREIGN KEY([CateID])
REFERENCES [dbo].[Tb_ProductCategory] ([CateID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_Product] CHECK CONSTRAINT [FK_dbo.Tb_Product_dbo.Tb_ProductCategory_CateID]
GO
ALTER TABLE [dbo].[Tb_ProductComment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_ProductComment_dbo.Tb_Customer_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Tb_Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_ProductComment] CHECK CONSTRAINT [FK_dbo.Tb_ProductComment_dbo.Tb_Customer_CustomerID]
GO
ALTER TABLE [dbo].[Tb_ProductComment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_ProductComment_dbo.Tb_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Tb_Product] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_ProductComment] CHECK CONSTRAINT [FK_dbo.Tb_ProductComment_dbo.Tb_Product_ProductID]
GO
ALTER TABLE [dbo].[Tb_Shipping]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_Shipping_dbo.Tb_Order_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Tb_Order] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_Shipping] CHECK CONSTRAINT [FK_dbo.Tb_Shipping_dbo.Tb_Order_OrderID]
GO
ALTER TABLE [dbo].[Tb_Staff]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_Staff_dbo.Tb_Role_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Tb_RoleStaff] ([RoleID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_Staff] CHECK CONSTRAINT [FK_dbo.Tb_Staff_dbo.Tb_Role_RoleID]
GO
ALTER TABLE [dbo].[Tb_TagNews]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_TagNews_dbo.Tb_News_NewsID] FOREIGN KEY([NewsID])
REFERENCES [dbo].[Tb_News] ([NewsID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_TagNews] CHECK CONSTRAINT [FK_dbo.Tb_TagNews_dbo.Tb_News_NewsID]
GO
ALTER TABLE [dbo].[Tb_TagNews]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_TagNews_dbo.Tb_Tag_TagID] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tb_Tag] ([TagID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_TagNews] CHECK CONSTRAINT [FK_dbo.Tb_TagNews_dbo.Tb_Tag_TagID]
GO
ALTER TABLE [dbo].[Tb_TagProduct]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_TagProduct_dbo.Tb_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Tb_Product] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_TagProduct] CHECK CONSTRAINT [FK_dbo.Tb_TagProduct_dbo.Tb_Product_ProductID]
GO
ALTER TABLE [dbo].[Tb_TagProduct]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_TagProduct_dbo.Tb_Tag_TagID] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tb_Tag] ([TagID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_TagProduct] CHECK CONSTRAINT [FK_dbo.Tb_TagProduct_dbo.Tb_Tag_TagID]
GO
USE [master]
GO
ALTER DATABASE [MINHTHUShop] SET  READ_WRITE 
GO

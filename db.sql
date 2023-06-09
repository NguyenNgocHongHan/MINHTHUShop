USE [master]
GO
/****** Object:  Database [MINHTHUShop]    Script Date: 20/06/2023 9:41:00 CH ******/
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
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 20/06/2023 9:41:01 CH ******/
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
/****** Object:  Table [dbo].[Tb_Banner]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Banner](
	[BannerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](250) NOT NULL,
	[Link] [nvarchar](250) NOT NULL,
	[Sort] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Tb_Banner] PRIMARY KEY CLUSTERED 
(
	[BannerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Brand]    Script Date: 20/06/2023 9:41:01 CH ******/
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
/****** Object:  Table [dbo].[Tb_Error]    Script Date: 20/06/2023 9:41:01 CH ******/
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
/****** Object:  Table [dbo].[Tb_FAQ]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_FAQ](
	[FAQID] [int] IDENTITY(1,1) NOT NULL,
	[FAQCateID] [int] NOT NULL,
	[Question] [nvarchar](250) NOT NULL,
	[Answer] [nvarchar](max) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
	[MetaTitle] [nvarchar](250) NOT NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescriptions] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.Tb_FAQ] PRIMARY KEY CLUSTERED 
(
	[FAQID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_FAQCategory]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_FAQCategory](
	[FAQCateID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Sort] [int] NULL,
	[ParentID] [int] NULL,
	[MetaTitle] [nvarchar](250) NOT NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescriptions] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.Tb_FAQCategory] PRIMARY KEY CLUSTERED 
(
	[FAQCateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Feedback]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Feedback](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[IsRead] [bit] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Phone] [char](10) NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Tb_Feedback] PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Group]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Group](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Tb_Group] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Menu]    Script Date: 20/06/2023 9:41:01 CH ******/
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
/****** Object:  Table [dbo].[Tb_MenuGroup]    Script Date: 20/06/2023 9:41:01 CH ******/
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
/****** Object:  Table [dbo].[Tb_Order]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [nvarchar](128) NOT NULL,
	[OrderStatusID] [int] NOT NULL,
	[ShippingMethodID] [int] NOT NULL,
	[PaymentMethodID] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Note] [nvarchar](500) NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[CustomerAddress] [nvarchar](250) NOT NULL,
	[CustomerMobile] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Tb_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_OrderDetail]    Script Date: 20/06/2023 9:41:01 CH ******/
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
/****** Object:  Table [dbo].[Tb_OrderStatus]    Script Date: 20/06/2023 9:41:01 CH ******/
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
/****** Object:  Table [dbo].[Tb_PaymentMethod]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_PaymentMethod](
	[PaymentMethodID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Tb_PaymentMethod] PRIMARY KEY CLUSTERED 
(
	[PaymentMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Product]    Script Date: 20/06/2023 9:41:01 CH ******/
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
	[OriginalPrice] [decimal](18, 2) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[PromotionPrice] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Detail] [nvarchar](max) NULL,
	[Tag] [nvarchar](500) NULL,
	[CreateDate] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
	[MetaTitle] [nvarchar](250) NOT NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescriptions] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.Tb_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_ProductCategory]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_ProductCategory](
	[CateID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Sort] [int] NULL,
	[ParentID] [int] NULL,
	[MetaTitle] [nvarchar](250) NOT NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescriptions] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.Tb_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[CateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Role]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Role](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](250) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.Tb_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_RoleGroup]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_RoleGroup](
	[RoleID] [nvarchar](128) NOT NULL,
	[GroupID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Tb_RoleGroup] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_ShippingMethod]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_ShippingMethod](
	[ShippingMethodID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Cost] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Tb_ShippingMethod] PRIMARY KEY CLUSTERED 
(
	[ShippingMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Tag]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Tag](
	[TagID] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Tb_Tag] PRIMARY KEY CLUSTERED 
(
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_TagProduct]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_TagProduct](
	[ProductID] [int] NOT NULL,
	[TagID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Tb_TagProduct] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Target]    Script Date: 20/06/2023 9:41:01 CH ******/
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
/****** Object:  Table [dbo].[Tb_User]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_User](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[Gender] [bit] NULL,
	[DateOfBirth] [datetime] NULL,
	[Avatar] [nvarchar](250) NULL,
	[CreateDate] [datetime] NOT NULL,
	[IsLoggedIn] [bit] NULL,
	[LastLogin] [datetime] NULL,
	[Status] [bit] NOT NULL,
	[Email] [nvarchar](max) NULL,
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
 CONSTRAINT [PK_dbo.Tb_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_UserClaim]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_UserClaim](
	[UserId] [nvarchar](128) NOT NULL,
	[Id] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[Tb_User_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.Tb_UserClaim] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_UserGroup]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_UserGroup](
	[UserID] [nvarchar](128) NOT NULL,
	[GroupID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Tb_UserGroup] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_UserLogin]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_UserLogin](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[Tb_User_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.Tb_UserLogin] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_UserRole]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_UserRole](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
	[IdentityRole_Id] [nvarchar](128) NULL,
	[Tb_User_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.Tb_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Webpage]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Webpage](
	[PageID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateDate] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
	[MetaTitle] [nvarchar](250) NOT NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescriptions] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.Tb_Webpage] PRIMARY KEY CLUSTERED 
(
	[PageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_FAQCateID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_FAQCateID] ON [dbo].[Tb_FAQ]
(
	[FAQCateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MenuGroupID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_MenuGroupID] ON [dbo].[Tb_Menu]
(
	[MenuGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TargetID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_TargetID] ON [dbo].[Tb_Menu]
(
	[TargetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CustomerID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_CustomerID] ON [dbo].[Tb_Order]
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderStatusID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_OrderStatusID] ON [dbo].[Tb_Order]
(
	[OrderStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PaymentMethodID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_PaymentMethodID] ON [dbo].[Tb_Order]
(
	[PaymentMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ShippingMethodID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_ShippingMethodID] ON [dbo].[Tb_Order]
(
	[ShippingMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_OrderID] ON [dbo].[Tb_OrderDetail]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_ProductID] ON [dbo].[Tb_OrderDetail]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BrandID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_BrandID] ON [dbo].[Tb_Product]
(
	[BrandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CateID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_CateID] ON [dbo].[Tb_Product]
(
	[CateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_GroupID] ON [dbo].[Tb_RoleGroup]
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_RoleID] ON [dbo].[Tb_RoleGroup]
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_ProductID] ON [dbo].[Tb_TagProduct]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TagID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_TagID] ON [dbo].[Tb_TagProduct]
(
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tb_User_Id]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_Tb_User_Id] ON [dbo].[Tb_UserClaim]
(
	[Tb_User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_GroupID] ON [dbo].[Tb_UserGroup]
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserID]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_UserID] ON [dbo].[Tb_UserGroup]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tb_User_Id]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_Tb_User_Id] ON [dbo].[Tb_UserLogin]
(
	[Tb_User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_IdentityRole_Id]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_IdentityRole_Id] ON [dbo].[Tb_UserRole]
(
	[IdentityRole_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tb_User_Id]    Script Date: 20/06/2023 9:41:01 CH ******/
CREATE NONCLUSTERED INDEX [IX_Tb_User_Id] ON [dbo].[Tb_UserRole]
(
	[Tb_User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tb_Feedback] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Tb_Feedback] ADD  DEFAULT ('') FOR [Email]
GO
ALTER TABLE [dbo].[Tb_Feedback] ADD  DEFAULT ('') FOR [Phone]
GO
ALTER TABLE [dbo].[Tb_Order] ADD  DEFAULT ('') FOR [CustomerName]
GO
ALTER TABLE [dbo].[Tb_Order] ADD  DEFAULT ('') FOR [CustomerAddress]
GO
ALTER TABLE [dbo].[Tb_Order] ADD  DEFAULT ('') FOR [CustomerMobile]
GO
ALTER TABLE [dbo].[Tb_Role] ADD  DEFAULT ('') FOR [Discriminator]
GO
ALTER TABLE [dbo].[Tb_Webpage] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Tb_Webpage] ADD  DEFAULT ('') FOR [MetaTitle]
GO
ALTER TABLE [dbo].[Tb_FAQ]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_FAQ_dbo.Tb_FAQCategory_FAQCateID] FOREIGN KEY([FAQCateID])
REFERENCES [dbo].[Tb_FAQCategory] ([FAQCateID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_FAQ] CHECK CONSTRAINT [FK_dbo.Tb_FAQ_dbo.Tb_FAQCategory_FAQCateID]
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
ALTER TABLE [dbo].[Tb_Order]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_Order_dbo.Tb_Staff_StaffID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Tb_User] ([Id])
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
ALTER TABLE [dbo].[Tb_RoleGroup]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_RoleGroup_dbo.Tb_Group_GroupID] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Tb_Group] ([GroupID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_RoleGroup] CHECK CONSTRAINT [FK_dbo.Tb_RoleGroup_dbo.Tb_Group_GroupID]
GO
ALTER TABLE [dbo].[Tb_RoleGroup]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_RoleGroup_dbo.Tb_Role_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Tb_Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_RoleGroup] CHECK CONSTRAINT [FK_dbo.Tb_RoleGroup_dbo.Tb_Role_RoleID]
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
ALTER TABLE [dbo].[Tb_UserClaim]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_UserClaim_dbo.Tb_User_Tb_User_Id] FOREIGN KEY([Tb_User_Id])
REFERENCES [dbo].[Tb_User] ([Id])
GO
ALTER TABLE [dbo].[Tb_UserClaim] CHECK CONSTRAINT [FK_dbo.Tb_UserClaim_dbo.Tb_User_Tb_User_Id]
GO
ALTER TABLE [dbo].[Tb_UserGroup]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_UserGroup_dbo.Tb_Group_GroupID] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Tb_Group] ([GroupID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_UserGroup] CHECK CONSTRAINT [FK_dbo.Tb_UserGroup_dbo.Tb_Group_GroupID]
GO
ALTER TABLE [dbo].[Tb_UserGroup]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_UserGroup_dbo.Tb_User_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Tb_User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tb_UserGroup] CHECK CONSTRAINT [FK_dbo.Tb_UserGroup_dbo.Tb_User_UserID]
GO
ALTER TABLE [dbo].[Tb_UserLogin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tb_UserLogin_dbo.Tb_User_Tb_User_Id] FOREIGN KEY([Tb_User_Id])
REFERENCES [dbo].[Tb_User] ([Id])
GO
ALTER TABLE [dbo].[Tb_UserLogin] CHECK CONSTRAINT [FK_dbo.Tb_UserLogin_dbo.Tb_User_Tb_User_Id]
GO
ALTER TABLE [dbo].[Tb_UserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicationStaffRoles_dbo.ApplicationRoles_IdentityRole_Id] FOREIGN KEY([IdentityRole_Id])
REFERENCES [dbo].[Tb_Role] ([Id])
GO
ALTER TABLE [dbo].[Tb_UserRole] CHECK CONSTRAINT [FK_dbo.ApplicationStaffRoles_dbo.ApplicationRoles_IdentityRole_Id]
GO
ALTER TABLE [dbo].[Tb_UserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicationStaffRoles_dbo.Tb_Staff_Tb_Staff_Id] FOREIGN KEY([Tb_User_Id])
REFERENCES [dbo].[Tb_User] ([Id])
GO
ALTER TABLE [dbo].[Tb_UserRole] CHECK CONSTRAINT [FK_dbo.ApplicationStaffRoles_dbo.Tb_Staff_Tb_Staff_Id]
GO
/****** Object:  StoredProcedure [dbo].[GetRevenueStatistics]    Script Date: 20/06/2023 9:41:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRevenueStatistics]
    @fromDate [nvarchar](max),
    @toDate [nvarchar](max)
AS
BEGIN
    
    select
    	                    o.CreateDate as Date,
    sum(od.Quantity*p.PromotionPrice) as Revenues,
    sum((od.Quantity*p.PromotionPrice)-(od.Quantity*p.OriginalPrice)) as Benefit
    from Tb_Order o
    	                    inner join Tb_OrderDetail od
    on o.OrderID = od.OrderId
    inner join Tb_Product p
    on od.ProductID  = p.ProductID
    where o.CreateDate <= cast(@toDate as date) and o.CreateDate >= cast(@fromDate as date)
    group by o.CreateDate
    
END
GO
USE [master]
GO
ALTER DATABASE [MINHTHUShop] SET  READ_WRITE 
GO

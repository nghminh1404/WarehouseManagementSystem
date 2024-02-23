USE [master]
GO
/****** Object:  Database [WMS]    Script Date: 2/23/2024 8:55:21 PM ******/
CREATE DATABASE [WMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WMS', FILENAME = N'D:\SQL\MSSQL15.SQLEXPRESS\MSSQL\DATA\WMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WMS_log', FILENAME = N'D:\SQL\MSSQL15.SQLEXPRESS\MSSQL\DATA\WMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WMS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [WMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WMS] SET  MULTI_USER 
GO
ALTER DATABASE [WMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WMS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [WMS] SET QUERY_STORE = OFF
GO
USE [WMS]
GO
/****** Object:  Table [dbo].[ActionType]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionType](
	[ActionId] [int] NOT NULL,
	[Action] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_ActionType] PRIMARY KEY CLUSTERED 
(
	[ActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvailableForReturns]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvailableForReturns](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImportId] [int] NULL,
	[ExportId] [int] NULL,
	[GoodId] [int] NOT NULL,
	[Available] [int] NOT NULL,
 CONSTRAINT [PK_AvailableForReturns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[StorageId] [int] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailToken]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailToken](
	[TokenId] [int] IDENTITY(1,1) NOT NULL,
	[Token] [nvarchar](64) NOT NULL,
	[UserId] [int] NOT NULL,
	[IssuedAt] [datetime2](7) NOT NULL,
	[ExpiredAt] [datetime2](7) NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[IsRevoked] [bit] NOT NULL,
 CONSTRAINT [PK_EmailToken] PRIMARY KEY CLUSTERED 
(
	[TokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExportOrder]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExportOrder](
	[ExportId] [int] IDENTITY(1,1) NOT NULL,
	[ExportCode] [nvarchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[TotalAmount] [int] NOT NULL,
	[Total] [real] NOT NULL,
	[TotalPrice] [real] NOT NULL,
	[Note] [nvarchar](250) NULL,
	[State] [int] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Approved] [datetime2](7) NULL,
	[Completed] [datetime2](7) NULL,
	[Denied] [datetime2](7) NULL,
	[StorageId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_ExportOrder] PRIMARY KEY CLUSTERED 
(
	[ExportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExportOrderDetail]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExportOrderDetail](
	[DetailId] [int] IDENTITY(1,1) NOT NULL,
	[ExportId] [int] NOT NULL,
	[GoodId] [int] NOT NULL,
	[MeasuredUnitId] [int] NULL,
	[Amount] [int] NOT NULL,
	[Discount] [real] NOT NULL,
	[Price] [real] NOT NULL,
 CONSTRAINT [PK_ExportOrderDetail] PRIMARY KEY CLUSTERED 
(
	[DetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Good]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Good](
	[GoodId] [int] IDENTITY(1,1) NOT NULL,
	[GoodName] [nvarchar](100) NOT NULL,
	[GoodCode] [nvarchar](24) NULL,
	[CategoryId] [int] NOT NULL,
	[Description] [nvarchar](250) NULL,
	[SupplierId] [int] NOT NULL,
	[CostPrice] [real] NOT NULL,
	[SellingPrice] [real] NOT NULL,
	[DefaultMeasuredUnit] [nvarchar](100) NULL,
	[InStock] [int] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Status] [bit] NULL,
	[StockPrice] [real] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Barcode] [nvarchar](24) NULL,
	[StorageId] [int] NOT NULL,
	[MaxStock] [int] NULL,
	[MinStock] [int] NULL,
 CONSTRAINT [PK_Good] PRIMARY KEY CLUSTERED 
(
	[GoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GoodHistory]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GoodHistory](
	[HistoryId] [int] IDENTITY(1,1) NOT NULL,
	[GoodId] [int] NOT NULL,
	[ActionId] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[CostPrice] [real] NULL,
	[CostPriceDifferential] [nvarchar](50) NULL,
	[Price] [real] NULL,
	[PriceDifferential] [nvarchar](50) NULL,
	[Amount] [int] NULL,
	[AmountDifferential] [nvarchar](11) NULL,
	[Note] [nvarchar](250) NULL,
	[OrderCode] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
	[ActionCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_GoodHistory] PRIMARY KEY CLUSTERED 
(
	[HistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImportOrder]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportOrder](
	[ImportId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[SupplierId] [int] NOT NULL,
	[TotalAmount] [int] NOT NULL,
	[Total] [real] NOT NULL,
	[TotalCost] [real] NOT NULL,
	[Note] [nvarchar](250) NULL,
	[Created] [datetime2](7) NOT NULL,
	[Completed] [datetime2](7) NULL,
	[State] [int] NOT NULL,
	[ImportCode] [nvarchar](50) NOT NULL,
	[StorageId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_ImportOrder] PRIMARY KEY CLUSTERED 
(
	[ImportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImportOrderDetail]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportOrderDetail](
	[ImportId] [int] NOT NULL,
	[GoodId] [int] NOT NULL,
	[MeasuredUnitId] [int] NULL,
	[Amount] [int] NOT NULL,
	[CostPrice] [real] NOT NULL,
	[Discount] [real] NOT NULL,
	[DetailId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ImportOrderDetail] PRIMARY KEY CLUSTERED 
(
	[DetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeasuredUnit]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasuredUnit](
	[MeasuredUnitId] [int] IDENTITY(1,1) NOT NULL,
	[GoodId] [int] NOT NULL,
	[MeasuredUnitName] [nvarchar](100) NOT NULL,
	[MeasuredUnitValue] [int] NOT NULL,
	[SuggestedPrice] [real] NULL,
 CONSTRAINT [PK_MeasuredUnit] PRIMARY KEY CLUSTERED 
(
	[MeasuredUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectId] [int] NOT NULL,
	[ProjectName] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefreshToken]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefreshToken](
	[TokenId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Token] [nvarchar](44) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[ExpiredAt] [datetime2](7) NOT NULL,
	[IsRevoked] [bit] NOT NULL,
	[JwtId] [nvarchar](36) NOT NULL,
 CONSTRAINT [PK_RefreshToken] PRIMARY KEY CLUSTERED 
(
	[TokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReturnsOrder]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnsOrder](
	[ReturnsId] [int] IDENTITY(1,1) NOT NULL,
	[ImportId] [int] NULL,
	[ExportId] [int] NULL,
	[SupplierId] [int] NULL,
	[UserId] [int] NOT NULL,
	[Note] [nvarchar](250) NULL,
	[Media] [nvarchar](max) NULL,
	[Created] [datetime2](7) NOT NULL,
	[ReturnsCode] [nvarchar](50) NOT NULL,
	[StorageId] [int] NOT NULL,
	[Total] [real] NOT NULL,
	[State] [int] NOT NULL,
	[Imported] [datetime2](7) NULL,
 CONSTRAINT [PK_ReturnsOrder] PRIMARY KEY CLUSTERED 
(
	[ReturnsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReturnsOrderDetail]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnsOrderDetail](
	[DetailId] [int] IDENTITY(1,1) NOT NULL,
	[ReturnsId] [int] NOT NULL,
	[GoodId] [int] NOT NULL,
	[MeasuredUnitId] [int] NULL,
	[Price] [real] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_ReturnsOrderDetail] PRIMARY KEY CLUSTERED 
(
	[DetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StocktakeNote]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StocktakeNote](
	[StocktakeId] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Canceled] [datetime2](7) NULL,
	[Updated] [datetime2](7) NULL,
	[State] [int] NOT NULL,
	[UpdatedId] [int] NULL,
	[StorageId] [int] NOT NULL,
	[Note] [nvarchar](250) NULL,
	[CreatedId] [int] NOT NULL,
	[StocktakeCode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StocktakeNote] PRIMARY KEY CLUSTERED 
(
	[StocktakeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StocktakeNoteDetail]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StocktakeNoteDetail](
	[DetailId] [int] IDENTITY(1,1) NOT NULL,
	[StocktakeId] [int] NOT NULL,
	[GoodId] [int] NOT NULL,
	[CurrentStock] [int] NOT NULL,
	[ActualStock] [int] NOT NULL,
	[AmountDifferential] [int] NOT NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_StocktakeNoteDetail] PRIMARY KEY CLUSTERED 
(
	[DetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Storage]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storage](
	[StorageId] [int] IDENTITY(1,1) NOT NULL,
	[StorageName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Storage] PRIMARY KEY CLUSTERED 
(
	[StorageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](100) NOT NULL,
	[SupplierPhone] [nvarchar](15) NOT NULL,
	[Status] [bit] NOT NULL,
	[SupplierEmail] [nvarchar](62) NULL,
	[Note] [nvarchar](250) NULL,
	[StorageId] [int] NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/23/2024 8:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](62) NULL,
	[Password] [nvarchar](32) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[RoleId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[StorageId] [int] NOT NULL,
	[UserCode] [nvarchar](24) NULL,
	[Address] [nvarchar](250) NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT ((0)) FOR [StorageId]
GO
ALTER TABLE [dbo].[ExportOrder] ADD  CONSTRAINT [DF__ExportOrd__Stora__0E04126B]  DEFAULT ((0)) FOR [StorageId]
GO
ALTER TABLE [dbo].[ExportOrderDetail] ADD  DEFAULT (CONVERT([real],(0))) FOR [Discount]
GO
ALTER TABLE [dbo].[Good] ADD  DEFAULT (CONVERT([real],(0))) FOR [CostPrice]
GO
ALTER TABLE [dbo].[Good] ADD  DEFAULT (CONVERT([real],(0))) FOR [SellingPrice]
GO
ALTER TABLE [dbo].[Good] ADD  DEFAULT ((0)) FOR [InStock]
GO
ALTER TABLE [dbo].[Good] ADD  DEFAULT (CONVERT([real],(0))) FOR [StockPrice]
GO
ALTER TABLE [dbo].[Good] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Created]
GO
ALTER TABLE [dbo].[Good] ADD  DEFAULT ((0)) FOR [StorageId]
GO
ALTER TABLE [dbo].[GoodHistory] ADD  DEFAULT ((0)) FOR [UserId]
GO
ALTER TABLE [dbo].[ImportOrder] ADD  CONSTRAINT [DF__ImportOrd__Stora__11D4A34F]  DEFAULT ((0)) FOR [StorageId]
GO
ALTER TABLE [dbo].[ImportOrderDetail] ADD  DEFAULT (CONVERT([real],(0))) FOR [Discount]
GO
ALTER TABLE [dbo].[RefreshToken] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsRevoked]
GO
ALTER TABLE [dbo].[ReturnsOrder] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Created]
GO
ALTER TABLE [dbo].[ReturnsOrder] ADD  DEFAULT ((0)) FOR [StorageId]
GO
ALTER TABLE [dbo].[ReturnsOrder] ADD  DEFAULT (CONVERT([real],(0))) FOR [Total]
GO
ALTER TABLE [dbo].[ReturnsOrder] ADD  DEFAULT ((0)) FOR [State]
GO
ALTER TABLE [dbo].[ReturnsOrderDetail] ADD  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[StocktakeNote] ADD  DEFAULT ((0)) FOR [CreatedId]
GO
ALTER TABLE [dbo].[Supplier] ADD  DEFAULT ((0)) FOR [StorageId]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [RoleId]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Status]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [StorageId]
GO
ALTER TABLE [dbo].[AvailableForReturns]  WITH CHECK ADD  CONSTRAINT [FK_AvailableForReturns_ExportOrder_ExportId] FOREIGN KEY([ExportId])
REFERENCES [dbo].[ExportOrder] ([ExportId])
GO
ALTER TABLE [dbo].[AvailableForReturns] CHECK CONSTRAINT [FK_AvailableForReturns_ExportOrder_ExportId]
GO
ALTER TABLE [dbo].[AvailableForReturns]  WITH CHECK ADD  CONSTRAINT [FK_AvailableForReturns_Good_GoodId] FOREIGN KEY([GoodId])
REFERENCES [dbo].[Good] ([GoodId])
GO
ALTER TABLE [dbo].[AvailableForReturns] CHECK CONSTRAINT [FK_AvailableForReturns_Good_GoodId]
GO
ALTER TABLE [dbo].[AvailableForReturns]  WITH CHECK ADD  CONSTRAINT [FK_AvailableForReturns_ImportOrder_ImportId] FOREIGN KEY([ImportId])
REFERENCES [dbo].[ImportOrder] ([ImportId])
GO
ALTER TABLE [dbo].[AvailableForReturns] CHECK CONSTRAINT [FK_AvailableForReturns_ImportOrder_ImportId]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Storage_StorageId] FOREIGN KEY([StorageId])
REFERENCES [dbo].[Storage] ([StorageId])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Storage_StorageId]
GO
ALTER TABLE [dbo].[EmailToken]  WITH CHECK ADD  CONSTRAINT [FK_EmailToken_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmailToken] CHECK CONSTRAINT [FK_EmailToken_User_UserId]
GO
ALTER TABLE [dbo].[ExportOrder]  WITH CHECK ADD  CONSTRAINT [FK_ExportOrder_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[ExportOrder] CHECK CONSTRAINT [FK_ExportOrder_Project]
GO
ALTER TABLE [dbo].[ExportOrder]  WITH CHECK ADD  CONSTRAINT [FK_ExportOrder_Storage_StorageId] FOREIGN KEY([StorageId])
REFERENCES [dbo].[Storage] ([StorageId])
GO
ALTER TABLE [dbo].[ExportOrder] CHECK CONSTRAINT [FK_ExportOrder_Storage_StorageId]
GO
ALTER TABLE [dbo].[ExportOrder]  WITH CHECK ADD  CONSTRAINT [FK_ExportOrder_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExportOrder] CHECK CONSTRAINT [FK_ExportOrder_User_UserId]
GO
ALTER TABLE [dbo].[ExportOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_ExportOrderDetail_ExportOrder_ExportId] FOREIGN KEY([ExportId])
REFERENCES [dbo].[ExportOrder] ([ExportId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExportOrderDetail] CHECK CONSTRAINT [FK_ExportOrderDetail_ExportOrder_ExportId]
GO
ALTER TABLE [dbo].[ExportOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_ExportOrderDetail_Good_GoodId] FOREIGN KEY([GoodId])
REFERENCES [dbo].[Good] ([GoodId])
GO
ALTER TABLE [dbo].[ExportOrderDetail] CHECK CONSTRAINT [FK_ExportOrderDetail_Good_GoodId]
GO
ALTER TABLE [dbo].[ExportOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_ExportOrderDetail_MeasuredUnit_MeasuredUnitId] FOREIGN KEY([MeasuredUnitId])
REFERENCES [dbo].[MeasuredUnit] ([MeasuredUnitId])
GO
ALTER TABLE [dbo].[ExportOrderDetail] CHECK CONSTRAINT [FK_ExportOrderDetail_MeasuredUnit_MeasuredUnitId]
GO
ALTER TABLE [dbo].[Good]  WITH CHECK ADD  CONSTRAINT [FK_Good_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Good] CHECK CONSTRAINT [FK_Good_Category_CategoryId]
GO
ALTER TABLE [dbo].[Good]  WITH CHECK ADD  CONSTRAINT [FK_Good_Storage_StorageId] FOREIGN KEY([StorageId])
REFERENCES [dbo].[Storage] ([StorageId])
GO
ALTER TABLE [dbo].[Good] CHECK CONSTRAINT [FK_Good_Storage_StorageId]
GO
ALTER TABLE [dbo].[Good]  WITH CHECK ADD  CONSTRAINT [FK_Good_Supplier_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([SupplierId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Good] CHECK CONSTRAINT [FK_Good_Supplier_SupplierId]
GO
ALTER TABLE [dbo].[GoodHistory]  WITH CHECK ADD  CONSTRAINT [FK_GoodHistory_ActionType_ActionId] FOREIGN KEY([ActionId])
REFERENCES [dbo].[ActionType] ([ActionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GoodHistory] CHECK CONSTRAINT [FK_GoodHistory_ActionType_ActionId]
GO
ALTER TABLE [dbo].[GoodHistory]  WITH CHECK ADD  CONSTRAINT [FK_GoodHistory_Good_GoodId] FOREIGN KEY([GoodId])
REFERENCES [dbo].[Good] ([GoodId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GoodHistory] CHECK CONSTRAINT [FK_GoodHistory_Good_GoodId]
GO
ALTER TABLE [dbo].[GoodHistory]  WITH CHECK ADD  CONSTRAINT [FK_GoodHistory_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GoodHistory] CHECK CONSTRAINT [FK_GoodHistory_User_UserId]
GO
ALTER TABLE [dbo].[ImportOrder]  WITH CHECK ADD  CONSTRAINT [FK_ImportOrder_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[ImportOrder] CHECK CONSTRAINT [FK_ImportOrder_Project]
GO
ALTER TABLE [dbo].[ImportOrder]  WITH CHECK ADD  CONSTRAINT [FK_ImportOrder_Storage_StorageId] FOREIGN KEY([StorageId])
REFERENCES [dbo].[Storage] ([StorageId])
GO
ALTER TABLE [dbo].[ImportOrder] CHECK CONSTRAINT [FK_ImportOrder_Storage_StorageId]
GO
ALTER TABLE [dbo].[ImportOrder]  WITH CHECK ADD  CONSTRAINT [FK_ImportOrder_Supplier_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([SupplierId])
GO
ALTER TABLE [dbo].[ImportOrder] CHECK CONSTRAINT [FK_ImportOrder_Supplier_SupplierId]
GO
ALTER TABLE [dbo].[ImportOrder]  WITH CHECK ADD  CONSTRAINT [FK_ImportOrder_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImportOrder] CHECK CONSTRAINT [FK_ImportOrder_User_UserId]
GO
ALTER TABLE [dbo].[ImportOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_ImportOrderDetail_Good_GoodId] FOREIGN KEY([GoodId])
REFERENCES [dbo].[Good] ([GoodId])
GO
ALTER TABLE [dbo].[ImportOrderDetail] CHECK CONSTRAINT [FK_ImportOrderDetail_Good_GoodId]
GO
ALTER TABLE [dbo].[ImportOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_ImportOrderDetail_ImportOrder_ImportId] FOREIGN KEY([ImportId])
REFERENCES [dbo].[ImportOrder] ([ImportId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImportOrderDetail] CHECK CONSTRAINT [FK_ImportOrderDetail_ImportOrder_ImportId]
GO
ALTER TABLE [dbo].[ImportOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_ImportOrderDetail_MeasuredUnit_MeasuredUnitId] FOREIGN KEY([MeasuredUnitId])
REFERENCES [dbo].[MeasuredUnit] ([MeasuredUnitId])
GO
ALTER TABLE [dbo].[ImportOrderDetail] CHECK CONSTRAINT [FK_ImportOrderDetail_MeasuredUnit_MeasuredUnitId]
GO
ALTER TABLE [dbo].[MeasuredUnit]  WITH CHECK ADD  CONSTRAINT [FK_MeasuredUnit_Good_GoodId] FOREIGN KEY([GoodId])
REFERENCES [dbo].[Good] ([GoodId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MeasuredUnit] CHECK CONSTRAINT [FK_MeasuredUnit_Good_GoodId]
GO
ALTER TABLE [dbo].[RefreshToken]  WITH CHECK ADD  CONSTRAINT [FK_RefreshToken_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RefreshToken] CHECK CONSTRAINT [FK_RefreshToken_User_UserId]
GO
ALTER TABLE [dbo].[ReturnsOrder]  WITH CHECK ADD  CONSTRAINT [FK_ReturnsOrder_ExportOrder_ExportId] FOREIGN KEY([ExportId])
REFERENCES [dbo].[ExportOrder] ([ExportId])
GO
ALTER TABLE [dbo].[ReturnsOrder] CHECK CONSTRAINT [FK_ReturnsOrder_ExportOrder_ExportId]
GO
ALTER TABLE [dbo].[ReturnsOrder]  WITH CHECK ADD  CONSTRAINT [FK_ReturnsOrder_ImportOrder_ImportId] FOREIGN KEY([ImportId])
REFERENCES [dbo].[ImportOrder] ([ImportId])
GO
ALTER TABLE [dbo].[ReturnsOrder] CHECK CONSTRAINT [FK_ReturnsOrder_ImportOrder_ImportId]
GO
ALTER TABLE [dbo].[ReturnsOrder]  WITH CHECK ADD  CONSTRAINT [FK_ReturnsOrder_Storage_StorageId] FOREIGN KEY([StorageId])
REFERENCES [dbo].[Storage] ([StorageId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReturnsOrder] CHECK CONSTRAINT [FK_ReturnsOrder_Storage_StorageId]
GO
ALTER TABLE [dbo].[ReturnsOrder]  WITH CHECK ADD  CONSTRAINT [FK_ReturnsOrder_Supplier_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([SupplierId])
GO
ALTER TABLE [dbo].[ReturnsOrder] CHECK CONSTRAINT [FK_ReturnsOrder_Supplier_SupplierId]
GO
ALTER TABLE [dbo].[ReturnsOrder]  WITH CHECK ADD  CONSTRAINT [FK_ReturnsOrder_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReturnsOrder] CHECK CONSTRAINT [FK_ReturnsOrder_User_UserId]
GO
ALTER TABLE [dbo].[ReturnsOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_ReturnsOrderDetail_Good_GoodId] FOREIGN KEY([GoodId])
REFERENCES [dbo].[Good] ([GoodId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReturnsOrderDetail] CHECK CONSTRAINT [FK_ReturnsOrderDetail_Good_GoodId]
GO
ALTER TABLE [dbo].[ReturnsOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_ReturnsOrderDetail_MeasuredUnit_MeasuredUnitId] FOREIGN KEY([MeasuredUnitId])
REFERENCES [dbo].[MeasuredUnit] ([MeasuredUnitId])
GO
ALTER TABLE [dbo].[ReturnsOrderDetail] CHECK CONSTRAINT [FK_ReturnsOrderDetail_MeasuredUnit_MeasuredUnitId]
GO
ALTER TABLE [dbo].[ReturnsOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_ReturnsOrderDetail_ReturnsOrder_ReturnsId] FOREIGN KEY([ReturnsId])
REFERENCES [dbo].[ReturnsOrder] ([ReturnsId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReturnsOrderDetail] CHECK CONSTRAINT [FK_ReturnsOrderDetail_ReturnsOrder_ReturnsId]
GO
ALTER TABLE [dbo].[StocktakeNote]  WITH CHECK ADD  CONSTRAINT [FK_StocktakeNote_Storage_StorageId] FOREIGN KEY([StorageId])
REFERENCES [dbo].[Storage] ([StorageId])
GO
ALTER TABLE [dbo].[StocktakeNote] CHECK CONSTRAINT [FK_StocktakeNote_Storage_StorageId]
GO
ALTER TABLE [dbo].[StocktakeNote]  WITH CHECK ADD  CONSTRAINT [FK_StocktakeNote_User_CreatedId] FOREIGN KEY([CreatedId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StocktakeNote] CHECK CONSTRAINT [FK_StocktakeNote_User_CreatedId]
GO
ALTER TABLE [dbo].[StocktakeNote]  WITH CHECK ADD  CONSTRAINT [FK_StocktakeNote_User_UpdatedId] FOREIGN KEY([UpdatedId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[StocktakeNote] CHECK CONSTRAINT [FK_StocktakeNote_User_UpdatedId]
GO
ALTER TABLE [dbo].[StocktakeNoteDetail]  WITH CHECK ADD  CONSTRAINT [FK_StocktakeNoteDetail_Good_GoodId] FOREIGN KEY([GoodId])
REFERENCES [dbo].[Good] ([GoodId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StocktakeNoteDetail] CHECK CONSTRAINT [FK_StocktakeNoteDetail_Good_GoodId]
GO
ALTER TABLE [dbo].[StocktakeNoteDetail]  WITH CHECK ADD  CONSTRAINT [FK_StocktakeNoteDetail_StocktakeNote_StocktakeId] FOREIGN KEY([StocktakeId])
REFERENCES [dbo].[StocktakeNote] ([StocktakeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StocktakeNoteDetail] CHECK CONSTRAINT [FK_StocktakeNoteDetail_StocktakeNote_StocktakeId]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_Storage_StorageId] FOREIGN KEY([StorageId])
REFERENCES [dbo].[Storage] ([StorageId])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_Supplier_Storage_StorageId]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role_RoleId]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Storage_StorageId] FOREIGN KEY([StorageId])
REFERENCES [dbo].[Storage] ([StorageId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Storage_StorageId]
GO
USE [master]
GO
ALTER DATABASE [WMS] SET  READ_WRITE 
GO

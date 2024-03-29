USE [WarehouseManagement]
GO
/****** Object:  Table [dbo].[ActionType]    Script Date: 3/12/2024 1:34:00 PM ******/
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
/****** Object:  Table [dbo].[AvailableForReturns]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvailableForReturns](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImportId] [int] NULL,
	[ExportId] [int] NULL,
	[GoodsId] [int] NOT NULL,
	[Available] [int] NOT NULL,
 CONSTRAINT [PK_AvailableForReturns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[DeliveyId] [int] IDENTITY(1,1) NOT NULL,
	[DeliveryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED 
(
	[DeliveyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailToken]    Script Date: 3/12/2024 1:34:00 PM ******/
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
/****** Object:  Table [dbo].[ExportOrder]    Script Date: 3/12/2024 1:34:00 PM ******/
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
	[StatusId] [int] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Completed] [datetime2](7) NULL,
	[StorageId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Denied] [datetime2](7) NULL,
 CONSTRAINT [PK_ExportOrder] PRIMARY KEY CLUSTERED 
(
	[ExportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExportOrderDetail]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExportOrderDetail](
	[DetailId] [int] IDENTITY(1,1) NOT NULL,
	[ExportId] [int] NOT NULL,
	[Price] [real] NOT NULL,
	[LoadsId] [int] NULL,
	[TotalAmount] [int] NULL,
	[image] [nvarchar](max) NULL,
 CONSTRAINT [PK_ExportOrderDetail] PRIMARY KEY CLUSTERED 
(
	[DetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Features]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Features](
	[featureId] [int] IDENTITY(1,1) NOT NULL,
	[featurename] [nvarchar](50) NOT NULL,
	[url] [nvarchar](max) NULL,
 CONSTRAINT [PK_Features] PRIMARY KEY CLUSTERED 
(
	[featureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Goods]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goods](
	[GoodsId] [int] IDENTITY(1,1) NOT NULL,
	[GoodsName] [nvarchar](100) NOT NULL,
	[GoodsCode] [nvarchar](24) NULL,
	[CategoryId] [int] NOT NULL,
	[Description] [nvarchar](250) NULL,
	[SupplierId] [int] NOT NULL,
	[CostPrice] [real] NOT NULL,
	[DefaultMeasuredUnit] [nvarchar](100) NULL,
	[InStock] [int] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[StatusId] [int] NULL,
	[StockPrice] [real] NOT NULL,
	[WarrantyTime] [datetime2](7) NOT NULL,
	[Barcode] [nvarchar](24) NULL,
	[StorageId] [int] NOT NULL,
	[MaxStock] [int] NULL,
	[MinStock] [int] NULL,
 CONSTRAINT [PK_Goods] PRIMARY KEY CLUSTERED 
(
	[GoodsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GoodsHistory]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GoodsHistory](
	[HistoryId] [int] IDENTITY(1,1) NOT NULL,
	[GoodsId] [int] NOT NULL,
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
 CONSTRAINT [PK_GoodsHistory] PRIMARY KEY CLUSTERED 
(
	[HistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImportOrder]    Script Date: 3/12/2024 1:34:00 PM ******/
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
	[StatusId] [int] NOT NULL,
	[ImportCode] [nvarchar](50) NOT NULL,
	[StorageId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_ImportOrder] PRIMARY KEY CLUSTERED 
(
	[ImportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImportOrderDetail]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportOrderDetail](
	[ImportId] [int] NOT NULL,
	[CostPrice] [real] NOT NULL,
	[DetailId] [int] IDENTITY(1,1) NOT NULL,
	[LoadsId] [int] NULL,
	[TotalAmount] [int] NULL,
	[imagee] [nvarchar](max) NULL,
 CONSTRAINT [PK_ImportOrderDetail] PRIMARY KEY CLUSTERED 
(
	[DetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loads]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loads](
	[LoadsId] [int] IDENTITY(1,1) NOT NULL,
	[LoadsCode] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
	[StorageId] [int] NOT NULL,
	[image] [nvarchar](100) NULL,
	[statusId] [int] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[DeliveryDate] [datetime2](7) NULL,
	[DeliveryId] [int] NULL,
	[isPaid] [int] NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_Loads] PRIMARY KEY CLUSTERED 
(
	[LoadsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoadsGoods]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoadsGoods](
	[LoadsId] [int] NOT NULL,
	[GoodsId] [int] NOT NULL,
 CONSTRAINT [PK_LoadsGoods] PRIMARY KEY CLUSTERED 
(
	[LoadsId] ASC,
	[GoodsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeasuredUnit]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasuredUnit](
	[MeasuredUnitId] [int] IDENTITY(1,1) NOT NULL,
	[GoodsId] [int] NOT NULL,
	[MeasuredUnitName] [nvarchar](100) NOT NULL,
	[MeasuredUnitValue] [int] NOT NULL,
	[SuggestedPrice] [real] NULL,
 CONSTRAINT [PK_MeasuredUnit] PRIMARY KEY CLUSTERED 
(
	[MeasuredUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 3/12/2024 1:34:00 PM ******/
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
/****** Object:  Table [dbo].[RefreshToken]    Script Date: 3/12/2024 1:34:00 PM ******/
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
/****** Object:  Table [dbo].[ReturnsOrder]    Script Date: 3/12/2024 1:34:00 PM ******/
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
	[image] [nvarchar](max) NULL,
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
/****** Object:  Table [dbo].[ReturnsOrderDetail]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnsOrderDetail](
	[DetailId] [int] IDENTITY(1,1) NOT NULL,
	[ReturnsId] [int] NOT NULL,
	[GoodsId] [int] NOT NULL,
	[MeasuredUnitId] [int] NULL,
	[Price] [real] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_ReturnsOrderDetail] PRIMARY KEY CLUSTERED 
(
	[DetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleFeature]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleFeature](
	[roleId] [int] NOT NULL,
	[featureId] [int] NOT NULL,
 CONSTRAINT [PK_RoleFeature] PRIMARY KEY CLUSTERED 
(
	[roleId] ASC,
	[featureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StocktakeNote]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StocktakeNote](
	[StocktakeId] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Canceled] [datetime2](7) NULL,
	[Updated] [datetime2](7) NULL,
	[StatusId] [int] NOT NULL,
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
/****** Object:  Table [dbo].[StocktakeNoteDetail]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StocktakeNoteDetail](
	[DetailId] [int] IDENTITY(1,1) NOT NULL,
	[StocktakeId] [int] NOT NULL,
	[GoodsId] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Storage]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storage](
	[StorageId] [int] IDENTITY(1,1) NOT NULL,
	[StorageName] [nvarchar](100) NOT NULL,
	[StorageAddress] [nvarchar](100) NULL,
	[StoragePhone] [varchar](20) NULL,
 CONSTRAINT [PK_Storage] PRIMARY KEY CLUSTERED 
(
	[StorageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 3/12/2024 1:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](100) NOT NULL,
	[SupplierPhone] [nvarchar](15) NOT NULL,
	[StatusId] [int] NOT NULL,
	[SupplierEmail] [nvarchar](62) NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/12/2024 1:34:00 PM ******/
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
	[StatusId] [int] NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[StorageId] [int] NOT NULL,
	[UserCode] [nvarchar](24) NULL,
	[Address] [nvarchar](250) NULL,
	[Image] [nvarchar](max) NULL,
	[FullName] [nvarchar](100) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[ActionType] ([ActionId], [Action], [Description]) VALUES (1, N'Nhập hàng', NULL)
INSERT [dbo].[ActionType] ([ActionId], [Action], [Description]) VALUES (2, N'Xuất hàng', NULL)
INSERT [dbo].[ActionType] ([ActionId], [Action], [Description]) VALUES (3, N'Sửa hàng', NULL)
INSERT [dbo].[ActionType] ([ActionId], [Action], [Description]) VALUES (4, N'Khởi tạo', NULL)
INSERT [dbo].[ActionType] ([ActionId], [Action], [Description]) VALUES (5, N'Kiểm hàng', NULL)
INSERT [dbo].[ActionType] ([ActionId], [Action], [Description]) VALUES (6, N'Trả hàng', NULL)
INSERT [dbo].[ActionType] ([ActionId], [Action], [Description]) VALUES (7, N'Nhập hàng trả', NULL)
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (1, N'Điện thoại di động', N'Danh mục chứa các điện thoại di động và smartphone của các hãng nổi tiếng như Apple, Samsung, Xiaomi, và Oppo.')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (2, N'Máy tính xách tay', N'Danh mục chứa các máy tính xách tay với nhiều dòng sản phẩm từ các nhà sản xuất như Dell, HP, Lenovo, và Asus.')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (3, N'Tivi', N'Danh mục chứa các sản phẩm tivi với các công nghệ hiển thị như LED, OLED, và QLED, và các kích thước màn hình từ 32 inch đến 75 inch.')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (4, N'Máy ảnh', N'Danh mục chứa các máy ảnh kỹ thuật số DSLR và mirrorless từ các thương hiệu nổi tiếng như Canon, Nikon, Sony, và Fujifilm.')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (5, N'Máy tính bảng', N'Danh mục chứa các máy tính bảng với hệ điều hành Android và iOS từ các nhà sản xuất như Samsung, Apple, Lenovo, và Huawei.')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (6, N'Âm thanh', N'Danh mục chứa các sản phẩm âm thanh như tai nghe, loa di động, và hệ thống âm thanh gia đình từ các thương hiệu như Bose, Sony, JBL, và Harman Kardon.')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (7, N'Đồ điện tử gia dụng', N'Danh mục chứa các sản phẩm điện tử gia dụng như máy giặt, tủ lạnh, máy lọc không khí, và máy hút bụi từ các nhà sản xuất như Samsung, LG, Panasonic, và Electrolux.')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (8, N'Linh kiện điện tử', N'Danh mục chứa các linh kiện điện tử như vi xử lý, bộ nhớ, bo mạch chủ, và card đồ họa từ các nhà sản xuất như Intel, AMD, Corsair, và NVIDIA.')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (9, N'Máy chơi game', N'Danh mục chứa các máy chơi game như PlayStation, Xbox, Nintendo Switch, và máy tính chơi game cá nhân (PC Gaming).')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (10, N'Đồng hồ thông minh', N'Danh mục chứa các đồng hồ thông minh từ các thương hiệu như Apple Watch, Samsung Galaxy Watch, Fitbit, và Xiaomi Mi Watch.')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Administrator')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Project Manager')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (3, N'Storekeeper')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (4, N'Accountant')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([StatusId], [StatusType]) VALUES (1, N'Active')
INSERT [dbo].[Status] ([StatusId], [StatusType]) VALUES (2, N'Inactive')
INSERT [dbo].[Status] ([StatusId], [StatusType]) VALUES (3, N'On Progress')
INSERT [dbo].[Status] ([StatusId], [StatusType]) VALUES (4, N'Completed')
INSERT [dbo].[Status] ([StatusId], [StatusType]) VALUES (5, N'Cancel')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Storage] ON 

INSERT [dbo].[Storage] ([StorageId], [StorageName], [StorageAddress], [StoragePhone]) VALUES (1, N'Hải Phòng', N'Thành phố Hải Phòng', N'0369999999')
INSERT [dbo].[Storage] ([StorageId], [StorageName], [StorageAddress], [StoragePhone]) VALUES (2, N'Hà Nội', N'Thành phố Hà Nội', N'0369999999')
SET IDENTITY_INSERT [dbo].[Storage] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (2, N'Logitech', N'0123456789', 1, N'logitech@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (3, N'Samsung', N'0987654321', 2, N'samsung@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (4, N'Crystal-Optech Co., Ltd', N'0912345678', 1, N'crystaloptech@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (5, N'Delta Electronics Incorporated', N'0123456789', 1, N'deltaelectronics@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (6, N'Arist Benefex', N'0987654321', 1, N'aristbenefex@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (7, N'BrightHR', N'0912345678', 1, N'brighthr@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (8, N'Engagedly Inc.', N'0123456789', 1, N'engagedly@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (9, N'EY Skills Foundry', N'0987654321', 1, N'eyskillsfoundry@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (10, N'Fama Technologies, Inc.', N'0912345678', 1, N'famatechnologies@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (11, N'Firstup', N'0123456789', 1, N'firstup@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (12, N'Gloat', N'0987654321', 1, N'gloat@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (13, N'Harkn', N'0912345678', 1, N'harkn@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (14, N'HiBob', N'0123456789', 1, N'hibob@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (15, N'hireEZ', N'0987654321', 1, N'hireez@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (16, N'Mindr', N'0912345678', 1, N'mindr@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (17, N'Mineral', N'0123456789', 1, N'mineral@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (18, N'Pathstream', N'0987654321', 1, N'pathstream@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (19, N'Performica', N'0912345678', 1, N'performica@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (20, N'Plum', N'0123456789', 1, N'plum@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (21, N'Quantive', N'0987654321', 1, N'quantive@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (22, N'Quantum Workplace', N'0912345678', 1, N'quantumworkplace@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (23, N'ServiceNow', N'0123456789', 1, N'servicenow@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (24, N'SkillCycle', N'0987654321', 1, N'skillcycle@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (25, N'Virgin Pulse', N'0912345678', 1, N'virginpulse@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (26, N'When I Work', N'0123456789', 1, N'wheniwork@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (27, N'WorkJam', N'0987654321', 1, N'workjam@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (28, N'Worksome', N'0912345678', 1, N'worksome@example.com', NULL)
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [SupplierPhone], [StatusId], [SupplierEmail], [Note]) VALUES (29, N'WorkTango', N'0123456789', 1, N'worktango@example.com', NULL)
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
ALTER TABLE [dbo].[ExportOrder] ADD  CONSTRAINT [DF__ExportOrd__Stora__0E04126B]  DEFAULT ((0)) FOR [StorageId]
GO
ALTER TABLE [dbo].[Goods] ADD  CONSTRAINT [DF__Goods__CostPrice__5165187F]  DEFAULT (CONVERT([real],(0))) FOR [CostPrice]
GO
ALTER TABLE [dbo].[Goods] ADD  CONSTRAINT [DF__Goods__InStock__534D60F1]  DEFAULT ((0)) FOR [InStock]
GO
ALTER TABLE [dbo].[Goods] ADD  CONSTRAINT [DF__Goods__StockPric__5441852A]  DEFAULT (CONVERT([real],(0))) FOR [StockPrice]
GO
ALTER TABLE [dbo].[Goods] ADD  CONSTRAINT [DF__Goods__Created__5535A963]  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [WarrantyTime]
GO
ALTER TABLE [dbo].[Goods] ADD  CONSTRAINT [DF__Goods__StorageId__5629CD9C]  DEFAULT ((0)) FOR [StorageId]
GO
ALTER TABLE [dbo].[GoodsHistory] ADD  DEFAULT ((0)) FOR [UserId]
GO
ALTER TABLE [dbo].[ImportOrder] ADD  CONSTRAINT [DF__ImportOrd__Stora__11D4A34F]  DEFAULT ((0)) FOR [StorageId]
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
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__User__RoleId__619B8048]  DEFAULT ((0)) FOR [RoleId]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__User__Status__628FA481]  DEFAULT (CONVERT([bit],(0))) FOR [StatusId]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__User__StorageId__6383C8BA]  DEFAULT ((0)) FOR [StorageId]
GO
ALTER TABLE [dbo].[AvailableForReturns]  WITH CHECK ADD  CONSTRAINT [FK_AvailableForReturns_ExportOrder_ExportId] FOREIGN KEY([ExportId])
REFERENCES [dbo].[ExportOrder] ([ExportId])
GO
ALTER TABLE [dbo].[AvailableForReturns] CHECK CONSTRAINT [FK_AvailableForReturns_ExportOrder_ExportId]
GO
ALTER TABLE [dbo].[AvailableForReturns]  WITH CHECK ADD  CONSTRAINT [FK_AvailableForReturns_Goods_GoodsId] FOREIGN KEY([GoodsId])
REFERENCES [dbo].[Goods] ([GoodsId])
GO
ALTER TABLE [dbo].[AvailableForReturns] CHECK CONSTRAINT [FK_AvailableForReturns_Goods_GoodsId]
GO
ALTER TABLE [dbo].[AvailableForReturns]  WITH CHECK ADD  CONSTRAINT [FK_AvailableForReturns_ImportOrder_ImportId] FOREIGN KEY([ImportId])
REFERENCES [dbo].[ImportOrder] ([ImportId])
GO
ALTER TABLE [dbo].[AvailableForReturns] CHECK CONSTRAINT [FK_AvailableForReturns_ImportOrder_ImportId]
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
ALTER TABLE [dbo].[ExportOrder]  WITH CHECK ADD  CONSTRAINT [FK_ExportOrder_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[ExportOrder] CHECK CONSTRAINT [FK_ExportOrder_Status]
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
ALTER TABLE [dbo].[Goods]  WITH CHECK ADD  CONSTRAINT [FK_Goods_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Goods] CHECK CONSTRAINT [FK_Goods_Category_CategoryId]
GO
ALTER TABLE [dbo].[Goods]  WITH CHECK ADD  CONSTRAINT [FK_Goods_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[Goods] CHECK CONSTRAINT [FK_Goods_Status]
GO
ALTER TABLE [dbo].[Goods]  WITH CHECK ADD  CONSTRAINT [FK_Goods_Storage_StorageId] FOREIGN KEY([StorageId])
REFERENCES [dbo].[Storage] ([StorageId])
GO
ALTER TABLE [dbo].[Goods] CHECK CONSTRAINT [FK_Goods_Storage_StorageId]
GO
ALTER TABLE [dbo].[Goods]  WITH CHECK ADD  CONSTRAINT [FK_Goods_Supplier_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([SupplierId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Goods] CHECK CONSTRAINT [FK_Goods_Supplier_SupplierId]
GO
ALTER TABLE [dbo].[GoodsHistory]  WITH CHECK ADD  CONSTRAINT [FK_GoodsHistory_ActionType_ActionId] FOREIGN KEY([ActionId])
REFERENCES [dbo].[ActionType] ([ActionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GoodsHistory] CHECK CONSTRAINT [FK_GoodsHistory_ActionType_ActionId]
GO
ALTER TABLE [dbo].[GoodsHistory]  WITH CHECK ADD  CONSTRAINT [FK_GoodsHistory_Goods_GoodsId] FOREIGN KEY([GoodsId])
REFERENCES [dbo].[Goods] ([GoodsId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GoodsHistory] CHECK CONSTRAINT [FK_GoodsHistory_Goods_GoodsId]
GO
ALTER TABLE [dbo].[GoodsHistory]  WITH CHECK ADD  CONSTRAINT [FK_GoodsHistory_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GoodsHistory] CHECK CONSTRAINT [FK_GoodsHistory_User_UserId]
GO
ALTER TABLE [dbo].[ImportOrder]  WITH CHECK ADD  CONSTRAINT [FK_ImportOrder_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[ImportOrder] CHECK CONSTRAINT [FK_ImportOrder_Project]
GO
ALTER TABLE [dbo].[ImportOrder]  WITH CHECK ADD  CONSTRAINT [FK_ImportOrder_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[ImportOrder] CHECK CONSTRAINT [FK_ImportOrder_Status]
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
ALTER TABLE [dbo].[ImportOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_ImportOrderDetail_ImportOrder_ImportId] FOREIGN KEY([ImportId])
REFERENCES [dbo].[ImportOrder] ([ImportId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImportOrderDetail] CHECK CONSTRAINT [FK_ImportOrderDetail_ImportOrder_ImportId]
GO
ALTER TABLE [dbo].[Loads]  WITH CHECK ADD  CONSTRAINT [FK_Loads_Delivery] FOREIGN KEY([DeliveryId])
REFERENCES [dbo].[Delivery] ([DeliveyId])
GO
ALTER TABLE [dbo].[Loads] CHECK CONSTRAINT [FK_Loads_Delivery]
GO
ALTER TABLE [dbo].[Loads]  WITH CHECK ADD  CONSTRAINT [FK_Loads_Status] FOREIGN KEY([statusId])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[Loads] CHECK CONSTRAINT [FK_Loads_Status]
GO
ALTER TABLE [dbo].[Loads]  WITH CHECK ADD  CONSTRAINT [FK_Loads_Storage] FOREIGN KEY([StorageId])
REFERENCES [dbo].[Storage] ([StorageId])
GO
ALTER TABLE [dbo].[Loads] CHECK CONSTRAINT [FK_Loads_Storage]
GO
ALTER TABLE [dbo].[Loads]  WITH CHECK ADD  CONSTRAINT [FK_Loads_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Loads] CHECK CONSTRAINT [FK_Loads_User]
GO
ALTER TABLE [dbo].[LoadsGoods]  WITH CHECK ADD  CONSTRAINT [FK_LoadsGoods_Goods] FOREIGN KEY([GoodsId])
REFERENCES [dbo].[Goods] ([GoodsId])
GO
ALTER TABLE [dbo].[LoadsGoods] CHECK CONSTRAINT [FK_LoadsGoods_Goods]
GO
ALTER TABLE [dbo].[LoadsGoods]  WITH CHECK ADD  CONSTRAINT [FK_LoadsGoods_Loads] FOREIGN KEY([LoadsId])
REFERENCES [dbo].[Loads] ([LoadsId])
GO
ALTER TABLE [dbo].[LoadsGoods] CHECK CONSTRAINT [FK_LoadsGoods_Loads]
GO
ALTER TABLE [dbo].[MeasuredUnit]  WITH CHECK ADD  CONSTRAINT [FK_MeasuredUnit_Goods_GoodsId] FOREIGN KEY([GoodsId])
REFERENCES [dbo].[Goods] ([GoodsId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MeasuredUnit] CHECK CONSTRAINT [FK_MeasuredUnit_Goods_GoodsId]
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
ALTER TABLE [dbo].[ReturnsOrder]  WITH CHECK ADD  CONSTRAINT [FK_ReturnsOrder_Status] FOREIGN KEY([State])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[ReturnsOrder] CHECK CONSTRAINT [FK_ReturnsOrder_Status]
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
ALTER TABLE [dbo].[ReturnsOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_ReturnsOrderDetail_Goods_GoodsId] FOREIGN KEY([GoodsId])
REFERENCES [dbo].[Goods] ([GoodsId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReturnsOrderDetail] CHECK CONSTRAINT [FK_ReturnsOrderDetail_Goods_GoodsId]
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
ALTER TABLE [dbo].[RoleFeature]  WITH CHECK ADD  CONSTRAINT [FK_RoleFeature_Features] FOREIGN KEY([featureId])
REFERENCES [dbo].[Features] ([featureId])
GO
ALTER TABLE [dbo].[RoleFeature] CHECK CONSTRAINT [FK_RoleFeature_Features]
GO
ALTER TABLE [dbo].[RoleFeature]  WITH CHECK ADD  CONSTRAINT [FK_RoleFeature_Role] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[RoleFeature] CHECK CONSTRAINT [FK_RoleFeature_Role]
GO
ALTER TABLE [dbo].[StocktakeNote]  WITH CHECK ADD  CONSTRAINT [FK_StocktakeNote_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[StocktakeNote] CHECK CONSTRAINT [FK_StocktakeNote_Status]
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
ALTER TABLE [dbo].[StocktakeNoteDetail]  WITH CHECK ADD  CONSTRAINT [FK_StocktakeNoteDetail_Goods_GoodsId] FOREIGN KEY([GoodsId])
REFERENCES [dbo].[Goods] ([GoodsId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StocktakeNoteDetail] CHECK CONSTRAINT [FK_StocktakeNoteDetail_Goods_GoodsId]
GO
ALTER TABLE [dbo].[StocktakeNoteDetail]  WITH CHECK ADD  CONSTRAINT [FK_StocktakeNoteDetail_StocktakeNote_StocktakeId] FOREIGN KEY([StocktakeId])
REFERENCES [dbo].[StocktakeNote] ([StocktakeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StocktakeNoteDetail] CHECK CONSTRAINT [FK_StocktakeNoteDetail_StocktakeNote_StocktakeId]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_Supplier_Status]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role_RoleId]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Status]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Storage_StorageId] FOREIGN KEY([StorageId])
REFERENCES [dbo].[Storage] ([StorageId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Storage_StorageId]
GO

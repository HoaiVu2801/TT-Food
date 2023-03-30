USE [master]
GO
/****** Object:  Database [API_Food]    Script Date: 3/30/2023 6:39:23 PM ******/
CREATE DATABASE [API_Food]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'API_Food', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\API_Food.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'API_Food_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\API_Food_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [API_Food] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [API_Food].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [API_Food] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [API_Food] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [API_Food] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [API_Food] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [API_Food] SET ARITHABORT OFF 
GO
ALTER DATABASE [API_Food] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [API_Food] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [API_Food] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [API_Food] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [API_Food] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [API_Food] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [API_Food] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [API_Food] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [API_Food] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [API_Food] SET  ENABLE_BROKER 
GO
ALTER DATABASE [API_Food] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [API_Food] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [API_Food] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [API_Food] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [API_Food] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [API_Food] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [API_Food] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [API_Food] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [API_Food] SET  MULTI_USER 
GO
ALTER DATABASE [API_Food] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [API_Food] SET DB_CHAINING OFF 
GO
ALTER DATABASE [API_Food] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [API_Food] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [API_Food] SET DELAYED_DURABILITY = DISABLED 
GO
USE [API_Food]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/30/2023 6:39:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FoodByRestaurant]    Script Date: 3/30/2023 6:39:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FoodByRestaurant](
	[FoodID] [varchar](36) NOT NULL,
	[FoodName] [nvarchar](255) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UnitID] [varchar](36) NOT NULL,
	[Mode] [int] NOT NULL,
 CONSTRAINT [PK_FoodByRestaurant] PRIMARY KEY CLUSTERED 
(
	[FoodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FoodForUser]    Script Date: 3/30/2023 6:39:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FoodForUser](
	[FoodID] [varchar](36) NOT NULL,
	[FoodName] [nvarchar](255) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UnitID] [varchar](36) NOT NULL,
	[RestaurantID] [varchar](36) NOT NULL,
	[Mode] [int] NOT NULL,
	[RestaurantUnitID] [varchar](36) NULL,
 CONSTRAINT [PK_FoodForUser] PRIMARY KEY CLUSTERED 
(
	[FoodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Log]    Script Date: 3/30/2023 6:39:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Log](
	[LogID] [varchar](36) NOT NULL,
	[Action] [nvarchar](100) NOT NULL,
	[UserID] [varchar](36) NOT NULL,
	[Table] [nvarchar](100) NOT NULL,
	[Time] [datetime2](7) NOT NULL,
	[Status] [nvarchar](255) NOT NULL,
	[Content] [nvarchar](max) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/30/2023 6:39:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [varchar](36) NOT NULL,
	[UserID] [varchar](36) NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[Price] [int] NOT NULL,
	[UnitID] [varchar](36) NOT NULL,
	[Status] [nvarchar](100) NOT NULL,
	[Mode] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 3/30/2023 6:39:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailID] [varchar](36) NOT NULL,
	[OrderID] [varchar](36) NOT NULL,
	[FoodID] [varchar](36) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Mode] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RefreshToken]    Script Date: 3/30/2023 6:39:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RefreshToken](
	[TokenID] [varchar](36) NOT NULL,
	[Token] [nvarchar](max) NOT NULL,
	[Jti] [nvarchar](max) NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[IsRevoked] [bit] NOT NULL,
	[UserID] [varchar](36) NOT NULL,
	[ExpiredAt] [datetime2](7) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_RefreshToken] PRIMARY KEY CLUSTERED 
(
	[TokenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 3/30/2023 6:39:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [varchar](36) NOT NULL,
	[RoleName] [nvarchar](255) NOT NULL,
	[Order] [int] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Mode] [int] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 3/30/2023 6:39:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Unit](
	[UnitID] [varchar](36) NOT NULL,
	[UnitName] [nvarchar](255) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[Mode] [int] NOT NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[UnitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/30/2023 6:39:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [varchar](36) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[RoleID] [varchar](36) NOT NULL,
	[UnitID] [varchar](36) NOT NULL,
	[Mode] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230322010559_Initial', N'7.0.4')
INSERT [dbo].[FoodByRestaurant] ([FoodID], [FoodName], [Type], [CreatedDate], [UnitID], [Mode]) VALUES (N'12c4f4e9-2081-4b70-aa7f-6066c39516b5', N'Rau Xào', N'Món Rau', CAST(N'2023-03-09 11:07:06.3710000' AS DateTime2), N'5f57fb7a-0863-4fce-aacf-aaa59323be99', 1)
INSERT [dbo].[FoodByRestaurant] ([FoodID], [FoodName], [Type], [CreatedDate], [UnitID], [Mode]) VALUES (N'425b2cbd-230c-44b6-bde2-7e820205ea9b', N'Rau Luộc', N'Món Mặn', CAST(N'2023-03-27 08:36:46.9300000' AS DateTime2), N'7b1b24ee-1a74-40ab-8d26-bbbe69d6b9ec', 1)
INSERT [dbo].[FoodByRestaurant] ([FoodID], [FoodName], [Type], [CreatedDate], [UnitID], [Mode]) VALUES (N'92ff213e-c21d-436b-bdaf-af98d9241e99', N'Thịt Luộc', N'Món Mặn', CAST(N'2023-03-27 10:17:47.3450000' AS DateTime2), N'31b6d42a-1935-479a-8ff5-8a9625e62bd3', 1)
INSERT [dbo].[FoodByRestaurant] ([FoodID], [FoodName], [Type], [CreatedDate], [UnitID], [Mode]) VALUES (N'c4cd0118-7346-453d-9a96-aab329e169a1', N'Thịt Kho', N'Món Mặn', CAST(N'2023-03-28 00:00:00.0000000' AS DateTime2), N'af1f0bf8-7f44-4213-b37f-e6df0c274f81', 1)
INSERT [dbo].[FoodByRestaurant] ([FoodID], [FoodName], [Type], [CreatedDate], [UnitID], [Mode]) VALUES (N'dc46740d-9ba3-4885-8dfa-354af6a67f9f', N'Gà', N'Món Mặn', CAST(N'2023-03-29 10:53:32.9240000' AS DateTime2), N'40182e2f-75c0-4753-bdaf-b431397079a4', 1)
INSERT [dbo].[Unit] ([UnitID], [UnitName], [Type], [Address], [PhoneNumber], [Mode]) VALUES (N'31b6d42a-1935-479a-8ff5-8a9625e62bd3', N'Đơn vị 2', N'Nhà Hàng', N'Thanh Xuân, Hà Nội', N'0384736282', 1)
INSERT [dbo].[Unit] ([UnitID], [UnitName], [Type], [Address], [PhoneNumber], [Mode]) VALUES (N'39e16eb1-0564-460b-95df-4220fa0bf58f', N'Đơn vị 6', N'Nhà Hàng', N'Hà Nội', N'0983674887', 1)
INSERT [dbo].[Unit] ([UnitID], [UnitName], [Type], [Address], [PhoneNumber], [Mode]) VALUES (N'40182e2f-75c0-4753-bdaf-b431397079a4', N'Đơn vị 5', N'Nhà Hàng', N'Hà Nội', N'0937846374', 1)
INSERT [dbo].[Unit] ([UnitID], [UnitName], [Type], [Address], [PhoneNumber], [Mode]) VALUES (N'5f57fb7a-0863-4fce-aacf-aaa59323be99', N'Đơn vị 3', N'Nhà Hàng', N'Hà Đông, Hà Nội', N'0936473628', 1)
INSERT [dbo].[Unit] ([UnitID], [UnitName], [Type], [Address], [PhoneNumber], [Mode]) VALUES (N'7b1b24ee-1a74-40ab-8d26-bbbe69d6b9ec', N'Đơn vị 4', N'Nhà Hàng', N'Nam Từ Liêm, Hà Nội', N'08456821354', 1)
INSERT [dbo].[Unit] ([UnitID], [UnitName], [Type], [Address], [PhoneNumber], [Mode]) VALUES (N'af1f0bf8-7f44-4213-b37f-e6df0c274f81', N'Đơn vị 1', N'Nhà Hàng', N'Văn Phú, Hà Đông, Hà Nội', N'08634521892', 1)
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_FoodByRestaurant_UnitID]    Script Date: 3/30/2023 6:39:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_FoodByRestaurant_UnitID] ON [dbo].[FoodByRestaurant]
(
	[UnitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_FoodForUser_RestaurantID]    Script Date: 3/30/2023 6:39:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_FoodForUser_RestaurantID] ON [dbo].[FoodForUser]
(
	[RestaurantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_FoodForUser_RestaurantUnitID]    Script Date: 3/30/2023 6:39:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_FoodForUser_RestaurantUnitID] ON [dbo].[FoodForUser]
(
	[RestaurantUnitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Order_UnitID]    Script Date: 3/30/2023 6:39:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_Order_UnitID] ON [dbo].[Order]
(
	[UnitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Order_UserID]    Script Date: 3/30/2023 6:39:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_Order_UserID] ON [dbo].[Order]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_OrderDetail_FoodID]    Script Date: 3/30/2023 6:39:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetail_FoodID] ON [dbo].[OrderDetail]
(
	[FoodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_OrderDetail_OrderID]    Script Date: 3/30/2023 6:39:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetail_OrderID] ON [dbo].[OrderDetail]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RefreshToken_UserID]    Script Date: 3/30/2023 6:39:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_RefreshToken_UserID] ON [dbo].[RefreshToken]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Users_Email]    Script Date: 3/30/2023 6:39:23 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email] ON [dbo].[Users]
(
	[Email] ASC
)
WHERE ([Email] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Users_PhoneNumber]    Script Date: 3/30/2023 6:39:23 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_PhoneNumber] ON [dbo].[Users]
(
	[PhoneNumber] ASC
)
WHERE ([PhoneNumber] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Users_RoleID]    Script Date: 3/30/2023 6:39:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_RoleID] ON [dbo].[Users]
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Users_UnitID]    Script Date: 3/30/2023 6:39:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_UnitID] ON [dbo].[Users]
(
	[UnitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Users_UserName]    Script Date: 3/30/2023 6:39:23 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_UserName] ON [dbo].[Users]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FoodByRestaurant]  WITH CHECK ADD  CONSTRAINT [FK_FoodByRestaurant_Unit_UnitID] FOREIGN KEY([UnitID])
REFERENCES [dbo].[Unit] ([UnitID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FoodByRestaurant] CHECK CONSTRAINT [FK_FoodByRestaurant_Unit_UnitID]
GO
ALTER TABLE [dbo].[FoodForUser]  WITH CHECK ADD  CONSTRAINT [FK_FoodForUser_Unit_RestaurantID] FOREIGN KEY([RestaurantID])
REFERENCES [dbo].[Unit] ([UnitID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FoodForUser] CHECK CONSTRAINT [FK_FoodForUser_Unit_RestaurantID]
GO
ALTER TABLE [dbo].[FoodForUser]  WITH CHECK ADD  CONSTRAINT [FK_FoodForUser_Unit_RestaurantUnitID] FOREIGN KEY([RestaurantUnitID])
REFERENCES [dbo].[Unit] ([UnitID])
GO
ALTER TABLE [dbo].[FoodForUser] CHECK CONSTRAINT [FK_FoodForUser_Unit_RestaurantUnitID]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Unit_UnitID] FOREIGN KEY([UnitID])
REFERENCES [dbo].[Unit] ([UnitID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Unit_UnitID]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Users_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Users_UserID]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_FoodForUser_FoodID] FOREIGN KEY([FoodID])
REFERENCES [dbo].[FoodForUser] ([FoodID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_FoodForUser_FoodID]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order_OrderID]
GO
ALTER TABLE [dbo].[RefreshToken]  WITH CHECK ADD  CONSTRAINT [FK_RefreshToken_Users_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RefreshToken] CHECK CONSTRAINT [FK_RefreshToken_Users_UserID]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Role_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Role_RoleID]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Unit_UnitID] FOREIGN KEY([UnitID])
REFERENCES [dbo].[Unit] ([UnitID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Unit_UnitID]
GO
USE [master]
GO
ALTER DATABASE [API_Food] SET  READ_WRITE 
GO

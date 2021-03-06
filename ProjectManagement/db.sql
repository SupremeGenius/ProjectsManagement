USE [master]
GO
/****** Object:  Database [AssigmentDB]    Script Date: 3/26/2019 9:19:55 AM ******/
CREATE DATABASE [AssigmentDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AssigmentDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.THUYVTKSE63436\MSSQL\DATA\AssigmentDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AssigmentDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.THUYVTKSE63436\MSSQL\DATA\AssigmentDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AssigmentDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AssigmentDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AssigmentDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AssigmentDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AssigmentDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AssigmentDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AssigmentDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AssigmentDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AssigmentDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AssigmentDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AssigmentDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AssigmentDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AssigmentDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AssigmentDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AssigmentDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AssigmentDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AssigmentDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AssigmentDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AssigmentDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AssigmentDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AssigmentDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AssigmentDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AssigmentDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AssigmentDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AssigmentDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AssigmentDB] SET  MULTI_USER 
GO
ALTER DATABASE [AssigmentDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AssigmentDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AssigmentDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AssigmentDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AssigmentDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AssigmentDB]
GO
/****** Object:  Table [dbo].[tbl_Account]    Script Date: 3/26/2019 9:19:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Account](
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](6) NOT NULL,
	[emId] [int] NOT NULL,
	[roleId] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Account] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Company]    Script Date: 3/26/2019 9:19:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Company](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[address] [nvarchar](250) NOT NULL,
	[email] [nvarchar](200) NOT NULL,
	[deleteStatus] [bit] NOT NULL CONSTRAINT [DF_tbl_Company_deleteStatus]  DEFAULT ((0)),
	[bankNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_Company] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Employee]    Script Date: 3/26/2019 9:19:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[address] [nvarchar](200) NOT NULL,
	[birthday] [date] NOT NULL,
	[phone] [nvarchar](13) NOT NULL,
	[email] [nvarchar](200) NOT NULL,
	[roleId] [int] NOT NULL,
	[salary] [float] NOT NULL,
	[deleteStatus] [bit] NOT NULL CONSTRAINT [DF_tbl_Employee_deleteStatus]  DEFAULT ((0)),
 CONSTRAINT [PK_tbl_Employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Joining]    Script Date: 3/26/2019 9:19:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Joining](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[projectId] [int] NOT NULL,
	[emId] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Joining] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Partner]    Script Date: 3/26/2019 9:19:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Partner](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](150) NOT NULL,
	[position] [nvarchar](100) NOT NULL,
	[address] [nvarchar](300) NULL,
	[phone] [nvarchar](12) NOT NULL,
	[companyID] [int] NOT NULL,
	[email] [nvarchar](250) NOT NULL,
	[deleteStatus] [bit] NULL CONSTRAINT [DF_tbl_Partner_deleteStatus]  DEFAULT ((0)),
 CONSTRAINT [PK_tbl_Partner] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Project]    Script Date: 3/26/2019 9:19:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Project](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[description] [nvarchar](max) NULL,
	[partnerId] [int] NOT NULL,
	[status] [bit] NOT NULL,
	[advancePayment] [float] NOT NULL CONSTRAINT [DF_tbl_Project_advancePayment]  DEFAULT ((0)),
	[cost] [float] NOT NULL,
	[beginTime] [date] NOT NULL,
	[deadline] [date] NULL,
	[endTime] [date] NULL,
	[deleteStatus] [bit] NOT NULL CONSTRAINT [DF_tbl_Project_deleteStatus]  DEFAULT ((0)),
 CONSTRAINT [PK_tbl_Project] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Role]    Script Date: 3/26/2019 9:19:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[roleName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tbl_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[tbl_Account] ([username], [password], [emId], [roleId]) VALUES (N'thien', N'1', 2, 4)
INSERT [dbo].[tbl_Account] ([username], [password], [emId], [roleId]) VALUES (N'thuy', N'1', 1, 4)
SET IDENTITY_INSERT [dbo].[tbl_Company] ON 

INSERT [dbo].[tbl_Company] ([id], [name], [address], [email], [deleteStatus], [bankNumber]) VALUES (1, N'Cong ty Sobalis', N'Ho chi minh', N'solabit@gmail.com', 0, N'0987654321')
INSERT [dbo].[tbl_Company] ([id], [name], [address], [email], [deleteStatus], [bankNumber]) VALUES (2, N'CÔNG TY TNHH JONE ĐẠI PHÁT', N'Số 36 Đường số 5, ấp Tiền Lân, Xã Bà Điểm, Huyện Hóc Môn, TP Hồ Chi Minh', N'dh@gmial.com', 0, N'1234')
INSERT [dbo].[tbl_Company] ([id], [name], [address], [email], [deleteStatus], [bankNumber]) VALUES (3, N'CÔNG TY TNHH THIẾT KẾ XÂY DỰNG HOÀNG THỊNH

', N'78/12/32/5 đường Tôn Thất Thuyết, Phường 16, Quận 4, TP Hồ Chí Minh', N'hoangthinh@gmail.com', 0, N'1234567890')
INSERT [dbo].[tbl_Company] ([id], [name], [address], [email], [deleteStatus], [bankNumber]) VALUES (4, N'CÔNG TY TNHH XÂY DỰNG TÂN MAI VÕ', N'24/7 Đường số 12, Phường Bình Hưng Hòa A, Quận Bình Tân, TP Hồ Chí MinhA', N'tanmaivo@gmail.com', 0, N'123456789')
INSERT [dbo].[tbl_Company] ([id], [name], [address], [email], [deleteStatus], [bankNumber]) VALUES (5, N'CÔNG TY TNHH BAOBAO ADS', N'33 Lô 17 Đường Hưng Phú, Phường 10, Quận 8, TP Hồ Chí Minh
', N'baobao@gmail.com', 0, N'123456789')
INSERT [dbo].[tbl_Company] ([id], [name], [address], [email], [deleteStatus], [bankNumber]) VALUES (6, N'CÔNG TY CỔ PHẦN THỰC PHẨM SẠCH THÁI DƯƠNG', N'36 Đặng Tất, Phường Tân Định, Quận 1, TP Hồ Chí Minh', N'thaiduong@gamil.com', 0, N'23456789')
INSERT [dbo].[tbl_Company] ([id], [name], [address], [email], [deleteStatus], [bankNumber]) VALUES (9, N'thien phat', N'go vap', N'thien@gmail.com', 0, N'12357890')
INSERT [dbo].[tbl_Company] ([id], [name], [address], [email], [deleteStatus], [bankNumber]) VALUES (10, N'thien phat', N'go vap', N'td@gmail.com', 0, N'123456789')
SET IDENTITY_INSERT [dbo].[tbl_Company] OFF
SET IDENTITY_INSERT [dbo].[tbl_Employee] ON 

INSERT [dbo].[tbl_Employee] ([id], [name], [address], [birthday], [phone], [email], [roleId], [salary], [deleteStatus]) VALUES (1, N'Vo Kim Thuy', N'Go Vap', CAST(N'1998-01-21' AS Date), N'0378043064', N'vokimthuy211@gmail.com', 4, 2000, 0)
INSERT [dbo].[tbl_Employee] ([id], [name], [address], [birthday], [phone], [email], [roleId], [salary], [deleteStatus]) VALUES (2, N'Vo Nhat Thien', N'Quan 12', CAST(N'1998-11-02' AS Date), N'0987654321', N'vonhatthien@gmail.com', 4, 3000, 0)
INSERT [dbo].[tbl_Employee] ([id], [name], [address], [birthday], [phone], [email], [roleId], [salary], [deleteStatus]) VALUES (3, N'Dat Dang', N'Quan 1', CAST(N'1998-05-07' AS Date), N'098765421', N'dat@gmail.com', 4, 1000, 0)
INSERT [dbo].[tbl_Employee] ([id], [name], [address], [birthday], [phone], [email], [roleId], [salary], [deleteStatus]) VALUES (5, N'Hong Nhung', N'Quan 12', CAST(N'1998-01-24' AS Date), N'0378034069', N'nhung@gmail.com', 5, 600, 0)
INSERT [dbo].[tbl_Employee] ([id], [name], [address], [birthday], [phone], [email], [roleId], [salary], [deleteStatus]) VALUES (6, N'Nguyen thanh Dat', N'Hà Nội', CAST(N'1967-08-01' AS Date), N'01667715678', N'dat@gmail.com', 5, 100, 0)
INSERT [dbo].[tbl_Employee] ([id], [name], [address], [birthday], [phone], [email], [roleId], [salary], [deleteStatus]) VALUES (7, N'Đỗ Xuân Sơn', N'Hà Tĩnh', CAST(N'1987-03-04' AS Date), N'0912345679', N'son@gmail.com', 4, 200, 0)
INSERT [dbo].[tbl_Employee] ([id], [name], [address], [birthday], [phone], [email], [roleId], [salary], [deleteStatus]) VALUES (9, N'Bùi Thị Huế', N'TT Huế', CAST(N'1986-05-04' AS Date), N'0945678790', N'hue@gmail.com', 5, 300, 0)
INSERT [dbo].[tbl_Employee] ([id], [name], [address], [birthday], [phone], [email], [roleId], [salary], [deleteStatus]) VALUES (10, N'Trần Thị Ánh', N'Tp Hồ Chí Minh', CAST(N'1995-08-07' AS Date), N'0989765345', N'anh@gmail.com', 5, 400, 0)
SET IDENTITY_INSERT [dbo].[tbl_Employee] OFF
SET IDENTITY_INSERT [dbo].[tbl_Joining] ON 

INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (1, 1, 1)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (2, 1, 2)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (3, 1, 3)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (71, 1, 5)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (40, 1, 10)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (45, 4, 3)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (7, 4, 6)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (8, 4, 7)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (10, 4, 9)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (11, 4, 10)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (12, 5, 3)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (13, 5, 9)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (15, 6, 7)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (14, 6, 10)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (17, 8, 1)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (55, 8, 3)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (20, 9, 3)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (21, 10, 3)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (22, 10, 5)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (72, 10, 9)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (49, 11, 3)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (56, 11, 5)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (23, 11, 6)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (73, 11, 7)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (24, 11, 9)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (41, 12, 5)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (27, 12, 7)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (26, 12, 9)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (25, 12, 10)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (28, 13, 1)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (46, 13, 3)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (29, 13, 5)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (31, 14, 5)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (50, 15, 3)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (32, 15, 6)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (33, 15, 10)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (35, 16, 2)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (38, 17, 1)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (37, 17, 3)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (75, 20, 1)
INSERT [dbo].[tbl_Joining] ([id], [projectId], [emId]) VALUES (74, 20, 6)
SET IDENTITY_INSERT [dbo].[tbl_Joining] OFF
SET IDENTITY_INSERT [dbo].[tbl_Partner] ON 

INSERT [dbo].[tbl_Partner] ([id], [name], [position], [address], [phone], [companyID], [email], [deleteStatus]) VALUES (1, N'VÕ THỊ KIM THÙY', N'PM', N'Go vap', N'0378034064', 1, N'solabit@gmail.com', 0)
INSERT [dbo].[tbl_Partner] ([id], [name], [position], [address], [phone], [companyID], [email], [deleteStatus]) VALUES (2, N'TRẦN VIẾT ĐÔNG', N'Leader', N'Quận 1', N'0123456', 2, N'dh@gmial.com', 0)
INSERT [dbo].[tbl_Partner] ([id], [name], [position], [address], [phone], [companyID], [email], [deleteStatus]) VALUES (3, N'Nguyễn Lê Nhật Trường', N'PM', N'Quan 2', N'0123', 3, N'	truongnlnse61324@gmail.com', 0)
INSERT [dbo].[tbl_Partner] ([id], [name], [position], [address], [phone], [companyID], [email], [deleteStatus]) VALUES (4, N'ĐINH TUẤN	 NAM', N'PO', N'Quan 4', N'012345678', 4, N'namdtse62542@gmail.com', 0)
INSERT [dbo].[tbl_Partner] ([id], [name], [position], [address], [phone], [companyID], [email], [deleteStatus]) VALUES (5, N'Vũ Đại Phong', N'Employee', N'Quan 5', N'012389876', 5, N'	phongvdse62641@gmail.com', 0)
INSERT [dbo].[tbl_Partner] ([id], [name], [position], [address], [phone], [companyID], [email], [deleteStatus]) VALUES (7, N'VÕ VĂN TUẤN', N'Employee', N'Quan 6', N'0378038754', 6, N'thaiduong@gamil.com', 0)
INSERT [dbo].[tbl_Partner] ([id], [name], [position], [address], [phone], [companyID], [email], [deleteStatus]) VALUES (8, N'Nguyễn Gia Huy', N'Employee', N'Quan 7', N'01234535', 6, N'	huyngse63158@gmail.com', 0)
INSERT [dbo].[tbl_Partner] ([id], [name], [position], [address], [phone], [companyID], [email], [deleteStatus]) VALUES (9, N'Võ Văn Tần', N'PO', N'Quan 9', N'01233580', 4, N'tan2gmail.com', 0)
INSERT [dbo].[tbl_Partner] ([id], [name], [position], [address], [phone], [companyID], [email], [deleteStatus]) VALUES (18, N'thien', N'CEO', N'thuy', N'0123567890', 9, N'thien@gmail.com', 0)
INSERT [dbo].[tbl_Partner] ([id], [name], [position], [address], [phone], [companyID], [email], [deleteStatus]) VALUES (19, N'thien', N'CEO', N'go vap', N'01237899', 10, N'hien@gmail.com', 0)
SET IDENTITY_INSERT [dbo].[tbl_Partner] OFF
SET IDENTITY_INSERT [dbo].[tbl_Project] ON 

INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (1, N'A Simple Survey update', N'', 1, 0, 50000, 1000000, CAST(N'2018-03-05' AS Date), CAST(N'2019-02-02' AS Date), NULL, 0)
INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (4, N'Absolute Duo', NULL, 2, 1, 3000000, 10000000, CAST(N'2017-05-03' AS Date), CAST(N'2017-06-04' AS Date), CAST(N'2017-06-01' AS Date), 0)
INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (5, N'Accel World', NULL, 3, 1, 1000000, 5000000, CAST(N'2018-06-01' AS Date), CAST(N'2018-07-01' AS Date), CAST(N'2018-07-01' AS Date), 0)
INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (6, N'Akuma Koujo 〜 Yurui Akuma no Monogatari 〜', N'', 4, 1, 500, 30000, CAST(N'2018-08-07' AS Date), CAST(N'2018-09-01' AS Date), CAST(N'2018-09-01' AS Date), 0)
INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (8, N'All you need is kill', N'', 5, 1, 500000, 5000000, CAST(N'2018-08-07' AS Date), CAST(N'2018-09-01' AS Date), CAST(N'2019-03-24' AS Date), 1)
INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (9, N'Boku wa Tomodachi ga Sukunai', NULL, 7, 0, 100000, 6000000, CAST(N'2018-09-01' AS Date), CAST(N'2019-05-01' AS Date), NULL, 0)
INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (10, N'CtG —Zero Kara Sodateru Dennou Shoujo', NULL, 7, 1, 100000, 6000000, CAST(N'2018-09-01' AS Date), CAST(N'2019-01-01' AS Date), CAST(N'2019-01-01' AS Date), 0)
INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (11, N'Dungeon ni Deai wo Motomeru no wa Machigatteiru Darou ka', NULL, 2, 1, 500000, 5000000, CAST(N'2019-01-01' AS Date), CAST(N'2018-05-01' AS Date), CAST(N'2018-02-01' AS Date), 0)
INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (12, N'Ero Manga Sensei: Imouto to Akazu no Ma', N'', 1, 1, 100000, 6000000, CAST(N'2018-09-01' AS Date), CAST(N'2019-05-01' AS Date), CAST(N'2019-03-24' AS Date), 0)
INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (13, N'All you need is kill', N'', 1, 1, 500000, 5000000, CAST(N'2018-08-07' AS Date), CAST(N'2018-09-01' AS Date), CAST(N'2018-09-01' AS Date), 0)
INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (14, N'Hikaru ga Chikyuu ni Itakoro......', NULL, 2, 0, 100000, 6000000, CAST(N'2018-09-01' AS Date), CAST(N'2019-05-01' AS Date), NULL, 0)
INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (15, N'Ichiban Ushiro no Daimaou', NULL, 2, 0, 100000, 6000000, CAST(N'2018-09-01' AS Date), CAST(N'2019-05-01' AS Date), NULL, 0)
INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (16, N'Intellectual Village no Zashiki Warashi', NULL, 3, 0, 100000, 6000000, CAST(N'2018-09-01' AS Date), CAST(N'2019-05-01' AS Date), NULL, 0)
INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (17, N'Ero Manga Sensei: Imouto to Akazu no Ma', NULL, 8, 0, 100000, 6000000, CAST(N'2018-09-01' AS Date), CAST(N'2019-05-01' AS Date), NULL, 0)
INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (18, N'updatetttt', NULL, 3, 0, 2, 22, CAST(N'2019-03-25' AS Date), NULL, NULL, 1)
INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (19, N'updatetttt', NULL, 3, 0, 2, 22, CAST(N'2019-03-25' AS Date), NULL, NULL, 1)
INSERT [dbo].[tbl_Project] ([id], [name], [description], [partnerId], [status], [advancePayment], [cost], [beginTime], [deadline], [endTime], [deleteStatus]) VALUES (20, N'updatetttt', NULL, 3, 0, 2, 22, CAST(N'2019-03-25' AS Date), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[tbl_Project] OFF
SET IDENTITY_INSERT [dbo].[tbl_Role] ON 

INSERT [dbo].[tbl_Role] ([id], [roleName]) VALUES (4, N'PM')
INSERT [dbo].[tbl_Role] ([id], [roleName]) VALUES (5, N'employee')
SET IDENTITY_INSERT [dbo].[tbl_Role] OFF
/****** Object:  Index [IX_tbl_Joining]    Script Date: 3/26/2019 9:19:55 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tbl_Joining] ON [dbo].[tbl_Joining]
(
	[projectId] ASC,
	[emId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_tbl_Partner]    Script Date: 3/26/2019 9:19:55 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tbl_Partner] ON [dbo].[tbl_Partner]
(
	[phone] ASC,
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Account]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Account_tbl_Employee1] FOREIGN KEY([emId])
REFERENCES [dbo].[tbl_Employee] ([id])
GO
ALTER TABLE [dbo].[tbl_Account] CHECK CONSTRAINT [FK_tbl_Account_tbl_Employee1]
GO
ALTER TABLE [dbo].[tbl_Account]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Account_tbl_Role1] FOREIGN KEY([roleId])
REFERENCES [dbo].[tbl_Role] ([id])
GO
ALTER TABLE [dbo].[tbl_Account] CHECK CONSTRAINT [FK_tbl_Account_tbl_Role1]
GO
ALTER TABLE [dbo].[tbl_Employee]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Employee_tbl_Role] FOREIGN KEY([roleId])
REFERENCES [dbo].[tbl_Role] ([id])
GO
ALTER TABLE [dbo].[tbl_Employee] CHECK CONSTRAINT [FK_tbl_Employee_tbl_Role]
GO
ALTER TABLE [dbo].[tbl_Joining]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Joining_tbl_Employee1] FOREIGN KEY([emId])
REFERENCES [dbo].[tbl_Employee] ([id])
GO
ALTER TABLE [dbo].[tbl_Joining] CHECK CONSTRAINT [FK_tbl_Joining_tbl_Employee1]
GO
ALTER TABLE [dbo].[tbl_Joining]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Joining_tbl_Project] FOREIGN KEY([projectId])
REFERENCES [dbo].[tbl_Project] ([id])
GO
ALTER TABLE [dbo].[tbl_Joining] CHECK CONSTRAINT [FK_tbl_Joining_tbl_Project]
GO
ALTER TABLE [dbo].[tbl_Partner]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Partner_tbl_Company] FOREIGN KEY([companyID])
REFERENCES [dbo].[tbl_Company] ([id])
GO
ALTER TABLE [dbo].[tbl_Partner] CHECK CONSTRAINT [FK_tbl_Partner_tbl_Company]
GO
ALTER TABLE [dbo].[tbl_Project]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Project_tbl_Partner] FOREIGN KEY([partnerId])
REFERENCES [dbo].[tbl_Partner] ([id])
GO
ALTER TABLE [dbo].[tbl_Project] CHECK CONSTRAINT [FK_tbl_Project_tbl_Partner]
GO
USE [master]
GO
ALTER DATABASE [AssigmentDB] SET  READ_WRITE 
GO

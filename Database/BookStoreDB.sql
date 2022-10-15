CREATE DATABASE [BookStoreDB]
USE [BookStoreDB]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 10/14/2022 9:04:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](20) NULL,
	[Name] [nvarchar](50) NULL,
	[Avatar] [ntext] NULL,
	[Phone] [char](10) NULL,
	[DateOfBirth] [date] NULL,
	[IsActive] [bit] NULL,
	[RoleId] [int] NULL,
	[StoreId] [int] NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 10/14/2022 9:04:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[ISBN] [nvarchar](20) NULL,
	[Author] [nvarchar](100) NULL,
	[ReleaseYear] [char](4) NULL,
	[Version] [int] NULL,
	[IsActive] [bit] NULL,
	[Amount] [int] NULL,
	[CategoryId] [int] NULL,
	[PublisherId] [int] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookInStore]    Script Date: 10/14/2022 9:04:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookInStore](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NULL,
	[StoreId] [int] NULL,
 CONSTRAINT [PK_BookInStore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/14/2022 9:04:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 10/14/2022 9:04:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TotalPrice] [money] NULL,
	[CreateDate] [datetime] NULL,
	[ShippingAddress] [ntext] NULL,
	[CustomerId] [int] NULL,
	[OrderStatus] [nvarchar](50) NULL,
	[StaffId] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 10/14/2022 9:04:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[BookId] [int] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 10/14/2022 9:04:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestBook]    Script Date: 10/14/2022 9:04:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddBookState] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[Quantity] [int] NULL,
	[AcceptedImport] [bit] NULL,
	[StaffId] [int] NULL,
 CONSTRAINT [PK_RequestBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestBookDetail]    Script Date: 10/14/2022 9:04:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestBookDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NULL,
	[RealQuantity] [int] NULL,
	[RequestBookId] [int] NULL,
 CONSTRAINT [PK_RequestBookDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10/14/2022 9:04:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 10/14/2022 9:04:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [ntext] NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([Id], [Username], [Password], [Name], [Avatar], [Phone], [DateOfBirth], [IsActive], [RoleId], [StoreId], [Address]) VALUES (1, N'dat', N'admin@@', N'Tran Thanh Dat', N'https://scontent.fsgn5-6.fna.fbcdn.net/v/t1.6435-9/174762436_1564087070462196_7088412740167491002_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=174925&_nc_ohc=AIOCzgUZmb8AX8uag1j&_nc_ht=scontent.fsgn5-6.fna&oh=00_AT8nQS8VOu-Km5-qbndO2dgZx-lbnhTBzhQCUJ3iFuS2xw&oe=636D30D1', N'123456789 ', CAST(N'2001-06-25' AS Date), 1, 1, NULL, N'District 9, HCM City')
INSERT [dbo].[Account] ([Id], [Username], [Password], [Name], [Avatar], [Phone], [DateOfBirth], [IsActive], [RoleId], [StoreId], [Address]) VALUES (2, N'linh', N'123', N'Do Anh Linh', N'https://scontent.fsgn5-2.fna.fbcdn.net/v/t39.30808-6/277997569_3353450438246521_7339571529235875641_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=_t1Vq70yQYcAX-17zQ2&_nc_ht=scontent.fsgn5-2.fna&oh=00_AT80jMaPQVAnKfR-D3XwUWEIIvl9MmuA26jpM62ZW2ZAjg&oe=634EE205', N'123456789 ', CAST(N'2000-11-12' AS Date), 1, 2, NULL, N'District 9, HCM City')
INSERT [dbo].[Account] ([Id], [Username], [Password], [Name], [Avatar], [Phone], [DateOfBirth], [IsActive], [RoleId], [StoreId], [Address]) VALUES (3, N'thang', N'123', N'Tran Ngoc Thang', N'https://scontent.fsgn5-14.fna.fbcdn.net/v/t39.30808-6/307438835_2013015145571418_6591376168230117923_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=L6rbiMjizLMAX-_K1t1&_nc_ht=scontent.fsgn5-14.fna&oh=00_AT_u7o_GhDa0e8xTbfmJDQyYd6DPNWfJy1EKiOaIu_RbmA&oe=634D4461', N'123456789 ', CAST(N'2001-01-21' AS Date), 1, 3, NULL, N'District 9, HCM City')
INSERT [dbo].[Account] ([Id], [Username], [Password], [Name], [Avatar], [Phone], [DateOfBirth], [IsActive], [RoleId], [StoreId], [Address]) VALUES (4, N'huy', N'123', N'Tran Minh Huy', N'https://scontent.fsgn5-5.fna.fbcdn.net/v/t39.30808-1/277582153_685497472597196_4540333871419656258_n.jpg?stp=dst-jpg_s200x200&_nc_cat=100&ccb=1-7&_nc_sid=7206a8&_nc_ohc=qmqImZaBx0UAX96u55Y&_nc_ht=scontent.fsgn5-5.fna&oh=00_AT9Ipf1Hj9MR11s_iu1Hta2irS-xEErNWN6Tee1wKSF0vQ&oe=634D7A54', N'123456789 ', CAST(N'2001-04-14' AS Date), 1, 4, NULL, N'Tan Binh, HCM City')
INSERT [dbo].[Account] ([Id], [Username], [Password], [Name], [Avatar], [Phone], [DateOfBirth], [IsActive], [RoleId], [StoreId], [Address]) VALUES (5, N'dattest', N'123', NULL, NULL, NULL, NULL, 1, 4, NULL, NULL)
INSERT [dbo].[Account] ([Id], [Username], [Password], [Name], [Avatar], [Phone], [DateOfBirth], [IsActive], [RoleId], [StoreId], [Address]) VALUES (6, N'dattest2', N'123', NULL, NULL, NULL, NULL, 1, 4, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Importer')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (3, N'Seller')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (4, N'Customer')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Store]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Category]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Publisher] FOREIGN KEY([PublisherId])
REFERENCES [dbo].[Publisher] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Publisher]
GO
ALTER TABLE [dbo].[BookInStore]  WITH CHECK ADD  CONSTRAINT [FK_BookInStore_Book] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([Id])
GO
ALTER TABLE [dbo].[BookInStore] CHECK CONSTRAINT [FK_BookInStore_Book]
GO
ALTER TABLE [dbo].[BookInStore]  WITH CHECK ADD  CONSTRAINT [FK_BookInStore_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[BookInStore] CHECK CONSTRAINT [FK_BookInStore_Store]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Account] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Account]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Staff] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Staff]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Book] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Book]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[RequestBook]  WITH CHECK ADD  CONSTRAINT [FK_RequestBook_Account] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[RequestBook] CHECK CONSTRAINT [FK_RequestBook_Account]
GO
ALTER TABLE [dbo].[RequestBookDetail]  WITH CHECK ADD  CONSTRAINT [FK_RequestBookDetail_Book] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([Id])
GO
ALTER TABLE [dbo].[RequestBookDetail] CHECK CONSTRAINT [FK_RequestBookDetail_Book]
GO
ALTER TABLE [dbo].[RequestBookDetail]  WITH CHECK ADD  CONSTRAINT [FK_RequestBookDetail_ReqBook] FOREIGN KEY([RequestBookId])
REFERENCES [dbo].[RequestBook] ([Id])
GO
ALTER TABLE [dbo].[RequestBookDetail] CHECK CONSTRAINT [FK_RequestBookDetail_ReqBook]
GO

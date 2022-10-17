Create Database BookStoreDB
Go
USE [BookStoreDB]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 10/17/2022 4:22:35 PM ******/
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
/****** Object:  Table [dbo].[Book]    Script Date: 10/17/2022 4:22:35 PM ******/
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
	[Avatar] [ntext] NULL,
	[Price] [money] NULL,
	[Description] [ntext] null,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookInStore]    Script Date: 10/17/2022 4:22:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookInStore](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NULL,
	[StoreId] [int] NULL,
	[Amount] [int] NULL,
 CONSTRAINT [PK_BookInStore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/17/2022 4:22:35 PM ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 10/17/2022 4:22:35 PM ******/
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
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 10/17/2022 4:22:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[BookInStoreId] [int] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 10/17/2022 4:22:35 PM ******/
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
/****** Object:  Table [dbo].[RequestBook]    Script Date: 10/17/2022 4:22:35 PM ******/
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
/****** Object:  Table [dbo].[RequestBookDetail]    Script Date: 10/17/2022 4:22:35 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 10/17/2022 4:22:35 PM ******/
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
/****** Object:  Table [dbo].[Store]    Script Date: 10/17/2022 4:22:35 PM ******/
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
INSERT [dbo].[Account] ([Id], [Username], [Password], [Name], [Avatar], [Phone], [DateOfBirth], [IsActive], [RoleId], [StoreId], [Address]) VALUES (2, N'linh', N'123', N'Do Anh Linh', N'https://scontent.fsgn5-2.fna.fbcdn.net/v/t39.30808-6/277997569_3353450438246521_7339571529235875641_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=_t1Vq70yQYcAX-17zQ2&_nc_ht=scontent.fsgn5-2.fna&oh=00_AT80jMaPQVAnKfR-D3XwUWEIIvl9MmuA26jpM62ZW2ZAjg&oe=634EE205', N'0123456789', CAST(N'2000-11-12' AS Date), 1, 2, 1, N'District 9, HCM City')
INSERT [dbo].[Account] ([Id], [Username], [Password], [Name], [Avatar], [Phone], [DateOfBirth], [IsActive], [RoleId], [StoreId], [Address]) VALUES (3, N'thang', N'123', N'Tran Ngoc Thang', N'https://scontent.fsgn5-14.fna.fbcdn.net/v/t39.30808-6/307438835_2013015145571418_6591376168230117923_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=L6rbiMjizLMAX-_K1t1&_nc_ht=scontent.fsgn5-14.fna&oh=00_AT_u7o_GhDa0e8xTbfmJDQyYd6DPNWfJy1EKiOaIu_RbmA&oe=634D4461', N'0123456789', CAST(N'2001-01-21' AS Date), 1, 3, 1, N'District 9, HCM City')
INSERT [dbo].[Account] ([Id], [Username], [Password], [Name], [Avatar], [Phone], [DateOfBirth], [IsActive], [RoleId], [StoreId], [Address]) VALUES (4, N'huy', N'123', N'Tran Minh Huy', N'https://scontent.fsgn5-5.fna.fbcdn.net/v/t39.30808-1/277582153_685497472597196_4540333871419656258_n.jpg?stp=dst-jpg_s200x200&_nc_cat=100&ccb=1-7&_nc_sid=7206a8&_nc_ohc=qmqImZaBx0UAX96u55Y&_nc_ht=scontent.fsgn5-5.fna&oh=00_AT9Ipf1Hj9MR11s_iu1Hta2irS-xEErNWN6Tee1wKSF0vQ&oe=634D7A54', N'0123456789', CAST(N'2001-04-14' AS Date), 1, 4, 1, N'Tan Binh, HCM City')
INSERT [dbo].[Account] ([Id], [Username], [Password], [Name], [Avatar], [Phone], [DateOfBirth], [IsActive], [RoleId], [StoreId], [Address]) VALUES (5, N'dattest', N'123', NULL, NULL, NULL, NULL, 1, 4, NULL, NULL)
INSERT [dbo].[Account] ([Id], [Username], [Password], [Name], [Avatar], [Phone], [DateOfBirth], [IsActive], [RoleId], [StoreId], [Address]) VALUES (6, N'dattest2', N'123', NULL, NULL, NULL, NULL, 1, 4, NULL, NULL)
INSERT [dbo].[Account] ([Id], [Username], [Password], [Name], [Avatar], [Phone], [DateOfBirth], [IsActive], [RoleId], [StoreId], [Address]) VALUES (7, N'customer14', N'1234', NULL, NULL, NULL, NULL, 1, 4, NULL, NULL)
INSERT [dbo].[Account] ([Id], [Username], [Password], [Name], [Avatar], [Phone], [DateOfBirth], [IsActive], [RoleId], [StoreId], [Address]) VALUES (8, N'cus16', N'123', NULL, NULL, NULL, NULL, 1, 4, NULL, NULL)
INSERT [dbo].[Account] ([Id], [Username], [Password], [Name], [Avatar], [Phone], [DateOfBirth], [IsActive], [RoleId], [StoreId], [Address]) VALUES (9, N'cus 17', N'123', N'cus so 17', N'https://cdn.hubs.vn/pv-blog/2020/05/14.png', N'0123456789', CAST(N'2022-10-16' AS Date), 1, 4, 1, N'HCM')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([Id], [Name], [ISBN], [Author], [ReleaseYear], [Version], [IsActive], [Amount], [CategoryId], [PublisherId], [Avatar], [Price]) VALUES (1, N'SPY X FAMILY TIỂU THUYẾT - BỨC CHÂN DUNG GIA ĐÌNH', N'978-604-2-27479-1', N'Tatsuya Endo', N'2022', 1, 1, 10, 1, 1, N'https://cdn0.fahasa.com/media/catalog/product/s/p/spy-x-family---buc-chan-dung-gia-dinh.jpg', 45000.0000)
INSERT [dbo].[Book] ([Id], [Name], [ISBN], [Author], [ReleaseYear], [Version], [IsActive], [Amount], [CategoryId], [PublisherId], [Avatar], [Price]) VALUES (2, N'KAGUYA - CUỘC CHIẾN TỎ TÌNH - TẬP 1', N'978-604-2-27584-2', N'Aka Akasaka', N'2022', 1, 1, 5, 5, 1, N'https://product.hstatic.net/200000343865/product/1_24b40a928914441d9c458639392603b4_master.jpg', 40000.0000)
INSERT [dbo].[Book] ([Id], [Name], [ISBN], [Author], [ReleaseYear], [Version], [IsActive], [Amount], [CategoryId], [PublisherId], [Avatar], [Price]) VALUES (3, N'ONE PIECE - TẬP 58', N'978-604-2-24654-5', N'Eiichiro Oda', N'2022', 1, 1, 4, 5, 1, N'https://product.hstatic.net/200000343865/product/58_309b41f9ef1744ddad2f66508c9af997_master.jpg', 25000.0000)
INSERT [dbo].[Book] ([Id], [Name], [ISBN], [Author], [ReleaseYear], [Version], [IsActive], [Amount], [CategoryId], [PublisherId], [Avatar], [Price]) VALUES (4, N'THĂNG LONG KINH KÌ - KẺ CHỢ - HÀ NỘI THỜI CẬN ĐẠI', N'978-604-2-26681-9', N'Nguyễn Quốc Tín', N'2020', 1, 1, 3, 2, 1, N'https://cdn0.fahasa.com/media/catalog/product/8/9/8935244875652.jpg', 68000.0000)
INSERT [dbo].[Book] ([Id], [Name], [ISBN], [Author], [ReleaseYear], [Version], [IsActive], [Amount], [CategoryId], [PublisherId], [Avatar], [Price]) VALUES (5, N'LƯỢC SỬ VŨ TRỤ BẰNG HÌNH - HÀNH TRÌNH VƯỢT KHÔNG GIAN VÀ THỜI GIAN', N'978-604-2-27115-8', N'Anne Rooney', N'2021', 1, 1, 12, 3, 1, N'https://cdn0.fahasa.com/media/catalog/product/8/9/8935244874785.jpg', 124000.0000)
INSERT [dbo].[Book] ([Id], [Name], [ISBN], [Author], [ReleaseYear], [Version], [IsActive], [Amount], [CategoryId], [PublisherId], [Avatar], [Price]) VALUES (6, N'HAI VẠN DẶM DƯỚI BIỂN', N'978-604-2-26329-0', N'Jules Verne     ', N'2020', 1, 1, 1, 1, 1, N'https://salt.tikicdn.com/cache/750x750/ts/product/4b/63/66/414069beb78b4dedfa17ed9b7f9779d7.jpg.webp', 60000.0000)
INSERT [dbo].[Book] ([Id], [Name], [ISBN], [Author], [ReleaseYear], [Version], [IsActive], [Amount], [CategoryId], [PublisherId], [Avatar], [Price]) VALUES (7, N'HÀNH TRÌNH BIẾN ĐỔI - NÀNG HƯƠNG TỈNH GIẤC', N'978-604-2-26879-0 ', N'Khoa Lê', N'2019', 1, 1, 5, 6, 1, N'https://salt.tikicdn.com/cache/750x750/media/catalog/product/n/a/nang-huong-tinh-giac.jpg.webp', 23000.0000)
INSERT [dbo].[Book] ([Id], [Name], [ISBN], [Author], [ReleaseYear], [Version], [IsActive], [Amount], [CategoryId], [PublisherId], [Avatar], [Price]) VALUES (8, N'TRANH TRUYỆN LỊCH SỬ VIỆT NAM - HUYỀN TRÂN CÔNG CHÚA', N'978-604-2-25286-7', N'Nguyễn Huy Thắng', N'2020', 1, 1, 2, 4, 1, N'https://product.hstatic.net/200000343865/product/huyen-tran-cong-chua_1bb65d9822b041508cb9757b8b5c3d42_master.jpg', 15000.0000)
INSERT [dbo].[Book] ([Id], [Name], [ISBN], [Author], [ReleaseYear], [Version], [IsActive], [Amount], [CategoryId], [PublisherId], [Avatar], [Price]) VALUES (9, N'ÔNG GIÀ VÀ BIỂN CẢ', N'8935244877151', N'Ernest Hemingway', N'2022', 1, 1, 5, 1, 1, N'https://cdn0.fahasa.com/media/catalog/product/8/9/8935244877151.jpg', 25000.0000)
INSERT [dbo].[Book] ([Id], [Name], [ISBN], [Author], [ReleaseYear], [Version], [IsActive], [Amount], [CategoryId], [PublisherId], [Avatar], [Price]) VALUES (10, N'BLUE FLAG - TẬP 4', N'978-604-2-27629-0', N'Kaito', N'2022', 1, 1, 100, 6, 1, N'https://cdn0.fahasa.com/media/catalog/product/b/l/blue-flag---tap-4.jpg', 40500.0000)
INSERT [dbo].[Book] ([Id], [Name], [ISBN], [Author], [ReleaseYear], [Version], [IsActive], [Amount], [CategoryId], [PublisherId], [Avatar], [Price]) VALUES (11, N'THẦN THOẠI AI CẬP', N'978-604-2-27094-6', N' Nguyễn Thị Hường', N'2022', 1, 1, 50, 4, 1, N'https://cdn0.fahasa.com/media/catalog/product/8/9/8935244877168.jpg', 108000.0000)
INSERT [dbo].[Book] ([Id], [Name], [ISBN], [Author], [ReleaseYear], [Version], [IsActive], [Amount], [CategoryId], [PublisherId], [Avatar], [Price]) VALUES (12, N' RÈN LUYỆN TƯ DUY, NÂNG CAO IQ - THỬ TÀI THÁM TỬ', N' 978-604-2-27689-4', N' Hồ Viện Viện', N'2022', 1, 1, 5, 3, 1, N'https://salt.tikicdn.com/cache/750x750/ts/product/fb/3a/04/7ae62046a57c316bf746eb9e012fdf19.jpg.webp', 45000.0000)
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (1, N'Foreign Literature', N'Foreign literature studies concerns the comprehensive research of literature in the language of the country it was written in that includes the study of the regional and historical circumstances in which it was written.')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (2, N'Traditional History', N'From the Civil War, to World Wars, to the Cold War and the Vietnam War. From Genghis Khan to Ulysses Grant. Spies, murderers, and politicians. Religion and science.')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (3, N'Science', N'A science book is a work of nonfiction, usually written by a scientist, researcher, or professor like Stephen Hawking (A Brief History of Time), or sometimes by a non-scientist such as Bill Bryson (A Short History of Nearly Everything).')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (4, N'Vietnam Literature', N'Vietnamese literature (Vietnamese: Văn học Việt Nam; Chữ Hán: 文學越南) is the literature, both oral and written, created largely by Vietnamese-speaking people.')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (5, N'Manga', N'Manga (Japanese: 漫画 [maŋga])[a] are comics or graphic novels originating from Japan. Most manga conform to a style developed in Japan in the late 19th century,[1] and the form has a long prehistory in earlier Japanese art.')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (6, N'Comic', N'Comics is a medium used to express ideas with images, often combined with text or other visual information. It typically takes the form of a sequence of panels of images.')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (8, N'Light Novel', N'A light novel (Japanese: ライトノベル, Hepburn: raito noberu; Chinese: 輕小說; Wade–Giles: Ch''ing Hsiao-shuo) is a style of young adult novel primarily targeting high school and middle school students.')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Publisher] ON 

INSERT [dbo].[Publisher] ([Id], [Name], [IsActive]) VALUES (1, N'NXBKIMDONG', 1)
INSERT [dbo].[Publisher] ([Id], [Name], [IsActive]) VALUES (2, N'Nhà xuất bản Trẻ', 1)
SET IDENTITY_INSERT [dbo].[Publisher] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Importer')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (3, N'Seller')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (4, N'Customer')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Store] ON 

INSERT [dbo].[Store] ([Id], [Name], [Address]) VALUES (1, N'Store 1', N'Quan 1, HCM')
SET IDENTITY_INSERT [dbo].[Store] OFF
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
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Book] FOREIGN KEY([BookInStoreId])
REFERENCES [dbo].[BookInStore] ([Id])
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

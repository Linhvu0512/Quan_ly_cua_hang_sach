USE [BOOKSTORE]
GO
/****** Object:  Table [dbo].[BangluongNV]    Script Date: 12/27/2020 4:53:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangluongNV](
	[Manv] [nvarchar](50) NOT NULL,
	[Macv] [nvarchar](50) NOT NULL,
	[Tennv] [nvarchar](50) NULL,
	[Thoigian] [datetime] NULL,
	[Luong] [nvarchar](50) NULL,
	[Nhanvien] [nvarchar](50) NULL,
	[Quanly] [nvarchar](50) NULL,
	[Thuong] [nvarchar](50) NULL,
	[Thanhtien] [nvarchar](50) NULL,
 CONSTRAINT [PK_BangluongNV] PRIMARY KEY CLUSTERED 
(
	[Manv] ASC,
	[Macv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chitiethoadon]    Script Date: 12/27/2020 4:53:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chitiethoadon](
	[Mahd] [nvarchar](50) NOT NULL,
	[Masp] [nvarchar](50) NOT NULL,
	[Soluong] [int] NULL,
	[Dongia] [int] NULL,
	[Tongtien] [int] NULL,
 CONSTRAINT [PK_Chitiethoadon] PRIMARY KEY CLUSTERED 
(
	[Mahd] ASC,
	[Masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chucvu]    Script Date: 12/27/2020 4:53:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chucvu](
	[Macv] [nvarchar](50) NOT NULL,
	[Tencv] [nvarchar](50) NULL,
	[Luongcoban] [nvarchar](50) NULL,
 CONSTRAINT [PK_Chucvu] PRIMARY KEY CLUSTERED 
(
	[Macv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hoadonbanhangg]    Script Date: 12/27/2020 4:53:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hoadonbanhangg](
	[Mahd] [nvarchar](50) NOT NULL,
	[Manv] [nvarchar](50) NOT NULL,
	[Tennv] [nvarchar](50) NULL,
	[Ngayban] [datetime] NULL,
	[Thanhtien] [int] NULL,
	[Tenkh] [nvarchar](50) NULL,
	[Sdt] [nvarchar](50) NULL,
 CONSTRAINT [PK_Hoadonbanhangg] PRIMARY KEY CLUSTERED 
(
	[Mahd] ASC,
	[Manv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nguoidung]    Script Date: 12/27/2020 4:53:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nguoidung](
	[Taikhoan] [nvarchar](50) NOT NULL,
	[Matkhau] [nvarchar](50) NULL,
	[Quyentruycap] [nvarchar](50) NULL,
 CONSTRAINT [PK_Nguoidung] PRIMARY KEY CLUSTERED 
(
	[Taikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sanpham]    Script Date: 12/27/2020 4:53:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sanpham](
	[Masp] [nvarchar](50) NOT NULL,
	[Tensp] [nvarchar](50) NULL,
	[Soluong] [int] NULL,
	[Dongia] [int] NULL,
	[Gianhap] [int] NULL,
	[Tonkho] [int] NULL,
 CONSTRAINT [PK_Sanpham] PRIMARY KEY CLUSTERED 
(
	[Masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Thongtinnhanvien]    Script Date: 12/27/2020 4:53:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thongtinnhanvien](
	[Manv] [nvarchar](50) NOT NULL,
	[Tennv] [nvarchar](50) NULL,
	[Gioitinh] [nvarchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
	[CMND] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
 CONSTRAINT [PK_Thongtinnhanvien] PRIMARY KEY CLUSTERED 
(
	[Manv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BangluongNV] ([Manv], [Macv], [Tennv], [Thoigian], [Luong], [Nhanvien], [Quanly], [Thuong], [Thanhtien]) VALUES (N'NV01', N'QL01', N'Vũ Mỹ Linh', CAST(N'2020-01-12T00:00:00.000' AS DateTime), N'5000000', N'0', N'1', N'200000', N'5200000')
INSERT [dbo].[BangluongNV] ([Manv], [Macv], [Tennv], [Thoigian], [Luong], [Nhanvien], [Quanly], [Thuong], [Thanhtien]) VALUES (N'NV02', N'NV01', N'Vũ Linh Chi', CAST(N'2020-07-10T00:00:00.000' AS DateTime), N'4000000', N'1', N'0', N'100000', N'4100000')
INSERT [dbo].[BangluongNV] ([Manv], [Macv], [Tennv], [Thoigian], [Luong], [Nhanvien], [Quanly], [Thuong], [Thanhtien]) VALUES (N'NV03', N'NV01', N'Mai Ngọc Anh', CAST(N'2020-12-23T15:34:38.000' AS DateTime), N'4000000', N'1', N'0', N'20000', N'4020000')
GO
INSERT [dbo].[Chitiethoadon] ([Mahd], [Masp], [Soluong], [Dongia], [Tongtien]) VALUES (N'HD01', N'SP01', 1, 10000, 10000)
INSERT [dbo].[Chitiethoadon] ([Mahd], [Masp], [Soluong], [Dongia], [Tongtien]) VALUES (N'HD02', N'SP02', 2, 150000, 300000)
INSERT [dbo].[Chitiethoadon] ([Mahd], [Masp], [Soluong], [Dongia], [Tongtien]) VALUES (N'HD03', N'SP02', 2, 150000, 300000)
INSERT [dbo].[Chitiethoadon] ([Mahd], [Masp], [Soluong], [Dongia], [Tongtien]) VALUES (N'HD04', N'SP01', 7, 10000, 70000)
INSERT [dbo].[Chitiethoadon] ([Mahd], [Masp], [Soluong], [Dongia], [Tongtien]) VALUES (N'HD05', N'SP01', 3, 10000, 30000)
GO
INSERT [dbo].[Chucvu] ([Macv], [Tencv], [Luongcoban]) VALUES (N'NV01', N'Nhanvien', N'4000000')
INSERT [dbo].[Chucvu] ([Macv], [Tencv], [Luongcoban]) VALUES (N'QL01', N'Quanlynhanvien', N'5000000')
INSERT [dbo].[Chucvu] ([Macv], [Tencv], [Luongcoban]) VALUES (N'QL02', N'Quanlybanhang', N'5200000')
INSERT [dbo].[Chucvu] ([Macv], [Tencv], [Luongcoban]) VALUES (N'QL03', N'Quanlysanpham', N'5600000')
GO
INSERT [dbo].[Hoadonbanhangg] ([Mahd], [Manv], [Tennv], [Ngayban], [Thanhtien], [Tenkh], [Sdt]) VALUES (N'HD01', N'NV01', N'Vũ Mỹ Linh', CAST(N'2020-12-11T00:00:00.000' AS DateTime), 100000, N'Dũng', N'0124578')
INSERT [dbo].[Hoadonbanhangg] ([Mahd], [Manv], [Tennv], [Ngayban], [Thanhtien], [Tenkh], [Sdt]) VALUES (N'HD02', N'NV02', N'Vũ Linh Chi', CAST(N'2020-08-14T00:00:00.000' AS DateTime), 1500000, N'Nam', N'01775523')
INSERT [dbo].[Hoadonbanhangg] ([Mahd], [Manv], [Tennv], [Ngayban], [Thanhtien], [Tenkh], [Sdt]) VALUES (N'HD03', N'NV03', N'Mai Ngọc Anh', CAST(N'2020-10-14T03:09:55.000' AS DateTime), 300000, N'An', N'01235896')
INSERT [dbo].[Hoadonbanhangg] ([Mahd], [Manv], [Tennv], [Ngayban], [Thanhtien], [Tenkh], [Sdt]) VALUES (N'HD04', N'NV04', N'Hoàng Anh', CAST(N'2020-10-06T03:09:55.000' AS DateTime), 70000, N'Tú', N'16340')
GO
INSERT [dbo].[Nguoidung] ([Taikhoan], [Matkhau], [Quyentruycap]) VALUES (N'Quanlybanhang', N'123456', N'Yes')
INSERT [dbo].[Nguoidung] ([Taikhoan], [Matkhau], [Quyentruycap]) VALUES (N'Quanlynhanvien', N'123456', N'Yes')
INSERT [dbo].[Nguoidung] ([Taikhoan], [Matkhau], [Quyentruycap]) VALUES (N'Quanlysanpham', N'123456', N'Yes')
GO
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Soluong], [Dongia], [Gianhap], [Tonkho]) VALUES (N'SP01', N'Truyện tranh', 1, 10000, 5000, 10)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Soluong], [Dongia], [Gianhap], [Tonkho]) VALUES (N'SP02', N'Truyện ngôn tình', 2, 150000, 70000, 20)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Soluong], [Dongia], [Gianhap], [Tonkho]) VALUES (N'SP03', N'SGK lớp 1', 30, 30000, 15000, 10)
GO
INSERT [dbo].[Thongtinnhanvien] ([Manv], [Tennv], [Gioitinh], [Diachi], [CMND], [SDT]) VALUES (N'NV01', N'Vũ Mỹ Linh', N'Nữ', N'Hà Nam', N'011111', N'099999')
INSERT [dbo].[Thongtinnhanvien] ([Manv], [Tennv], [Gioitinh], [Diachi], [CMND], [SDT]) VALUES (N'NV02', N'Vũ Linh Chi', N'Nữ', N'Hà Nội', N'022222', N'058999')
INSERT [dbo].[Thongtinnhanvien] ([Manv], [Tennv], [Gioitinh], [Diachi], [CMND], [SDT]) VALUES (N'NV03', N'Mai Ngọc Anh', N'Nam', N'Hà Nội', N'025890', N'021479')
INSERT [dbo].[Thongtinnhanvien] ([Manv], [Tennv], [Gioitinh], [Diachi], [CMND], [SDT]) VALUES (N'NV04', N'Hoàng Anh', N'Nam', N'Nam Định', N'0147852', N'01236589')
GO

CREATE DATABASE [Toko_Buku]
GO
USE [Toko_Buku]
GO
/****** Object:  Table [dbo].[Checkout]    Script Date: 2/15/2024 9:16:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Checkout](
	[Nama_Pelanggan] [varchar](50) NULL,
	[Judul] [varchar](50) NULL,
	[Jumlah] [int] NULL,
	[Tanggal_Pembelian] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 2/15/2024 9:16:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[id_User] [int] NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 2/15/2024 9:16:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Isbn] [int] NULL,
	[Judul] [varchar](50) NULL,
	[Penulis] [varchar](50) NULL,
	[Stok] [int] NULL,
	[Harga] [int] NULL
) ON [PRIMARY]
GO

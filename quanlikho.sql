create database quanlikhocuahang

create table NHACUNGCAP
(
MANHACUNGCAP nvarchar(50) primary key,
TENNHACUNGCAP nvarchar(100),
DIACHI nvarchar(100),
DIENTHOAI nvarchar(15)
)

create table NHANVIEN
(
MANV nvarchar(50) primary key,
TENNV nvarchar(100),
DIACHI nvarchar(100),
DIENTHOAI nvarchar(15),
NGAYSINH datetime,
MATKHAU nvarchar(30),
PHANQUYEN bit
)

create table LOAI
(
MALOAI nvarchar(15) primary key,
TENLOAI nvarchar(50) unique
)

create table SANPHAM
(
MASP nvarchar(50) primary key,
HINHANH nvarchar(100),
TENSP nvarchar(100) unique,
LOAISP nvarchar(15),
HANSUDUNG nvarchar(10),
foreign key (LOAISP) references LOAI(MALOAI)
)

create table PHIEUNHAPHANG
(
MANHAPHANG int primary key IDENTITY(1,1),
NGAYNHAPHANG datetime,
MANHACUNGCAP nvarchar(50),
MANV nvarchar(50),

foreign key(MANHACUNGCAP) references NHACUNGCAP(MANHACUNGCAP),
foreign key(MANV) references NHANVIEN(MANV)
)

create table TONKHO
(
STT int primary key IDENTITY(1,1),
MANHAPHANG int not null,
MASP nvarchar(50) not null,
NGAYHETHAN datetime null,
SOLUONGNHAP int,
SOLUONGTON int,
DONGIANHAP decimal (10),

unique(MANHAPHANG,MASP),
foreign key(MASP) references SANPHAM(MASP),
foreign key(MANHAPHANG) references PHIEUNHAPHANG(MANHAPHANG)
)

create table XUATKHO
(
STT int primary key IDENTITY(1,1),
MATONKHO int not null,
SOLUONGXUAT int,
NGAYXUAT datetime,
DONGIAXUAT decimal(10)

foreign key(MATONKHO) references TONKHO(STT),
)

--insert into THANHPHO values(N'HCM',N'Hồ Chí Minh')
--insert into THANHPHO values(N'HN',N'Hà Nội')
--insert into THANHPHO values(N'DN',N'Đà Nẵng')
--insert into THANHPHO values(N'VT',N'Vũng Tàu')
--insert into THANHPHO values(N'H',N'Huế')


insert into NHANVIEN (MANV,TENNV, MATKHAU) values(N'123456789',N'admin',N'123456')

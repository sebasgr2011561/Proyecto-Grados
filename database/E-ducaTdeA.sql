﻿USE [E-ducaTDA]
GO
ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_Usuarios_Roles]
GO
ALTER TABLE [dbo].[Rutas] DROP CONSTRAINT [FK_Rutas_Usuarios]
GO
ALTER TABLE [dbo].[Rutas] DROP CONSTRAINT [FK_Rutas_Recursos]
GO
ALTER TABLE [dbo].[Recursos] DROP CONSTRAINT [FK_Recursos_Usuarios]
GO
ALTER TABLE [dbo].[Recursos] DROP CONSTRAINT [FK_Recursos_Categoria]
GO
ALTER TABLE [dbo].[Permisos] DROP CONSTRAINT [FK_Permisos_Roles]
GO
ALTER TABLE [dbo].[Calificaciones] DROP CONSTRAINT [FK_Calificaciones_Usuarios]
GO
ALTER TABLE [dbo].[Calificaciones] DROP CONSTRAINT [FK_Calificaciones_Recursos]
GO
ALTER TABLE [dbo].[Asignacion] DROP CONSTRAINT [FK_Asignacion_Usuarios]
GO
ALTER TABLE [dbo].[Asignacion] DROP CONSTRAINT [FK_Asignacion_Recursos]
GO
/****** Object:  Index [IX_Usuarios_IdRol]    Script Date: 24/04/2024 8:10:57 p. m. ******/
DROP INDEX [IX_Usuarios_IdRol] ON [dbo].[Usuarios]
GO
/****** Object:  Index [IX_Rutas_IdRecurso]    Script Date: 24/04/2024 8:10:57 p. m. ******/
DROP INDEX [IX_Rutas_IdRecurso] ON [dbo].[Rutas]
GO
/****** Object:  Index [IX_Rutas_IdEstudiante]    Script Date: 24/04/2024 8:10:57 p. m. ******/
DROP INDEX [IX_Rutas_IdEstudiante] ON [dbo].[Rutas]
GO
/****** Object:  Index [IX_Recursos_IdProfesor]    Script Date: 24/04/2024 8:10:57 p. m. ******/
DROP INDEX [IX_Recursos_IdProfesor] ON [dbo].[Recursos]
GO
/****** Object:  Index [IX_Recursos_IdCategoria]    Script Date: 24/04/2024 8:10:57 p. m. ******/
DROP INDEX [IX_Recursos_IdCategoria] ON [dbo].[Recursos]
GO
/****** Object:  Index [IX_Permisos_IdRol]    Script Date: 24/04/2024 8:10:57 p. m. ******/
DROP INDEX [IX_Permisos_IdRol] ON [dbo].[Permisos]
GO
/****** Object:  Index [IX_Calificaciones_IdUsuario]    Script Date: 24/04/2024 8:10:57 p. m. ******/
DROP INDEX [IX_Calificaciones_IdUsuario] ON [dbo].[Calificaciones]
GO
/****** Object:  Index [IX_Calificaciones_IdRecurso1]    Script Date: 24/04/2024 8:10:57 p. m. ******/
DROP INDEX [IX_Calificaciones_IdRecurso1] ON [dbo].[Calificaciones]
GO
/****** Object:  Index [IX_Asignacion_IdRecurso]    Script Date: 24/04/2024 8:10:57 p. m. ******/
DROP INDEX [IX_Asignacion_IdRecurso] ON [dbo].[Asignacion]
GO
/****** Object:  Index [IX_Asignacion_IdEstudiante]    Script Date: 24/04/2024 8:10:57 p. m. ******/
DROP INDEX [IX_Asignacion_IdEstudiante] ON [dbo].[Asignacion]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 24/04/2024 8:10:57 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
DROP TABLE [dbo].[Usuarios]
GO
/****** Object:  Table [dbo].[Rutas]    Script Date: 24/04/2024 8:10:57 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rutas]') AND type in (N'U'))
DROP TABLE [dbo].[Rutas]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 24/04/2024 8:10:57 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[Recursos]    Script Date: 24/04/2024 8:10:57 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Recursos]') AND type in (N'U'))
DROP TABLE [dbo].[Recursos]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 24/04/2024 8:10:57 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Permisos]') AND type in (N'U'))
DROP TABLE [dbo].[Permisos]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 24/04/2024 8:10:57 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categoria]') AND type in (N'U'))
DROP TABLE [dbo].[Categoria]
GO
/****** Object:  Table [dbo].[Calificaciones]    Script Date: 24/04/2024 8:10:57 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Calificaciones]') AND type in (N'U'))
DROP TABLE [dbo].[Calificaciones]
GO
/****** Object:  Table [dbo].[Asignacion]    Script Date: 24/04/2024 8:10:57 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Asignacion]') AND type in (N'U'))
DROP TABLE [dbo].[Asignacion]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 24/04/2024 8:10:57 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
USE [master]
GO
/****** Object:  Database [E-ducaTDA]    Script Date: 24/04/2024 8:10:57 p. m. ******/
DROP DATABASE [E-ducaTDA]
GO
/****** Object:  Database [E-ducaTDA]    Script Date: 24/04/2024 8:10:57 p. m. ******/
CREATE DATABASE [E-ducaTDA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'E-ducaTDA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLDEV\MSSQL\DATA\E-ducaTDA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'E-ducaTDA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLDEV\MSSQL\DATA\E-ducaTDA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [E-ducaTDA] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [E-ducaTDA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [E-ducaTDA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [E-ducaTDA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [E-ducaTDA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [E-ducaTDA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [E-ducaTDA] SET ARITHABORT OFF 
GO
ALTER DATABASE [E-ducaTDA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [E-ducaTDA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [E-ducaTDA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [E-ducaTDA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [E-ducaTDA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [E-ducaTDA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [E-ducaTDA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [E-ducaTDA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [E-ducaTDA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [E-ducaTDA] SET  ENABLE_BROKER 
GO
ALTER DATABASE [E-ducaTDA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [E-ducaTDA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [E-ducaTDA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [E-ducaTDA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [E-ducaTDA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [E-ducaTDA] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [E-ducaTDA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [E-ducaTDA] SET RECOVERY FULL 
GO
ALTER DATABASE [E-ducaTDA] SET  MULTI_USER 
GO
ALTER DATABASE [E-ducaTDA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [E-ducaTDA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [E-ducaTDA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [E-ducaTDA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [E-ducaTDA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [E-ducaTDA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'E-ducaTDA', N'ON'
GO
ALTER DATABASE [E-ducaTDA] SET QUERY_STORE = ON
GO
ALTER DATABASE [E-ducaTDA] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [E-ducaTDA]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 24/04/2024 8:10:58 p. m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asignacion]    Script Date: 24/04/2024 8:10:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignacion](
	[IdAsignacion] [int] IDENTITY(1,1) NOT NULL,
	[IdEstudiante] [int] NOT NULL,
	[IdRecurso] [int] NOT NULL,
	[FechaAsignacion] [datetime] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Asignacion] PRIMARY KEY CLUSTERED 
(
	[IdAsignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calificaciones]    Script Date: 24/04/2024 8:10:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificaciones](
	[IdRecurso] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdRecurso1] [int] NOT NULL,
	[Calificacion] [int] NULL,
	[Comentario] [nvarchar](max) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Calificaciones] PRIMARY KEY CLUSTERED 
(
	[IdRecurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 24/04/2024 8:10:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[NombreCategoria] [varchar](50) NOT NULL,
	[ImagenCategoria] [nvarchar](max) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 24/04/2024 8:10:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NOT NULL,
	[Permiso] [varchar](50) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recursos]    Script Date: 24/04/2024 8:10:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recursos](
	[IdRecurso] [int] IDENTITY(1,1) NOT NULL,
	[IdProfesor] [int] NOT NULL,
	[NombreRecurso] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[ImagenPortada] [nvarchar](max) NULL,
	[Duracion] [int] NULL,
	[Precio] [float] NULL,
	[IdCategoria] [int] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Recursos] PRIMARY KEY CLUSTERED 
(
	[IdRecurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 24/04/2024 8:10:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rutas]    Script Date: 24/04/2024 8:10:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rutas](
	[IdRuta] [int] IDENTITY(1,1) NOT NULL,
	[IdEstudiante] [int] NOT NULL,
	[IdRecurso] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Rutas] PRIMARY KEY CLUSTERED 
(
	[IdRuta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 24/04/2024 8:10:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NOT NULL,
	[Nombres] [nvarchar](50) NOT NULL,
	[Apellidos] [nvarchar](100) NOT NULL,
	[Celular] [nvarchar](10) NULL,
	[Biografia] [nvarchar](max) NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Imagen] [nvarchar](max) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240405020248_Initial-migration', N'8.0.2')
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([IdCategoria], [NombreCategoria], [ImagenCategoria], [Estado]) VALUES (1, N'Desarrollo Web', N'', 1)
INSERT [dbo].[Categoria] ([IdCategoria], [NombreCategoria], [ImagenCategoria], [Estado]) VALUES (2, N'Desarrollo Web Back', N'', 1)
INSERT [dbo].[Categoria] ([IdCategoria], [NombreCategoria], [ImagenCategoria], [Estado]) VALUES (3, N'Bases de Datos', N'', 1)
INSERT [dbo].[Categoria] ([IdCategoria], [NombreCategoria], [ImagenCategoria], [Estado]) VALUES (4, N'Boostrap', N'', 1)
INSERT [dbo].[Categoria] ([IdCategoria], [NombreCategoria], [ImagenCategoria], [Estado]) VALUES (5, N'Logica de Programación', N'', 1)
INSERT [dbo].[Categoria] ([IdCategoria], [NombreCategoria], [ImagenCategoria], [Estado]) VALUES (6, N'IA', N'', 1)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Recursos] ON 

INSERT [dbo].[Recursos] ([IdRecurso], [IdProfesor], [NombreRecurso], [Descripcion], [ImagenPortada], [IdCategoria], [Estado]) VALUES (14, 2, N'Introducción JavaScript', N'', N'', 1, 1)
INSERT [dbo].[Recursos] ([IdRecurso], [IdProfesor], [NombreRecurso], [Descripcion], [ImagenPortada], [IdCategoria], [Estado]) VALUES (15, 2, N'Introducción HTML y CSS', N'', N'', 1, 1)
INSERT [dbo].[Recursos] ([IdRecurso], [IdProfesor], [NombreRecurso], [Descripcion], [ImagenPortada], [IdCategoria], [Estado]) VALUES (16, 2, N'Aprende ASP.NET Core MVC 6', N'', N'', 2, 1)
INSERT [dbo].[Recursos] ([IdRecurso], [IdProfesor], [NombreRecurso], [Descripcion], [ImagenPortada], [IdCategoria], [Estado]) VALUES (17, 2, N'Master ASP.NET Core', N'', N'', 2, 1)
INSERT [dbo].[Recursos] ([IdRecurso], [IdProfesor], [NombreRecurso], [Descripcion], [ImagenPortada], [IdCategoria], [Estado]) VALUES (18, 2, N'Gestión avanzada de Datos con MongoDB', N'', N'', 3, 1)
INSERT [dbo].[Recursos] ([IdRecurso], [IdProfesor], [NombreRecurso], [Descripcion], [ImagenPortada], [IdCategoria], [Estado]) VALUES (19, 2, N'SQL - Consultas en Microsoft SQL', N'', N'', 3, 1)
INSERT [dbo].[Recursos] ([IdRecurso], [IdProfesor], [NombreRecurso], [Descripcion], [ImagenPortada], [IdCategoria], [Estado]) VALUES (20, 2, N'Boostrap 4', N'', N'', 4, 1)
INSERT [dbo].[Recursos] ([IdRecurso], [IdProfesor], [NombreRecurso], [Descripcion], [ImagenPortada], [IdCategoria], [Estado]) VALUES (21, 2, N'Boostrap 5', N'', N'', 4, 1)
INSERT [dbo].[Recursos] ([IdRecurso], [IdProfesor], [NombreRecurso], [Descripcion], [ImagenPortada], [IdCategoria], [Estado]) VALUES (22, 2, N'Master en logica de programación', N'', N'', 5, 1)
INSERT [dbo].[Recursos] ([IdRecurso], [IdProfesor], [NombreRecurso], [Descripcion], [ImagenPortada], [IdCategoria], [Estado]) VALUES (23, 2, N'Expresiones regulares', N'', N'', 5, 1)
INSERT [dbo].[Recursos] ([IdRecurso], [IdProfesor], [NombreRecurso], [Descripcion], [ImagenPortada], [IdCategoria], [Estado]) VALUES (24, 2, N'Master IA generativa', N'', N'', 6, 1)
INSERT [dbo].[Recursos] ([IdRecurso], [IdProfesor], [NombreRecurso], [Descripcion], [ImagenPortada], [IdCategoria], [Estado]) VALUES (25, 2, N'Curso completo de IA', N'', N'', 6, 1)
SET IDENTITY_INSERT [dbo].[Recursos] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([IdRol], [Descripcion], [Estado]) VALUES (1, N'Administrador', 1)
INSERT [dbo].[Roles] ([IdRol], [Descripcion], [Estado]) VALUES (2, N'Profesor', 1)
INSERT [dbo].[Roles] ([IdRol], [Descripcion], [Estado]) VALUES (3, N'Estudiante', 1)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [IdRol], [Nombres], [Apellidos], [Celular], [Biografia], [Email], [Password], [Imagen], [Estado]) VALUES (1, 1, N'Administrador', N'TdeA', N'123456789', N'Admin123*', N'Admin', N'$2a$11$bNsqi8hHUfpuKur4VVuNIu9gbiEek3RqMrzbg.4IpwmG8GeMamtr2', N'null', 1)
INSERT [dbo].[Usuarios] ([IdUsuario], [IdRol], [Nombres], [Apellidos], [Celular], [Biografia], [Email], [Password], [Imagen], [Estado]) VALUES (2, 2, N'Profesor', N'TdeA', N'123456789', N'Admin123*', N'Profesor', N'$2a$11$OkZPqpZ9/zJNZ2xmjSZTO.LgbBsVWFJPH4mynM8kwEvi.h6rvKUWe', N'null', 1)
INSERT [dbo].[Usuarios] ([IdUsuario], [IdRol], [Nombres], [Apellidos], [Celular], [Biografia], [Email], [Password], [Imagen], [Estado]) VALUES (3, 3, N'Estudiante', N'TdeA', N'123456789', N'Admin123*', N'Estudiante', N'$2a$11$pfFLVX8sPAPeCARJvE6gJe60hiFau7V5BhXIybxvDZMtd79Ii1WfK', N'null', 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
/****** Object:  Index [IX_Asignacion_IdEstudiante]    Script Date: 24/04/2024 8:10:58 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Asignacion_IdEstudiante] ON [dbo].[Asignacion]
(
	[IdEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Asignacion_IdRecurso]    Script Date: 24/04/2024 8:10:58 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Asignacion_IdRecurso] ON [dbo].[Asignacion]
(
	[IdRecurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Calificaciones_IdRecurso1]    Script Date: 24/04/2024 8:10:58 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Calificaciones_IdRecurso1] ON [dbo].[Calificaciones]
(
	[IdRecurso1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Calificaciones_IdUsuario]    Script Date: 24/04/2024 8:10:58 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Calificaciones_IdUsuario] ON [dbo].[Calificaciones]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Permisos_IdRol]    Script Date: 24/04/2024 8:10:58 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Permisos_IdRol] ON [dbo].[Permisos]
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Recursos_IdCategoria]    Script Date: 24/04/2024 8:10:58 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Recursos_IdCategoria] ON [dbo].[Recursos]
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Recursos_IdProfesor]    Script Date: 24/04/2024 8:10:58 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Recursos_IdProfesor] ON [dbo].[Recursos]
(
	[IdProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rutas_IdEstudiante]    Script Date: 24/04/2024 8:10:58 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Rutas_IdEstudiante] ON [dbo].[Rutas]
(
	[IdEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rutas_IdRecurso]    Script Date: 24/04/2024 8:10:58 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Rutas_IdRecurso] ON [dbo].[Rutas]
(
	[IdRecurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuarios_IdRol]    Script Date: 24/04/2024 8:10:58 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Usuarios_IdRol] ON [dbo].[Usuarios]
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Asignacion]  WITH CHECK ADD  CONSTRAINT [FK_Asignacion_Recursos] FOREIGN KEY([IdRecurso])
REFERENCES [dbo].[Recursos] ([IdRecurso])
GO
ALTER TABLE [dbo].[Asignacion] CHECK CONSTRAINT [FK_Asignacion_Recursos]
GO
ALTER TABLE [dbo].[Asignacion]  WITH CHECK ADD  CONSTRAINT [FK_Asignacion_Usuarios] FOREIGN KEY([IdEstudiante])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Asignacion] CHECK CONSTRAINT [FK_Asignacion_Usuarios]
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Calificaciones_Recursos] FOREIGN KEY([IdRecurso1])
REFERENCES [dbo].[Recursos] ([IdRecurso])
GO
ALTER TABLE [dbo].[Calificaciones] CHECK CONSTRAINT [FK_Calificaciones_Recursos]
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Calificaciones_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Calificaciones] CHECK CONSTRAINT [FK_Calificaciones_Usuarios]
GO
ALTER TABLE [dbo].[Permisos]  WITH CHECK ADD  CONSTRAINT [FK_Permisos_Roles] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([IdRol])
GO
ALTER TABLE [dbo].[Permisos] CHECK CONSTRAINT [FK_Permisos_Roles]
GO
ALTER TABLE [dbo].[Recursos]  WITH CHECK ADD  CONSTRAINT [FK_Recursos_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Recursos] CHECK CONSTRAINT [FK_Recursos_Categoria]
GO
ALTER TABLE [dbo].[Recursos]  WITH CHECK ADD  CONSTRAINT [FK_Recursos_Usuarios] FOREIGN KEY([IdProfesor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Recursos] CHECK CONSTRAINT [FK_Recursos_Usuarios]
GO
ALTER TABLE [dbo].[Rutas]  WITH CHECK ADD  CONSTRAINT [FK_Rutas_Recursos] FOREIGN KEY([IdRecurso])
REFERENCES [dbo].[Recursos] ([IdRecurso])
GO
ALTER TABLE [dbo].[Rutas] CHECK CONSTRAINT [FK_Rutas_Recursos]
GO
ALTER TABLE [dbo].[Rutas]  WITH CHECK ADD  CONSTRAINT [FK_Rutas_Usuarios] FOREIGN KEY([IdEstudiante])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Rutas] CHECK CONSTRAINT [FK_Rutas_Usuarios]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([IdRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
USE [master]
GO
ALTER DATABASE [E-ducaTDA] SET  READ_WRITE 
GO

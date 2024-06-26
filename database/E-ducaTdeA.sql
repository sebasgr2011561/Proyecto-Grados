USE [master]
GO
/****** Object:  Database [E-ducaTdeA]    Script Date: 16/05/2024 1:45:19 a. m. ******/
CREATE DATABASE [E-ducaTdeA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'E-ducaTdeA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.HAMILTONDEVTECH\MSSQL\DATA\E-ducaTdeA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'E-ducaTdeA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.HAMILTONDEVTECH\MSSQL\DATA\E-ducaTdeA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [E-ducaTdeA] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [E-ducaTdeA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [E-ducaTdeA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET ARITHABORT OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [E-ducaTdeA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [E-ducaTdeA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET  ENABLE_BROKER 
GO
ALTER DATABASE [E-ducaTdeA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [E-ducaTdeA] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [E-ducaTdeA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET RECOVERY FULL 
GO
ALTER DATABASE [E-ducaTdeA] SET  MULTI_USER 
GO
ALTER DATABASE [E-ducaTdeA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [E-ducaTdeA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [E-ducaTdeA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [E-ducaTdeA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [E-ducaTdeA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [E-ducaTdeA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'E-ducaTdeA', N'ON'
GO
ALTER DATABASE [E-ducaTdeA] SET QUERY_STORE = ON
GO
ALTER DATABASE [E-ducaTdeA] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [E-ducaTdeA]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 16/05/2024 1:45:19 a. m. ******/
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
/****** Object:  Table [dbo].[Asignacion]    Script Date: 16/05/2024 1:45:19 a. m. ******/
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
/****** Object:  Table [dbo].[Calificaciones]    Script Date: 16/05/2024 1:45:19 a. m. ******/
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
/****** Object:  Table [dbo].[Categoria]    Script Date: 16/05/2024 1:45:19 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[NombreCategoria] [varchar](255) NOT NULL,
	[ImagenCategoria] [nvarchar](max) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulos]    Script Date: 16/05/2024 1:45:19 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulos](
	[IdModulo] [int] IDENTITY(1,1) NOT NULL,
	[IdRecurso] [int] NOT NULL,
	[NombreModulo] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[URLModulo] [nvarchar](255) NOT NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 16/05/2024 1:45:19 a. m. ******/
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
/****** Object:  Table [dbo].[Recursos]    Script Date: 16/05/2024 1:45:19 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recursos](
	[IdRecurso] [int] IDENTITY(1,1) NOT NULL,
	[IdProfesor] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[NombreRecurso] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[ImagenPortada] [nvarchar](max) NULL,
	[Duracion] [int] NULL,
	[Precio] [float] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Recursos] PRIMARY KEY CLUSTERED 
(
	[IdRecurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 16/05/2024 1:45:19 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rutas]    Script Date: 16/05/2024 1:45:19 a. m. ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 16/05/2024 1:45:19 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NOT NULL,
	[Nombres] [nvarchar](50) NOT NULL,
	[Apellidos] [nvarchar](150) NOT NULL,
	[Celular] [nvarchar](max) NULL,
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
/****** Object:  Index [IX_Asignacion_IdEstudiante]    Script Date: 16/05/2024 1:45:19 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Asignacion_IdEstudiante] ON [dbo].[Asignacion]
(
	[IdEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Asignacion_IdRecurso]    Script Date: 16/05/2024 1:45:19 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Asignacion_IdRecurso] ON [dbo].[Asignacion]
(
	[IdRecurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Calificaciones_IdRecurso1]    Script Date: 16/05/2024 1:45:19 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Calificaciones_IdRecurso1] ON [dbo].[Calificaciones]
(
	[IdRecurso1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Calificaciones_IdUsuario]    Script Date: 16/05/2024 1:45:19 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Calificaciones_IdUsuario] ON [dbo].[Calificaciones]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Permisos_IdRol]    Script Date: 16/05/2024 1:45:19 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Permisos_IdRol] ON [dbo].[Permisos]
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Recursos_IdCategoria]    Script Date: 16/05/2024 1:45:19 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Recursos_IdCategoria] ON [dbo].[Recursos]
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Recursos_IdProfesor]    Script Date: 16/05/2024 1:45:19 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Recursos_IdProfesor] ON [dbo].[Recursos]
(
	[IdProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rutas_IdEstudiante]    Script Date: 16/05/2024 1:45:19 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Rutas_IdEstudiante] ON [dbo].[Rutas]
(
	[IdEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rutas_IdRecurso]    Script Date: 16/05/2024 1:45:19 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Rutas_IdRecurso] ON [dbo].[Rutas]
(
	[IdRecurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuarios_IdRol]    Script Date: 16/05/2024 1:45:19 a. m. ******/
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
ALTER TABLE [dbo].[Modulos]  WITH CHECK ADD  CONSTRAINT [FK_Modulos_Recursos1] FOREIGN KEY([IdRecurso])
REFERENCES [dbo].[Recursos] ([IdRecurso])
GO
ALTER TABLE [dbo].[Modulos] CHECK CONSTRAINT [FK_Modulos_Recursos1]
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
ALTER DATABASE [E-ducaTdeA] SET  READ_WRITE 
GO

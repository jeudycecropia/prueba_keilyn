--/////////////////////////////////
--CREACIÓN DE LA BASE DE DATOS
--/////////////////////////////////

/****** Object:  Database [AutenticacionUsuario]    Script Date: 03/31/2013 15:30:06 ******/
CREATE DATABASE [AutenticacionUsuario] ON  PRIMARY 
( NAME = N'AutenticacionUsuario', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\AutenticacionUsuario.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AutenticacionUsuario_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\AutenticacionUsuario_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [AutenticacionUsuario] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AutenticacionUsuario].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [AutenticacionUsuario] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET ARITHABORT OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [AutenticacionUsuario] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [AutenticacionUsuario] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [AutenticacionUsuario] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET  DISABLE_BROKER 
GO

ALTER DATABASE [AutenticacionUsuario] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [AutenticacionUsuario] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [AutenticacionUsuario] SET  READ_WRITE 
GO

ALTER DATABASE [AutenticacionUsuario] SET RECOVERY FULL 
GO

ALTER DATABASE [AutenticacionUsuario] SET  MULTI_USER 
GO

ALTER DATABASE [AutenticacionUsuario] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [AutenticacionUsuario] SET DB_CHAINING OFF 
GO




--/////////////////////////////////
--CREACIÓN DE LA TABLA
--/////////////////////////////////

USE [AutenticacionUsuario]
GO

/****** Object:  Table [dbo].[PerfilUsuario]    Script Date: 03/31/2013 15:30:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PerfilUsuario](
	[sId] [varchar](50) NOT NULL,
	[sPassword] [varchar](50) NOT NULL,
	[sNombre] [varchar](50) NOT NULL,
	[sApellidos] [varchar](100) NOT NULL,
	[sEmail] [varchar](50) NOT NULL,
	[sDireccion] [varchar](max) NOT NULL,
	[sTelefono] [varchar](20) NOT NULL,
 CONSTRAINT [PK_PerfilUsuario] PRIMARY KEY CLUSTERED 
(
	[sId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO





--/////////////////////////////////
--INSERCIÓN DE UN PERFIL
--/////////////////////////////////
INSERT INTO [AutenticacionUsuario].[dbo].[PerfilUsuario]
           ([sId]
           ,[sPassword]
           ,[sNombre]
           ,[sApellidos]
           ,[sEmail]
           ,[sDireccion]
           ,[sTelefono])
     VALUES
           ('khidalgo'
           ,'123'
           ,'Keylin'
           ,'Hidalgo'
           ,'khidalgo@proyecto.com'
           ,'Costa Rica'
           ,'88776655')
GO





--/////////////////////////////////
--CREACIÓN DEL PROCEDIMIENTO ALMACENADO
--/////////////////////////////////

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Keylin Hidalgo
-- Create date: 31 marzo 2013
-- Description:	Obtiene el perfil de un usuario por id y password
-- =============================================
CREATE PROCEDURE sp_ConsultarPerfil 
@sId varchar(50)
,@sPassword varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT 
		[sNombre]
		,[sApellidos]
		,[sEmail]
		,[sDireccion]
		,[sTelefono]
  FROM [AutenticacionUsuario].[dbo].[PerfilUsuario]
  WHERE [sId] = @sId AND [sPassword] = @sPassword
  COLLATE SQL_Latin1_General_CP1_CI_AS
  
END
GO

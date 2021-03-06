USE [master]
GO
/****** Object:  Database [GerenciamentoClientes]    Script Date: 12/12/2021 14:39:20 ******/
CREATE DATABASE [GerenciamentoClientes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GerenciamentoClientes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\GerenciamentoClientes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GerenciamentoClientes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\GerenciamentoClientes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GerenciamentoClientes] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GerenciamentoClientes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GerenciamentoClientes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET ARITHABORT OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GerenciamentoClientes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GerenciamentoClientes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GerenciamentoClientes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GerenciamentoClientes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GerenciamentoClientes] SET  MULTI_USER 
GO
ALTER DATABASE [GerenciamentoClientes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GerenciamentoClientes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GerenciamentoClientes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GerenciamentoClientes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GerenciamentoClientes] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GerenciamentoClientes] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GerenciamentoClientes] SET QUERY_STORE = OFF
GO
USE [GerenciamentoClientes]
GO
/****** Object:  User [teste]    Script Date: 12/12/2021 14:39:20 ******/
CREATE USER [teste] FOR LOGIN [teste] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [teste]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 12/12/2021 14:39:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[RazaoSocial] [varchar](50) NOT NULL,
	[Cnpj] [varchar](18) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_TabClientes] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [GerenciamentoClientes] SET  READ_WRITE 
GO

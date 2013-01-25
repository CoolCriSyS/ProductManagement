﻿USE [master]
GO

/****** Object:  Database [B2BProductCatalog]    Script Date: 02/14/2011 09:21:36 ******/
CREATE DATABASE [B2BProductCatalog] ON  PRIMARY 
( NAME = N'B2BProductCatalog', FILENAME = N'D:\MSSQL\Database\B2BProductCatalog.mdf' , SIZE = 12288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 2048KB )
 LOG ON 
( NAME = N'B2BProductCatalog_log', FILENAME = N'D:\MSSQL\Logs\B2BProductCatalog_log.ldf' , SIZE = 84352KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [B2BProductCatalog] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [B2BProductCatalog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [B2BProductCatalog] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET ARITHABORT OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [B2BProductCatalog] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [B2BProductCatalog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [B2BProductCatalog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET  DISABLE_BROKER 
GO

ALTER DATABASE [B2BProductCatalog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [B2BProductCatalog] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [B2BProductCatalog] SET  READ_WRITE 
GO

ALTER DATABASE [B2BProductCatalog] SET RECOVERY FULL 
GO

ALTER DATABASE [B2BProductCatalog] SET  MULTI_USER 
GO

ALTER DATABASE [B2BProductCatalog] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [B2BProductCatalog] SET DB_CHAINING OFF 
GO



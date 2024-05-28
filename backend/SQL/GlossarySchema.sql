use master
go
alter database [Glossary] set single_user with rollback immediate
go
drop database [Glossary]
go



CREATE DATABASE [Glossary]
GO

USE [Glossary]
GO

CREATE TABLE [Term](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [varchar](50) NULL,
)
GO

CREATE TABLE [Definition](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Description] [varchar](1000) NULL,
	[TermId] [int] UNIQUE NOT NULL,
)
GO

ALTER TABLE [Definition]  WITH CHECK ADD  CONSTRAINT [fk_term] FOREIGN KEY([TermId])
REFERENCES [Term] ([Id])
GO
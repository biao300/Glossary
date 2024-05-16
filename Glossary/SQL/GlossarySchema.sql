CREATE DATABASE [Glossary]
GO

USE [Glossary]
GO

CREATE TABLE [Term](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [varchar](200) NULL,
)
GO

CREATE TABLE [Definition](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Description] [varchar](max) NULL,
	[TermId] [int] UNIQUE NOT NULL,
)
GO

ALTER TABLE [Definition]  WITH CHECK ADD  CONSTRAINT [fk_term] FOREIGN KEY([TermId])
REFERENCES [Term] ([Id])
GO
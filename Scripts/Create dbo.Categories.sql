USE [SistemaDb]
GO

/****** Object: Table [dbo].[Categories] Script Date: 05/04/2023 14:03:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categories] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [Situation] BIT            NOT NULL
);



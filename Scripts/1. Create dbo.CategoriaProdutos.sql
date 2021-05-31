USE [Api]
GO

/****** Object: Table [dbo].[CategoriaProdutos] Script Date: 31/05/2021 1:41:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CategoriaProdutos] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [Descricao] VARCHAR (20)     NOT NULL
);



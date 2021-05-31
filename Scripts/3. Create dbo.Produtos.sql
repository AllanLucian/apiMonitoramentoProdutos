USE [Api]
GO

/****** Object: Table [dbo].[Produtos] Script Date: 31/05/2021 1:42:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Produtos] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [CategoriaProdutoId] UNIQUEIDENTIFIER NOT NULL,
    [Nome]               VARCHAR (200)    NOT NULL,
    [Valor]              DECIMAL (5, 2)   NOT NULL,
    [Quantidade]         INT              NOT NULL,
    [DataCadastro]       DATETIME2 (7)    NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_Produtos_CategoriaProdutoId]
    ON [dbo].[Produtos]([CategoriaProdutoId] ASC);


GO
ALTER TABLE [dbo].[Produtos]
    ADD CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED ([Id] ASC);


GO
ALTER TABLE [dbo].[Produtos]
    ADD CONSTRAINT [FK_Produtos_CategoriaProdutos_CategoriaProdutoId] FOREIGN KEY ([CategoriaProdutoId]) REFERENCES [dbo].[CategoriaProdutos] ([Id]);



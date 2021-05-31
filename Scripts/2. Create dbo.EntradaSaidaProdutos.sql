USE [Api]
GO

/****** Object: Table [dbo].[EntradaSaidaProdutos] Script Date: 31/05/2021 1:46:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EntradaSaidaProdutos] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [ProdutoId]   UNIQUEIDENTIFIER NOT NULL,
    [Quantidade]  INT              NOT NULL,
    [Operacao]    VARCHAR (100)    NOT NULL,
    [Responsavel] VARCHAR (200)    NOT NULL,
    [Data]        DATETIME2 (7)    NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_EntradaSaidaProdutos_ProdutoId]
    ON [dbo].[EntradaSaidaProdutos]([ProdutoId] ASC);


GO
ALTER TABLE [dbo].[EntradaSaidaProdutos]
    ADD CONSTRAINT [PK_EntradaSaidaProdutos] PRIMARY KEY CLUSTERED ([Id] ASC);


GO
ALTER TABLE [dbo].[EntradaSaidaProdutos]
    ADD CONSTRAINT [FK_EntradaSaidaProdutos_Produtos_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [dbo].[Produtos] ([Id]);



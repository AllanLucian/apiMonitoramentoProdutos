--------------------CATEGORIAPRODUTO----------------------------

INSERT INTO dbo.CategoriaProdutos VALUES ('69cd6a3c-e6c0-4359-b6e4-90f1ae174a7b', 'Salgado')
INSERT INTO dbo.CategoriaProdutos VALUES ('69cd6a3c-e6c0-4359-b6e4-90f1ae174a7c', 'Doce')


-------------------------PRODUTO-------------------------------

INSERT INTO dbo.Produtos VALUES (NEWID(), '69cd6a3c-e6c0-4359-b6e4-90f1ae174a7b', 'Pão de Queijo', 2.50, 20, GETDATE())
INSERT INTO dbo.Produtos VALUES (NEWID(), '69cd6a3c-e6c0-4359-b6e4-90f1ae174a7c', 'Brigadeiro', 1.50, 100, GETDATE())
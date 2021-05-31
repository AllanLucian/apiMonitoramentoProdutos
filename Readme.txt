O projeto utiliza Migrations para criação da base de dados, dessa forma, será necessária a execução do seguinte comando abaixo no Package Manager Console, selecionando o projeto DevIO.API:

update-database -Context MeuDbContext

Caso aconteça algum erro, deletar manualmente os scripts da pasta Migrations dos projetos (DevIO.API e DevIO.Data) e executar na ordem os seguintes comandos:

DevIO.Data

        add-migration -Context MeuDbContext
        
DevIO.API

        update-database -Context MeuDbContext

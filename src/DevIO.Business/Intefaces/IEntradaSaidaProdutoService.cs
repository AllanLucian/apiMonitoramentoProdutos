using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Business.Intefaces
{
    public interface IEntradaSaidaProdutoService : IDisposable
    {
        Task Adicionar(EntradaSaidaProduto entradaSaidaProduto);

        Task<IEnumerable<EntradaSaidaProduto>> ObterEntradaSaidaPorProdutos();
    }
}

using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class EntradaSaidaProdutoService : BaseService, IEntradaSaidaProdutoService
    {
        private readonly IEntradaSaidaProdutoRepository _entradaSaidaProdutoRepository;

        public EntradaSaidaProdutoService(IEntradaSaidaProdutoRepository entradaSaidaRepository,
                              INotificador notificador) : base(notificador)
        {
            _entradaSaidaProdutoRepository = entradaSaidaRepository;
        }

        public async Task Adicionar(EntradaSaidaProduto entradaSaidaProduto)
        {
            await _entradaSaidaProdutoRepository.Adicionar(entradaSaidaProduto);
        }

        public async Task<IEnumerable<EntradaSaidaProduto>> ObterEntradaSaidaPorProdutos()
        {
            return await _entradaSaidaProdutoRepository.ObterEntradaSaidaPorProdutos();
        }

        public void Dispose()
        {
            _entradaSaidaProdutoRepository?.Dispose();
        }
    }
}

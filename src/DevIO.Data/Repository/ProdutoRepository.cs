using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<Produto>> ObterProdutosPorCategoria(Guid categoriaId)
        {
            return await Buscar(p => p.CategoriaProdutoId == categoriaId);
        }
    }
}
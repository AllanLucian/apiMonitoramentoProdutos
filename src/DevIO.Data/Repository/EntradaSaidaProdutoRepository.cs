using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class EntradaSaidaProdutoRepository : Repository<EntradaSaidaProduto>, IEntradaSaidaProdutoRepository
    {
        protected readonly MeuDbContext Db;
        protected readonly DbSet<EntradaSaidaProduto> DbSet;

        public EntradaSaidaProdutoRepository(MeuDbContext db) : base(db)
        {
            Db = db;
            DbSet = db.Set<EntradaSaidaProduto>();
        }

        public async Task<IEnumerable<EntradaSaidaProduto>> ObterEntradaSaidaPorProdutos()
        {
            return await Db.EntradaSaidaProdutos.AsNoTracking().Include(e => e.Produto).ToListAsync();
        }
    }
}

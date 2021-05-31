using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class CategoriaProdutoRepository : ICategoriaProdutoRepository
    {
        protected readonly MeuDbContext Db;
        protected readonly DbSet<CategoriaProduto> DbSet;

        public CategoriaProdutoRepository(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<CategoriaProduto>();
        }

        public async Task<List<CategoriaProduto>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }
    }
}
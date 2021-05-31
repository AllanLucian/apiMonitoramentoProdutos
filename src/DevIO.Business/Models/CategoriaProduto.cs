using System.Collections.Generic;

namespace DevIO.Business.Models
{
    public class CategoriaProduto : Entity
    {
        public string Descricao { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}

using System;

namespace DevIO.Business.Models
{
    public class EntradaSaidaProduto : Entity
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public string Operacao { get; set; }
        public string Responsavel { get; set; }
        public DateTime Data { get; set; }

        /* EF Relations */
        public Produto Produto { get; set; }
    }
}

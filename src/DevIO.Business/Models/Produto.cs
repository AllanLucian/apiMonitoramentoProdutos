using System;

namespace DevIO.Business.Models
{
    public class Produto : Entity
    {
        public Guid CategoriaProdutoId { get; set; }

        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }

        /* EF Relations */
        public CategoriaProduto CategoriaProduto { get; set; }
    }
}
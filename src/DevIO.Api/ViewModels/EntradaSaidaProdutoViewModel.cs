using System;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.ViewModels
{
    public class EntradaSaidaProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public string Operacao { get; set; }
        public string Responsavel { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Data { get; set; }

        [ScaffoldColumn(false)]
        public string NomeProduto { get; set; }
    }
}

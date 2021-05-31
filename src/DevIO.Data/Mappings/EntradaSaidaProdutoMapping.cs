using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class EntradaSaidaProdutoMapping : IEntityTypeConfiguration<EntradaSaidaProduto>
    {
        public void Configure(EntityTypeBuilder<EntradaSaidaProduto> builder)
        {
            builder.HasKey(p => p.Id);


            builder.Property(p => p.Responsavel)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Quantidade)
            .IsRequired();

            builder.Property(p => p.Operacao)
            .IsRequired()
            .HasColumnType("varchar(100)");
        }
    }
}

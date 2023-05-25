using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaCodeblox.Dominio.Entidades;

namespace ProvaCodeblox.Repositorio.Configuracoes
{
    public class ConfiguracoesDeProduto : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(produto => produto.Id);
            builder.Property(produto => produto.Nome).HasMaxLength(250).IsRequired();
            builder.Property(produto => produto.Tipo).HasMaxLength(100).IsRequired();
            builder.Property(produto => produto.Quantidade).IsRequired();
            builder.Property(produto => produto.Descricao).HasMaxLength(500);
        }
    }
}

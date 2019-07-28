using Storiify.Compartilhado.Padroes;
using Storiify.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Storiify.Infra.BancoDeDados.Mapeamentos
{
    internal class SerieHistoriasMap : IEntityTypeConfiguration<SerieHistorias>
    {
        public const string Tabela = "tb_serie_historias";
        public void Configure(EntityTypeBuilder<SerieHistorias> builder)
        {
            IgnorarVos(builder);

            builder.ToTable(Tabela);

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Id).HasMaxLength(PadroesTamanho.Id);

            builder.OwnsOne(h => h.Nome, n =>
            {
                n.Property(no => no.Texto).IsRequired().HasMaxLength(PadroesTamanho.MaxNome).HasColumnName("Nome");
                n.HasIndex(no => no.Texto).IsUnique();
            });
        }

        /// <summary>
        /// Ignora todos os VOs da entidade, deve ser o primeiro elemento a ser mapeado
        /// </summary>
        private static void IgnorarVos(EntityTypeBuilder<SerieHistorias> builder)
        {
            builder.Ignore(h => h.Nome);
        }
    }
}

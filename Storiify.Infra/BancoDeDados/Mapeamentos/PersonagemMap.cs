using Storiify.Compartilhado.Padroes;
using Storiify.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Storiify.Infra.BancoDeDados.Mapeamentos
{
    internal class PersonagemMap : IEntityTypeConfiguration<Personagem>
    {
        public const string Tabela = "tb_personagem";
        public void Configure(EntityTypeBuilder<Personagem> builder)
        {
            IgnorarVos(builder);

            builder.ToTable(Tabela);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasMaxLength(PadroesTamanho.Id);

            builder.OwnsOne(p => p.Nome, n =>
            {
                n.Property(no => no.Texto).IsRequired().HasMaxLength(PadroesTamanho.MaxNome).HasColumnName("Nome");
            });

            builder.OwnsOne(p => p.Foto, f =>
            {
                f.Property(fo => fo.IdPublico).HasMaxLength(PadroesTamanho.MaxFotoIdPublico).HasColumnName("FotoIdPublico");
                f.Property(fo => fo.Url).HasMaxLength(PadroesTamanho.MaxFotoUrl).HasColumnName("FotoUrl");
            });
        }

        /// <summary>
        /// Ignora todos os VOs da entidade, deve ser o primeiro elemento a ser mapeado
        /// </summary>
        private static void IgnorarVos(EntityTypeBuilder<Personagem> builder)
        {
            builder.Ignore(p => p.Nome);
            builder.Ignore(p => p.Foto);
        }
    }
}

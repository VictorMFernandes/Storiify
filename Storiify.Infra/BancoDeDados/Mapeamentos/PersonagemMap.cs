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

            builder.HasKey(u => u.Id);

            builder.OwnsOne(u => u.Nome, n =>
            {
                n.Property(no => no.Texto).IsRequired().HasMaxLength(PadroesTamanho.MaxNome).HasColumnName("Nome");
            });

            builder.OwnsOne(u => u.Foto, f =>
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
            builder.Ignore(u => u.Nome);
            builder.Ignore(u => u.Foto);
        }
    }
}

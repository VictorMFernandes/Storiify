using Storiify.Compartilhado.Padroes;
using Storiify.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Storiify.Infra.BancoDeDados.Mapeamentos
{
    internal class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public const string Tabela = "tb_usuario";
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            IgnorarVos(builder);

            builder.ToTable(Tabela);

            builder.HasKey(u => u.Id);

            builder.OwnsOne(u => u.Email, e =>
            {
                e.Property(em => em.Endereco).IsRequired().HasMaxLength(PadroesTamanho.MaxEmail).HasColumnName("Email");
            });
            builder.OwnsOne(u => u.Nome, n =>
            {
                n.Property(no => no.Texto).IsRequired().HasMaxLength(PadroesTamanho.MaxNome).HasColumnName("Nome");
            });

            builder.OwnsOne(u => u.Autenticacao, a =>
            {
                a.Property(au => au.Login).IsRequired().HasMaxLength(PadroesTamanho.MaxLogin).HasColumnName("Login");
                a.Property(au => au.Senha).IsRequired().HasMaxLength(32).IsFixedLength().HasColumnName("Senha");
                a.Property(au => au.Ativo).HasColumnName("Ativo");
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
        private static void IgnorarVos(EntityTypeBuilder<Usuario> builder)
        {
            builder.Ignore(u => u.Autenticacao);
            builder.Ignore(u => u.Nome);
            builder.Ignore(u => u.Email);
            builder.Ignore(u => u.Foto);
        }
    }
}

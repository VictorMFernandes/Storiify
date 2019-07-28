using Storiify.Dominio.Entidades;
using Storiify.Infra.BancoDeDados.Mapeamentos;
using FluentValidator;
using Microsoft.EntityFrameworkCore;

namespace Storiify.Infra.BancoDeDados.Contexto
{
    public class BancoContexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Historia> Historias { get; set; }
        public DbSet<Personagem> Personagens { get; set; }

        public BancoContexto(DbContextOptions options) : base(options)
        {
            // TODO remover proxyCreation
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new HistoriaMap());
            modelBuilder.ApplyConfiguration(new PersonagemMap());
            modelBuilder.ApplyConfiguration(new SerieHistoriasMap());
        }
    }
}

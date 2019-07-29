using System.Linq;
using Storiify.Dominio.Entidades;
using Storiify.Dominio.Repositorios;
using Storiify.Infra.BancoDeDados.Contexto;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Win32.SafeHandles;
using Storiify.Dominio.Sistema;
using Storiify.Dominio.ValueObjects;
using Storiify.Infra.BancoDeDados.Mapeamentos;

namespace Storiify.Infra.BancoDeDados.Repositorios
{
    public class SerieHistoriasRepositorio : ISerieHistoriasRepositorio
    {
        private readonly BancoContexto _contexto;

        public SerieHistoriasRepositorio(BancoContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<SerieHistorias> PegarPorNome(string nome)
        {
            var query = $"SELECT Id, Nome AS Texto FROM {SerieHistoriasMap.Tabela} " +
                        "WHERE Nome = @nome";

            using (var conn = new SqliteConnection(Configuracoes.ConnString))
            {
                conn.Open();

                var haha = await conn.QueryAsync<string, SerieHistorias, SerieHistorias> (query, (t, s) =>
                {
                    var nomeRet = new Nome(t); 
                    
                    return new SerieHistorias(s.Id, nomeRet);
                }, nome);

                return haha.FirstOrDefault();
            }
        }
    }
}

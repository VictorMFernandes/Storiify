using Dapper;
using Storiify.Dominio.Comandos.AutenticacaoComandos.Saidas;
using Storiify.Dominio.Entidades;
using Storiify.Dominio.Repositorios;
using Storiify.Dominio.Sistema;
using Storiify.Infra.BancoDeDados.Contexto;
using Storiify.Infra.BancoDeDados.Mapeamentos;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Storiify.Dominio.Comandos.HistoriaComandos.Saidas;

namespace Storiify.Infra.BancoDeDados.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContexto _contexto;

        public UsuarioRepositorio(BancoContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Usuario> PegarPorId(string id)
        {
            return await _contexto
                        .Usuarios
                        .FirstOrDefaultAsync(x => x.PossuiId(id));
        }

        public async Task<AutenticarUsuarioComandoResultado> PegarPorLogin(string login)
        {
            var query = $"SELECT Id, Nome, Email, FotoUrl, Senha FROM {UsuarioMap.Tabela} " +
                                $"WHERE Login = '{login}'";
            
            using (var conn = new SqliteConnection(Configuracoes.ConnString))
            {
                conn.Open();
                var resultado = await conn.QueryFirstOrDefaultAsync<AutenticarUsuarioComandoResultado>(query);
                
                if (resultado == null) return null;

                query = $"SELECT h.Id, h.Nome, h.FotoUrl, sh.Nome AS NomeSerieHistorias FROM {HistoriaMap.Tabela} AS h " +
                        $"INNER JOIN {SerieHistoriasMap.Tabela} AS sh ON h.SerieHistoriasId = sh.Id " +
                        $"WHERE h.UsuarioId = '{resultado.Id}'";

                resultado.Historias = await conn.QueryAsync<PegarHistoriasComandoResultado>(query);

                return resultado;
            }
        }

        public void Criar(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
        }
        public void Atualizar(Usuario usuario)
        {
            _contexto.Entry(usuario).State = EntityState.Modified;
        }

        public async Task<bool> IdExiste(string id)
        {
            return await _contexto.Usuarios
                                    .AsNoTracking()
                                    .AnyAsync(x => x.PossuiId(id));
        }

        public async Task<bool> EmailExiste(string email)
        {
            return await _contexto.Usuarios
                                    .AsNoTracking()
                                    .AnyAsync(x => x.Email.Endereco == email);
        }
    }
}

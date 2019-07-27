using Storiify.Dominio.Comandos.AutenticacaoComandos.Saidas;
using Storiify.Dominio.Entidades;
using Storiify.Dominio.Repositorios;
using System.Threading.Tasks;

namespace Storiify.Testes.Falsos
{
    internal class UsuarioRepositorioFalso : IUsuarioRepositorio
    {
        public void Atualizar(Usuario usuario) { }

        public void Criar(Usuario usuario) { }

        public Task<bool> IdExiste(string id) => Task.Run(() => true);

        public Task<bool> EmailExiste(string email) => Task.Run(() => false);

        public Task<Usuario> PegarPorId(string id) => null;

        public Task<AutenticarUsuarioComandoResultado> PegarPorLogin(string login) => null;
    }
}

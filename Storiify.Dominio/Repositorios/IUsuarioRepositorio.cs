using Storiify.Dominio.Comandos.AutenticacaoComandos.Saidas;
using Storiify.Dominio.Entidades;
using System.Threading.Tasks;

namespace Storiify.Dominio.Repositorios
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> PegarPorId(string id);
        Task<AutenticarUsuarioComandoResultado> PegarPorLogin(string login);

        void Criar(Usuario usuario);
        void Atualizar(Usuario usuario);

        Task<bool> IdExiste(string id);
        Task<bool> EmailExiste(string email);
    }
}

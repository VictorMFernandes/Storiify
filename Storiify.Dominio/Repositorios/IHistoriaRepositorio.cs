using Storiify.Dominio.Entidades;
using System.Threading.Tasks;

namespace Storiify.Dominio.Repositorios
{
    public interface IHistoriaRepositorio
    {
        Task<Historia> PegarPorId(string id);
        void Criar(Historia usuario);
        void Atualizar(Historia usuario);
    }
}

using Storiify.Dominio.Entidades;
using System.Threading.Tasks;

namespace Storiify.Dominio.Repositorios
{
    public interface ISerieHistoriasRepositorio
    {
        Task<SerieHistorias> PegarPorNome(string nome);
    }
}

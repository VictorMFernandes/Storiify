using Storiify.Dominio.Entidades;
using System.Threading.Tasks;

namespace Storiify.Dominio.Repositorios
{
    public interface IPersonagemRepositorio
    {
        Task<Personagem> PegarPorId(string id);
        void Criar(Personagem usuario);
        void Atualizar(Personagem usuario);
    }
}

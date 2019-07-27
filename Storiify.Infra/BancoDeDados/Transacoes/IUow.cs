using System.Threading.Tasks;

namespace Storiify.Infra.BancoDeDados.Transacoes
{
    public interface IUow
    {
        Task<bool> Salvar();
        void RollBack();
    }
}

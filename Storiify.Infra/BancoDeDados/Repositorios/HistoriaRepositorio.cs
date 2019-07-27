using Storiify.Dominio.Entidades;
using Storiify.Dominio.Repositorios;
using Storiify.Infra.BancoDeDados.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Storiify.Infra.BancoDeDados.Repositorios
{
    public class HistoriaRepositorio : IHistoriaRepositorio
    {
        private readonly BancoContexto _contexto;

        public HistoriaRepositorio(BancoContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Historia> PegarPorId(string id)
        {
            return await _contexto
                        .Historias
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Criar(Historia usuario)
        {
            _contexto.Historias.Add(usuario);
        }
        public void Atualizar(Historia usuario)
        {
            _contexto.Entry(usuario).State = EntityState.Modified;
        }
    }
}

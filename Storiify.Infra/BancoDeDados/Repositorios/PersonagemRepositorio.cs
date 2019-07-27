using Storiify.Dominio.Entidades;
using Storiify.Dominio.Repositorios;
using Storiify.Infra.BancoDeDados.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Storiify.Infra.BancoDeDados.Repositorios
{
    public class PersonagemRepositorio : IPersonagemRepositorio
    {
        private readonly BancoContexto _contexto;

        public PersonagemRepositorio(BancoContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Personagem> PegarPorId(string id)
        {
            return await _contexto
                        .Personagens
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Criar(Personagem usuario)
        {
            _contexto.Personagens.Add(usuario);
        }
        public void Atualizar(Personagem usuario)
        {
            _contexto.Entry(usuario).State = EntityState.Modified;
        }
    }
}

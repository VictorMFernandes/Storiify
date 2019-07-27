using System.Threading.Tasks;
using Storiify.Compartilhado.Comandos;
using Storiify.Dominio.Comandos.HistoriaComandos.Entradas;
using Storiify.Dominio.Comandos.UsuarioComandos.Saidas;
using Storiify.Dominio.Repositorios;

namespace Storiify.Dominio.Gerenciadores
{
    public class PersonagemGerenciador : Gerenciador
        , IComandoGerenciador<RegistrarPersonagemComando>
    {
        private readonly IPersonagemRepositorio _personagemRepo;

        public PersonagemGerenciador(IPersonagemRepositorio personagemRepo)
        {
            _personagemRepo = personagemRepo;
        }

        public async Task<IComandoResultado> Executar(RegistrarPersonagemComando comando)
        {
            if (!ValidarComando(comando))
                return null;

            // Criar a entidade
            var personagem = comando.GerarEntidade();

            // Validar entidade
            AddNotifications(personagem);

            if (Invalid) return null;

            // Persistir o usuário
            _personagemRepo.Criar(personagem);

            // Retornar o resultado para tela
            return new RegistrarPersonagemComandoResultado(personagem.Id, personagem.ToString());
        }

        #region Comandos

        #endregion
    }
}

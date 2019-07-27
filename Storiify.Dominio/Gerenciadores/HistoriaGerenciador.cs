using System.Threading.Tasks;
using Storiify.Compartilhado.Comandos;
using Storiify.Dominio.Comandos.HistoriaComandos.Entradas;
using Storiify.Dominio.Comandos.UsuarioComandos.Saidas;
using Storiify.Dominio.Repositorios;

namespace Storiify.Dominio.Gerenciadores
{
    public class HistoriaGerenciador : Gerenciador
        , IComandoGerenciador<RegistrarHistoriaComando>
    {
        private readonly IHistoriaRepositorio _historiaRepo;

        public HistoriaGerenciador(IHistoriaRepositorio historiaRepo)
        {
            _historiaRepo = historiaRepo;
        }

        #region Comandos

        public async Task<IComandoResultado> Executar(RegistrarHistoriaComando comando)
        {
            if (!ValidarComando(comando))
                return null;

            // Criar a entidade
            var historia = comando.GerarEntidade();

            // Validar entidade
            AddNotifications(historia);

            if (Invalid) return null;

            // Persistir o usuário
            _historiaRepo.Criar(historia);

            // Retornar o resultado para tela
            return new RegistrarHistoriaComandoResultado(historia.Id, historia.ToString());
        }

        #endregion
    }
}

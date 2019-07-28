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
        private readonly ISerieHistoriasRepositorio _serieHistoriasRepo;

        public HistoriaGerenciador(IHistoriaRepositorio historiaRepo, ISerieHistoriasRepositorio serieHistoriasRepo)
        {
            _historiaRepo = historiaRepo;
            _serieHistoriasRepo = serieHistoriasRepo;
        }

        #region Comandos

        public async Task<IComandoResultado> Executar(RegistrarHistoriaComando comando)
        {
            if (!ValidarComando(comando))
                return null;

            if (string.IsNullOrEmpty(comando.SerieHistoriasId))
            {

            }
            else
            {

            }

            var serieHistoria = await _serieHistoriasRepo.PegarPorNome(comando.SerieHistoriasNome);

            // Criar a entidade
            var historia = comando.GerarEntidade(serieHistoria);

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

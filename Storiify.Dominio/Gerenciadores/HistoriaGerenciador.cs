using System.Threading.Tasks;
using Storiify.Compartilhado.Comandos;
using Storiify.Dominio.Comandos.HistoriaComandos.Entradas;
using Storiify.Dominio.Comandos.HistoriaComandos.Saidas;
using Storiify.Dominio.Comandos.UsuarioComandos.Saidas;
using Storiify.Dominio.Entidades;
using Storiify.Dominio.Repositorios;
using Storiify.Dominio.ValueObjects;

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

            // Resolve a qual série de histórias essa história participará
            SerieHistorias serieHistoria;

            if (string.IsNullOrEmpty(comando.SerieHistoriasNome))
            {
                serieHistoria = null;
            }
            else
            {
                serieHistoria = await _serieHistoriasRepo.PegarPorNome(comando.SerieHistoriasNome)
                                        ?? new SerieHistorias(new Nome(comando.SerieHistoriasNome));
            }

            // Criar a entidade
            var historia = comando.GerarEntidade(serieHistoria);

            // Validar entidade
            AddNotifications(historia);

            if (Invalid) return null;

            // Persistir o usuário
            _historiaRepo.Criar(historia);

            // Retornar o resultado para tela
            return new RegistrarHistoriaComandoResultado(historia);
        }

        #endregion
    }
}

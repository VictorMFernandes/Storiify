using Storiify.Compartilhado.Comandos;
using Storiify.Dominio.Entidades;

namespace Storiify.Dominio.Comandos.HistoriaComandos.Saidas
{
    public class RegistrarHistoriaComandoResultado : IComandoResultado
    {
        #region Propriedades Api

        public string Id { get; }
        public string SerieHistoriasNome { get; set; }
        public string Nome { get; }

        #endregion

        #region Construtores
        public RegistrarHistoriaComandoResultado(Historia historia)
        {
            Id = historia.Id;
            Nome = historia.Nome.ToString();
            SerieHistoriasNome = historia.SerieHistorias.ToString();
        }

        #endregion
    }
}

using Storiify.Compartilhado.Comandos;

namespace Storiify.Dominio.Comandos.HistoriaComandos.Saidas
{
    public class PegarHistoriasComandoResultado : IComandoResultado
    {
        #region Propriedades

        public string Id { get; set; }
        public string NomeSerieHistorias { get; set; }
        public string Nome { get; set; }
        public string FotoUrl { get; set; }

        #endregion
    }
}

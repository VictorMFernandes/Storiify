using Storiify.Dominio.Comandos.HistoriaComandos.Entradas;
using Storiify.Dominio.Sistema.Exemplos;
using Swashbuckle.AspNetCore.Filters;

namespace Storiify.Api.Documentacao.Exemplos
{
    public class RegistrarHistoriaComandoExemplo : IExamplesProvider<RegistrarHistoriaComando>
    {
        public RegistrarHistoriaComando GetExamples()
        {
            return ExemplosComando.RegistrarHistoria;
        }
    }
}

using Storiify.Dominio.Comandos.AutenticacaoComandos.Entradas;
using Storiify.Dominio.Sistema.Exemplos;
using Swashbuckle.AspNetCore.Filters;

namespace Storiify.Api.Documentacao.Exemplos
{
    public class AutenticarUsuarioComandoExemplo : IExamplesProvider<AutenticarUsuarioComando>
    {
        public AutenticarUsuarioComando GetExamples()
        {
            return ExemplosComando.AutenticarUsuario;
        }
    }
}

using Storiify.Dominio.Comandos.UsuarioComandos.Entradas;
using Storiify.Dominio.Sistema.Exemplos;
using Swashbuckle.AspNetCore.Filters;

namespace Storiify.Api.Documentacao.Exemplos
{
    public class RegistrarUsuarioComandoExemplo : IExamplesProvider<RegistrarUsuarioComando>
    {
        public RegistrarUsuarioComando GetExamples()
        {
            return ExemplosComando.RegistrarUsuario;
        }
    }
}

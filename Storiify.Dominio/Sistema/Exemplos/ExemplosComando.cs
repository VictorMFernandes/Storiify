using Storiify.Compartilhado.Padroes;
using Storiify.Dominio.Comandos.AutenticacaoComandos.Entradas;
using Storiify.Dominio.Comandos.HistoriaComandos.Entradas;
using Storiify.Dominio.Comandos.UsuarioComandos.Entradas;

namespace Storiify.Dominio.Sistema.Exemplos
{
    public class ExemplosComando
    {
        public static RegistrarUsuarioComando RegistrarUsuario = new RegistrarUsuarioComando("Melissa Arroio Merlone dos Santos"
                , "melissa@email.com", "senha", "senha");

        public static RegistrarHistoriaComando RegistrarHistoria = new RegistrarHistoriaComando("O Senhor dos Anéis");

        public static RegistrarPersonagemComando RegistrarPersonagem = new RegistrarPersonagemComando("Aragorn");

        public static AutenticarUsuarioComando AutenticarUsuario = new AutenticarUsuarioComando(PadroesString.UsuarioLogin,
            PadroesString.UsuarioSenha);
    }
}

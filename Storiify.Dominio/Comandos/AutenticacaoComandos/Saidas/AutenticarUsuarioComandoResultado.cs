using Storiify.Compartilhado.Comandos;

namespace Storiify.Dominio.Comandos.AutenticacaoComandos.Saidas
{
    public class AutenticarUsuarioComandoResultado : IComandoResultado
    {
        #region Propriedades Api

        public string Token { get; private set; }
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string FotoUrl { get; private set; }
        internal string Senha { get; private set; }

        #endregion

        #region Construtores

        public AutenticarUsuarioComandoResultado()
        {
        }

        #endregion

        public void PrepararParaRetornar(string token)
        {
            Token = token;
        }
    }
}

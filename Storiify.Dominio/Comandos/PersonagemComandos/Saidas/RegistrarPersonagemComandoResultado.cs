using Storiify.Compartilhado.Comandos;

namespace Storiify.Dominio.Comandos.UsuarioComandos.Saidas
{
    public class RegistrarPersonagemComandoResultado : IComandoResultado
    {
        #region Propriedades Api

        public string Id { get; }
        public string Nome { get; }

        #endregion

        #region Construtores
        public RegistrarPersonagemComandoResultado(string id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        #endregion
    }
}

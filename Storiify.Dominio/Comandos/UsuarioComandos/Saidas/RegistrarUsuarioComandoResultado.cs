using Storiify.Compartilhado.Comandos;

namespace Storiify.Dominio.Comandos.UsuarioComandos.Saidas
{
    public class RegistrarUsuarioComandoResultado : IComandoResultado
    {
        #region Propriedades Api

        public string Id { get; }
        public string Nome { get; }
        public string Email { get; }

        #endregion

        #region Construtores
        public RegistrarUsuarioComandoResultado(string id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        #endregion
    }
}

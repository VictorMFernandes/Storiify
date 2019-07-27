using Storiify.Compartilhado.Comandos;
using FluentValidator;
using System.Collections.Generic;
using System.Linq;

namespace Storiify.Dominio.Comandos.AutenticacaoComandos.Entradas
{
    public class AutenticarUsuarioComando : IComando
    {
        #region Propriedades Api

        public string Login { get; set; }
        public string Senha { get; set; }

        #endregion

        #region Construtores

        public AutenticarUsuarioComando(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }

        #endregion

        #region IComando

        public bool FoiValidado { get; set; }

        public bool Validar()
        {
            FoiValidado = true;

            if (string.IsNullOrEmpty(Login))
            {
                _notificacoes.Add(new Notification("Login", "O Login não pode ser vazio."));
            }

            if (string.IsNullOrEmpty(Senha))
            {
                _notificacoes.Add(new Notification("Senha", "A Senha não pode ser vazia."));
            }

            return !_notificacoes.Any();
        }

        private readonly List<Notification> _notificacoes = new List<Notification>();
        public IReadOnlyCollection<Notification> PegarNotificacoes() => _notificacoes;

        #endregion
    }
}

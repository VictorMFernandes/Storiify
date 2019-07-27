using Storiify.Compartilhado.Comandos;
using Storiify.Dominio.Entidades;
using Storiify.Dominio.ValueObjects;
using FluentValidator;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Storiify.Dominio.Comandos.UsuarioComandos.Entradas
{
    public class RegistrarUsuarioComando : IComando
    {
        #region Propriedades Api

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }

        #endregion

        #region Construtores

        public RegistrarUsuarioComando(string nome, string email, string senha, string confirmacaoSenha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            ConfirmacaoSenha = confirmacaoSenha;
        }

        #endregion

        #region IComando

        public bool FoiValidado { get; private set; }

        public bool Validar()
        {
            _nome = new Nome(Nome);
            _email = new Email(Email);
            _autenticacao = new Autenticacao(Email, Senha, ConfirmacaoSenha);

            FoiValidado = true;

            return _nome.Valid && _email.Valid && _autenticacao.Valid;
        }

        public IReadOnlyCollection<Notification> PegarNotificacoes()
        {
            var resultado = new List<Notification>();

            resultado.AddRange(_nome.Notifications);
            resultado.AddRange(_email.Notifications);
            resultado.AddRange(_autenticacao.Notifications);

            return resultado;
        }

        #endregion

        #region Value Objects

        private Nome _nome;
        private Email _email;
        private Autenticacao _autenticacao;

        #endregion

        public Usuario GerarEntidade()
        {
            return new Usuario(_nome, _email, _autenticacao);
        }
    }
}

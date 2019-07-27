using Storiify.Compartilhado.Entidades;
using Storiify.Dominio.ValueObjects;
using System;
using System.Collections.Generic;

namespace Storiify.Dominio.Entidades
{
    public sealed class Usuario : Entidade
    {
        #region Propriedades

        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public Autenticacao Autenticacao { get; private set; }
        public Foto Foto { get; private set; }
        public DateTime DtCriacao { get; private set; }
        public DateTime DtUltimaAtividade { get; private set; }
        public ICollection<Historia> Historias { get; set; }

        #endregion

        #region Construtores

        private Usuario() { }

        public Usuario(Nome nome, Email email, Autenticacao autenticacao)
        {
            Nome = nome;
            Email = email;
            Autenticacao = autenticacao;
            Foto = new Foto(string.Empty, string.Empty);
            DtCriacao = DateTime.Now;
            DtUltimaAtividade = DateTime.Now;

            Validar();
        }

        public Usuario(string id, Nome nome, Email email, Autenticacao autenticacao)
            : this(nome, email, autenticacao)
        {
            Id = id;
        }

        #endregion

        #region Métodos de Sobrescrita

        public override string ToString()
        {
            return Nome.ToString();
        }

        protected override void Validar()
        {
            AddNotifications(Nome, Email, Autenticacao);
        }

        protected override void InicializarColecoes()
        {
            Historias = new List<Historia>();
        }

        #endregion

        #region Métodos de Crud

        public void AtualizarDtUltimaAtividade()
        {
            DtUltimaAtividade = DateTime.Now;
        }

        public void AtualizarFoto(Foto foto)
        {
            Foto = foto;
        }

        #endregion
    }
}

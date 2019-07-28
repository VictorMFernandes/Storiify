using FluentValidator;
using FluentValidator.Validation;
using Storiify.Compartilhado.Padroes;
using System;

namespace Storiify.Compartilhado.Entidades
{
    public abstract class Entidade : Notifiable
    {
        public string Id { get; protected set; }

        protected Entidade()
        {
            Id = Guid.NewGuid().ToString();
            InicializarColecoes();
            ValidarEntidade();
        }

        private void ValidarEntidade()
        {
            AddNotifications(new ValidationContract()
                .HasLen(Id, PadroesTamanho.Id, nameof(Id), string.Format(PadroesMensagens.IdInvalido, Id)));
        }

        protected abstract void InicializarColecoes();
        protected abstract void Validar();
        public abstract override string ToString();

        public bool PossuiId(string id)
        {
            return (Id == id);
        }
    }
}

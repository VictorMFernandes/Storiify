using FluentValidator;
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
        }

        protected abstract void InicializarColecoes();
        protected abstract void Validar();
        public abstract override string ToString();
    }
}

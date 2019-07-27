using FluentValidator;

namespace Storiify.Compartilhado.Entidades
{
    public abstract class ValueObject : Notifiable
    {
        protected abstract void Validar();
        public abstract override string ToString();
    }
}

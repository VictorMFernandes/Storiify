using Storiify.Compartilhado.Entidades;
using FluentValidator.Validation;
using Storiify.Compartilhado.Padroes;

namespace Storiify.Dominio.ValueObjects
{
    public sealed class Email : ValueObject
    {
        #region Propriedades

        public string Endereco { get; }

        #endregion

        #region Construtores

        public Email(string endereco)
        {
            Endereco = endereco;

            Validar();
        }

        #endregion

        #region Métodos de Sobrescrita
        public override string ToString()
        {
            return Endereco;
        }

        protected override void Validar()
        {
            AddNotifications(new ValidationContract()
                .IsEmail(Endereco, nameof(Email), string.Format(PadroesMensagens.EmailInvalido, Endereco))
            );
        }

        #endregion
    }
}

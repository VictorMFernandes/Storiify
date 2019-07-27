using Storiify.Compartilhado.Entidades;
using Storiify.Compartilhado.Extensoes;
using FluentValidator.Validation;

namespace Storiify.Dominio.ValueObjects
{
    public sealed class Telefone : ValueObject
    {
        #region Propriedades

        public string Numero { get; }

        #endregion

        #region Construtores

        public Telefone(string numero)
        {
            Numero = numero;

            Validar();
        }

        #endregion

        #region Métodos de Sobrescrita

        public override string ToString()
        {
            return Numero;
        }

        protected override void Validar()
        {
            AddNotifications(new ValidationContract()
                .IsTrue(Numero.TelefoneValido(), "Numero", "Telefone inválido")
            );
        }

        #endregion
    }
}

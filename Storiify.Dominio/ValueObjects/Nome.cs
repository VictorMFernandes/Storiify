using Storiify.Compartilhado.Entidades;
using Storiify.Compartilhado.Padroes;
using FluentValidator.Validation;

namespace Storiify.Dominio.ValueObjects
{
    public sealed class Nome : ValueObject
    {
        #region Propriedades

        public string Texto { get; }

        #endregion

        #region Construtores

        public Nome(string texto)
        {
            Texto = texto;

            Validar();
        }

        #endregion

        #region Métodos de Sobrescrita

        public override string ToString()
        {
            return Texto;
        }

        protected override void Validar()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(Texto, PadroesTamanho.MinNome
                    , nameof(Nome)
                    , PadroesMensagens.NomeMin)
                .HasMaxLen(Texto, PadroesTamanho.MaxNome
                    , nameof(Nome)
                    , PadroesMensagens.NomeMax)
            );
        }

        #endregion
    }
}

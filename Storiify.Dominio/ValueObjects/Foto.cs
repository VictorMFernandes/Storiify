using Storiify.Compartilhado.Entidades;
using Storiify.Compartilhado.Padroes;
using FluentValidator.Validation;

namespace Storiify.Dominio.ValueObjects
{
    public sealed class Foto : ValueObject
    {
        #region Propriedades

        public string Url { get; }
        public string IdPublico { get; }

        #endregion

        #region Construtores

        public Foto(string url, string idPublico)
        {
            Url = url;
            IdPublico = idPublico;

            Validar();
        }

        #endregion

        #region Métodos de Sobrescrita

        public override string ToString()
        {
            return Url;
        }

        protected override void Validar()
        {
            AddNotifications(new ValidationContract()
                                .IsUrl(Url, "Url", "A Url da imagem não é válida")
                                .HasMaxLen(Url, PadroesTamanho.MaxFotoUrl
                                    , "Url"
                                    , $"A Url de uma imagem deve ter no máximo {PadroesTamanho.MaxFotoUrl} caracteres")
                                .HasMaxLen(IdPublico, PadroesTamanho.MaxFotoIdPublico
                                    , "PublicId"
                                    , $"O Id Público de uma foto deve ter no máximo {PadroesTamanho.MaxFotoIdPublico} caracteres"));
        }

        #endregion
    }
}

using Storiify.Compartilhado.Entidades;
using Storiify.Compartilhado.Padroes;
using FluentValidator.Validation;

namespace Storiify.Dominio.ValueObjects
{
    public sealed class Foto : ValueObject
    {
        #region Propriedades

        public string Url { get; private set; }
        public string IdPublico { get; private set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor para o ORM, usado na inicialização das entidades
        /// </summary>
        public Foto()
        {
            Url = string.Empty;
            IdPublico = string.Empty;
        }

        /// <summary>
        /// Construtor principal
        /// </summary>
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
                                .IsUrl(Url, nameof(Foto)+nameof(Url), string.Format(PadroesMensagens.UrlInvalida, Url))
                                .HasMaxLen(Url, PadroesTamanho.MaxFotoUrl
                                    , nameof(Foto) + nameof(Url)
                                    , PadroesMensagens.UrlMax)
                                .HasMaxLen(IdPublico, PadroesTamanho.MaxFotoIdPublico
                                    , nameof(Foto) + nameof(IdPublico)
                                    , PadroesMensagens.IdPublicoMax));
        }

        #endregion
    }
}

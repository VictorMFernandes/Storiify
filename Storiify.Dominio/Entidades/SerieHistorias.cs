using Storiify.Compartilhado.Entidades;
using Storiify.Dominio.ValueObjects;
using System.Collections.Generic;

namespace Storiify.Dominio.Entidades
{
    public class SerieHistorias : Entidade
    {
        #region Propriedade

        public Nome Nome { get; private set; }
        public ICollection<Historia> Historias { get; set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor para o ORM
        /// </summary>
        private SerieHistorias() { }

        /// <summary>
        /// Construtor principal
        /// </summary>
        public SerieHistorias(Nome nome)
        {
            Nome = nome;
            Validar();
        }

        /// <summary>
        /// Construtor para semear
        /// </summary>
        public SerieHistorias(string id, Nome nome)
            : this(nome)
        {
            Id = id;
        }

        #endregion

        #region Métodos de Sobrescrita

        public override string ToString()
        {
            return Nome.ToString();
        }

        protected override void InicializarColecoes()
        {
            Historias = new List<Historia>();
        }

        protected override void Validar()
        {
            AddNotifications(Nome);
        }

        #endregion
    }
}

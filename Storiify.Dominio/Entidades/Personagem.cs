using Storiify.Compartilhado.Entidades;
using Storiify.Dominio.ValueObjects;

namespace Storiify.Dominio.Entidades
{
    public class Personagem : Entidade
    {
        #region Propriedades

        public Nome Nome { get; private set; }
        public Foto Foto { get; private set; }
        public string HistoriaId { get; private set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor para o ORM
        /// </summary>
        private Personagem() { }

        /// <summary>
        /// Construtor principal
        /// </summary>
        public Personagem(Nome nome, string historiaId)
        {
            Nome = nome;
            Foto = new Foto();
            HistoriaId = historiaId;

            Validar();
        }

        /// <summary>
        /// Construtor para semear
        /// </summary>
        public Personagem(string id, Nome nome, string historiaId)
            : this(nome, historiaId)
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
        }

        protected override void Validar()
        {
            AddNotifications(Nome, Foto);
        }

        #endregion
    }
}

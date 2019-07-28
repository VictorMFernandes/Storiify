using Storiify.Compartilhado.Entidades;
using Storiify.Dominio.ValueObjects;

namespace Storiify.Dominio.Entidades
{
    public class Personagem : Entidade
    {
        #region Propriedades

        public Nome Nome { get; private set; }
        public Foto Foto { get; private set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor para o ORM
        /// </summary>
        private Personagem() { }

        /// <summary>
        /// Construtor principal
        /// </summary>
        public Personagem(Nome nome)
        {
            Nome = nome;
            Foto = new Foto();

            Validar();
        }

        /// <summary>
        /// Construtor para semear
        /// </summary>
        public Personagem(string id, Nome nome)
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
        }

        protected override void Validar()
        {
            AddNotifications(Nome, Foto);
        }

        #endregion
    }
}

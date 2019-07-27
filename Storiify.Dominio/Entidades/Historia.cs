using Storiify.Compartilhado.Entidades;
using Storiify.Dominio.ValueObjects;
using System.Collections.Generic;

namespace Storiify.Dominio.Entidades
{
    public class Historia : Entidade
    {
        #region Propriedade

        public Nome Nome { get; private set; }
        public Foto Foto { get; private set; }
        public ICollection<Personagem> Personagens { get; set; }

        #endregion

        #region Construtores

        private Historia() { }

        public Historia(Nome nome)
        {
            Nome = nome;
        }

        #endregion

        #region Métodos de Sobrescrita

        public override string ToString()
        {
            return Nome.ToString();
        }

        protected override void InicializarColecoes()
        {
            Personagens = new List<Personagem>();
        }

        protected override void Validar()
        {
            AddNotifications(Nome);
        }

        #endregion
    }
}

using Storiify.Compartilhado.Entidades;
using Storiify.Dominio.ValueObjects;
using System;

namespace Storiify.Dominio.Entidades
{
    public class Personagem : Entidade
    {
        #region Propriedades

        public Nome Nome { get; private set; }
        public Foto Foto { get; private set; }

        #endregion

        #region Construtores

        public Personagem() { }

        public Personagem(Nome nome)
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
            throw new NotImplementedException();
        }

        protected override void Validar()
        {
            AddNotifications(Nome);
        }

        #endregion
    }
}

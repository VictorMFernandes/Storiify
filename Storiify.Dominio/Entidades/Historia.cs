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
        public SerieHistorias SerieHistorias { get; private set; }
        public ICollection<Personagem> Personagens { get; private set; }
        public string UsuarioId { get; private set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor para o ORM
        /// </summary>
        private Historia() { }

        /// <summary>
        /// Construtor principal
        /// </summary>
        public Historia(Nome nome, SerieHistorias serieHistorias, string usuarioId)
        {
            Nome = nome;
            SerieHistorias = serieHistorias;
            UsuarioId = usuarioId;
            Foto = new Foto();

            Validar();
        }

        /// <summary>
        /// Construtor para semear
        /// </summary>
        public Historia(string id, Nome nome, SerieHistorias serieHistorias, string usuarioId)
            : this(nome, serieHistorias, usuarioId)
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
            Personagens = new List<Personagem>();
        }

        protected override void Validar()
        {
            AddNotifications(Nome, Foto);
        }

        #endregion

        public void AdicionarPersonagem(Personagem personagem)
        {
            Personagens.Add(personagem);
        }

        public void DefinirSerieHistorias(SerieHistorias serieHistorias)
        {
            SerieHistorias = serieHistorias;
        }
    }
}

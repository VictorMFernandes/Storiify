using Storiify.Compartilhado.Comandos;
using Storiify.Dominio.Entidades;
using Storiify.Dominio.ValueObjects;
using FluentValidator;
using System.Collections.Generic;

namespace Storiify.Dominio.Comandos.HistoriaComandos.Entradas
{
    public class RegistrarHistoriaComando : IComando
    {
        #region Propriedades Api

        public string Nome { get; set; }
        public string SerieHistoriasId { get; set; }
        public string SerieHistoriasNome { get; set; }
        private string UsuarioId { get; set; }

        #endregion

        #region Construtores

        public RegistrarHistoriaComando(string nome)
        {
            Nome = nome;
        }

        #endregion

        #region IComando

        public bool FoiValidado { get; private set; }

        public bool Validar()
        {
            _nome = new Nome(Nome);

            FoiValidado = true;

            return _nome.Valid;
        }

        public IReadOnlyCollection<Notification> PegarNotificacoes()
        {
            var resultado = new List<Notification>();

            resultado.AddRange(_nome.Notifications);

            return resultado;
        }

        #endregion

        #region Value Objects

        private Nome _nome;

        #endregion

        public Historia GerarEntidade(SerieHistorias serieHistorias)
        {
            return new Historia(_nome, serieHistorias, UsuarioId);
        }

        public void PegarId(string usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
}

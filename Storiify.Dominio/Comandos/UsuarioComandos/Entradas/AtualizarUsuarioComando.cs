using Storiify.Compartilhado.Comandos;
using FluentValidator;
using System;
using System.Collections.Generic;

namespace Storiify.Dominio.Comandos.UsuarioComandos.Entradas
{
    public class AtualizarUsuarioComando : IComando
    {
        #region Propriedades Api

        public string Id { get; set; }
        public DateTime DtNascimento { get; set; }

        #endregion

        #region IComando

        public bool FoiValidado { get; set; }

        public bool Validar() => FoiValidado = true;

        public IReadOnlyCollection<Notification> PegarNotificacoes() => new List<Notification>();

        #endregion
    }
}

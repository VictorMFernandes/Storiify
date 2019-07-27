using Storiify.Compartilhado.Comandos;
using FluentValidator;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Storiify.Dominio.Comandos.FotoComandos.Entradas
{
    public class AlterarFotoUsuarioComando : IComando
    {
        #region Propriedades

        internal string UsuarioLogadoId { get; private set; }
        internal string UsuarioId { get; private set; }
        public IFormFile ArquivoFoto { get; set; }

        #endregion

        #region IComando

        public bool FoiValidado { get; private set; }

        public bool Validar() => FoiValidado = true;

        public IReadOnlyCollection<Notification> PegarNotificacoes() => new List<Notification>();

        #endregion

        public void PegarIdsUsuarios(string usuarioLogadoId, string usuarioId)
        {
            UsuarioLogadoId = usuarioLogadoId;
            UsuarioId = usuarioId;
        }
    }
}

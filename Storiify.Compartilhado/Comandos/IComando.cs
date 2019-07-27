using FluentValidator;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Storiify.Compartilhado.Comandos
{
    public interface IComando
    {
        /// <summary>
        /// Verifica se o comando foi validado pelo gerenciador
        /// </summary>
        /// <remarks>Utilizado na parte de testes</remarks>
        [JsonIgnore]
        bool FoiValidado { get; }
        /// <summary>
        /// Verifica se o comando é válido e gera os VO's necessários se existirem
        /// </summary>
        bool Validar();
        /// <summary>
        /// Retorna as notificacoes geradas na validação
        /// </summary>
        IReadOnlyCollection<Notification> PegarNotificacoes();
    }
}

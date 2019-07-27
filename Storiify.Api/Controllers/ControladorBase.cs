using Storiify.Infra.BancoDeDados.Transacoes;
using FluentValidator;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Storiify.Compartilhado.Comandos.Genericos;

namespace Storiify.Api.Controllers
{
    public abstract class ControladorBase : Controller
    {
        protected string UsuarioLogadoId => User.FindFirst(ClaimTypes.NameIdentifier).Value;

        private readonly IUow _uow;

        protected ControladorBase(IUow uow)
        {
            _uow = uow;
        }

        protected async Task<IActionResult> Resposta(object resultado
            , IEnumerable<Notification> notificacoes)
        {
            if (resultado is IComandoResultadoGenerico resultadoPadrao)
            {
                return StatusCode(
                    (int)resultadoPadrao.CodigoHttp
                    , new
                    {
                        resultadoPadrao.Sucesso,
                        Resultado = (object) resultadoPadrao.Resultado
                    });
            }

            var notificacoesEnumeradas = notificacoes as Notification[] ?? notificacoes.ToArray();

            if (!notificacoesEnumeradas.Any())
            {
                await _uow.Salvar();
                return Ok(new
                {
                    Sucesso = true,
                    Resultado = resultado
                });
            }
            else
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Erros = notificacoesEnumeradas
                });
            }
        }
    }
}

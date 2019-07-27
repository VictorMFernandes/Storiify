using Storiify.Dominio.Comandos.AutenticacaoComandos.Entradas;
using Storiify.Dominio.Comandos.AutenticacaoComandos.Saidas;
using Storiify.Dominio.Gerenciadores;
using Storiify.Infra.BancoDeDados.Transacoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Storiify.Api.Controllers
{
    public class AutenticacaoController : ControladorBase
    {
        private readonly IConfiguration _config;
        private readonly AutenticacaoGerenciador _gerenciador;

        public AutenticacaoController(IUow uow, IConfiguration config, AutenticacaoGerenciador gerenciador) : base(uow)
        {
            _config = config;
            _gerenciador = gerenciador;
        }

        /// <summary>
        /// Loga um usuário no sistema.
        /// </summary>
        /// <param name="comando">Comando para logar usuário no sistema</param>
        /// <response code="200">Login realizado com sucesso.</response>
        [HttpPost("v1/logar")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AutenticarUsuarioComandoResultado), 200)]
        public async Task<IActionResult> Logar([FromBody]AutenticarUsuarioComando comando)
        {
            var resultado = await _gerenciador.Executar(comando);

            return await Resposta(resultado, _gerenciador.Notifications);
        }
    }
}

using Storiify.Dominio.Comandos.UsuarioComandos.Entradas;
using Storiify.Dominio.Comandos.UsuarioComandos.Saidas;
using Storiify.Dominio.Gerenciadores;
using Storiify.Infra.BancoDeDados.Transacoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Storiify.Api.Controllers
{
    public class UsuariosController : ControladorBase
    {
        private readonly UsuarioGerenciador _gerenciador;

        public UsuariosController(UsuarioGerenciador gerenciador, IUow uow)
            : base(uow)
        {
            _gerenciador = gerenciador;
        }

        /// <summary>
        /// Registra um usuário no sistema.
        /// </summary>
        /// <param name="comando">Comando para registrar usuário no sistema</param>
        /// <remarks>E-mail deve ser único.</remarks>
        /// <response code="200">Retorna as principais propriedades do usuário que acabou de ser registrado.</response>
        [ProducesResponseType(typeof(RegistrarUsuarioComandoResultado), 200)]
        [HttpPost]
        [Route("v1/[controller]")]
        [AllowAnonymous]
        public async Task<IActionResult> RegistrarUsuario([FromBody]RegistrarUsuarioComando comando)
        {
            var resultado = await _gerenciador.Executar(comando);
            return await Resposta(resultado, _gerenciador.Notifications);
        }
    }
}

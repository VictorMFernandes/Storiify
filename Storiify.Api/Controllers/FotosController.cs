using Storiify.Dominio.Comandos.FotoComandos.Entradas;
using Storiify.Dominio.Comandos.FotoComandos.Saidas;
using Storiify.Dominio.Gerenciadores;
using Storiify.Infra.BancoDeDados.Transacoes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Storiify.Api.Controllers
{
    public class FotosController : ControladorBase
    {
        private readonly FotoGerenciador _gerenciador;

        public FotosController(FotoGerenciador gerenciador, IUow uow)
            : base(uow)
        {
            _gerenciador = gerenciador;
        }

        /// <summary>
        /// Altera a foto de um usuário do sistema.
        /// </summary>
        /// <param name="usuarioId">Id do usuário que terá sua foto alterada.</param>
        /// <param name="comando">Comando para alterar a foto de um usuário.</param>
        /// <response code="200">Retorna Url da foto que foi criada.</response>
        [ProducesResponseType(typeof(AlterarFotoComandoResultado), 200)]
        [HttpPost]
        [Route("v1/Usuarios/{usuarioId}/[controller]")]
        public async Task<IActionResult> AlterarFotoUsuario(string usuarioId, [FromForm]AlterarFotoUsuarioComando comando)
        {
            comando.PegarIdsUsuarios(UsuarioLogadoId, usuarioId);

            var resultado = await _gerenciador.Executar(comando);
            return await Resposta(resultado, _gerenciador.Notifications);
        }
    }
}

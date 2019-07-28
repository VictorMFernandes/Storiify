using Storiify.Dominio.Comandos.UsuarioComandos.Saidas;
using Storiify.Dominio.Gerenciadores;
using Storiify.Infra.BancoDeDados.Transacoes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Storiify.Dominio.Comandos.HistoriaComandos.Entradas;

namespace Storiify.Api.Controllers
{
    public class HistoriasController : ControladorBase
    {
        private readonly HistoriaGerenciador _gerenciador;

        public HistoriasController(HistoriaGerenciador gerenciador, IUow uow)
            : base(uow)
        {
            _gerenciador = gerenciador;
        }

        /// <summary>
        /// Registra uma história no sistema.
        /// </summary>
        /// <param name="comando">Comando para registrar história no sistema</param>
        /// <response code="200">Retorna as principais propriedades da história que acabou de ser registrada.</response>
        [ProducesResponseType(typeof(RegistrarHistoriaComandoResultado), 200)]
        [HttpPost]
        [Route("v1/[controller]")]
        public async Task<IActionResult> RegistrarHistoria([FromBody]RegistrarHistoriaComando comando)
        {
            comando.PegarId(UsuarioLogadoId);
            var resultado = await _gerenciador.Executar(comando);
            return await Resposta(resultado, _gerenciador.Notifications);
        }
    }
}

using Storiify.Dominio.Comandos.UsuarioComandos.Saidas;
using Storiify.Dominio.Gerenciadores;
using Storiify.Infra.BancoDeDados.Transacoes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Storiify.Dominio.Comandos.HistoriaComandos.Entradas;

namespace Storiify.Api.Controllers
{
    public class PersonagensController : ControladorBase
    {
        private readonly PersonagemGerenciador _gerenciador;

        public PersonagensController(PersonagemGerenciador gerenciador, IUow uow)
            : base(uow)
        {
            _gerenciador = gerenciador;
        }

        /// <summary>
        /// Registra um personagem no sistema.
        /// </summary>
        /// <param name="historiaId">Id da história a qual o personagem pertencerá</param>
        /// <param name="comando">Comando para registrar personagem no sistema</param>
        /// <response code="200">Retorna as principais propriedades do personagem que acabou de ser registrado.</response>
        [ProducesResponseType(typeof(RegistrarPersonagemComandoResultado), 200)]
        [HttpPost]
        [Route("v1/Historias/{historiaId}/[controller]")]
        public async Task<IActionResult> RegistrarPersonagem(string historiaId, [FromBody]RegistrarPersonagemComando comando)
        {
            comando.PegarId(historiaId);

            var resultado = await _gerenciador.Executar(comando);
            return await Resposta(resultado, _gerenciador.Notifications);
        }
    }
}

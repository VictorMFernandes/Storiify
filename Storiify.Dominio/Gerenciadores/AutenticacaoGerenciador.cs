using Storiify.Compartilhado.Comandos;
using Storiify.Dominio.Comandos.AutenticacaoComandos.Entradas;
using Storiify.Dominio.Repositorios;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Storiify.Compartilhado.Padroes;
using Storiify.Dominio.Enums;
using Storiify.Compartilhado.Extensoes;
using Storiify.Dominio.ValueObjects;

namespace Storiify.Dominio.Gerenciadores
{
    public class AutenticacaoGerenciador : Gerenciador
        , IComandoGerenciador<AutenticarUsuarioComando>
    {

        private readonly IUsuarioRepositorio _usuarioRepo;
        private readonly IConfiguration _config;

        public AutenticacaoGerenciador(IUsuarioRepositorio usuarioRepo, IConfiguration config)
        {
            _usuarioRepo = usuarioRepo;
            _config = config;
        }

        #region Comandos

        public async Task<IComandoResultado> Executar(AutenticarUsuarioComando comando)
        {
            if (!ValidarComando(comando))
                return null;

            // Pega usuario pelo login
            var usuario = await _usuarioRepo.PegarPorLogin(comando.Login);

            // Confere a senha
            if (usuario == null || !Autenticacao.ConferirSenhas(usuario.Senha, comando.Senha))
            {
                AddNotification("Usuario", PadroesMensagens.UsuarioOuSenhaInvalidos);
                return null;
            }

            var tokenSecreto = _config.GetSection(EConfigSecao.TokenSecreto.EnumTextos().Nome).Value;
            var prescricaoToken = double.Parse(_config.GetSection(EConfigSecao.PrescricaoTokenDias.EnumTextos().Nome).Value);

            usuario.PrepararParaRetornar(Autenticacao.GerarToken(usuario.Id, comando.Login, tokenSecreto, prescricaoToken));

            return usuario;
        }
        
        #endregion
    }
}

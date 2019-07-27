using Storiify.Compartilhado.Comandos;
using Storiify.Dominio.Comandos.UsuarioComandos.Entradas;
using Storiify.Dominio.Comandos.UsuarioComandos.Saidas;
using Storiify.Dominio.Repositorios;
using Storiify.Dominio.Servicos;
using System.Threading.Tasks;
using Storiify.Compartilhado.Comandos.Genericos;
using Storiify.Compartilhado.Padroes;

namespace Storiify.Dominio.Gerenciadores
{
    public class UsuarioGerenciador : Gerenciador
        , IComandoGerenciador<RegistrarUsuarioComando>
        , IComandoGerenciador<AtualizarUsuarioComando>
    {
        private readonly IUsuarioRepositorio _usuarioRepo;
        private readonly IEmailServico _emailServico;

        public UsuarioGerenciador(IUsuarioRepositorio usuarioRepo, IEmailServico emailServico)
        {
            _usuarioRepo = usuarioRepo;
            _emailServico = emailServico;
        }

        #region Comandos

        public async Task<IComandoResultado> Executar(RegistrarUsuarioComando comando)
        {
            if (!ValidarComando(comando))
                return null;

            // Verificar se o e-mail já existe na base
            if (await _usuarioRepo.EmailExiste(comando.Email))
                AddNotification("Email", string.Format(PadroesMensagens.EmailEmUso, comando.Email));

            // Criar a entidade
            var usuario = comando.GerarEntidade();

            // Validar entidade
            AddNotifications(usuario);

            if (Invalid) return null;

            // Persistir o usuário
            _usuarioRepo.Criar(usuario);

            // Enviar um e-mail de boas vindas
            _emailServico.Enviar(usuario.Email.Endereco, "victorfernandes92@gmail.com", "Bem Vindo", "Seja bem vindo ao CondoFácil!");

            // Retornar o resultado para tela
            return new RegistrarUsuarioComandoResultado(usuario.Id, usuario.ToString(), usuario.Email.Endereco);
        }

        public async Task<IComandoResultado> Executar(AtualizarUsuarioComando comando)
        {
            if (!ValidarComando(comando))
                return null;

            // Recupera usuário do banco
            var usuario = await _usuarioRepo.PegarPorId(comando.Id);

            // Caso o usuário não exista
            if (usuario == null)
            {
                return new NaoEncontradoResultado(PadroesMensagens.UsuarioNaoEncontrado);
            }

            // Atualiza o usuário

            // Valida
            AddNotifications(usuario);

            if (Invalid)
                return null;

            // Persistir o usuário
            _usuarioRepo.Atualizar(usuario);

            // TODO implementar retorno
            return null;
        }

        #endregion
    }
}

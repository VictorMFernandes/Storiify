using Storiify.Compartilhado.Comandos;
using Storiify.Dominio.Comandos.FotoComandos.Entradas;
using Storiify.Dominio.Comandos.FotoComandos.Saidas;
using Storiify.Dominio.Repositorios;
using Storiify.Dominio.Servicos;
using System.Threading.Tasks;
using Storiify.Compartilhado.Comandos.Genericos;
using Storiify.Compartilhado.Padroes;

namespace Storiify.Dominio.Gerenciadores
{
    public class FotoGerenciador : Gerenciador
        , IComandoGerenciador<AlterarFotoUsuarioComando>
    {
        private readonly IUsuarioRepositorio _usuarioRepo;
        private readonly IFotoServico _fotoServico;

        public FotoGerenciador(IUsuarioRepositorio usuarioRepo
            , IFotoServico fotoServico)
        {
            _usuarioRepo = usuarioRepo;
            _fotoServico = fotoServico;
        }

        #region Comandos

        public async Task<IComandoResultado> Executar(AlterarFotoUsuarioComando comando)
        {
            // Verifica a validade do comando
            if (!ValidarComando(comando))
                return null;

            // Checa se o usuário tem permissão para fazer a ação
            if (comando.UsuarioId != comando.UsuarioLogadoId)
            {
                return new NaoAutorizadoResultado("Não é possível alterar a foto de outro usuário");
            }

            // Recupera usuário do banco
            var usuario = await _usuarioRepo.PegarPorId(comando.UsuarioId);

            // Caso o usuário não exista
            if (usuario == null)
            {
                return new NaoEncontradoResultado(PadroesMensagens.UsuarioNaoEncontrado);
            }

            if (!string.IsNullOrEmpty(usuario.Foto.IdPublico)) _fotoServico.DeletarFoto(usuario.Foto.IdPublico);

            var foto = _fotoServico.UploadFoto(comando.ArquivoFoto);

            // Validar entidade
            AddNotifications(foto);

            if (Invalid)
            {
                _fotoServico.DeletarFoto(foto.IdPublico);
                return null;
            }

            // Persistir a foto
            usuario.AtualizarFoto(foto);
            _usuarioRepo.Atualizar(usuario);

            // Retornar o resultado para tela
            return new AlterarFotoComandoResultado(foto.Url);
        }

        #endregion
    }
}

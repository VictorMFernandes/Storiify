using Storiify.Dominio.Entidades;
using Storiify.Dominio.Repositorios;
using Storiify.Dominio.Servicos;
using Storiify.Dominio.ValueObjects;
using Storiify.Infra.BancoDeDados.Transacoes;
using Storiify.Compartilhado.Padroes;

namespace Storiify.Infra.BancoDeDados.Contexto
{
    public class SemeadorBd : ISemeadorBd
    {
        private readonly IUsuarioRepositorio _usuarioRepo;
        private readonly IUow _uow;

        public SemeadorBd(IUsuarioRepositorio usuarioRepo, IUow uow)
        {
            _usuarioRepo = usuarioRepo;
            _uow = uow;
        }

        public async void SemearBancoDeDados()
        {
            if (await _usuarioRepo.IdExiste(PadroesString.UsuarioId))
                return;

            var nome = new Nome(PadroesString.UsuarioNome);
            var email = new Email(PadroesString.UsuarioEmail);
            var autenticacao = new Autenticacao(PadroesString.UsuarioLogin
                                                , PadroesString.UsuarioSenha
                                                , PadroesString.UsuarioSenha);

            var usuario = new Usuario(PadroesString.UsuarioId, nome, email, autenticacao);
            _usuarioRepo.Criar(usuario);

            await _uow.Salvar();
        }
    }
}

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
        private readonly IHistoriaRepositorio _historiaRepo;
        private readonly IUow _uow;

        public SemeadorBd(IUsuarioRepositorio usuarioRepo, IHistoriaRepositorio historiaRepo
            , IUow uow)
        {
            _usuarioRepo = usuarioRepo;
            _historiaRepo = historiaRepo;

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

            nome = new Nome(PadroesString.SerieHistoriasNome);
            var serieHistorias = new SerieHistorias(PadroesString.SerieHistoriasId, nome);

            nome = new Nome(PadroesString.Historia1Nome);
            var historia = new Historia(PadroesString.Historia1Id, nome, serieHistorias, PadroesString.UsuarioId);
            historia.DefinirSerieHistorias(serieHistorias);

            nome = new Nome(PadroesString.Personagem1Nome);
            var personagem = new Personagem(PadroesString.Personagem1Id, nome, PadroesString.Historia1Id);

            historia.Personagens.Add(personagem);

            nome = new Nome(PadroesString.Personagem2Nome);
            personagem = new Personagem(PadroesString.Personagem2Id, nome, PadroesString.Historia1Id);

            historia.Personagens.Add(personagem);

            _historiaRepo.Criar(historia);

            nome = new Nome(PadroesString.Historia2Nome);
            historia = new Historia(PadroesString.Historia2Id, nome, serieHistorias, PadroesString.UsuarioId);
            historia.DefinirSerieHistorias(serieHistorias);

            _historiaRepo.Criar(historia);

            await _uow.Salvar();
        }
    }
}

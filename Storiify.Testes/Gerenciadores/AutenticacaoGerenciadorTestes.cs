using Storiify.Dominio.Comandos.AutenticacaoComandos.Entradas;
using Storiify.Dominio.Gerenciadores;
using Storiify.Dominio.Sistema.Exemplos;
using Storiify.Testes.Falsos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Storiify.Testes.Gerenciadores
{
    [TestClass]
    public class AutenticacaoGerenciadorTestes : IGerenciadorTestes
    {
        private readonly AutenticacaoGerenciador _gerenciador;

        private readonly AutenticarUsuarioComando _autenticarUsuarioComandoValido;
        private readonly AutenticarUsuarioComando _autenticarUsuarioComandoInvalido;

        public AutenticacaoGerenciadorTestes()
        {
            _gerenciador = new AutenticacaoGerenciador(new UsuarioRepositorioFalso(), new ConfigurationFalso());

            _autenticarUsuarioComandoValido = ExemplosComando.AutenticarUsuario;
            _autenticarUsuarioComandoInvalido = new AutenticarUsuarioComando(string.Empty, "senha");
        }

        [TestMethod]
        public void ValidarComandosAoExecutalos()
        {
            _ = _gerenciador.Executar(_autenticarUsuarioComandoValido);

            Assert.IsTrue(_autenticarUsuarioComandoValido.FoiValidado);
        }

        [TestMethod]
        public async void RetornarNullQuandoComandoInvalido()
        {
            var resultado = await _gerenciador.Executar(_autenticarUsuarioComandoInvalido);

            Assert.IsNull(resultado);
        }
    }
}

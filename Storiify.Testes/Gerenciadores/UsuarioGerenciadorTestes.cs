using Storiify.Dominio.Comandos.UsuarioComandos.Entradas;
using Storiify.Dominio.Gerenciadores;
using Storiify.Dominio.Sistema.Exemplos;
using Storiify.Testes.Falsos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Storiify.Testes.Gerenciadores
{
    [TestClass]
    public class UsuarioGerenciadorTestes : IGerenciadorTestes
    {
        private readonly UsuarioGerenciador _gerenciador;

        private readonly RegistrarUsuarioComando _registrarUsuarioComandoValido;
        private readonly RegistrarUsuarioComando _registrarUsuarioComandoInvalido;

        public UsuarioGerenciadorTestes()
        {
            _gerenciador = new UsuarioGerenciador(new UsuarioRepositorioFalso(), new EmailServicoFalso());

            _registrarUsuarioComandoValido = ExemplosComando.RegistrarUsuario;
            _registrarUsuarioComandoInvalido = new RegistrarUsuarioComando(
                "Primeiro Sobrenome", "email", "senha", "senha");
        }

        [TestMethod]
        public void ValidarComandosAoExecutalos()
        {
            _ = _gerenciador.Executar(_registrarUsuarioComandoValido);

            Assert.IsTrue(_registrarUsuarioComandoValido.FoiValidado);
        }

        [TestMethod]
        public async void RetornarNullQuandoComandoInvalido()
        {
            var resultado = await _gerenciador.Executar(_registrarUsuarioComandoInvalido);

            Assert.IsNull(resultado);
        }
    }
}

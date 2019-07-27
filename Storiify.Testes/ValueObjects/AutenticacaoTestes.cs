using Storiify.Dominio.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Storiify.Testes.ValueObjects
{
    [TestClass]
    public class AutenticacaoTestes
    {
        [TestMethod]
        public void InvalidarQuandoSenhasDiferentes()
        {
            var autenticacao = new Autenticacao("login", "senha", "senhaDiferente");

            Assert.IsTrue(autenticacao.Invalid);
            Assert.AreNotEqual(0, autenticacao.Notifications.Count);
        }

        [TestMethod]
        public void ValidarQuandoSenhasIguais()
        {
            var autenticacao = new Autenticacao("meuLogin", "senha", "senha");

            Assert.IsTrue(autenticacao.Valid);
            Assert.AreEqual(0, autenticacao.Notifications.Count);
        }
    }
}

using Storiify.Dominio.Servicos;

namespace Storiify.Infra.Servicos
{
    public class EmailServico : IEmailServico
    {
        public void Enviar(string para, string de, string assunto, string corpo)
        {
            // TODO implementar system.net.mail
        }
    }
}

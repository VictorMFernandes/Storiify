using Storiify.Dominio.Servicos;

namespace Storiify.Testes.Falsos
{
    internal class EmailServicoFalso : IEmailServico
    {
        public void Enviar(string para, string de, string assunto, string corpo)
        {
            
        }
    }
}

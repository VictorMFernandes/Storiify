namespace Storiify.Dominio.Servicos
{
    public interface IEmailServico
    {
        void Enviar(string para, string de, string assunto, string corpo);
    }
}

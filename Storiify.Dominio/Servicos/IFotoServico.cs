using Storiify.Dominio.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Storiify.Dominio.Servicos
{
    public interface IFotoServico
    {
        Foto UploadFoto(IFormFile arquivo);
        bool DeletarFoto(string idPublico);
    }
}

using Storiify.Dominio.Servicos;
using Storiify.Dominio.ValueObjects;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Storiify.Infra.Servicos
{
    public class FotoServico : IFotoServico
    {
        private const string CloudName = "appinova";
        private const string ApiKey = "349134115664522";
        private const string ApiSecret = "Fk94NY4BihdwFC2RVT4Jeca7J6w";

        private readonly Cloudinary _cloudinary;

        public FotoServico()
        {
            var acc = new Account(
                CloudName,
                ApiKey,
                ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }

        public Foto UploadFoto(IFormFile arquivo)
        {
            using (var stream = arquivo.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(arquivo.Name, stream),
                    Transformation = new Transformation()
                        .Width(500).Height(500).Crop("fill").Gravity("face")
                };

                var resultadoUpload = _cloudinary.Upload(uploadParams);

                return new Foto(resultadoUpload.Uri.ToString(), resultadoUpload.PublicId);
            }
        }

        public bool DeletarFoto(string idPublico)
        {
            if (string.IsNullOrEmpty(idPublico)) return true;

            var deletarParams = new DeletionParams(idPublico);
            var resultado = _cloudinary.Destroy(deletarParams);

            return resultado.Result == "ok";
        }
    }
}

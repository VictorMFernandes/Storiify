using System;

namespace Storiify.Compartilhado.Extensoes
{
    public static class GuidExtensoes
    {
        public static string EmBase64(this Guid guid)
        {
            var guidString = Convert.ToBase64String(guid.ToByteArray());
            guidString = guidString.Replace("=", string.Empty);
            guidString = guidString.Replace("/", string.Empty);
            return guidString.Replace("+", string.Empty);
        }
    }
}

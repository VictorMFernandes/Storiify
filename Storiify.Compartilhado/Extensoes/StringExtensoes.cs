using System.Text;
using Storiify.Compartilhado.Padroes;

namespace Storiify.Compartilhado.Extensoes
{
    public static class StringExtensoes
    {
        public static bool SomenteNumero(this string str)
        {
            if (str == null) return false;

            foreach (var c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public static string EmCamelCase(this string str)
        {
            var sb = new StringBuilder();
            var charEhSeparador = false;

            foreach (var c in str)
            {
                if (c == '-' || c == '_')
                {
                    charEhSeparador = true;
                }
                else if (charEhSeparador)
                {
                    sb.Append(char.ToUpper(c));
                    charEhSeparador = false;
                }
                else
                {
                    sb.Append(char.ToLower(c));
                }
            }

            return sb.ToString();
        }

        public static bool CpfValido(this string cpf)
        {
            var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);
            if (cpf.Length != 11)
                return false;
            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            var resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            var digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool CnpjValido(this string cnpj)
        {
            var multiplicador1 = new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
            if (cnpj.Length != 14)
                return false;
            var tempCnpj = cnpj.Substring(0, 12);
            var soma = 0;
            for (var i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            var resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            var digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (var i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static bool TelefoneValido(this string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone)) return false;

            if (!telefone.SomenteNumero()) return false;

            if (telefone.Length < PadroesTamanho.MinTelefone) return false;

            return telefone.Length <= PadroesTamanho.MaxTelefone;
        }
    }
}

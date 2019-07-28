namespace Storiify.Compartilhado.Padroes
{
    public class PadroesMensagens
    {
        public const string UsuarioNaoEncontrado = "Usuário não encontrado";
        public const string UsuarioOuSenhaInvalidos = "Usuário ou senha inválidos";
        /// <summary>
        /// {0} Nome do ministério
        /// </summary>
        public const string UsuarioNaoVinculado = "Usuário não vinculado ao ministério {0}";

        public const string UsuarioSemPermissao = "O Usuário não tem permissão para realizar essa ação";

        public const string LinkInvalido = "Link convite inválido";

        #region Email

        /// <summary>
        /// {0} E-mail que está em uso
        /// </summary>
        public const string EmailEmUso = "O E-mail {0} já está em uso";
        /// <summary>
        /// {0} E-mail que está inválido
        /// </summary>
        public const string EmailInvalido = "E-mail {0} inválido";

        #endregion

        #region Foto

        /// <summary>
        /// {0} Url que está inválida
        /// </summary>
        public const string UrlInvalida = "A Url {0} é inválida";
        public static string UrlMax = $"A Url de uma imagem deve ter no máximo {PadroesTamanho.MaxFotoUrl} caracteres";
        public static string IdPublicoMax = $"O Id Público de uma foto deve ter no máximo {PadroesTamanho.MaxFotoIdPublico} caracteres";

        #endregion

        #region Id

        /// <summary>
        /// {0} Id que está inválido
        /// </summary>
        public const string IdInvalido = "O Id {0} é inválido";

        #endregion

        #region Login

        public static string LoginMin = $"O login deve conter no mínimo {PadroesTamanho.MinLogin} caracteres";
        public static string LoginMax = $"O login deve conter no máximo {PadroesTamanho.MaxLogin} caracteres";

        public static string SenhasDiferentes = "As senhas não coincidem";

        #endregion

        #region Nome

        public static string NomeMin = $"O Nome deve conter no mínimo {PadroesTamanho.MinNome} caracteres";
        public static string NomeMax = $"O Nome deve conter no máximo {PadroesTamanho.MaxNome} caracteres";

        #endregion

        #region Telefone

        /// <summary>
        /// {0} número de telefone que está inválido
        /// </summary>
        public const string TelefoneInvalido = "Telefone {0} inválido";

        #endregion
    }
}

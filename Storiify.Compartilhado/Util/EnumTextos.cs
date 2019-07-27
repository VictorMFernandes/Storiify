using System;

namespace Storiify.Compartilhado.Util
{
    public class EnumTextos : Attribute
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public EnumTextos(string nome)
        {
            Nome = nome;
        }

        public EnumTextos(string nome, string descricao)
            : this(nome)
        {
            Descricao = descricao;
        }
    }
}

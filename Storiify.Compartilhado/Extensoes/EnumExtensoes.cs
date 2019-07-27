using Storiify.Compartilhado.Util;
using System;
using System.Reflection;

namespace Storiify.Compartilhado.Extensoes
{
    public static class EnumExtensoes
    {
        /// <summary>
        /// Recupera o valor contido atributo EnumTextos.
        /// </summary>
        /// <param name="enumAlvo"></param>
        public static EnumTextos EnumTextos(this Enum enumAlvo)
        {
            Type type = enumAlvo.GetType();
            FieldInfo fi = type.GetField(enumAlvo.ToString());
            if (fi != null)
            {
                return fi.GetCustomAttribute(typeof(EnumTextos), false) as EnumTextos;
            }

            return new EnumTextos(string.Empty);
        }
    }
}

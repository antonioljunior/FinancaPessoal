using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensoes
{
    public static class ExtensionMethods
    {
        public static int? ToInt(this object valor)
        {
            int resultado;
            if (int.TryParse(valor.ToString(), out resultado))
                return resultado;

            return null;
        }

        public static DateTime? ToDateTime(this object valor)
        {
            DateTime resultado;
            if (DateTime.TryParse(valor.ToString(), out resultado))
                return resultado;

            return null;
        }

        public static string RemoverMascara(this string valor)
        {
            return valor.Replace(".", "").
                Replace("-", "").
                Replace("(", "").
                Replace(")", "").
                Replace("/", "");
        }
    }
}

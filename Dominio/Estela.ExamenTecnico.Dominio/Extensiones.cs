using Estela.ExamenTecnico.Dominio.Exceptions;
using System.Text.RegularExpressions;

namespace Estela.ExamenTecnico
{
    public static class Extensiones
    {
        public static string Cadena(this int entero, int longitud)
        {
            var str = entero.ToString();
            while (str.Length < longitud)
            {
                str = "0" + str;
            }
            return str;
        }

        public static string Cadena(this int? entero, int longitud)
        {
            return (entero ?? 0).Cadena(longitud);
        }

        public static string Cadena(this Guid id)
        {
            return Convert.ToBase64String(id.ToByteArray())
              .Replace("/", "-")
              .Replace("+", "_")
              .Replace("=", "");
        }

        public static string? Cadena(this Guid? id)
        {
            if (id.HasValue)
                return id.Value.Cadena();
            return null;
        }

        public static bool EsGuid(this string cadena)
        {
            if (string.IsNullOrEmpty(cadena))
                return false;
            if (cadena.Length != 22)
                return false;
            return Regex.IsMatch(cadena, "[a-zA-Z0-9_-]{22}");
        }

        public static Guid Guid(this string cadena)
        {
            if (string.IsNullOrEmpty(cadena)) throw new ArgumentNullException(nameof(cadena));
            if (!cadena.EsGuid()) throw new GuidFormatException(cadena);

            var tmp = cadena.Replace("-", "/")
              .Replace("_", "+");
            return new Guid(Convert.FromBase64String(tmp + "=="));
        }

        public static Guid? GuidONull(this string cadena)
        {
            if (string.IsNullOrEmpty(cadena))
                return null;

            return cadena.Guid();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras_de_Datos.Comunes
{
    public interface ITextoTamañoFijo
    {
        /// <summary>
        /// Cantidad de caracteres que siempre sera devuelta por el método ConvertirATextoTamñoFijo, esta no se deverá
        /// cambiar ya que se utilizará para calcular posiciones en los archivos.
        /// </summary>
        int TamañoEnTexto { get; }
        /// <summary>
        /// Devuelve una representación en string del objeto.
        /// </summary>
        /// <returns></returns>
        string ConvertirATextoTamañoFijo();
    }
}

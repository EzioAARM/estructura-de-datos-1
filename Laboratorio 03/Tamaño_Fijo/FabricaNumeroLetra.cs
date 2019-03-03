using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estructuras_de_Datos.Comunes;

namespace Laboratorio_03.Tamaño_Fijo
{
    class FabricaNumeroLetra : IFabricaTextoTamañoFijo<NumeroLetra>
    {
        public NumeroLetra Fabricar(string textoTamañoFijo)
        {
            NumeroLetra nl = new NumeroLetra();
            nl.Numero = Convert.ToInt32(textoTamañoFijo.Substring(0, 11));
            nl.Letra = Convert.ToChar(textoTamañoFijo.Substring(11, 1));
            return nl;
        }

        public NumeroLetra FabricarNulo()
        {
            return new NumeroLetra();
        }
    }
}

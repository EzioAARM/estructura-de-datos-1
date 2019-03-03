using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estructuras_de_Datos.Comunes;

namespace Laboratorio_03.Tamaño_Fijo
{

    public class NumeroLetra : ITextoTamañoFijo, IComparable
    {
        private const string TextoEnteroFormato = "00000000000;-0000000000";

        public int Numero { get; set; }
        public char Letra { get; set; }

        public NumeroLetra()
        {
            Numero = 0;
            Letra = '0';
        }

        public NumeroLetra(int numero, char letra)
        {
            Numero = numero;
            Letra = letra;
        }

        public int TamañoEnTexto
        {
            get
            {
                return 12;
            }
        }

        public string ConvertirATextoTamañoFijo()
        {
            return Numero.ToString(TextoEnteroFormato) + Letra.ToString();
        }

        public int CompareTo(Object theObject)
        {
            string Total = Numero.ToString() + Letra.ToString();

            return theObject.ToString().CompareTo(Total);
        }

        public override string ToString()
        {
            return ConvertirATextoTamañoFijo();
        }
    }
}

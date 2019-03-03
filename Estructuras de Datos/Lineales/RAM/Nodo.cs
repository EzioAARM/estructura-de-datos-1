using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras_de_Datos.Lineales.RAM
{
    internal class Nodo<T> where T : IComparable
    {
        internal T Dato { get; set; }
        internal Nodo<T> Siguiente { get; set; }
        internal Nodo<T> Anterior { get; set; }

        internal Nodo(T dato)
        {
            Dato = dato;
            Siguiente = null;
            Anterior = null;
        }
    }
}

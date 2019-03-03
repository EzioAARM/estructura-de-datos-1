using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras_de_Datos.No_Lineales.RAM
{
    internal class Nodo<TLlave, T> where TLlave : IComparable
    {
        public TLlave Llave { get; set; }
        public T Dato { get; set; }
        public Nodo<TLlave, T> Izquierda { get; set; }
        public Nodo<TLlave, T> Derecha { get; set; }
        public Nodo<TLlave, T> Padre { get; set; }

        public Nodo(TLlave llave, T dato)
        {
            Llave = llave;
            Dato = dato;
            Izquierda = null;
            Derecha = null;
            Padre = null;
        }
    }
}

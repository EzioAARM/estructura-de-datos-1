using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;



namespace Estructuras_de_Datos.No_Lineales
{
    public abstract class ArbolBusqueda<TLlave, T> where TLlave : IComparable //Es el molde para el resto de arboles.
    {
        public int Tamaño { get; protected set; }

        public abstract void Agregar(TLlave llave, T dato);

        public abstract void Eliminar(TLlave llave);

        public abstract T Obtener(TLlave llave);

        public abstract bool Contiene(TLlave llave);

        public abstract Bitmap Dibujar();

        public abstract string RecorrerPreOrden();

        public abstract string RecorrerInOrden();

        public abstract string RecorrerPostOrden();

        public abstract int ObtenerAltura();

        public abstract void Cerrar();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras_de_Datos.Lineales
{
    public abstract class Lista<T> where T : IComparable
    {
        public int Tamanio { get; protected set; }
        public abstract void AgregarAlInicio(T dato);
        public abstract void AgregarAlFinal(T dato);
        public abstract void Insertar(T dato, int posicion);
        public abstract void EliminarAlInicio();
        public abstract void EliminarAlFinal();
        public abstract void Eliminar(int posicion);
        public abstract T ObtenerAlInicio();
        public abstract T ObtenerAlFinal();
        public abstract T Obtener(int posicion);
        public abstract T[] GenerarArreglo();

        protected void ValidarPosicion(int posicion, bool PermitirIgualTamanio)
        {
            if ((posicion > (PermitirIgualTamanio ? Tamanio : Tamanio - 1)) || (posicion < 0))
            {
                throw new ArgumentOutOfRangeException("posición");
            }
        }
        public abstract void Cerrar();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras_de_Datos.Lineales.RAM
{
    public class ListaEnlazada<T> : Lista<T> where T : IComparable
    {
        private Nodo<T> _cabeza;

        private void UbicarPosicion(int posicion, ref Nodo<T> nodoAnterior, ref Nodo<T> nodoActual)
        {
            nodoAnterior = null;
            nodoActual = _cabeza;

            for (int i = 0; i < posicion; i++)
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.Siguiente;
            }
        }

        public ListaEnlazada()
        {
            Tamanio = 0;
            _cabeza = null;
        }

        public override void AgregarAlInicio(T dato)
        {
            Nodo<T> nodoNuevo = new Nodo<T>(dato);

            if (_cabeza == null)
            {
                _cabeza = nodoNuevo;
            }
            else
            {
                nodoNuevo.Siguiente = _cabeza;
                _cabeza = nodoNuevo;
            }
            Tamanio++;
        }

        public override void Insertar(T dato, int posicion)
        {
            Nodo<T> nodoNuevo = new Nodo<T>(dato);
            Nodo<T> nodoActual = null;
            Nodo<T> nodoAnterior = null;

            ValidarPosicion(posicion, true);

            if (posicion == 0)
            {
                AgregarAlInicio(dato);
                return;
            }

            UbicarPosicion(posicion, ref nodoAnterior, ref nodoActual);

            nodoAnterior.Siguiente = nodoNuevo;
            nodoNuevo.Siguiente = nodoActual;

            Tamanio++;
        }

        public override void AgregarAlFinal(T dato)
        {
            Insertar(dato, Tamanio);
        }

        public override void EliminarAlInicio()
        {
            if (_cabeza == null)
            {
                throw new ArgumentOutOfRangeException("posicion");
            }
            else
            {
                _cabeza = _cabeza.Siguiente;
            }
            Tamanio--;
        }

        public override void Eliminar(int posicion)
        {
            Nodo<T> nodoActual = null;
            Nodo<T> nodoAnterior = null;

            ValidarPosicion(posicion, false);

            if (posicion == 0)
            {
                EliminarAlInicio();
                return;
            }

            UbicarPosicion(posicion, ref nodoAnterior, ref nodoActual);
            nodoAnterior.Siguiente = nodoActual.Siguiente;
            Tamanio--;
        }

        public override void EliminarAlFinal()
        {
            Eliminar(Tamanio - 1);
        }

        public override T ObtenerAlInicio()
        {
            if (_cabeza == null)
            {
                throw new ArgumentOutOfRangeException("posicion");
            }
            else
            {
                return _cabeza.Dato;
            }
        }

        public override T Obtener(int posicion)
        {
            Nodo<T> nodoActual = null;
            Nodo<T> nodoAnterior = null;

            ValidarPosicion(posicion, false);

            if (posicion == 0)
            {
                return ObtenerAlInicio();
            }

            UbicarPosicion(posicion, ref nodoAnterior, ref nodoActual);

            return nodoActual.Dato;
        }

        public override T ObtenerAlFinal()
        {
            return Obtener(Tamanio - 1);
        }

        public override T[] GenerarArreglo()
        {
            T[] resultado = new T[Tamanio];
            Nodo<T> nodoActual = _cabeza;
            int posicion = 0;

            while (nodoActual != null)
            {
                resultado[posicion] = nodoActual.Dato;
                posicion++;

                nodoActual = nodoActual.Siguiente;
            }
            return resultado;
        }

        public override void Cerrar()
        {
            //_archivo.Close();
        }
    }
}

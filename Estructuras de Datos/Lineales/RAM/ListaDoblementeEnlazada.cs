using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras_de_Datos.Lineales.RAM
{
    public class ListaDoblementeEnlazada<T> : Lista<T> where T : IComparable
    {
        private Nodo<T> _cabeza;
        private Nodo<T> _cola;

        private void UbicarPosicion(int posicion, ref Nodo<T> nodoActual)
        {
            if (posicion < (Tamanio / 2))
            {
                nodoActual = _cabeza;
                for (int i = 0; i < posicion; i++)
                {
                    nodoActual = nodoActual.Siguiente;
                }
            }
            else
            {
                nodoActual = _cola;
                for (int i = Tamanio - 1; i > posicion; i++)
                {
                    nodoActual = nodoActual.Anterior;
                    
                }
            }
        }

        public override void AgregarAlInicio(T dato)
        {
            Nodo<T> nodoNuevo = new Nodo<T>(dato);

            if (_cabeza == null)
            {
                _cabeza = nodoNuevo;
                _cola = nodoNuevo;
            }
            else
            {
                nodoNuevo.Siguiente = _cabeza;
                _cabeza.Anterior = nodoNuevo;
                _cabeza = nodoNuevo;
            }
            Tamanio++;
        }

        public override void Insertar(T dato, int posicion)
        {
            Nodo<T> nodoNuevo = new Nodo<T>(dato);
            Nodo<T> nodoActual = null;

            ValidarPosicion(posicion, true);

            if (posicion == 0)
            {
                AgregarAlInicio(dato);
                return;
            }
            if (posicion == Tamanio)
            {
                AgregarAlFinal(dato);
                return;
            }
            UbicarPosicion(posicion, ref nodoActual);

            nodoNuevo.Anterior = nodoActual.Anterior;
            nodoNuevo.Siguiente = nodoActual;

            nodoActual.Anterior.Siguiente = nodoNuevo;
            nodoActual.Anterior = nodoNuevo;
            
            Tamanio++;
        }

        public override void AgregarAlFinal(T dato)
        {
            Nodo<T> nodoNuevo = new Nodo<T>(dato);
            Nodo<T> nodoActual = null;

            UbicarPosicion(Tamanio, ref nodoActual);

            nodoNuevo.Anterior = _cola.Anterior;
            nodoNuevo.Siguiente = _cola;

            _cola.Anterior.Siguiente = nodoNuevo;
            _cola.Anterior = nodoNuevo;

            Tamanio++;
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

            UbicarPosicion(posicion, ref nodoActual);
            nodoAnterior = nodoActual.Anterior;
            nodoAnterior.Siguiente = nodoActual.Siguiente;
            nodoActual.Siguiente.Anterior = nodoActual.Anterior;

            Tamanio--;
        }

        public override void EliminarAlInicio()
        {
            if (_cabeza == null)
            {
                throw new NotImplementedException("posicion");
            }
            else
            {
                _cabeza = _cabeza.Siguiente;
            }
        }

        public override void EliminarAlFinal()
        {
            Eliminar(Tamanio - 1);
        }

        public override T ObtenerAlInicio()
        {
            if (_cabeza == null)
            {
                throw new NotImplementedException("posicion");
            }
            else
            {
                return _cabeza.Dato;
            }
        }

        public override T ObtenerAlFinal()
        {
            return Obtener(Tamanio - 1);
        }

        public override T Obtener(int posicion)
        {
            Nodo<T> nodoActual = null;

            UbicarPosicion(posicion, ref nodoActual);

            return nodoActual.Dato;
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

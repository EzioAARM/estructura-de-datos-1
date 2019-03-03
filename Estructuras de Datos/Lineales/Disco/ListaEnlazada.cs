using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estructuras_de_Datos.Comunes;
using System.IO;

namespace Estructuras_de_Datos.Lineales.Disco
{
    public class ListaEnlazada<T> : Lista<T> where T : IComparable, ITextoTamañoFijo
    {
        #region Atributos

        //Tamaño total del encabezado
        private const int _tamañoEncabezadoBinario = 3 * Utilidades.EnteroYEnterBinarioTamaño;

        // Atributos en el encabezado del archivo
        private int _cabeza;
        private int _ultimaPosicionLibre;

        // Otras variables para acceso al archivo
        private FileStream _archivo = null;
        private string _archivoNombre = "";
        private IFabricaTextoTamañoFijo<T> _fabrica = null;

        #endregion

        #region Metodo Privado

        private void GuardarEncabezado()
        {
            // Se escribe a disco
            Utilidades.EscribirEntero(_archivo, 0, _cabeza);
            Utilidades.EscribirEntero(_archivo, 1, _ultimaPosicionLibre);
            Utilidades.EscribirEntero(_archivo, 2, Tamanio);
            _archivo.Flush();
        }

        private void UbicarPosicion(int posicion, ref Nodo<T> nodoAnterior, ref Nodo<T> nodoActual)
        {
            nodoAnterior = null;
            nodoActual = Nodo<T>.CrearNodoDesdeDisco(_archivo, _tamañoEncabezadoBinario, _cabeza, _fabrica);
            for (int i = 0; i < posicion; i++)
            {
                nodoAnterior = nodoActual;
                if (nodoActual.Siguiente == Utilidades.ApuntadorVacio)
                    nodoActual = new Nodo<T>(-1, _fabrica.FabricarNulo());
                else
                    nodoActual = Nodo<T>.CrearNodoDesdeDisco(_archivo, _tamañoEncabezadoBinario, nodoActual.Siguiente, _fabrica);
            }
        }

        #endregion

        public ListaEnlazada(string nombreArchivo, IFabricaTextoTamañoFijo<T> fabrica)
        {
            // Se guardan los parámetros recibidos
            _archivoNombre = nombreArchivo;
            _fabrica = fabrica;

            // Se abre la conexión al archivo
            _archivo = new FileStream(_archivoNombre, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);

            // Se obtienen los valores del encabezado del archivo
            _cabeza = Utilidades.LeerEntero(_archivo, 0);
            _ultimaPosicionLibre = Utilidades.LeerEntero(_archivo, 1);
            Tamanio = Utilidades.LeerEntero(_archivo, 2);

            // Se corrigen los valores del encabezado cuando el archivo no existe previamente
            if (_ultimaPosicionLibre == Utilidades.ApuntadorVacio)
            {
                _ultimaPosicionLibre = 0;
            }

            if (Tamanio == Utilidades.ApuntadorVacio)
            {
                Tamanio = 0;
            }

            // Si el archivo existe solamente se actualizan los encabezados, sino se crea y luego
            // se almacenan los valores iniciales
            GuardarEncabezado();
        }

        public override void AgregarAlInicio(T dato)
        {
            Nodo<T> nodoNuevo = new Nodo<T>(_ultimaPosicionLibre, dato);

            if (_cabeza == Utilidades.ApuntadorVacio)
            {
                _cabeza = nodoNuevo.Posicion;
            }
            else
            {
                nodoNuevo.Siguiente = _cabeza;
                _cabeza = nodoNuevo.Posicion;
            }

            Tamanio++;
            _ultimaPosicionLibre++;

            nodoNuevo.GuardarNodoEnDisco(_archivo, _tamañoEncabezadoBinario);
            GuardarEncabezado();
        }

        public override void AgregarAlFinal(T dato)
        {
            Insertar(dato, Tamanio);
        }

        public override void Insertar(T dato, int posicion)
        {
            Nodo<T> nodoNuevo = new Nodo<T>(_ultimaPosicionLibre, dato);
            Nodo<T> nodoActual = null;
            Nodo<T> nodoAnterior = null;

            ValidarPosicion(posicion, true);

            if (posicion == 0)
            {
                AgregarAlInicio(dato);
                return;
            }

            UbicarPosicion(posicion, ref nodoAnterior, ref nodoActual);

            nodoAnterior.Siguiente = nodoNuevo.Posicion;
            nodoNuevo.Siguiente = nodoActual.Posicion;

            Tamanio++;
            _ultimaPosicionLibre++;

            nodoAnterior.GuardarNodoEnDisco(_archivo, _tamañoEncabezadoBinario);
            nodoNuevo.GuardarNodoEnDisco(_archivo, _tamañoEncabezadoBinario);
            GuardarEncabezado();
        }

        public override void EliminarAlInicio()
        {
            Nodo<T> nodoEliminar = null;

            if (_cabeza == Utilidades.ApuntadorVacio)
                throw new ArgumentOutOfRangeException("posicion");
            else
            {
                nodoEliminar = Nodo<T>.CrearNodoDesdeDisco(_archivo, _tamañoEncabezadoBinario, _cabeza, _fabrica);
                _cabeza = nodoEliminar.Siguiente;
            }

            Tamanio--;

            nodoEliminar.LimpiarNodoEnDisco(_archivo, _tamañoEncabezadoBinario, _fabrica);
            GuardarEncabezado();
        }

        public override void EliminarAlFinal()
        {
            Eliminar(Tamanio - 1);
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

            nodoAnterior.GuardarNodoEnDisco(_archivo, _tamañoEncabezadoBinario);
            nodoActual.LimpiarNodoEnDisco(_archivo, _tamañoEncabezadoBinario, _fabrica);
            GuardarEncabezado();
        }

        public override T ObtenerAlInicio()
        {
            Nodo<T> nodoObtener = null;
            if (_cabeza == Utilidades.ApuntadorVacio)
            {
                throw new ArgumentOutOfRangeException("posicion");
            }
            else
            {
                nodoObtener = Nodo<T>.CrearNodoDesdeDisco(_archivo, _tamañoEncabezadoBinario, _cabeza, _fabrica);
                return nodoObtener.Dato;
            }
        }

        public override T ObtenerAlFinal()
        {
            return Obtener(Tamanio - 1);
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

        public override T[] GenerarArreglo()
        {
            T[] resultado = new T[Tamanio];
            int nodoActualPosicion = _cabeza;
            Nodo<T> nodoActual = null;
            int posicion = 0;

            while (nodoActualPosicion != Utilidades.ApuntadorVacio)
            {
                nodoActual = Nodo<T>.CrearNodoDesdeDisco(_archivo, _tamañoEncabezadoBinario, nodoActualPosicion, _fabrica);
                resultado[posicion] = nodoActual.Dato;
                posicion++;
                nodoActualPosicion = nodoActual.Siguiente;
            }
            return resultado;

        }

        public override void Cerrar()
        {
            _archivo.Close();
        }
    }
}

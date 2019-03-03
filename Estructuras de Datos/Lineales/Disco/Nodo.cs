using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estructuras_de_Datos.Comunes;
using System.IO;

namespace Estructuras_de_Datos.Lineales.Disco
{
    internal class Nodo<T> where T : ITextoTamañoFijo
    {
        #region Propiedades
        internal int Posicion { get; private set; }
        internal int Anterior { get; set; }
        internal int Siguiente { get; set; }
        internal T Dato { get; set; }

        internal int TamañoEnTexto
        {
            get
            {
                int tamañoEnTexto = 0;
                tamañoEnTexto = Dato.TamañoEnTexto; // Tamaño del Dato
                tamañoEnTexto += Utilidades.TextoEnteroTamaño * 3; //Tamaño de Posicion, Anterior y Siguiente
                tamañoEnTexto += 3; // Tamaño de los separadores
                tamañoEnTexto += Utilidades.TextoNuevaLineaTamaño; // Tamaño del Enter
                return tamañoEnTexto;
            }
        }

        internal int TamañoEnBytes
        {
            get
            {
                return TamañoEnTexto * Utilidades.BinarioCaracterTamaño;
            }
        }

        #endregion

        #region Metodos Privados

        private int CalcularPosicionEnDisco(int tamañoEncabezado)
        {
            return tamañoEncabezado + (Posicion * TamañoEnBytes);
        }

        private string ConvertirATextoTamañoFijo()
        {
            StringBuilder datosCadena = new StringBuilder();

            datosCadena.Append(Utilidades.FormatearEntero(Posicion));
            datosCadena.Append(Utilidades.TextoSeparador);
            datosCadena.Append(Utilidades.FormatearEntero(Anterior));
            datosCadena.Append(Utilidades.TextoSeparador);
            datosCadena.Append(Utilidades.FormatearEntero(Siguiente));
            datosCadena.Append(Utilidades.TextoSeparador);
            datosCadena.Append(Dato.ConvertirATextoTamañoFijo().Replace(Utilidades.TextoSeparador, Utilidades.TextoSustitutoSeparador));
            datosCadena.Append(Utilidades.TextoNuevaLinea);

            return datosCadena.ToString();
        }

        private byte[] ObtenerBytes()
        {
            byte[] datosBinarios = null;
            datosBinarios = Utilidades.ConvertirBinarioYTexto(ConvertirATextoTamañoFijo());
            return datosBinarios;
        }

        #endregion

        #region Métodos Internos y Publicos

        internal Nodo(int posicion, T dato)
        {
            if (posicion < Utilidades.ApuntadorVacio)
                throw new ArgumentOutOfRangeException("posicion");

            Posicion = posicion;
            Dato = dato;
            Siguiente = Utilidades.ApuntadorVacio;
            Anterior = Utilidades.ApuntadorVacio;
        }

        internal void GuardarNodoEnDisco(FileStream archivo, int tamañoEncabezado)
        {
            // Se ubica la posicion donde se debe escribir
            archivo.Seek(CalcularPosicionEnDisco(tamañoEncabezado), SeekOrigin.Begin);

            // Se escribe al archivo y se fuerza a vaciar el buffer
            archivo.Write(ObtenerBytes(), 0, TamañoEnBytes);
            archivo.Flush();
        }

        internal void LimpiarNodoEnDisco(FileStream archivo, int tamañoEncabezado, IFabricaTextoTamañoFijo<T> fabrica)
        {
            //Se limpia el contenido del nodo
            Siguiente = Utilidades.ApuntadorVacio;
            Anterior = Utilidades.ApuntadorVacio;
            Dato = fabrica.FabricarNulo();

            GuardarNodoEnDisco(archivo, tamañoEncabezado);
        }

        internal static Nodo<T> CrearNodoDesdeDisco(FileStream archivo, int tamañoEncabezado, int posicion, IFabricaTextoTamañoFijo<T> fabrica)
        {
            if (archivo == null)
                throw new ArgumentNullException("archivo");
            if (tamañoEncabezado < 0)
                throw new ArgumentOutOfRangeException("tamañoEncabezado");
            if (posicion < 0)
                throw new ArgumentOutOfRangeException("posicion");
            if (fabrica == null)
                throw new ArgumentNullException("fabrica");

            // Se crea un nodo nulo para poder acceder a las propiedades de tamaño calculadas
            // sobre la instancia el dato de la instancia del nodo.
            Nodo<T> nuevoNodo = new Nodo<T>(posicion, fabrica.FabricarNulo());

            // Se cea un buffer donde almacenarán los bytes leidos
            byte[] datosBinario = new byte[nuevoNodo.TamañoEnBytes];

            // Variables a ser utilizadas luego de que el archivo sea leido
            string datosCadena = "";
            string[] datosSeparados = null;

            // Se ubica la posición donde deberá estar el nodo y se lee desde el archivo
            archivo.Seek(nuevoNodo.CalcularPosicionEnDisco(tamañoEncabezado), SeekOrigin.Begin);
            archivo.Read(datosBinario, 0, nuevoNodo.TamañoEnBytes);

            // Se converiten los bytes leidos del archivo a una cadena
            datosCadena = Utilidades.ConvertirBinarioYTexto(datosBinario);

            // Se quitan los saltos de linea y se separa en secciones
            datosCadena = datosCadena.Replace(Utilidades.TextoNuevaLinea, "");
            datosSeparados = datosCadena.Split(Utilidades.TextoSeparador);

            // Se asignan los apuntadores de Anterior y Siguiente
            nuevoNodo.Anterior = Convert.ToInt32(datosSeparados[1]);
            nuevoNodo.Siguiente = Convert.ToInt32(datosSeparados[2]);

            // Se regenera el objeto Dato utilizando la fabrica
            nuevoNodo.Anterior = Convert.ToInt32(datosSeparados[1]);
            nuevoNodo.Siguiente = Convert.ToInt32(datosSeparados[2]);

            // Se retorna el nodo luego de agregar toda la información
            return nuevoNodo;
        }

        #endregion
    }
}

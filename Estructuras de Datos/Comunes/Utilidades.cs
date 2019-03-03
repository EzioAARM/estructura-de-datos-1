using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Estructuras_de_Datos.Comunes
{
    internal static class Utilidades
    {
        #region Utilidades Texto

        // Para formatear los enteros en los archivos
        internal const int TextoEnteroTamaño = 11;
        private const string TextoEnteroFormato = "00000000000;-0000000000";

        // El salto de linea "enter"
        internal const int TextoNuevaLineaTamaño = 2;
        internal const string TextoNuevaLinea = "\r\n";

        // Separador a usar en el nodo y caracter auxiliar para sustituirlo
        internal const char TextoSeparador = '|';
        internal const char TextoSustitutoSeparador = '°';

        internal static string FormatearEntero(int numero)
        {
            return numero.ToString(TextoEnteroFormato);
        }

        #endregion

        #region Utilidades Bytes

        internal const int BinarioCaracterTamaño = 4; // Debido al UTF32

        internal static string ConvertirBinarioYTexto(byte[] datosBinario)
        {
            return Encoding.UTF32.GetString(datosBinario);
        }

        internal static byte[] ConvertirBinarioYTexto(string datosTexto)
        {
            return Encoding.UTF32.GetBytes(datosTexto);
        }

        #endregion

        #region Utilidades Enteros

        internal const int EnteroYEnterTamaño = (Utilidades.TextoEnteroTamaño + Utilidades.TextoNuevaLineaTamaño);
        internal const int EnteroYEnterBinarioTamaño = EnteroYEnterTamaño * Utilidades.BinarioCaracterTamaño;

        private static byte[] ConvertirenteroYEnter(int numero)
        {
            return Utilidades.ConvertirBinarioYTexto(Utilidades.FormatearEntero(numero) + Utilidades.TextoNuevaLinea);
        }

        private static int ConvertirEnteroYEnter(byte[] buffer)
        {
            return Convert.ToInt32(Utilidades.ConvertirBinarioYTexto(buffer).Replace(Utilidades.TextoNuevaLinea, ""));
        }

        internal static int LeerEntero(FileStream archivo, int posicion)
        {
            if (archivo == null)
            {
                throw new ArgumentNullException("archivo");
            }
            if (posicion < 0)
            {
                throw new ArgumentOutOfRangeException("posicion");
            }
            try
            {
                byte[] buffer = new byte[EnteroYEnterBinarioTamaño];
                posicion = posicion * EnteroYEnterBinarioTamaño;
                archivo.Seek(posicion, SeekOrigin.Begin);
                archivo.Read(buffer, 0, EnteroYEnterBinarioTamaño);
                return ConvertirEnteroYEnter(buffer);
            }
            catch (Exception)
            {
                return Utilidades.ApuntadorVacio;
            }
        }

        internal static void EscribirEntero(FileStream archivo, int posicion, int numero)
        {
            if (archivo == null)
            {
                throw new ArgumentNullException("archivo");
            }
            if (posicion < 0)
            {
                throw new ArgumentOutOfRangeException("posicion");
            }
            byte[] buffer = ConvertirenteroYEnter(numero);
            posicion = posicion * EnteroYEnterBinarioTamaño;
            archivo.Seek(posicion, SeekOrigin.Begin);
            archivo.Write(buffer, 0, EnteroYEnterBinarioTamaño);
        }

        #endregion

        #region Otros

        internal const int ApuntadorVacio = -1; 

        #endregion
    }
}

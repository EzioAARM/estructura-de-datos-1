using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Estructuras_de_Datos.No_Lineales.RAM
{
    public class ABB<TLlave,T> : ArbolBusqueda<TLlave,T> where TLlave:IComparable
    {
        internal Nodo<TLlave, T> _raiz;

        #region Insercion
        private Nodo<TLlave, T> AgregarRecursivo(Nodo<TLlave, T> nodoActual, Nodo<TLlave, T> nodoNuevo)
        {
            if (nodoActual == null)
            {
                return nodoNuevo;
            }

            if (nodoNuevo.Llave.CompareTo(nodoActual.Llave) == 0)
            {
                throw new InvalidOperationException("La llave indicada ya esta contenida en el arbol.");
            }

            if (nodoNuevo.Llave.CompareTo(nodoActual.Llave) < 0)
            {
                nodoActual.Izquierda = AgregarRecursivo(nodoActual.Izquierda, nodoNuevo);
                nodoActual.Izquierda.Padre = nodoActual;
            }
            else
            {
                nodoActual.Derecha = AgregarRecursivo(nodoActual.Derecha, nodoNuevo);
                nodoActual.Derecha.Padre = nodoActual;
            }

            return nodoActual;
        }
        #endregion

        #region Consultas
        internal Nodo<TLlave, T> ObtenerRecursivo(Nodo<TLlave, T> nodoActual, TLlave llavePorObtener)
        {
            if (nodoActual == null)
            {
                return null;
            }

            if (llavePorObtener.CompareTo(nodoActual.Llave)<0)
            {
                return ObtenerRecursivo(nodoActual.Derecha, llavePorObtener);
            }

            if (llavePorObtener.CompareTo(nodoActual.Llave)>0)
            {
                return ObtenerRecursivo(nodoActual.Izquierda, llavePorObtener);
            }

            return nodoActual;
        }

        private Nodo<TLlave, T> ObtenerMayorRecursivo(Nodo<TLlave, T> nodoActual)
        {
            if (nodoActual.Derecha == null)
            {
                return nodoActual;
            }
            else
            {
                return ObtenerMayorRecursivo(nodoActual.Derecha);
            }
        }

        internal int ObtenerAlturaRecursivo(Nodo<TLlave, T> nodoActual)
        {
            int alturaIzquierda = 0;
            int alturaDerecha = 0;

            if (nodoActual == null)
            {
                return 0;
            }

            alturaIzquierda = ObtenerAlturaRecursivo(nodoActual.Izquierda);
            alturaDerecha = ObtenerAlturaRecursivo(nodoActual.Derecha);

            if (alturaIzquierda > alturaDerecha)
            {
                return alturaIzquierda + 1;
            }
            else
            {
                return alturaDerecha + 1;
            }
        }

        internal int CalcularFactorEquilibrio(Nodo<TLlave, T> nodoActual)
        {
            int alturaIzquierda = 0;
            int alturaDerecha = 0;

            alturaIzquierda = ObtenerAlturaRecursivo(nodoActual.Izquierda);
            alturaDerecha = ObtenerAlturaRecursivo(nodoActual.Derecha);

            return (alturaIzquierda - alturaDerecha);
        }
        #endregion

        public ABB()
        {
            Tamaño = 0;
            _raiz = null;
        }

        public override void Agregar(TLlave llave, T dato)
        {
            if (llave == null)
            {
                throw new ArgumentNullException("llave");
            }

            Nodo<TLlave, T> nodoNuevo = new Nodo<TLlave, T>(llave, dato);
            _raiz = AgregarRecursivo(_raiz, nodoNuevo);
            Tamaño++;
        }

        public override T Obtener(TLlave llave)
        {
            Nodo<TLlave, T> nodoObtenido = ObtenerRecursivo(_raiz, llave);

            if (nodoObtenido == null)
            {
                throw new InvalidOperationException("La llave indicada no esta en el arbol.");
            }
            else
            {
                return nodoObtenido.Dato;
            }
        }

        public override bool Contiene(TLlave llave)
        {
            Nodo<TLlave, T> nodoObtenido = ObtenerRecursivo(_raiz, llave);

            if (nodoObtenido == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void Eliminar(TLlave llave)
        {
            Nodo<TLlave, T> nodoPorBorrar = ObtenerRecursivo(_raiz, llave);
            Nodo<TLlave, T> NodoPorSubir = null;

            //No se encuentra en la estructura, no se hace nada.
            if (nodoPorBorrar == null)
            {
                throw new InvalidOperationException("La llave indicada no esta en el arbol.");
            }

            //Es un nodo hoja.
            if (nodoPorBorrar.Izquierda == null && nodoPorBorrar.Derecha == null)
            {
                if (nodoPorBorrar == _raiz)
                {
                    _raiz = null;
                }
                else if (nodoPorBorrar == nodoPorBorrar.Padre.Izquierda)
                {
                    nodoPorBorrar.Padre.Izquierda = null;
                }
                else
                {
                    nodoPorBorrar.Padre.Derecha = null;
                }

                return;
            }

            //Es un nodo intermedio con un solo hijo. //REVISAR!!!
            if (nodoPorBorrar.Izquierda == null || nodoPorBorrar.Derecha == null)
            {
                if (nodoPorBorrar == _raiz)
                {
                    if (nodoPorBorrar.Izquierda != null)
                    {
                        _raiz = nodoPorBorrar.Izquierda;
                        Eliminar(nodoPorBorrar.Izquierda.Llave);
                    }
                    else
                    {
                        _raiz = nodoPorBorrar.Derecha;
                        Eliminar(nodoPorBorrar.Derecha.Llave);
                    }
                }
                else if (nodoPorBorrar.Izquierda != null)
                {
                    if (nodoPorBorrar == nodoPorBorrar.Padre.Izquierda)
                    {
                        nodoPorBorrar.Padre.Izquierda = nodoPorBorrar.Izquierda;
                        nodoPorBorrar.Izquierda.Padre = nodoPorBorrar.Padre;
                    }
                    else
                    {
                        nodoPorBorrar.Padre.Derecha = nodoPorBorrar.Izquierda;
                        nodoPorBorrar.Izquierda.Padre = nodoPorBorrar.Padre;
                    } 
                }
                else
                {
                    if (nodoPorBorrar == nodoPorBorrar.Padre.Izquierda)
                    {
                        nodoPorBorrar.Padre.Izquierda = nodoPorBorrar.Derecha;
                        nodoPorBorrar.Derecha.Padre = nodoPorBorrar.Padre;
                    }
                    else
                    {
                        nodoPorBorrar.Padre.Derecha = nodoPorBorrar.Derecha;
                        nodoPorBorrar.Derecha.Padre = nodoPorBorrar.Padre;
                    }
                }

                return;
            }

            //Es un nodo intermedio con dos hijos.
            NodoPorSubir = ObtenerMayorRecursivo(nodoPorBorrar.Izquierda);
            Eliminar(NodoPorSubir.Llave);

            nodoPorBorrar.Llave = NodoPorSubir.Llave;
            nodoPorBorrar.Dato = NodoPorSubir.Dato;
        }

        #region Recorridos

        #region PrintNodo
        private void EscribirNodo(Nodo<TLlave, T> nodoActual, StringBuilder texto)
        {
            texto.AppendLine(nodoActual.Llave.ToString());
            texto.AppendLine(nodoActual.Dato.ToString());
            texto.AppendLine("---------------");
        }
        #endregion

        #region PreOrden
        private void RecorrerPreOrdenRecursivo(Nodo<TLlave, T> nodoActual, StringBuilder texto)
        {
            if (nodoActual == null)
            {
                return;
            }

            EscribirNodo(nodoActual, texto);
            RecorrerPreOrdenRecursivo(nodoActual.Izquierda, texto);
            RecorrerPreOrdenRecursivo(nodoActual.Derecha, texto);
        }

        public override string RecorrerPreOrden()
        {
            StringBuilder texto = new StringBuilder();
            RecorrerPreOrdenRecursivo(_raiz, texto);
            return texto.ToString();
        }
        #endregion

        #region InOrden
        private void RecorrerInOrdenRecursivo(Nodo<TLlave, T> nodoActual, StringBuilder texto)
        {
            if (nodoActual == null)
            {
                return;
            }

            RecorrerInOrdenRecursivo(nodoActual.Izquierda, texto);
            EscribirNodo(nodoActual, texto);
            RecorrerInOrdenRecursivo(nodoActual.Derecha, texto);
        }

        public override string RecorrerInOrden()
        {
            StringBuilder texto = new StringBuilder();
            RecorrerInOrdenRecursivo(_raiz, texto);
            return texto.ToString();
        }
        #endregion

        #region PostOrden
        private void RecorrerPostOrdenRecursivo(Nodo<TLlave, T> nodoActual, StringBuilder texto)
        {
            if (nodoActual == null)
            {
                return;
            }

            RecorrerPostOrdenRecursivo(nodoActual.Izquierda, texto);
            RecorrerPostOrdenRecursivo(nodoActual.Derecha, texto);
            EscribirNodo(nodoActual, texto);
        }

        public override string RecorrerPostOrden()
        {
            StringBuilder texto = new StringBuilder();
            RecorrerPostOrdenRecursivo(_raiz, texto);
            return texto.ToString();
        }
        #endregion

        #endregion

        private void DibujarNodo(Nodo<TLlave, T> nodoActual, Graphics grafico,
            Pen nodoLapicero, Brush letrasPincel, Font letrasFormato,
            int nodoX, int nodoY, int nodoAncho, int nodoAlto)
        {
            nodoX = nodoX - (nodoAncho / 2);
            nodoY = nodoY - (nodoAlto / 2);

            grafico.DrawRectangle(nodoLapicero, nodoX, nodoY, nodoAncho, nodoAlto);
            grafico.DrawString(nodoActual.Llave.ToString(), letrasFormato, letrasPincel, nodoX, nodoY);
        }

        private void DibujarPreOrdenRecursivo(Nodo<TLlave, T> nodoActual, Graphics grafico,
            Pen nodoLapicero, Brush letrasPincel, Font letrasFormato,
            int nodoX, int nodoY, int nodoAncho, int nodoAlto,
            int separacionHorizontal, int separacionVertical)
        {
            int nodoHijoX = 0;
            int nodoHijoY = 0;

            if (nodoActual == null)
            {
                return;
            }

            //Se dibuja el nodo actual
            DibujarNodo(nodoActual, grafico, nodoLapicero, letrasPincel, letrasFormato, nodoX, nodoY, nodoAncho, nodoAlto);

            separacionHorizontal = separacionHorizontal / 2;
            nodoHijoY = nodoY + (nodoAlto + separacionVertical);

            //Se dibuja recursivamente el lado Izquierdo
            nodoHijoX = nodoX - separacionHorizontal;

            grafico.DrawLine(nodoLapicero, nodoX, nodoY + nodoAlto / 2, nodoHijoX, nodoHijoY - nodoAlto / 2);
            DibujarPreOrdenRecursivo(nodoActual.Izquierda, grafico,
                nodoLapicero, letrasPincel, letrasFormato,
                nodoHijoX, nodoHijoY, nodoAncho, nodoAlto,
                separacionHorizontal, separacionVertical);

            //Se dibuja recursivamente el lado Derecho.
            nodoHijoX = nodoX + separacionHorizontal;

            grafico.DrawLine(nodoLapicero, nodoX, nodoY + nodoAlto / 2, nodoHijoX, nodoHijoY - nodoAlto / 2);
            DibujarPreOrdenRecursivo(nodoActual.Derecha, grafico,
                nodoLapicero, letrasPincel, letrasFormato,
                nodoHijoX, nodoHijoY, nodoAncho, nodoAlto,
                separacionHorizontal, separacionVertical);
        }

        public override Bitmap Dibujar()
        {
            const int nodoAncho = 100;
            const int nodoAlto = 50;
            const int separacionVertical = 25;

            //La cantidad de nodos a lo ancho se calcula en funcion de la altura, crecen como potencia de base 2
            int dibujoAncho = Convert.ToInt32(Math.Pow(2, ObtenerAltura() - 1)) * (nodoAncho + separacionVertical);
            int dibujoAlto = ObtenerAltura() * (nodoAlto + separacionVertical);

            if (dibujoAncho == 0 || dibujoAlto == 0)
            {
                return new Bitmap(1, 1);
            }

            Bitmap dibujo = new Bitmap(dibujoAncho, dibujoAlto);
            Graphics grafico = Graphics.FromImage(dibujo);
            Pen nodoLapicero = new Pen(Brushes.MediumBlue);
            Brush letrasPincel = Brushes.DarkBlue;
            Font letrasFormato = new Font(FontFamily.GenericSerif, 20);

            //Se inicia el dibujado recursivo empezando por la raiz
            //para lo cual se usa el recorrido Pre Orden
            DibujarPreOrdenRecursivo(_raiz, grafico,
                nodoLapicero, letrasPincel, letrasFormato,
                dibujoAncho / 2, (nodoAlto + separacionVertical) / 2, nodoAncho, nodoAlto,
                dibujoAncho / 2, separacionVertical);

            return dibujo;
        }

        public override int ObtenerAltura()
        {
            return ObtenerAlturaRecursivo(_raiz);
        }

        public override void Cerrar()
        {
            //Este metodo solo se usa cuando son estructuras de datos en archivos
        }
    }
}

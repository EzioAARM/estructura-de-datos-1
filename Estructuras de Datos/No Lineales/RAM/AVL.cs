using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras_de_Datos.No_Lineales.RAM
{
    public class AVL<TLlave, T> : ABB<TLlave ,T> where TLlave: IComparable
    {
        private Nodo<TLlave, T> RotarDerecha(Nodo<TLlave, T> nodoActual)
        {
            Nodo<TLlave, T> raizNueva = null;

            raizNueva = nodoActual.Izquierda; //Yes
            nodoActual.Izquierda = raizNueva.Derecha; 
            raizNueva.Derecha = nodoActual; //Yes.

            raizNueva.Padre = nodoActual.Padre;
            nodoActual.Padre = raizNueva;

            if (nodoActual.Izquierda != null)
            {
                nodoActual.Izquierda.Padre = nodoActual;
            }

            return raizNueva;
        }

        private Nodo<TLlave, T> RotarIzquierda(Nodo<TLlave, T> nodoActual)
        {
            Nodo<TLlave, T> raizNueva = null;

            raizNueva = nodoActual.Derecha;
            nodoActual.Derecha = raizNueva.Izquierda;
            raizNueva.Izquierda = nodoActual;

            raizNueva.Padre = nodoActual.Padre;
            nodoActual.Padre = raizNueva;

            if (nodoActual.Derecha != null)
            {
                nodoActual.Derecha.Padre = nodoActual;
            }

            return raizNueva;
        }

        private Nodo<TLlave, T> BalancearDerecha(Nodo<TLlave, T> nodoActual)
        {
            int factorEquilibrio = 0;
            int factorEquilibrioAnidado = 0;

            factorEquilibrio = CalcularFactorEquilibrio(nodoActual);

            if (factorEquilibrio <= -2) //Derecha mas pesada (en por lo menos 2)
            {
                factorEquilibrioAnidado = CalcularFactorEquilibrio(nodoActual.Derecha);

                if (factorEquilibrioAnidado <= -1) //Derecha mas pesada
                {
                    //Rotacion simple
                    return RotarIzquierda(nodoActual);
                }
                else
                {
                    //Doble rotacion
                    nodoActual.Derecha = RotarDerecha(nodoActual.Derecha);
                    nodoActual = RotarIzquierda(nodoActual);
                    return nodoActual;
                }
            }

            return nodoActual;
        }

        private Nodo<TLlave, T> BalancearIzquierda(Nodo<TLlave, T> nodoActual)
        {
            int factorEquilibrio = 0;
            int factorEquilibrioAnidado = 0;

            factorEquilibrio = CalcularFactorEquilibrio(nodoActual);

            if (factorEquilibrio <= -2) //Izquierda mas pesada (en por lo menos 2)
            {
                factorEquilibrioAnidado = CalcularFactorEquilibrio(nodoActual.Izquierda);

                if (factorEquilibrioAnidado <= -1) //Izquierda mas pesada
                {
                    //Rotacion simple
                    return RotarDerecha(nodoActual);
                }
                else
                {
                    //Doble rotacion
                    nodoActual.Izquierda = RotarIzquierda(nodoActual.Izquierda);
                    nodoActual = RotarDerecha(nodoActual);
                    return nodoActual;
                }
            }

            return nodoActual;
        }

        public override void Agregar(TLlave llave, T dato)
        {
            if (llave == null)
            {
                throw new ArgumentException("llave");
            }

            Nodo<TLlave, T> nodoNuevo = new Nodo<TLlave, T>(llave, dato);
            _raiz = AgregarRecursivoConBalance(_raiz, nodoNuevo);
            _raiz = BalancearDerecha(_raiz);
            _raiz = BalancearIzquierda(_raiz);

            Tamaño++;
        }

        private Nodo<TLlave, T> AgregarRecursivoConBalance(Nodo<TLlave, T> nodoActual, Nodo<TLlave, T> nodoNuevo)
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
                nodoActual.Izquierda = AgregarRecursivoConBalance(nodoActual.Izquierda, nodoNuevo);
                nodoActual.Izquierda.Padre = nodoActual;
                nodoActual.Izquierda = BalancearIzquierda(nodoActual.Izquierda);
            }
            else
            {
                nodoActual.Derecha = AgregarRecursivoConBalance(nodoActual.Derecha, nodoNuevo);
                nodoActual.Derecha.Padre = nodoActual;
                nodoActual.Derecha = BalancearDerecha(nodoActual.Derecha);
            }

            return nodoActual;
        }

        public override void Eliminar(TLlave llave)
        {
            Nodo<TLlave, T> nodoPorBorrar = ObtenerRecursivo(_raiz, llave);
            Nodo<TLlave, T> nodoPadre = null;

            //No se encuentra en la estructura, no se hace nada.
            if (nodoPorBorrar == null)
            {
                throw new InvalidOperationException("La llave indicada no esta en el arbol.");
            }

            nodoPadre = nodoPorBorrar.Padre;

            base.Eliminar(llave);

            while (nodoPadre != null)
            {
                BalancearDerecha(nodoPadre);
                BalancearIzquierda(nodoPadre);
                nodoPadre = nodoPadre.Padre;
            }
        }

    }
}

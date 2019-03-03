using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Estructuras_de_Datos.Lineales;
using Estructuras_de_Datos.Lineales.RAM;

namespace Laboratorio_02
{
    public partial class Lab2 : Form
    {
        private Lista<int> miLista;
        private int posicion;
        private int valor;

        private void ObtenerDatosTexto(DatosRecuperar recuperar)
        {
            switch (recuperar)
            {
                case DatosRecuperar.Todos:
                    if (!(Int32.TryParse(txtPosicion.Text, out posicion) && Int32.TryParse(txtValor.Text, out valor)))
                    {
                        MessageBox.Show("Revisa los datos ingresados para Posicion y valor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case DatosRecuperar.SoloPosicion:
                    if (!Int32.TryParse(txtPosicion.Text, out posicion))
                    {
                        MessageBox.Show("Revisa el dato ingresado para la posicion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case DatosRecuperar.SoloValor:
                    if (!Int32.TryParse(txtValor.Text, out valor))
                    {
                        MessageBox.Show("Revisa el dato ingresado para el valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void MostrarError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MostrarLista()
        {
            int[] miListaEnArray = miLista.GenerarArreglo();
            lbDatos.Items.Clear();
            for (int i = 0; i < miListaEnArray.Length; i++)
            {
                lbDatos.Items.Add(miListaEnArray[i]);
            }
        }

        public void frmListasEnlazadas()
        {
            InitializeComponent();
            miLista = new ListaDoblementeEnlazada<int>();
            MostrarLista();
        }

        public Lab2()
        {
            InitializeComponent();
            miLista = new ListaDoblementeEnlazada<int>();
            MostrarLista();
        }

        public enum DatosRecuperar
        {
            Todos,
            SoloPosicion,
            SoloValor
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCrearSimple_Click(object sender, EventArgs e)
        {
            try
            {
                miLista = new ListaEnlazada<int>();
                MostrarLista();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnCrearListaDoblementeEnlazada_Click(object sender, EventArgs e)
        {
            try
            {
                miLista = new ListaDoblementeEnlazada<int>();
                MostrarLista();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnAgregarAlInicio_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerDatosTexto(DatosRecuperar.SoloValor);
                miLista.AgregarAlInicio(valor);
                MostrarLista();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnAgregarAlFinal_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerDatosTexto(DatosRecuperar.SoloValor);
                miLista.AgregarAlFinal(valor);
                MostrarLista();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerDatosTexto(DatosRecuperar.Todos);
                miLista.Insertar(valor, posicion);
                MostrarLista();
                txtPosicion.Clear();
                txtValor.Clear();
                txtValor.Focus();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnEliminarAlInicio_Click(object sender, EventArgs e)
        {
            try
            {
                miLista.EliminarAlInicio();
                MostrarLista();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnEliminarAlFinal_Click(object sender, EventArgs e)
        {
            try
            {
                miLista.EliminarAlFinal();
                MostrarLista();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerDatosTexto(DatosRecuperar.SoloPosicion);
                miLista.Eliminar(posicion);
                MostrarLista();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnObtenerAlInicio_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(miLista.ObtenerAlInicio().ToString());
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnObtenerAlFinal_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(miLista.ObtenerAlFinal().ToString());
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnObtener_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerDatosTexto(DatosRecuperar.SoloPosicion);
                MessageBox.Show(miLista.Obtener(posicion).ToString());
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }
    }
}

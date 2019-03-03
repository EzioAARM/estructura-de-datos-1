using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Estructuras_de_Datos.No_Lineales;
using Estructuras_de_Datos.No_Lineales.RAM;

namespace Laboratorio_04
{
    public partial class frmArbolesBinarios : Form
    {
        private ArbolBusqueda<int, string> miArbol;
        private int llave;
        private string valor;

        public frmArbolesBinarios()
        {
            InitializeComponent();
            pbArbol.SizeMode = PictureBoxSizeMode.StretchImage;

            miArbol = new ABB<int, string>();
            MostrarArbol();
        }

        public enum DatosRecuperar
        {
            Todos,
            SoloLlave,
            SoloValor
        }

        private bool ObtenerDatosTexto(DatosRecuperar recuperar)
        {
            string Mensaje = "";

            if ((recuperar == DatosRecuperar.SoloLlave)||(recuperar == DatosRecuperar.Todos))
            {
                if (!Int32.TryParse(txtLlave.Text, out llave))
                {
                    Mensaje += "Revisa el dato ingresado para Llave.\r\n";
                }
            }

            if ((recuperar == DatosRecuperar.SoloValor)||(recuperar == DatosRecuperar.Todos))
            {
                if (txtValor.Text.Trim() == "")
                {
                    valor = "";
                    Mensaje += "Revisa el dato ingresado para valor.\r\n";
                }
                else
                {
                    valor = txtValor.Text;
                }
            }

            if (Mensaje.Length > 0)
            {
                MessageBox.Show(Mensaje, "Datos de entrada invalidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void MostrarError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MostrarArbol()
        {
            pbArbol.Image = miArbol.Dibujar();
        }

        private void btnCrearAbb_Click(object sender, EventArgs e)
        {
            try
            {
                miArbol = new ABB<int, string>();
                MostrarArbol();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnAI_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ObtenerDatosTexto(DatosRecuperar.Todos))
                {
                    return;
                }

                miArbol.Agregar(llave, valor);
                MostrarArbol();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnOI_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ObtenerDatosTexto(DatosRecuperar.SoloLlave))
                {
                    return;
                }

                MessageBox.Show(miArbol.Obtener(llave));
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(miArbol.RecorrerInOrden());
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnEI_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ObtenerDatosTexto(DatosRecuperar.SoloLlave))
                {
                    return;
                }

                miArbol.Eliminar(llave);
                MostrarArbol();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(miArbol.RecorrerPreOrden());
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(miArbol.RecorrerPostOrden());
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btnCrearAVL_Click(object sender, EventArgs e)
        {
            try
            {
                miArbol = new AVL<int, string>();
                MostrarArbol();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }
    }
}

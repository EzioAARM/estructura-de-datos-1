using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace miniSQL
{
    public partial class Form1 : Form
    {
        string bdActual;
        List<string> reservadas = new List<string>();
        string sentenciaActual;
        BaseDatos baseDatos;

        public void EjecutarCreate(string query)
        {
            if (sentenciaActual.Split(' ')[1] == "basedatos" || sentenciaActual.Split(' ')[1] == "database")
            {
                baseDatos = new BaseDatos(sentenciaActual.Split(' ')[2].Substring(0, sentenciaActual.Split(' ')[2].Length - 1), true);
            }
            else if (sentenciaActual.Split(' ')[1] == "tabla" || sentenciaActual.Split(' ')[1] == "table")
            {
                if (bdActual == null)
                {
                    throw new Exception("Debe seleccionar una base de datos primero");
                }
                baseDatos = new BaseDatos(bdActual, false);
                baseDatos.EjecutarCreateTable(query, bdActual);
            }
            else
            {
                throw new ArgumentException("Tiene un error de sintaxis.");
            }
        }
        public Form1()
        {
            InitializeComponent();
            StreamReader lector = new StreamReader("reservadas.ini");
            string valor = lector.ReadLine();
            while (valor != null)
            {
                reservadas.Add(valor);
                valor = lector.ReadLine();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sentenciaActual = rtbEditorSQL.SelectedText;

                if (sentenciaActual == "")
                    sentenciaActual = rtbEditorSQL.Text;
                else
                    throw new ArgumentNullException("Debe ingresar un comando sql para ejecutar");

                if (sentenciaActual.Substring(sentenciaActual.Length - 1, 1) != ";")
                    throw new ArgumentException("Debre ingresar ; al final de cada sentencia");

                if (sentenciaActual.Split(' ')[0] == "use" || sentenciaActual.Split(' ')[0] == "usar")
                    bdActual = sentenciaActual.Split(' ')[2].Substring(0, sentenciaActual.Split(' ')[2].Length - 1);
                else if (sentenciaActual.Split(' ')[0] == "crear" || sentenciaActual.Split(' ')[0] == "create")
                    EjecutarCreate(sentenciaActual);
                rtbErrores.Text = "Comando ejecutado con éxito";
                CargarBasesDeDatos();
            }
            catch (Exception ex)
            {
                rtbErrores.Text = ex.Message;
                this.rtbEditorSQL.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                rtbEditorSQL.ForeColor = Color.Red;
            }
        }

        private void rtbEditorSQL_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        public void CargarBasesDeDatos()
        {
            treeView1.Nodes.Clear();
            IEnumerable<string> datos = System.IO.Directory.EnumerateDirectories("databases/");
            int nodoActual = 0;
            foreach (string dato in datos)
            {
                treeView1.Nodes.Add(dato.Split('/')[1]);
                IEnumerable<string> tablas = System.IO.Directory.EnumerateFiles(dato + "/");
                foreach (string tabla in tablas)
                {
                    if (tabla.Split('/')[2].Split('.')[1] != "campos")
                        treeView1.Nodes[nodoActual].Nodes.Add(tabla.Split('/')[2].Split('.')[0]);
                }
                nodoActual++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarBasesDeDatos();
        }

        private void rtbEditorSQL_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (rtbEditorSQL.Text == "")
            {
                rtbEditorSQL.ForeColor = Color.Black;
                this.rtbEditorSQL.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            string[] palabras = rtbEditorSQL.Text.Split(' ');
            var resultado = from b in reservadas from c in palabras where c == b select b;
            int inicio = 0;
            foreach (var item in resultado)
            {
                inicio = 0;
                inicio = rtbEditorSQL.Text.IndexOf(item, inicio);
                rtbEditorSQL.Select(inicio, item.Length);
                if (e.KeyChar == Convert.ToChar(Keys.Space))
                {
                    rtbEditorSQL.SelectionColor = Color.Blue;
                }
                rtbEditorSQL.SelectionStart = rtbEditorSQL.Text.Length;
                inicio++;
            }
            rtbEditorSQL.SelectionColor = Color.Black;
            rtbEditorSQL.SelectionStart = rtbEditorSQL.Text.Length;*/
        }

        private void rtbEditorSQL_TextChanged(object sender, EventArgs e)
        {
            if (rtbEditorSQL.Text == "")
            {
                rtbEditorSQL.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }
    }
}

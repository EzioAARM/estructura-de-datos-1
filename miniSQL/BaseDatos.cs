using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace miniSQL
{
    public class BaseDatos
    {
        string Nombre;
        List<Tabla> Tablas { get; set; }
        public BaseDatos(string nombre, bool seCreara)
        {
            if (seCreara)
            {
                if (!System.IO.Directory.Exists("databases/" + nombre))
                    System.IO.Directory.CreateDirectory("databases/" + nombre);
                else
                    throw new ArgumentException("La base de datos ya fue creada");
            }
            Nombre = nombre;
            Tablas = new List<Tabla>();
        }

        public void EjecutarCreateTable(string query, string baseDatos)
        {
            string nombreTabla = "";
            nombreTabla = query.Split(' ')[2];
            bool tieneCampos = false;
            int i = 0;
            while (i < query.Split(' ')[2].Length)
            {
                if (nombreTabla[i] == '(')
                {
                    tieneCampos = true;
                    nombreTabla = query.Split(' ')[2].Substring(0, i);
                    i = query.Split(' ')[2].Length;
                }
                else
                {
                    tieneCampos = false;
                }
                i++;
            }
            if (!tieneCampos)
                nombreTabla = query.Split(' ')[2].Substring(0, query.Split(' ')[2].Length - 1);
            Tablas.Add(new Tabla(nombreTabla, baseDatos, true));
            if (tieneCampos)
            {
                i = 0;
                int DondeEmpiezanCampos = 0;
                while (i < query.Length)
                {
                    if (query[i] == '(')
                    {
                        DondeEmpiezanCampos = i;
                        i = query.Length;
                    }
                    i++;
                }
                string[] campos = query.Substring(DondeEmpiezanCampos + 1, query.Length - DondeEmpiezanCampos - 3).Split(',');
                CrearCampos(campos, nombreTabla, Tablas.Count);
            }
        }

        public void CrearCampos(string[] campos, string nombreTabla, int posicionTablaListado)
        {
            int i = 0;
            string tipoDato = "";
            int longitudValores = 0;
            bool esPrimaryKey = false;
            bool Nulo = true;
            string nombre;
            string[] campo;
            while (i < campos.Length)
            {
                campo = campos[i].Split(' ');
                nombre = campo[0];
                tipoDato = campo[1].Split('(')[0];
                longitudValores = Convert.ToInt32(campo[1].Split('(')[1].Split(')')[0]);
                try
                {
                    if (campo[2] + campo[3] == "primarykey")
                    {
                        esPrimaryKey = true;
                    }
                }
                catch { }
                try
                {
                    if (campo[4] + campo[5] == "notnull" || campo[2] + campo[3] == "notnull")
                    {
                        Nulo = false;
                    }
                }
                catch { }
                if (tipoDato == "varchar")
                    Tablas[posicionTablaListado - 1].Campos.Add(new CampoVarchar(tipoDato, longitudValores, nombre, esPrimaryKey, Nulo, nombreTabla, Nombre, true));
                else if (tipoDato == "int")
                    Tablas[posicionTablaListado - 1].Campos.Add(new CampoInt(tipoDato, longitudValores, nombre, esPrimaryKey, Nulo, nombreTabla, Nombre, true));
                else if (tipoDato == "datetime")
                    Tablas[posicionTablaListado - 1].Campos.Add(new CampoDateTime(tipoDato, longitudValores, nombre, esPrimaryKey, Nulo, nombreTabla, Nombre, true));
                i++;
            }
        }
    }
}

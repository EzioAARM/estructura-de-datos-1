using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace miniSQL
{
    public class Tabla
    {
        public List<Campo> Campos { get; set; }
        public string Nombre { get; set; }

        public Tabla(string nombre, string bdName, bool seCreara)
        {
            if (seCreara)
            {
                if (!System.IO.File.Exists("databases/" + bdName + "/" + nombre + ".minsql") || !System.IO.File.Exists("databases/" + bdName + "/" + nombre + ".campos.minsql"))
                {
                    System.IO.File.Create("databases/" + bdName + "/" + nombre + ".minsql");
                    System.IO.File.Create("databases/" + bdName + "/" + nombre + ".campos.minsql");
                }
                else
                {
                    throw new Exception("La tabla ya ha sido creada en la base de datos " + bdName);
                }
            }
            Nombre = nombre;
            Campos = new List<Campo>();
        }

        public void CrearCampo(string tipoDato, int longitudValores, string nombre, bool esPrimaryKey, bool esNulo, string nombreTabla, string database, bool seCrara)
        {
            if (tipoDato == "varchar");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Estructuras_de_Datos.Lineales;
using Estructuras_de_Datos.Lineales.Disco;

namespace miniSQL
{
    public abstract class Campo
    {
        public string TipoDato { get; set; }
        public int LongitudValores { get; set; }
        public string Nombre { get; set; }
        public bool PrimaryKey { get; set; }
        public bool Nulo { get; set; }

        public abstract bool Existe(string archivo);
    }
}

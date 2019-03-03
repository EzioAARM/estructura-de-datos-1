using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estructuras_de_Datos.Lineales.Disco;

namespace miniSQL
{
    public class CampoDateTime : Campo
    {
        DateTime Dato { get; set; }
        public CampoDateTime(string tipoDato, int longitudValores, string nombre, bool esPrimaryKey, bool esNulo, string nombreTabla, string database, bool seCrara)
        {
            TipoDato = tipoDato;
            Nombre = nombre;
            PrimaryKey = esPrimaryKey;
            Nulo = esNulo;
            if (!Existe("databases/" + database + "/" + nombreTabla + ".campos.minsql") && seCrara)
            {
                ListaDoblementeEnlazada<string> ListaCampos = new ListaDoblementeEnlazada<string>("databases/" + database + "/" + nombreTabla + ".campos.minsql", Estructuras_de_Datos.Comunes.IFabricaTextoTamañoFijo<string> );
            }
        }

        public override bool Existe(string archivo)
        {
            throw new NotImplementedException();
        }
    }
}

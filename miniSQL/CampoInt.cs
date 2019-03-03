using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniSQL
{
    public class CampoInt : Campo
    {
        int Dato { get; set; }
        public CampoInt(string tipoDato, int longitudValores, string nombre, bool esPrimaryKey, bool esNulo, string nombreTabla, string database, bool seCrara)
            : base(tipoDato, longitudValores, nombre, esPrimaryKey, esNulo, nombreTabla, database, seCrara)
        {

        }

        public override bool Existe(string archivo)
        {
            throw new NotImplementedException();
        }
    }
}

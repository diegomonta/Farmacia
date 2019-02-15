using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    internal class Conexion
    {
        //ATRIBUTO CONNECTION STRING
        private static string _connectionString = "Data Source=.; Initial Catalog = Farmacia; Integrated Security = true";

        //PROPIEDAD GET CONNECTION STRING
        public static string ConnectionString
        {
            get { return _connectionString; }
        }
    }
}

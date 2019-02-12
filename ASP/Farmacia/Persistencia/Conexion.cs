using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    internal class Conexion
    {
        //ATRIBUTO CONNECTION STRING
        private string ConnectionString = "Data Source=.; Initial Catalog = Farmacia; Integrated Security = true";

        //PROPIEDAD GET CONNECTION STRING
        public string connectionString
        {
            get { return ConnectionString; }
        }
    }
}

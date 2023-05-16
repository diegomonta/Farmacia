using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Persistencia
{
    internal class Conexion
    {
        //ATRIBUTO CONNECTION STRING
        private static string _connectionString = "Data Source=EscuelaSeguridad.mssql.somee.com; Initial Catalog = EscuelaSeguridad; user id = diego9102_SQLLogin_1; pwd=75idi8gfji";

        //PROPIEDAD GET CONNECTION STRING
        public static string ConnectionString
        {
            get { return _connectionString; }
        }
    }
}

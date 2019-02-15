using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EntidadesCompartidas;
using System.Data;

namespace Persistencia
{
    public class PersistenciaEmpleado
    {
        //BUSCAR CLIENTE
        public Empleado LogInCliente(string Usuario, string Pass)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("LogInEmpleado", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@Usuario", Usuario);
            sp.Parameters.AddWithValue("@Pass", Pass);

            //READER
            SqlDataReader reader;

            //PREPARAR VARIABLES
            Empleado empleado;
            string Nombre;
            string InicioJornada;
            string FinJornada;
            try
            {
                connection.Open();
                reader = sp.ExecuteReader();

                if (reader.HasRows)
                {
                    Nombre = (string)reader["Nombre"];
                    InicioJornada = (string)reader["InicioJornada"];
                    FinJornada = (string)reader["FinJornada"];

                    reader.Read();
                    empleado = new Empleado(Usuario, Pass, Nombre, InicioJornada, FinJornada);
                }
                else
                    return null;

                return empleado;
            }
            catch { throw; }

            finally { connection.Close(); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EntidadesCompartidas;
using System.Data;

namespace Persistencia
{
    public class PersistenciaCliente
    {
        //BUSCAR CLIENTE
        public Cliente LogInCliente(string Usuario, string Pass)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("LogInCliente", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@Usuario", Usuario);
            sp.Parameters.AddWithValue("@Pass", Pass);

            //READER
            SqlDataReader reader;

            //PREPARAR VARIABLES
            Cliente cliente;
            string Nombre;
            string DireccionFacturacion;
            string Telefono;
            try
            {
                connection.Open();
                reader = sp.ExecuteReader();

                if (reader.Read())
                {
                    Nombre = (string)reader["Nombre"];
                    DireccionFacturacion = (string)reader["DireccionFacturacion"];
                    Telefono = (string)reader["Telefono"];

                    cliente = new Cliente(Usuario, Pass, Nombre, DireccionFacturacion, Telefono);
                    reader.Close();
                }
                else
                    return null;

                return cliente;
            }
            catch { throw; }

            finally { connection.Close(); }
        }
    }
}

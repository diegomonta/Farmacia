using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EntidadesCompartidas;
using System.Data;

namespace Persistencia
{
    public class PersistenciaUsuario
    {
        //BUSCAR USUARIO
        public Usuario BuscarUsuario(string Usuario, string Pass)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("BuscarUsuario", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@Usuario", Usuario);
            sp.Parameters.AddWithValue("@Pass", Pass);

            //READER
            SqlDataReader reader;

            //PREPARAR VARIABLES
            Usuario usu;
            string Nombre;
            try
            {
                connection.Open();
                reader = sp.ExecuteReader();

                if (reader.Read())
                {
                    Nombre = (string)reader["Nombre"];

                    usu = new Usuario(Usuario, Pass, Nombre);
                    reader.Close();
                }
                else
                    return null;

                return usu;
            }
            catch { throw; }

            finally { connection.Close(); }
        }
    }
}

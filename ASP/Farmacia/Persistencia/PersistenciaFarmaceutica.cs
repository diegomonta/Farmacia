using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaFarmaceutica
    {
        //BUSCAR FARMACEUTICA
        public Farmaceutica BuscarFarmaceutica(string RUC)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("BuscarFarmaceutica", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@RUC", RUC);

            //READER
            SqlDataReader reader;

            //PREPARAR VARIABLES
            Farmaceutica farmaceutica;
            string Nombre;
            string CorreoElectronico;
            string Direccion;
            try
            {
                connection.Open();
                reader = sp.ExecuteReader();

                if (reader.Read())
                {
                    Nombre = (string)reader["Nombre"];
                    CorreoElectronico = (string)reader["CorreoElectronico"];
                    Direccion = (string)reader["Direccion"];

                    farmaceutica = new Farmaceutica(RUC, Nombre, CorreoElectronico, Direccion);
                    reader.Close();
                }
                else
                    return null;

                return farmaceutica;
            }
            catch { throw; }

            finally { connection.Close(); }
        }

        //LISTAR FARMACEUTICAS
        public List<Farmaceutica> ListarFarmaceuticas()
        {
            //GET CONNECTION STRING 
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand Command = new SqlCommand("ListarFarmaceutica", connection);
            Command.CommandType = CommandType.StoredProcedure;

            //READER
            SqlDataReader Reader;

            //PREPARAR VARIABLES
            string RUC;
            string Nombre;
            string CorreoElectronico;
            string Direccion;
            Farmaceutica farmaceutica = null;
            List<Farmaceutica> List = new List<Farmaceutica>();
            try
            {
                connection.Open();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    RUC = (string)Reader["RUC"];
                    Nombre = (string)Reader["Nombre"];
                    CorreoElectronico = (string)Reader["CorreoElectronico"];
                    Direccion = (string)Reader["Direccion"];
                    farmaceutica = new Farmaceutica(RUC, Nombre, CorreoElectronico, Direccion);
                    List.Add(farmaceutica);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la base de datos: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return List;
        }

        //ALTA FARMACEUTICA
        public void AltaFarmaceutica(Farmaceutica farmaceutica)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("AltaFarmaceutica", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@RUC", farmaceutica.pRUC);
            sp.Parameters.AddWithValue("@Nombre", farmaceutica.pNombre);
            sp.Parameters.AddWithValue("@CorreoElectronico", farmaceutica.pCorreoElectronico);
            sp.Parameters.AddWithValue("@Direccion", farmaceutica.pDireccion);

            //RETORNO
            SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            sp.Parameters.Add(retorno);

            try
            {
                connection.Open();

                //ALTA FARMACEUTICA
                sp.ExecuteNonQuery();

                //RETORNO
                switch ((int)retorno.Value)
                {
                    case 1:
                        //EXITO
                        break;
                    //FARMACEUTICA YA EXISTE
                    case -1:
                        throw new Exception("El RUC ya esta utilizado.");
                    //EXCEPCION NO CONTROLADA
                    default:
                        throw new Exception("Ha ocurrido un error vuelva a intentarlo mas tarde.");
                }
            }
            catch { throw; }

            finally { connection.Close(); }
        }

        //BAJA FARMACEUTICA
        public void BajaFarmaceutica(Farmaceutica farmaceutica)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("BajaFarmacecutica", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@RUC", farmaceutica.pRUC);

            //RETORNO
            SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            sp.Parameters.Add(retorno);

            try
            {
                connection.Open();

                //ALTA FARMACEUTICA
                sp.ExecuteNonQuery();

                //RETORNO
                switch ((int)retorno.Value)
                {
                    case 1:
                        //EXITO
                        break;
                    //FARMACEUTICA YA EXISTE
                    case -1:
                        throw new Exception("El RUC no existe.");
                    //EXCEPCION NO CONTROLADA
                    default:
                        throw new Exception("Ha ocurrido un error vuelva a intentarlo mas tarde.");
                }
            }
            catch { throw; }

            finally { connection.Close(); }
        }

        //MODIFICAR FARMACEUTICA
        public void ModificarFarmaceutica(Farmaceutica farmaceutica)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("ModificarFarmaceutica", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@RUC", farmaceutica.pRUC);
            sp.Parameters.AddWithValue("@Nombre", farmaceutica.pNombre);
            sp.Parameters.AddWithValue("@CorreoElectronico", farmaceutica.pCorreoElectronico);
            sp.Parameters.AddWithValue("@Direccion", farmaceutica.pDireccion);

            //RETORNO
            SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            sp.Parameters.Add(retorno);

            try
            {
                connection.Open();

                //ALTA FARMACEUTICA
                sp.ExecuteNonQuery();

                //RETORNO
                switch ((int)retorno.Value)
                {
                    case 1:
                        //EXITO
                        break;
                    //FARMACEUTICA YA EXISTE
                    case -1:
                        throw new Exception("El RUC no existe.");
                    //EXCEPCION NO CONTROLADA
                    default:
                        throw new Exception("Ha ocurrido un error vuelva a intentarlo mas tarde.");
                }
            }
            catch { throw; }

            finally { connection.Close(); }
        }
    }
}

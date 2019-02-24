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
        public Cliente BuscarCliente(string usuario)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("Buscarcliente", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@Usuario", usuario);

            //READER
            SqlDataReader reader;

            //PREPARAR VARIABLES
            Cliente cliente;
            string Pass;
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
                    Pass = (string)reader["Pass"];
                    DireccionFacturacion = (string)reader["DireccionFacturacion"];
                    Telefono = (string)reader["Telefono"];

                    cliente = new Cliente(usuario, Pass, Nombre, DireccionFacturacion, Telefono);
                    reader.Close();
                }
                else
                    return null;

                return cliente;
            }
            catch { throw; }

            finally { connection.Close(); }
        }

        //LOGIN CLIENTE
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

        //ALTA CLIENTE
        public void AltaCliente(Cliente cliente)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("AltaCliente", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@Usuario", cliente.pNombreUsuario);
            sp.Parameters.AddWithValue("@Pass", cliente.pPass);
            sp.Parameters.AddWithValue("@Nombre", cliente.pNombreCompleto);
            sp.Parameters.AddWithValue("@DireccionFacturacion", cliente.pDireccionFacturacion);
            sp.Parameters.AddWithValue("@Telefono", cliente.pTelefono);

            //RETORNO
            SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            sp.Parameters.Add(retorno);

            try
            {
                connection.Open();

                //ALTA CLIENTE
                sp.ExecuteNonQuery();

                //RETORNO
                switch ((int)retorno.Value)
                {
                    case 1:
                        //EXITO
                        break;
                    //USUARIO YA EXISTE
                    case -1:
                        throw new Exception("El usuario ya ha sido tomado.");
                    //EXCEPCION NO CONTROLADA
                    default:
                        throw new Exception("Ha ocurrido un error vuelva a intentarlo mas tarde.");
                }
            }
            catch { throw; }

            finally { connection.Close(); }
        }

        ////BAJA CLIENTE
        //public void BajaCliente(Cliente cliente)
        //{
        //    //GET CONNECTION STRING
        //    SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

        //    //STORED PROCEDURE
        //    SqlCommand sp = new SqlCommand("BajaCliente", connection);
        //    sp.CommandType = CommandType.StoredProcedure;

        //    //PARAMETROS
        //    sp.Parameters.AddWithValue("@Usuario", cliente.pNombreUsuario);

        //    //RETORNO
        //    SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
        //    retorno.Direction = ParameterDirection.ReturnValue;
        //    sp.Parameters.Add(retorno);

        //    try
        //    {
        //        connection.Open();

        //        //BAJA CLIENTE
        //        sp.ExecuteNonQuery();

        //        //RETORNO
        //        switch ((int)retorno.Value)
        //        {
        //            case 1:
        //                //EXITO
        //                break;
        //            //Cliente NO EXISTE
        //            case -1:
        //                throw new Exception("El usuario no existe.");
        //            //EXCEPCION NO CONTROLADA
        //            default:
        //                throw new Exception("Ha ocurrido un error vuelva a intentarlo mas tarde.");
        //        }
        //    }
        //    catch { throw; }

        //    finally { connection.Close(); }
        //}

        ////MODIFICAR CLIENTE
        //public void ModificarCliente(Cliente cliente)
        //{
        //    //GET CONNECTION STRING
        //    SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

        //    //STORED PROCEDURE
        //    SqlCommand sp = new SqlCommand("ModificarCliente", connection);
        //    sp.CommandType = CommandType.StoredProcedure;

        //    //PARAMETROS
        //    sp.Parameters.AddWithValue("@Usuario", cliente.pNombreUsuario);
        //    sp.Parameters.AddWithValue("@Pass", cliente.pPass);
        //    sp.Parameters.AddWithValue("@Nombre", cliente.pNombreCompleto);
        //    sp.Parameters.AddWithValue("@DireccionFacturacion", cliente.pDireccionFacturacion);
        //    sp.Parameters.AddWithValue("@Telefono", cliente.pTelefono);

        //    //RETORNO
        //    SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
        //    retorno.Direction = ParameterDirection.ReturnValue;
        //    sp.Parameters.Add(retorno);

        //    try
        //    {
        //        connection.Open();

        //        //MODIFICAR CLIENTE
        //        sp.ExecuteNonQuery();

        //        //RETORNO
        //        switch ((int)retorno.Value)
        //        {
        //            case 1:
        //                //EXITO
        //                break;
        //            //Cliente NO EXISTE
        //            case -1:
        //                throw new Exception("El usuario no existe.");
        //            //EXCEPCION NO CONTROLADA
        //            default:
        //                throw new Exception("Ha ocurrido un error vuelva a intentarlo mas tarde.");
        //        }
        //    }
        //    catch { throw; }

        //    finally { connection.Close(); }
        //}
    }
}

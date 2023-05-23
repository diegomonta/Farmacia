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
        //BUSCAR EMPLEADO
        public Empleado BuscarEmpleado(string usuario)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("BuscarEmpleado", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@Usuario", usuario);

            //READER
            SqlDataReader reader;

            //PREPARAR VARIABLES
            Empleado empleado;
            string Pass;
            string Nombre;
            string InicioJornada;
            string FinJornada;
            string Correo;
            try
            {
                connection.Open();
                reader = sp.ExecuteReader();

                if (reader.Read())
                {
                    Nombre = (string)reader["Nombre"];
                    Pass = (string)reader["Pass"];
                    InicioJornada = (string)reader["InicioJornada"];
                    FinJornada = (string)reader["FinJornada"];
                    Correo = (string)reader["Correo"];

                    empleado = new Empleado(usuario, Pass, Nombre, InicioJornada, FinJornada,Correo);
                    reader.Close();
                }
                else
                    return null;

                return empleado;
            }
            catch { throw; }

            finally { connection.Close(); }
        }

        //LOGIN EMPLEADO
        public Empleado LogInEmpleado(string usuario, string Pass)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("LogInEmpleado", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@Usuario", usuario);
            sp.Parameters.AddWithValue("@Pass", Pass);

            //READER
            SqlDataReader reader;

            //PREPARAR VARIABLES
            Empleado empleado;
            string Nombre;
            string InicioJornada;
            string FinJornada;
            string Correo;
            try
            {
                connection.Open();
                reader = sp.ExecuteReader();

                if (reader.Read())
                {
                    Nombre = (string)reader["Nombre"];
                    InicioJornada = (string)reader["InicioJornada"];
                    FinJornada = (string)reader["FinJornada"];
                    Correo = (string)reader["Correo"];

                    empleado = new Empleado(usuario, Pass, Nombre, InicioJornada, FinJornada,Correo);
                    reader.Close();
                }
                else
                    return null;

                return empleado;
            }
            catch { throw; }

            finally { connection.Close(); }
        }

        //ALTA EMPLEADO
        public void AltaEmpleado(Empleado empleado)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("AltaEmpleado", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@Usuario", empleado.pNombreUsuario);
            sp.Parameters.AddWithValue("@Pass", empleado.pPass);
            sp.Parameters.AddWithValue("@Nombre", empleado.pNombreCompleto);
            sp.Parameters.AddWithValue("@InicioJornada", empleado.pInicioJornadaLaboral);
            sp.Parameters.AddWithValue("@FinJornada", empleado.pFinJornadaLaboral);

            //RETORNO
            SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            sp.Parameters.Add(retorno);

            try
            {
                connection.Open();

                //ALTA EMPLEADO
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

        //BAJA EMPLEADO
        public void BajaEmpleado(Empleado empleado)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("BajaEmpleado", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@Usuario", empleado.pNombreUsuario);

            //RETORNO
            SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            sp.Parameters.Add(retorno);

            try
            {
                connection.Open();

                //BAJA EMPLEADO
                sp.ExecuteNonQuery();

                //RETORNO
                switch ((int)retorno.Value)
                {
                    case 1:
                        //EXITO
                        break;
                    //EMPLEADO NO EXISTE
                    case -1:
                        throw new Exception("El usuario no existe.");
                    //EXCEPCION NO CONTROLADA
                    default:
                        throw new Exception("Ha ocurrido un error vuelva a intentarlo mas tarde.");
                }
            }
            catch { throw; }

            finally { connection.Close(); }
        }

        //MODIFICAR EMPLEADO
        public void ModificarEmpleado(Empleado empleado)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("ModificarEmpleado", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@Usuario", empleado.pNombreUsuario);
            sp.Parameters.AddWithValue("@Pass", empleado.pPass);
            sp.Parameters.AddWithValue("@Nombre", empleado.pNombreCompleto);
            sp.Parameters.AddWithValue("@InicioJornada", empleado.pInicioJornadaLaboral);
            sp.Parameters.AddWithValue("@FinJornada", empleado.pFinJornadaLaboral);
            sp.Parameters.AddWithValue("@Correo", empleado.pCorreo);

            //RETORNO
            SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            sp.Parameters.Add(retorno);

            try
            {
                connection.Open();

                //MODIFICAR EMPLEADO
                sp.ExecuteNonQuery();

                //RETORNO
                switch ((int)retorno.Value)
                {
                    case 1:
                        //EXITO
                        break;
                    //EMPLEADO NO EXISTE
                    case -1:
                        throw new Exception("El usuario no existe.");
                    //EXCEPCION NO CONTROLADA
                    default:
                        throw new Exception("Ha ocurrido un error vuelva a intentarlo mas tarde.");
                }
            }
            catch { throw; }

            finally { connection.Close(); }
        }
        public void ModificarClave(string usuario, string claveRecuperacion)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("Modificarclave", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@Usuario", usuario);
            sp.Parameters.AddWithValue("@Pass", claveRecuperacion);

            //RETORNO
            SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            sp.Parameters.Add(retorno);

            try
            {
                connection.Open();

                //MODIFICAR EMPLEADO
                sp.ExecuteNonQuery();

                //RETORNO
                switch ((int)retorno.Value)
                {
                    case 1:
                        //EXITO
                        break;
                    //EMPLEADO NO EXISTE
                    case -1:
                        throw new Exception("El usuario no existe.");
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

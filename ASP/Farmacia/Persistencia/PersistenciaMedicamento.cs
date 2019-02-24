using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaMedicamento
    {
        //BUSCAR MEDICAMENTO
        public Medicamento BuscarMedicamento(int Codigo, string RucFarmaceutica)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("BuscarMedicamento", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@Codigo", Codigo);
            sp.Parameters.AddWithValue("@Farmaceutica", RucFarmaceutica);

            //READER
            SqlDataReader reader;

            try
            {
                //PREPARAR VARIABLES
                Persistencia.PersistenciaFarmaceutica persistenciaFarmaceutica = new PersistenciaFarmaceutica();
                Medicamento medicamento;
                string Nombre;
                double Precio;
                string Descripcion;
                Farmaceutica farmaceutica = persistenciaFarmaceutica.BuscarFarmaceutica(RucFarmaceutica);

                connection.Open();
                reader = sp.ExecuteReader();

                if (reader.Read())
                {
                    Nombre = (string)reader["Nombre"];
                    Precio = (double)reader["Precio"];
                    Descripcion = (string)reader["Descripcion"];

                    medicamento = new Medicamento(Codigo, farmaceutica, Nombre, Descripcion, Precio);
                    reader.Close();
                }
                else
                    return null;

                return medicamento;
            }
            catch { throw; }

            finally { connection.Close(); }
        }

        ////LISTAR FARMACEUTICAS
        //public List<Farmaceutica> ListarFarmaceuticas()
        //{
        //    //GET CONNECTION STRING 
        //    SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

        //    //STORED PROCEDURE
        //    SqlCommand Command = new SqlCommand("ListarFarmaceutica", connection);
        //    Command.CommandType = CommandType.StoredProcedure;

        //    //READER
        //    SqlDataReader Reader;

        //    //PREPARAR VARIABLES
        //    string RUC;
        //    string Nombre;
        //    string CorreoElectronico;
        //    string Direccion;
        //    Farmaceutica farmaceutica = null;
        //    List<Farmaceutica> List = new List<Farmaceutica>();
        //    try
        //    {
        //        connection.Open();
        //        Reader = Command.ExecuteReader();
        //        while (Reader.Read())
        //        {
        //            RUC = (string)Reader["RUC"];
        //            Nombre = (string)Reader["Nombre"];
        //            CorreoElectronico = (string)Reader["CorreoElectronico"];
        //            Direccion = (string)Reader["Direccion"];
        //            farmaceutica = new Farmaceutica(RUC, Nombre, CorreoElectronico, Direccion);
        //            List.Add(farmaceutica);
        //        }
        //        Reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("Error en la base de datos: " + ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return List;
        //}

        //ALTA MEIDICAMENTO
        public void AltaMedicamento(Medicamento medicamento)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("AltaMedicamento", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@Codigo", medicamento.pCodigo);
            sp.Parameters.AddWithValue("@Farmaceutica", medicamento.pFarmaceutica.pRUC);
            sp.Parameters.AddWithValue("@Descripcion", medicamento.pDescripcion);
            sp.Parameters.AddWithValue("@Precio", medicamento.pPrecio);
            sp.Parameters.AddWithValue("@Nombre", medicamento.pNombre);

            //RETORNO
            SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            sp.Parameters.Add(retorno);

            try
            {
                connection.Open();

                //ALTA MEDICAMENTO
                sp.ExecuteNonQuery();

                //RETORNO
                switch ((int)retorno.Value)
                {
                    case 1:
                        //EXITO
                        break;
                    //FARMACEUTICA YA EXISTE
                    case -1:
                        throw new Exception("El meidcamento ya existe.");
                    //EXCEPCION NO CONTROLADA
                    default:
                        throw new Exception("Ha ocurrido un error vuelva a intentarlo mas tarde.");
                }
            }
            catch { throw; }

            finally { connection.Close(); }
        }

        //BAJA MEDICAMENTO
        public void BajaMedicamento(Medicamento medicamento)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("BajaMedicamento", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@Codigo", medicamento.pCodigo);
            sp.Parameters.AddWithValue("@Farmaceutica", medicamento.pFarmaceutica.pRUC);

            //RETORNO
            SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            sp.Parameters.Add(retorno);

            try
            {
                connection.Open();

                //BAJA MEIDICAMENTO
                sp.ExecuteNonQuery();

                //RETORNO
                switch ((int)retorno.Value)
                {
                    case 1:
                        //EXITO
                        break;
                    //FARMACEUTICA NO EXISTE
                    case -1:
                        throw new Exception("El medicamento no existe.");
                    //EXCEPCION NO CONTROLADA
                    default:
                        throw new Exception("Ha ocurrido un error vuelva a intentarlo mas tarde.");
                }
            }
            catch { throw; }

            finally { connection.Close(); }
        }

        //MODIFICAR MEDICAMENTO
        public void ModificarMedicamento(Medicamento medicamento)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("ModificarMedicamento", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@Codigo", medicamento.pCodigo);
            sp.Parameters.AddWithValue("@Farmaceutica", medicamento.pFarmaceutica.pRUC);
            sp.Parameters.AddWithValue("@Descripcion", medicamento.pDescripcion);
            sp.Parameters.AddWithValue("@Precio", medicamento.pPrecio);
            sp.Parameters.AddWithValue("@Nombre", medicamento.pNombre);

            //RETORNO
            SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            sp.Parameters.Add(retorno);

            try
            {
                connection.Open();

                //MODIFICAR MEDICAMENTO
                sp.ExecuteNonQuery();

                //RETORNO
                switch ((int)retorno.Value)
                {
                    case 1:
                        //EXITO
                        break;
                    //FARMACEUTICA NO EXISTE
                    case -1:
                        throw new Exception("El medicamento no existe.");
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

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

        //LISTAR MEDICAMENTO
        public List<Medicamento> ListarMedicamento()
        {
            //GET CONNECTION STRING 
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand Command = new SqlCommand("ListarMedicamento", connection);
            Command.CommandType = CommandType.StoredProcedure;

            //READER
            SqlDataReader Reader;

            //PREPARAR VARIABLES
            int Codigo;
            string Descripcion;
            double Precio;
            string Nombre;
            Farmaceutica farmaceutica = null;
            Medicamento medicamento = null;
            List<Medicamento> List = new List<Medicamento>();
            Persistencia.PersistenciaFarmaceutica persistenciaFarmaceutica = new PersistenciaFarmaceutica();
            try
            {
                connection.Open();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    Codigo = (int)Reader["Codigo"];
                    Descripcion = (string)Reader["Descripcion"];
                    Precio = (double)Reader["Precio"];
                    Nombre = (string)Reader["Nombre"];
                    farmaceutica = persistenciaFarmaceutica.BuscarFarmaceutica((string)Reader["Farmaceutica"]);
                    medicamento = new Medicamento(Codigo, farmaceutica, Nombre, Descripcion, Precio);
                    List.Add(medicamento);
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
                    //MEDICAMENTO YA EXISTE
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
                    //MEDICAMENTO NO EXISTE
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
                    //MEDICAMENTO NO EXISTE
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

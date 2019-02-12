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

        //ALTA FARMACEUTICA
        public void AltaFarmaceutica(Farmaceutica farmaceutica)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(@"Data Source=.; Initial Catalog=Farmacia; Integrated Security=true");

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
            sp.Parameters.AddWithValue("@retorno", retorno);

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
            SqlConnection connection = new SqlConnection(@"Data Source=.; Initial Catalog=Farmacia; Integrated Security=true");

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("BajaFarmacecutica", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@RUC", farmaceutica.pRUC);

            //RETORNO
            SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            sp.Parameters.AddWithValue("@retorno", retorno);

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
            SqlConnection connection = new SqlConnection(@"Data Source=.; Initial Catalog=Farmacia; Integrated Security=true");

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("ModificarFarmaceutica", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@RUC", farmaceutica.pRUC);
            sp.Parameters.AddWithValue("@Nombre", farmaceutica.pNombre);
            sp.Parameters.AddWithValue("@CorreoElecctronico", farmaceutica.pCorreoElectronico);
            sp.Parameters.AddWithValue("@Direccion", farmaceutica.pDireccion);

            //RETORNO
            SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            sp.Parameters.AddWithValue("@retorno", retorno);

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

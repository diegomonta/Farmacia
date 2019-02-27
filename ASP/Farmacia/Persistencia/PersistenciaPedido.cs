using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaPedido
    {
        public void AltaPedido(Pedido pedido)
        {
            //GET CONNECTION STRING
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand sp = new SqlCommand("AltaPedido", connection);
            sp.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            sp.Parameters.AddWithValue("@Cliente", pedido.pClienteComprador.pNombreUsuario);
            sp.Parameters.AddWithValue("@MedicamentoCodigo", pedido.pMedicamentoPedido.pCodigo);
            sp.Parameters.AddWithValue("@MedicamentoFarmaceutica", pedido.pMedicamentoPedido.pFarmaceutica.pRUC);
            sp.Parameters.AddWithValue("@CantidadMedicamento", pedido.pCantidad);
            sp.Parameters.AddWithValue("@Estado", pedido.pEstado);

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
                        throw new Exception("El cliente no existe.");
                    //LA FARMACEUTICA NO EXISTE
                    case -2:
                        throw new Exception("La farmaceutica no existe.");
                    //EL MEDICAMENTO NO EXISTE
                    case -3:
                        throw new Exception("El medicamento no existe.");
                    //EXCEPCION NO CONTROLADA
                    default:
                        throw new Exception("Ha ocurrido un error vuelva a intentarlo mas tarde.");
                }
            }
            catch { throw; }

            finally { connection.Close(); }
        }

        //LISTAR FARMACEUTICAS
        public List<Pedido> ListarPedidoPorCliente(Cliente cliente)
        {
            //GET CONNECTION STRING 
            SqlConnection connection = new SqlConnection(Conexion.ConnectionString);

            //STORED PROCEDURE
            SqlCommand Command = new SqlCommand("ListarPedidoPorCliente", connection);
            Command.CommandType = CommandType.StoredProcedure;

            //PARAMETROS
            Command.Parameters.AddWithValue("@Usuario", cliente.pNombreUsuario);

            //READER
            SqlDataReader Reader;

            //PREPARAR VARIABLES
            Persistencia.PersistenciaMedicamento persistenciaMedicamento = new PersistenciaMedicamento();
            int Numero;
            int MedicamentoCodigo;
            string MedicamentoFarmacia;
            Medicamento medicamento = null;
            string Estado;
            int Cantidad;
            List<Pedido> List = new List<Pedido>();
            try
            {
                connection.Open();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    Numero = (int)Reader["Numero"];
                    Estado = (string)Reader["Estado"];
                    Cantidad = (int)Reader["Cantidad"];
                    MedicamentoCodigo = (int)Reader["MedicamentoCodigo"];
                    MedicamentoFarmacia = (string)Reader["MedicamentoFarmaceutica"];
                    medicamento = persistenciaMedicamento.BuscarMedicamento(MedicamentoCodigo, MedicamentoFarmacia);
                    Pedido pedido = new Pedido(Numero, cliente, medicamento, Cantidad, Estado);
                    List.Add(pedido);
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
    }
}

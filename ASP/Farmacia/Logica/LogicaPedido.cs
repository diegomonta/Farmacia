using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPedido
    {
        //ALTA PEDIDO
        public void AltaPedido(Pedido pedido)
        {
            try
            {
                PersistenciaPedido persistenciaPedido = new PersistenciaPedido();
                persistenciaPedido.AltaPedido(pedido);
            }
            catch { throw; }
        }

        //LISTAR PEDIDO
        public List<Pedido> ListarPedidosPorClienteGenerados(Cliente cliente)
        {
            try
            {
                PersistenciaPedido persistenciaPedido = new PersistenciaPedido();
                return persistenciaPedido.ListarPedidoPorClienteGenerados(cliente);
            }
            catch { throw; }
        }

        //LISTAR PEDIDO POR ESTADO MEDICAMENTO
        public List<Pedido> ListarPedidoPorEstadoMedicamento(Medicamento medicamento, string estado)
        {
            try
            {
                PersistenciaPedido persistenciaPedido = new PersistenciaPedido();
                return persistenciaPedido.ListarPedidoPorEstadoMedicamento(medicamento, estado);
            }
            catch { throw; }
        }

        //LISTAR PEDIDO POR MEDICAMENTO
        public List<Pedido> ListarPedidoPorMedicamento(Medicamento medicamento)
        {
            try
            {
                PersistenciaPedido persistenciaPedido = new PersistenciaPedido();
                return persistenciaPedido.ListarPedidoPorMedicamento(medicamento);
            }
            catch { throw; }
        }

        //LISTAR PEDIDOS GENERADOS O ENVIADOS
        public List<Pedido> ListarPedidoGeneradoOEnviado()
        {
            try
            {
                PersistenciaPedido persistenciaPedido = new PersistenciaPedido();
                return persistenciaPedido.ListarPedidoGeneradoOEnviado();
            }
            catch { throw; }
        }

        //CAMBIAR ESTADO PEDIDO
        public void CambiarEstadoPedido(Pedido pedido)
        {
            try
            {
                switch (pedido.pEstado)
                {
                    case "GENERADO":
                        pedido.pEstado = "ENVIADO";
                        break;
                    case "ENVIADO":
                        pedido.pEstado = "ENTREGADO";
                        break;
                    default:
                        throw new Exception("El pedido seleccionado no tiene un estado correcto.");
                }
                PersistenciaPedido persistenciaPedido = new PersistenciaPedido();
                persistenciaPedido.CambiarEstadoPedido(pedido);
            }
            catch { throw; }
        }

        //BUSCAR PEDIDO
        public Pedido BuscarPedido(int Numero)
        {
            try
            {
                PersistenciaPedido persistenciaPedido = new PersistenciaPedido();
                return persistenciaPedido.BuscarPedido(Numero);
            }
            catch { throw; }
        }

        //BAJA PEDIDO
        public void BajaPedido(Pedido pedido)
        {
            try
            {
                PersistenciaPedido persistenciaPedido = new PersistenciaPedido();
                persistenciaPedido.BajaPedido(pedido);
            }
            catch { throw; }
        }
    }
}

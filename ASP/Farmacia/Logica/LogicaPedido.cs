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
                Persistencia.PersistenciaPedido persistenciaPedido = new PersistenciaPedido();
                persistenciaPedido.AltaPedido(pedido);
            }
            catch { throw; }
        }

        public List<Pedido> ListarPedidosPorCliente(Cliente cliente)
        {
            try
            {
                Persistencia.PersistenciaPedido persistenciaPedido = new PersistenciaPedido();
                return persistenciaPedido.ListarPedidoPorCliente(cliente);
            }
            catch { throw; }
        }
    }
}

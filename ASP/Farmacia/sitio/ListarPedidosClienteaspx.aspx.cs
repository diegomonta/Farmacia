using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ListarPedidosClienteaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Logica.LogicaPedido logicaPedido = new LogicaPedido();
            logicaPedido.ListarPedidosPorCliente((Cliente)Session["USUARIO"]);
        }
        catch (Exception ex) { lblERROR.Text = ex.Message; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ListarPedidoEliminar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                LogicaPedido logicaPedido = new LogicaPedido();
                Session["listaPedidos"] = logicaPedido.ListarPedidosPorClienteGenerados((Cliente)Session["USUARIO"]);
                gvPedidos.DataSource = (List<Pedido>)Session["listaPedidos"];
                gvPedidos.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
}
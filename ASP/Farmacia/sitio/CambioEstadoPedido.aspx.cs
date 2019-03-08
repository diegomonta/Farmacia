using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class CambioEstadoPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //PASE DE SEGURIDAD
            if ((Usuario)Session["USUARIO"] is Cliente)
                Response.Redirect("HomePage.aspx");

            //LISTAR PEDIDOS
            if (!Page.IsPostBack)
                formularioDefault();
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }

    public void formularioDefault()
    {
        try
        {
            //ACTUALIZAR LISTA DE PEDIDOS GENERADOS 
            LogicaPedido logicaPedido = new LogicaPedido();
            Session["listaPedidos"] = logicaPedido.ListarPedidoGeneradoOEnviado();
            gvPedidos.DataSource = (List<Pedido>)Session["listaPedidos"];
            gvPedidos.DataBind();

            //LIMPIAR LABEL ERROR
            lblERROR.Text = "";
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }

    protected void gvPedidos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //CAMBIAR ESTADO PEDIDO
            int index = gvPedidos.SelectedRow.RowIndex;
            Pedido pedido = ((List<Pedido>)Session["listaPedidos"])[index];
            LogicaPedido logicaPedido = new LogicaPedido();
            logicaPedido.CambiarEstadoPedido(pedido);

            //ACTUALIZAR LISTA
            formularioDefault();

            lblERROR.ForeColor = System.Drawing.Color.Green;
            lblERROR.Text = "Estado actualizado.";
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
}
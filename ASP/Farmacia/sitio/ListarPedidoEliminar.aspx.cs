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

    public void formularioDefault()
    {
        //DEFAULT FORMULARIO ACTUALIZAR LISTA DE PEDIDOS LIMPIIAR DATOS Y LIMPIAR SESSION
    }

    protected void gvPedidos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int index = gvPedidos.SelectedRow.RowIndex;
            Session["PEDIDO"] = ((List<Pedido>)Session["listaPedidos"])[index];
            txtNumero.Text = ((Pedido)Session["PEDIDO"]).pNumero.ToString();
            txtCliente.Text = ((Pedido)Session["PEDIDO"]).pClienteComprador.pNombreCompleto;
            txtMedicamento.Text = ((Pedido)Session["PEDIDO"]).pMedicamentoPedido.pNombre;
            txtPrecio.Text = ((Pedido)Session["PEDIDO"]).pMedicamentoPedido.pPrecio.ToString();
            txtCantidad.Text = ((Pedido)Session["PEDIDO"]).pCantidad.ToString();
            txtFarmaceutica.Text = ((Pedido)Session["PEDIDO"]).pMedicamentoPedido.pFarmaceutica.pNombre + "(" + ((Pedido)Session["PEDIDO"]).pMedicamentoPedido.pFarmaceutica.pRUC + ")";

        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            if ((Pedido)Session["PEDIDO"] == null)
                throw new Exception("Debe seleccionar un pedido.");
            else
            {
                Logica.LogicaPedido logicaPedido = new LogicaPedido();
                logicaPedido.BajaPedido((Pedido)Session["PEDIDO"]);
            }
            lblERROR.ForeColor = System.Drawing.Color.Green;
            lblERROR.Text = "Pedido eliminado correctamente.";
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
}
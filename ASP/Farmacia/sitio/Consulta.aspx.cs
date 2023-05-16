using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class Consulta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        try
        {
            int numero;
            try
            {
                numero = Convert.ToInt32(txtNumero.Text);
            }
            catch
            {
                throw new Exception("El numero de pedido debe ser un numero.");
            }
            LogicaPedido logicaPedido = new Logica.LogicaPedido();
            Pedido pedido = logicaPedido.BuscarPedido(numero);
            if (pedido != null)
            {
                lblERROR.ForeColor = System.Drawing.Color.Green;
                lblERROR.Text = "El pedido se encuentra en estado:" + pedido.pEstado;
            }
            else
                throw new Exception("No se ha encontrado ningun pedido con ese numero.");
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
}
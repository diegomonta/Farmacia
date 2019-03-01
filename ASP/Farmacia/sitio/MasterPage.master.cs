using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Usuario)Session["USUARIO"] != null)
        {
            btnLogOut.Enabled = true;
            lblUsuario.Text = "Usuario: " + ((Usuario)Session["USUARIO"]).pNombreUsuario;

            if ((Usuario)Session["USUARIO"] is Empleado)
                LogedInEmpleado();
            else
                LogedInCliente();
        }
        else
            LogedOut();
    }

    public void LogedInEmpleado()
    {
        //BOTONES EMPLEADO
        btnABMEmpleado.Visible = true;
        btnABMFarmaceutica.Visible = true;
        btnABMMedicamento.Visible = true;
        btnCambiarEstadoPedido.Visible = true;

        //BOTONES CLIENTE
        btnRealizarPedido.Visible = false;
        btnListarPedidoEliminar.Visible = false;
    }

    public void LogedInCliente()
    {
        //BOTONES EMPLEADO
        btnABMEmpleado.Visible = false;
        btnABMFarmaceutica.Visible = false;
        btnABMMedicamento.Visible = false;
        btnCambiarEstadoPedido.Visible = false;

        //BOTONES CLIENTE
        btnRealizarPedido.Visible = true;
        btnListarPedidoEliminar.Visible = true;
    }

    public void LogedOut()
    {
        Session["USUARIO"] = null;
        btnLogOut.Enabled = false;
        Response.Redirect("Default.aspx");
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        LogedOut();
    }

    protected void btnABMFarmaceutica_Click(object sender, EventArgs e)
    {
        Response.Redirect("ABMFarmaceuticas.aspx");
    }

    protected void btnABMEmpleado_Click(object sender, EventArgs e)
    {
        Response.Redirect("ABMEmpleados.aspx");
    }

    protected void btnABMMedicamento_Click(object sender, EventArgs e)
    {
        Response.Redirect("ABMMedicamentos.aspx");
    }

    protected void btnRealizarPedido_Click(object sender, EventArgs e)
    {
        Response.Redirect("RealizarPedido.aspx");
    }

    protected void btnListarPedidoEliminar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListarPedidoEliminar.aspx");
    }
}

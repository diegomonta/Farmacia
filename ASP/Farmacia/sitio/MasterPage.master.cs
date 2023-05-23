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
        btnListadoMedicamentosPedidos.Visible = true;
        btnRegistrarCliente.Visible = true;

        //BOTONES CLIENTE
        btnRealizarInscripcion.Visible = false;
        btnListarPedidoEliminar.Visible = false;
    }

    public void LogedInCliente()
    {
        //BOTONES EMPLEADO
        btnABMEmpleado.Visible = false;
        btnABMFarmaceutica.Visible = false;
        btnABMMedicamento.Visible = false;
        btnCambiarEstadoPedido.Visible = false;
        btnListadoMedicamentosPedidos.Visible = false;
        btnRegistrarCliente.Visible = false;

        //BOTONES CLIENTE
        btnRealizarInscripcion.Visible = true;
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
        Response.Redirect("Materias.aspx");
    }

    protected void btnABMEmpleado_Click(object sender, EventArgs e)
    {
        Response.Redirect("Administrador.aspx");
    }

    protected void btnABMMedicamento_Click(object sender, EventArgs e)
    {
        Response.Redirect("Cursos.aspx");
    }

    protected void btnRealizarInscripcion_Click(object sender, EventArgs e)
    {
        Response.Redirect("RealizarInscripcion.aspx");
    }

    protected void btnListarPedidoEliminar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListarPedidoEliminar.aspx");
    }

    protected void btnListadoMedicamentosPedidos_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListadoCursos.aspx");
    }

    protected void btnCambiarEstadoPedido_Click(object sender, EventArgs e)
    {
        Response.Redirect("CambioEstado.aspx");
    }
    protected void btnRegistrarCliente_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegistroUsuario.aspx");
    }
}

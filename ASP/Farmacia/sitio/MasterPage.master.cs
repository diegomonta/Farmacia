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
            if ((Usuario)Session["USUARIO"] is Empleado)
                LogedIn();
            else
                Response.Redirect("DefaultCliente.aspx");
        }
        else
            LogedOut();
    }

    public void LogedIn()
    {
        //BOTONES 
        btnLogOut.Enabled = true;
        lblUsuario.Text = "Usuario: "+((Usuario)Session["USUARIO"]).pNombreUsuario;
    }

    public void LogedOut()
    {
        Session["USUARIO"] = null;
        btnLogOut.Enabled = false;
        Response.Redirect("LogIn.aspx");
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
}

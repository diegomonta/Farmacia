using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class LogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        try
        {
            Logica.LogicaUsuario lusu = new Logica.LogicaUsuario();
            Usuario usu = lusu.LoginUsuario(txtUsuario.Text, txtPass.Text);
            if (usu is Cliente)
            {
                Session["USUARIO"] = usu;
                //CAMBIAR REDIRECT A DEFAULT CLIENTE CUANDO EXISTA
                Response.Redirect("DefaultEmpleado.aspx");
            }
            else if (usu is Empleado)
            {
                Session["USUARIO"] = usu;
                Response.Redirect("DefaultEmpleado.aspx");
            }
            else
            {
                Session["USUARIO"] = usu;
            }
        }
        catch (Exception ex)
        {
            lblERROR.Text = ex.Message;
        }
    }

    protected void btnRegistrarCliente_Click(object sender, EventArgs e)
    {
        Response.Redirect("LACONCHADETUVIEJA.aspx");
    }
}
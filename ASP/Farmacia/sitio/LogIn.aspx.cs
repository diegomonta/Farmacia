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
        Logica.LogicaUsuario lusu = new Logica.LogicaUsuario();
        Usuario usu = lusu.LoginUsuario(txtUsuario.Text, txtPass.Text);
        if (usu is Cliente)
            lblERROR.Text = "CLIENTE";
        else if (usu is Empleado)
            lblERROR.Text = "EMPLEADO";
        else
            lblERROR.Text = "NO EXISTE";
    }
}
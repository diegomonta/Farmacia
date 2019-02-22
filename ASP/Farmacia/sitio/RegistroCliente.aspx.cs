using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using EntidadesCompartidas;

public partial class RegistroCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            Logica.LogicaUsuario logicaUsuario = new LogicaUsuario();
            string usuario = txtUsuario.Text;
            string pass = txtPass.Text;
            string nombre = txtNombre.Text;
            string direccionFacturacion = txtDireccionFacturacion.Text;
            string telefono = txtTelefono.Text;
            Cliente cliente = new Cliente(usuario, pass, nombre, direccionFacturacion, telefono);

            //SIGNED IN
            Session["USUARIO"] = cliente;
            //REDIRECT
            Response.Redirect("DefaultCliente.aspx");

        }
        catch (Exception ex) { lblERROR.Text = ex.Message; }
    }
}
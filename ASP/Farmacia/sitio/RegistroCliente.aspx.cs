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
            LogicaUsuario logicaUsuario = new LogicaUsuario();
            string usuario = txtUsuario.Text;
            string pass = txtPass.Text;
            string nombre = txtNombre.Text;
            string direccionFacturacion = txtDireccionFacturacion.Text;
            string telefono = txtTelefono.Text;
            Cliente cliente = new Cliente(usuario, pass, nombre, direccionFacturacion, telefono);

            logicaUsuario.AltaUsuario(cliente);

            //SIGNED IN
            Session["USUARIO"] = cliente;
            //REDIRECT
            Response.Redirect("Default.aspx");

        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
}
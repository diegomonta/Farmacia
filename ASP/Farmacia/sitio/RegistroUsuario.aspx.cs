using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using EntidadesCompartidas;

public partial class RegistroUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Registrar(object sender, EventArgs e)
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
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        string contrasena = txtPass.Text;

        // Realiza la validación de la contraseña utilizando la función calcularFortalezaContrasena
        string fortaleza = calcularFortalezaContrasena(contrasena);

        // Muestra un mensaje de retroalimentación sobre la fortaleza de la contraseña en el lado del servidor
        lblERROR.Text = fortaleza;

        if (fortaleza == "La contraseña es segura.")
        {
            Registrar(sender, e);
        }
    }
    private string calcularFortalezaContrasena(string contrasena)
    {
        // Implementa tu lógica para calcular la fortaleza de la contraseña aquí
        // Puedes utilizar expresiones regulares y otros criterios para evaluar la fortaleza

        if (contrasena.Length < 8)
        {
            return "La contraseña debe tener al menos 8 caracteres.";
        }
        else if (!contrasena.Any(c => char.IsDigit(c)))
        {
            return "La contraseña debe contener al menos un número.";
        }
        else if (!contrasena.Any(c => char.IsLetter(c)))
        {
            return "La contraseña debe contener al menos una letra.";
        }
        else
        {
            return "La contraseña es segura.";
        }
    }
}
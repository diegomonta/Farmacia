using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class LogIn : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
    {
        // Agrega un atributo de evento al campo de contraseña para llamar a la función JavaScript
        txtPass.Attributes.Add("onkeyup", "validarContrasena();");
    }
    public void ingresar(object sender, EventArgs e)
    {
        try
        {
            LogicaUsuario logicaUsuario = new LogicaUsuario();
            Usuario usu = logicaUsuario.LoginUsuario(txtUsuario.Text, txtPass.Text);
            if (usu is Cliente)
            {
                Session["USUARIO"] = usu;
                Response.Redirect("HomePage.aspx");
            }
            else if (usu is Empleado)
            {
                Session["USUARIO"] = usu;
                Response.Redirect("HomePage.aspx");
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
    

    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        string contrasena = txtPass.Text;

        // Realiza la validación de la contraseña utilizando la función calcularFortalezaContrasena
        string fortaleza = calcularFortalezaContrasena(contrasena);

        // Muestra un mensaje de retroalimentación sobre la fortaleza de la contraseña en el lado del servidor
        lblERROR.Text = fortaleza;

        if (fortaleza == "La contraseña es segura.")
        {
            ingresar(sender, e);
        }
    }

    private string calcularFortalezaContrasena(string contrasena)
    {
        // Implementa tu lógica para calcular la fortaleza de la contraseña aquí
        // Puedes utilizar expresiones regulares y otros criterios para evaluar la fortaleza

        if (contrasena.Length < 5)
        {
            return "La contraseña debe tener al menos 5 caracteres.";
        }
        if (contrasena.Length > 10)
        {
            return "La contraseña debe tener menos 10 caracteres.";
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
    protected void btnRegistrarCliente_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegistroUsuario.aspx");
    }

    protected void btnConsulta_Click(object sender, EventArgs e)
    {
        Response.Redirect("Consulta.aspx");
    }
}
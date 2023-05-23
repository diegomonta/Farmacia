using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text.Trim();
        string contrasena = txtPass.Text.Trim();

        // Validar entrada de usuario para evitar ataques de XSS u otros tipos de ataques
        // Utilizar funciones de validación y sanitización proporcionadas por el framework o lenguaje de programación

        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
        {
            lblERROR.Text = "Debe ingresar un usuario y una contraseña válidos.";
            return;
        }

        try
        {
            // Realizar el hash de la contraseña antes de enviarla a la capa de lógica
            string hashedContrasena = CalcularHash(contrasena);

            LogicaUsuario logicaUsuario = new LogicaUsuario();
            Usuario usu = logicaUsuario.LoginUsuario(usuario, hashedContrasena);

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
            LogError(ex);
            lblERROR.Text = "Ocurrió un error en el proceso de inicio de sesión. Por favor, intenta nuevamente más tarde.";
        }
    }

    

    protected void btnConsulta_Click(object sender, EventArgs e)
    {
        Response.Redirect("Consulta.aspx");
    }

    private void LogError(Exception ex)
    {
        // Implementar la lógica para registrar el error en logs
        // Utilizar librerías o métodos específicos para esto
    }

    private string CalcularHash(string input)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}

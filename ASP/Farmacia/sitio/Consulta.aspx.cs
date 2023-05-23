using System;
using System.Text;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using System.Data.SqlClient;
using Logica;
using EntidadesCompartidas;
using System.Collections.Generic;
using System.Security.Cryptography;

public partial class Consulta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string key = Request.QueryString["key"];

            if (!string.IsNullOrEmpty(key))
            {

                    // Mostrar formulario para cambiar la contraseña
                    pnlRecuperarContraseña.Visible = true;
            }
        }
    }

    protected void btnRecuperarContraseña_Click(object sender, EventArgs e)
    { 
        string usuario =  txtUsuario.Text.Trim();

        try
        {
            LogicaUsuario logicaUsuario = new LogicaUsuario();
            Usuario usu = logicaUsuario.BuscarUsuario(txtUsuario.Text);
            string correo = ((EntidadesCompartidas.Empleado)usu).pCorreo;

            if (usu is Cliente)
            {
                throw new Exception("Este usuario pertenece a un estudiante no se puede cambiar contraseña.");
            }
            else if (usu is Empleado)
            {
                UsuarioExiste(usuario, correo);
            }
            else
            {
                throw new Exception("Este usuario no existe");
            }

                         
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
        
    }
    private string GenerarClaveRecuperacion()
    {
        const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        char[] claveArray = new char[8];
        Random random = new Random();

        for (int i = 0; i < claveArray.Length; i++)
        {
            claveArray[i] = caracteres[random.Next(caracteres.Length)];
        }

        return new string(claveArray);
    }

    private string UsuarioExiste(string usuario, string correo)
    {
     
        
            string clave = GenerarClaveRecuperacion();
            string claveRecuperacion = CalcularHash(clave);
            GuardarClaveRecuperacion(usuario, claveRecuperacion);
            EnviarCorreoRecuperacion(usuario, clave,correo);
            // Response.Redirect("~/Default.aspx");
        return usuario;
    }

    private void GuardarClaveRecuperacion(string usuario, string claveRecuperacion)
    {
        try
        {
            LogicaUsuario logicaUsuario = new LogicaUsuario();
            logicaUsuario.ModificarClave(usuario, claveRecuperacion);

            lblERROR.ForeColor = System.Drawing.Color.Green;
            lblERROR.Text = "Modificacion exitosa.";
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }

  
    private string EnviarCorreoRecuperacion(string usuario, string claveRecuperacion, string correo)
    {
        string msge = "Error al enviar este correo. Por favor verifique los datos o intente más tarde.";
        string from = "escuelaseguridad23@outlook.es";
        string displayName = "recuperacion contraseña";
        try
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from, displayName);
            mail.To.Add(correo);

            mail.Subject = "recuperacion contraseña";
            mail.Body = claveRecuperacion;
            mail.IsBodyHtml = true;


            SmtpClient client = new SmtpClient("smtp.office365.com", 587); //Aquí debes sustituir tu servidor SMTP y el puerto
            client.Credentials = new NetworkCredential(from, "Escuela2023");
            client.EnableSsl = true;//En caso de que tu servidor de correo no utilice cifrado SSL,poner en false

            client.Send(mail);
            msge = "¡Correo enviado exitosamente! Pronto te contactaremos.";

        }
        catch (Exception ex)
        {
            msge = ex.Message + ". Por favor verifica tu conexión a internet y que tus datos sean correctos e intenta nuevamente.";
        }

        return msge;
    }
    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        LogedOut();
    }
    public void LogedOut()
    {
        Session["USUARIO"] = null;
        btnLogOut.Enabled = false;
        Response.Redirect("Default.aspx");
    }
    private void MostrarMensaje()
    {
        // Mostrar el mensaje en tu interfaz de usuario (puede ser un control Label, una alerta JavaScript, etc.)
        // Aquí se muestra un ejemplo de implementación ficticia:
        
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
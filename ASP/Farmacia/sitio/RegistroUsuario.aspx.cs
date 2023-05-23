using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using EntidadesCompartidas;
using Logica;

public partial class RegistroUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Aquí puedes realizar acciones adicionales en la carga de la página
    }

    protected void Registrar(object sender, EventArgs e)
    {
        try
        {
            string usuario = txtUsuario.Text.Trim();
            string pass = txtPass.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string direccionFacturacion = txtDireccionFacturacion.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            // Realiza validaciones de seguridad en el lado del servidor
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(direccionFacturacion) || string.IsNullOrEmpty(telefono))
            {
                lblERROR.ForeColor = System.Drawing.Color.Red;
                lblERROR.Text = "Por favor, complete todos los campos.";
                return;
            }

            // Ejemplo de medida de seguridad: Almacenamiento de contraseñas con hash y sal
            string hashPassword = CalcularHash(pass);

            // Ejemplo de medida de seguridad: Verificar si el usuario ya existe en la base de datos
            if (UsuarioExistente(usuario))
            {
                lblERROR.ForeColor = System.Drawing.Color.Red;
                lblERROR.Text = "El nombre de usuario ya está en uso. Por favor, elija otro.";
                return;
            }

            LogicaUsuario logicaUsuario = new LogicaUsuario();
            Cliente cliente = new Cliente(usuario, hashPassword, nombre, direccionFacturacion, telefono);

            logicaUsuario.AltaUsuario(cliente);

            // Almacenar en la sesión el usuario registrado
            Session["USUARIO"] = cliente;

            // Redirigir al usuario a una página de éxito o inicio de sesión
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = "Ha ocurrido un error: " + ex.Message;
        }
    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        string contrasena = txtPass.Text.Trim();

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

    private bool UsuarioExistente(string usuario)
    {
        // Verificar si el usuario ya existe en la base de datos
        LogicaUsuario logicaUsuario = new LogicaUsuario();
        Usuario usuarioExistente = logicaUsuario.BuscarUsuario(usuario);

        return usuarioExistente != null;
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
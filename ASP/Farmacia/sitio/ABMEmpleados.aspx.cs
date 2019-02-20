using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABMEmpleados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //CARGAR HORAS
                for (int hora = 1; hora <= 24; hora++)
                {
                    string Hora = (hora.ToString() == "24") ? "00" : ((hora.ToString().Length == 1) ? ("0" + hora.ToString()) : hora.ToString());

                    ddlInicioJornadaHoras.Items.Add(Hora);
                    ddlFinJornadaHoras.Items.Add(Hora);
                }

                //CARGAR MINUTOS
                for (int minuto = 0; minuto <= 55; minuto += 5)
                {
                    string Minuto = (minuto.ToString().Length == 1) ? ("0" + minuto.ToString()) : minuto.ToString();
                    ddlInicioJornadaMinutos.Items.Add(Minuto.ToString());
                    ddlFinJornadaMinutos.Items.Add(Minuto.ToString());
                }

                FormularioDefault();
            }
        }
        catch (Exception ex) { lblERROR.Text = ex.Message; }
    }

    //FORMULARIO ESTADO DEFAULT
    private void FormularioDefault()
    {
        //BLOQUEAR BOTONES
        btnAlta.Enabled = false;
        btnBaja.Enabled = false;
        btnModificar.Enabled = false;
        btnCancelar.Enabled = true;
        btnBuscar.Enabled = true;

        //BOQUEAR TEXTBOXES
        txtUsuario.Enabled = true;
        txtUsuario.Text = "";

        txtPass.Enabled = false;
        txtPass.Text = "";

        txtNombre.Enabled = false;
        txtNombre.Text = "";
        ddlFinJornadaHoras.Enabled = false;
        ddlFinJornadaMinutos.Enabled = false;
        ddlInicioJornadaHoras.Enabled = false;
        ddlInicioJornadaMinutos.Enabled = false;
    }

    //FORMULARIO ESTADO ALTA
    private void FormularioAlta()
    {
        //BLOQUEAR BOTONES
        btnAlta.Enabled = true;
        btnBaja.Enabled = false;
        btnModificar.Enabled = false;
        btnCancelar.Enabled = true;
        btnBuscar.Enabled = true;

        //BOQUEAR TEXTBOXES
        txtUsuario.Enabled = false;
        txtPass.Enabled = true;
        txtNombre.Enabled = true;
        ddlFinJornadaHoras.Enabled = true;
        ddlFinJornadaMinutos.Enabled = true;
        ddlInicioJornadaHoras.Enabled = true;
        ddlInicioJornadaMinutos.Enabled = true;
    }

    //FORMULARIO MODIFICAR / CANCELAR
    private void FormularioModificarCancelar()
    {
        //BLOQUEAR BOTONES
        btnAlta.Enabled = false;
        btnBaja.Enabled = true;
        btnModificar.Enabled = true;
        btnCancelar.Enabled = true;
        btnBuscar.Enabled = true;

        //BOQUEAR TEXTBOXES
        txtUsuario.Enabled = false;
        txtPass.Enabled = true;
        txtNombre.Enabled = true;
        ddlFinJornadaHoras.Enabled = true;
        ddlFinJornadaMinutos.Enabled = true;
        ddlInicioJornadaHoras.Enabled = true;
        ddlInicioJornadaMinutos.Enabled = true;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try { }
        catch (Exception ex)
        {
            lblERROR.Text = ex.Message;
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try { }
        catch (Exception ex)
        {
            lblERROR.Text = ex.Message;
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        try { }
        catch (Exception ex)
        {
            lblERROR.Text = ex.Message;
        }
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try { }
        catch (Exception ex)
        {
            lblERROR.Text = ex.Message;
        }
    }
    protected void btnBaja_Click(object sender, EventArgs e)
    {
        try { }
        catch (Exception ex)
        {
            lblERROR.Text = ex.Message;
        }
    }
    protected void btnAlta_Click(object sender, EventArgs e)
    {
        try { }
        catch (Exception ex)
        {
            lblERROR.Text = ex.Message;
        }
    }
}
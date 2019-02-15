using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABMFarmacias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
        txtCorreoElectronico.Enabled = false;
        txtDireccion.Enabled = false;
        txtNombre.Enabled = false;
        txtRuc.Enabled = true;
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
        txtCorreoElectronico.Enabled = true;
        txtDireccion.Enabled = true;
        txtNombre.Enabled = true;
        txtRuc.Enabled = false;
    }

    //FORMULARIO MODIFICAR / CANCELAR
    private void FormularioModificarCancelar()
    {
        //BLOQUEAR BOTONES
        btnAlta.Enabled = true;
        btnBaja.Enabled = false;
        btnModificar.Enabled = false;
        btnCancelar.Enabled = true;
        btnBuscar.Enabled = true;

        //BOQUEAR TEXTBOXES
        txtCorreoElectronico.Enabled = true;
        txtDireccion.Enabled = true;
        txtNombre.Enabled = true;
        txtRuc.Enabled = false;
    }
    //ALTA FARMACEUTICA
    protected void btnAlta_Click(object sender, EventArgs e)
    {

    }

    //BAJA FARMACEUTICA
    protected void btnBaja_Click(object sender, EventArgs e)
    {

    }

    //MODIFICAR FARMACEUTICA
    protected void btnModificar_Click(object sender, EventArgs e)
    {

    }

    //BUSCAR FARMACEUTICA
    protected void btnBuscar_Click(object sender, EventArgs e)
    {

    }

    //CANCELAR (RESPONSE REDIRECT HOMEPAGE)
    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }

    //LIMPIAR FORMULARIO
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.FormularioDefault();
    }
}
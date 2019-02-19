using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

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
        try
        {
            Logica.LogicaFarmaceutica logicaFarmaceutica = new LogicaFarmaceutica();
            string RUC = txtRuc.Text;
            string Nombre = txtNombre.Text;
            string CorreoElectronio = txtCorreoElectronico.Text;
            string Direccion = txtDireccion.Text;
            Farmaceutica farmaceutica = new Farmaceutica(RUC, Nombre, CorreoElectronio, Direccion);

            logicaFarmaceutica.AltaFarmaceutica(farmaceutica);
        }
        catch (Exception ex) { lblERROR.Text = ex.Message; }
    }

    //BAJA FARMACEUTICA
    protected void btnBaja_Click(object sender, EventArgs e)
    {
        try { }
        catch (Exception ex) { lblERROR.Text = ex.Message; }
    }

    //MODIFICAR FARMACEUTICA
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try { }
        catch (Exception ex) { lblERROR.Text = ex.Message; }
    }

    //BUSCAR FARMACEUTICA
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Logica.LogicaFarmaceutica logicaFarmaceutica = new Logica.LogicaFarmaceutica();
            Session["Farmaceutica"] = logicaFarmaceutica.BuscarFarmaceutica(txtRuc.Text);

            if ((Farmaceutica)Session["Farmaceutica"] == null)
                FormularioAlta();
            else
                FormularioModificarCancelar();
        }
        catch (Exception ex) { lblERROR.Text = ex.Message; }
    }

    //CANCELAR (RESPONSE REDIRECT HOMEPAGE)
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try { }
        catch (Exception ex) { lblERROR.Text = ex.Message; }
    }

    //LIMPIAR FORMULARIO
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Session["Farmaceutica"] = null;
        this.FormularioDefault();
    }
}
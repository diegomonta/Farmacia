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
        try
        {
            //PASE DE SEGURIDAD
            if ((Usuario)Session["USUARIO"] is Cliente)
                Response.Redirect("HomePage.aspx");

            if (!Page.IsPostBack)
            {
                FormularioDefault();
            }
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
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
        txtCorreoElectronico.Text = "";

        txtDireccion.Enabled = false;
        txtDireccion.Text = "";

        txtNombre.Enabled = false;
        txtNombre.Text = "";

        txtRuc.Enabled = true;
        txtRuc.Text = "";

        lblERROR.Text = "";
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
        btnAlta.Enabled = false;
        btnBaja.Enabled = true;
        btnModificar.Enabled = true;
        btnCancelar.Enabled = true;
        btnBuscar.Enabled = true;

        //BOQUEAR TEXTBOXES
        txtCorreoElectronico.Enabled = true;
        txtCorreoElectronico.Text = ((Farmaceutica)Session["Farmaceutica"]).pCorreoElectronico;

        txtDireccion.Enabled = true;
        txtDireccion.Text = ((Farmaceutica)Session["Farmaceutica"]).pDireccion;

        txtNombre.Enabled = true;
        txtNombre.Text = ((Farmaceutica)Session["Farmaceutica"]).pNombre;

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

            //EXITO
            lblERROR.ForeColor = System.Drawing.Color.Green;
            lblERROR.Text = "Alta exitosa.";
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }

    //BAJA FARMACEUTICA
    protected void btnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            Logica.LogicaFarmaceutica logicaFarmaceutica = new Logica.LogicaFarmaceutica();
            logicaFarmaceutica.BajaFarmaceutica((Farmaceutica)Session["Farmaceutica"]);

            //EXITO
            lblERROR.ForeColor = System.Drawing.Color.Green;
            lblERROR.Text = "Baja exitosa.";
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }

    //MODIFICAR FARMACEUTICA
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Logica.LogicaFarmaceutica logicaFarmaceutica = new Logica.LogicaFarmaceutica();
            string RUC = ((Farmaceutica)Session["Farmaceutica"]).pRUC;
            string Nombre = txtNombre.Text;
            string CorreoElectronico = txtCorreoElectronico.Text;
            string Direccion = txtDireccion.Text;

            Farmaceutica farmaceutica = new Farmaceutica(RUC, Nombre, CorreoElectronico, Direccion);
            logicaFarmaceutica.ModificarFarmaceutica(farmaceutica);

            //EXITO
            lblERROR.ForeColor = System.Drawing.Color.Green;
            lblERROR.Text = "Modificacion exitosa.";
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
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
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }

    //CANCELAR (RESPONSE REDIRECT HOMEPAGE)
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try { Response.Redirect("DefaultEmpleado.aspx"); }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }

    //LIMPIAR FORMULARIO
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Session["Farmaceutica"] = null;
        this.FormularioDefault();
    }
}
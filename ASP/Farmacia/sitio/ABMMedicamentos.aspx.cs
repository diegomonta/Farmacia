using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABMMedicamentos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //PASE DE SEGURIDAD
            if ((Usuario)Session["USUARIO"] is Cliente)
                Response.Redirect("HomePage.aspx");

            //CARGAR FARMACEUTICAS
            if (!Page.IsPostBack)
            {
                Logica.LogicaFarmaceutica logicaFarmaceutica = new LogicaFarmaceutica();
                List<Farmaceutica> listaFarmaceuticas = logicaFarmaceutica.ListarFarmaceutica();

                foreach (Farmaceutica farmaceutica in listaFarmaceuticas)
                {
                    ListItem item = new ListItem(farmaceutica.pNombre + "(" + farmaceutica.pRUC + ")", farmaceutica.pRUC);
                    ddlFarmaceuticas.Items.Add(item);
                }
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
        txtCodigo.Enabled = true;
        txtCodigo.Text = "";

        ddlFarmaceuticas.Enabled = true;

        txtDescripcion.Enabled = false;
        txtDescripcion.Text = "";

        txtPrecio.Enabled = false;
        txtPrecio.Text = "";

        txtNombre.Enabled = false;
        txtNombre.Text = "";

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
        txtCodigo.Enabled = false;

        ddlFarmaceuticas.Enabled = false;

        txtDescripcion.Enabled = true;
        txtDescripcion.Text = "";

        txtPrecio.Enabled = true;
        txtPrecio.Text = "";

        txtNombre.Enabled = true;
        txtNombre.Text = "";
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
        txtCodigo.Enabled = false;

        ddlFarmaceuticas.Enabled = false;

        txtDescripcion.Enabled = true;
        txtDescripcion.Text = ((Medicamento)Session["Medicamento"]).pDescripcion;

        txtPrecio.Enabled = true;
        txtPrecio.Text = ((Medicamento)Session["Medicamento"]).pPrecio.ToString();

        txtNombre.Enabled = true;
        txtNombre.Text = ((Medicamento)Session["Medicamento"]).pNombre;
    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            Logica.LogicaFarmaceutica logicaFarmaceutica = new LogicaFarmaceutica();
            Logica.LogicaMedicamento logicaMedicamento = new LogicaMedicamento();

            Farmaceutica farmaceutica = logicaFarmaceutica.BuscarFarmaceutica(ddlFarmaceuticas.SelectedItem.Value);

            if (farmaceutica == null)
                throw new Exception("La farmaceutica no existe.");

            string descripcion = txtDescripcion.Text;
            double doublevalue;
            double precio;
            string nombre = txtNombre.Text;
            int codigo;
            int intvalue;

            //VARIFICAR INT
            if (int.TryParse(txtCodigo.Text, out intvalue))
                codigo = Convert.ToInt32(txtCodigo.Text);
            else
                throw new Exception("El codigo debe ser un numero.");

            //VERIFICAR DOUBLE
            if (double.TryParse(txtPrecio.Text, out doublevalue))
                precio = double.Parse(txtPrecio.Text);
            else
                throw new Exception("El precio debe ser un numero.");

            Medicamento medicamento = new Medicamento(codigo, farmaceutica, nombre, descripcion, precio);

            logicaMedicamento.AltaMedicamento(medicamento);

            lblERROR.ForeColor = System.Drawing.Color.Green;
            lblERROR.Text = "Alta exitosa.";
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
    protected void btnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            Logica.LogicaFarmaceutica logicaFarmaceutica = new LogicaFarmaceutica();
            Logica.LogicaMedicamento logicaMedicamento = new LogicaMedicamento();

            Farmaceutica farmaceutica = logicaFarmaceutica.BuscarFarmaceutica(ddlFarmaceuticas.SelectedItem.Value);

            if (farmaceutica == null)
                throw new Exception("La farmaceutica no existe.");

            string descripcion = txtDescripcion.Text;
            double doublevalue;
            double precio;
            string nombre = txtNombre.Text;
            int codigo;
            int intvalue;

            //VARIFICAR INT
            if (int.TryParse(txtCodigo.Text, out intvalue))
                codigo = Convert.ToInt32(txtCodigo.Text);
            else
                throw new Exception("El codigo debe ser un numero.");

            //VERIFICAR double
            if (double.TryParse(txtPrecio.Text, out doublevalue))
                precio = double.Parse(txtPrecio.Text);
            else
                throw new Exception("El precio debe ser un numero.");

            Medicamento medicamento = new Medicamento(codigo, farmaceutica, nombre, descripcion, precio);

            logicaMedicamento.BajaMedicamento(medicamento);

            lblERROR.ForeColor = System.Drawing.Color.Green;
            lblERROR.Text = "Baja exitosa.";
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Logica.LogicaFarmaceutica logicaFarmaceutica = new LogicaFarmaceutica();
            Logica.LogicaMedicamento logicaMedicamento = new LogicaMedicamento();

            Farmaceutica farmaceutica = logicaFarmaceutica.BuscarFarmaceutica(ddlFarmaceuticas.SelectedItem.Value);

            if (farmaceutica == null)
                throw new Exception("La farmaceutica no existe.");

            string descripcion = txtDescripcion.Text;
            double doublevalue;
            double precio;
            string nombre = txtNombre.Text;
            int codigo;
            int intvalue;

            //VARIFICAR INT
            if (int.TryParse(txtCodigo.Text, out intvalue))
                codigo = Convert.ToInt32(txtCodigo.Text);
            else
                throw new Exception("El codigo debe ser un numero.");

            //VERIFICAR double
            if (double.TryParse(txtPrecio.Text, out doublevalue))
                precio = double.Parse(txtPrecio.Text);
            else
                throw new Exception("El precio debe ser un numero.");

            Medicamento medicamento = new Medicamento(codigo, farmaceutica, nombre, descripcion, precio);

            logicaMedicamento.ModificarMedicamento(medicamento);

            lblERROR.ForeColor = System.Drawing.Color.Green;
            lblERROR.Text = "Modificacion exitosa.";
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            int intvalue;
            if (int.TryParse(txtCodigo.Text, out intvalue))
            {
                Logica.LogicaMedicamento logicaMedicamento = new LogicaMedicamento();
                Session["Medicamento"] = logicaMedicamento.BuscarMedicamento(Convert.ToInt32(txtCodigo.Text), ddlFarmaceuticas.SelectedItem.Value);

                if (Session["Medicamento"] == null)
                    FormularioAlta();
                else
                    FormularioModificarCancelar();
            }
            else
                throw new Exception("Codigo debe ser un numero.");
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        try
        {
            FormularioDefault();
            Session["Medicamento"] = null;
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
}
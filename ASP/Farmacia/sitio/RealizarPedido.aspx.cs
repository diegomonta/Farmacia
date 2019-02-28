using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using EntidadesCompartidas;
using System.Data;
public partial class RealizarPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Logica.LogicaMedicamento logicaMedicamento = new LogicaMedicamento();
            Session["listaMedicamentos"] = logicaMedicamento.ListarMedicamento();
            gvMedicamentos.DataSource = (List<Medicamento>)Session["listaMedicamentos"];
            gvMedicamentos.DataBind();
        }
    }

    protected void gvMedicamentos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int index = gvMedicamentos.SelectedRow.RowIndex;
            Session["Medicamento"] = ((List<Medicamento>)Session["listaMedicamentos"])[index];
            txtCodigo.Text = ((Medicamento)Session["Medicamento"]).pCodigo.ToString();
            txtDescripcion.Text = ((Medicamento)Session["Medicamento"]).pDescripcion;
            txtFarmaceutica.Text = ((Medicamento)Session["Medicamento"]).pFarmaceutica.pRUC;
            txtNombre.Text = ((Medicamento)Session["Medicamento"]).pNombre;
            txtPrecio.Text = ((Medicamento)Session["Medicamento"]).pPrecio.ToString();
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
    protected void btnPedir_Click(object sender, EventArgs e)
    {
        try
        {
            //VERIFICACIONES
            if ((Medicamento)Session["Medicamento"] == null)
                throw new Exception("Debe seleccionar un medicamento.");
            int cantidad;

            try
            {
                cantidad = Convert.ToInt32(txtCantidad.Text);
                if (cantidad < 1)
                    throw new Exception("La cantidad debe ser mayor a cero.");
            }
            catch { throw new Exception("La cantidad debe ser un numero."); }


        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
}
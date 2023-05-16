using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using EntidadesCompartidas;
using System.Data;
public partial class RealizarInscripcion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //PASE DE SEGURIDAD
            if ((Usuario)Session["USUARIO"] is Empleado)
                Response.Redirect("HomePage.aspx");

            if (!Page.IsPostBack)
            {
                LogicaMedicamento logicaMedicamento = new LogicaMedicamento();
                Session["listaMedicamentos"] = logicaMedicamento.ListarMedicamento();
                gvMedicamentos.DataSource = (List<Medicamento>)Session["listaMedicamentos"];
                gvMedicamentos.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }

    protected void gvMedicamentos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int index = gvMedicamentos.SelectedRow.RowIndex;
            Session["MEDICAMENTO"] = ((List<Medicamento>)Session["listaMedicamentos"])[index];
            txtCodigo.Text = ((Medicamento)Session["MEDICAMENTO"]).pCodigo.ToString();
            txtDescripcion.Text = ((Medicamento)Session["MEDICAMENTO"]).pDescripcion;
            txtFarmaceutica.Text = ((Medicamento)Session["MEDICAMENTO"]).pFarmaceutica.pRUC;
            txtNombre.Text = ((Medicamento)Session["MEDICAMENTO"]).pNombre;
            txtPrecio.Text = ((Medicamento)Session["MEDICAMENTO"]).pPrecio.ToString();
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
            if ((Medicamento)Session["MEDICAMENTO"] == null)
                throw new Exception("Debe seleccionar un curso.");
            int cantidad;

            try
            {
                cantidad = Convert.ToInt32(txtCantidad.Text);
            }
            catch { throw new Exception("La cantidad debe ser un numero."); }

            if (cantidad < 1)
                throw new Exception("La cantidad debe ser mayor a cero.");

            Pedido pedido = new Pedido((Cliente)Session["USUARIO"], (Medicamento)Session["MEDICAMENTO"], cantidad, "GENERADO");
            LogicaPedido logicaPedido = new LogicaPedido();
            logicaPedido.AltaPedido(pedido);

            lblERROR.ForeColor = System.Drawing.Color.Green;
            lblERROR.Text = "inscribcion generado con exito.";

        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
}
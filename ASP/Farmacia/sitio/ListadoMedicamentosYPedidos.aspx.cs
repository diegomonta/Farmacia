using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ListadoMedicamentosYPedidos : System.Web.UI.Page
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
                LogicaFarmaceutica logicaFarmaceutica = new LogicaFarmaceutica();
                List<Farmaceutica> listaFarmaceuticas = logicaFarmaceutica.ListarFarmaceutica();

                foreach (Farmaceutica farmaceutica in listaFarmaceuticas)
                {
                    ListItem item = new ListItem(farmaceutica.pNombre + "(" + farmaceutica.pRUC + ")", farmaceutica.pRUC);
                    ddlFarmaceutica.Items.Add(item);
                }
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

    }

    protected void ddlFarmaceutica_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LogicaFarmaceutica logicaFarmaceutica = new LogicaFarmaceutica();
            Farmaceutica farmaceutica = logicaFarmaceutica.BuscarFarmaceutica(ddlFarmaceutica.SelectedItem.Value);

            LogicaMedicamento logicaMedicamento = new LogicaMedicamento();
            Session["ListaMedicamentos"] = logicaMedicamento.ListarMedicamentoPorFarmaceutica(farmaceutica);
            gvMedicamentos.DataSource = (List<Medicamento>)Session["ListaMedicamentos"];
            gvMedicamentos.DataBind();
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
}
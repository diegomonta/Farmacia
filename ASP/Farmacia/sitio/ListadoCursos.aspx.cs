using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ListadoCursos : System.Web.UI.Page
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
        int index = gvMedicamentos.SelectedRow.RowIndex;
        Session["MEDICAMENTO"] = ((List<Medicamento>)Session["ListaMedicamentos"])[index];

        btnTodos_Click(null, EventArgs.Empty);
    }

    protected void ddlFarmaceutica_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlFarmaceutica.SelectedItem.Value))
            {
                LogicaFarmaceutica logicaFarmaceutica = new LogicaFarmaceutica();
                Farmaceutica farmaceutica = logicaFarmaceutica.BuscarFarmaceutica(ddlFarmaceutica.SelectedItem.Value);

                LogicaMedicamento logicaMedicamento = new LogicaMedicamento();
                Session["ListaMedicamentos"] = logicaMedicamento.ListarMedicamentoPorFarmaceutica(farmaceutica);
                gvMedicamentos.DataSource = (List<Medicamento>)Session["ListaMedicamentos"];
                gvMedicamentos.DataBind();

                //LIMPIAR GRIDVIEW PEDIDOS
                gvPedidos.DataSource = null;
                gvPedidos.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
    protected void btnTodos_Click(object sender, EventArgs e)
    {
        try
        {
            //MOSTRAR FILTRO SELECCIONADO
            btnTodos.BackColor = System.Drawing.Color.Green;
            btnGenerados.BackColor = System.Drawing.Color.Silver;
            btnEntregados.BackColor = System.Drawing.Color.Silver;

            if ((Medicamento)Session["MEDICAMENTO"] == null)
                throw new Exception("Debe seleccionar un medicamento.");
            LogicaPedido logicaPedido = new LogicaPedido();
            gvPedidos.DataSource = logicaPedido.ListarPedidoPorMedicamento((Medicamento)Session["MEDICAMENTO"]);
            gvPedidos.DataBind();
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }

    }
    protected void btnGenerados_Click(object sender, EventArgs e)
    {
        try
        {
            //MOSTRAR FILTRO SELECCIONADO
            btnTodos.BackColor = System.Drawing.Color.Silver;
            btnGenerados.BackColor = System.Drawing.Color.Green;
            btnEntregados.BackColor = System.Drawing.Color.Silver;

            if ((Medicamento)Session["MEDICAMENTO"] == null)
                throw new Exception("Debe seleccionar un medicamento.");

            LogicaPedido logicaPedido = new LogicaPedido();
            gvPedidos.DataSource = logicaPedido.ListarPedidoPorEstadoMedicamento((Medicamento)Session["MEDICAMENTO"], "GENERADO");
            gvPedidos.DataBind();
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
    protected void btnEntregados_Click(object sender, EventArgs e)
    {
        try
        {
            //MOSTRAR FILTRO SELECCIONADO
            btnTodos.BackColor = System.Drawing.Color.Silver;
            btnGenerados.BackColor = System.Drawing.Color.Silver;
            btnEntregados.BackColor = System.Drawing.Color.Green;

            if ((Medicamento)Session["MEDICAMENTO"] == null)
                throw new Exception("Debe seleccionar un medicamento.");

            LogicaPedido logicaPedido = new LogicaPedido();
            gvPedidos.DataSource = logicaPedido.ListarPedidoPorEstadoMedicamento((Medicamento)Session["MEDICAMENTO"], "ENTREGADO");
            gvPedidos.DataBind();
        }
        catch (Exception ex)
        {
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Text = ex.Message;
        }
    }
}
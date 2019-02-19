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
        }

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {

    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {

    }
    protected void btnBaja_Click(object sender, EventArgs e)
    {

    }
    protected void btnAlta_Click(object sender, EventArgs e)
    {

    }
}
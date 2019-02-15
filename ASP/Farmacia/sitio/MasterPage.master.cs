using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Usuario)Session["USUARIO"] != null)
            LogedIn();
        else
            LogedOut();
    }

    public void LogedIn()
    {
        //BOTONES 
        btnLogIn.Enabled = false;
        btnLogOut.Enabled = true;

    }

    public void LogedOut()
    {
        btnLogIn.Enabled = true;
        btnLogOut.Enabled = false;
    }
    protected void btnLogIn_Click(object sender, EventArgs e)
    {

    }
}

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

    public static void LogedIn()
    {
        //BOTONES 
        //this.btnLogIn.Enabled = false;
        //this.btnLogOut.Enabled = true;
    }

    public static void LogedOut() {
        //this.btnLogIn.Enabled = true;
        //this.btnLogOut.Enabled = false;
    }
}

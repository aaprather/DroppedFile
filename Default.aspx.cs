using System;
using TOOL;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["tos"] != null)
        {
            Server.Transfer("~/Terms.aspx");
        }
        else if(Request.QueryString["r"] != null)
        {
            Server.Transfer("~/Report.aspx");
        }
        else if (Request.QueryString["s"] == null)
        {
            /*DEBUG CHECK*/
            if (Tools.GetIPAddress() == "::1") //Check if it is me debugging.
                Server.Transfer("~/Home.aspx");
            else if (PI.PrivateInfo.bannedIPS.Contains(Tools.GetIPAddress()))
                Response.Redirect("http://google.com"); //Redirect all banned ip address to google

            /************/

            Tools.LogIP(); //Log EVERYBODY'S information
            Server.Transfer("~/Home.aspx");
        }
        else
            Server.Transfer("~/Download.aspx?s=" + Request.QueryString["s"]);


    }
}
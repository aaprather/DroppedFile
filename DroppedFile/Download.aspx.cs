using Globe;
using System;
using TOOL;
public partial class Download : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        Label9.Text = Globals.CompanyMessage;

        fileNameLabel.Text = Tools.getActualFileName(Request.QueryString["s"]);
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(Label2.Text);

        if (i == 0) //timer hits 0, start the download
        {
            Timer1.Enabled = false;
            Response.Redirect("~/Download2.aspx?s=" + Request.QueryString["s"]);
        }
        Label2.Text = Convert.ToString(i - 1);
        Label1.Text = Label2.Text;
    }
}
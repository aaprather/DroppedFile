using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOOL;
using Globe;
public partial class Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Label9.Text = Globals.CompanyMessage;

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if(TextBox1.Text != "")
        {
            try
            {
                Tools.LogReport(Tools.sanitizeInput(TextBox1.Text)); //Sanitized the input 8/19/2018
                TextBox1.Text = "";
                Label1.Text = "Report Sent!";
            }
            catch
            {
                TextBox1.Text = "";
                Label1.Text = "Unable to Send Report!";
            }
        }
        
        

    }
}
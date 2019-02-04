using Globe;
using System;
using System.IO;
using TOOL;
using UL;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label9.Text = Globals.CompanyMessage;
    }

    protected void uploadButton_Click(object sender, EventArgs e)
    {
        string actualFileName = Path.GetFileName(FileUpload1.FileName).Replace(" ","_");
        string storedFileName = Tools.GetRandomString() + "_" + actualFileName; //Append actualName to storedName so that links are nicer to view.

        if (Uploading.goodSize(FileUpload1.FileBytes.Length) == false) //check if file is too big 30mb limit
        {
            Label10.Text = "File is larger than 30MB";
        }
        else if(actualFileName.Contains("&"))
        {
            Label10.Text = "File contains illegal character '&'"; //Should really just replace the '&' to a blank space instead of throwing error message
        }
        else
        {
            if (FileUpload1.HasFile)
            {
                
                if (Uploading.UploadFTPfile(FileUpload1, storedFileName) == true) //successful upload
                {
                    Label10.Text = ""; //Clear any error from the link location
                    Uploading.logUpload(storedFileName, actualFileName);
                    LinkButton1.Visible = true;
                    LinkButton1.Text = Tools.GenerateLink(storedFileName);
                    LinkButton1.PostBackUrl = LinkButton1.Text;
                }
                else
                    Label10.Text = "File upload fail!";
            }
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using PI;
using DL;
using TOOL;
public partial class Download2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Downloading.DownloadFTPfile(Request.QueryString["s"], Tools.getActualFileName(Request.QueryString["s"])) == false)
            Response.Redirect(PrivateInfo.websiteBaseLink);


    }
}
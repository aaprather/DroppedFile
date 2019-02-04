using PI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;
using TOOL;

/// <summary>
/// Summary description for Uploading
/// </summary>
namespace UL
{
    public static class Uploading
    {
        public static bool goodSize(int fileSize)
        {
            if (fileSize < 31428800) //check if file is under 30mb
                return true;
            else
                return false;
        }

        public static bool UploadFTPfile(FileUpload FileUpload1, string storedFileName)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(PrivateInfo.ftpUsername, PrivateInfo.ftpPassword);
                    client.UploadData(PrivateInfo.ftpURL + storedFileName, FileUpload1.FileBytes); //upload file with name changed
                }
                return true;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.ToString());
                return false;
            }
        }

        public static void logUpload(string sName, string aName)
        {
            try
            {
                string[] clientInfo = Tools.GrabClientData(Tools.GetIPAddress());

                using (SqlConnection Connection = new SqlConnection(PrivateInfo.sqlString))
                {
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO Uploads Values (@ip, @city, @state, @date, @storedFileName, @actualFileName, @Country, @VISITDATE);", Connection);
                    Connection.Open();
                    if (Tools.GetIPAddress() == PrivateInfo.homeIP)
                    {
                        cmd.Parameters.AddWithValue("@ip", "Home"); //Log my ip address as 'Home'.
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ip", Tools.GetIPAddress()); //Log everyone else's ip address as is.
                    }
                    cmd.Parameters.AddWithValue("@city", clientInfo[2]);
                    cmd.Parameters.AddWithValue("@state", clientInfo[1]);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.AddHours(-4).ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@VISITDATE", DateTime.Now.AddHours(-4).ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@storedFileName", sName);
                    cmd.Parameters.AddWithValue("@actualFileName", aName);
                    cmd.Parameters.AddWithValue("@Country", clientInfo[0]);
                    cmd.ExecuteNonQuery();
                    Connection.Close();
                }
            }
            catch
            {

            }
        }
    }
}

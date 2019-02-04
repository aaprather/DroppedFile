using PI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using TOOL;

/// <summary>
/// Summary description for Downloading
/// </summary>
namespace DL
{
    public static class Downloading //EVERYTHING DEALING WITH DOWNLOAD
    {
        public static bool DownloadFTPfile(string sName, string aName)
        {
            try
            {
                if (aName == "")
                    return false;

                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(PrivateInfo.ftpUsername, PrivateInfo.ftpPassword);
                    DownloadFile(sName, aName);
                }
                logDownload(sName, aName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public static void logDownload(string sName, string aName)
        {
            try
            {
                string[] clientInfo = Tools.GrabClientData(Tools.GetIPAddress());

                using (SqlConnection Connection = new SqlConnection(PrivateInfo.sqlString))
                {
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO Downloads Values (@ip, @city, @state, @date, @storedFileName, @actualFileName, @Country, @VISITDATE);", Connection);
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

        public static void DownloadFile(string sName, string aName)
        {
            try
            {
                //Create FTP Request.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(PrivateInfo.ftpURL + sName);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                //Enter FTP Server credentials.
                request.Credentials = new NetworkCredential(PrivateInfo.ftpUsername, PrivateInfo.ftpPassword);
                request.UsePassive = true;
                request.UseBinary = true;
                request.EnableSsl = false;

                //Fetch the Response and read it into a MemoryStream object.
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                using (MemoryStream stream = new MemoryStream())
                {
                    //Download the File.
                    response.GetResponseStream().CopyTo(stream);
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + aName);
                    HttpContext.Current.Response.ContentType = "application/octet-stream";
                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    HttpContext.Current.Response.BinaryWrite(stream.ToArray());
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }
        }



    }
}

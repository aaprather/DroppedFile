using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using PI;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Summary description for Tools
/// </summary>
namespace TOOL
{
    public static class Tools
    {

        private static Random r = new Random();

        public static string sanitizeInput(string x) //prevents sql injection
        {
            string toReturn = x;

            if (toReturn.Contains("'"))
            {
                toReturn = toReturn.Replace("'", "");
            }

            return toReturn;
        }

        private static int GetRandomInt() //between 0 and 6
        {
            return r.Next(0, 7);
        }

        public static string GetRandomString()
        {
            int length = 10;
            byte[] seedBuffer = new byte[4];
            using (var rngCryptoServiceProvider = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(seedBuffer);
                string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                Random random = new Random(BitConverter.ToInt32(seedBuffer, 0));
                return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            }
        }

        public static string GrabClientData(string IP, int index)
        {
            string[] t = GrabClientData(GetIPAddress());
            return t[index];
        }

        public static string[] GrabClientData(string IP)
        {

            string[] t = new string[10]; //might add more data later

            var url = "http://api.ipstack.com/" + IP + "?access_key=" + PrivateInfo.getRandomKey(GetRandomInt());
            var request = WebRequest.Create(url);

            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                try
                {
                    json_data = w.DownloadString(url);
                    JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                    var result = jsSerializer.DeserializeObject(json_data);
                    Dictionary<string, object> obj2 = new Dictionary<string, object>();
                    obj2 = (Dictionary<string, object>)(result);

                    //Sometimes ipstack would be unable to determine some values, so try/catch is needed
                    try { t[0] = obj2["country_name"].ToString(); }
                    catch { t[0] = "Null Value"; }

                    try { t[1] = obj2["region_code"].ToString(); }
                    catch { t[1] = "Null Value"; }

                    try { t[2] = obj2["city"].ToString(); }
                    catch { t[2] = "Null Value"; }

                }
                catch
                {

                }
            }
            return t;
        }



        public static string GetIPAddress()
        {
            HttpContext context = HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            if (context.Request.ServerVariables["REMOTE_ADDR"] == "::1")
            {
                return PrivateInfo.homeIP; //If we are debugging, lets just return our home ip address
            }
            else
                return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        public static void LogIP()
        {
            try
            {
                string[] clientInfo = GrabClientData(GetIPAddress());

                using (SqlConnection Connection = new SqlConnection(PrivateInfo.sqlString))
                {
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO Visited Values (@ip, @city, @state, @date, @Country, @VISITDATE, @unique);", Connection);
                    Connection.Open();
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.AddHours(-4).ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@VISITDATE", DateTime.Now.AddHours(-4).ToString("yyyy-MM-dd HH:mm:ss"));
                    if (GetIPAddress() == PrivateInfo.homeIP)
                    {
                        cmd.Parameters.AddWithValue("@ip", "Home"); //Log my ip address as 'Home'.
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ip", GetIPAddress()); //Log everyone else's ip address as is.
                    }
                    cmd.Parameters.AddWithValue("@Country", clientInfo[0]);
                    cmd.Parameters.AddWithValue("@state", clientInfo[1]);
                    cmd.Parameters.AddWithValue("@city", clientInfo[2]);
                    cmd.Parameters.AddWithValue("@unique", GetRandomString());
                    cmd.ExecuteNonQuery();
                    Connection.Close();
                }
            }
            catch
            {

            }
        }
        public static string GenerateLink(string sName)
        {
            string link = PrivateInfo.websiteBaseLink + "?s=" + sName;
            return link;
        }


        public static string getActualFileName(string storedFileName)
        {
            string actualFileName = string.Empty;
            try
            {
                using (SqlConnection Connection = new SqlConnection(PrivateInfo.sqlString))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(@"Select actualFileName FROM Uploads WHERE storedFileName=@storedFileName", Connection);
                    cmd.Parameters.AddWithValue("@storedFileName", storedFileName);
                    actualFileName = (string)cmd.ExecuteScalar();
                    Connection.Close();
                }
                return actualFileName;
            }
            catch
            {
                return "";
            }

        }

        public static void LogReport(string link)
        {
            try
            {
                string[] clientInfo = GrabClientData(GetIPAddress());

                using (SqlConnection Connection = new SqlConnection(PrivateInfo.sqlString))
                {
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO Reports Values (@ip, @date, @link, @unique);", Connection);
                    Connection.Open();
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.AddHours(-4).ToString("yyyy-MM-dd HH:mm:ss"));
                    if (GetIPAddress() == PrivateInfo.homeIP)
                    {
                        cmd.Parameters.AddWithValue("@ip", "Home"); //Log my ip address as 'Home'.
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ip", GetIPAddress()); //Log everyone else's ip address as is.
                    }
                    cmd.Parameters.AddWithValue("@unique", GetRandomString());
                    cmd.Parameters.AddWithValue("@link", link);
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

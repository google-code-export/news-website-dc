using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace NewsVn.Web.Utils
{
    /// <summary>
    /// Summary description for AutoCompleteSV
    /// </summary>
    public class AutoCompleteSV : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string strConn = WebConfigurationManager.ConnectionStrings["NewsVn_Conn"].ConnectionString;
            string prefixText = context.Request.QueryString["q"];
            //sau nay cho vao cai webconfig | xai cay tren thi sua lai roi comment cai duoi lai cho tao 
            //using (SqlConnection conn = new SqlConnection("Data source=.\\SQLEXPRESS; Initial Catalog=NEWSVN; Persist Security Info=True;User ID=sa;Password=sa"))
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    StringBuilder sb = new StringBuilder();
                    try
                    {
                        cmd.CommandText = "select distinct Title from Posts where approved=1 and  datediff(day,approvedon,getdate())<=30 and Title like @SearchText + '%' ";
                        cmd.Parameters.AddWithValue("@SearchText", prefixText);
                        cmd.Connection = conn;
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                sb.Append(sdr["Title"]).Append(Environment.NewLine);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("");
                        conn.Close();
                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)
                            conn.Close();
                        conn.Dispose();
                    }
                    context.Response.Write(sb.ToString());
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
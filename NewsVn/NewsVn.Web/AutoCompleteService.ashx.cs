using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsVn.Data;
using System.Data.SqlClient;
using System.Text;

namespace NewsVn.Web
{
    /// <summary>
    /// Summary description for AutoCompleteService
    /// </summary>
    public class AutoCompleteService : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string prefixText = context.Request.QueryString["q"];
            using (SqlConnection conn = new SqlConnection("Data source=.\\SQLEXPRESS; Initial Catalog=NEWSVN; Persist Security Info=True;User ID=sa;Password=sa"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select distinct Title from Posts where approved=1 and  convert(varchar,dateadd(day,10,approvedon),103)=convert(varchar,getdate(),103) and Title like  @SearchText + '%' ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    StringBuilder sb = new StringBuilder();
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            sb.Append(sdr["Title"]).Append(Environment.NewLine);
                        }
                    }
                    conn.Close();
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
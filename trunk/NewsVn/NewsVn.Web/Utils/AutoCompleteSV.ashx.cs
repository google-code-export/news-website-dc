using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using NewsVn.Impl.Context;

namespace NewsVn.Web.Utils
{
    /// <summary>
    /// Summary description for AutoCompleteSV
    /// </summary>
    public class AutoCompleteSV : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string strConn = ApplicationManager.ConnectionString;
            string prefixText = context.Request.QueryString["q"];
            //sau nay cho vao cai webconfig | xai cay tren thi sua lai roi comment cai duoi lai cho tao 
            //using (SqlConnection conn = new SqlConnection("Data source=.\\SQLEXPRESS; Initial Catalog=NEWSVN; Persist Security Info=True;User ID=sa;Password=sa"))
            StringBuilder sb = new StringBuilder();
            try
            {
                using (var ctx = new NewsVnContext(strConn))
                {
                    var data = ctx.PostRespo.Getter.getQueryable(p => p.Title.ToLower().StartsWith(prefixText.ToLower()) && p.Actived == true) // DateTime.Now.Subtract(p.ApprovedOn.Value).Days<=30 &&
                        .Select(p => new { p.Title });

                    foreach (var item in data)
                    {
                        sb.Append(item.Title).Append(Environment.NewLine);
                    }
                }
            }
            catch (Exception)
            {
                context.Response.Write("");
            }

            context.Response.Write(sb.ToString());

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
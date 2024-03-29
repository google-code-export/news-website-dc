﻿using System;
using System.Linq;
using System.Text;
using System.Web;
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
            StringBuilder sb = new StringBuilder();
            try
            {
                using (var ctx = new NewsVnContext(strConn))
                {
                    //var data = ctx.PostRepo.Getter.getQueryable(p => p.Title.ToLower().StartsWith(prefixText.ToLower()) && p.Actived == true) // DateTime.Now.Subtract(p.ApprovedOn.Value).Days<=30 &&
                    //    .Select(p => new { p.Title, p.ApprovedOn }).OrderByDescending(p => p.ApprovedOn);

                    //koha chinh sua ngay 21/08/2011
                    var data = ctx.PostRepo.Getter.getQueryable(p => p.Title.ToLower().Contains(prefixText.ToLower()) || p.TitleAscii.ToLower().Contains(prefixText.ToLower()) && p.Actived == true) // DateTime.Now.Subtract(p.ApprovedOn.Value).Days<=30 &&
                       .Select(p => new { p.Title, p.ApprovedOn }).OrderByDescending(p => p.ApprovedOn);
                    
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
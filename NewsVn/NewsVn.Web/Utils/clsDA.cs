using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Web.UI;

namespace NewsVn.Web.Utils
{
    public class clsPost
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Avatar { get; set; }
        public string SeoUrl { get; set; }
        public DateTime ApprovedOn { get; set; }
    //    Public Shared Sub Excute_Javascript(ByVal strFunction As String, ByVal cls As Object, Optional ByVal addScriptTags As Boolean = True)
    //    'strFunction = strFunction.Replace("'", "\'")
    //    ScriptManager.RegisterStartupScript(cls, cls.GetType(), "javascriptfunction", strFunction, addScriptTags)
    //End Sub
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFunction"></param>
        /// <param name="obj"></param>
        public static void Excute_Javascript(string strFunction, object obj)
        {
            ScriptManager.RegisterStartupScript((Control) obj, obj.GetType(), "javascriptfunction", strFunction, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFunction"></param>
        /// <param name="obj"></param>
        /// <param name="bolAddScriptTags"></param>
        public static void Excute_Javascript(string strFunction, object obj, bool bolAddScriptTags = true)
        {
            ScriptManager.RegisterStartupScript((Control)obj, obj.GetType(), "javascriptfunction", strFunction, bolAddScriptTags);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryType"></param>
        /// <param name="intTake"></param>
        /// <returns></returns>
        public static List<clsPost> Load_Post_From_XML(string CategoryType,int intTake)
        {
            XDocument xCategory = XDocument.Load(HttpContext.Current.Server.MapPath(@"~/Resources/Xml/category.xml"));
            var Categories = xCategory.Descendants("Category").Where(c => c.Attribute("Type").Value == CategoryType).Descendants("Post");
            return Categories.Select(p => new clsPost()
            {
                PostID = Convert.ToInt32(p.Attribute("ID").Value),
                Title = p.Element("Title").Value,
                Avatar = p.Element("Avatar").Value,
                SeoUrl = p.Element("SeoUrl").Value,
                ApprovedOn = DateTime.Now// Convert.ToDateTime(p.Attribute("ApprovedOn").Value)
            }).Take(intTake == -1 ? 20 : intTake).ToList();
        }
    }
    public class clsCurrency
    {
        public string CurrencyCode { get; set; }
        public decimal Buy { get; set; }
        public decimal Sell { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryType"></param>
        /// <param name="intTake"></param>
        /// <returns></returns>
        public static List<clsCurrency> Get_Currency_From_Bank(string url)
        {
            XElement xCurrency = XElement.Load(url);
            var data = xCurrency.Elements("Exrate").Select(p => new clsCurrency()
            {
                CurrencyCode = p.Attribute("CurrencyCode").Value,
                Buy = Convert.ToDecimal( p.Attribute("Buy").Value),
                Sell =Convert.ToDecimal( p.Attribute("Sell").Value),
            }).ToList();

            return data;
        }
    }
}
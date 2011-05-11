using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Web.UI;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;

namespace NewsVn.Web.Utils
{
    public class clsPost
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string CateName { get; set; }
        public string Description { get; set; }
        public string ApprovedOn { get; set; }
        public string ApprovedBy { get; set; }
        public string Avatar { get; set; }
        public string SeoUrl { get; set; }
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
        public static List<clsPost> Load_Post_From_XML(int intTake)
        {
            XElement element = XElement.Load(HttpContext.Current.Server.MapPath(@"~/Resources/Xml/category.xml"));
            return element.Element("Posts").Elements("Post").Select(c => new clsPost
            {
                Title = c.Element("Title").Value,
                Avatar = c.Element("Avatar").Value,
                SeoUrl = c.Element("SeoUrl").Value,
                ID = c.Attribute("ID").Value,
                Description = c.Element("Description").Value,
                CateName = c.Element("CateName").Value,
                ApprovedBy = c.Element("ApprovedBy").Value,
                ApprovedOn = c.Element("ApprovedOn").Value,
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
            try
            {
                XElement xCurrency = XElement.Load(url);
                var data = xCurrency.Elements("Exrate").Select(p => new clsCurrency()
                {
                    CurrencyCode = p.Attribute("CurrencyCode").Value,
                    Buy = Convert.ToDecimal(p.Attribute("Buy").Value),
                    Sell = Convert.ToDecimal(p.Attribute("Sell").Value),
                }).ToList();

                return data;
            }
            catch (Exception)
            {
                return new List<clsCurrency>();
            }
            
            
        }
    }
    /// <summary>
    /// "0:Toàn quốc", "1:Hà Nội", "2:Hồ Chí Minh", "3:Các tỉnh miền Bắc", "4:Các tỉnh miền Nam"
    /// </summary>
    public class clsCommon
    {
        public static string getLocationName(int LocationID)
        {
            string[] Location = { "Toàn quốc", "Hà Nội", "Hồ Chí Minh", "Các tỉnh miền Bắc", "Các tỉnh miền Nam"};
            try
            {
                return Location[LocationID];
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string ToTitleCase(string input)
        {
            var tifo = new CultureInfo("vi-VN", false).TextInfo;
            return tifo.ToTitleCase(input);
        }
        //remove unicode vietnam
        public static string RemoveUnicodeMarks(string accented)
        {
            accented = accented.Length > 50 ? accented.Substring(0, 50) : accented;

            string[] splitted = accented.Split("~!@#$%^&*:()_+ '\",.?/`“”-–".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            accented = string.Join("-", splitted).ToLower();

            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = accented.Normalize(System.Text.NormalizationForm.FormD);

            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        //cut string fix to words expectation
        public static string hintDesc(string desc)
        {
            int intWord = 150;
            var toLong = desc.Length > intWord;
            var s_ = toLong ? desc.Substring(0, intWord - 1) : desc;
            s_ = toLong ? s_.Substring(0, s_.LastIndexOf(' ')) : s_;
            return toLong ? s_ + " ..." : s_;
        }
        //convert Gerenic List to Datatable (su dung khi it record 'performance')
        public static DataTable ListToDataTable<T>(IEnumerable<T> list)
        {
            var dt = new DataTable();

            foreach (var info in typeof(T).GetProperties())
            {
                dt.Columns.Add(new DataColumn(info.Name, info.PropertyType));
            }
            foreach (var t in list)
            {
                var row = dt.NewRow();
                foreach (var info in typeof(T).GetProperties())
                {
                    row[info.Name] = info.GetValue(t, null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

    }
}
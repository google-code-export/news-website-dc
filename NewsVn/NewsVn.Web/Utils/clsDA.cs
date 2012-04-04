using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;

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
        public string Buy { get; set; }
        public string Sell { get; set; }
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
                NumberFormatInfo nfi = new CultureInfo("vi-VN", true).NumberFormat;
                nfi.NumberGroupSeparator=",";
                XElement xCurrency = XElement.Load(url);
                var data = xCurrency.Elements("Exrate").Where(c => c.Attribute("Buy").Value != "0" && c.Attribute("Sell").Value != "0").Select(p => new clsCurrency()
                {
                    CurrencyCode = p.Attribute("CurrencyCode").Value,
                    Buy = decimal.Parse(p.Attribute("Buy").Value.Split('.')[0]).ToString("N0",nfi),
                    Sell = decimal.Parse(p.Attribute("Sell").Value.Split('.')[0]).ToString("N0", nfi)
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
            if (!string.IsNullOrEmpty(accented))
            {
                accented = accented.Length > 50 ? accented.Substring(0, 50) : accented;

                string[] splitted = accented.Split("~!@#$%^&*:()_+ '\",.?/`“”-–".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                accented = string.Join("-", splitted).ToLower();

                Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
                string strFormD = accented.Normalize(System.Text.NormalizationForm.FormD);

                return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            }
            else return "";
            
        }
        /// <summary>
        /// without "-" character
        /// </summary>
        /// <param name="accented"></param>
        /// <returns>none unicode word and separate by white space</returns>
        public static string RemoveUnicodeMarks_Whitespace(string accented)
        {
            if (!string.IsNullOrEmpty(accented))
            {
                accented = accented.Length > 50 ? accented.Substring(0, 50) : accented;

                string[] splitted = accented.Split("~!@#$%^&*:()_+ '\",.?/`“”-–".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                accented = string.Join("-", splitted).ToLower();

                Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
                string strFormD = accented.Normalize(System.Text.NormalizationForm.FormD);

                return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            }
            else return "";

        }
        public static string RemoveDangerousMarks(string accented)
        {
            if (!string.IsNullOrEmpty(accented))
            {
                accented = accented.Length > 50 ? accented.Substring(0, 50) : accented;

                string[] splitted = accented.Split("~!@#$%^&*:()_+ '\",.?/`“”-–".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                accented = string.Join(" ", splitted).ToLower();
                return accented;
            }
            else return "";
        }
        //cut string fix to words expectation
        public static string hintDesc(string desc,int intWords)
        {
            var toLong = desc.Length > intWords;
            var s_ = toLong ? desc.Substring(0, intWords - 1) : desc;
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
        public static void Excute_Javascript(string strFunction, object obj)
        {
            ScriptManager.RegisterStartupScript((Control)obj, obj.GetType(), "javascriptfunction", strFunction, false);
        }
        public static void Excute_Javascript(string strFunction, object obj, bool bolAddScriptTags = true)
        {
            ScriptManager.RegisterStartupScript((Control)obj, obj.GetType(), "javascriptfunction", strFunction, bolAddScriptTags);
        }

        public static string getEllipsisText(object input, int maxLenth)
        {
            if (input == null) return getEllipsisText(string.Empty, maxLenth);
            return getEllipsisText(input.ToString(), maxLenth);
        }

        public static string getEllipsisText(string input, int maxLenth)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            if (input.Length > maxLenth) return input.Substring(0, maxLenth) + "...";
            return input;
        }

        #region Log4net config
        public static string GetIPAddress()
        {
            HttpContext context = HttpContext.Current;
            string sIPAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (sIPAddress == null)
            {
                return context.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                string[] ipArray = sIPAddress.Split(new Char[] { ',' });
                return ipArray[0];
            }
        }
        public static string AddTabSpace(int Num)
        {
            if (Num <= 0)
            {
                return Convert.ToChar(9).ToString();
            }
            string strTab = "";
            for (int i = 1; i <= Num; i++)
            {
                strTab += Convert.ToChar(9).ToString();
            }
            return strTab;
        }
        #endregion
       
        public static void WriteTextLog(string tip,string err)
        {
            StreamWriter logFile = File.AppendText(HttpContext.Current.Server.MapPath(("Resources/Templates/logfile.txt")));
            logFile.WriteLine("---- Time: " + DateTime.Now.ToString() + " ----");
            logFile.WriteLine(tip + AddTabSpace(1) + err);
            logFile.Close();
        }
        
        
    }
}
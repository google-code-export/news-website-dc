using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using System.Xml.Linq;
using NewsVn.Core.Caching;
using System.Collections;

namespace NewsVn.Web.Utils
{
    /// <summary>
    /// Summary description for NewsVnService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class NewsVnService : BaseUI.BaseService
    {
        #region CommentBox

        private int CountPostComments(int postID)
        {
            return _PostComments.Where(c => c.Post.ID == postID).Count();
        }

        [WebMethod]
        public string GetCommentDialogTitle(int postID)
        {
            return string.Format("Bình luận: {0} ({1})",
                _Posts.FirstOrDefault(p => p.ID == postID).Title,
                this.CountPostComments(postID));
        }

        [WebMethod]
        public string GeneratePagerContent(int postID, int pageSize, int pageIndex)
        {
            int numOfComments = this.CountPostComments(postID);

            if (numOfComments <= pageSize) return "";
            
            var html = new StringBuilder();
            html.Append("<span>Trang:</span>");

            int numOfPages = numOfComments / pageSize;

            for (int i = 0; i < numOfPages; i++)
            {
                if (i + 1 == pageIndex)
                    html.AppendFormat("\n<span>{0}</span>", i + 1);
                else
                    html.AppendFormat("\n<a href=\"javascript:void(0)\">{0}</a>", i + 1);
            }

            return html.ToString();
        }

        [WebMethod]
        public string LoadCommentList(int postID, int pageSize, int pageIndex, bool oldestOnTop)
        {
            var postComments = _PostComments.Where(c => c.Post.ID == postID);

            if (oldestOnTop)
                postComments = postComments.OrderBy(c => c.UpdatedOn).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            else
                postComments = postComments.OrderByDescending(c => c.UpdatedOn).Skip(pageSize * (pageIndex - 1)).Take(pageSize);

            var html = new StringBuilder();

            foreach (var comment in postComments)
            {
                html.AppendFormat("<li><b>{0}</b><p>{1}</p><i>({2})</i></li>", comment.Title, comment.Content, comment.UpdatedBy);
            }

            return html.ToString();
        }

        private Dictionary<string, string> GetCaptchaMap()
        {
            var captchaMap = new Dictionary<string, string>();

            if (HttpContextCache.Exists("captcha-list"))
            {
                captchaMap = HttpContextCache.Get<Dictionary<string, string>>("captcha-list");
            }
            else 
            {
                try
                {
                    var root = XElement.Load(Server.MapPath("~/Resources/Xml/Captcha.xml"));
                    var captchaList = root.Elements("captcha").Select(c => new
                    {
                        Key = c.Attribute("key").Value,
                        Question = c.Element("question").Value,
                        Answer = c.Element("answer").Value
                    });

                    foreach (var captcha in captchaList)
                    {
                        captchaMap.Add(captcha.Key, string.Format("{0}|{1}", captcha.Question, captcha.Answer));
                    }

                    HttpContextCache.Add("captcha-list", captchaMap);
                }
                catch (Exception) { }
            }

            return captchaMap;
        }

        [WebMethod]
        public string GenerateFormCaptcha(string omitKey)
        {
            var captchaMap = this.GetCaptchaMap();

            Random random = new Random();

            var captcha = captchaMap.ElementAt(random.Next(0, 9));
            
            while (captcha.Key == omitKey)
            {
                captcha = captchaMap.ElementAt(random.Next(0, 9));
            }

            string[] temp = captcha.Value.Split('|');

            return string.Format("<input id=\"comment_box_captchaKey\" type=\"hidden\" value=\"{0}\" />{1}", captcha.Key, temp[0]);
        }

        private bool CheckCaptchaResponse(string key, string answer)
        {
            var captchaMap = this.GetCaptchaMap();

            string captchaAnswer = captchaMap[key].Split('|')[1];

            if (answer.Equals(captchaAnswer, StringComparison.CurrentCultureIgnoreCase)) return true;
            
            return false;
        }

        [WebMethod]
        public string InsertComment(Data.PostComment comment, int postID, string captchaKey, string captchaAnswer)
        {
            try
            {
                if (this.CheckCaptchaResponse(captchaKey, captchaAnswer))
                {
                    comment.UpdatedOn = DateTime.Now;
                    comment.Post = _Posts.FirstOrDefault(p => p.ID == postID);
                    ApplicationManager.Entities.AddToPostComments(comment);
                    ApplicationManager.Entities.SaveChanges();
                    ApplicationManager.UpdateCacheData<Data.PostComment>(ApplicationManager.Entities.PostComments);
                   // ApplicationManager.UpdateCacheData<Data.Category>(ApplicationManager.Entities.Categories);
                }
                else return string.Format("{0}", "Captcha không hợp lệ.");
            }
            catch (Exception)
            {
                return string.Format("{0}", "Không thể thêm bình luận của bạn.");
            }

            return string.Format("{0}", "Bình luận của bạn đã được gởi và chờ kiểm duyệt.");
        }

        #endregion

        #region Weather
        [WebMethod]
        //get weather from yahoo
        public string GetWeather(string Zipcode)
        {
            string query = String.Format("http://weather.yahooapis.com/forecastrss?w=" + Zipcode);
            XDocument thisDoc = XDocument.Load(query);
            XNamespace ns = "http://xml.weather.yahoo.com/ns/rss/1.0";
            var condition = (from i in thisDoc.Descendants(ns + "condition") select i);
            var atmosphere = (from i in thisDoc.Descendants(ns + "atmosphere") select i);

            var html = new System.Text.StringBuilder();
            string code = "";
            string codeName = "";
            string humidity = "";
            string temp = "";
            foreach (var c in condition)
            {
                code = c.Attribute("code").Value;
                codeName = skyStatus[int.Parse(code) == 3200 ? 48 : int.Parse(code)];
            }

            foreach (var c in condition)
            {
                int tempF = 0;
                temp = c.Attribute("temp").Value;
                int.TryParse(temp, out tempF);
                //(°F – 32) / 1.8
                temp = Math.Round(((tempF - 32) / 1.8), 1).ToString();
            }

            foreach (var h in atmosphere)
            {
                humidity = h.Attribute("humidity").Value;
            }
            html.AppendFormat("<table class=\"ui-table align-left\" style=\"margin:10px 0;\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr class='ui-widget-header'><td ><b>{3}</b></td><td ><img src=\"http://l.yimg.com/a/i/us/we/52/{4}.gif\"/></td></tr><tr><td>Nhiệt độ</td><td>{0}<sup>o</sup>C</td></tr><tr class='even'><td >Độ ẩm</td><td>{1}%</td></tr><tr><td>Gió đông tốc độ</td><td>{2} m/s</td></tr></table>", temp, humidity, 7, codeName, code);

            return html.ToString();
        }
        #endregion

        #region Ads
        [WebMethod]
        public string load_pletAdsList(string AdsCatName,int pageindex, bool isSearchByDate, string searchDate, string locationID)
        {
            string[] array = checkCateID_By_SEONAME(AdsCatName).Split('$');
            int cateID=int.Parse(array[0]);
            var html = new System.Text.StringBuilder();
            //clone 1 anynomous List<>
            var Datasource=_AdPosts.Select(p => new
                    {
                        p.ID,
                        p.Title,
                        p.Content,
                        p.Avatar,
                        p.SeoUrl,
                        p.UpdatedOn,
                        p.Payment,
                        isFree = p.Payment <= 0 ? true : false,
                        p.Location 
                    }).Take(0).ToList();
            Datasource.Clear();
            //end clone

            //general IQueryable
            var DataQ = _AdPosts
                    .Where(p => p.Category.ID == cateID || (p.Category.Parent != null && p.Category.Parent.ID == cateID
                        && p.Actived == true));//&& p.ExpiredOn>=DateTime.Today //expired sau nay se dung
            //return List<> by Search Result
            //1: condition:search by date
            if (isSearchByDate)
            {
                DateTime inputSearchDateTime = Convert.ToDateTime(searchDate.Replace('_', '/'));
                Datasource = DataQ.Where(p => p.UpdatedOn.Day == inputSearchDateTime.Day && p.UpdatedOn.Month == inputSearchDateTime.Month &&
                    p.UpdatedOn.Year == inputSearchDateTime.Year
                    && p.Location == locationID).Select(p => new
                {
                    p.ID,
                    p.Title,
                    p.Content,
                    p.Avatar,
                    p.SeoUrl,
                    p.UpdatedOn,
                    p.Payment,
                    isFree = p.Payment <= 0 ? true : false,
                    p.Location 
                }).OrderByDescending(p => p.Payment).ToList();
                //Search by date not paging
            }
                //2: search by location
            else
            {
                //search by location (location in one page) if location is not 'Toan Quoc' (id=0)
                if (int.Parse(locationID) >= 1)
                {
                    DataQ = DataQ.Where(p => p.Location == locationID);
                }
                // search all (in one page) 
                Datasource = DataQ.Select(p => new
                {
                    p.ID,
                    p.Title,
                    p.Content,
                    p.Avatar,
                    p.SeoUrl,
                    p.UpdatedOn,
                    p.Payment,
                    isFree = p.Payment <= 0 ? true : false,
                    p.Location 
                }).OrderByDescending(p => p.Payment).Skip(pageindex * 20).Take(20).ToList();
            }
            //generate result
            if (Datasource.Count >= 1)
            {
                int index = 0;
                html.AppendLine("<tr class='ui-widget-header'><th style='text-align:left;'>Tin rao vặt</th><th style='text-align:left;'>Ngày đăng</th><th style='text-align:left;'>Phạm vi</th></tr>");
                foreach (var itemAds in Datasource)
                {
//                    Type itemType = itemAds.GetType();
                    if (index % 2 != 0)
                        html.AppendLine("<tr class='even'>");
                    else
                        html.AppendLine("<tr>");

                    html.AppendLine("<td>");
                    html.AppendFormat("<a {0} href='{1}'>", itemAds.isFree ? "" : "style='font-weight: bold;'",HostName+ itemAds.SeoUrl.ToString() + ".aspx" );
                    html.AppendLine( itemAds.Title + "</a>");
                    html.AppendLine("</td><td >");
                    html.AppendLine(string.Format("{0:dd/MM/yyyy}", itemAds.UpdatedOn));
                    html.AppendLine("</td>");
                    html.AppendLine("</td><td style=\"width:100px;\">");
                    html.AppendLine(Utils.clsCommon.getLocationName(int.Parse(itemAds.Location)));
                    html.AppendLine("</td>");
                    html.AppendLine("</tr>");
                    index++;
                }
            }
            else
            {
                html.AppendLine("<tr class='ui-widget-header'><th style=\"text-align:left;\">Tin rao vặt</th><th style=\"text-align:left;\">Ngày đăng</th><th style='text-align:left; widht:100px;'>Phạm vi</th></tr><tr><td colspan='3' ><div style='text-align: center; padding-top: 6px;'><span>Không tìm thấy bài viết</span></div></td></tr>");
            }
            return html.ToString();
        }
        [WebMethod]
        public string getAdsByAdsCat(string AdsCatName)
        {
            try
            {
                string[] array = checkCateID_By_SEONAME(AdsCatName).Split('$');
                int catID = int.Parse(array[0]);
                var data = _AdPosts.Where(p => p.Category.ID == catID || (p.Category.Parent != null && p.Category.Parent.ID == catID))
                        .Select(p => new
                        {
                           Name= p.Category.Name,
                            p.ID,
                            p.Title,
                            p.Content,
                            p.Avatar,
                            p.SeoUrl,
                            p.UpdatedOn,
                            p.Payment,
                            isFree = p.Payment <= 0 ? true : false,
                            p.Location
                        }).OrderByDescending(p => p.Payment).Take(20).ToList();
                var html = new System.Text.StringBuilder();

                if (data.Count() >= 1)
                {
                    int index = 0;
                    foreach (var itemAds in data)
                    {
                        html.AppendLine("<tbody>");
                        if (index % 2 == 0)
                            html.AppendLine("<tr class='even'>");
                        else
                            html.AppendLine("<tr>");
                        html.AppendLine("<td style='width: 220px;'>");
                        html.AppendFormat("<a {0} href='{1}'>", itemAds.isFree ? "" : "style='font-weight: bold;'", HostName +  itemAds.SeoUrl.ToString() + ".aspx");
                        html.AppendLine(itemAds.Title + "</a>");
                        html.AppendLine("</td><td>");
                        html.AppendLine(string.Format("{0:dd/MM/yyyy}", itemAds.UpdatedOn));
                        html.AppendLine("</td>");
                        html.AppendLine("<td style='width: 120px;'>" + Utils.clsCommon.getLocationName(int.Parse(itemAds.Location)) + "</td>");
                        html.AppendLine("</tr>");
                        html.AppendLine("</tbody>");
                        index++;
                    }
                }
                else
                {
                    html.AppendLine("<div style='text-align: center; padding-top: 6px;'><span>Không tìm thấy bài viết</span></div>");
                }
                return html.ToString();
            }
            catch (Exception)
            {

                return "";
            }
        }
        //check and set Ads CateID , Ads CateTitle
        private string checkCateID_By_SEONAME(string seoNAME)
        {
            var cate = _AdCategories.Where(c => c.SeoName == seoNAME && c.Actived == true).Select(c => new { c.ID, c.Name }).ToList();
            if (cate.Count() > 0)
            {
                return cate[0].ID.ToString() + "$" + cate[0].Name;
            }
            else
                return "-1$";
        }
        #endregion
    }
}

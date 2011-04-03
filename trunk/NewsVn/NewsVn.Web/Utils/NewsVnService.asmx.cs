using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using System.Xml.Linq;
using NewsVn.Core.Caching;

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
                postComments = postComments.OrderBy(c => c.CreatedOn).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            else
                postComments = postComments.OrderByDescending(c => c.CreatedOn).Skip(pageSize * (pageIndex - 1)).Take(pageSize);

            var html = new StringBuilder();

            foreach (var comment in postComments)
            {
                html.AppendFormat("<li><b>{0}</b><p>{1}</p><i>({2})</i></li>", comment.Title, comment.Content, comment.CreatedBy);
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
                    comment.CreatedOn = DateTime.Now;
                    comment.Post = _Posts.FirstOrDefault(p => p.ID == postID);
                    ApplicationManager.Entities.AddToPostComments(comment);
                    ApplicationManager.Entities.SaveChanges();
                    ApplicationManager.UpdateCacheData<Data.PostComment>(ApplicationManager.Entities.PostComments);
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
            html.AppendFormat("<table class=\"ui-table align-left\" style=\"margin:10px 0;\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td ><b>{3}</b></td><td ><img src=\"http://l.yimg.com/a/i/us/we/52/{4}.gif\"/></td></tr><tr><td>Nhiệt độ</td><td>{0}<sup>o</sup>C</td></tr><tr><td>Độ ẩm</td><td>{1}%</td></tr><tr><td>Gió đông tốc độ</td><td>{2} m/s</td></tr></table>", temp, humidity, 7, codeName, code);

            return html.ToString();
        }
        #endregion
    }
}

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
    }
}

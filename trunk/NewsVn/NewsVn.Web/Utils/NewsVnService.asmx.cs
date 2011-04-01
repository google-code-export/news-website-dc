using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;

namespace NewsVn.Web.Utils
{
    /// <summary>
    /// Summary description for NewsVnService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
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

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules
{
    public partial class CommentBox : System.Web.UI.UserControl
    {        
        //void load_Comments()
        //{
        //    var commentData = ApplicationManager.Entities.PostComments.ToList().Where(pc=>pc.Post.ID==PostID).Select(
        //        pc => new { 
        //        pc.CreatedOn,
        //        pc.Content,
        //        pc.Title,
        //        pc.CreatedBy,
        //        }).OrderByDescending(pc => pc.CreatedOn).ToList();
        //    lsvComment.DataSource = Datasource;
        //    lsvComment.DataBind();
        //}
    }
}
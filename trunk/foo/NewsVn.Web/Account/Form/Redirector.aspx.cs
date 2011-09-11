using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace NewsVn.Web.Account.Form
{
    public partial class Redirector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var root = XElement.Load(Server.MapPath("~/Config/RolesRedirect.xml"));
                var roleList = root.Elements("role").Select(c => new
                {
                    Name = c.Attribute("name").Value,
                    DefaultUrl = c.Element("default-url").Value
                });
                
                var currentRole = roleList.FirstOrDefault(r => User.IsInRole(r.Name));
                
                if (currentRole != null)
                {
                    Response.Redirect(currentRole.DefaultUrl);
                }
                else
                {
                    throw new HttpException(404, "Không tìm thấy trang quản trị!");
                }
            }
        }
    }
}
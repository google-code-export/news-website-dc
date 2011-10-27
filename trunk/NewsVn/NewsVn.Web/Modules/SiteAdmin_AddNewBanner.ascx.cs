using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Web.Utils;
using NewsVn.Impl.Context;

namespace NewsVn.Web.Modules
{
    public partial class SiteAdmin_AddNewBanner : BaseUI.SecuredModule
    {
        int intPositionID;
        int intTypeID;
        protected void Page_Load(object sender, EventArgs e)
        {
            intPositionID = int.Parse( Request.QueryString["pid"]);
            intTypeID = int.Parse(Request.QueryString["tid"]);
            if (!IsPostBack)
            {
                txtPosition.Text = ApplicationKeyValueRef.GetKeyValue("Dropdown.BannerPosition", intPositionID.ToString());
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    var bannerdtl = new Impl.Entity.BannerDetail 
                    {
                        BannerID= intPositionID, 
                        Width = int.Parse(txtWidth.Text),
                        Height = int.Parse(txtHeight.Text),
                        Title= txtTitle.Text,
                        Url=txtUrl.Text
                    };

                    ctx.BannerDetailRepo.Setter.addOne(bannerdtl);

                    ctx.SubmitChanges();

                    Response.Redirect(HostName + "account/siteadmin/misc/editadpostposition.aspx?pid=" + intPositionID + "&tid=" + intTypeID);
                }
            }
            catch
            {
            }
        }
    }
}
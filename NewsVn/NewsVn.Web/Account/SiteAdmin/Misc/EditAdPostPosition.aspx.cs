using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Account.SiteAdmin.Misc
{
    public partial class EditAdPostPosition : BaseUI.SecuredPage
    {
        int intPositionID;
        int intTypeID;
        public string bannerPosition = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            SiteTitle += "";
            
            intPositionID = int.Parse(Request.QueryString["pid"]);
            intTypeID = int.Parse(Request.QueryString["tid"]);
            bannerPosition = ApplicationKeyValueRef.GetKeyValue("Dropdown.BannerPosition", intPositionID.ToString());
            if (!IsPostBack)
            {
                loadPositionBannerDetail();
                loadDdlBannerType();
            }
        }

        int bannerCount = 0;

        void loadPositionBannerDetail()
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                var BannerLists = ctx.BannerDetailRepo.Getter.getQueryable (c => c.BannerID == intPositionID)
                .Select(c => new
                {
                    c.ID,
                    c.Height,
                    c.Width,
                    c.Title,
                    c.Url,
                    c.BannerID,
                    BannerPosition = ApplicationKeyValueRef.GetKeyValue("Dropdown.BannerPosition", c.BannerID.ToString())
                });

                rptCurrentBannerList.DataSource = BannerLists;
                rptCurrentBannerList.DataBind();
                bannerCount = BannerLists.Count();
            }
        }

        void loadDdlBannerType()
        {
            ApplicationKeyValueRef.BindingDataToComboBox(ddlBannerType, "Dropdown.BannerType");
            ddlBannerType.SelectedIndex = intTypeID - 1;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra số lượng banner hiện tại so với loại banner đã chọn -> thông báo cập nhật thêm banner hoặc xóa bớt cho phù hợp.
                if (rptCurrentBannerList.Items.Count != int.Parse(ddlBannerType.SelectedValue))
                {
                    Response.Write("vui lòng cập nhật số lượng banner trùng với loại banner đã chọn");
                }
                else
                {
                    using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                    {
                        var updBanner = ctx.BannerRepo.Getter.getOne(c => c.PositionID == intPositionID);

                        if (updBanner != null)
                        {
                            updBanner.TypeID = int.Parse(ddlBannerType.SelectedValue);
                            ctx.SubmitChanges();
                        }
                    }
                }
            }
            catch
            {

            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect(HostName + "account/siteadmin/misc/AddNewBanner.aspx?pid=" + intPositionID + "&tid=" + intTypeID);
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    int ID = int.Parse(hidDel.Value);
                    var BannerDetail = ctx.BannerDetailRepo.Getter.getOne(c => c.ID == ID);
                    ctx.BannerDetailRepo.Setter.deleteOne(BannerDetail);
                    ctx.SubmitChanges();
                }
                loadPositionBannerDetail();
            }
            catch
            {
                
            }
        }
        protected void rptCurrentBannerList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            //OnClientClick="javascript:return ConfirmDelete('"+<%#Eval("ID") %>+"');"
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                LinkButton lnkbtnDelete = new LinkButton();
                lnkbtnDelete = (LinkButton)e.Item.FindControl("lbtnDel");
                lnkbtnDelete.Attributes.Add("onclick", "return ConfirmDelete('" + DataBinder.Eval(e.Item.DataItem, "ID").ToString() + "');");
            }
        }
        
    }
}
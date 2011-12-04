using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Account.SiteAdmin.Misc
{
    public partial class ViewAdBox : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteTitle += "Quản lý Banner quảng cáo";

            if (!IsPostBack )
            {
                loadBannerPositionList();
                loadCurrentBannerList(); 
            }
        }
        protected void loadCurrentBannerList()
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                var BannerLists = ctx.BannerDetailRepo.Getter.getQueryable()
                .Select(c=>new{
                c.ID ,
                c.Height,
                c.Width,
                c.Title,
                c.Url,
                c.BannerID,
                BannerPosition= ApplicationKeyValueRef.GetKeyValue("Dropdown.BannerPosition",c.BannerID.ToString())
                }) ;
                
                rptCurrentBannerList.DataSource = BannerLists;
                rptCurrentBannerList.DataBind();
            }
        }
        

        protected void loadBannerPositionList()
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                var BannerPositionLists = ctx.BannerRepo.Getter.getQueryable()
                    .Select(
                    c => new
                    {
                        c.PositionID,
                        c.TypeID,
                        bannerPosition = ApplicationKeyValueRef.GetKeyValue("Dropdown.BannerPosition", c.PositionID.ToString()),
                        bannerType = ApplicationKeyValueRef.GetKeyValue("Dropdown.BannerType", c.TypeID.ToString()),
                    }
                    );
                rptBannerPositon.DataSource = BannerPositionLists;
                rptBannerPositon.DataBind();
            }
        }

        protected void lnkbtnDel_Click(object sender, EventArgs e)
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                int ID = int.Parse(hidDel.Value);
                var BannerDetail = ctx.BannerDetailRepo.Getter.getOne(c => c.ID == ID);
                ctx.BannerDetailRepo.Setter.deleteOne(BannerDetail);
                ctx.SubmitChanges();
            }
            loadBannerPositionList();
            loadCurrentBannerList(); 
        }

        protected void rptCurrentBannerList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            //OnClientClick="javascript:return ConfirmDelete('"+<%#Eval("ID") %>+"');"
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                LinkButton lnkbtnDelete = new LinkButton();
                lnkbtnDelete = (LinkButton)e.Item.FindControl("lnkbtnDel");
                //ScriptManager sm = System.Web.UI.ScriptManager.GetCurrent(this.Page);
                //sm.RegisterAsyncPostBackControl(lnkbtnDelete);
                lnkbtnDelete.Attributes.Add("onclick", "return ConfirmDelete('" + DataBinder.Eval(e.Item.DataItem, "ID").ToString() + "');");
            }
        }
    }
}
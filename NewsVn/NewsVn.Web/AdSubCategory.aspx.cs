using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using NewsVn.Impl.Context;

namespace NewsVn.Web
{
    public partial class AdSubCategory : BaseUI.BasePage
    {
        private int intCateID = -1;
        private string CateTitle = "Rao Nhanh";

        //check and set Ads CateID , Ads CateTitle
        private bool checkCateID_By_SEONAME(string seoNAME, NewsVnContext ctx)
        {
            var _AdCategories = ctx.CategoryRepo.Getter.getQueryable(c => c.Type == "adpost" && c.Actived == true);
            var cate = _AdCategories.Where(c => c.SeoName == seoNAME && c.Actived == true).Select(c => new { c.ID, c.Name, c.Parent }).ToList();
            if (cate.Count() > 0)
            {
                intCateID = cate[0].ID;
                this.CateTitle = (cate[0].Parent == null ? "" : cate[0].Parent.Name + " - ") + cate[0].Name;
                return true;
            }
            else
                return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    checkCateID_By_SEONAME(Request.QueryString["ct"].ToString(), ctx);
                    SiteTitle += "RAO NHANH - " + (intCateID == -1 ? "Mua bán nhà đất, điện thoại, máy tính, ô tô xe máy, dịch vụ" : CateTitle);
                    MetaKeyWords = "newsvn, newsvn.vn, rao vặt,mua,bán,thuê,cho thuê,thiết bị,văn phòng,điện tử,điện lạnh,ô tô,xe máy,sửa chữa,lắp đặt,thiết kế,nội thất,xây dựng,máy móc,tìm đối tác,cơ hội kinh doanh,hàng hoá,mua sắm,siêu thị,tiêu dùng,sản xuất,rao mua,rao bán,rao vat,mua ban,thue,cho thue,thiet bi,van phong,dien tu,dien lanh,o to,xe may,sua chua,lap dat,thiet ke,noi that,xay dung,may moc,tim doi tac,co hoi kinh doanh,hang hoa,mua sam,sieu thi,tieu dung,san xuat,rao mua,rao ban, sale off, khuyen mai, gia re";
                    MetaKeyDes = "Newsvn, Thông tin rao vặt, " + CateTitle;
                    DateTime searchDate = DateTime.Now;
                    int pageindex = 0;
                    int.TryParse(Request.QueryString["p"], out pageindex);
                    if (Request.QueryString["d"] != null && DateTime.TryParse(Request.QueryString["d"].Replace('_', '/'), out searchDate))
                    {
                        load_pletAdsList(pageindex, true, ctx);
                    }
                    else
                    {
                        load_pletAdsList(pageindex, false, ctx);
                    }
                    bindBannerRight(ctx);
                }
            }
        }

        //Load List Ads by Ads Category
        private void load_pletAdsList(int pageindex, bool isSearchByDate, NewsVnContext ctx)
        {
            var _AdPosts = ctx.AdPostRepo.Getter.getQueryable(a => a.Actived == true);
            if (isSearchByDate)
            {
                var date = DateTime.Parse(Request.QueryString["d"].Replace('_', '/'));
                pletCatAdsPost.Datasource = _AdPosts.Where(p => p.CategoryID == intCateID || (p.Category.Parent != null && p.Category.ParentID == intCateID))
                    .Where(p => p.CreatedOn.Day == date.Day && p.CreatedOn.Month == date.Month && p.CreatedOn.Year == date.Year)
                    .Select(p => new
                    {
                        p.ID,
                        p.Title,
                        p.Content,
                        p.Avatar,
                        p.SeoUrl,
                        p.CreatedOn,
                        p.Payment,
                        isFree = p.Payment <= 0 ? true : false,
                        p.Location// = Utils.clsCommon.getLocationName(int.Parse(p.Location))
                    }).OrderByDescending(p => p.Payment).ThenByDescending(p => p.CreatedOn).ToList();
                pletCatAdsPost.CateTitle = CateTitle;//bind Ads CateTitle
                pletCatAdsPost.HostName = this.HostName;
            }
            else
            {
                pletCatAdsPost.Datasource = _AdPosts.Where(p => p.CategoryID == intCateID || (p.Category.Parent != null && p.Category.ParentID == intCateID))
                    .Select(p => new
                    {
                        p.ID,
                        p.Title,
                        p.Content,
                        p.Avatar,
                        p.SeoUrl,
                        p.CreatedOn,
                        p.Payment,
                        isFree = p.Payment <= 0 ? true : false,
                        p.Location// = Utils.clsCommon.getLocationName(int.Parse(p.Location))
                    }).OrderByDescending(p => p.Payment).ThenByDescending(p => p.CreatedOn).Skip(pageindex * 20).Take(20).ToList();
                pletCatAdsPost.CateTitle = CateTitle;//bind Ads CateTitle
                pletCatAdsPost.HostName = this.HostName;
            }
            pletCatAdsPost.DataBind();
        }

        void bindBannerRight(NewsVnContext ctx)
        {
            var bannerRightListID = ctx.BannerDetailRepo.Getter.getQueryable(c => c.Activated && c.TypePosition == 2).Select(c => c.ID).ToArray();
            if (bannerRightListID.Length >= 1)
            {   //lay random 1 list right banner
                var lstID = new List<int>();
                for (int i = 0; i <= (bannerRightListID.Length < 5 ? bannerRightListID.Length - 1 : 5); i++)
                {
                    if (bannerRightListID.Length <= 5)
                    {
                        for (int j = 0; j <= bannerRightListID.Length - 1; j++)
                        {
                            lstID.Add(bannerRightListID[j]);
                        }
                        break;
                    }
                    var randon = new Random();
                    int _randomIndex = randon.Next(0, bannerRightListID.Length - 1);
                    if (!lstID.Contains(bannerRightListID[_randomIndex]))
                    {
                        lstID.Add(bannerRightListID[_randomIndex]);
                    }
                }
                Control UC_PortletAdPost = LoadControl("~/Modules/AdBoxList.ascx");
                var bannerRightLists = ctx.BannerDetailRepo.Getter.getQueryable(a => lstID.Contains(a.ID)).OrderByDescending(a => a.Price).ToList();
                var _AdBoxList1 = ((Modules.AdBoxList)UC_PortletAdPost);
                _AdBoxList1.Datasource = bannerRightLists;
                _AdBoxList1.DataBind();
                adboxArea.Controls.Add(_AdBoxList1);
            }
        }
    }
}
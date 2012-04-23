using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using NewsVn.Impl.Context;

namespace NewsVn.Web
{
    public partial class AdCategory : BaseUI.BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            SiteTitle += "RAO NHANH - Mua bán nhà đất, điện thoại, máy tính, ô tô xe máy, dịch vụ";
            MetaKeyWords = "newsvn, rao vặt,mua,bán,thuê,cho thuê,thiết bị,văn phòng,điện tử,điện lạnh,ô tô,xe máy,sửa chữa,lắp đặt,thiết kế,nội thất,xây dựng,máy móc,tìm đối tác,cơ hội kinh doanh,hàng hoá,mua sắm,siêu thị,tiêu dùng,sản xuất,rao mua,rao bán,rao vat,mua ban,thue,cho thue,thiet bi,van phong,dien tu,dien lanh,o to,xe may,sua chua,lap dat,thiet ke,noi that,xay dung,may moc,tim doi tac,co hoi kinh doanh,hang hoa,mua sam,sieu thi,tieu dung,san xuat,rao mua,rao ban, sale off, khuyen mai, gia re";
            MetaKeyDes = "Newsvn, Cổng thông tin điện tử - Thông tin rao vặt, Đăng ký rao vặt miễn phí, mua bán nhiều lĩnh vực khác nhau như BĐS nhà đất, điện tử điện lạnh, máy tính, điện thoại, dịch vụ";
            hidHostName.Value = HostName;            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    load_SpecialAds(ctx);
                    load_pletAdPosts(ctx);
                    bindBannerRight(ctx);
                }                
            }
        }

        //load special ads (top payment rate)
        private void load_SpecialAds(NewsVnContext ctx)
        {
            //hien tai chua co set expired : p.ExpiredOn >= DateTime.Now &&
            var _AdPosts = ctx.AdPostRepo.Getter.getQueryable(p => p.Actived == true);
            var datasource = _AdPosts
                .Select(p => new
                {
                    p.Category.Name,
                    Avatar = HostName +  p.Avatar,
                    p.Title,
                    p.Content,//=Utils.clsCommon.hintDesc(p.Content,200),
                    p.Payment,
                    p.Location,// = Utils.clsCommon.getLocationName(int.Parse( p.Location)),
                    p.SeoUrl,
                    p.CreatedBy,
                    p.CreatedOn
                }).OrderByDescending(p => p.Payment).Take(5).ToList();
            pletSpecialAds.Datasource = datasource;
            pletSpecialAds.DataBind();
        }

        private void load_pletAdPosts(NewsVnContext ctx)
        {
            int indexArea = 0;
            var _AdCategories = ctx.CategoryRepo.Getter.getQueryable(c => c.Type == "adpost" && c.Actived == true);
            var _AdPosts = ctx.AdPostRepo.Getter.getQueryable(a => a.Actived == true);

            for (int i = 0; i < _AdCategories.Count(); i++)
            {
                var cate = _AdCategories.AsEnumerable().ElementAt(i);
            
                if (cate.Parent != null)
                {
                    continue;
                }
                Control UC_PortletAdPost = LoadControl("~/Modules/AdPostsPortlet.ascx");
                var ctrPortletPost = ((Modules.AdPostsPortlet)UC_PortletAdPost);
                ctrPortletPost.Title = cate.Name;
                ctrPortletPost.SeoName = cate.SeoName;
                ctrPortletPost.SeoUrl = cate.SeoUrl;
                ctrPortletPost.indexCtrl = i.ToString();
                //set position
                if (indexArea % 2 == 0)
                    ctrPortletPost.CssClass = "left";
                else
                {
                    ctrPortletPost.CssClass = "right";
                    ctrPortletPost.ClearLayout = true;
                }

                ctrPortletPost.Datasource = _AdPosts
                    .Where(p => p.CategoryID == cate.ID || (p.Category.Parent != null && p.Category.ParentID == cate.ID))
                    .Select(p => new
                    {
                        p.ID,
                        p.Title,
                        p.Content,
                        p.Avatar,
                        SeoUrl = HostName + p.SeoUrl,
                        p.CreatedOn,
                        p.Payment,
                        isFree = p.Payment <= 0 ? true : false,
                        p.Location //= Utils.clsCommon.getLocationName(int.Parse(p.Location)),
                    }).OrderByDescending(p => p.Payment).ThenByDescending(p=>p.CreatedOn).Take(20).ToList();
                //bind subCategory
                ctrPortletPost.subDatasource = _AdCategories.Where(p => (p.Parent != null && p.ParentID == cate.ID) && cate.Actived == true)
                    .Select(p => new
                    {
                        p.ID,
                        p.Name,
                        p.SeoName,
                        SeoUrlSearch = p.SeoUrl,
                        SeoUrl = HostName + p.SeoUrl,
                    }).ToList();
                //bind control
                ctrPortletPost.DataBind();
                AdPostArea.Controls.Add(ctrPortletPost);
                indexArea += 1;
            }
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
            }
        }
    }
}
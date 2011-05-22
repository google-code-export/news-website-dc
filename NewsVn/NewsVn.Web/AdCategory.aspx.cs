using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web
{
    public partial class AdCategory : BaseUI.BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            BaseUI.BaseMaster.SiteTitle = "- RAO NHANH - Mua bán nhà đất, điện thoại, máy tính, ô tô xe máy, dịch vụ";
            BaseUI.BaseMaster.MetaKeyWords = "rao vặt,mua,bán,thuê,cho thuê,thiết bị,văn phòng,điện tử,điện lạnh,ô tô,xe máy,sửa chữa,lắp đặt,thiết kế,nội thất,xây dựng,máy móc,tìm đối tác,cơ hội kinh doanh,hàng hoá,mua sắm,siêu thị,tiêu dùng,sản xuất,rao mua,rao bán,rao vat,mua ban,thue,cho thue,thiet bi,van phong,dien tu,dien lanh,o to,xe may,sua chua,lap dat,thiet ke,noi that,xay dung,may moc,tim doi tac,co hoi kinh doanh,hang hoa,mua sam,sieu thi,tieu dung,san xuat,rao mua,rao ban, sale off, khuyen mai, gia re";
            BaseUI.BaseMaster.MetaKeyDes = "Cổng thông tin điện tử - Thông tin rao vặt, Đăng ký rao vặt miễn phí, mua bán nhiều lĩnh vực khác nhau như BĐS nhà đất, điện tử điện lạnh, máy tính, điện thoại, dịch vụ";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_SpecialAds();
                load_pletAdPosts();
            }
        }
        //load special ads (top payment rate)
        private void load_SpecialAds()
        {
            //hien tai chua co set expired : p.ExpiredOn >= DateTime.Now &&
            var datasource = _AdPosts.Where(p => p.AdCategory.Actived == true && p.Actived == true)
                .Select(p => new
                {
                    p.AdCategory.Name,
                    Avatar=HostName +"/Resources/"+ p.Avatar,
                    p.Title,
                    p.Content,//=Utils.clsCommon.hintDesc(p.Content,200),
                    p.Payment,
                    p.Location,// = Utils.clsCommon.getLocationName(int.Parse( p.Location)),
                    p.SeoUrl,
                    p.CreatedBy,
                    p.CreatedOn
                }).OrderByDescending(p=>p.Payment).Take(5).ToList();
            
            
            pletSpecialAds.Datasource = datasource;
            pletSpecialAds.DataBind();
        }
        private void load_pletAdPosts()
        {
            int indexArea = 0;
            for (int i = 0; i < _AdCategories.Count(); i++)
            {
                var cate = _AdCategories.ElementAt(i);
                Control UC_PortletAdPost = LoadControl("~/Modules/AdPostsPortlet.ascx");
                var ctrPortletPost = ((Modules.AdPostsPortlet)UC_PortletAdPost);
                ctrPortletPost.Title = cate.Name;
                ctrPortletPost.SeoName = cate.SeoName;
                ctrPortletPost.SeoUrl = cate.SeoUrl;
                ctrPortletPost.indexCtrl = i.ToString();
                if (cate.Parent != null)
                {
                    continue;
                }
                //set position
                if (indexArea % 2 == 0)
                    ctrPortletPost.CssClass = "left";
                else
                {
                    ctrPortletPost.CssClass = "right";
                    ctrPortletPost.ClearLayout = true;
                }
                ctrPortletPost.Datasource = _AdPosts
                    .Where(p => p.AdCategory.ID == cate.ID || (p.AdCategory.Parent != null && p.AdCategory.Parent.ID == cate.ID) && cate.Actived == true)
                    .Select(p => new
                    {
                        p.ID,
                        p.Title,
                        p.Content,
                        p.Avatar,
                        SeoUrl=HostName+ p.SeoUrl,
                        p.CreatedOn,
                        p.Payment,
                        isFree = p.Payment <= 0 ? true : false,
                        p.Location //= Utils.clsCommon.getLocationName(int.Parse(p.Location)),
                    }).OrderByDescending(p => p.Payment).Take(20).ToList();
                //bind subCategory
                ctrPortletPost.subDatasource = _AdCategories.Where(p =>(p.Parent != null && p.Parent.ID == cate.ID) && cate.Actived == true)
                    .Select(p => new
                    {
                        p.ID,
                        p.Name,
                        p.SeoName,
                        SeoUrl = HostName + p.SeoUrl,
                    }).ToList();
                //bind control
                ctrPortletPost.DataBind();
                AdPostArea.Controls.Add(ctrPortletPost);
                indexArea += 1;
            }
        }
    }
}
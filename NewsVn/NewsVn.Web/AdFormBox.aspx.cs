using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using NewsVn.Impl.Context;

namespace NewsVn.Web
{
    public partial class AdFormBox : BaseUI.BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            SiteTitle += "Đăng Ký Rao Nhanh";
            MetaKeyWords = "newsvn, rao vặt,mua,bán,thuê,cho thuê,thiết bị,văn phòng,điện tử,điện lạnh,ô tô,xe máy,sửa chữa,lắp đặt,thiết kế,nội thất,xây dựng,máy móc,tìm đối tác,cơ hội kinh doanh,hàng hoá,mua sắm,siêu thị,tiêu dùng,sản xuất,rao mua,rao bán,rao vat,mua ban,thue,cho thue,thiet bi,van phong,dien tu,dien lanh,o to,xe may,sua chua,lap dat,thiet ke,noi that,xay dung,may moc,tim doi tac,co hoi kinh doanh,hang hoa,mua sam,sieu thi,tieu dung,san xuat,rao mua,rao ban, sale off, khuyen mai, gia re";
            MetaKeyDes = "Newsvn, Cổng thông tin điện tử - Đăng ký rao vặt miễn phí, đăng tin vip, mua bán nhiều lĩnh vực khác nhau như BĐS nhà đất, điện tử điện lạnh, máy tính, điện thoại, dịch vụ";            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindBannerRight();
            }
        }

        void bindBannerRight()
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
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
}
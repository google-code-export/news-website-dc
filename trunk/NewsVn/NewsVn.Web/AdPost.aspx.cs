using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web
{
    public partial class AdPost : BaseUI.BasePage   
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int AdsID = 0;
                int.TryParse(Request.QueryString["cp"],out AdsID);
                load_pletAdsDetail(AdsID);
            }
        }
        //load Ads details by ID
        private void load_pletAdsDetail(int AdsID)
        {
            var datafilter = _AdPosts.Where(p => p.ID == AdsID && p.Actived == true);// && p.ExpiredOn >= DateTime.Now
                    

            if (datafilter != null)
            {
                var data = datafilter.Select(p => new
                {
                    p.ID,
                    p.Title,
                    p.Content,
                    p.Avatar,
                    p.SeoUrl,
                    p.CreatedOn,
                    p.CreatedBy,
                    p.Location //= Utils.clsCommon.getLocationName(int.Parse(p.Location))
                }).FirstOrDefault();
                pletAdsDetail.AdsTitle = data.Title;
                pletAdsDetail.AdsContent = data.Content;
                pletAdsDetail.CreateBy = data.CreatedBy;
                pletAdsDetail.CreatedOn = data.CreatedOn;
                pletAdsDetail.Location = data.Location == null ? 0 : int.Parse(data.Location);
                //Load Ads relation by Created Date and Difference with current ID
                BaseUI.BaseMaster.ExecuteSEO(data.Title.Trim().Length > 0 ?"RAO NHANH - "+ data.Title.Trim() : "RAO NHANH - Mua bán nhà đất, điện thoại, máy tính, ô tô xe máy, dịch vụ", Utils.clsCommon.RemoveUnicodeMarks(data.Title).Replace('-', ' ') + "," + data.Title + "," + Utils.clsCommon.RemoveUnicodeMarks(data.Content).Replace('-', ' '),"Newsvn, "+data.CreatedBy+ " - " + Utils.clsCommon.hintDesc(data.Content, 300));
                load_pletAdsRelated(datafilter.FirstOrDefault());
            }
            else
            {
                pletAdsDetail.AdsTitle = "N/A";
                pletAdsDetail.AdsContent = "Không tìm thấy bài viết";
                pletAdsDetail.CreateBy = "N/A";
                pletAdsDetail.CreatedOn = DateTime.Now;
                BaseUI.BaseMaster.SiteTitle = "- RAO NHANH - Mua bán nhà đất, điện thoại, máy tính, ô tô xe máy, dịch vụ";
                BaseUI.BaseMaster.MetaKeyWords = "newsvn, rao vặt,mua,bán,thuê,cho thuê,thiết bị,văn phòng,điện tử,điện lạnh,ô tô,xe máy,sửa chữa,lắp đặt,thiết kế,nội thất,xây dựng,máy móc,tìm đối tác,cơ hội kinh doanh,hàng hoá,mua sắm,siêu thị,tiêu dùng,sản xuất,rao mua,rao bán,rao vat,mua ban,thue,cho thue,thiet bi,van phong,dien tu,dien lanh,o to,xe may,sua chua,lap dat,thiet ke,noi that,xay dung,may moc,tim doi tac,co hoi kinh doanh,hang hoa,mua sam,sieu thi,tieu dung,san xuat,rao mua,rao ban, sale off, khuyen mai, gia re";
                BaseUI.BaseMaster.MetaKeyDes = "Newsvn, Cổng thông tin điện tử - Thông tin rao vặt, Đăng ký rao vặt miễn phí, mua bán nhiều lĩnh vực khác nhau như BĐS nhà đất, điện tử điện lạnh, máy tính, điện thoại, dịch vụ";
            }
        }

        private void load_pletAdsRelated(Data.AdPost inputAdPost)
        {
            var data = _AdPosts.Where(p => p.ID != inputAdPost.ID && p.Actived == true)// && p.ExpiredOn >= DateTime.Now
                .Where(p => p.UpdatedOn <= inputAdPost.UpdatedOn)
                    .Select(p => new
                    {
                        p.Title,
                        p.SeoUrl,
                        p.UpdatedOn,
                        p.Payment,
                    }).OrderByDescending(p=>p.Payment).ThenByDescending(p=>p.UpdatedOn).Take(15).ToList();
            pletAdsRelated.Datasource = data;
            pletAdsRelated.DataBind();
        }
    }
}
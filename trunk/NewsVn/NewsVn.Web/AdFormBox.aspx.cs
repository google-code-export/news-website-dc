using System;

namespace NewsVn.Web
{
    public partial class AdFormBox : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            BaseUI.BaseMaster.SiteTitle = "- Đăng Ký Rao Nhanh";
            BaseUI.BaseMaster.MetaKeyWords = "newsvn, rao vặt,mua,bán,thuê,cho thuê,thiết bị,văn phòng,điện tử,điện lạnh,ô tô,xe máy,sửa chữa,lắp đặt,thiết kế,nội thất,xây dựng,máy móc,tìm đối tác,cơ hội kinh doanh,hàng hoá,mua sắm,siêu thị,tiêu dùng,sản xuất,rao mua,rao bán,rao vat,mua ban,thue,cho thue,thiet bi,van phong,dien tu,dien lanh,o to,xe may,sua chua,lap dat,thiet ke,noi that,xay dung,may moc,tim doi tac,co hoi kinh doanh,hang hoa,mua sam,sieu thi,tieu dung,san xuat,rao mua,rao ban, sale off, khuyen mai, gia re";
            BaseUI.BaseMaster.MetaKeyDes = "Newsvn, Cổng thông tin điện tử - Đăng ký rao vặt miễn phí, đăng tin vip, mua bán nhiều lĩnh vực khác nhau như BĐS nhà đất, điện tử điện lạnh, máy tính, điện thoại, dịch vụ";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
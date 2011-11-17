using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class BannerControl : BaseUI.SecuredModule
    {
       
        public List<Impl.Entity.BannerDetail> Datasource { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
             //Response.Write(BannerType.ToString());
            if (!IsPostBack)
            {
                adoptBanner();
            }
        }
        void adoptBanner() {
            var _html = new System.Text.StringBuilder();
            foreach (var item in Datasource)
            {
                //kiem tra loai item la gi?: video hay image hay flash de lay control html tuong ung
                //* luu y: homepage chi co banner la flash + image ko co video: image =1, flash = 2, video =3
                if (item.TypeBanner == 1)
                {
                    _html.AppendLine("<a href='" + item.LinkUrl + "' target='_blank' > <img alt=''  width='" + item.Width.ToString() + "' height='" + item.Height.ToString() + "' src='" + item.Url + "' /></a>");
                }
                else if (item.TypeBanner == 2)
                {
                    _html.AppendLine(" <div style=' z-index: -1; top: auto; left: auto; background-color:#ffffff;'>");
                    _html.AppendLine("<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000'  width=" + item.Width.ToString() + " height=" + item.Height.ToString() + " id='movie_name' align='middle'>");

                    _html.AppendLine("<param name='movie' value='" + item.Url + "'/>");
                    _html.AppendLine("<param name='wmode' value='transparent'/>");

                    _html.AppendLine(" <!--[if !IE]>-->");
                    _html.AppendLine(" <object type='application/x-shockwave-flash'  data='" + item.Url + "' width=" + item.Width.ToString() + " height=" + item.Height.ToString() + ">");
                    _html.AppendLine("       <param name='movie' value='" + item.Url + "'/>");
                    _html.AppendLine("       <param name='wmode' value='transparent' />");

                    _html.AppendLine("<!--<![endif]-->");
                    _html.AppendLine("   <a href='http://www.adobe.com/go/getflash'>");
                    _html.AppendLine("        <img src='http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif' alt='Get Adobe Flash player'/>");
                    _html.AppendLine("      </a>");
                    _html.AppendLine("    <!--[if !IE]>-->");
                    _html.AppendLine("  </object>");
                    _html.AppendLine("<!--<![endif]-->");
                    _html.AppendLine("</object>");
                    _html.AppendLine(" </div>");

                }
            }
            divContentAds.InnerHtml += _html;
        }
        //protected override void OnDataBinding(EventArgs e)
        //{
        //    rptBanner.DataSource = Datasource;
        //    rptBanner.DataBind();
        //}
    }
}
﻿using System;
using System.Collections.Generic;

namespace NewsVn.Web.Modules
{
    public partial class AdBoxList : BaseUI.BaseModule
    {
        public List<Impl.Entity.BannerDetail> Datasource { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                adoptBanner();
            }
        }
        void adoptBanner()
        {
            var _html = new System.Text.StringBuilder();
            _html.Append("<br /> <ul class=\"side-part-list\">");

            // CuongNguyen: Add to prevent NULL
            if (Datasource == null)
            {
                Datasource = new List<Impl.Entity.BannerDetail>();
            }

            foreach (var item in Datasource)
            {
                //kiem tra loai item la gi?: video hay image hay flash de lay control html tuong ung
                //* luu y: homepage chi co banner la flash + image ko co video: image =1, flash = 2, video =3
                _html.AppendLine("<li><a href='" + item.LinkUrl + "' target='_blank' rel='nofollow'> <img alt=''  width='" + item.Width.ToString() + "' height='" + item.Height.ToString() + "' src='" + item.Url + "' /></a></li>");
            }
            _html.AppendLine("</ul>");
            divContentAds.InnerHtml += _html;
        }
    }
}
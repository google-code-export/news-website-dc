using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using NewsVn.Web.Utils;

namespace NewsVn.Web.BaseUI
{
    public class BaseModule : System.Web.UI.UserControl
    {
        public string InfoBar { get; set; }
        public string ErrorBar { get; set; }
        public string HostName { get; set; }
        protected string CE_Configuration { get; set; }
        protected IQueryable<Data.Post> _Posts;
        protected IQueryable<Data.Category> _Categories;
        protected IQueryable<Data.Category> _AdCategories;
        protected IQueryable<Data.Category> _VideoCategories;

        protected override void OnInit(EventArgs e)
        {
            var sb = new StringBuilder();
            sb.Append("<li><div class=\"ui-widget\"><div class=\"ui-state-highlight ui-corner-all\" style=\"padding: 0 .7em;\">");
            sb.Append("<p><span class=\"ui-icon ui-icon-info\" style=\"float: left; margin: .15em .3em 0 0;\"></span>");
            sb.Append("<b>Thông báo:</b> {0}</p></div></div></li>");
            InfoBar = sb.ToString();

            sb = new StringBuilder();
            sb.Append("<li><div class=\"ui-widget\"><div class=\"ui-state-error ui-corner-all\" style=\"padding: 0 .7em;\">");
            sb.Append("<p><span class=\"ui-icon ui-icon-alert\" style=\"float: left; margin: .15em .3em 0 0;\"></span>");
            sb.Append("<b>Cảnh báo:</b> {0}</p></div></div></li>");
            ErrorBar = sb.ToString();

            HostName = NewsVn.Web.Utils.ApplicationManager.HostName;

            _Categories = ApplicationManager.Entities.Categories.Where(c => "post".Equals(c.Type, StringComparison.OrdinalIgnoreCase) && c.Actived).ToList().AsQueryable();
            _AdCategories = ApplicationManager.Entities.Categories.Where(c => "ad".Equals(c.Type, StringComparison.OrdinalIgnoreCase) && c.Actived).ToList().AsQueryable();
            _VideoCategories = ApplicationManager.Entities.Categories.Where(c => "video".Equals(c.Type, StringComparison.OrdinalIgnoreCase) && c.Actived).ToList().AsQueryable();

            _Posts = ApplicationManager.Entities.Posts.Where(p => p.Approved && p.Actived && p.Category.Actived).AsQueryable();

            //configure CuteEditor
            CE_Configuration = "InsertChars,InsertTemplate, InsertEmotion,InsertYouTube,Images,Codes,Links,InsertForm , InsertTextBox, InsertInputText,InsertInputPassword,InsertInputhidden,InsertListBox,InsertDropDown,InsertRadioBox,InsertCheckBox,InsertInputImage,InsertInputSubmit,InsertInputReset,InsertInputButton,AbsolutePosition,BringForward,BringBackward,ToggleBorder,DocumentPropertyPage,CssClass,CssStyle,FormatBlock,CleanCode,GroupBox,InsertLayer";
            base.OnInit(e);
        }
    }
}
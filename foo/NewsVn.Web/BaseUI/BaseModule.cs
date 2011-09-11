﻿using System;
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

            //configure CuteEditor
            CE_Configuration = "InsertChars,InsertTemplate, InsertEmotion,InsertYouTube,Images,Codes,Links,InsertForm , InsertTextBox, InsertInputText,InsertInputPassword,InsertInputhidden,InsertListBox,InsertDropDown,InsertRadioBox,InsertCheckBox,InsertInputImage,InsertInputSubmit,InsertInputReset,InsertInputButton,AbsolutePosition,BringForward,BringBackward,ToggleBorder,DocumentPropertyPage,CssClass,CssStyle,FormatBlock,CleanCode,GroupBox,InsertLayer";
            base.OnInit(e);
        }
    }
}
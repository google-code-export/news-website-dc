﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace NewsVn.Web.Utils
{
    public class ApplicationMailing
    {
        private static SmtpClient _smtpClient;

        public enum SendPurpose
        {
            CreateAccount,
            DeleteAccount,
            ChangeApproval,
            ResetPassword
        }

        static ApplicationMailing()
        {
            _smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Timeout = 100000,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("xxx@gmail.com", "xxx"),                
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
        }

        public static bool Send(string[] to, SendPurpose purpose, Dictionary<string, string> args)
        {
            string from = "noreply@homevn.vn";
            return Send(from, to, purpose, args);
        }

        public static bool Send(string from, string[] to, SendPurpose purpose, Dictionary<string, string> args)
        {
            string subject = "[NewsVN - Cổng thông tin điện tử 24/07] ";
            StringBuilder bodySb = new StringBuilder();        

            switch (purpose)
            {
                case SendPurpose.CreateAccount:
                    subject += "Tài khoản mới của bạn được thiết lập";
                    bodySb.Append("<h1>Tài khoản mới của bạn được thiết lập</h1>");
                    bodySb.Append("<p>Website: <b>http://www.newsvn.vn</b></p>");
                    bodySb.AppendFormat("<p>Tài khoản: <b>{0}</b><p>", args["newsvn.account.name"]);
                    bodySb.AppendFormat("<p>Mật khẩu: <b>{0}</b><p>", args["newsvn.account.password"]);
                    bodySb.Append("<p>Vui lòng thay đổi mật khẩu ngay sau khi bạn đăng nhập.</p>");
                    break;
                case SendPurpose.DeleteAccount:
                    subject += "Tài khoản của bạn đã bị xóa";
                    bodySb.Append("<h1>Tài khoản của bạn đã bị xóa</h1>");
                    bodySb.Append("<p>Website: <b>http://www.newsvn.vn</b></p>");
                    bodySb.AppendFormat("<p>Tài khoản: <b>{0}</b><p>", args["newsvn.account.name"]);
                    bodySb.Append("<p>Vui lòng liên hệ admin của newsvn.com để biết thêm chi tiết.</p>");
                    break;
                case SendPurpose.ChangeApproval:
                    subject += "Cập nhật lại tài khoản của bạn";
                    bodySb.Append("<h1>Thông tin tài khoản vừa được cập nhật</h1>");
                    bodySb.Append("<p>Website: <b>http://www.newsvn.vn</b></p>");
                    bodySb.AppendFormat("<p>Tài khoản: <b>{0}</b><p>", args["newsvn.account.name"]);
                    bodySb.AppendFormat("<p>Trạng thái: <b>{0}</b><p>", args["newsvn.account.status"]);
                    bodySb.Append("<p>Vui lòng liên hệ admin của newsvn.com để biết thêm chi tiết.</p>");
                    break;
                case SendPurpose.ResetPassword:
                    subject += "Mật khẩu mới được đặt lại cho tài khoản của bạn";
                    bodySb.Append("<h1>Mật khẩu mới được đặt lại cho tài khoản của bạn</h1>");
                    bodySb.Append("<p>Website: <b>http://www.newsvn.vn</b></p>");
                    bodySb.AppendFormat("<p>Tài khoản: <b>{0}</b><p>", args["newsvn.account.name"]);
                    bodySb.AppendFormat("<p>Mật khẩu mới: <b>{0}</b><p>", args["newsvn.account.password"]);
                    bodySb.Append("<p>Vui lòng thay đổi mật khẩu ngay sau khi bạn đăng nhập lại.</p>");
                    break;
            }

            return Send(from, to, subject, bodySb.ToString());
        }

        public static bool Send(string from, string[] to, string subject, string body)
        {
            return Send(from, to, subject, body, null);
        }

        public static bool Send(string from, string[] to, string subject, string body, string[] attachments)
        {
            return Send(from, to, null, subject, body, attachments);
        }

        public static bool Send(string from, string[] to, string[] cc, string subject, string body, string[] attachments)
        {
            try
            {
                using (MailMessage msg = new MailMessage())
                {
                    msg.From = new MailAddress(from);
                    for (int i = 0; i < to.Length; i++)
                    {
                        msg.To.Add(new MailAddress(to[i]));
                    }
                    if (cc != null)
                    {
                        for (int i = 0; i < cc.Length; i++)
                        {
                            msg.CC.Add(new MailAddress(cc[i]));
                        }
                    }
                    msg.Subject = subject;
                    msg.SubjectEncoding = Encoding.UTF8;
                    msg.Body = body;
                    msg.BodyEncoding = Encoding.UTF8;
                    msg.IsBodyHtml = true;
                    if (attachments != null)
                    {
                        for (int i = 0; i < attachments.Length; i++)
                        {
                            msg.Attachments.Add(new Attachment(attachments[i]));
                        }
                    }
                    _smtpClient.Send(msg);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
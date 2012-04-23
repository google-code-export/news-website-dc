﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web.Services;
using System.Xml.Linq;
using NewsVn.Impl.Caching;
using NewsVn.Impl.Context;

using System.Threading;
using System.IO;
using NewsVn.Impl.PostFetch;
using NewsVn.Impl.PostFetch.Settings;
using NewsVn.Impl.PostFetch.Services;
using NewsVn.Impl.PostFetch.Models;

namespace NewsVn.Web.Utils
{
    /// <summary>
    /// Summary description for NewsVnService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    
    public class NewsVnService : BaseUI.BaseService
    {
        //auto postfetch / config time execute job 
        public static long TimerSetting = long.Parse(System.Configuration.ConfigurationManager.AppSettings["AutoPostFetch_TimeValue"].ToString());
        long timerdelay = 60000;//3600s = 1h //7200000
        Timer timer;
        object SyncRoot = new object();
        public NewsVnService()
        {
            timerdelay = TimerSetting;
            //
            string xmlPath = Server.MapPath("~/Config/PostFetchSites.xml");
            var xmlFile = new FileInfo(xmlPath);

            if (xmlFile.Exists)
            {
                _settingReader = new XmlSettingReader(xmlPath);
                _service = new DefaultPostFetchService(_settingReader);
            }     

            //init site setting
            if (_settingReader != null)
            {
                _siteSettings = _settingReader.GetSiteSettings();
            }
        }

        public void initRefreshScheduler()
        {
            //using delegate function timercallback
            try
            {
                TimerCallback OnTimerTick = new TimerCallback(TimerTick);
                timer = new Timer(OnTimerTick, null, 0, timerdelay);
            }
            catch (Exception ex)
            {

            }
        }
        public void setAutoMode()
        {
            excuteAutoPostFetch();
        }
        private void TimerTick(object state)
        {
            lock (SyncRoot)
            {
                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    //check status of AutoFetchPost / allow or not allow!
                    var AutoFetchPostIsRunning = ctx.SettingRepo.Getter.getQueryable(c => c.Name == "AutoFetchPostIsRunning").FirstOrDefault();
                    if (AutoFetchPostIsRunning != null)
                    {
                        if (AutoFetchPostIsRunning.Value == "True")
                        {
                            excuteAutoPostFetch();            
                        }
                    }
                }
                
            }
        }
        private readonly ISettingReader _settingReader;
        private readonly PostFetchServiceAbstract _service;
        private IList<SiteSetting> _siteSettings;

        private void excuteAutoPostFetch()
        {
            bool allowAutoPostFetch = true;
        //read all site
            if (_siteSettings != null)
            {
                foreach (var site in _siteSettings)
                {
                    //get categories by site
                    if (allowAutoPostFetch)
                    {
                        int selectedSiteID = 0;
                        int.TryParse(site.ID.ToString(), out selectedSiteID);
                        var siteSetting = _siteSettings.FirstOrDefault(x => x.ID == selectedSiteID);

                        if (siteSetting != null)
                        {
                            //read all category of one site
                            foreach (var category in siteSetting.Categories)
                            {
                                if (allowAutoPostFetch)
                                {
                                    allowAutoPostFetch = getPostList(selectedSiteID, category.ID);
                                }
                                else
                                    break;
                            }
                        }
                    }
                    else
                        break;
                }
                //Turn the autoFetchPost to off status
                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    //check status of AutoFetchPost / allow or not allow!
                    var AutoFetchPostIsRunning = ctx.SettingRepo.Getter.getQueryable(c => c.Name == "AutoFetchPostIsRunning").FirstOrDefault();
                    if (AutoFetchPostIsRunning != null)
                    {
                        AutoFetchPostIsRunning.Value = "False";
                        ctx.SubmitChanges();
                    }
                }
            }

        }
        //get list of news from category of one site
        private bool getPostList(int siteID, int CategoryID)
        {
            IList<PostItemModel> postList = new List<PostItemModel>();
            bool allowAutoPostFetch = true;
            if (_service != null)
            {
                int selectedSiteID = siteID;

                int selectedCategoryID = CategoryID;

                var setting = _service.RequestSetting(selectedSiteID, selectedCategoryID);

                if (setting != null)
                {
                    using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                    {
                        postList = _service.RequestPostItemList(setting, ctx);
                     allowAutoPostFetch=  autoInsertPost(postList, setting);
                    }
                }
            }

            return allowAutoPostFetch;
        }
        //add postFetch
        private bool autoInsertPost(IList<PostItemModel> pPostItemModel, PostSettingModel pSetting) {
            try
            {
                if (_service != null)
                {
                    //get setting by
                    var setting = pSetting;
                    using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                    {
                        //recheck status of allow autopostfetch
                        //du co dang chay ma stop, thi auto van se thuc thi cho het 1 sitesetting vd excute den vnexpress thi van phai excute cho xong moi stop
                        var AutoFetchPostIsRunning = ctx.SettingRepo.Getter.getQueryable(c => c.Name == "AutoFetchPostIsRunning").FirstOrDefault();
                        if (AutoFetchPostIsRunning.Value == "True")
                        {
                            foreach (var item in pPostItemModel)
                            {
                                string itemUrl = item.Url;
                                var postItem = _service.RequestRawPostItem(itemUrl, setting);
                                if (postItem != null)
                                {
                                    postItem.Url = itemUrl;
                                    postItem.Avatar = item.Avatar;
                                    postItem.TargetID = setting.TargetID;
                                    postItem.Creator = "AutoFetch";
                                    bool success = _service.AddPostItem(postItem, ctx);
                                }
                            }
                            ctx.SubmitChanges();
                            //thuc thi update seourl
                            var posts = ctx.PostRepo.Getter.getQueryable(p => p.Approved == true && p.CreatedBy == "AutoFetch" && p.SeoUrl == "");
                            foreach (var post in posts)
                            {
                                // Added by DuyNguyen Apr 05, 2012
                                // Update SeoUrl for autofetch Item
                                if (post.AutoFetch)
                                {
                                    var cate = post.Category;
                                    post.SeoUrl = string.Format("pt/{0}/{1}/{2}.aspx", cate.SeoName, post.ID, clsCommon.RemoveUnicodeMarks(post.Title));
                                }
                            }
                           ctx.SubmitChanges();
                        }
                        else
                            return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #region CommentBox

        private int CountPostComments(int postID)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                return ctx.PostCommentRepo.Getter.getQueryable(c => c.PostID == postID && c.UpdatedOn <= DateTime.Now).Count();
            }
        }

        [WebMethod]
        public string GetCommentDialogTitle(int postID)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                return string.Format("Bình luận: {0} ({1})",
                    ctx.PostRepo.Getter.getOne(p => p.ID == postID).Title,
                    this.CountPostComments(postID));
            }
        }

        [WebMethod]
        public string GeneratePagerContent(int postID, int pageSize, int pageIndex)
        {
            int numOfComments = this.CountPostComments(postID);

            if (numOfComments <= pageSize) return "";

            var html = new StringBuilder();
            html.Append("<span>Trang:</span>");

            int numOfPages = numOfComments / pageSize;

            for (int i = 0; i < numOfPages; i++)
            {
                if (i + 1 == pageIndex)
                    html.AppendFormat("\n<span>{0}</span>", i + 1);
                else
                    html.AppendFormat("\n<a href=\"javascript:void(0)\">{0}</a>", i + 1);
            }

            return html.ToString();
        }

        [WebMethod]
        public string LoadCommentList(int postID, int pageSize, int pageIndex, bool oldestOnTop)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var postComments = ctx.PostCommentRepo.Getter.getQueryable(c => c.PostID == postID && c.UpdatedOn <= DateTime.Now);

                if (oldestOnTop)
                    postComments = ctx.PostCommentRepo.Getter.getPagedList(postComments.OrderBy(c => c.UpdatedOn), pageIndex, pageSize);
                else
                    postComments = ctx.PostCommentRepo.Getter.getPagedList(postComments.OrderByDescending(c => c.UpdatedOn), pageIndex, pageSize);

                var html = new StringBuilder();

                foreach (var comment in postComments)
                {
                    html.AppendFormat("<li><b>{0}</b><p>{1}</p><i>({2})</i></li>", comment.Title, comment.Content, comment.UpdatedBy);
                }

                return html.ToString();
            }
        }

        private Dictionary<string, string> GetCaptchaMap()
        {
            var captchaMap = new Dictionary<string, string>();

            if (HttpContextCache.Exists("captcha-list"))
            {
                captchaMap = HttpContextCache.Get<Dictionary<string, string>>("captcha-list");
            }
            else
            {
                try
                {
                    var root = XElement.Load(Server.MapPath("~/Resources/Xml/Captcha.xml"));
                    var captchaList = root.Elements("captcha").Select(c => new
                    {
                        Key = c.Attribute("key").Value,
                        Question = c.Element("question").Value,
                        Answer = c.Element("answer").Value
                    });

                    foreach (var captcha in captchaList)
                    {
                        captchaMap.Add(captcha.Key, string.Format("{0}|{1}", captcha.Question, captcha.Answer));
                    }

                    HttpContextCache.Add("captcha-list", captchaMap);
                }
                catch (Exception) { }
            }

            return captchaMap;
        }

        [WebMethod]
        public string GenerateFormCaptcha(string omitKey)
        {
            var captchaMap = this.GetCaptchaMap();

            Random random = new Random();

            var captcha = captchaMap.ElementAt(random.Next(0, 9));

            while (captcha.Key == omitKey)
            {
                captcha = captchaMap.ElementAt(random.Next(0, 9));
            }

            string[] temp = captcha.Value.Split('|');

            return string.Format("<input id=\"comment_box_captchaKey\" type=\"hidden\" value=\"{0}\" />{1}", captcha.Key, temp[0]);
        }

        private bool CheckCaptchaResponse(string key, string answer)
        {
            var captchaMap = this.GetCaptchaMap();

            string captchaAnswer = captchaMap[key].Split('|')[1];

            if (answer.Equals(captchaAnswer, StringComparison.CurrentCultureIgnoreCase)) return true;

            return false;
        }

        [WebMethod]
        public string InsertComment(Impl.Entity.PostComment comment, int postID, string captchaKey, string captchaAnswer)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    if (this.CheckCaptchaResponse(captchaKey, captchaAnswer))
                    {
                        comment.UpdatedOn = DateTime.Now.AddHours(1);
                        comment.Post = ctx.PostRepo.Getter.getOne(p => p.ID == postID);
                        ctx.PostCommentRepo.Setter.addOne(comment);
                    }
                    else return string.Format(ErrorBar, "Captcha không hợp lệ.");
                }
            }
            catch (Exception)
            {
                return string.Format(ErrorBar, "Không thể thêm bình luận của bạn.");
            }
            return string.Format("{0}", "OK");
        }

        [WebMethod]
        public string ViewCommentContent(int commentID)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    return "<p>" + ctx.PostCommentRepo.Getter.getOne(p => p.ID == commentID).Content + "</p>";
                }
            }
            catch (Exception)
            {
                return string.Format("<ul>" + ErrorBar + "</ul>", "Không thể thêm bình luận của bạn.");
            }
        }

        #endregion

        #region Weather
        [WebMethod]
        //get weather from yahoo
        public string GetWeather(string Zipcode)
        {
            string query = String.Format("http://weather.yahooapis.com/forecastrss?w=" + Zipcode);
            XDocument thisDoc = XDocument.Load(query);
            XNamespace ns = "http://xml.weather.yahoo.com/ns/rss/1.0";
            var condition = (from i in thisDoc.Descendants(ns + "condition") select i);
            var atmosphere = (from i in thisDoc.Descendants(ns + "atmosphere") select i);

            var html = new System.Text.StringBuilder();
            string code = "";
            string codeName = "";
            string humidity = "";
            string temp = "";
            foreach (var c in condition)
            {
                code = c.Attribute("code").Value;
                codeName = skyStatus[int.Parse(code) == 3200 ? 48 : int.Parse(code)];
            }

            foreach (var c in condition)
            {
                int tempF = 0;
                temp = c.Attribute("temp").Value;
                int.TryParse(temp, out tempF);
                //(°F – 32) / 1.8
                temp = Math.Round(((tempF - 32) / 1.8), 1).ToString();
            }

            foreach (var h in atmosphere)
            {
                humidity = h.Attribute("humidity").Value;
            }
            html.AppendFormat("<table class=\"ui-table align-left\" style=\"margin:10px 0;\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr class='ui-widget-header'><td ><b>{3}</b></td><td ><img src=\"http://l.yimg.com/a/i/us/we/52/{4}.gif\"/></td></tr><tr><td>Nhiệt độ</td><td>{0}<sup>o</sup>C</td></tr><tr class='even'><td >Độ ẩm</td><td>{1}%</td></tr><tr><td>Gió đông tốc độ</td><td>{2} m/s</td></tr></table>", temp, humidity, 7, codeName, code);

            return html.ToString();
        }
        #endregion

        #region Ads

        [WebMethod]
        public string load_pletAdsList(string AdsCatName, int pageindex, bool isSearchByDate, string searchDate, string locationID)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                string[] array = checkCateID_By_SEONAME(AdsCatName).Split('$');
                int cateID = int.Parse(array[0]);
                var html = new System.Text.StringBuilder();
                //clone 1 anynomous List<>
                var Datasource = ctx.AdPostRepo.Getter.getQueryable().Select(p => new
                {
                    p.ID,
                    p.Title,
                    p.Content,
                    p.Avatar,
                    p.SeoUrl,
                    p.UpdatedOn,
                    p.Payment,
                    isFree = p.Payment <= 0 ? true : false,
                    p.Location,
                    p.CreatedOn
                }).Take(0).ToList();
                Datasource.Clear();
                //end clone

                //general IQueryable
                var DataQ = ctx.AdPostRepo.Getter.getQueryable(p => p.Category.ID == cateID || (p.Category.Parent != null && p.Category.Parent.ID == cateID
                            && p.Actived == true));//&& p.ExpiredOn>=DateTime.Today //expired sau nay se dung
                //return List<> by Search Result
                //1: condition:search by date
                if (isSearchByDate)
                {
                    DateTime inputSearchDateTime = Convert.ToDateTime(searchDate.Replace('_', '/'));
                    Datasource = DataQ.Where(p => p.CreatedOn.Day == inputSearchDateTime.Day && p.CreatedOn.Month == inputSearchDateTime.Month &&
                        p.CreatedOn.Year == inputSearchDateTime.Year
                        && p.Location == locationID).Select(p => new
                        {
                            p.ID,
                            p.Title,
                            p.Content,
                            p.Avatar,
                            p.SeoUrl,
                            p.UpdatedOn,
                            p.Payment,
                            isFree = p.Payment <= 0 ? true : false,
                            p.Location,
                            p.CreatedOn
                        }).OrderByDescending(p => p.Payment).ThenByDescending(p=>p.CreatedOn).ToList();
                    //Search by date not paging
                }
                //2: search by location
                else
                {
                    //search by location (location in one page) if location is not 'Toan Quoc' (id=0)
                    if (int.Parse(locationID) >= 1)
                    {
                        DataQ = DataQ.Where(p => p.Location == locationID);
                    }
                    // search all (in one page) 
                    Datasource = DataQ.Select(p => new
                    {
                        p.ID,
                        p.Title,
                        p.Content,
                        p.Avatar,
                        p.SeoUrl,
                        p.UpdatedOn,
                        p.Payment,
                        isFree = p.Payment <= 0 ? true : false,
                        p.Location,
                        p.CreatedOn
                    }).OrderByDescending(p => p.Payment).ThenByDescending(p=>p.CreatedOn).Skip(pageindex * 20).Take(20).ToList();
                }
                //generate result
                if (Datasource.Count >= 1)
                {
                    int index = 0;
                    html.AppendLine("<tr class='ui-widget-header'><th style='text-align:left;'>Tin rao vặt</th><th style='text-align:left;'>Ngày đăng</th><th style='text-align:left;'>Phạm vi</th></tr>");
                    foreach (var itemAds in Datasource)
                    {
                        //                    Type itemType = itemAds.GetType();
                        if (index % 2 != 0)
                            html.AppendLine("<tr class='even'>");
                        else
                            html.AppendLine("<tr>");

                        html.AppendLine("<td>");
                        html.AppendFormat("<a {0} href='{1}'>", itemAds.isFree ? "" : "style='font-weight: bold;'", HostName + itemAds.SeoUrl.ToString() + ".aspx");
                        html.AppendLine(itemAds.Title + "</a>");
                        html.AppendLine("</td><td >");
                        html.AppendLine(string.Format("{0:dd/MM/yyyy}", itemAds.CreatedOn));
                        html.AppendLine("</td>");
                        html.AppendLine("</td><td style=\"width:100px;\">");
                        html.AppendLine(Utils.clsCommon.getLocationName(int.Parse(itemAds.Location)));
                        html.AppendLine("</td>");
                        html.AppendLine("</tr>");
                        index++;
                    }
                }
                else
                {
                    html.AppendLine("<tr class='ui-widget-header'><th style=\"text-align:left;\">Tin rao vặt</th><th style=\"text-align:left;\">Ngày đăng</th><th style='text-align:left; widht:100px;'>Phạm vi</th></tr><tr><td colspan='3' ><div style='text-align: center; padding-top: 6px;'><span>Không tìm thấy bài viết</span></div></td></tr>");
                }
                return html.ToString();
            }
        }

        [WebMethod]
        public string getAdsByAdsCat(string AdsCatName)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    string[] array = checkCateID_By_SEONAME(AdsCatName).Split('$');
                    int catID = int.Parse(array[0]);
                    var data = ctx.AdPostRepo.Getter.getQueryable(p => p.CategoryID == catID || (p.Category.Parent != null && p.Category.Parent.ID == catID))
                            .Select(p => new
                            {
                                Name = p.Category.Name,
                                p.ID,
                                p.Title,
                                p.Content,
                                p.Avatar,
                                p.SeoUrl,
                                p.UpdatedOn,
                                p.Payment,
                                isFree = p.Payment <= 0 ? true : false,
                                p.Location,
                                p.CreatedOn
                            }).OrderByDescending(p => p.Payment).ThenByDescending(p=>p.CreatedOn).Take(20).ToList();
                    var html = new System.Text.StringBuilder();

                    if (data.Count() >= 1)
                    {
                        int index = 0;
                        foreach (var itemAds in data)
                        {
                            html.AppendLine("<tbody>");
                            if (index % 2 == 0)
                                html.AppendLine("<tr class='even'>");
                            else
                                html.AppendLine("<tr>");
                            html.AppendLine("<td style='width: 220px;'>");
                            html.AppendFormat("<a {0} href='{1}'>", itemAds.isFree ? "" : "style='font-weight: bold;'", HostName + itemAds.SeoUrl.ToString() + ".aspx");
                            html.AppendLine(itemAds.Title + "</a>");
                            html.AppendLine("</td><td>");
                            html.AppendLine(string.Format("{0:dd/MM/yyyy}", itemAds.CreatedOn));
                            html.AppendLine("</td>");
                            html.AppendLine("<td style='width: 120px;'>" + Utils.clsCommon.getLocationName(int.Parse(itemAds.Location)) + "</td>");
                            html.AppendLine("</tr>");
                            html.AppendLine("</tbody>");
                            index++;
                        }
                    }
                    else
                    {
                        html.AppendLine("<div style='text-align: center; padding-top: 6px;'><span>Không tìm thấy bài viết</span></div>");
                    }
                    return html.ToString();
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
        //check and set Ads CateID , Ads CateTitle
        private string checkCateID_By_SEONAME(string seoNAME)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var cate = ctx.CategoryRepo.Getter.getQueryable(c => c.SeoName == seoNAME && c.Actived == true).Select(c => new { c.ID, c.Name }).ToList();

                if (cate.Count() > 0)
                {
                    return cate[0].ID.ToString() + "$" + cate[0].Name;
                }
                else return "-1$";
            }
        }
        #endregion

        #region User

        [WebMethod]
        public string ViewUserDetails(string userName)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var user = Membership.GetUser(userName);

                if (user != null)
                {
                    var sb = new StringBuilder();
                    sb.AppendFormat("<li><label>Tài khoản:</label><b>{0}</b></li>", user.UserName);
                    sb.AppendFormat("<li><label>Quyền truy cập:</label><b>{0}</b></li>", this.getConfiguredRoleNames(user.UserName));
                    sb.AppendFormat("<li><label>Tạo lúc:</label><b>{0:dd/MM/yyyy HH:mm:ss}</b></li>", user.CreationDate);
                    sb.AppendFormat("<li><label>Email:</label><b>{0}</b></li>", user.Email);
                    sb.AppendFormat("<li><label>Trạng thái:</label><b>{0}</b></li>", user.IsOnline ? "Online" : "Offline");
                    sb.AppendFormat("<li><label>Hoạt động cuối:</label><b>{0:dd/MM/yyyy HH:mm:ss}</b></li>", user.LastActivityDate);
                    sb.AppendFormat("<li><label>Kích hoạt:</label><b>{0}</b></li>", user.IsApproved ? "Được kích hoạt" : "Bị vô hiệu");

                    var profile = ctx.MemberProfileRepo.Getter.getOne(p => p.Account.Equals(user.UserName));

                    if (profile != null)
                    {
                        sb.Append("<li style='border-top:1px dotted #333;margin-top:10px'></li>");
                        sb.AppendFormat("<li><label>Họ tên:</label><b>{0}</b></li>", profile.Name);
                        sb.AppendFormat("<li><label>Số CMND:</label><b>{0}</b></li>", profile.IdNumber);
                        sb.AppendFormat("<li><label>Điện thoại:</label><b>{0}</b></li>", !string.IsNullOrEmpty(profile.Phone) ? profile.Phone : "<i>Chưa xác định</i>");
                        sb.AppendFormat("<li><label>Ngày sinh:</label><b>{0:dd/MM/yyyy}</b></li>", profile.DOB.HasValue ? profile.DOB.Value.ToShortDateString() : "<i>Chưa xác định</i>");
                        sb.AppendFormat("<li><label>Giới tính:</label><b>{0}</b></li>", profile.Gender.Value ? "Nam" : "Nữ");
                        sb.AppendFormat("<li><label>Khu vực:</label><b>{0}</b></li>", !string.IsNullOrEmpty(profile.Location) ? profile.Location : "<i>Chưa xác định</i>");
                        sb.AppendFormat("<li><label>Trình độ:</label><b>{0}</b></li>", !string.IsNullOrEmpty(profile.Education) ? profile.Education : "<i>Chưa xác định</i>");
                    }

                    return sb.ToString();
                }

                return string.Format(ErrorBar, "Không tìm thấy tài khoản này!");
            }
        }

        [WebMethod]
        public void ChangeUserInformation()
        {

        }

        [WebMethod]
        public void ChangeUserPassword(string oldPassword, string newPassword)
        {
            var user = Membership.GetUser();
            
            if (!user.ChangePassword(oldPassword, newPassword))
            {
                throw new Exception("Cannot change password!");
            }
            else
            {
                var args = new Dictionary<string, string>();
                args["newsvn.account.name"] = user.UserName;
                args["newsvn.account.password"] = newPassword;
                ApplicationMailing.Send(new string[] { user.Email }, ApplicationMailing.SendPurpose.ChangePassword, args);
            }
        }

        private string getConfiguredRoleNames(string userName)
        {
            string roleNames = string.Empty;
            string[] roles = Roles.GetRolesForUser(userName);

            for (int i = 0; i < roles.Length; i++)
            {
                roleNames += ApplicationSettings.GetSettingValue("App.Security.Role", roles[i]) + ";";
            }
            return roleNames;
        }

        #endregion
    }
}

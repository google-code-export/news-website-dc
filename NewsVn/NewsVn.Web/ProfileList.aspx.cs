using System;
using System.Linq;
using NewsVn.Impl.Context;

namespace NewsVn.Web
{
    public partial class ProfileList : BaseUI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    load_PletUserProfileList(ctx);
                    load_RandomUserProfile(ctx);
                    this.ExecuteSEO("Tìm bạn bốn phương", "newsvn, newsvn.vn, ket noi ban be, tim ban, ket ban, tim ban 4 phuong,tim ban chat dang online,ket ban online,tim ban trai,ket ban bon phuong", "Tìm bạn bốn phương, kết bạn giao lưu, tìm bạn gái, tìm bạn trai, chia sẻ thông tin, profile");
                }
            }
        }

        private void load_PletUserProfileList(NewsVnContext ctx)
        {
            //xu ly paging trong khoang vd: <<< 95 96 97 98 99 100 >>>
            var data = ctx.UserProfileRepo.Getter.getQueryable(u => u.Description != null).OrderByDescending(u => u.Account)
                .Select(u => new
                {
                    Account = u.Account,
                    u.Age,
                    Country =GetLocationByLocationID(int.Parse(u.Country.Value.ToString()), ctx),
                    u.UpdatedOn,
                    Gender = Utils.ApplicationKeyValueRef.GetKeyValue("Dropdown.Gender", u.Country.Value.ToString()),
                    Location = GetLocationByLocationID(int.Parse(u.Location.ToString()), ctx),
                    u.Name,
                    u.Nickname,
                    u.Expectation,
                    Avatar =u.Avatar.Length<=0 || u.Avatar==null?HostName+ "resources/Images/No_Image/no_avatar.jpg" :HostName+u.Avatar
                })
                .ToList();
            pletUserProfileList.Datasource = data;
            pletUserProfileList.DataBind();
            data = null;
        }

        private void load_RandomUserProfile(NewsVnContext ctx)
        {
            Random x = new Random();
            var _UserProfiles_var = ctx.UserProfileRepo.Getter.getQueryable();
            var cloneDataStructure = _UserProfiles_var.Where(u => u.Description != null).OrderByDescending(u => u.Account).Take(0)
                 .Select(u => new
                 {
                     layoutPosition = "",
                     Account = u.Account,
                     u.Age,
                     Country = GetLocationByLocationID(int.Parse(u.Country.Value.ToString()), ctx),
                     u.UpdatedOn,
                     Gender = Utils.ApplicationKeyValueRef.GetKeyValue("Dropdown.Gender", u.Gender.ToString()),
                     Location = GetLocationByLocationID(int.Parse(u.Location.ToString()), ctx),
                     u.Name,
                     u.Nickname,
                     u.Expectation,
                     u.Avatar
                 }).ToList();

            for (int i = 0; i < 8; i++)
            {
                var data = _UserProfiles_var.OrderByDescending(u => u.Account)
                    .Skip(x.Next(0, _UserProfiles_var.Count() == 0 ? 0 : _UserProfiles_var.Count() - 1)).Take(1)
                .Select(u => new
                {
                    layoutPosition = i % 2 == 0 ? "left" : "right",
                    Account = u.Account,
                    u.Age,
                    Country = GetLocationByLocationID(int.Parse(u.Country.Value.ToString()), ctx),
                    u.UpdatedOn,
                    Gender = Utils.ApplicationKeyValueRef.GetKeyValue("Dropdown.Gender", u.Gender.ToString()),
                    Location = GetLocationByLocationID(int.Parse(u.Location.ToString()), ctx),
                    u.Name,
                    u.Nickname,
                    u.Expectation,
                    Avatar = u.Avatar.Length < 1 || u.Avatar == null ? HostName + "resources/Images/No_Image/no_avatar.jpg" : HostName + u.Avatar
                }).FirstOrDefault();
                cloneDataStructure.Add(data);
                data = null;
            }

            pletRandomProfile.Datasource = cloneDataStructure;
            pletRandomProfile.DataBind();
            cloneDataStructure = null;
        }

        private string GetLocationByLocationID(int intLocationID, NewsVnContext ctx)
        {
            var _Location = ctx.LocationRepo.Getter.getOne(e => e.LocationID == intLocationID).LocationName;
            if (_Location != "")
            {
                return _Location.ToString();

            }
            else
            {
                return "";
            }
        }
    }
}
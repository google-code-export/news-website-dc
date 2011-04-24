using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NewsVn.Web.Utils;

namespace NewsVn.Web
{
    public partial class ProfileList : BaseUI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_PletUserProfileList();
                load_RandomUserProfile();
            }
        }
        private void load_PletUserProfileList()
        {
            //did not use cache! large record
            //xu ly paging trong khoang vd: <<< 95 96 97 98 99 100 >>>
            var data = ApplicationManager.Entities.UserProfiles.OrderByDescending(u=>u.Account)
                .Select(u => new { 
                u.Account,u.Age,u.Country,u.CreatedOn,
                Gender =u.Gender==true?"Nam":"Nữ",
               u.Location,u.Name,u.Nickname,u.Expectation,
                Avatar = u.Avatar.Length < 1 ? "~/resources/profiles/no_photo.gif" : u.Avatar
                })
                .ToList();
            pletUserProfileList.Datasource = data;
            pletUserProfileList.DataBind();
            data = null;
        }
        private void load_RandomUserProfile()
        {
            Random x = new Random();
            var _UserProfiles_var = ApplicationManager.Entities.UserProfiles;
            var cloneDataStructure = _UserProfiles_var.OrderByDescending(u => u.Account).Take(0)
                 .Select(u => new
                 {
                     layoutPosition="",
                     u.Account,
                     u.Age,
                     u.Country,
                     u.CreatedOn,
                     Gender = u.Gender == true ? "Nam" : "Nữ",
                     u.Location,
                     u.Name,
                     u.Nickname,
                     u.Expectation,u.Avatar
                 }).ToList();
            for (int i = 0; i < 8; i++)
            {
                var data = _UserProfiles_var.OrderByDescending(u => u.Account)
                .Skip(x.Next(0, _UserProfiles_var.Count()-1)).Take(1)
                .Select(u => new
                {
                    layoutPosition = i % 2 == 0 ? "left" : "right",
                    u.Account,
                    u.Age,
                    u.Country,
                    u.CreatedOn,
                    Gender = u.Gender == true ? "Nam" : "Nữ",
                    u.Location,
                    u.Name,
                    u.Nickname,
                    u.Expectation,
                    Avatar = u.Avatar.Length < 1 ? "~/resources/profiles/no_photo.gif" : u.Avatar
                }).FirstOrDefault();
                cloneDataStructure.Add(data);
                data = null;
            }

            pletRandomProfile.Datasource = cloneDataStructure;
            pletRandomProfile.DataBind();
            cloneDataStructure = null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using System.Web.Configuration;
using NewsVn.Web.Utils;

namespace NewsVn.Web
{
    public partial class ProfileSearchResult : BaseUI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack )
            {
                LoadProfileResult();
            }
        }

        private void LoadProfileResult()
        {
            try
            {
                string requestUrl = Request.Url.ToString();
                string []  prams = requestUrl.Split('=')[1].ToString().ToString().Split('-');
                //gender-fagetage-avatar-marital-education-religion-smoke-drink-nation-location-name
                string strGender = prams[0];
                string strFage = prams[1].Substring(0,2);
                string strTage = prams[1].Substring(2, 2);
                string strAvatar = prams[2];
                string strMarital  = prams[3];
                string strEducation = prams[4];
                string strReligion = prams[5];
                bool bSmoke = (prams[6]=="1")?true:false;
                bool bDrunk = (prams[7]=="1")?true:false;
                string strNation = prams[8];
                string strLocation = prams[9];
                string strName = prams[10];
                                
                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    var _Profile = ctx.UserProfileRepo.Getter.getQueryable();
                    var profileResult = _Profile.Where(p => p.Gender == int.Parse(strGender)
                        && p.Age >= int.Parse(strFage)
                        && p.Age <= int.Parse(strTage)
                        && p.Avatar == strAvatar
                        && p.MaritalStatus == int.Parse(strMarital)
                        && p.Education == int.Parse(strEducation)
                        && p.Religion == int.Parse(strReligion)
                        && p.Smoke == bSmoke
                        && p.Drink == bDrunk
                        && p.Country == int.Parse(strNation)
                        && p.Location == int.Parse(strLocation)
                        && p.Name == strName
                        )
                        .Select(pf => new
                        {
                            pf.Account,
                            pf.Avatar,
                            pf.Age,
                            pf.Location,
                            pf.Nickname,
                            pf.Name,
                            pf.Expectation,
                            pf.UpdatedOn,
                            profileCommentCount = this.GetProfileCommentByAccount(pf.Account)

                        }).OrderByDescending(pf => pf.Account).ThenByDescending(pf => pf.UpdatedOn).ToList();

                    profileSearchResult.DataSource = profileResult;
                    
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private int GetProfileCommentByAccount(string strAccount)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    return ctx.UserProfileCommentRepo.Getter.getQueryable(c => c.ForAccount == strAccount).Count();
                }
            }
            catch (Exception)
            {

                return 0;
            }
        }
    }
}
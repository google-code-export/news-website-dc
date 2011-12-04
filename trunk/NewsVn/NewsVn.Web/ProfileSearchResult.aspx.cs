using System;
using System.Linq;
using NewsVn.Impl.Context;

namespace NewsVn.Web
{
    public partial class ProfileSearchResult : BaseUI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack )
            {
                SiteTitle += "Kết quả tìm kiếm";
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

                int intEdu = 0;
                int intFage = 0;
                int intTage = 0;
                int intHasAvatar = 0;
                int intMaritalStatus = 0;
                int intReligion = 0;
                int intNation = 0;
                int intLocation = 0;

                int.TryParse(prams[4], out intEdu);
                int.TryParse(prams[1].Substring(0, 2), out intFage);
                int.TryParse(prams[1].Substring(2, 2), out intTage);
                int.TryParse(prams[2], out intHasAvatar);
                int.TryParse(prams[3], out intMaritalStatus);
                int.TryParse(prams[4], out intReligion);
                int.TryParse(prams[8], out intNation);
                int.TryParse(prams[9], out intLocation);

                                
                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    var _Profile = ctx.UserProfileRepo.Getter.getQueryable(p => p.Gender == int.Parse(strGender)
                        && p.Age >= int.Parse(strFage)
                        && p.Age <= int.Parse(strTage)
                        && p.Smoke == bSmoke
                        && p.Drink == bDrunk
                        
                        );
                    if (strName != "0")
                    {
                        _Profile = _Profile.Where(c => c.Name.Contains( strName));
                    }
                    if (intEdu!=0)
                    {
                        _Profile = _Profile.Where(c => c.Education == intEdu);
                    }
                    if (intHasAvatar != 0)
                    {
                        //_Profile = _Profile.Where(c => c.a == intHasAvatar);
                    }
                    if (intMaritalStatus != 0)
                    {
                        _Profile = _Profile.Where(c => c.MaritalStatus == intMaritalStatus);
                    }
                    if (intReligion != 0)
                    {
                        _Profile = _Profile.Where(c => c.Religion == intReligion);
                    }
                    if (intNation != 0)
                    {
                        _Profile = _Profile.Where(c => c.Country == intNation);
                    }
                    if (intLocation != 0)
                    {
                        _Profile = _Profile.Where(c => c.Location == intLocation);
                    }
                    var dataResult=_Profile.Select(pf => new
                        {
                            pf.Account,
                            pf.Avatar,
                            Gender = Utils.ApplicationKeyValueRef.GetKeyValue("Dropdown.Gender", pf.Gender.ToString()),
                            pf.Age,
                            pf.Location,
                            pf.Nickname,
                            pf.Name,
                            pf.Expectation,
                            pf.UpdatedOn,
                            profileCommentCount = this.GetProfileCommentByAccount(pf.Account, ctx)

                        }).OrderByDescending(pf => pf.Account).ThenByDescending(pf => pf.UpdatedOn).ToList();

                    profileSearchResult.DataSource = dataResult;
                }
                
                
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString(); 
            }
        }

        private int GetProfileCommentByAccount(string strAccount, NewsVnContext ctx)
        {
            return ctx.UserProfileCommentRepo.Getter.getQueryable(c => c.ForAccount == strAccount).Count();
        }

        enum CompareOpt
        {
            Equal, NotEqual, Greater, GreaterOrEqual, Less, LessOrEqual
        }

        private bool CompareInt(int? a, int? b, CompareOpt opt)
        {
            if (a == null || b == null)
            {
                return true;
            }
            
            if (a == 0 || b == 0)
            {
                return true;
            }

            bool condition = false;

            switch (opt)
            {
                case CompareOpt.Equal:
                    condition = a == b;
                    break;
                case CompareOpt.NotEqual:
                    condition = a != b;
                    break;
                case CompareOpt.Greater:
                    condition = a > b;
                    break;
                case CompareOpt.GreaterOrEqual:
                    condition = a >= b;
                    break;
                case CompareOpt.Less:
                    condition = a < b;
                    break;
                case CompareOpt.LessOrEqual:
                    condition = a <= b;
                    break;
            }

            return condition;
        }

    }
}
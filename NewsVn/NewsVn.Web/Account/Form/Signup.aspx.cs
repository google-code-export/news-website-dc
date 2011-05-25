using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Account.Form
{
    public partial class Signup : BaseUI.BasePage
    {
        protected void Page_Load(object sender, EventArgs args)
        {
            this.Title = SiteTitle + "Đăng ký";
            
            this.GenerateAgeDropDownList();

            if (!IsPostBack)
            {
                ltrTitle.Text = wzUserSignUp.ActiveStep.Title;
            }
        }

        private void GenerateAgeDropDownList()
        {
            string age = string.Empty;
            for (int i = 18; i <= 80; i++)
            {
                age = i.ToString();
                ddlAge.Items.Add(new ListItem(age, age));
            }
        }

        protected void wzUserSignUp_OnActiveStepChanged(object sender, EventArgs args)
        {
            ltrTitle.Text = wzUserSignUp.ActiveStep.Title;
        }

        protected void Start_Click(object sender, EventArgs args)
        {
            wzUserSignUp.ActiveStepIndex = 1;
        }

        protected void Finish_Click(object sender, EventArgs args)
        {
            wzUserSignUp.ActiveStepIndex = 2;
        }
    }
}
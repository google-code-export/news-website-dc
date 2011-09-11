using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class SideTabsBox : System.Web.UI.UserControl
    {
        public string CurrencySource { get; set; }
        public List<Utils.clsCurrency> Datasource { get; set; }
        public object Datasource_Weather { get; set; }
        protected override void OnDataBinding(EventArgs e)
        {

            rptCurrency.DataSource = Datasource;
            rptCurrency.DataBind();

            regionSelector.DataSource = Datasource_Weather;
            regionSelector.DataTextField = "Name";
            regionSelector.DataValueField = "WOEID";
            regionSelector.DataBind();
        }
    }
}
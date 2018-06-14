using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shop.Bussiness;
using Shop.Model;

namespace Shop.Admin.Config
{
    public partial class License : AdminPageBase
    {
        protected BaseConfig model;
        protected string password = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            B_BaseConfig bconfig=new B_BaseConfig();
            model = bconfig.LoadConfig();
            
            if (!EX_Admin.Power("License_set", "账户设置"))
            {
                PageNoPower();
            }
            password = model.LicensePWD;
            if (password != "")
                password = "******";
            
            string[] arr = model.LicenseDomain.Split(',');
            string res = "";
            foreach (string str in arr)
            {
                if (str == "")
                    continue;
                if (res == "")
                    res = str;
                else
                    res += ","+str;
            }
            model.LicenseDomain = res;
        }
    }
}
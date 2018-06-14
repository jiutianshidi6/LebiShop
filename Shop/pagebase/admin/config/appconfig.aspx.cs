using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shop.Bussiness;
using Shop.Model;

namespace Shop.Admin.storeConfig
{
    public partial class appconfig : AdminPageBase
    {
        protected BaseConfig model;
        protected string val;
        protected string app_menu = "";
        protected string app_lefticon = "";
        protected string app_lefturl = "";
        protected string app_righticon = "";
        protected string app_righturl = "";
        protected string app_name = "";
        protected string app_toplogo = "";
        protected string app_toplogourl = "";
        protected string app_topbackground = "";
        protected string app_topcolor = "";
        protected string app_topline = "";
        protected string app_bottombackground = "";
        protected string app_bottomcolor = "";
        protected string app_bottomline = "";
        protected string app_startimage = "";
        protected string app_starturl = "";
        protected string app_waittimes = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!EX_Admin.Power("appconfig_edit", "APP设置"))
            {
                PageReturnMsg = PageNoPowerMsg();
            }
            
            val = B_BaseConfig.Get("app_menu");
            app_name = B_BaseConfig.Get("app_name");
            app_lefticon = B_BaseConfig.Get("app_lefticon");
            app_lefturl = B_BaseConfig.Get("app_lefturl");
            app_righticon = B_BaseConfig.Get("app_righticon");
            app_righturl = B_BaseConfig.Get("app_righturl");
            app_toplogo = B_BaseConfig.Get("app_toplogo");
            app_toplogourl = B_BaseConfig.Get("app_toplogourl");
            app_topbackground = B_BaseConfig.Get("app_topbackground");
            app_topcolor = B_BaseConfig.Get("app_topcolor");
            app_topline = B_BaseConfig.Get("app_topline");
            app_bottombackground = B_BaseConfig.Get("app_bottombackground");
            app_bottomcolor  = B_BaseConfig.Get("app_bottomcolor");
            app_bottomline = B_BaseConfig.Get("app_bottomline");
            app_startimage = B_BaseConfig.Get("app_startimage");
            app_starturl = B_BaseConfig.Get("app_starturl");
            app_waittimes = B_BaseConfig.Get("app_waittimes");
        }

        public List<BaseConfigAppMenu> Getmenus(string str)
        {
            List<BaseConfigAppMenu> menus;
            try
            {
                menus = B_BaseConfig.AppMenu(str);
                if (menus == null)
                    menus = new List<BaseConfigAppMenu>();
            }
            catch
            {
                menus = new List<BaseConfigAppMenu>();
            }

            return menus;
        }
    }
}
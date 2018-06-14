using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ServiceProcess;
using System.Text.RegularExpressions;

using Shop.Model;
using Shop.Tools;
using Shop.DataAccess;

namespace Shop.Bussiness
{
    public class Site
    {
        private string _title = "LebiShop多语言网店系统";
        private string _adminpath = "";
        private string _adminjspath = "";
        private string _adminimagepath = "";
        private string _admincsspath = "";
        private string _SiteName = "LebiShop多语言网店系统";
        private string _WebPath = "";
        private string _SupplierPath = "";
        private int _SiteCount = 2;//用户的站点数量
        #region 静态实例
        private static Site _Instance;
        public static Site Instance
        {
            get
            {
                if (_Instance == null)
                    return new Site();
                else
                    return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion
        public Site()
        {
            BaseConfig bcf = ShopCache.GetBaseConfig();
            if (!Shop.LebiAPI.Service.Instanse.Check("managelicenese"))
            {
                _SiteName = "LebiShop多语言网店系统";
                _title = "LebiShop多语言网店系统";
            }
            else
            {
                Lebi_Site s = ShopCache.GetMainSite();
                _SiteName = Language.Content(s.Name, "CN");
                _title = Language.Content(s.Title, "CN");
            }
            _WebPath = RequestTool.GetConfigKey("WebPath");
            _SupplierPath = RequestTool.GetConfigKey("SupplierPath");
            _WebPath = _WebPath.TrimEnd('/');
            _adminpath = _WebPath + RequestTool.GetConfigKey("AdminPath");
            _adminjspath = _WebPath + "/theme/system/systempage/admin/js";
            _admincsspath = _WebPath + "/theme/system/systempage/admin/css";
            _adminimagepath = _WebPath + "/theme/system/systempage/admin/images";

            if (!Shop.LebiAPI.Service.Instanse.Check("lebilicense"))
            {

                _SiteName = "LebiShop多语言网店系统"; //Language.Content(bcf.Name, Language.CurrentLanguage().Code);
                _title = _SiteName;

            }
            if (Shop.LebiAPI.Service.Instanse.Check("domain3"))
            {
                _SiteCount = B_Lebi_Site.Counts("");
                _SiteCount = _SiteCount > 30 ? 30 : 30; //_SiteCount; // _SiteCount;
            }
            else if (Shop.LebiAPI.Service.Instanse.Check("domain20"))
            {
                _SiteCount = B_Lebi_Site.Counts("");
                _SiteCount = _SiteCount > 20 ? 20 : 20; //_SiteCount; // _SiteCount;
            }
            else if (Shop.LebiAPI.Service.Instanse.Check("domain10"))
            {
                _SiteCount = B_Lebi_Site.Counts("");
                _SiteCount = _SiteCount > 10 ? 10 : 10; //_SiteCount; // _SiteCount;
            }
            //else if (Shop.LebiAPI.Service.Instanse.Check("domain2"))
            //{
            //    _SiteCount = B_Lebi_Site.Counts("");
            //    _SiteCount = _SiteCount > 2 ? 2 : _SiteCount; // _SiteCount;
            //}
            else
            {
                _SiteCount = 2;
            }
            if (_SiteCount == 0)
                _SiteCount = 2;

        }
        public int SiteCount
        {
            get { return _SiteCount; }
        }
        public string WebPath
        {
            get { return _WebPath; }
        }
        public string SiteName
        {
            //set { _SiteName = value; }
            get { return _SiteName; }
        }
        public string title
        {
            //set { _title = value; }
            get { return _title; }
        }

        public string SupplierPath
        {
            get { return _SupplierPath; }
        }
        public string AdminPath
        {
            //set { _adminpath = value; }
            get { return _adminpath; }
        }
        public string AdminJsPath
        {
            //set { _adminjspath = value; }
            get { return _adminjspath; }
        }
        public string AdminCssPath
        {
            //set { _admincsspath = value; }
            get { return _admincsspath; }
        }
        public string AdminImagePath
        {
            //set { _adminimagepath = value; }
            get { return _adminimagepath; }
        }
        /// <summary>
        ///  多站点选择
        /// </summary>
        /// <param name="InputName"></param>
        /// <param name="ids"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public string SiteCheckbox(string InputName, string ids, string lang)
        {
            int sitenum = _SiteCount;
            List<Lebi_Site> models = B_Lebi_Site.GetList("", "Sort desc", sitenum, 1);
            string str = "";
            foreach (Lebi_Site model in models)
            {
                string sel = "";
                if (("," + ids + ",").IndexOf("," + model.id + ",") > -1)
                    sel = "checked";
                str += "<label><input type=\"checkbox\" name=\"" + InputName + "\" id=\"" + InputName + "\" shop=\"true\" value=\"" + model.id + "\" " + sel + ">" + model.SubName + "&nbsp;</label>";
            }
            return str;

        }
        /// <summary>
        /// 全部可用站点
        /// </summary>
        /// <returns></returns>
        public List<Lebi_Site> Sites()
        {
            int sitenum = _SiteCount;
            List<Lebi_Site> sites = B_Lebi_Site.GetList("", "Sort desc", sitenum, 1);
            return sites;
        }
        /// <summary>
        /// 全部可用站点ID
        /// </summary>
        /// <returns></returns>
        public string Sitesid()
        {
            string str = "";
            foreach (Lebi_Site site in Sites())
            {
                if (str == "")
                    str = site.id.ToString();
                else
                    str += "," + site.id.ToString();
            }
            return str;
        }
    }
    public class Site_Supplier
    {
        private string _title = "";
        private string _adminpath = "";
        private string _adminjspath = "";
        private string _adminimagepath = "";
        private string _admincsspath = "";
        private string _SiteName = "";
        private string _WebPath = "";
        private int _SiteCount = 0;//用户的站点数量
        public Site_Supplier()
        {
            BaseConfig bcf = ShopCache.GetBaseConfig();
            if (!Shop.LebiAPI.Service.Instanse.Check("managelicenese"))
            {
                _SiteName = "LebiShop网上商店系统";
                _title = "LebiShop网上商店系统";
            }
            else
            {
                Lebi_Site s = ShopCache.GetMainSite();
                _SiteName = Language.Content(s.Name, "CN");
                _title = Language.Content(s.Title, "CN");
            }
            _WebPath = RequestTool.GetConfigKey("WebPath");
            _WebPath = _WebPath.TrimEnd('/');

            _adminpath = RequestTool.GetConfigKey("SupplierPath");
            _adminjspath = _WebPath + "/theme/system/systempage/supplier/js";
            _admincsspath = _WebPath + "/theme/system/systempage/supplier/css";
            _adminimagepath = _WebPath + "/theme/system/systempage/supplier/images";

            if (!Shop.LebiAPI.Service.Instanse.Check("lebilicense"))
            {

                _SiteName = Language.Content(bcf.Name, Language.CurrentLanguage().Code);
                _title = _SiteName;

            }
            if (!Shop.LebiAPI.Service.Instanse.Check("domain3"))
            {
                _SiteCount = 1;
            }
            else
            {
                _SiteCount = B_Lebi_Site.Counts("");
                _SiteCount = _SiteCount > 3 ? 3 : _SiteCount;
            }

        }
        public int SiteCount
        {
            get { return _SiteCount; }
        }
        public string WebPath
        {
            get { return _WebPath; }
        }
        public string SiteName
        {
            //set { _SiteName = value; }
            get { return _SiteName; }
        }
        public string title
        {
            //set { _title = value; }
            get { return _title; }
        }

        public string AdminPath
        {
            //set { _adminpath = value; }
            get { return _adminpath; }
        }
        public string AdminJsPath
        {
            //set { _adminjspath = value; }
            get { return _adminjspath; }
        }
        public string AdminCssPath
        {
            //set { _admincsspath = value; }
            get { return _admincsspath; }
        }
        public string AdminImagePath
        {
            //set { _adminimagepath = value; }
            get { return _adminimagepath; }
        }

    }
    public class Site_Agent
    {

        private string _adminpath = "";
        private string _adminjspath = "";
        private string _adminimagepath = "";
        private string _admincsspath = "";
        private string _WebPath = "";
        public Site_Agent()
        {
            BaseConfig bcf = ShopCache.GetBaseConfig();

            _WebPath = RequestTool.GetConfigKey("WebPath");
            _WebPath = _WebPath.TrimEnd('/');

            _adminpath = _WebPath + "/agent";
            _adminjspath = _adminpath + "/js";
            _admincsspath = _adminpath + "/css";
            _adminimagepath = _adminpath + "/images";
        }

        public string WebPath
        {
            get { return _WebPath; }
        }
        public string AdminPath
        {
            //set { _adminpath = value; }
            get { return _adminpath; }
        }
        public string AdminJsPath
        {
            //set { _adminjspath = value; }
            get { return _adminjspath; }
        }
        public string AdminCssPath
        {
            //set { _admincsspath = value; }
            get { return _admincsspath; }
        }
        public string AdminImagePath
        {
            //set { _adminimagepath = value; }
            get { return _adminimagepath; }
        }

    }
}


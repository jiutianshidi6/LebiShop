using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shop.Bussiness;
using Shop.Model;
using Shop.Tools;

namespace Shop.Admin.product
{
    public partial class Tag : AdminPageBase
    {
        protected string lang;
        protected string key;
        protected List<Lebi_Pro_Tag> models;
        protected string PageString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!EX_Admin.Power("pro_tag_list", "商品标签列表"))
            {
                PageNoPower();
            }
            PageSize = RequestTool.getpageSize(20);
            lang = RequestTool.RequestString("lang");
            key = RequestTool.RequestString("key");
            if (lang == "")
                lang = "CN";
            string where = "1=1";
            if (key != "")
                where += " and Name like lbsql{'%"+key+"%'}";
            models = B_Lebi_Pro_Tag.GetList(where, "Sort desc", PageSize, page);
            int recordCount = B_Lebi_Pro_Tag.Counts(where);
            
            PageString = Pager.GetPaginationString("?page={0}&lang="+lang+"&key=" + key, page, PageSize, recordCount);
            
        }
    }
}
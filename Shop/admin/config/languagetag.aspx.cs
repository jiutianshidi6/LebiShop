using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shop.Bussiness;
using Shop.Model;
using Shop.Tools;

namespace Shop.Admin.storeConfig
{
    public partial class LanguageTag : AdminPageBase
    {
        protected string lang;
        protected int type;
        protected string key;
        protected List<Lebi_Language_Tag> models;
        protected string PageString;

        protected List<Lebi_Language_Code> langs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!EX_Admin.Power("language_tag_list", "语言标签列表"))
            {
                PageNoPower();
            }
            PageSize = RequestTool.getpageSize(20);
            key = RequestTool.RequestString("key");
            string where = "1=1";
            if (key != "")
                where += " and (Tag like lbsql{'%" + key + "%'} or CN like lbsql{'%" + key + "%'} or EN like lbsql{'%" + key + "%'} or ja like lbsql{'%" + key + "%'})";

            models = B_Lebi_Language_Tag.GetList(where, "id desc", PageSize, page);
            int recordCount = B_Lebi_Language_Tag.Counts(where);
            PageString = Pager.GetPaginationString("?page={0}&key=" + key, page, PageSize, recordCount);
            langs = Language.Languages();
            List<Lebi_Language_Code> temps=Language.Languages();
            foreach (Lebi_Language_Code l in Language.AdminLanguages())
            {
                bool flag=false;
                foreach (Lebi_Language_Code cl in temps)
                {
                    if (cl.id == l.id)
                        flag = true;
                }
                if (!flag)
                    langs.Add(l);
            }
        }

        public string TagValue(Lebi_Language_Tag tag, string lang)
        {
            if (tag == null)
                return "";
            string res = "";
            Type type = tag.GetType();
            System.Reflection.PropertyInfo p = type.GetProperty(lang);
            if (p == null)
                return "";
            res = p.GetValue(tag, null).ToString();
            return res;
        }
    }
}
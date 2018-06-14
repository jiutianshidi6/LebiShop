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
    public partial class Property : AdminPageBase
    {

        protected List<Lebi_Type> types;
        protected Lebi_Type tmodel;
        protected string PageString;
        protected int tid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!EX_Admin.Power("property_list", "属性规格列表"))
            {
                PageNoPower();
            }
            string where = "Class='ProPertyType'";
            tid = RequestTool.RequestInt("tid", 133);
            PageSize = RequestTool.getpageSize(20);
            types = B_Lebi_Type.GetList(where, "Sort desc");
            int recordCount = B_Lebi_ProPerty.Counts("parentid = 0 and Type_id_ProPertyType = " + tid + "");
            PageString = Pager.GetPaginationString("tid=" + tid + "&page={0}", page, PageSize, recordCount);
            tmodel = B_Lebi_Type.GetModel(tid);
        }
        public List<Lebi_ProPerty> GetModels(int type)
        {
            List<Lebi_ProPerty> models;
            string where = "Type_id_ProPertyType=" + type + " and parentid=0";
            models = B_Lebi_ProPerty.GetList(where, "Sort desc");
            return models;

        }
        public string GetProPerty(int pid, int top = 0)
        {
            List<Lebi_ProPerty> models;
            string where = "parentid=" + pid + "";
            if (top == 0)
                models = B_Lebi_ProPerty.GetList(where, "Sort desc");
            else
                models = B_Lebi_ProPerty.GetList(where, "Sort desc", top, 1);
            string str = "";

            foreach (Lebi_ProPerty model in models)
            {
                if (str == "")
                    str = Language.Content(model.Name, CurrentLanguage.Code);
                else
                    str += ", " + Language.Content(model.Name, CurrentLanguage.Code);
                if (model.Code != "")
                    str += "(" + model.Code + ")";

            }
            return str;

        }


    }
}
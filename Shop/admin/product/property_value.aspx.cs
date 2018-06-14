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
    public partial class Property_Value : AdminPageBase
    {

        protected List<Lebi_ProPerty> models;
        protected Lebi_ProPerty pmodel;
        protected Lebi_Type tmodel;
        protected string PageString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!EX_Admin.Power("property_add", "添加属性规格") || !EX_Admin.Power("property_edit", "编辑属性规格"))
            {
                PageNoPower();
            }
            int pid = RequestTool.RequestInt("pid",0);
            pmodel = B_Lebi_ProPerty.GetModel(pid);
            string where = "parentid=" + pid;
            models = B_Lebi_ProPerty.GetList(where, "Sort desc");
            tmodel = B_Lebi_Type.GetModel(pmodel.Type_id_ProPertyType);

        }

      
    }
}
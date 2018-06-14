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
    public partial class product_Edit_part : AdminPageBase
    {
        protected List<Lebi_ProPerty> pros;
        protected Lebi_Product model;
        protected List<KeyValue> ProPerty133;
        protected void Page_Load(object sender, EventArgs e)
        {
            int tid = RequestTool.RequestInt("tid", 0);
            int pid = RequestTool.RequestInt("pid", 0);
            //Lebi_ProPerty_Type ptype = B_Lebi_ProPerty_Type.GetModel(tid);
            string property = EX_Product.ProductType_ProPertystr(tid);
            if (property != "")
            {
                pros = B_Lebi_ProPerty.GetList("Type_id_ProPertyType in (132,133) and id in (" + property + ")", "Sort desc");
            }
            if (pros == null)
            {
                pros = new List<Lebi_ProPerty>();
            }
            model = B_Lebi_Product.GetModel(pid);
            if (model == null)
                model = new Lebi_Product();
            ProPerty133 = Common.KeyValueToList(model.ProPerty133);
        }

        public string GetproList(Lebi_ProPerty pmodel)
        {
            string str = "";

            List<Lebi_ProPerty> ps = B_Lebi_ProPerty.GetList("parentid=" + pmodel.id + "", "Sort desc");
            if (pmodel.Type_id_ProPertyType == 132)
            {
                foreach (Lebi_ProPerty p in ps)
                {
                    string sel = "";
                    if (("," + model.ProPerty132 + ",").Contains("," + p.id + ","))
                        sel = "checked";
                    str += " <label><input type=\"checkbox\" name=\"Property132\" shop=\"true\" " + sel + " value=\"" + p.id + "\"" + " />" + Language.Content(p.Name, CurrentLanguage.Code) +"</label>";

                }
            }
            else if (pmodel.Type_id_ProPertyType == 133)
            {
                List<Lebi_Language_Code> langs = Language.Languages();
                KeyValue kv;
                try
                {
                    kv = (from m in ProPerty133
                          where m.K == pmodel.id.ToString()
                          select m).ToList().FirstOrDefault();
                }
                catch
                {
                    kv = new KeyValue();
                }
                foreach (Lebi_Language_Code lang in langs)
                {
                    string val = "";
                    if (kv != null && kv.V != null)
                        val = kv.V;
                    str += lang.Code + " <input type=\"text\" name=\"Property133_" + pmodel.id + lang.Code + "\" shop=\"true\" value=\"" + Language.Content(val, lang.Code) + "\"" + " class=\"input\"  /> ";
                }


            }
            else if (pmodel.Type_id_ProPertyType == 134)
            {
                foreach (Lebi_ProPerty p in ps)
                {
                    string sel = "";
                    if (("," + model.ProPerty134 + ",").Contains("," + p.id + ","))
                        sel = "checked";
                    str += " <label><input type=\"checkbox\" name=\"Property134\" shop=\"true\" " + sel + " value=\"" + p.id + "\"" + " />" + Language.Content(p.Name, CurrentLanguage.Code) + "</label>";

                }
            }
            return str;
        }

        public string Getpro131List(int pid)
        {
            string str = "";
            List<Lebi_ProPerty> ps = B_Lebi_ProPerty.GetList("parentid=" + pid + "", "Sort desc");
            foreach (Lebi_ProPerty p in ps)
            {
                string sel = "";

                if (("," + model.ProPerty131 + ",").Contains("," + p.id + ","))
                    sel = "checked";
                str += " <label><input type=\"checkbox\" name=\"Property131\" shop=\"true\" " + sel + " value=\"" + p.id + "\"" + " />" + Language.Content(p.Name, CurrentLanguage.Code);
                if (p.Code!="")
                    str += "(" + p.Code + ")";
                str += "</label>";
            }

            return str;
        }

        /// <summary>
        /// 属性规格选择
        /// </summary>
        /// <param name="selid"></param>
        /// <returns></returns>
        public string Property(string selid, int t)
        {
            string str = "";
            List<Lebi_ProPerty> pros = B_Lebi_ProPerty.GetList("parentid=0 and Type_id_ProPertyType=" + t + "", "Sort desc");
            foreach (Lebi_ProPerty pro in pros)
            {
                string sel = "";
                if (("," + selid + ",").Contains("," + pro.id + ""))
                {
                    sel = "checked";
                }
                str += "<label><input " + sel + " type=\"checkbox\" value=\"" + pro.id + "\" shop=\"true\" name=\"ProPerty" + t + "\"/>" + Language.Content(pro.Name, CurrentLanguage.Code);
                if (pro.Code != "")
                    str += "(" + pro.Code + ")";
                str += "</label>&nbsp;";
            }
            return str;
        }
    }
}
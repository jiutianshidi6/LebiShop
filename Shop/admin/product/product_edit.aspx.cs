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
    public partial class product_Edit : AdminPageBase
    {
        protected Lebi_Product model;
        protected int action;
        protected string t = "";
        protected int id;
        protected bool wap;
        protected void Page_Load(object sender, EventArgs e)
        {
            Random Random = new Random();
            t = RequestTool.RequestString("t");
            id = RequestTool.RequestInt("id", 0);
            model = B_Lebi_Product.GetModel(id);
            if (id == 0 || (id > 0 && t == "copy"))
            {
                if (!EX_Admin.Power("product_add", "添加商品"))
                {
                    PageNoPower();
                }
                ////如果添加商品时随机数小于9位数 重定向生成随机数 防止破坏已有数据
                //if (randnum.ToString().Length < 9)
                //{
                //    Response.Redirect(site.AdminPath + "/product/product_edit.aspx?id=" + id + "&t=" + t + "&randnum=" + Random.Next(100000000, 999999999));
                //    Response.End();
                //    return;
                //}
            }
            else
            {
                if (!EX_Admin.Power("product_edit", "编辑商品"))
                {
                    PageNoPower();
                }
                if (site.SiteCount > 1 && CurrentAdmin.Site_ids != "" && model.Site_ids != "")
                {
                    string[] psids = model.Site_ids.Split(',');
                    bool flag = false;
                    foreach (string pdis in psids)
                    {
                        if (("," + CurrentAdmin.Site_ids + ",").Contains("," + pdis + ","))
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        PageError();
                        return;
                    }
                }
            }
            action = RequestTool.RequestInt("action", 1);

            if (model == null)
            {
                model = new Lebi_Product();
                model.Type_id_ProductType = 320;
                model.Site_ids = site.Sitesid();
            }
            else
            {
                if (t == "copy")
                    model.id = 0;
            }
            wap = Ishavewap();
        }
        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Lebi_Supplier GetSupplier(int id)
        {
            Lebi_Supplier user = B_Lebi_Supplier.GetModel("id = " + id);
            if (user == null)
                user = new Lebi_Supplier();
            return user;
        }
        private bool Ishavewap()
        {
            int count = B_Lebi_Site.Counts("IsMobile=1");
            if (count > 0)
                return true;
            return false;
        }
        public int CountSon(int pid)
        {
            return B_Lebi_Product.Counts("Product_id=" + pid + " and Product_id<>0");
        }
    }
}
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
    public partial class subproduct_edit_all : AdminPageBase
    {
        protected Lebi_Product model;
        protected int action;
        protected int randnum;
        protected int id;
        protected bool wap;
        protected void Page_Load(object sender, EventArgs e)
        {
            Random Random = new Random();
            randnum = RequestTool.RequestInt("randnum",0);
            id = RequestTool.RequestInt("id",0);
            if (id == 0 || (id > 0 && randnum > 0))
            {
                if (!EX_Admin.Power("product_add", "添加商品"))
                {
                    PageNoPower();
                }
            }
            else
            {
                if (!EX_Admin.Power("product_edit", "编辑商品"))
                {
                    PageNoPower();
                }
            }
            action = RequestTool.RequestInt("action", 1);
            model = B_Lebi_Product.GetModel(id);
            if (model == null){
                model = new Lebi_Product();
                model.Type_id_ProductType = 320;
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
            Lebi_Supplier user = B_Lebi_Supplier.GetModel(id);
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
    }
}
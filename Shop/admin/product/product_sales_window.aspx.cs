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
    public partial class product_sales_window : AdminPageBase
    {
        protected string Number;
        protected List<Lebi_Order_Product> pros;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!EX_Admin.Power("product_edit", "编辑商品"))
            {
                WindowNoPower();
            }
            Number = RequestTool.RequestString("Number");
            pros = B_Lebi_Order_Product.GetList("Product_Number=lbsql{'" + Number + "'}", "");
        }
    }
}
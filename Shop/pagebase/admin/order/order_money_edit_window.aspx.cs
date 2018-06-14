using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shop.Bussiness;
using Shop.Model;
using Shop.Tools;

namespace Shop.Admin.order
{
    public partial class Order_Money_Edit_window : AdminAjaxBase
    {
        protected Lebi_Order model;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!EX_Admin.Power("order_price_edit", "编辑订单金额"))
            {
                WindowNoPower();
            }
            int id = RequestTool.RequestInt("id",0);
            model = B_Lebi_Order.GetModel(id);
            if (model == null)
                model = new Lebi_Order();
        }
    }
}
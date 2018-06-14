using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Shop.Bussiness;
using Shop.Model;
using Shop.Tools;

namespace Shop.Admin.order
{
    public partial class Print_Shipping : AdminPageBase
    {
        protected string id;
        protected Lebi_Order model;
        protected BaseConfig config;
        protected List<Lebi_Order_Product> pros;
        protected List<Lebi_Comment> comms;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!EX_Admin.Power("order_edit", "编辑订单"))
            {
                NewPageNoPower();
            }
            int id = RequestTool.RequestInt("id", 0);
            model = B_Lebi_Order.GetModel(id);
            if (model == null)
            {
                model = new Lebi_Order();
            }
            config = ShopCache.GetBaseConfig();
            pros = B_Lebi_Order_Product.GetList("Order_id=" + model.id + "", "");
            comms = B_Lebi_Comment.GetList("TableName='Order' and Keyid=" + model.id + " and User_id = "+ model.User_id +" and Admin_id = 0", "id desc");
        }
    }
}
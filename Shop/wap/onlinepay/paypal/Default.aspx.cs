using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using Shop.Model;
using Shop.Bussiness;
using Shop.Tools;


namespace Paypal
{
    public partial class _Default : ShopPage
    {
        public string OrderCode;
        public string Pid;
        public string Money;
        public string ReturnUrl;
        public string business;
        public Lebi_OnlinePay pay;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            int order_id = RequestTool.RequestInt("order_id", 0);
            Lebi_Order order = B_Lebi_Order.GetModel(order_id);
            if (order == null)
            {
                Response.Write("订单错误");
                Response.End();
                return;
            }
            pay = Shop.Bussiness.Money.GetOnlinePay(order,"paypal");
            if (pay == null)
            {
                Response.Write("系统错误");
                Response.End();
                return;
            }
            if (pay.FeeRate > 0)
            {
                order.Money_OnlinepayFee = order.Money_Pay * pay.FeeRate/100;
            }
            order.Site_id_pay = CurrentSite.id;
            B_Lebi_Order.Update(order);
            Lebi_Currency currendy = B_Lebi_Currency.GetModel(pay.Currency_id);
            business = pay.UserName;
            OrderCode = order.Code;
            Pid = order.Code;
            Money = (order.Money_Pay * currendy.ExchangeRate * (1 + (pay.FeeRate / 100))).ToString("0.00");
            
            Shop.Bussiness.Site site = new Shop.Bussiness.Site();
            ReturnUrl = "http://" + RequestTool.GetRequestDomain() + site.WebPath + "/onlinepay/paypal/ReturnUrl.aspx";

        }
    }
}

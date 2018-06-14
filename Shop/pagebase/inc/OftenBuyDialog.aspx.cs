using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shop.Model;
using Shop.Bussiness;
using Shop.Tools;

namespace Shop.inc
{
    public partial class OftenBuyDialog : Bussiness.ShopPage
    {
        protected int num;
        protected int pid;
        protected string property;
        public void LoadPage()
        {
            num = RequestTool.RequestInt("num", 1);
            pid = RequestTool.RequestInt("pid", 0);
            property = RequestTool.RequestString("property");
        }
    }
}
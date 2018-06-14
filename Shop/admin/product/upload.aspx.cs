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
    public partial class upload : AdminPageBase
    {
        protected string inputname = "";
        protected string i = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            inputname = RequestTool.RequestString("n");
            i = RequestTool.RequestString("i");
            
            if (inputname == "")
                inputname = "Images";
        }
    }
}
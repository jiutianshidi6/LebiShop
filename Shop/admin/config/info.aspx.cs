using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shop.Bussiness;
using Shop.Model;

namespace Shop.Admin
{
    public partial class Info : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected bool chkobj(string obj)
        {
            try
            {
                object meobj = Server.CreateObject(obj);
                return (true);
            }
            catch (Exception objex)
            {
                return (false);
            }
        }
    }
}
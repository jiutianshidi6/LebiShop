using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shop.Bussiness;
using Shop.Model;
using Shop.Tools;
using System.IO;
namespace Shop.Admin
{
    public partial class updatedb : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Shop.LebiAPI.Service.Instanse.UpdateDBBody();
            Response.Write("OK");
        }

    }
}
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

namespace Shop.Admin.theme
{
    public partial class part_Edit : AdminPageBase
    {
        protected string SkinContent;
        protected string FileName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!EX_Admin.Power("theme_syspart_edit", "编辑系统块"))
            {
                PageReturnMsg = PageNoPowerMsg();
            }
            if (RequestTool.GetConfigKey("OnlineFileEdit").Trim() != "1")
            {
                PageReturnMsg = PageNoEditMsg();
            }
            
            FileName = RequestTool.RequestString("file");
            FileName = FileName.Replace(".", "");
            SkinContent = GetSkinStr(FileName);
            
        }

        /// <summary>
        /// 取得一个文件的内容
        /// </summary>
        /// <param name="theme"></param>
        /// <param name="skin"></param>
        /// <returns></returns>
        private string GetSkinStr(string filename)
        {
            string str = "";
            string path = "/theme/system/" + filename;
            str = HtmlEngine.ReadTxt(path);

            return str;

        }
    }
}
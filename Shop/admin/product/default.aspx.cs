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
    public partial class default_ : AdminPageBase
    {
        protected string lang;
        protected string key;
        protected string Pro_Type_id;
        protected int status;
        protected int brand;
        protected int tag;
        protected string dateFrom;
        protected string dateTo;
        protected string OrderBy;
        protected string orderstr = "";
        protected List<Lebi_Product> models;
        protected string PageString;
        protected SearchProduct sp;
        protected int Type_id_ProductType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!EX_Admin.Power("product_list", "商品列表"))
            {
                PageNoPower();
            }
            sp = new SearchProduct(CurrentAdmin, CurrentLanguage.Code);
            PageSize = RequestTool.getpageSize(20);
            key = RequestTool.RequestString("key");
            Type_id_ProductType = RequestTool.RequestInt("Type_id_ProductType", 320);
            //Pro_Type_id = RequestTool.RequestString("Pro_Type_id");
            //status = RequestTool.RequestInt("status", 0);
            //brand = RequestTool.RequestInt("brand", 0);
            //tag = RequestTool.RequestInt("tag", 0);
            //dateFrom = RequestTool.RequestString("dateFrom");
            //dateTo = RequestTool.RequestString("dateTo");
            //OrderBy = RequestTool.RequestString("OrderBy");
            //lang = RequestTool.RequestString("lang");
            //if (lang == "")
            //    lang = "CN";
            string where = "Product_id=0";
            //if (Pro_Type_id != "")
            //    where += " and Pro_Type_id in (" + Shop.Bussiness.EX_Product.Categoryid(Pro_Type_id) + ")";
            //if (status > 0)
            //    where += " and Type_id_ProductStatus=" + status + "";
            //if (tag > 0)
            //    where += " and Pro_Tag_id=" + tag + "";
            //if (brand > 0)
            //    where += " and Brand_id=" + brand + "";
            if (key != "")
                where += " and (Name like lbsql{'%" + key + "%'} or Number like lbsql{'%" + key + "%'} or Code like lbsql{'%" + key + "%'})";
            //if (dateFrom != "" && dateTo != "")
            //    where += " and (datediff(d,Time_Add,'" + dateFrom + "')<=0 and datediff(d,Time_Add,'" + dateTo + "')>=0)";

            where += sp.SQL;
            if (domain3admin && CurrentAdmin.Site_ids != "")
            {
                string[] arr = CurrentAdmin.Site_ids.Split(',');
                string sonwhere = "";
                foreach (string sid in arr)
                {
                    if (sonwhere == "")
                        sonwhere = "','+Site_ids+',' like '%," + sid + ",%'";
                    else
                        sonwhere += " or ','+Site_ids+',' like '%," + sid + ",%'";
                }
                where += " and (" + sonwhere + " or Site_ids='')";
            }
            if (CurrentAdmin.Pro_Type_ids != "")
            {
                string[] ids = CurrentAdmin.Pro_Type_ids.Split(',');
                string sonwhere = "";
                foreach (string id in ids)
                {
                    sonwhere += " or Path like '%,"+id+",%'";
                }
                sonwhere = "select id from Lebi_Pro_Type where id in (" + CurrentAdmin.Pro_Type_ids + ")" + sonwhere;
                where += " and Pro_Type_id in (" + sonwhere + ")";

            }
            if (OrderBy == "StatusDesc")
            {
                orderstr = " Type_id_ProductStatus desc";
            }
            else if (OrderBy == "StatusAsc")
            {
                orderstr = " Type_id_ProductStatus asc";
            }
            else if (OrderBy == "ViewsDesc")
            {
                orderstr = " Count_Views desc";
            }
            else if (OrderBy == "ViewsAsc")
            {
                orderstr = " Count_Views asc";
            }
            else if (OrderBy == "SalesDesc")
            {
                orderstr = " Count_Sales desc";
            }
            else if (OrderBy == "SalesAsc")
            {
                orderstr = " Count_Sales asc";
            }
            else if (OrderBy == "CountDesc")
            {
                orderstr = " Count_Stock desc";
            }
            else if (OrderBy == "CountAsc")
            {
                orderstr = " Count_Stock asc";
            }
            else if (OrderBy == "Price_CostDesc")
            {
                orderstr = " Price_Cost desc";
            }
            else if (OrderBy == "Price_CostAsc")
            {
                orderstr = " Price_Cost asc";
            }
            else if (OrderBy == "PriceDesc")
            {
                orderstr = " Price desc";
            }
            else if (OrderBy == "PriceAsc")
            {
                orderstr = " Price asc";
            }
            else if (OrderBy == "FreezeDesc")
            {
                orderstr = " Count_Freeze desc";
            }
            else if (OrderBy == "FreezeAsc")
            {
                orderstr = " Count_Freeze asc";
            }
            else
            {
                orderstr = " id desc";
            }
            models = B_Lebi_Product.GetList(where, orderstr, PageSize, page);
            int recordCount = B_Lebi_Product.Counts(where);
            PageString = Pager.GetPaginationString("?page={0}&key=" + key + "&" + sp.URL, page, PageSize, recordCount);
            //Response.Write(where);
        }

        public int CountSon(int pid)
        {
            return B_Lebi_Product.Counts("Product_id=" + pid + " and Product_id<>0");
        }
        /// <summary>
        /// 返回某个商品分类下，所有子id的组合
        /// 逗号分隔
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void LicenseWord()
        {
            return;
            //if (!b_api.check("biaozhun") && !b_api.check("zengqiang"))
            //{
            //    response.write("<div class=\"licensealt\"><p class=\"title\">" + tag("敬告") + "：</p>");
            //    response.write("您使用的是免费系统，可录入100条主商品数据</br>");
            //    response.write("获得标准授权后可录入500条主商品数据</br>");
            //    response.write("获得增强授权可取消此限制，<a href=\"" + b_api.weburl + "/plans/\" target=\"_bank\">点此获取</a>");
            //    response.write("</div>");
            //    return;
            //}
            //if (b_api.check("biaozhun"))
            //{
            //    response.write("<div class=\"licensealt\"><p class=\"title\">" + tag("敬告") + "：</p>");
            //    response.write("您使用的是系统为标准授权，可录入500条主商品数据</br>");
            //    response.write("获得增强授权可取消此限制，<a href=\"" + b_api.weburl + "/plans/\" target=\"_bank\">点此获取</a>");
            //    response.write("</div>");
            //    return;
            //}

        }
    }
}
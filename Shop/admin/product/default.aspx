<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.product.default_" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("商品列表")%>-<%=site.title%></title>

<script src="<%=site.AdminJsPath %>/jquery-3.1.0.min.js"></script>
<script src="<%=site.AdminJsPath %>/jquery-migrate-1.2.1.js"></script>
<script src="<%=site.AdminJsPath %>/Cookies.js"></script>
<script src="<%=site.AdminJsPath %>/main.js"></script>
<script src="<%=site.AdminJsPath %>/messagebox.js"></script>
<script src="<%=site.AdminJsPath %>/master.js"></script>
<script src="<%=site.AdminJsPath %>/jquery-ui/jquery-ui.min.js"></script>
<%if (CurrentLanguage.Code=="CN"){%><script src="<%=site.AdminJsPath %>/jquery-ui/datepicker-zh-CN.js"></script><%}%>
<link rel="stylesheet" type="text/css" href="<%=site.AdminCssPath %>/css.css" />
<link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/jquery-ui/jquery-ui.min.css" />
<link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/jquery-ui/jquery-ui.theme.min.css" />
<link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/lightbox/lightbox.min.css" />
<%if (Shop.LebiAPI.Service.Instanse.Check("managelicenese")){%>
<style>#body_head #logo {width:112px;height:62px;background:url(<%=site.AdminImagePath %>/2015/logo_oem.gif) center 20px #0669c5 no-repeat;float:left;}</style>
<%}%>
<script>
    var AdminPath = "<%=site.AdminPath %>";var WebPath ="<%=site.WebPath %>";var AdminImagePath = "<%=site.AdminImagePath %>";var requestPage = "<%=Shop.Tools.RequestTool.GetRequestUrl().ToLower() %>";var refPage = "<%=Shop.Tools.RequestTool.GetUrlReferrer().ToLower() %>";
    function quit() { if (confirm("<%=Tag("您确定要退出吗？")%>")) return true; else return false; }
</script>

    <script type="text/javascript">
        $(document).ready(function(){$("li.menu ul").hide();$("li.menu").bind("mouseover",function(){$(this).find("ul").slideDown("fast")});$("li.menu ul").bind("mouseleave",function(){$(this).slideUp("fast")})});
        function roadstock(id)
        {
            $.ajax({
                type: 'POST',
                url: "<%=site.AdminPath %>/ajax/ajax_ex.aspx?__Action=productRoadStock&id="+id,
                data: '',
                dataType: 'html',
                success: function(res){
                    //document.write(res);
                    $('#rs'+id).html(res);
                }
            });
        }
    </script>
    <link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/prettyphoto/css/prettyPhoto.css" />
    <script language="javascript" type="text/javascript" src="<%=site.AdminJsPath %>/prettyphoto/jquery.prettyphoto.js"></script>
    <script type="text/javascript" src="<%=site.AdminJsPath %>/My97DatePicker/WdatePicker.js"></script> 
    <script type="text/javascript" src="<%=site.AdminJsPath %>/multiselect/js/jquery.multiselect2side.js"></script>
    <link rel="stylesheet" href="<%=site.AdminJsPath %>/multiselect/css/jquery.multiselect2side.css" type="text/css" media="screen" />
    <style>
    .headtable{width:100%}
    .headtable tr{border-bottom: 0px solid #ececec;}
    .headtable tr td{border-bottom: 0px solid #ececec;width:33%}
    .datalist .list td {
        border-bottom: 1px solid #ececec;
        color: #808080;
        line-height: 150%;
        padding: 5px 10px;
        text-align: left;
        white-space: normal;
        word-break: normal; 
        word-wrap: break-word;
    }
</style>

</head>
<body>
<div id="body_head">
  <div class="admintop">
    <div id="logo">
        <a href="<%=site.AdminPath %>/ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"></a>
        <%=LicenseString %>
    </div>
    <%=Version %>
    <div class="admininfo">
        <div id="NewEvent">
            <span><%=Tag("未确认")%></span><em><a href="<%=site.AdminPath %>/order/default.aspx?t=211&type=1"><span id="NewEvent_Order_IsVerified"><%=SYS.NewEvent_Order_IsVerified%></span></a></em>
            <span><%=Tag("已支付")%></span><em><a href="<%=site.AdminPath %>/order/default.aspx?t=211&type=4"><span id="NewEvent_Order_IsPaid"><%=SYS.NewEvent_Order_IsPaid%></span></a></em>
            <span><%=Tag("未发货")%></span><em class="noborder"><a href="<%=site.AdminPath %>/order/default.aspx?t=211&type=5"><span id="NewEvent_Order_IsShipped"><%=SYS.NewEvent_Order_IsShipped%></span></a></em>
        </div>
    </div>
    <%if (Tips()!=""){ %><div id="tips"><%=Tips() %></div><%} %>
    <div id="service">
        <div class="layout">
          <div class="adminface" onmousehover="">
            <img src="<%=CurrentAdmin.Avatar%>" alt="[<%=Lang(CurrentAdminGroup.Name)%>]<%=CurrentAdmin.UserName%>" />
          </div>
          <div class="adminfacepop">
              <a href="javascript:AdminPWD(0);"><%=Tag("改密")%></a>
              <a href="<%=site.AdminPath %>/Logout.aspx" onclick="return quit()"><%=Tag("注销")%></a>
              <a href="<%=site.WebPath %>/" target="_blank"><%=Tag("网站前台")%></a>
          </div>
        </div>
    </div>
    <div class="clearfix">
    </div>
    <div class="navmenu">
        <ul id="shopmenu" class="menu">
            <%foreach (Shop.Model.Lebi_Menu menu in TopMenus)
                { %>
            <li class="<%=CurrentTopMenu.id==menu.id?"current":"" %>"><a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=<%=menu.id %>"><span><img src="<%if (menu.Image != ""){ %><%=GetImage(site.WebPath + menu.Image) %><%}else{%><%=site.AdminImagePath%>/icon/plugin.png<%} %>" /><%=Tag(menu.Name)%></span></a> </li>
            <%} %>
        </ul>
        <ul class="menu">
            <li class="menuline"></li>
            <li><a href="javascript:void(0);" onclick="updateadmin();"><span><img src="<%=site.AdminImagePath%>/icon/reh.png" /><%=Tag("系统刷新")%></span></a></li>
            <li><a href="javascript:void(0);" onclick="UpdateCache(0);"><span><img src="<%=site.AdminImagePath%>/icon/cache.png" /><%=Tag("更新缓存")%></span></a></li>
            <li><a href="javascript:void(0);" onclick="UpdateCache(1);"><span><img src="<%=site.AdminImagePath%>/icon/data.png" /><%=Tag("数据同步")%></span></a></li>
            <li><a href="<%=site.AdminPath%>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><span><img src="<%=site.AdminImagePath%>/icon/dasktop.png" /><%=Tag("桌面") %></span></a></li>
            <li><a href="<%=site.WebPath %>/" target="_blank"><span><img src="<%=site.AdminImagePath%>/icon/web.png" /><%=Tag("网站前台")%></span></a></li>
            <li><a href="javascript:void(0);" onclick="Copyright();"><span><img src="<%=site.AdminImagePath%>/icon/about.png" /><%=Tag("关于") %></span></a></li>
        </ul>
        
    </div>
  </div>
</div>
<div id="body_content">
<div id="sidebar">
    <div class="menubar ">
        <%if (desk == 1)
            { 
        %>
        <h2><span><img src="<%=site.AdminImagePath %>/2015/minus.png" id="img1" /> <%=Tag("快捷菜单")%></span></h2>
        <ul class="clear">
            <%foreach (Shop.Model.Lebi_Menu menu in GetIndexMenus()){ %><li><a href="<%=MenuUrl(menu.URL,1) %>"><span><%=Tag(menu.Name)%></span></a></li><%}%>
        </ul>
        <% }else{ %>
        <%foreach (Shop.Model.Lebi_Menu pmenu in GetMenus(CurrentTopMenu.id)){ %>
        <h2><span><img mid="<%=pmenu.id %>" src="<%=site.AdminImagePath %>/2015/<%=MenuShow(pmenu.id)==true?"minus":"plus" %>.png" id="imgStatis" /> <%=Tag(pmenu.Name)%></span></h2>
        <ul class="clear" <%=MenuShow(pmenu.id)==true?"":"style=\"display:none;\"" %>>
            <%foreach (Shop.Model.Lebi_Menu menu in GetMenus(pmenu.Code)){ %><li><a href="<%=MenuUrl(menu.URL,0) %>"><span><%=Tag(menu.Name)%></span></a></li><%}%>
        </ul>
        <%} } %>
    </div>
</div>
<div id="sideplus">
    <a href="javascript:void()" onclick="switchSysBar()"><span class="navPoint" id="switchPoint" title="<%=Tag("关闭/打开左栏")%>"><img src="<%=site.AdminImagePath%>/2015/left.png" alt="<%=Tag("关闭/打开左栏")%>" /></span></a>
</div>
<div id="sidecontent" class="clear">
    <div class="mainbody_path" id="body_path">
      
    <div class="tools">
    <ul>
    <li class="add"><a href="javascript:void(0);" onclick="window.location='Product_Edit.aspx?Type_id_ProductType=<%=Type_id_ProductType %>'"><b></b><span><%=Tag("添加")%></span></a></li>
    <li class="del"><a href="javascript:void(0);" onclick="Product_Del();"><b></b><span><%=Tag("删除")%></span></a></li>
    <li class="up"><a href="javascript:void(0);" onclick="Product_Status_Edit_muti(1);"><b></b><span><%=Tag("上架")%></span></a></li>
    <li class="down"><a href="javascript:void(0);" onclick="Product_Status_Edit_muti(0);"><b></b><span><%=Tag("下架")%></span></a></li>
    <li class="menu"><a href="javascript:void(0);"><span><%=Tag("更多")%><s></s></span></a>
	<ul class="clearfix">
        <li class="reset"><a href="javascript:void(0);" onclick="Product_MoveCategory();"><b></b><span><%=Tag("类别")%></span></a></li>
        <li class="reset"><a href="javascript:void(0);" onclick="Product_MoveBrand();"><b></b><span><%=Tag("品牌")%></span></a></li>
        <li class="reset"><a href="javascript:void(0);" onclick="Product_MoveTag();"><b></b><span><%=Tag("标签")%></span></a></li>
        <li class="reset"><a href="javascript:void(0);" onclick="Product_Property132();"><b></b><span><%=Tag("商品属性")%></span></a></li>
         <%if (site.SiteCount > 1){ %><li class="reset"><a href="javascript:void(0);" onclick="Product_Site();"><b></b><span><%=Tag("站点")%></span></a></li><%} %>
	</ul></li>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="<%=site.AdminPath %>/product/"><%=Tag("商品列表")%></a></span></li>
    </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <% LicenseWord(); %>
    <div class="searchbox">
        <input name="key" type="text" id="key" class="input-query" value="<%=key %>" onkeydown="if(event.keyCode==13){search_();}"/><input type="button" id="btnSou" class="btn-query" onclick="search_();" align="absmiddle" />
         <div style="margin-top:5px;">
        <a href="javascript:void(0);" onclick="SearchWindow();"><%=Tag("高级搜索")%></a>
        <%=sp.Description%>
        </div>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%" border="0">
    <tr>
    <td style="width:150px;vertical-align:top">
        <table style="background: #f4f4f4" width="100%">
        <%=Lebi.ERP.other.CreateTree(0,0,CurrentLanguage.Code) %>
        </table>
    </td>
    <td style="vertical-align:top" >
    <table class="datalist">
        <tr class="title">
            <th class="selectAll" style="width: 40px">
                <a href="javascript:void(0);" onclick="$('input[name=\'productid\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));"><%=Tag("全选")%></a>
            </th>
            <th style="width: 40px">
                <%=Tag("图片")%>
            </th>
            <th style="width: 80px">
                <%=Tag("编号")%>
            </th>
            <th style="width: 80px">
                <%=Tag("规格")%>
            </th>
            <th style="">
                <%=Tag("商品名称")%>
            </th>
            <th style="width: 60px">
                <%=Tag("子商品")%>
            </th>
            <th style="width: 80px">
                <%=Tag("面价")%>     
            </th>
            <th style="width: 80px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "PriceDesc"){Response.Write("PriceAsc");}else{Response.Write("PriceDesc");}%>');" title="<%=Tag("点击排序")%>"><%if (Type_id_ProductType == 321){ %><%=Tag("抢购价")%><%}else if (Type_id_ProductType == 322){ %><%=Tag("团购价")%><%}else if (Type_id_ProductType == 323){ %><%=Tag("换购积分")%><%}else{ %><%=Tag("销售价")%><%} %><%if (OrderBy == "PriceDesc") { Response.Write("↓"); } else if (OrderBy == "PriceAsc") { Response.Write("↑"); }%></a>
            </th>
            <%if (Shop.Bussiness.EX_Admin.CheckPower("product_price_cost")){ %>
            <th style="width: 80px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "Price_CostDesc"){Response.Write("Price_CostAsc");}else{Response.Write("Price_CostDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("成本价")%><%if (OrderBy == "Price_CostDesc") { Response.Write("↓"); } else if (OrderBy == "Price_CostAsc") { Response.Write("↑"); }%></a>
            </th>
            <%} %>
            <th style="width: 40px">
                <%=Tag("单位")%>     
            </th>
            <th style="width: 60px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "CountDesc"){Response.Write("CountAsc");}else{Response.Write("CountDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("库存")%><%if (OrderBy == "CountDesc") { Response.Write("↓"); } else if (OrderBy == "CountAsc") { Response.Write("↑"); }%></a>
            </th>
            <th style="width: 60px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "FreezeDesc"){Response.Write("FreezeAsc");}else{Response.Write("FreezeDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("冻结库存")%><%if (OrderBy == "FreezeDesc") { Response.Write("↓"); } else if (OrderBy == "FreezeAsc") { Response.Write("↑"); }%></a>
            </th>
            <th style="width: 60px">
                <%=Tag("在途库存")%>
            </th>
            <th style="width: 60px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "SalesDesc"){Response.Write("SalesAsc");}else{Response.Write("SalesDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("销量")%><%if (OrderBy == "SalesDesc") { Response.Write("↓"); } else if (OrderBy == "SalesAsc") { Response.Write("↑"); }%></a>
            </th>
            <th style="width: 60px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "ViewsDesc"){Response.Write("ViewsAsc");}else{Response.Write("ViewsDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("浏览量")%><%if(OrderBy == "ViewsDesc"){Response.Write("↓");}else if (OrderBy == "ViewsAsc"){Response.Write("↑");}%></a>
            </th>
            <th style="width: 60px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "StatusDesc"){Response.Write("StatusAsc");}else{Response.Write("StatusDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("状态")%><%if (OrderBy == "StatusDesc") { Response.Write("↓"); } else if (OrderBy == "StatusAsc") { Response.Write("↑"); }%></a>
            </th>
            <th style="width: 60px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "SortDesc"){Response.Write("SortAsc");}else{Response.Write("SortDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("排序")%><%if (OrderBy == "SortDesc") { Response.Write("↓"); } else if (OrderBy == "SortAsc") { Response.Write("↑"); }%></a>
            </th>
            <%if (Type_id_ProductType == 321)
              { %>
            <th style="width: 140px">
                <%=Tag("截止日期")%>
            </th>
            <%} %>
            <th style="width: 100px">
                <%=Tag("操作")%>
            </th>
        </tr>
        <%
        decimal Total_Price_Market = 0;
        decimal Total_Price = 0;
        decimal Total_Price_Cost = 0;
        int Total_Count_Stock = 0;
        int Total_Count_Freeze = 0;
        int Total_Count_Sales = 0;
        int Total_Count_Views = 0;
        int Total_StockFreeze = 0;
        foreach (Shop.Model.Lebi_Product model in models)
        {
        int Count_Stock = Shop.Bussiness.EX_Product.ProductStockForAdmin(model);
        Total_Price_Market += model.Price_Market*Count_Stock;
        string Price = "";
        if (model.Type_id_ProductType == 321 || model.Type_id_ProductType == 322){
        Price = FormatMoney(model.Price_Sale).ToString();
        Total_Price += model.Price_Sale*Count_Stock;
        }else if (model.Type_id_ProductType == 323){
        Price = model.Price_Sale.ToString();
        }else{
        Price = FormatMoney(model.Price).ToString();
        Total_Price += model.Price*Count_Stock;
        }
        Total_Price_Cost += model.Price_Cost*Count_Stock;
        Total_Count_Stock += Count_Stock;
        Total_Count_Freeze += model.Count_Freeze;
        Total_Count_Sales += model.Count_Sales;
        Total_Count_Views += model.Count_Views;
        int StockFreeze = Lebi.ERP.Store.ProductStockFreeze(model);
        Total_StockFreeze += StockFreeze;
        %>
        <script type="text/javascript">
            $(document).ready(function () {
                $("area[rel^='prettyPhoto<%=model.id %>']").prettyPhoto();
                $(".piclist<%=model.id %>:first a[rel^='prettyPhoto<%=model.id %>']").prettyPhoto({ animation_speed: 'fast', slideshow: 10000, hideflash: true });
            })
        </script>
            <tr class="list" ondblclick="Edit(<%=model.id %>,0);">
                <td style="text-align:center">
                    <input type="checkbox" ShopKeyID="true" name="productid" id="<%=model.id %>" value="<%=model.id %>" />
                </td>
                <td>
                    <div class="piclist<%=model.id %>">
                    <a href="<%=Image(model.ImageOriginal,"big") %>" rel="prettyPhoto<%=model.id %>[]" target="_blank"><img style="height: 30px;width: 30px;vertical-align:middle" src="<%=Image(model.ImageOriginal,50,50) %>" /></a>
                    </div>
                </td>
                <td>
                    <%=model.Number%>
                </td>
                <td>
                    <%=model.Code%>
                </td>
                <td style="<%=model.IsCombo==1?"color:blue":""%>"><%=Shop.Tools.Utils.GetUnicodeSubString(Lang(model.Name), 50, "...")%>&nbsp;<%if (model.Supplier_id > 0)
                                                 { %><a href="?Supplier_id=<%=model.Supplier_id %>" title="<%=Tag("商家")%>：<%=Shop.Bussiness.EX_Supplier.GetSupplier(model.Supplier_id).Company%>"><img src="<%=AdminImage("icon/supplier.png") %>" /></a>&nbsp;<%} %>
                <a target="_blank" href="<%=Shop.Bussiness.ThemeUrl.GetURL("P_Product",model.id.ToString(),"",CurrentLanguage.Code)%>" title="<%=Lang(model.Name) %>"><img src="<%=AdminImage("icon/newWindow.png") %>" /></a>
                
                </td>
                <td>
                    <a href="subproduct_edit.aspx?id=<%=model.id %>" title="<%=Tag("编辑")%>"><%=CountSon(model.id)%></a>
                </td>
                <td>
                    <%=FormatMoney(model.Price_Market)%>
                </td>
                <td>
                    <%=Price%>
                </td>
                <%if (Shop.Bussiness.EX_Admin.CheckPower("product_price_cost")){ %>
                <td>
                    <%=FormatMoney(model.Price_Cost)%>
                </td>
                <%}%>
                <td>
                    <%=Lang(Lebi.ERP.other.ProudctUnit(model.Units_id))%>
                </td>
                <td>
                    <%=Count_Stock%>
                </td>
                <td>
                    <a href="javascript:void(0)" onclick="Product_Freeze('<%=model.id %>');" title="<%=Tag("查看")%>"><%=StockFreeze%></a>
                </td>
                <td id="rs<%=model.id%>">
                    <script type="text/javascript">
                        roadstock(<%=model.id%>);
                    </script>
                </td>
                <td>
                    <a href="javascript:void(0)" onclick="Product_Sales('<%=model.Number %>');" title="<%=Tag("查看")%>"><%=model.Count_Sales %></a>
                </td>
                <td>
                    <%=model.Count_Views%>
                </td>
                <td>
                    <span id="ProductStatus<%=model.id %>">
                        <%=Tag(Shop.Bussiness.EX_Type.TypeName(model.Type_id_ProductStatus)) %>
                    </span><input type="hidden" id="Type_id_ProductStatus<%=model.id %>" value="<%=model.Type_id_ProductStatus %>" />
                </td>
                <td>
                    <%=model.Sort%>
                </td>
                <%if (Type_id_ProductType == 321)
                  { %>
                <td>
                    <%if (model.Time_Expired < DateTime.Now)
                      { %><span class="red"><%=Tag("已结束")%></span><%}
                      else
                      { %><%=model.Time_Expired%><%} %>
                </td>
                <%} %>
                <td>
                    <a href="javascript:void(0)" onclick="Edit(<%=model.id %>,0);"><%=Tag("编辑")%></a> | <a href="javascript:void(0)" onclick="Edit(<%=model.id %>,1);"><%=Tag("复制")%></a>
                    <%if (Shop.LebiAPI.Service.Instanse.Check("plugin_productlimit")){%> | <a href="javascript:void(0)" onclick="ProductLimit(<%=model.id %>,'<%=Lang(model.Name)%>');"><%=Tag("权限")%></a><%} %>
                </td>
            </tr>
        <%} %>
        <tr class="list">
            <td colspan="6" style="text-align:right;font-weight:bold"><%=Tag("合计")%></td>
            <td style="font-weight:bold"><%=FormatMoney(Total_Price_Market)%></td>
            <td style="font-weight:bold"><%=FormatMoney(Total_Price)%></td>
            <%if (Shop.Bussiness.EX_Admin.CheckPower("product_price_cost")){ %>
            <td style="font-weight:bold"><%=FormatMoney(Total_Price_Cost)%></td>
            <%} %>
            <td>&nbsp;</td>
            <%if (Shop.Bussiness.EX_Admin.CheckPower("product_price_cost")){ %>
            <td style="font-weight:bold"><%=Total_Count_Stock%></td>
            <%} %>
            <td style="font-weight:bold"><%=Total_StockFreeze%></td>
            <td style="font-weight:bold">&nbsp;</td>
            <td style="font-weight:bold"><%=Total_Count_Sales%></td>
            <td style="font-weight:bold"><%=Total_Count_Views%></td>
            <td colspan="4">&nbsp;</td>
        </tr>
    </table>
        </td>
        </tr>
        </table>
    <script type="text/javascript">
       
        function search_(scurl) {
            var key = $("#key").val();
            //window.location = "?key=" + escape(key) + "&OrderBy=<%=OrderBy%>&Type_id_ProductType=<%=Type_id_ProductType %>&"+scurl;
            window.location = "?key=" + escape(key) + "&OrderBy=<%=OrderBy%>&"+scurl;
        }
        function Edit(id,type) {
            var url = "product_edit.aspx?id=" + id;
            if (type == 1)
                url += "&t=copy"
            //window.location = url;
            window.open(url);
        }
        function OrderBy(url) {
            url+='&key='+escape('<%=key%>')+'&<%=sp.URL%>';
            MsgBox(4, "<%=Tag("正在排序，请稍后")%> ……", url);
        }
        function Product_Status(id) {
            var Type_id_ProductStatus = $("#Type_id_ProductStatus" + id).val();
            var url = "<%=site.AdminPath %>/ajax/ajax_product.aspx?__Action=Product_Status&id=" + id + "&Status="+ Type_id_ProductStatus;
            RequestAjax(url,"",function(){if (Type_id_ProductStatus == 101) {$("#ProductStatus" + id).html("<%=Tag("下架")%>");$("#Type_id_ProductStatus" + id).val(100);}else if (Type_id_ProductStatus == 100) {$("#ProductStatus" + id).html("<%=Tag("上架")%>");$("#Type_id_ProductStatus" + id).val(101);};MsgBox(1, "<%=Tag("操作成功")%>", "")});
        }
        function Product_Del() {
            if (!confirm("<%=Tag("确认要删除吗？")%>"))
                return false;
            var postData = GetFormJsonData("ShopKeyID");
            var url = "<%=site.AdminPath %>/ajax/ajax_product.aspx?__Action=Product_Del&father=1";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function Product_Status_Edit_muti(status) {
            var postData = GetFormJsonData("ShopKeyID");
            var action = $("#action").val();
            var url = "<%=site.AdminPath %>/ajax/ajax_product.aspx?__Action=Product_Status_Edit_muti&father=1&status=" + status;
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function Product_Sales(number) {
            var title_ = "<%=Tag("销量")%>"; 
            var height_ = 300;
            var url_ = "product_sales_window.aspx?number=" + number;
            var width_ = 650;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Product_MoveCategory() {
            $("li.menu ul").hide();
            var ids = GetChkCheckedValues("productid");
            if (ids == ""){
                MsgBox(2, "<%=Tag("请选择要修改的商品")%>", "");
                return;
            }
            var title_ = "<%=Tag("商品类别")%>"; 
            var height_ = 300;
            var url_ = "product_category_edit_window.aspx?ids="+ids+"";
            var width_ = 650;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Product_MoveBrand() {
            $("li.menu ul").hide();
            var ids = GetChkCheckedValues("productid");
            if (ids == ""){
                MsgBox(2, "<%=Tag("请选择要修改的商品")%>", "");
                return;
            }
            var title_ = "<%=Tag("商品品牌")%>"; 
            var height_ = 150;
            var url_ = "product_brand_edit_window.aspx?ids="+ids+"";
            var width_ = 500;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Product_MoveTag() {
            $("li.menu ul").hide();
            var ids = GetChkCheckedValues("productid");
            if (ids == ""){
                MsgBox(2, "<%=Tag("请选择要修改的商品")%>", "");
                return;
            }
            var title_ = "<%=Tag("商品标签")%>"; 
            var height_ = 200;
            var url_ = "product_tag_edit_window.aspx?ids="+ids+"";
            var width_ = 600;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Product_Freeze(id) {
            var title_ = "<%=Tag("冻结库存")%>"; 
            var url_ = "product_freeze_window.aspx?id=" + id;
            var width_ = 560;
            var height_ = "auto";
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function SearchWindow() {
            var title_ = "<%=Tag("商品查询")%>";
            var url_ = "product_search_window.aspx?callback=search_&<%=sp.URL %>";
            var width_ = 700;
            var height_ = 505;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Product_Site(){
            $("li.menu ul").hide();
            var ids = GetChkCheckedValues("productid");
            if (ids == ""){
                MsgBox(2, "<%=Tag("请选择要修改的商品")%>", "");
                return;
            }
            var title_ = "<%=Tag("编辑站点")%>";
            var url_ = "product_site_edit_window.aspx?ids="+ids+"";
            var width_ = 500;
            var height_ = 150;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Product_Property() {
            $("li.menu ul").hide();
            var ids = GetChkCheckedValues("productid");
            if (ids == ""){
                MsgBox(2, "<%=Tag("请选择要修改的商品")%>", "");
                return;
            }
            var title_ = "<%=Tag("商品规格")%>"; 
            var height_ = 500;
            var url_ = "product_property_edit_window.aspx?ids="+ids+"";
            var width_ = 1000;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Product_Property132() {
            $("li.menu ul").hide();
            var ids = GetChkCheckedValues("productid");
            if (ids == ""){
                MsgBox(2, "<%=Tag("请选择要修改的商品")%>", "");
                return;
            }
            var title_ = "<%=Tag("商品属性")%>"; 
            var height_ = 500;
            var url_ = "product_property132_edit_window.aspx?ids="+ids+"";
            var width_ = 1000;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function searchproduct(id)
        {
            var scurl='<%=sp.URL %>';
            scurl=scurl.replace("Pro_Type_id","uuu1");
            scurl=scurl+'&Pro_Type_id='+id;
            search_(scurl);
        }
        function ProductLimit(id,name){
            window.open("<%=site.AdminPath %>/product/productlimit_user.aspx?proid="+id);
            return;
            var title_ = "<%=Tag("商品权限")%>-"+name;
            var url_ = "<%=site.AdminPath %>/user/productlimit_window.aspx?productid="+id;
            var width_ = 900;
            var height_ = 750;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_, 'selectproduct');
        }
    </script>
    <script src="<%=WebPath%>/plugin/Lebi.ERP/js/tree.js" type="text/javascript"></script>

          <%}else{%>
            <%=PageReturnMsg%>
          <%}%>
        </div>
    </div>
    
<div class="bottom" id="body_bottom">
    <%=PageString%>
</div>

    <div id="body_foot">
        <div class="foot">
            <div class="copy" id="lebicopy">
                <asp:Label ID="LBLicense" runat="server"></asp:Label>
            </div>
            <div class="lang">
                <ul class="droplang">
                    <li class="lang_li"><a class="noclick">
                        <%int langi = 0;
                          if (CurrentAdminLanguage.Name == "")
                            {%><%=Tag("语言选择")%><%}else{%><%=CurrentAdminLanguage.Name%><%} %></a>
                        <dl class="lang_li_content">
                            <%foreach (Shop.Model.Lebi_Language_Code langc in langs)
                              {
                                  langi++; if (langi== langs.Count)
                                  {%>
                            <dd class="last"><%}
                                  else
                                  {%><dd><%} %>
                            <a href="javascript:SetLanguage('<%=langc.Code %>','<%=langc.Name %>');"><%=langc.Name %></a></dd>
                                  <%} %>
                        </dl>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>
</div>
<div id="sound"></div>
<script src="<%=site.AdminJsPath %>/lightbox/lightbox.min.js"></script>
<script>
    function Copyright() {
        var title_ = "<%=Tag("关于")%>";
        var url_ = "<%=site.AdminPath %>/Config/Copyright_window.aspx";
        var width_ = 500;
        var height_ = 'auto';
        var modal_ = true;
        EditWindow(title_, url_, width_, height_, modal_);
    }
    function UpdateCache(type) {
        var postData = ""; 
        if (type == 0){
            postData = {'datatype':'languagetag,producttype,config,themepage'};
        }else{
            postData = {'datatype':'dbbody,lebitype,lebimenu,lebipage'};
        }
        var url = "<%=site.AdminPath %>/ajax/ajax_db.aspx?__Action=CacheReset";
        RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "")});
    }
    function updateadmin(){
        var url="<%=site.AdminPath %>/ajax/ajax_site.aspx?__Action=UpdateAdmin";
        RequestAjax(url,"",function(res){RequestAjax("<%=site.AdminPath %>/ajax/ajax_db.aspx?__Action=CacheReset","{'datatype':'dbbody'}",function(){MsgBox(1, "<%=Tag("操作成功")%>", "")});});
    }
    function NewEvent(){
        GetNewEvent();
        setTimeout(function(){NewEvent();},<%=SYS.NewEventTimes%>);
    }
    function PlayAudio(){
        <%if (config.NewEventPlayAudio=="1"){%>
        $('#sound').html('<audio autoplay="autoplay"><source src="<%=site.AdminImagePath %>/msg.mp3" type="audio/mpeg"><source src="<%=site.AdminImagePath %>/msg.wav" type="audio/wav"></audio>');
        <%}%>
    }
    setTimeout(function(){NewEvent();},<%=LeftNewEventTimes%>);
</script>
</body>
</html>
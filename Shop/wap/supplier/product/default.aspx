<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.supplier.product.default_" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("商品列表")%>-<%=site.title%></title>

<link rel="stylesheet" type="text/css" href="<%=site.AdminCssPath %>/css.css" />
<script type="text/javascript" src="<%=site.AdminJsPath %>/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="<%=site.AdminJsPath %>/ajaxfileupload.js"></script>
<script type="text/javascript" src="<%=site.AdminJsPath %>/main.js"></script>
<script type="text/javascript" src="<%=site.AdminJsPath %>/messagebox.js"></script>
<script type="text/javascript" src="<%=site.AdminJsPath %>/Cookies.js"></script>
<script type="text/javascript" src="<%=site.AdminJsPath %>/jquery-ui.min.js"></script>
<script type="text/javascript" src="<%=site.WebPath %>/Editor/ckeditor/ckeditor.js"></script>
<script type="text/javascript" src="<%=site.WebPath %>/Editor/ckfinder/ckfinder.js"></script>
<script type="text/javascript" src="<%=site.AdminJsPath %>/master.js"></script>
<link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/jqueryuicss/redmond/jquery-ui.css" />
<script type="text/javascript" src="<%=site.AdminJsPath %>/multiselect/js/jquery.multiselect2side.js"></script>
<link rel="stylesheet" href="<%=site.AdminJsPath %>/multiselect/css/jquery.multiselect2side.css" type="text/css" media="screen" />
<script type="text/javascript">
    var AdminPath = "<%=site.AdminPath %>";var WebPath ="<%=site.WebPath %>";var AdminImagePath = "<%=site.AdminImagePath %>";var requestPage = "<%=Shop.Tools.RequestTool.GetRequestUrl().ToLower() %>";var refPage = "<%=Shop.Tools.RequestTool.GetUrlReferrer().ToLower() %>";
    function quit() { if (confirm("<%=Tag("您确定要退出吗？")%>")) return true; else return false; }
    </script>
</head>
<body>
<div id="body_head">
    <div id="logo">
      <span><a href="<%=site.AdminPath %>/ajax/ajax_supplier.aspx?__Action=MenuJump&pid=0"><%=Lang(CurrentSupplier.Name)%></a></span>
    </div>
    <div id="service">
        <div class="layout">
          <span><em><%=Tag("您好！")%></em>[<%=CurrentSupplier.SubName%>|<%=CurrentSupplierUserGroup.Name%>]<%=CurrentSupplierUser.RemarkName%>&nbsp;&nbsp;<a href="<%=site.AdminPath %>/config/password.aspx"><%=Tag("改密")%></a>&nbsp;|&nbsp;<a href="<%=site.AdminPath %>/Logout.aspx" onclick="return quit()"><%=Tag("注销")%></a>&nbsp;|&nbsp;<a href="<%=Shop.Bussiness.ThemeUrl.GetURL("P_ShopIndex",CurrentSupplier.id.ToString(),"",CurrentLanguage.Code) %>" target="_blank"><%=Tag("网站前台")%></a></span>
        </div>
    </div>
    <div class="clearfix">
    </div>
    <div class="navmenu">
        <ul class="menu">
            <%foreach (Shop.Model.Lebi_Supplier_Menu menu in TopMenus)
                { %>
            <li class="<%=CurrentTopMenu.id==menu.id?"current":"" %>"><a href="<%=site.AdminPath %>/Ajax/ajax_supplier.aspx?__Action=MenuJump&pid=<%=menu.id %>"><span><%if (menu.Image != ""){ %><img src="<%=GetImage(site.WebPath + menu.Image) %>" height="15px" /><%} %><%=Tag(menu.Name)%></span></a> </li>
            <%} %>
        </ul>
        <%=lbmenu%>
    </div>
</div>
<div id="body_content">
<div id="sidebar">
    <div class="menubar ">
        <%if (desk == 1)
            { 
        %>
        <h2><span><img src="<%=site.AdminImagePath %>/minus.gif" id="img1" /> <%=Tag("快捷菜单")%></span></h2>
        <ul class="clear">
            <%foreach (Shop.Model.Lebi_Supplier_Menu menu in GetIndexMenus()){ %><li><a href="<%=MenuUrl(menu.URL,1) %>"><span><%=Tag(menu.Name)%></span></a></li><%}%>
        </ul>
        <% }else{ %>
        <%foreach (Shop.Model.Lebi_Supplier_Menu pmenu in GetMenus(CurrentTopMenu.id)){ %>
        <h2><span><img mid="<%=pmenu.id %>" src="<%=site.AdminImagePath %>/<%=MenuShow(pmenu.id)==true?"minus":"plus" %>.gif" id="imgStatis" /> <%=Tag(pmenu.Name)%></span></h2>
        <ul class="clear" <%=MenuShow(pmenu.id)==true?"":"style=\"display:none;\"" %>>
            <%foreach (Shop.Model.Lebi_Supplier_Menu menu in GetMenus(pmenu.id)){ %><li><a href="<%=MenuUrl(menu.URL,0) %>"><span><%=Tag(menu.Name)%></span></a></li><%}%>
        </ul>
        <%} } %>
    </div>
</div>
<div id="sideplus">
    <a onclick="switchSysBar()"><span class="navPoint" id="switchPoint" title="<%=Tag("关闭/打开左栏")%>"><img src="<%=site.AdminImagePath%>/vertical/left.png" alt="<%=Tag("关闭/打开左栏")%>" /></span></a>
</div>
<div id="sidecontent" class="clear">
    <div class="mainbody_path" id="body_path">
      
    <div class="tools">
    <ul>
    <li class="add"><a href="javascript:void(0);" onclick="window.location='Product_Edit.aspx'"><b></b><span><%=Tag("添加")%></span></a></li>
    <li class="del"><a href="javascript:void(0);" onclick="Product_Del();"><b></b><span><%=Tag("删除")%></span></a></li>
    <li class="down"><a href="javascript:void(0);" onclick="Product_Status_Edit_muti(0);"><b></b><span><%=Tag("下架")%></span></a></li>
    <li class="reset"><a href="javascript:void(0);" onclick="Product_MoveCategory();"><b></b><span><%=Tag("类别")%></span></a></li>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="<%=site.AdminPath %>/product/"><%=Tag("商品列表")%></a></span></li>
    </ul>
    </div>

    </div>
      
      
    <div class="mainbody" id="body_main">
        <div id="body_main_form" style="min-width:1200px;width:100%">
          
    <link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/prettyphoto/css/prettyPhoto.css" />
    <script language="javascript" type="text/javascript" src="<%=site.AdminJsPath %>/prettyphoto/jquery.prettyphoto.js"></script>
    <script type="text/javascript" src="<%=site.AdminJsPath %>/My97DatePicker/WdatePicker.js"></script> 
    <% LicenseWord(); %>
    <div class="searchbox">
        <input name="key" type="text" id="key" class="input-query" value="<%=key %>"/><input type="button" id="btnSou" class="btn-query" onclick="search_();" align="absmiddle" />
         <div style="margin-top:5px;">
        <a href="javascript:void(0);" onclick="SearchWindow();"><%=Tag("高级搜索")%></a>
        <%=sp.Description%>
        </div>
    </div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" id="list" class="datalist">
        <tr class="title">
            <th width="40" class="selectAll">
                <a href="javascript:void(0);" onclick="$('input[name=\'sonproductid\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));"><%=Tag("全选")%></a>
            </th>
            <th width="40">
                <%=Tag("图片")%>
            </th>
            <th width="80">
                <%=Tag("编号")%>
            </th>
            <th width="*">
                <%=Tag("商品名称")%>
            </th>
            <th width="60">
                <%=Tag("子商品")%>
            </th>
            <th width="80">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "PriceDesc"){Response.Write("PriceAsc");}else{Response.Write("PriceDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("销售价")%><%if (OrderBy == "PriceDesc") { Response.Write("↓"); } else if (OrderBy == "PriceAsc") { Response.Write("↑"); }%></a>
            </th>
            <th width="80">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "Price_CostDesc"){Response.Write("Price_CostAsc");}else{Response.Write("Price_CostDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("成本价")%><%if (OrderBy == "Price_CostDesc") { Response.Write("↓"); } else if (OrderBy == "Price_CostAsc") { Response.Write("↑"); }%></a>
            </th>
            <th width="60">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "CountDesc"){Response.Write("CountAsc");}else{Response.Write("CountDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("库存")%><%if (OrderBy == "CountDesc") { Response.Write("↓"); } else if (OrderBy == "CountAsc") { Response.Write("↑"); }%></a>
            </th>
            <th width="60">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "FreezeDesc"){Response.Write("FreezeAsc");}else{Response.Write("FreezeDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("冻结库存")%><%if (OrderBy == "FreezeDesc") { Response.Write("↓"); } else if (OrderBy == "FreezeAsc") { Response.Write("↑"); }%></a>
            </th>
            <th width="60">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "SalesDesc"){Response.Write("SalesAsc");}else{Response.Write("SalesDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("销量")%><%if (OrderBy == "SalesDesc") { Response.Write("↓"); } else if (OrderBy == "SalesAsc") { Response.Write("↑"); }%></a>
            </th>
            <th width="60">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "ViewsDesc"){Response.Write("ViewsAsc");}else{Response.Write("ViewsDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("浏览量")%><%if(OrderBy == "ViewsDesc"){Response.Write("↓");}else if (OrderBy == "ViewsAsc"){Response.Write("↑");}%></a>
            </th>
            <th width="60">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "StatusDesc"){Response.Write("StatusAsc");}else{Response.Write("StatusDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("状态")%><%if (OrderBy == "StatusDesc") { Response.Write("↓"); } else if (OrderBy == "StatusAsc") { Response.Write("↑"); }%></a>
            </th>
            <th width="100">
                <%=Tag("操作")%>
            </th>
        </tr>
        <%foreach (Shop.Model.Lebi_Product model in models)
          {%>
        <script type="text/javascript">
            $(document).ready(function () {
                $("area[rel^='prettyPhoto<%=model.id %>']").prettyPhoto();
                $(".piclist<%=model.id %>:first a[rel^='prettyPhoto<%=model.id %>']").prettyPhoto({ animation_speed: 'fast', slideshow: 10000, hideflash: true });
            })
        </script>
            <tr class="list" ondblclick="Edit(<%=model.id %>,0);">
                <td align="center">
                    <input type="checkbox" ShopKeyID="true" name="sonproductid" id="<%=model.id %>" value="<%=model.id %>" />
                </td>
                <td>
                    <div class="piclist<%=model.id %>">
                    <a href="<%=site.WebPath + model.ImageBig %>" rel="prettyPhoto<%=model.id %>[]" target="_blank"><img style="height: 30px;width: 30px;vertical-align:middle" src="<%=site.WebPath + model.ImageSmall %>" /></a>
                    </div>
                </td>
                <td>
                    <%=model.Number%>
                </td>
                <td><%=Shop.Tools.Utils.GetUnicodeSubString(Lang(model.Name), 50, "...")%>&nbsp;<a target="_blank" href="<%=Shop.Bussiness.ThemeUrl.GetURL("P_Product",model.id.ToString(),"",CurrentLanguage.Code)%>"><img src="<%=PageImage("icon/newWindow.png")%>" /></a>
                
                </td>
                <td>
                    <a href="subproduct_edit.aspx?id=<%=model.id %>" title="<%=Tag("编辑")%>"><%=CountSon(model.id)%></a>
                </td>
                <td>
                    <%=FormatMoney(model.Price)%>
                </td>
                <td>
                    <%=FormatMoney(model.Price_Cost)%>
                </td>
                <td>
                    <%=model.Count_Stock%>
                </td>
                <td>
                    <a href="javascript:void(0)" onclick="Product_Freeze('<%=model.Number %>');" title="<%=Tag("查看")%>"><%=model.Count_Freeze%></a>
                </td>
                <td>
                    <a href="javascript:void(0)" onclick="Product_Sales('<%=model.Number %>');" title="<%=Tag("查看")%>"><%=model.Count_Sales_Show %></a>
                </td>
                <td>
                    <%=model.Count_Views_Show%>
                </td>
                <td title="<%=Tag("点击更改属性")%>" style="cursor:pointer" onclick="Product_Status(<%=model.id %>);">
                    <span id="ProductStatus<%=model.id %>">
                        <%=Tag(Shop.Bussiness.EX_Type.TypeName(model.Type_id_ProductStatus)) %>
                    </span><input type="hidden" id="Type_id_ProductStatus<%=model.id %>" value="<%=model.Type_id_ProductStatus %>" />
                </td>
                <td>
                    <a href="javascript:void(0)" onclick="Edit(<%=model.id %>,0);"><%=Tag("编辑")%></a> 
                </td>
            </tr>
        <%} %>
    </table>
    <script type="text/javascript">
        function search_(scurl) {
            var key = $("#key").val();
            window.location = "?key=" + escape(key) + "&OrderBy=<%=OrderBy%>&"+scurl;
        }
        function Edit(id,type) {
            var url = "product_edit.aspx?id=" + id;
            window.location = url;
        }
        function OrderBy(url) {
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
            var url = "<%=site.AdminPath %>/ajax/ajax_product.aspx?__Action=Product_Del";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function Product_Status_Edit_muti(status) {
            var postData = GetFormJsonData("ShopKeyID");
            var action = $("#action").val();
            var url = "<%=site.AdminPath %>/ajax/ajax_product.aspx?__Action=Product_Status_Edit_muti&status=" + status;
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
        function Product_Freeze(number) {
            var title_ = "<%=Tag("冻结库存")%>"; 
            var height_ = 300;
            var url_ = "product_freeze_window.aspx?number=" + number;
            var width_ = 560;
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
        function Product_MoveCategory() {
            $("li.menu ul").hide();
            var ids = GetChkCheckedValues("sonproductid");
            if (ids == ""){
                MsgBox(2, "<%=Tag("请选择要修改的商品")%>", "");
                return;
            }
            var title_ = "<%=Tag("商品类别")%>"; 
            var height_ = 230;
            var url_ = "Supplier_ProductType_edit_window.aspx?ids="+ids+"";
            var width_ = 400;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
    </script>

        </div>
    </div>
    
<div class="bottom" id="body_bottom">
    <%=PageString%>
</div>

</div>
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
                      if (CurrentLanguage.Name == "")
                        {%><%=Tag("语言选择")%><%}else{%><%=CurrentLanguage.Name%><%} %></a>
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
<script type="text/javascript">
    function Copyright() {
        var title_ = "<%=Tag("关于")%>";
        var url_ = "<%=site.AdminPath %>/Config/Copyright_window.aspx";
        var width_ = 500;
        var height_ = 310;
        var modal_ = true;
        EditWindow(title_, url_, width_, height_, modal_);
    }
</script>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.order.Default" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title>
        <%=Tag("订单管理")%>-<%=site.title%></title>

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
            <%if (PageReturnMsg == ""){%>
            <li class="del"><a href="javascript:void(0);" onclick="Del();"><b></b><span><%=Tag("删除")%></span></a></li>
            <li class="add"><a href="javascript:void(0);" onclick="AddOrder();"><b></b><span><%=Tag("添加订单")%></span></a></li>
            <li class="print"><a href="javascript:void(0);" onclick="Express_Log_Add();"><b></b><span><%=Tag("添加至快递单")%></span></a></li>
<%
            List<Shop.Model.Lebi_AdminSkin> skins = Shop.Bussiness.B_Lebi_AdminSkin.GetList("Type_id_AdminSkinType = 361", "Sort desc");
            foreach (Shop.Model.Lebi_AdminSkin skin in skins)
            {
                Response.Write("<li class=\"print\"><a href=\"javascript:void(0);\" onclick=\"AdminSkin('"+ skin.Code +"');\"><b></b><span>"+ skin.Name +"</span></a></li>");
            }
            if (Shop.LebiAPI.Service.Instanse.Check("plugin_ordercsv")){ 
                Response.Write("<li class=\"import\"><a href=\"javascript:void(0);\" onclick=\"Export();\"><b></b><span>"+ Tag("导出") +"</span></a></li>");
            }
 %>
            <%}%>
            <li class="name"><span id="navIgation">
                <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <%=Tag("订单管理")%> > <a href="<%=site.AdminPath %>/order/default.aspx?t=<%=t %>"><%=Shop.Bussiness.EX_Type.TypeName(t) %></a></span> </li>
        </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <div class="mainbody_top">
        <ul class="tablist">
            <li <%if (type==""){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=">
                <span>
                    <%=Tag("全部订单")%></span></a></li>
            <li <%if (type=="1"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=1">
                <span>
                    <%=Tag("未确认")%></span></a></li>
            <li <%if (type=="2"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=2">
                <span>
                    <%=Tag("已确认")%></span></a></li>
            <%if (t == 211)
              {%>
            <li <%if (type=="3"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=3">
                <span>
                    <%=Tag("未支付")%></span></a></li>
            <li <%if (type=="4"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=4">
                <span>
                    <%=Tag("已支付")%></span></a></li>
            <li <%if (type=="5"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=5">
                <span>
                    <%=Tag("未发货")%></span></a></li>
            <li <%if (type=="6"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=6">
                <span>
                    <%=Tag("已发货")%></span></a></li>
            <li <%if (type=="7"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=7">
                <span>
                    <%=Tag("部分发货")%></span></a></li>
            <li <%if (type=="8"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=8">
                <span>
                    <%=Tag("未收货")%></span></a></li>
            <li <%if (type=="9"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=9">
                <span>
                    <%=Tag("已收货")%></span></a></li>
            <%} %>
            <li <%if (type=="10"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=10">
                <span>
                    <%=Tag("已完成")%></span></a></li>
            <li <%if (type=="11"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=11">
                <span>
                    <%=Tag("无效订单")%></span></a></li>
            <li <%if (type=="12"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=12">
                <span>
                    <%=Tag("申请取消")%></span></a></li>
            <li <%if (type=="13"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=13">
                <span>
                    <%=Tag("已取消")%></span></a></li>
        </ul>
    </div>

    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <div class="searchbox">
        <label><input type="radio" name="mark" value="0" <%if (mark == "0"){Response.Write("checked");} %> />
        <img src="<%=AdminImage("mark/0.png")%>" height="12" /></label>
        <label><input type="radio" name="mark" value="1" <%if (mark == "1"){Response.Write("checked");} %> />
        <img src="<%=AdminImage("mark/1.png")%>" height="12" /></label>
        <label><input type="radio" name="mark" value="2" <%if (mark == "2"){Response.Write("checked");} %> />
        <img src="<%=AdminImage("mark/2.png")%>" height="12" /></label>
        <label><input type="radio" name="mark" value="3" <%if (mark == "3"){Response.Write("checked");} %> />
        <img src="<%=AdminImage("mark/3.png")%>" height="12" /></label>
        <label><input type="radio" name="mark" value="4" <%if (mark == "4"){Response.Write("checked");} %> />
        <img src="<%=AdminImage("mark/4.png")%>" height="12" /></label>
        <label><input type="radio" name="mark" value="5" <%if (mark == "5"){Response.Write("checked");} %> />
        <img src="<%=AdminImage("mark/5.png")%>" height="12" /></label>&nbsp;
        <input type="text" name="dateFrom" id="dateFrom" size="12" class="input-calendar" value="<%=dateFrom %>" />
        -
        <input type="text" name="dateTo" id="dateTo" size="12" class="input-calendar" value="<%=dateTo %>" />
        <input type="text" id="key" name="key" class="input-query"value="<%=key %>" onkeydown="if(event.keyCode==13){search_();}" /><input type="button" id="btnSou" class="btn-query" onclick="search_();" />
        <div style="margin-top:5px;">
        <a href="javascript:void(0);" onclick="SearchWindow();"><%=Tag("高级搜索")%></a>
        <%=su.Description%>
        </div>
    </div>
    <table class="datalist">
        <tr class="title">
            <th style="width: 40px" class="selectAll">
                <a href="javascript:void(0);" onclick="$('input[name=\'id\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));">
                    <%=Tag("全选")%></a>
            </th>
            <th width="80px">
                <%=Tag("操作")%>
            </th>
            <th width="110px">
                <%=Tag("订单编号")%>
            </th>
            <th width="110px">
                <%=Tag("配送点")%>
            </th>
            <th width="100px">
                <%=Tag("会员")%>
            </th>
            <th width="100px">
                <%=Tag("购买人")%>
            </th>
            <th width="80px">
                <%=Tag("金额")%>
            </th>
            <th width="80px">
                <%=Tag("运费")%>
            </th>
            <th>
                <%=Tag("订单状态")%>
            </th>
            <th width="120px">
                <%=Tag("支付方式")%>
            </th>
            <th width="120px">
                <%=Tag("配送方式")%>
            </th>
            <th width="130px">
                <%=Tag("订购日期")%>
            </th>
            <%if (domain3admin)
              { %>
            <th style="width: 70px">
               <%=Tag("站点") %> 
            </th>
            <%} %>
        </tr>
        <%int Mark = 0;foreach (Shop.Model.Lebi_Order model in models){
        if (model.Mark !=0){
        Mark=model.Mark;
        }else{
        Mark=0;
        }
        %>
        <tr class="list" ondblclick="Edit(<%=model.id %>,<%=model.Type_id_OrderType %>);">
            <td style="text-align:center">
                <input type="checkbox" name="id" value="<%=model.id %>" del="true" />
            </td>
            <td>
                <div class="menu">
                <a target="_blank" href="<%=model.Type_id_OrderType==212?"t":"" %>order_view.aspx?id=<%=model.id %>"><img src="<%=PageImage("icon/newWindow.png")%>" /></a> <a href="javascript:void(0);" onmouseover="GetAdminSkin('<%=model.id %>');" class="showmenu"><img src=<%=AdminImage("icon/Print.png")%> /></a><%if (model.Remark_Admin !=""){ %> <a onmouseover="GetOrderMemo('<%=model.id %>');" class="showmenu"><img src="<%=AdminImage("mark/"+Mark+".png")%>" /></a><%}else{%><img src="<%=AdminImage("mark/"+Mark+".png")%>" /><%}%>
	            <div id="submenu<%=model.id %>" class="submenu"></div>
                </div>
            </td>
            <td>
                <a target="_blank" href="<%=model.Type_id_OrderType==212?"t":"" %>order_view.aspx?id=<%=model.id %>"><%=model.Code %></a><%if (model.Supplier_id > 0){ %>&nbsp;
                <a href="?t=<%=t %>&Supplier_id=<%=model.Supplier_id %>" title="<%=Tag("商家")%>：<%=Shop.Bussiness.EX_Supplier.GetSupplier(model.Supplier_id).Company%>">
                <img src="<%=AdminImage("icon/supplier.png")%>" /></a><%} %>
            </td>
            <td>
                <%
                Shop.Model.Lebi_Supplier_Delivery ps=Shop.Bussiness.B_Lebi_Supplier_Delivery.GetModel(model.Supplier_Delivery_id);
                if(ps!=null)
                Response.Write(ps.Name);
                %>
            </td>
            <td>
                <%=model.User_UserName %>
            </td>
            <td>
                <%=model.T_Name %>
            </td>
            <td>
                <%=FormatMoney(model.Money_Order) %>
            </td>
            <td>
                <%=FormatMoney(model.Money_Transport) %>
            </td>
            <td>
                <%=Shop.Bussiness.Order.OrderStatus(model, CurrentLanguage.Code, 1) %>
            </td>
            <td>
                <%=Shop.Bussiness.Language.Content(model.Pay, CurrentLanguage.Code)%>&nbsp;
            </td>
            <td>
                <%=model.Transport_Name%>&nbsp;
            </td>
            <td>
                <%=FormatTime(model.Time_Add) %>
            </td>
             <%if (domain3admin)
              { %>
            <td><%=SiteName(model.Site_id) %></td>
            <%} %>
        </tr>
        <%
        if (model.DT_id>0){
        %>
        <tr class="list">
            <td colspan="13">
                <%=Tag("分销商")%>：
                <%
                Shop.Model.Lebi_DT dt = Shop.Bussiness.B_Lebi_DT.GetModel(model.DT_id);
                Response.Write(dt.UserName);
                %>
                &nbsp;&nbsp;<%=Tag("佣金")%>：<%=FormatMoney(model.DT_Money) %>
            </td>
        </tr>
        <%} %>
        <%} %>
    </table>
    <script type="text/javascript">
        $(document).ready(function () {
            var li = $(".datalist .menu");
            $(li).each(function (i) {
                var _this = this;
                $(_this).find(".showmenu").mouseover(function () {
                    $(".datalist .menu .submenu").hide();
                    var divindex = $(".datalist .menu").find(".submenu")[i];
                    $(divindex).show();
                    $(divindex).mouseleave(function () {
                        $(divindex).hide();
                    });
                });
            });
        });
        function search_(scurl) {
            var mark = GetRadioCheckedValues("mark");
            var key = $("#key").val();
            var dateFrom = $("#dateFrom").val();
            var dateTo = $("#dateTo").val();
            if(scurl==undefined || scurl=='')
                scurl='<%=su.URL %>';
            window.location = "?t=<%=t%>&type=<%=type%>&mark="+ mark +"&key=" + escape(key) + "&dateFrom=" + dateFrom + "&dateTo=" + dateTo+"&"+scurl;
        }
        function Edit(id,t) {
            if(t==211)
            window.open("order_view.aspx?id=" + id);
            else
            window.open("torder_view.aspx?id=" + id);
        }
        function Del() {
            if (!confirm("<%=Tag("确认要删除吗？")%>"))
                return false;
            var ids = GetChkCheckedValues("id");
            var postData = { "ids": ids };
            var url = "<%=site.AdminPath %>/ajax/ajax_order.aspx?__Action=Order_Del";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function AddOrder()
        {
            var title_ = "添加订单";
            var url_ = "<%=site.AdminPath %>/order/order_add_window.aspx";
            var width_ = 300;
            var height_ = "auto";
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Express_Log_Add() {
            var ids = GetChkCheckedValues("id");
            var postData = { "ids": ids };
            var url = "<%=site.AdminPath %>/ajax/ajax_order.aspx?__Action=Express_Log_Add";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "Express_Log.aspx")});
        }
        function AdminSkin(code){
            var ids = GetChkCheckedValues("id");
            if (ids == ""){
                MsgBox(2, "<%=Tag("请先选择")%>", "");
                return;
            }
            window.open("<%=site.AdminPath %>/custom/" + code + ".aspx?id=" + ids);
        }
        <%if (Shop.LebiAPI.Service.Instanse.Check("plugin_ordercsv")){  %>
        function Export(){
            var ids = GetChkCheckedValues("id");
            if (ids == ""){
                MsgBox(2, "<%=Tag("请先选择")%>", "");
                return;
            }
            var title_ = "<%=Tag("批量导出")%>";
            var url_ = "<%=site.AdminPath %>/plugin/Lebi.OrderCsv/export_window.aspx?ids="+ids+"";
            var width_ = 400;
            var height_ = "auto";
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        <%} %>
        function SearchWindow() {
            var title_ = "<%=Tag("订单查询")%>";
            var url_ = "order_search_window.aspx?callback=search_&<%=su.URL %>";
            var width_ = 500;
            var height_ = 500;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
    </script>

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
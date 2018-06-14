<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.Default" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("管理首页")%>-<%=site.title%></title>
    <style>
        #body_path, #body_bottom{height: 0;overflow: hidden;display: none;}
    </style>

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
      
    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
   <script language="javascript" type="text/javascript" src="<%=site.AdminJsPath %>/highcharts/highcharts.js"></script>
   <script language="javascript" type="text/javascript" src="<%=site.AdminJsPath %>/highcharts/themes/grid.js"></script>
   <div id="main_index">
    <div class="admindefault">
        <div class="at">
                <%=Tag("今日业务量")%>
        </div>
        <div class="list">
                <%=Tag("订单总数")%>
                <a href="<%=site.AdminPath %>/order/default.aspx?dateFrom=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&dateTo=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>"><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.ToString("yyyy-MM-dd"), System.DateTime.Now.ToString("yyyy-MM-dd"), "Type_id_OrderType = 211")%></a>
        </div>
        <div class="list">
                <%=Tag("退货订单总数")%>
                <a href="<%=site.AdminPath %>/order/default.aspx?t=212&dateFrom=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&dateTo=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>"><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.ToString("yyyy-MM-dd"), System.DateTime.Now.ToString("yyyy-MM-dd"), "Type_id_OrderType = 212")%></a>
        </div>
        <div class="list">
                <%=Tag("未确认订单")%>
                <a href="<%=site.AdminPath %>/order/default.aspx?dateFrom=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&dateTo=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&type=1"><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.ToString("yyyy-MM-dd"), System.DateTime.Now.ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsVerified = 0 and IsInvalid = 0")%></a>
        </div>
        <div class="list">
                <%=Tag("未支付订单")%>
                <a href="<%=site.AdminPath %>/order/default.aspx?dateFrom=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&dateTo=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&type=3"><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.ToString("yyyy-MM-dd"), System.DateTime.Now.ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsVerified = 1 and IsPaid = 0 and IsInvalid = 0")%></a>
        </div>
        <div class="list">
                <%=Tag("未发货订单")%>
                <a href="<%=site.AdminPath %>/order/default.aspx?dateFrom=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&dateTo=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&type=5"><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.ToString("yyyy-MM-dd"), System.DateTime.Now.ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsVerified = 1 and IsShipped = 0 and IsInvalid = 0")%></a>
        </div>
        <div class="list">
                <%=Tag("未收货订单")%>
                <a href="<%=site.AdminPath %>/order/default.aspx?dateFrom=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&dateTo=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&type=8"><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.ToString("yyyy-MM-dd"), System.DateTime.Now.ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsVerified = 1 and IsReceived = 0 and IsInvalid = 0")%></a>
        </div>
        <div class="list">
                <%=Tag("站内信")%>
                <a href="<%=site.AdminPath %>/user/Message.aspx?dateFrom=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&dateTo=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&type=0"><%=Shop.Bussiness.Message.GetCount_Message(System.DateTime.Now.ToString("yyyy-MM-dd"), System.DateTime.Now.ToString("yyyy-MM-dd"), "User_id_To = 0")%></a>
        </div>
        <div class="list">
                <%=Tag("商品评价")%>
                <a href="<%=site.AdminPath %>/product/Comment.aspx?dateFrom=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&dateTo=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>"><%=Shop.Bussiness.Comment.GetCount_Comment(System.DateTime.Now.ToString("yyyy-MM-dd"), System.DateTime.Now.ToString("yyyy-MM-dd"), "TableName = 'Product'")%></a>
        </div>
        <div class="list">
                <%=Tag("新增会员")%>
                <a href="<%=site.AdminPath %>/user/default.aspx?dateFrom=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&dateTo=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&datetype=1"><%=Shop.Bussiness.EX_User.GetCount_User(System.DateTime.Now.ToString("yyyy-MM-dd"), System.DateTime.Now.ToString("yyyy-MM-dd"), "",0)%></a>
        </div>
        <div class="list">
                <%=Tag("过生日会员")%>
                <a href="<%=site.AdminPath %>/user/default.aspx?dateFrom=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&dateTo=<%=System.DateTime.Now.ToString("yyyy-MM-dd")%>&datetype=3"><%=Shop.Bussiness.EX_User.GetCount_User(System.DateTime.Now.ToString("yyyy-MM-dd"), System.DateTime.Now.ToString("yyyy-MM-dd"), "",1)%></a>
        </div>
        <div class="clear"></div>
    </div>

    <div style="border-top:1px solid #ddd;border-bottom:1px solid #ddd;">
    <script type="text/javascript">
    var chart;
    $(document).ready(function() {
    chart = new Highcharts.Chart({
    chart: {renderTo: 'container',reflow:false,borderColor:'#ffffff',borderRadius:'3',borderWidth:'0'},
    title: {text: '<%=Tag("订单统计") %>',align: 'left',x: 5,style:{font: '14px "Trebuchet MS", Verdana, sans-serif'}},
    subtitle: {text: ''},
    xAxis: {categories: [<%var i = 1;for(i=1; i<=15; i++){%>'<a href=Order/default.aspx?dateFrom=<%=System.DateTime.Now.AddDays(-15+i).ToString("yyyy-MM-dd") %>&dateTo=<%=System.DateTime.Now.AddDays(-15+i).ToString("yyyy-MM-dd") %>><%=System.DateTime.Now.AddDays(-15+i).Month.ToString()%>-<%=System.DateTime.Now.AddDays(-15+i).Day.ToString()%></a>'<%if (i <15){Response.Write(", ");} %><%} %>],lineWidth:1},
    yAxis: {min: 0,title: {text: ''},lineWidth:1},
    legend: {align: 'center',x:0,y:-159,floating: true,shadow: true,verticalAlign: 'middle',borderWidth:0},
    tooltip: {},
    plotOptions: {column: {pointPadding: 1,borderWidth: 0}},
        series: [
        {name: '<%=Tag("未确认") %>',data: [<%for(i=1; i<=15; i++){%><%=FormatMoney(Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-15+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-15+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 0 and IsInvalid = 0"),"Number") %><%if (i <15){Response.Write(", ");} %><%} %>]}, 
        {name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=15; i++){%><%=FormatMoney(Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-15+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-15+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 0"),"Number") %><%if (i <15){Response.Write(", ");} %><%} %>]}, 
        {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=15; i++){%><%=FormatMoney(Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-15+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-15+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 1 and IsPaid = 1 and IsInvalid = 0"),"Number") %><%if (i <15){Response.Write(", ");} %><%} %>]},
        {name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=15; i++){%><%=FormatMoney(Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-15+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-15+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 1 and IsShipped = 0 and IsInvalid = 0"),"Number") %><%if (i <15){Response.Write(", ");} %><%} %>]},
        {name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=15; i++){%><%=FormatMoney(Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-15+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-15+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 1 and IsShipped = 1"),"Number") %><%if (i <15){Response.Write(", ");} %><%} %>]},
        {name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=15; i++){%><%=FormatMoney(Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-15+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-15+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 1 and IsReceived = 1 and IsInvalid = 0"),"Number") %><%if (i <15){Response.Write(", ");} %><%} %>]},
        {name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=15; i++){%><%=FormatMoney(Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-15+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-15+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 1 and IsCompleted = 1"),"Number") %><%if (i <15){Response.Write(", ");} %><%} %>]}]
    });});
    </script>
    <div id="container" style="width: 100%; height: 352px; *height:348px; _height:348px; margin: 0 auto"></div>
    </div>
    <div class="clear"></div>
   <div class="float_yestoday">
    <table class="table">
        <tr>
            <th colspan="2" class="head">
                <%=Tag("昨日业务量")%>
            </th>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("订单总数")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/order/default.aspx?dateFrom=<%=System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")%>&dateTo=<%=System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")%>"><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211")%></a>
            </td>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("已确认订单")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/order/default.aspx?dateFrom=<%=System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")%>&dateTo=<%=System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")%>&type=2"><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsVerified = 1 and IsInvalid = 0")%></a>
            </td>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("已支付订单")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/order/default.aspx?dateFrom=<%=System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")%>&dateTo=<%=System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")%>&type=4"><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsVerified = 1 and IsPaid = 1 and IsInvalid = 0")%></a>
            </td>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("已发货订单")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/order/default.aspx?dateFrom=<%=System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")%>&dateTo=<%=System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")%>&type=6"><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsVerified = 1 and IsShipped = 1 and IsInvalid = 0")%></a>
            </td>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("已收货订单")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/order/default.aspx?dateFrom=<%=System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")%>&dateTo=<%=System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")%>&type=9"><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsVerified = 1 and IsReceived = 1 and IsInvalid = 0")%></a>
            </td>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("已完成订单")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/order/default.aspx?dateFrom=<%=System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")%>&dateTo=<%=System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")%>&type=10"><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsVerified = 1 and IsCompleted = 1")%></a>
            </td>
        </tr>
    </table>
    </div>

    <div class="float_new">
    <table class="table">
        <tr>
            <th colspan="2" class="head">
                <%=Tag("待处理事务")%>
            </th>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("未确认订单")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/order/default.aspx?type=1"><%=Shop.Bussiness.Order.GetCount_Order("", "", "Type_id_OrderType = 211 and IsVerified = 0 and IsInvalid = 0")%></a>
            </td>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("未支付订单")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/order/default.aspx?type=3"><%=Shop.Bussiness.Order.GetCount_Order("", "", "Type_id_OrderType = 211 and IsVerified = 1 and IsPaid = 0 and IsInvalid = 0")%></a>
            </td>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("未发货订单")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/order/default.aspx?type=5"><%=Shop.Bussiness.Order.GetCount_Order("", "", "Type_id_OrderType = 211 and IsVerified = 1 and IsShipped = 0 and IsInvalid = 0")%></a>
            </td>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("未收货订单")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/order/default.aspx?type=8"><%=Shop.Bussiness.Order.GetCount_Order("", "", "Type_id_OrderType = 211 and IsVerified = 1 and IsReceived = 0 and IsInvalid = 0")%></a>
            </td>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("站内信")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/user/Message.aspx?type=0"><%=Shop.Bussiness.Message.GetCount_Message("", "", "User_id_To = 0")%></a>
            </td>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("商品评价")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/product/Comment.aspx?status=280"><%=Shop.Bussiness.Comment.GetCount_Comment("", "", "TableName = 'Product' and Status = 280")%></a>
            </td>
        </tr>
    </table>
    </div>
    <div class="float_total">
    <table class="table">
        <tr>
            <th colspan="2" class="head">
                <%=Tag("数据统计")%>
            </th>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("上架商品总数")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/product/default.aspx?status=101"><%=Shop.Bussiness.EX_Product.GetCount_Product("", "", "Type_id_ProductStatus = 101 and Product_id = 0")%></a>
            </td>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("下架商品总数")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/product/default.aspx?status=100"><%=Shop.Bussiness.EX_Product.GetCount_Product("", "", "Type_id_ProductStatus = 100 and Product_id = 0")%></a>
            </td>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("订单总数")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/order/default.aspx"><%=Shop.Bussiness.Order.GetCount_Order("", "", "Type_id_OrderType = 211")%></a>
            </td>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("会员总数")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/user/default.aspx"><%=Shop.Bussiness.EX_User.GetCount_User("", "", "",0)%></a>
            </td>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("站内信总数")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/user/Message.aspx"><%=Shop.Bussiness.Message.GetCount_Message("", "", "")%></a>
            </td>
        </tr>
        <tr class="list">
            <th>
                <%=Tag("商品评价总数")%>
            </th>
            <td>
                <a href="<%=site.AdminPath %>/product/Comment.aspx"><%=Shop.Bussiness.Comment.GetCount_Comment("", "", "TableName = 'Product'")%></a>
            </td>
        </tr>
    </table>
    </div>
    <div class="clear"></div>

        <%=serviceinfo%>
    
    </div>
    <script type="text/javascript">
        function CheckVersion() {
            var postData = '';
            var url = "<%=site.AdminPath %>/ajax/ajax_service.aspx?__Action=CheckVersion";
            $.ajax({
                type: "POST",
                url: url,
                data: postData,
                dataType: "json",
                success: function (res) {
                    //                    if (res.count > 0)
                    //                        $("#versiona").show();
                    //                    else
                    //                        $("#versiona").hide();
                }
            });

        }
        $(function () {
            CheckVersion();
        });
        
    </script>

          <%}else{%>
            <%=PageReturnMsg%>
          <%}%>
        </div>
    </div>
    
<div class="bottom" id="body_bottom">
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
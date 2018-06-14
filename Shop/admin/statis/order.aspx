<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.statis.order" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("订单统计")%>-<%=site.title%></title>

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

   <script language="javascript" type="text/javascript" src="<%=site.AdminJsPath %>/highcharts/highcharts.js"></script>
   <script language="javascript" type="text/javascript" src="<%=site.AdminJsPath %>/highcharts/exporting.js"></script>
   <script language="javascript" type="text/javascript" src="<%=site.AdminJsPath %>/highcharts/themes/grid.js"></script>
    <style>#body_bottom{height:0;overflow:hidden;display:none}</style>

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
    <li class="export"><a href="javascript:void(0);" onclick="Export();"><b></b><span><%=Tag("导出")%></span></a></li>
    <%}%>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="<%=site.AdminPath %>/statis/order.aspx"><%=Tag("订单统计")%></a></span></li>
    </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <div class="searchbox clear">
        <ul class="tabmenus">
            <li<%if (type == 0){ %> class="current"<%} %>><a href="order.aspx?time=<%=time %>"><span><%=Tag("销售额")%></span></a></li>
            <li<%if (type == 1){ %> class="current"<%} %>><a href="order.aspx?type=1&time=<%=time %>"><span><%=Tag("订单数")%></span></a></li>
        </ul>
    </div>
    <div class="mod-tab">
    <ul class="tablist">
        <li <%if (time==0){Response.Write("class=\"selected\"");} %>><a href="?time=0&type=<%=type %>"><span><%=Tag("今日")%></span></a></li>
        <li <%if (time==1){Response.Write("class=\"selected\"");} %>><a href="?time=1&type=<%=type %>"><span><%=Tag("昨日")%></span></a></li>
        <li <%if (time==2){Response.Write("class=\"selected\"");} %>><a href="?time=2&type=<%=type %>"><span><%=Tag("最近7日")%></span></a></li>
        <li <%if (time==3){Response.Write("class=\"selected\"");} %>><a href="?time=3&type=<%=type %>"><span><%=Tag("最近30日")%></span></a></li>
    </ul>
    </div>
    <%if (type == 0){ %>
    <%if (time == 0){ %>
    <script type="text/javascript">
    var chart;
    $(document).ready(function() {
    chart = new Highcharts.Chart({
    chart: {type: 'spline',renderTo: 'container',reflow:false,borderColor:'#C4D8ED',borderRadius:'3',borderWidth:'1'},
    title: {text: '<%=Tag("订单统计") %>',align: 'left',x: 5,style:{font: 'bold 12px "Trebuchet MS", Verdana, sans-serif'}},
    subtitle: {text: ''},
    xAxis: {categories: [<%var i = 1;for(i=1; i<=24; i++){%>'<%=(i-1)%>:00'<%if (i <24){Response.Write(", ");} %><%} %>],lineWidth:1},
    yAxis: {min: 0,title: {text: ''},lineWidth:1},
    tooltip: {crosshairs: true,shared: true},
    plotOptions: {column: {pointPadding: 1,borderWidth: 0}},
    series: [{name: '<%=Tag("未确认") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsShipped = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsShipped = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsReceived = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsCompleted = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}]
    });});
    </script>
    <%} %>
    <%if (time == 1){ %>
    <script type="text/javascript">
    var chart;
    $(document).ready(function() {
    chart = new Highcharts.Chart({
    chart: {type: 'spline',renderTo: 'container',reflow:false,borderColor:'#C4D8ED',borderRadius:'3',borderWidth:'1'},
    title: {text: '<%=Tag("订单统计") %>',align: 'left',x: 5,style:{font: 'bold 12px "Trebuchet MS", Verdana, sans-serif'}},
    subtitle: {text: ''},
    xAxis: {categories: [<%var i = 1;for(i=1; i<=24; i++){%>'<%=(i-1)%>:00'<%if (i <24){Response.Write(", ");} %><%} %>],lineWidth:1},
    yAxis: {min: 0,title: {text: ''},lineWidth:1},
    tooltip: {crosshairs: true,shared: true},
    plotOptions: {column: {pointPadding: 1,borderWidth: 0}},
    series: [{name: '<%=Tag("未确认") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsShipped = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsShipped = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsReceived = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsCompleted = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}]
    });});
    </script>
    <%} %>
    <%if (time == 2){ %>
    <script type="text/javascript">
    var chart;
    $(document).ready(function() {
    chart = new Highcharts.Chart({
    chart: {type: 'spline',renderTo: 'container',reflow:false,borderColor:'#C4D8ED',borderRadius:'3',borderWidth:'1'},
    title: {text: '<%=Tag("订单统计") %>',align: 'left',x: 5,style:{font: 'bold 12px "Trebuchet MS", Verdana, sans-serif'}},
    subtitle: {text: ''},
    xAxis: {categories: [<%var i = 1;for(i=1; i<=7; i++){%>'<%=System.DateTime.Now.AddDays(-7+i).Month.ToString()%>-<%=System.DateTime.Now.AddDays(-7+i).Day.ToString()%>'<%if (i <7){Response.Write(", ");} %><%} %>],lineWidth:1},
    yAxis: {min: 0,title: {text: ''},lineWidth:1},
    //legend: {align: 'center',x:0,y:-179,floating: true,shadow: true,verticalAlign: 'middle',borderWidth:0},
    tooltip: {crosshairs: true,shared: true},
    plotOptions: {column: {pointPadding: 1,borderWidth: 0}},
    series: [{name: '<%=Tag("未确认") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 0") %><%if (i <7){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 0") %><%if (i <7){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 1") %><%if (i <7){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsShipped = 0") %><%if (i <7){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsShipped = 1") %><%if (i <7){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsReceived = 1") %><%if (i <7){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsCompleted = 1") %><%if (i <7){Response.Write(", ");} %><%} %>]}]
    });});
    </script>
    <%} %>
    <%if (time == 3){ %>
    <script type="text/javascript">
    var chart;
    $(document).ready(function() {
    chart = new Highcharts.Chart({
    chart: {type: 'spline',renderTo: 'container',reflow:false,borderColor:'#C4D8ED',borderRadius:'3',borderWidth:'1'},
    title: {text: '<%=Tag("订单统计") %>',align: 'left',x: 5,style:{font: 'bold 12px "Trebuchet MS", Verdana, sans-serif'}},
    subtitle: {text: ''},
    xAxis: {categories: [<%var i = 1;var m = 1;for(i=1; i<=30; i++){%>'<%if (System.DateTime.Now.AddDays(-30+i).Month.ToString()==System.DateTime.Now.Month.ToString()){%><%if (m == 1){ %><%=System.DateTime.Now.Month.ToString() %>m<%}else{ %><%=System.DateTime.Now.AddDays(-30+i).Day.ToString()%><%} %><%m=m+1; %><%}else{%><%=System.DateTime.Now.AddDays(-30+i).Day.ToString()%><%} %>'<%if (i <30){Response.Write(", ");} %><%} %>],lineWidth:1},
    yAxis: {min: 0,title: {text: ''},lineWidth:1},
    //legend: {align: 'center',x:0,y:-179,floating: true,shadow: true,verticalAlign: 'middle',borderWidth:0},
    tooltip: {crosshairs: true,shared: true},
    plotOptions: {column: {pointPadding: 1,borderWidth: 0}},
    series: [{name: '<%=Tag("未确认") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 0") %><%if (i <30){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 0") %><%if (i <30){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 1") %><%if (i <30){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsShipped = 0") %><%if (i <30){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsShipped = 1") %><%if (i <30){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsReceived = 1") %><%if (i <30){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsCompleted = 1") %><%if (i <30){Response.Write(", ");} %><%} %>]}]
    });});
    </script>
    <%} %>
    <%} %>
    <%if (type == 1){ %>
    <%if (time == 0){ %>
    <script type="text/javascript">
    var chart;
    $(document).ready(function() {
    chart = new Highcharts.Chart({
    chart: {type: 'spline',renderTo: 'container',reflow:false,borderColor:'#C4D8ED',borderRadius:'3',borderWidth:'1'},
    title: {text: '<%=Tag("订单统计") %>',align: 'left',x: 5,style:{font: 'bold 12px "Trebuchet MS", Verdana, sans-serif'}},
    subtitle: {text: ''},
    xAxis: {categories: [<%var i = 1;for(i=1; i<=24; i++){%>'<%=(i-1)%>:00'<%if (i <24){Response.Write(", ");} %><%} %>],lineWidth:1},
    yAxis: {min: 0,title: {text: ''},lineWidth:1},
    tooltip: {crosshairs: true,shared: true},
    plotOptions: {column: {pointPadding: 1,borderWidth: 0}},
    series: [{name: '<%=Tag("未确认") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsShipped = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsShipped = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsReceived = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsCompleted = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}]
    });});
    </script>
    <%} %>
    <%if (time == 1){ %>
    <script type="text/javascript">
    var chart;
    $(document).ready(function() {
    chart = new Highcharts.Chart({
    chart: {type: 'spline',renderTo: 'container',reflow:false,borderColor:'#C4D8ED',borderRadius:'3',borderWidth:'1'},
    title: {text: '<%=Tag("订单统计") %>',align: 'left',x: 5,style:{font: 'bold 12px "Trebuchet MS", Verdana, sans-serif'}},
    subtitle: {text: ''},
    xAxis: {categories: [<%var i = 1;for(i=1; i<=24; i++){%>'<%=(i-1)%>:00'<%if (i <24){Response.Write(", ");} %><%} %>],lineWidth:1},
    yAxis: {min: 0,title: {text: ''},lineWidth:1},
    tooltip: {crosshairs: true,shared: true},
    plotOptions: {column: {pointPadding: 1,borderWidth: 0}},
    series: [{name: '<%=Tag("未确认") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsShipped = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsShipped = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsReceived = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsCompleted = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}]
    });});
    </script>
    <%} %>
    <%if (time == 2){ %>
    <script type="text/javascript">
    var chart;
    $(document).ready(function() {
    chart = new Highcharts.Chart({
    chart: {type: 'spline',renderTo: 'container',reflow:false,borderColor:'#C4D8ED',borderRadius:'3',borderWidth:'1'},
    title: {text: '<%=Tag("订单统计") %>',align: 'left',x: 5,style:{font: 'bold 12px "Trebuchet MS", Verdana, sans-serif'}},
    subtitle: {text: ''},
    xAxis: {categories: [<%var i = 1;for(i=1; i<=7; i++){%>'<%=System.DateTime.Now.AddDays(-7+i).Month.ToString()%>-<%=System.DateTime.Now.AddDays(-7+i).Day.ToString()%>'<%if (i <7){Response.Write(", ");} %><%} %>],lineWidth:1},
    yAxis: {min: 0,title: {text: ''},lineWidth:1},
    //legend: {align: 'center',x:0,y:-179,floating: true,shadow: true,verticalAlign: 'middle',borderWidth:0},
    tooltip: {crosshairs: true,shared: true},
    plotOptions: {column: {pointPadding: 1,borderWidth: 0}},
    series: [{name: '<%=Tag("未确认") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 0") %><%if (i <7){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 0") %><%if (i <7){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 1") %><%if (i <7){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsShipped = 0") %><%if (i <7){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsShipped = 1") %><%if (i <7){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsReceived = 1") %><%if (i <7){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsCompleted = 1") %><%if (i <7){Response.Write(", ");} %><%} %>]}]
    });});
    </script>
    <%} %>
    <%if (time == 3){ %>
    <script type="text/javascript">
    var chart;
    $(document).ready(function() {
    chart = new Highcharts.Chart({
    chart: {type: 'spline',renderTo: 'container',reflow:false,borderColor:'#C4D8ED',borderRadius:'3',borderWidth:'1'},
    title: {text: '<%=Tag("订单统计") %>',align: 'left',x: 5,style:{font: 'bold 12px "Trebuchet MS", Verdana, sans-serif'}},
    subtitle: {text: ''},
    xAxis: {categories: [<%var i = 1;var m = 1;for(i=1; i<=30; i++){%>'<%if (System.DateTime.Now.AddDays(-30+i).Month.ToString()==System.DateTime.Now.Month.ToString()){%><%if (m == 1){ %><%=System.DateTime.Now.Month.ToString() %>m<%}else{ %><%=System.DateTime.Now.AddDays(-30+i).Day.ToString()%><%} %><%m=m+1; %><%}else{%><%=System.DateTime.Now.AddDays(-30+i).Day.ToString()%><%} %>'<%if (i <30){Response.Write(", ");} %><%} %>]},
    yAxis: {min: 0,title: {text: ''}},
    tooltip: {crosshairs: true,shared: true},
    plotOptions: {column: {pointPadding: 1,borderWidth: 0}},
    series: [{name: '<%=Tag("未确认") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 0") %><%if (i <30){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 0") %><%if (i <30){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsPaid = 1") %><%if (i <30){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsShipped = 0") %><%if (i <30){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsShipped = 1") %><%if (i <30){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsReceived = 1") %><%if (i <30){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsCompleted = 1") %><%if (i <30){Response.Write(", ");} %><%} %>]}]
    });});
    </script>
    <%} %>
    <%} %>
    <div id="container" style="margin:0 auto;width: 98%;"></div>
    <table class="datalist">
        <tr class="title">
            <th>
            <%
            switch(time) {
                case 0:
                    Response.Write(Tag("时间"));
                    break;
                case 1:
                    Response.Write(Tag("时间"));
                    break;
                case 2:
                    Response.Write(Tag("日期"));
                    break;
                case 3:
                    Response.Write(Tag("日期"));
                    break;
            } 
            %></th>
            <th><%=Tag("未确认") %></th>
            <th><%=Tag("未支付") %></th>
            <th><%=Tag("已支付")%></th>
            <th><%=Tag("未发货")%></th>
            <th><%=Tag("已发货")%></th>
            <th><%=Tag("已收货")%></th>
            <th><%=Tag("已完成")%></th>
        </tr>
    <%if (type == 0)
      { %>
    <%if (time == 0)
      { %>
      <%var i = 1;for(i=1; i<=24; i++){%>
        <tr class="list">
            <td><%=i-1 %>:00</td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 0",i-1) %></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsPaid = 0", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsPaid = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsShipped = 0", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsShipped = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsReceived = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsCompleted = 1", i - 1)%></td>
        </tr>
      <%} %>
      <%} %>
    <%if (time == 1)
      { %>
      <%var i = 1;for(i=1; i<=24; i++){%>
        <tr class="list">
            <td><%=i-1 %>:00</td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 0",i-1) %></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsPaid = 0", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsPaid = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsShipped = 0", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsShipped = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsReceived = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsCompleted = 1", i - 1)%></td>
        </tr>
      <%} %>
      <%} %>
    <%if (time == 2)
      { %>
      <%var i = 1;for(i=1; i<=7; i++){%>
        <tr class="list">
            <td><%=System.DateTime.Now.AddDays(-7+i).Month.ToString()%>-<%=System.DateTime.Now.AddDays(-7+i).Day.ToString()%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsVerified = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsPaid = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsPaid = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsShipped = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsShipped = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsReceived = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsCompleted = 1")%></td>
        </tr>
      <%} %>
      <%} %>
    <%if (time == 3)
      { %>
      <%var i = 1;for(i=1; i<=30; i++){%>
        <tr class="list">
            <td><%=System.DateTime.Now.AddDays(-30+i).Month.ToString()%>-<%=System.DateTime.Now.AddDays(-30 + i).Day.ToString()%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsVerified = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsPaid = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsPaid = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsShipped = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsShipped = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsReceived = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsCompleted = 1")%></td>
        </tr>
      <%} %>
      <%} %>
      <%} %>
    <%if (type == 1)
      { %>
    <%if (time == 0)
      { %>
      <%var i = 1;for(i=1; i<=24; i++){%>
        <tr class="list">
            <td><%=i-1 %>:00</td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 0",i-1) %></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsPaid = 0", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsPaid = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsShipped = 0", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsShipped = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsReceived = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsCompleted = 1", i - 1)%></td>
        </tr>
      <%} %>
      <%} %>
    <%if (time == 1)
      { %>
      <%var i = 1;for(i=1; i<=24; i++){%>
        <tr class="list">
            <td><%=i-1 %>:00</td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Type_id_OrderType = 211 and IsVerified = 0",i-1) %></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsPaid = 0", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsPaid = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsShipped = 0", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsShipped = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsReceived = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsCompleted = 1", i - 1)%></td>
        </tr>
      <%} %>
      <%} %>
    <%if (time == 2)
      { %>
      <%var i = 1;for(i=1; i<=7; i++){%>
        <tr class="list">
            <td><%=System.DateTime.Now.AddDays(-7+i).Month.ToString()%>-<%=System.DateTime.Now.AddDays(-7+i).Day.ToString()%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsVerified = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsPaid = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsPaid = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsShipped = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsShipped = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsReceived = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsCompleted = 1")%></td>
        </tr>
      <%} %>
      <%} %>
    <%if (time == 3)
      { %>
      <%var i = 1;for(i=1; i<=30; i++){%>
        <tr class="list">
            <td><%=System.DateTime.Now.AddDays(-30+i).Month.ToString()%>-<%=System.DateTime.Now.AddDays(-30 + i).Day.ToString()%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsVerified = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsPaid = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsPaid = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsShipped = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsShipped = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsReceived = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Type_id_OrderType = 211 and IsCompleted = 1")%></td>
        </tr>
      <%} %>
      <%} %>
      <%} %>
    </table> 

          <%}else{%>
            <%=PageReturnMsg%>
          <%}%>
        </div>
    </div>
    
<div class="bottom" id="body_bottom">
<script>
    function Export(){
        MsgBox(1, "<%=Tag("正在处理，请等待")%>", "<%=site.AdminPath %>/ajax/export.aspx?__Action=Statis_Order&time=<%=time %>&type=<%=type %>")
    }
</script>
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
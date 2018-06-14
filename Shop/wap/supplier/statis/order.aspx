<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Supplier.Statis.Statis_Order" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("订单统计")%>-<%=site.title%></title>
    <style>#body_bottom{height:0;overflow:hidden;display:none}</style>

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
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_supplier.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="<%=site.AdminPath %>/statis/order.aspx"><%=Tag("订单统计")%></a></span></li>
    </ul>
    </div>

    </div>
      
      
   <script language="javascript" type="text/javascript" src="<%=site.AdminJsPath %>/highcharts/highcharts.js"></script>
   <script language="javascript" type="text/javascript" src="<%=site.AdminJsPath %>/highcharts/exporting.js"></script>
   <script language="javascript" type="text/javascript" src="<%=site.AdminJsPath %>/highcharts/themes/grid.js"></script>
    <div class="mainbody_top">
    <div class="searchbox clear">
        <ul class="tabmenus">
            <li<%if (type == 0){ %> class="current"<%} %>><a href="order.aspx?time=<%=time %>"><span><%=Tag("销售额")%></span></a></li>
            <li<%if (type == 1){ %> class="current"<%} %>><a href="order.aspx?type=1&time=<%=time %>"><span><%=Tag("订单数")%></span></a></li>
        </ul>
    </div>
    </div>

    <div class="mainbody" id="body_main">
        <div id="body_main_form" style="min-width:1200px;width:100%">
          
    <ul class="tablist">
        <li <%if (time==0){Response.Write("class=\"selected\"");} %>><a href="?time=0&type=<%=type %>"><span><%=Tag("今日")%></span></a></li>
        <li <%if (time==1){Response.Write("class=\"selected\"");} %>><a href="?time=1&type=<%=type %>"><span><%=Tag("昨日")%></span></a></li>
        <li <%if (time==2){Response.Write("class=\"selected\"");} %>><a href="?time=2&type=<%=type %>"><span><%=Tag("最近7日")%></span></a></li>
        <li <%if (time==3){Response.Write("class=\"selected\"");} %>><a href="?time=3&type=<%=type %>"><span><%=Tag("最近30日")%></span></a></li>
    </ul>
    <table cellspacing="0" border="0" class="table" style="width: 100%; border-collapse: collapse;">
    <tr>
    <td>
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
    series: [{name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsPaid = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsPaid = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsShipped = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsShipped = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsReceived = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsCompleted = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}]
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
    series: [{name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsPaid = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsPaid = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsShipped = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsShipped = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsReceived = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsCompleted = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}]
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
    series: [{name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsPaid = 0") %><%if (i <7){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsPaid = 1") %><%if (i <7){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsShipped = 0") %><%if (i <7){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsShipped = 1") %><%if (i <7){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsReceived = 1") %><%if (i <7){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsCompleted = 1") %><%if (i <7){Response.Write(", ");} %><%} %>]}]
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
    series: [{name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsPaid = 0") %><%if (i <30){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsPaid = 1") %><%if (i <30){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsShipped = 0") %><%if (i <30){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsShipped = 1") %><%if (i <30){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsReceived = 1") %><%if (i <30){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsCompleted = 1") %><%if (i <30){Response.Write(", ");} %><%} %>]}]
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
    series: [{name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsPaid = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsPaid = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsShipped = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsShipped = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsReceived = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsCompleted = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}]
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
    series: [{name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsPaid = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsPaid = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsShipped = 0",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsShipped = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsReceived = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=24; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsCompleted = 1",i-1) %><%if (i <24){Response.Write(", ");} %><%} %>]}]
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
    series: [{name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsPaid = 0") %><%if (i <7){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsPaid = 1") %><%if (i <7){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsShipped = 0") %><%if (i <7){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsShipped = 1") %><%if (i <7){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsReceived = 1") %><%if (i <7){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=7; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-7+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsCompleted = 1") %><%if (i <7){Response.Write(", ");} %><%} %>]}]
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
    series: [{name: '<%=Tag("未支付") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsPaid = 0") %><%if (i <30){Response.Write(", ");} %><%} %>]}, {name: '<%=Tag("已支付") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsPaid = 1") %><%if (i <30){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("未发货") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsShipped = 0") %><%if (i <30){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已发货") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsShipped = 1") %><%if (i <30){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已收货") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsReceived = 1") %><%if (i <30){Response.Write(", ");} %><%} %>]},{name: '<%=Tag("已完成") %>',data: [<%for(i=1; i<=30; i++){%><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),System.DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd"),"Supplier_id = "+ CurrentSupplier.id +" and (Type_id_OrderType = 211 or Type_id_OrderType = 213)  and IsVerified = 1 and IsCompleted = 1") %><%if (i <30){Response.Write(", ");} %><%} %>]}]
    });});
    </script>
    <%} %>
    <%} %>
    <div id="container" style="margin:0 auto;width: 98%;"></div>
    </td>
    </tr>
    </table>
    <table cellpadding="0" cellspacing="0" width="100%" border="0" class="datalist">
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
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsPaid = 0", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsPaid = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsShipped = 0", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsShipped = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsReceived = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsCompleted = 1", i - 1)%></td>
        </tr>
      <%} %>
      <%} %>
    <%if (time == 1)
      { %>
      <%var i = 1;for(i=1; i<=24; i++){%>
        <tr class="list">
            <td><%=i-1 %>:00</td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsPaid = 0", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsPaid = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsShipped = 0", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsShipped = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsReceived = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsCompleted = 1", i - 1)%></td>
        </tr>
      <%} %>
      <%} %>
    <%if (time == 2)
      { %>
      <%var i = 1;for(i=1; i<=7; i++){%>
        <tr class="list">
            <td><%=System.DateTime.Now.AddDays(-7+i).Month.ToString()%>-<%=System.DateTime.Now.AddDays(-7+i).Day.ToString()%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsPaid = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsPaid = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsShipped = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsShipped = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsReceived = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsCompleted = 1")%></td>
        </tr>
      <%} %>
      <%} %>
    <%if (time == 3)
      { %>
      <%var i = 1;for(i=1; i<=30; i++){%>
        <tr class="list">
            <td><%=System.DateTime.Now.AddDays(-30+i).Month.ToString()%>-<%=System.DateTime.Now.AddDays(-30 + i).Day.ToString()%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsPaid = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsPaid = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsShipped = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsShipped = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsReceived = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetMoney_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsCompleted = 1")%></td>
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
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsPaid = 0", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsPaid = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsShipped = 0", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsShipped = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsReceived = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsCompleted = 1", i - 1)%></td>
        </tr>
      <%} %>
      <%} %>
    <%if (time == 1)
      { %>
      <%var i = 1;for(i=1; i<=24; i++){%>
        <tr class="list">
            <td><%=i-1 %>:00</td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsPaid = 0", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsPaid = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsShipped = 0", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsShipped = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsReceived = 1", i - 1)%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(0).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsCompleted = 1", i - 1)%></td>
        </tr>
      <%} %>
      <%} %>
    <%if (time == 2)
      { %>
      <%var i = 1;for(i=1; i<=7; i++){%>
        <tr class="list">
            <td><%=System.DateTime.Now.AddDays(-7+i).Month.ToString()%>-<%=System.DateTime.Now.AddDays(-7+i).Day.ToString()%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsPaid = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsPaid = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsShipped = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsShipped = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsReceived = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-7 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsCompleted = 1")%></td>
        </tr>
      <%} %>
      <%} %>
    <%if (time == 3)
      { %>
      <%var i = 1;for(i=1; i<=30; i++){%>
        <tr class="list">
            <td><%=System.DateTime.Now.AddDays(-30+i).Month.ToString()%>-<%=System.DateTime.Now.AddDays(-30 + i).Day.ToString()%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsPaid = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsPaid = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsShipped = 0")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsShipped = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsReceived = 1")%></td>
            <td><%=Shop.Bussiness.Order.GetCount_Order(System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), System.DateTime.Now.AddDays(-30 + i).ToString("yyyy-MM-dd"), "Supplier_id = " + CurrentSupplier.id + " and (Type_id_OrderType = 211 or Type_id_OrderType = 213) and IsVerified = 1 and IsCompleted = 1")%></td>
        </tr>
      <%} %>
      <%} %>
      <%} %>
    </table> 

        </div>
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
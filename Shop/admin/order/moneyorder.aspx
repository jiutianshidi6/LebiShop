<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.order.Default" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title>
        <%=Tag("充值单管理")%>-<%=site.title%></title>

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

    <script type="text/javascript" src="<%=site.AdminJsPath %>/jquery-ui/timepicker-addon.js"></script>
    <%if (CurrentLanguage.Code=="CN"){%><script type="text/javascript" src="<%=site.AdminJsPath %>/jquery-ui/timepicker-zh-CN.js"></script><%}%>
    <link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/jquery-ui/timepicker-addon.css" />
    <script type="text/javascript">
        $(function () {
            $(".input-calendar").datetimepicker({dateFormat:"yy-mm-dd",showSecond:true,timeFormat:"HH:mm:ss",stepHour:1,stepMinute:1,tepSecond:1});
        });
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
            <%}%>
            <li class="name"><span id="navIgation">
                <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <%=Tag("充值单管理")%> > <a href="<%=site.AdminPath %>/order/default.aspx?t=<%=t %>"><%=Shop.Bussiness.EX_Type.TypeName(t) %></a></span> </li>
        </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <div class="mainbody_top">
        <ul class="tablist">
            <li <%if (type==""){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=">
                <span>
                    <%=Tag("全部订单")%></span></a></li>
           
            <li <%if (type=="3"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=3">
                <span>
                    <%=Tag("未支付")%></span></a></li>
            <li <%if (type=="4"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=4">
                <span>
                    <%=Tag("已支付")%></span></a></li>
            
        </ul>
    </div>

    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <script type="text/javascript" src="<%=site.AdminJsPath %>/My97DatePicker/WdatePicker.js"></script>
    <div class="searchbox">
        <input type="text" name="dateFrom" id="dateFrom" size="12" class="input-calendar" value="<%=dateFrom %>" style="width:150px" />
        -
        <input type="text" name="dateTo" id="dateTo" size="12" class="input-calendar" value="<%=dateTo %>" style="width:150px" />
        <input type="text" id="key" name="key" class="input-query"value="<%=key %>" onkeydown="if(event.keyCode==13){search_();}" /><input type="button" id="btnSou" class="btn-query" onclick="search_();" />
    </div>
    <table class="datalist">
        <tr class="title">
            <th style="width: 40px" class="selectAll">
                <a href="javascript:void(0);" onclick="$('input[name=\'id\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));">
                    <%=Tag("全选")%></a>
            </th>
            <th width="110px">
                <%=Tag("订单编号")%>
            </th>
            <th width="100px">
                <%=Tag("会员")%>
            </th>
            <th width="80px">
                <%=Tag("金额")%>
            </th>
             <th width="100px">
                <%=Tag("状态")%>
            </th>
            <th width="120px">
                <%=Tag("支付方式")%>
            </th>
           <th>
                <%=Tag("备注")%>
            </th>
           <th width="130px">
                <%=Tag("相关订单")%>
            </th>
            <th width="130px">
                <%=Tag("日期")%>
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
                <a href="javascript:void(0);" onclick="Edit(<%=model.id %>,<%=model.Type_id_OrderType %>);"><%=model.Code %></a>
            </td>
            <td>
                <%=model.User_UserName %>
            </td>
            <td>
                <%=FormatMoney(model.Money_Order) %>
            </td>
            <td>
                <%=Shop.Bussiness.Order.OrderStatus(model, CurrentLanguage.Code, 0) %>
            </td>
            <td>
                <%=Shop.Bussiness.Language.Content(model.Pay, CurrentLanguage.Code)%>
                <%=Shop.Bussiness.Language.Content(model.OnlinePay, CurrentLanguage.Code)%>
            </td>
            <td>
                <%=model.Remark_Admin %>
            </td>
            <td>
                <%
                if(model.Order_id>0)
                {
                    Shop.Model.Lebi_Order co=Shop.Bussiness.B_Lebi_Order.GetModel(model.Order_id);
                    if(co!=null){%>
                    <a href="order_view.aspx?id=<%=co.id%>" target="_blank"><%=co.Code%></a>
                
                <%    }
                }%>
            </td>
            <td>
                <%=FormatTime(model.Time_Add) %>
            </td>
             <%if (domain3admin)
              { %>
            <td><%=SiteName(model.Site_id) %></td>
            <%} %>
        </tr>
        <%} %>
    </table>
    <script type="text/javascript">
        function search_() {
            var mark = GetRadioCheckedValues("mark");
            var key = $("#key").val();
            var dateFrom = $("#dateFrom").val();
            var dateTo = $("#dateTo").val();
            window.location = "?t=<%=t%>&type=<%=type%>&user_id=<%=user_id %>&Supplier_id=<%=Supplier_id %>&mark="+ mark +"&key=" + escape(key) + "&dateFrom=" + dateFrom + "&dateTo=" + dateTo;
        }
        function Edit(id,t) {

            var title_ = "<%=Tag("管理充值单")%>";
            var url_ = "moneyorder_edit_window.aspx?id=" + id;
            var width_ = 500;
            var height_ = "auto";
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_, 'moneyorder_edit_window');
        }
        function Del() {
            if (!confirm("<%=Tag("确认要删除吗？")%>"))
                return false;
            var ids = GetChkCheckedValues("id");
            var postData = { "ids": ids };
            var url = "<%=site.AdminPath %>/ajax/ajax_order.aspx?__Action=Order_Del";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function AdminSkin(code){
            var ids = GetChkCheckedValues("id");
            if (ids == ""){
                MsgBox(2, "<%=Tag("请先选择")%>", "");
                return;
            }
            window.open("<%=site.AdminPath %>/custom/" + code + ".aspx?id=" + ids);
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
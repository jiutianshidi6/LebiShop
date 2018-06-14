<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.order.Order_Edit" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("订单管理")%>-<%=site.title%></title>

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
            <li class="submit"><a href="javascript:void(0);" onclick="SaveOrder();"><b></b><span><%=Tag("保存")%></span></a></li>
            <%}%>
            <li class="rotate"><a href="javascript:void(0);" onclick="history.back();"><b></b><span><%=Tag("返回")%></span></a></li>
            <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a>
                > <a href="<%=site.AdminPath %>/order/default.aspx"><%=Tag("订单管理")%></a> >
                <%=model.Code %>
            </span></li>
        </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <table class="datalist" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr class="title">
            <th colspan="4">
                <%=Tag("基本信息")%>：
            </th>
        </tr>
        <tr class="list">
            <td style="width: 100px;">
                <%=Tag("订单编号")%>：
            </td>
            <td style="width: 350px;">
                <%=model.Code%>
            </td>
            <td style="width: 100px;">
                <%=Tag("订购时间")%>：
            </td>
            <td>
                <%=FormatTime(model.Time_Add) %>
            </td>
        </tr>
        <tr class="list">
            <td>
                <%=Tag("订单金额")%>：
            </td>
            <td colspan="3">
                <%=Tag("总金额")%>：<%=model.Money_Order%>

                <%=Tag("商品")%>：<%=model.Money_Product%>

                <%=Tag("运费")%>：<%=model.Money_Transport%>

                <%=Tag("税金")%>：<%=model.Money_Bill%>
            </td>
        </tr>
        <tr class="list">
            <td>
                <%=Tag("获得积分")%>：
            </td>
            <td colspan="3">
                <%=model.Point%>
            </td>
        </tr>
        <tr class="list">
            <td>
                <%=Tag("配送方式")%>：
            </td>
            <td>
                <%=model.Transport_Name%>
            </td>
            <td>
                <%=Tag("支付方式")%>：
            </td>
            <td>
                <%=Shop.Bussiness.Language.Content(model.Pay,CurrentLanguage)%>
            </td>
        </tr>

    </table>

    <table class="datalist" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr class="title">
            <th colspan="4">
                <%=Tag("收货人信息")%>： <a href="javascript:Editshouhuo();"><%=Tag("编辑")%></a>
            </th>
        </tr>
        <tr class="list">
            <td style="width: 100px;">
                <%=Tag("收货人")%>：
            </td>
            <td style="width: 350px;">
                <%=model.T_Name %>
            </td>
            <td style="width: 100px;">
                <%=Tag("邮箱")%>：
            </td>
            <td>
                <%=model.T_Email %>
            </td>
        </tr>
        <tr class="list">
            <td >
                <%=Tag("手机")%>：
            </td>
            <td >
                <%=model.T_MobilePhone %>
            </td>
            <td >
                <%=Tag("电话")%>：
            </td>
            <td>
                <%=model.T_Phone %>
            </td>
        </tr>
        <tr class="list">
            <td >
                <%=Tag("邮编")%>：
            </td>
            <td >
                <%=model.T_Postalcode %>
            </td>
            <td >
                <%=Tag("地区")%>：
            </td>
            <td >
                <%=Shop.Bussiness.EX_Area.GetAreaName(model.T_Area_id)%>
            </td>
        </tr>
        <tr class="list">
            <td >
                <%=Tag("地址")%>：
            </td>
            <td colspan="3" >
                <%=model.T_Address %>
            </td>
            
        </tr>
    </table>
   
       <table class="datalist" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr class="title">
            <th colspan="4">
                <%=Tag("订单状态")%>： 
            </th>
        </tr>
        <tr class="list">
            <td style="width: 100px;">
                <%=Tag("状态")%>：
            </td>
            
            <td>
                <input type="checkbox" value="1" shop="true" name="IsVerified" <%=model.IsVerified==1?"checked":"" %> />
                <%=Tag("确认")%>
                <input type="checkbox" value="1" shop="true" name="IsPaid" <%=model.IsPaid==1?"checked":"" %> />
                <%=Tag("支付")%>
                <input type="checkbox" value="1" shop="true" name="IsShipped" <%=model.IsShipped==1?"checked":"" %> />
                <%=Tag("发货")%>
                <input type="checkbox" value="1" shop="true" name="IsReceived" <%=model.IsReceived==1?"checked":"" %> />
                <%=Tag("收货")%>
                <input type="checkbox" value="1" shop="true" name="IsCompleted" <%=model.IsCompleted==1?"checked":"" %> />
                <%=Tag("完成")%>
                <input type="checkbox" value="1" shop="true" name="IsInvalid" <%=model.IsInvalid==1?"checked":"" %> />
                <%=Tag("无效")%> 
            </td>
        </tr>

        <tr class="list">
            <td >
                <%=Tag("内部备注")%>：
            </td>
                
            <td>
                <textarea id="Remark_Admin" shop="true" class="input" style="width:600px;height:80px;"><%=model.Remark_Admin%></textarea>
            </td>
        </tr>
    </table>

    <table class="datalist" border="0" cellpadding="0" cellspacing="0" width="100%">
       <tr class="title">
            <th colspan="4">
                <%=Tag("订单商品")%>：<a href="javascript:Pro_Del();"><%=Tag("删除所选")%></a> <a href="javascript:Pro_Save();"><%=Tag("保存")%></a>
            </th>
        </tr>
        <tr class="title">
             <th style="width: 40px" class="selectAll">
                <a href="javascript:void(0);" onclick="$('input[name=\'id\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));"><%=Tag("全选")%></a>
            </th>
            <th style="width: 100px">
                <%=Tag("图片")%>
            </th>
            <th style="width: 100px">
                <%=Tag("编号")%>
            </th>
            <th >
                <%=Tag("名称")%>
            </th>
            <th style="width: 100px">
                <%=Tag("数量")%>
            </th>
            <th style="width: 100px">
                <%=Tag("金额")%>
            </th>
            <th style="width: 100px">
                <%=Tag("小计")%>
            </th>
        </tr>
        <%foreach (Shop.Model.Lebi_Order_Product pro in pros)
          { %>
        <tr class="list">
             <td>
                <input type="checkbox" name="proid" value="<%=pro.id %>" del="true" />
                <input type="hidden" name="proid" value="<%=pro.id %>" pro="true" style="display:none" />
             </td>
             <td>
                <img src="<%=pro.ImageSmall %>" style="width:30px" />
             </td>
             <td>
                
             </td>
             <td>
                <%=Shop.Bussiness.Language.Content(pro.Product_Name,CurrentLanguage) %>
             </td>
             <td>
                <input type="text" class="input" pro="true" name="Count<%=pro.id %>"  id="Count<%=pro.id %>" value="<%=pro.Count %>" onkeyup="value=value.replace(/[^\d]/g,'')" style="width: 70px;" />
             </td>
             <td>
                <input type="text" class="input" pro="true" name="Price<%=pro.id %>" id="Price<%=pro.id %>" value="<%=pro.Price %>" onkeyup="value=value.replace(/[^\d]/g,'')" style="width: 70px;" />
             </td>
             <td>
                <%=pro.Money%>
             </td>
        </tr>
        <% } %>
    </table>
    <script type="text/javascript">
        function SaveOrder() {
            var postData = GetFormJsonData("shop");
            var url = "<%=site.AdminPath %>/ajax/ajax_order.aspx?__Action=Order_Edit&id=<%=model.id %>";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function Editshouhuo() {
            var title_ = "<%=Tag("编辑收货人")%>";
            var url_ = "shouhuo_Edit_window.aspx?id=<%=model.id %>";
            var width_ = 600;
            var height_ = "auto";
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Pro_Del() {
            if (!confirm("<%=Tag("确认要删除吗？")%>"))
                return false;
            var postData = GetFormJsonData("del");
            var url = "<%=site.AdminPath %>/ajax/ajax_order.aspx?__Action=OrderPro_Del&id=<%=model.id %>";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function Pro_Save() {
            var postData = GetFormJsonData("pro");
            var url = "<%=site.AdminPath %>/ajax/ajax_order.aspx?__Action=OrderPro_Edit&id=<%=model.id %>";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
    </script>

          <%}else{%>
            <%=PageReturnMsg%>
          <%}%>
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
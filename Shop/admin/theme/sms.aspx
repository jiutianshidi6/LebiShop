<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.theme.SMSTPL" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("短信模板") %>-<%=site.title%></title>

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

    <style>
        .bottom{height: 0;overflow: hidden;display: none;}
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
    <%if (PageReturnMsg == ""){%>
    <li class="submit"><a href="javascript:void(0);" onclick="SaveObj();"><b></b><span><%=Tag("保存")%></span></a></li>
    <%}%>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <%=Tag("短信模板")%></span></li>
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
            <li<%if (type =="user"){ %> class="current"<%} %>><a href="?type=user"><span><%=Tag("会员模板")%></span></a></li>
            <li<%if (type =="admin"){ %> class="current"<%} %>><a href="?type=admin"><span><%=Tag("管理员模板")%></span></a></li>
        </ul>
    </div>
    <%=Shop.Bussiness.Language.AdminLanguageTab("") %>
    <table
        id="lang" class="table">
        <%foreach (Shop.Model.Lebi_Language_Code lang in Shop.Bussiness.Language.Languages())
          {%>
        <tbody id="lang_<%=lang.Code %>" class="lang_table" style="display: none">
            <%if (type == "user"){ %>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("新用户注册") %>：
                </th>
                <td>
                    <textarea id="SMSTPL_newuser<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_newuser<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_newuser, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("订单提交") %>：
                </th>
                <td>
                    <textarea id="SMSTPL_ordersubmit<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_ordersubmit<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_ordersubmit, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("订单自提确认") %>：
                </th>
                <td>
                    <textarea id="SMSTPL_orderpickup<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_orderpickup<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_orderpickup, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("订单发货") %>：
                </th>
                <td>
                    <textarea id="SMSTPL_ordershipping<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_ordershipping<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_ordershipping, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("余额提醒") %>：
                </th>
                <td>
                    <textarea id="SMSTPL_balance<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_balance<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_balance, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("找回密码") %>：
                </th>
                <td>
                    <textarea id="SMSTPL_getpwd<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_getpwd<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_getpwd, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("获取新密码") %>：
                </th>
                <td>
                    <textarea id="SMSTPL_getnewpwd<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_getnewpwd<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_getnewpwd, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("商品评论")%>：
                </th>
                <td>
                    <textarea id="SMSTPL_comment<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_comment<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_comment, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("商品咨询")%>：
                </th>
                <td>
                    <textarea id="SMSTPL_ask<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_ask<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_ask, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("站内信")%>：
                </th>
                <td>
                    <textarea id="SMSTPL_message<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_message<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_message, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("手机验证码")%>：
                </th>
                <td>
                    <textarea id="SMSTPL_checkcode<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_checkcode<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_checkcode, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("预定到货提醒")%>：
                </th>
                <td>
                    <textarea id="SMSTPL_reserveok" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_reserveok<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_reserveok, lang.Code)%></textarea>
                </td>
            </tr>
            <%}else{ %>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("新用户注册") %>：
                </th>
                <td>
                    <textarea id="SMSTPL_Admin_newuser<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_Admin_newuser<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_Admin_newuser, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("订单提交") %>：
                </th>
                <td>
                    <textarea id="SMSTPL_Admin_ordersubmit<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_Admin_ordersubmit<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_Admin_ordersubmit, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("订单付款") %>：
                </th>
                <td>
                    <textarea id="SMSTPL_Admin_orderpaid<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_Admin_orderpaid<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_Admin_orderpaid, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("订单收货") %>：
                </th>
                <td>
                    <textarea id="SMSTPL_Admin_orderrecive<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_Admin_orderrecive<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_Admin_orderrecive, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("订单留言") %>：
                </th>
                <td>
                    <textarea id="SMSTPL_Admin_ordercomment<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_Admin_ordercomment<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_Admin_ordercomment, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("留言反馈") %>：
                </th>
                <td>
                    <textarea id="SMSTPL_Admin_inquiry<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_Admin_inquiry<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_Admin_inquiry, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("商品评论")%>：
                </th>
                <td>
                    <textarea id="SMSTPL_Admin_comment<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_Admin_comment<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_Admin_comment, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("商品咨询")%>：
                </th>
                <td>
                    <textarea id="SMSTPL_Admin_ask<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_Admin_ask<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_Admin_ask, lang.Code)%></textarea>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("站内信")%>：
                </th>
                <td>
                    <textarea id="SMSTPL_Admin_message<%=lang.Code %>" class="textarea" style="height: 55px; width: 100%;" name="SMSTPL_Admin_message<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.SMSTPL_Admin_message, lang.Code)%></textarea>
                </td>
            </tr>
            <%} %>
        </tbody>
        <%} %>
        <tr>
            <td colspan="2" class="classfaq">
            <div class="faq_main">
                <p class="faq_title"><%=Tag("标签规则")%>：</p>
                <%if (type == "user")
                  { %>
                <%=Tag("用户名")%>：{$UserName}
                <%=Tag("用户ID")%>：{$UserID}
                <%=Tag("真实姓名")%>：{$RealName}
                <%=Tag("密码")%>：{$Password}
                <%=Tag("自提点")%>：{$PickUpStation}
                <%=Tag("自提时间")%>：{$PickUpTime}
                <%} %>
                <%=Tag("用户昵称")%>：{$NickName}
                <%=Tag("订单号码")%>：{$OrderNO}
                <%=Tag("快递公司")%>：{$ExpressCompany}
                <%=Tag("快递单号")%>：{$ExpressNumber}
                <%if (type == "admin")
                  { %>
                <%=Tag("配送方式")%>：{$Transport}
                <%} %>
                <%=Tag("金额")%>：{$Money}
                <%=Tag("时间")%>：{$Time}
                <%=Tag("标题")%>：{$Title}
                <%=Tag("内容")%>：{$Content}
                <%=Tag("客服电话")%>：{$Phone}
                <%=Tag("客服传真")%>：{$Fax}
                <%=Tag("客服邮箱")%>：{$Email}
                <%=Tag("客服QQ")%>：{$QQ}
                <%=Tag("域名")%>：{$Domain}
                <%=Tag("站点名称")%>：{$SiteName}
                <%=Tag("验证码")%>：{$CheckCode}
            </div>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
         LanguageTab_EditPage('<%=CurrentLanguage.Code %>'); //加载默认语言
        function SaveObj() {
            var postData = GetFormJsonData("shop");
            var url = "<%=site.AdminPath %>/ajax/ajax_site.aspx?__Action=SMSTPL_Edit&type=<%=type %>";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "")});
        }
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
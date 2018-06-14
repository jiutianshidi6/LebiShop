<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.storeConfig.EmailConfig" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("邮件设置")%>-<%=site.title%></title>

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
            <li class="submit"><a href="javascript:void(0);" onclick="SaveObj();"><b></b><span><%=Tag("保存")%></span></a></li>
            <li class="email"><a href="javascript:void(0);" onclick="Send();"><b></b><span><%=Tag("测试")%></span></a></li>
            <%}%>
            <li class="mes"><span id="Span1"><font id="mes"></font></span></li>
            <li class="name"><span id="navIgation">
                <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> >
                <%=Tag("邮件设置") %></span></li>
        </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <table class="table">
        <tbody>
            <tr>
                <th>
                    <%=Tag("发信邮箱")%>：
                </th>
                <td>
                    <input type="text" class="input" id="MailAddress" name="MailAddress" shop="true" style="width: 200px;"
                        value="<%=model.MailAddress %>" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("SMTP Server地址")%>：
                </th>
                <td>
                    <input type="text" class="input" id="SmtpAddress" name="SmtpAddress" shop="true"
                        style="width: 200px;" value="<%=model.SmtpAddress %>" />
                    <em><%=Tag("如：smtp.163.com")%></em>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("端口")%>：
                </th>
                <td>
                    <input type="text" class="input" id="MailPort" name="MailPort" shop="true"
                           style="width: 60px;" value="<%=model.MailPort %>"  onkeyup="value=value.replace(/[^\d]/g,'')" />
                    <em>25</em>
                    &nbsp;&nbsp;
                    <label><input type="checkbox" name="MailIsSSL" value="1" shop="true" <%=model.MailIsSSL=="1"?"checked":"" %> /><%=Tag("SSL")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("邮件登陆名")%>：
                </th>
                <td>
                    <input type="text" class="input" id="MailName" name="MailName" shop="true" style="width: 200px;"
                        value="<%=model.MailName %>" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("登陆密码")%>：
                </th>
                <td>
                    <input type="password" id="MailPassWord" name="MailPassWord" shop="true" style="width: 200px;"
                        value="<%=password %>" class="input" size="21" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("发信名称")%>：
                </th>
                <td>
                    <input type="text" class="input" id="MailDisplayName" name="MailDisplayName" shop="true" style="width: 200px;"
                        value="<%=model.MailDisplayName %>" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("失败邮件尝试次数")%>：
                </th>
                <td>
                    <input type="text" id="Mail_SendTop" name="Mail_SendTop" shop="true" style="width: 100px;"
                        value="<%=model.Mail_SendTop %>" class="input" onkeyup="value=value.replace(/[^\d]/g,'')" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("邮件队列提取间隔")%>：
                </th>
                <td>
                    <input type="text" id="Mail_SendTime" name="Mail_SendTime" shop="true" style="width: 100px;"
                        value="<%=model.Mail_SendTime %>" class="input" onkeyup="value=value.replace(/[^\d]/g,'')" />
                    <span class="FormALT"><%=Tag("单位：分钟") %></span>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("发件设置")%>：
                </th>
                <td>
                    <%string ms = model.MailSign;
                      if (ms == null)
                          ms = "";
                      ms = ms.ToLower();
                        %>
                    <label><input type="checkbox" name="MailSign" value="zhuce" shop="true" <%=ms.Contains("zhuce")?"checked":"" %> /><%=Tag("新用户注册")%></label>
                    <label><input type="checkbox" name="MailSign" value="getpwd" shop="true" <%=ms.Contains("getpwd")?"checked":"" %> /><%=Tag("找回密码")%></label>
                    <label><input type="checkbox" name="MailSign" value="dingdantijiao" shop="true" <%=ms.Contains("dingdantijiao")?"checked":"" %> /><%=Tag("订单提交")%></label>
                    <label><input type="checkbox" name="MailSign" value="orderpaid" shop="true" <%=ms.Contains("orderpaid")?"checked":"" %> /><%=Tag("订单付款")%></label>
                    <label><input type="checkbox" name="MailSign" value="dingdanfahuo" shop="true" <%=ms.Contains("dingdanfahuo")?"checked":"" %> /><%=Tag("订单发货")%></label>
                    <label><input type="checkbox" name="MailSign" value="changgouqingdan" shop="true" <%=ms.Contains("changgouqingdan")?"checked":"" %> /><%=Tag("常购清单")%></label>
                    <label><input type="checkbox" name="MailSign" value="sendfriend" shop="true" <%=ms.Contains("sendfriend")?"checked":"" %> /><%=Tag("邮件分享")%></label>
                    <label><input type="checkbox" name="MailSign" value="reserveok" shop="true" <%=ms.Contains("reserveok")?"checked":"" %> /><%=Tag("预定到货提醒")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("抄送邮箱")%>：
                </th>
                <td>
                    <input type="text" class="input" id="AdminMailAddress" name="AdminMailAddress" shop="true" style="width: 200px;"
                        value="<%=model.AdminMailAddress %>" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("抄送设置")%>：
                </th>
                <td>
                    <%string ams = model.AdminMailSign;
                      if (ams == null)
                          ams = "";
                      ams = ams.ToLower();
                        %>
                    <label><input type="checkbox" name="AdminMailSign" value="register" shop="true" <%=ams.Contains("register")?"checked":"" %> /><%=Tag("注册")%></label>
                    <label><input type="checkbox" name="AdminMailSign" value="ordersubmit" shop="true" <%=ams.Contains("ordersubmit")?"checked":"" %> /><%=Tag("订单提交")%></label>
                    <label><input type="checkbox" name="AdminMailSign" value="orderpaid" shop="true" <%=ams.Contains("orderpaid")?"checked":"" %> /><%=Tag("订单付款")%></label>
                    <label><input type="checkbox" name="AdminMailSign" value="ordercomment" shop="true" <%=ams.Contains("ordercomment")?"checked":"" %> /><%=Tag("订单留言")%></label>
                    <label><input type="checkbox" name="AdminMailSign" value="inquiry" shop="true" <%=ams.Contains("inquiry")?"checked":"" %> /><%=Tag("留言反馈")%></label>
                    <label><input type="checkbox" name="AdminMailSign" value="comment" shop="true" <%=ams.Contains("comment")?"checked":"" %> /><%=Tag("商品评论")%></label>
                    <label><input type="checkbox" name="AdminMailSign" value="ask" shop="true" <%=ams.Contains("ask")?"checked":"" %> /><%=Tag("商品咨询")%></label>
                    <label><input type="checkbox" name="AdminMailSign" value="message" shop="true" <%=ams.Contains("message")?"checked":"" %> /><%=Tag("站内信")%></label>
                </td>
            </tr>
        </tbody>
    </table>
    <script type="text/javascript">
        function SaveObj() {
            var postData = GetFormJsonData("shop");
            var url="<%=site.AdminPath %>/ajax/ajax_site.aspx?__Action=EmailConfig_Edit";
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", "")});
        }
        function Send() {
            var url="<%=site.AdminPath %>/ajax/ajax_site.aspx?__Action=EmailTestSend";
            RequestAjax(url,"",function(res){MsgBox(1, "<%=Tag("操作成功")%>", "")});
        }
    </script>

          <%}else{%>
            <%=PageReturnMsg%>
          <%}%>
        </div>
    </div>
    
    <input type="hidden" id="pwd" runat="server" />

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
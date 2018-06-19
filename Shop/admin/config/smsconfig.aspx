<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.storeConfig.SMSConfig" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title>
        <%=Tag("短信设置")%>-<%=site.title%></title>

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
            <li class="submit"><a href="javascript:void(0);" onclick="SaveObj();"><b></b><span>
                <%=Tag("保存")%></span></a></li>
            <%}%>
            <li class="mes"><span id="Span1"><font id="mes"></font></span></li>
            <li class="name"><span id="navIgation">
                <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a>
                >
                <%=Tag("短信设置")%></span></li>
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
                    <%=Tag("短信平台")%>：
                </th>
                <td>
                    <select name="SMS_server" id="SMS_server" shop="true" onchange="changeserver();" >
                        <option value="0" <%=model.SMS_server=="0"?"selected":"" %>>时代互联</option>
                        <option value="1" <%=model.SMS_server=="1"?"selected":"" %>>yunsms.cn</option>
                        <option value="999" <%=model.SMS_server=="999"?"selected":"" %>>通用HTTP接口</option>
                    </select>
                </td>
            </tr>
            <tr id="httpapi">
                <th>
                    接口地址：
                </th>
                <td>
                    <input type="text" class="input" id="SMS_httpapi" name="SMS_httpapi" shop="true" style="width: 400px;"
                        value="<%=model.SMS_httpapi %>" />
                    <br/><em>{$username}：短信账号名{$password}：帐户密码{$phonenumber}：手机号码{$content}：短信内容<br/>
                    示例：http://sms.xxx.com/send/?user={$username}&pwd={$password}&phone={$phonenumber}&content={$content}
                    </em>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("短信帐号")%>：
                </th>
                <td>
                    <input type="text" class="input" id="SMS_user" name="SMS_user" shop="true" style="width: 200px;"
                        value="<%=model.SMS_user %>" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("短信密码")%>：
                </th>
                <td>
                    <input type="password" class="input" id="SMS_password" name="SMS_password" shop="true"
                        style="width: 200px;" value="<%=SMS_password %>" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("短信后缀")%>：
                </th>
                <td>
                    <input type="text" class="input" id="SMS_lastmsg" name="SMS_lastmsg" shop="true" style="width: 200px;"
                        value="<%=model.SMS_lastmsg %>" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("状态")%>：
                </th>
                <td>
                    <input type="radio" name="SMS_state" value="1" shop="true" <%=model.SMS_state=="1"?"checked":"" %> /><%=Tag("开启")%>
                    <input type="radio" name="SMS_state" value="0" shop="true" <%=model.SMS_state=="0"?"checked":"" %> /><%=Tag("关闭")%>
                </td>
            </tr>
            
            <tr>
                <th>
                    <%=Tag("发给会员")%>：
                </th>
                <td>
                    <%string ms = model.SMS_sendmode;
                      if (ms == null)
                          ms = "";
                    %>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_newuser" shop="true" <%=ms.Contains("SMSTPL_newuser")?"checked":"" %> /><%=Tag("新用户注册")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_ordersubmit" shop="true"
                            <%=ms.Contains("SMSTPL_ordersubmit")?"checked":"" %> /><%=Tag("订单提交")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_ordershipping" shop="true"
                            <%=ms.Contains("SMSTPL_ordershipping")?"checked":"" %> /><%=Tag("订单发货")%></label>
                     <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_orderpickup" shop="true"
                            <%=ms.Contains("SMSTPL_orderpickup")?"checked":"" %> /><%=Tag("订单自提确认")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_balance" shop="true" <%=ms.Contains("SMSTPL_balance")?"checked":"" %> /><%=Tag("余额提醒")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_getpwd" shop="true" <%=ms.Contains("SMSTPL_getpwd")?"checked":"" %> /><%=Tag("找回密码")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_getnewpwd" shop="true" <%=ms.Contains("SMSTPL_getnewpwd")?"checked":"" %> /><%=Tag("获取新密码")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_comment" shop="true" <%=ms.Contains("SMSTPL_comment")?"checked":"" %> /><%=Tag("商品评论")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_ask" shop="true" <%=ms.Contains("SMSTPL_ask")?"checked":"" %> /><%=Tag("商品咨询")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_message" shop="true" <%=ms.Contains("SMSTPL_message")?"checked":"" %> /><%=Tag("站内信")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_reserveok" shop="true" <%=ms.Contains("SMSTPL_reserveok")?"checked":"" %> /><%=Tag("预定到货提醒")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("发给管理员")%>：
                </th>
                <td>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_Admin_newuser" shop="true"
                            <%=ms.Contains("SMSTPL_Admin_newuser")?"checked":"" %> /><%=Tag("新用户注册")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_Admin_ordersubmit" shop="true"
                            <%=ms.Contains("SMSTPL_Admin_ordersubmit")?"checked":"" %> /><%=Tag("订单提交")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_Admin_orderpaid" shop="true"
                            <%=ms.Contains("SMSTPL_Admin_orderpaid")?"checked":"" %> /><%=Tag("订单付款")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_Admin_orderrecive" shop="true"
                            <%=ms.Contains("SMSTPL_Admin_orderrecive")?"checked":"" %> /><%=Tag("订单收货")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_Admin_ordercomment" shop="true"
                            <%=ms.Contains("SMSTPL_Admin_ordercomment")?"checked":"" %> /><%=Tag("订单留言")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_Admin_inquiry" shop="true"
                            <%=ms.Contains("SMSTPL_Admin_inquiry")?"checked":"" %> /><%=Tag("留言反馈")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_Admin_comment" shop="true"
                            <%=ms.Contains("SMSTPL_Admin_comment")?"checked":"" %> /><%=Tag("商品评论")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_Admin_ask" shop="true" <%=ms.Contains("SMSTPL_Admin_ask")?"checked":"" %> /><%=Tag("商品咨询")%></label>
                    <label>
                        <input type="checkbox" name="SMS_sendmode" value="SMSTPL_Admin_message" shop="true"
                            <%=ms.Contains("SMSTPL_Admin_message")?"checked":"" %> /><%=Tag("站内信")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("手机号码")%>：
                </th>
                <td>
                    <input type="text" class="input" id="SMS_reciveno" name="SMS_reciveno" shop="true"
                        style="width: 200px;" value="<%=model.SMS_reciveno %>" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("最大字数")%>：
                </th>
                <td>
                    <input type="text" class="input" id="SMS_maxlen" name="SMS_maxlen" shop="true" style="width: 70px;"
                        value="<%=model.SMS_maxlen %>" />
                </td>
            </tr>
            <tr class="sdhl">
                <th>
                    <%=Tag("端口号")%>：
                </th>
                <td>
                    <input type="text" class="input" id="SMS_serverport" name="SMS_serverport" shop="true"
                        style="width: 200px;" value="<%=model.SMS_serverport %>" />
                </td>
            </tr>
            
            
             <tr class="sdhl">
                <th>
                    <%=Tag("发送通道")%>：
                </th>
                <td>
                    <select name="SMS_apitype" shop="true">
                        <option value="3" <%=model.SMS_apitype=="3"?"selected":"" %>>即时通道(客服类推荐) (发送1条扣去1.3条)</option>
                        <option value="2" <%=model.SMS_apitype=="2"?"selected":"" %>>普通通道(发送1条扣去1条)</option>
                    </select>
                </td>
            </tr>
             <tr class="sdhl">
                <th>
                    <%=Tag("短信余额")%>：
                </th>
                <td>
                    <%=account%>
                </td>
            </tr>
    <%
    if (!Shop.LebiAPI.Service.Instanse.Check("managelicenese")){
    %>
            <tr>
                <td colspan="2" class="classfaq">
                    <div class="faq_main">
                        <p class="faq_title">
                            时代互联通道说明：</p>
                        普通通道：会对短信内容进行严格审核，不允许发送含有任何营销内容的短信；<br />
                        即时通道：专为需即时发送的客户开辟的绿色通道，发送速度很快，支持回复短信。<br />
                        注意：在短信发送高峰时期，有时短信网关及通道接口有可能会出现涌堵现象，这时为节省发送时间，建议您更换通道来发送。<br />
                        短信购买：<a href="http://web.56770.com/mobile/" target="_blank">http://web.56770.com/mobile/</a>
                    </div>
                </td>
            </tr>
    <%}%>
        </tbody>
    </table>
    <script type="text/javascript">
        function SaveObj() {
            var postData = GetFormJsonData("shop");
            var url="<%=site.AdminPath %>/ajax/ajax_site.aspx?__Action=SMSConfig_Edit";
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", "")});
        }
        function changeserver()
        {
            var st=$("#SMS_server").val();
            if(st=='0')
                $('.sdhl').show();
            else
                $('.sdhl').hide();
            if(st=='999')
                $('#httpapi').show();
            else
                $('#httpapi').hide();
        }
        changeserver();
    </script>

          <%}else{%>
            <%=PageReturnMsg%>
          <%}%>
        </div>
    </div>
    
    <input type="hidden" id="pwd" runat="server" />
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
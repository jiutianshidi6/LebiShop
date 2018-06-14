<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.Config.platform" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title>
        <%=Tag("第三方配置")%>-<%=site.title%></title>

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

    <script type="text/javascript" src="<%=site.AdminJsPath %>/ajaxfileupload.js"></script>
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
            <li class="name"><span id="navIgation">
                <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a>
                >
                <%=Tag("第三方配置") %></span></li>
        </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <div class="proBox clear">
        <ul class="btns clear">
            <li class="menu">
                <%=Tag("QQ登录") %>
            </li>
            <li>
                <%=Tag("启用") %>：<input type="checkbox" name="platform_login" value="qq" <%=isselect("qq") %>
                    shop="true" />
            </li>
            <li>
                <%=Tag("申请地址") %>：<a href="http://connect.qq.com" target="_blank">http://connect.qq.com</a>
            </li>
        </ul>
        <div class="iTabHead">
            <table class="datalist">
                <tr class="list">
                    <td style="width: 150px;">
                        Appid
                    </td>
                    <td align="left">
                        <input type="text" class="input" id="platform_qq_id" name="platform_qq_id" shop="true"
                            style="width: 200px;" value="<%=model.platform_qq_id %>" />
                        <em></em>
                    </td>
                </tr>
                <tr class="list">
                    <td style="width: 150px;">
                        Appkey
                    </td>
                    <td align="left">
                        <input type="text" class="input" id="platform_qq_key" name="platform_qq_key" shop="true"
                            style="width: 200px;" value="<%=model.platform_qq_key %>" />
                        <em></em>
                    </td>
                </tr>
                <tr class="list">
                    <td style="width: 150px;">
                        <%=Tag("图标") %>
                    </td>
                    <td align="left">
                        <div id="image_platform_qq_image">
                            <%if (model.platform_qq_image != "")
                              {%>
                            <img height="16" src="<%=site.WebPath + model.platform_qq_image%>" />
                            <%} %>
                        </div>
                        <input type="text" shop="true" id="platform_qq_image" name="platform_qq_image" class="input"
                            style="width: 200px;" value="<%=model.platform_qq_image%>" />
                        <input id="file_platform_qq_image" name="file_platform_qq_image" class="input" type="file"
                            onchange="uploadImage('platform_qq_image')" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="proBox clear">
        <ul class="btns clear">
            <li class="menu">
                <%=Tag("新浪微博登录") %>
            </li>
            <li>
                <%=Tag("启用") %>：<input type="checkbox" name="platform_login" value="weibo" <%=isselect("weibo") %>
                    shop="true" />
            </li>
            <li>
                <%=Tag("申请地址") %>：<a href="http://open.weibo.com/" target="_blank">http://open.weibo.com/</a>
            </li>
        </ul>
        <div class="iTabHead">
            <table class="datalist">
                <tr class="list">
                    <td style="width: 150px;">
                        Appkey
                    </td>
                    <td align="left">
                        <input type="text" class="input" id="platform_weibo_id" name="platform_weibo_id"
                            shop="true" style="width: 200px;" value="<%=model.platform_weibo_id %>" />
                        <em></em>
                    </td>
                </tr>
                <tr class="list">
                    <td style="width: 150px;">
                        AppSecret
                    </td>
                    <td align="left">
                        <input type="text" class="input" id="platform_weibo_key" name="platform_weibo_key"
                            shop="true" style="width: 200px;" value="<%=model.platform_weibo_key %>" />
                        <em></em>
                    </td>
                </tr>
                <tr class="list">
                    <td style="width: 150px;">
                        <%=Tag("图标") %>
                    </td>
                    <td align="left">
                        <div id="image_platform_weibo_image">
                            <%if (model.platform_weibo_image != "")
                              {%>
                            <img height="16" src="<%=site.WebPath + model.platform_weibo_image%>" />
                            <%} %>
                        </div>
                        <input type="text" shop="true" id="platform_weibo_image" name="platform_weibo_image"
                            class="input" style="width: 200px;" value="<%=model.platform_weibo_image%>" />
                        <input id="file_platform_weibo_image" name="file_platform_weibo_image" class="input"
                            type="file" onchange="uploadImage('platform_weibo_image')" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="proBox clear">
        <ul class="btns clear">
            <li class="menu">
                <%=Tag("淘宝登录") %>
            </li>
            <li>
                <%=Tag("启用") %>：<input type="checkbox" name="platform_login" value="taobao" <%=isselect("taobao") %>
                    shop="true" />
            </li>
             <li>
                <%=Tag("申请地址") %>：<a href="http://open.taobao.com/" target="_blank">http://open.taobao.com/</a>
            </li>
        </ul>
        <div class="iTabHead">
            <table class="datalist">
                <tr class="list">
                    <td style="width: 150px;">
                        Appkey
                    </td>
                    <td align="left">
                        <input type="text" class="input" id="platform_taobao_key" name="platform_taobao_key"
                            shop="true" style="width: 200px;" value="<%=model.platform_taobao_key %>" />
                        <em></em>
                    </td>
                </tr>
                <tr class="list">
                    <td style="width: 150px;">
                        AppSecret
                    </td>
                    <td align="left">
                        <input type="text" class="input" id="platform_taobao_secret" name="platform_taobao_secret"
                            shop="true" style="width: 200px;" value="<%=model.platform_taobao_secret %>" />
                        <em></em>
                    </td>
                </tr>
                <tr class="list">
                    <td style="width: 150px;">
                        <%=Tag("图标") %>
                    </td>
                    <td align="left">
                        <div id="image_platform_taobao_image">
                            <%if (model.platform_taobao_image != "")
                              {%>
                            <img height="16" src="<%=site.WebPath + model.platform_taobao_image%>" />
                            <%} %>
                        </div>
                        <input type="text" shop="true" id="platform_taobao_image" name="platform_taobao_image"
                            class="input" style="width: 200px;" value="<%=model.platform_taobao_image%>" />
                        <input id="file_platform_taobao_image" name="file_platform_taobao_image" class="input" type="file" onchange="uploadImage('platform_taobao_image')" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="proBox clear">
        <ul class="btns clear">
            <li class="menu">
                <%=Tag("Facebook登录") %>
            </li>
            <li>
                <%=Tag("启用") %>：<input type="checkbox" name="platform_login" value="facebook" <%=isselect("facebook") %>
                    shop="true" />
            </li>
             <li>
                <%=Tag("申请地址") %>：<a href="https://developers.facebook.com/" target="_blank">https://developers.facebook.com/</a>
            </li>
        </ul>
        <div class="iTabHead">
            <table class="datalist">
                <tr class="list">
                    <td style="width: 150px;">
                        Appid
                    </td>
                    <td align="left">
                        <input type="text" class="input" id="platform_facebook_id" name="platform_facebook_id"
                            shop="true" style="width: 200px;" value="<%=model.platform_facebook_id %>" />
                        <em></em>
                    </td>
                </tr>
                <tr class="list">
                    <td style="width: 150px;">
                        AppSecret
                    </td>
                    <td align="left">
                        <input type="text" class="input" id="platform_facebook_secret" name="platform_facebook_secret"
                            shop="true" style="width: 200px;" value="<%=model.platform_facebook_secret %>" />
                        <em></em>
                    </td>
                </tr>
                <tr class="list">
                    <td style="width: 150px;">
                        <%=Tag("图标") %>
                    </td>
                    <td align="left">
                        <div id="image_platform_facebook_image">
                            <%if (model.platform_facebook_image != "")
                              {%>
                            <img height="16" src="<%=site.WebPath + model.platform_facebook_image%>" />
                            <%} %>
                        </div>
                        <input type="text" shop="true" id="platform_facebook_image" name="platform_facebook_image"
                            class="input" style="width: 200px;" value="<%=model.platform_facebook_image%>" />
                        <input id="file_platform_facebook_image" name="platform_facebook_image" class="input"
                            type="file" onchange="uploadImage('platform_facebook_image')" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="proBox clear">
        <ul class="btns clear">
            <li class="menu">
                <%=Tag("微信登录")%>
            </li>
            <li>
                <%=Tag("启用") %>：<input type="checkbox" name="platform_login" value="weixin" <%=isselect("weixin") %>
                    shop="true" />
            </li>
             <li>
                <%=Tag("申请地址") %>：<a href="https://mp.weixin.qq.com/" target="_blank">https://mp.weixin.qq.com/</a>
            </li>
        </ul>
        <div class="iTabHead">
            <table class="datalist">
                <tr class="list">
                    <td style="width: 150px;">
                        微信号
                    </td>
                    <td align="left">
                        <input type="text" class="input" id="platform_weixin_number" name="platform_weixin_number"
                            shop="true" style="width: 200px;" value="<%=model.platform_weixin_number %>" />
                        <em></em>
                    </td>
                </tr>
                <tr class="list">
                    <td style="width: 150px;">
                        Appid
                    </td>
                    <td align="left">
                        <input type="text" class="input" id="platform_weixin_id" name="platform_weixin_id"
                            shop="true" style="width: 200px;" value="<%=model.platform_weixin_id %>" />
                        <em></em>
                    </td>
                </tr>
                <tr class="list">
                    <td style="width: 150px;">
                        AppSecret
                    </td>
                    <td align="left">
                        <input type="text" class="input" id="platform_weixin_secret" name="platform_weixin_secret"
                            shop="true" style="width: 200px;" value="<%=model.platform_weixin_secret %>" />
                        <em></em>
                    </td>
                </tr>
                <tr class="list">
                    <td style="width: 150px;">
                        <%=Tag("图标") %>
                    </td>
                    <td align="left">
                        <div id="image_platform_weixin_image">
                            <%if (model.platform_weixin_image != "")
                              {%>
                            <img height="16" src="<%=site.WebPath + model.platform_weixin_image%>" />
                            <%} %>
                        </div>
                        <input type="text" shop="true" id="platform_weixin_image" name="platform_weixin_image"
                            class="input" style="width: 200px;" value="<%=model.platform_weixin_image%>" />
                        <input id="file_platform_weixin_image" name="file_platform_weixin_image" class="input"
                            type="file" onchange="uploadImage('platform_weixin_image')" />
                    </td>
                </tr>
                <tr class="list">
                    <td style="width: 150px;">
                        <%=Tag("二维码") %>
                    </td>
                    <td align="left">
                        <div id="image_platform_weixin_image_qrcode">
                            <%if (model.platform_weixin_image_qrcode != "")
                              {%>
                            <img height="16" src="<%=site.WebPath + model.platform_weixin_image_qrcode%>" />
                            <%} %>
                        </div>
                        <input type="text" shop="true" id="platform_weixin_image_qrcode" name="platform_weixin_image_qrcode"
                            class="input" style="width: 200px;" value="<%=model.platform_weixin_image_qrcode%>" />
                        <input id="file_platform_weixin_image_qrcode" name="file_platform_weixin_image_qrcode" class="input"
                            type="file" onchange="uploadImage('platform_weixin_image_qrcode')" />
                    </td>
                </tr>
                <tr class="list">
                    <td style="width: 150px;">
                        Token
                    </td>
                    <td align="left">
                        <input type="text" class="input" id="platform_weixin_custemtoken" name="platform_weixin_custemtoken"
                            shop="true" style="width: 200px;" value="<%=model.platform_weixin_custemtoken %>" />
                        <em></em>
                    </td>
                </tr>
                <tr class="list">
                    <td style="width: 150px;">
                        关注自动回复消息
                    </td>
                    <td align="left">
                        <input type="text" class="input" id="platform_weixin_subscribe_automsg" name="platform_weixin_subscribe_automsg"
                            shop="true" style="width: 200px;" value="<%=model.platform_weixin_subscribe_automsg %>" />
                        <em></em>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <%--<div class="proBox clear">
        <ul class="btns clear">
            <li class="menu">
                <%=Tag("Twitter登录") %>
            </li>
            <li>
                <%=Tag("启用") %>：<input type="checkbox" name="platform_login" value="twitter" <%=isselect("twitter") %>
                    shop="true" />
            </li>
        </ul>
        <div class="iTabHead">
            <table class="datalist">
                <tr class="list">
                    <td style="width: 150px;">
                        Consumer key
                    </td>
                    <td align="left">
                        <input type="text" class="input" id="platform_twitter_key" name="platform_twitter_key"
                            shop="true" style="width: 200px;" value="<%=model.platform_twitter_key %>" />
                        <em></em>
                    </td>
                </tr>
                <tr class="list">
                    <td style="width: 150px;">
                        Consumer secret
                    </td>
                    <td align="left">
                        <input type="text" class="input" id="platform_twitter_secret" name="platform_twitter_secret"
                            shop="true" style="width: 200px;" value="<%=model.platform_twitter_secret %>" />
                        <em></em>
                    </td>
                </tr>
                <tr class="list">
                    <td style="width: 150px;">
                        <%=Tag("图标") %>
                    </td>
                    <td align="left">
                        <div id="image_platform_twitter_image">
                            <%if (model.platform_twitter_image != "")
                              {%>
                            <img height="16" src="<%=site.WebPath + model.platform_twitter_image%>" />
                            <%} %>
                        </div>
                        <input type="text" shop="true" id="platform_twitter_image" name="platform_twitter_image"
                            class="input" style="width: 200px;" value="<%=model.platform_twitter_image%>" />
                        <input id="file_platform_twitter_image" name="file_platform_twitter_image" class="input"
                            type="file" onchange="uploadImage('platform_twitter_image')" />
                    </td>
                </tr>
            </table>
        </div>
    </div>--%>
    <script type="text/javascript">
        function SaveObj() {
            var postData = GetFormJsonData("shop");
            var url="<%=site.AdminPath %>/ajax/ajax_site.aspx?__Action=PlatformConfig_Edit";
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function uploadImage(id) {
        $.ajaxFileUpload
        (
	        {
	            url: WebPath + '/ajax/imageuploadone.aspx?path=config',
	            secureuri: false,
	            fileElementId: 'file_' + id,
	            dataType: 'json',
	            success: function (data, status) {
	                if (data.msg != 'OK') {
	                    MsgBox(2, data.msg, "");
	                }
	                else {
	                    var imageUrl = data.ImageUrl;
	                    if (imageUrl.length > 0) {
	                        $("#image_" + id + "").html('<img height="16" src=' + WebPath + imageUrl + '>');
	                        $("#" + id + "").val(imageUrl);
	                    }
	                }
	            }
	        }
        )
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
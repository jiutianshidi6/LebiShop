<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.sorteConfig.Language_Edit" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title>
        <%=Tag("站点设置")%>-<%=site.title%></title>

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
            <li class="submit"><a href="javascript:void(0);" onclick="SaveObj();"><b></b><span><%=Tag("保存")%></span></a></li>
            <%if (models.Count > 1 && model.id > 1){ %>
            <li class="del"><a href="javascript:void(0);" onclick="DelSite(<%=model.id %>);"><b>
            </b><span><%=Tag("删除站点")%></span></a></li>
            <%} %>
            <%}%>
            <li class="rotate"><a href="javascript:void(0);" onclick="javascript:history.back();"><b></b><span><%=Tag("返回")%></span></a></li>
            <li class="name"><span id="navIgation">
                <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="language.aspx"><%=Tag("站点设置")%></a> > <%=model.SubName %></span></li>
        </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <ul class="tablist clearfix">
        <li onclick="Edit(1)" id="p1" class="selected"><a><span><%=Tag("基本信息")%></span></a></li>
        <li onclick="Edit(2)" id="p2"><a><span><%=Tag("站点设置")%></span></a></li>
    </ul>
    <table id="table1" class="table">
        <tr>
            <th>
                <%=Tag("站点路径")%>：
            </th>
            <td>
                <em><%=site.WebPath %></em>
                <input type="text" id="Path" name="Path" class="input" shop="true" onchange="setpath();"
                    style="width: 200px;" value="<%=model.Path %>" /> <a href="<%if (model.Domain==""){ %><%=models.FirstOrDefault().Domain=="" ? site.WebPath + model.Path : "http://"+ models.FirstOrDefault().Domain + model.Path%><%}else{ %>http://<%=model.Domain%><%} %>" target="_blank"><img src="<%=PageImage("icon/newWindow.png")%>" /></a>
                    
            </td>
            <td style="width:120px" rowspan="3"><img src="<%=site.WebPath %>/inc/qrcode.aspx?txt=<%if (model.Domain==""){ %><%=models.FirstOrDefault().Domain=="" ? site.WebPath + model.Path : "http://"+ models.FirstOrDefault().Domain + model.Path%><%}else{ %>http://<%=model.Domain%><%} %>" width="120" height="120" /></td>
        </tr>
        <tr>
            <th>
                <%=Tag("站点简称")%>：
            </th>
            <td>
                <input type="text" id="SubName" name="SubName" maxlength="10" class="input" shop="true" min="notnull"
                    style="width: 200px;" value="<%=model.SubName %>" />
                <em></em>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("WAP站点")%>：
            </th>
            <td>
                <label><input type="radio" name="IsMobile" value="1" shop="true" <%=model.IsMobile==1?"checked":"" %> /><%=Tag("是")%></label>
                <label><input type="radio" name="IsMobile" value="0" shop="true" <%=model.IsMobile==0?"checked":"" %> /><%=Tag("否")%></label>
            </td>
        </tr>
        <%if (domain3admin || Shop.Bussiness.ShopCache.GetMainSite().id==model.id) {%>
        <tr>
            <th>
                <%=Tag("站点域名")%>：
            </th>
            <td colspan="2">
                <input type="text" id="Domain" name="Domain" class="input" shop="true" min="notnull"
                    style="width: 200px;" value="<%=model.Domain %>" />
                <em><%=Tag("不带http://")%><%=domain3admin ? ","+ Tag("不使用独立域名请留空") +"" : ""%></em>
            </td>
        </tr>
        <%} %>
        <tr>
            <th>
                <%=Tag("排序")%>：
            </th>
            <td colspan="2">
                <input type="text" class="input" id="Sort" name="Sort" onkeyup="value=value.replace(/[^\d]/g,'')"
                       shop="true" style="width: 80px;" value="<%=model.Sort %>" />
            </td>
        </tr>
        <tr>
            <th class="head" colspan="3">
                <%=Tag("微信登录设置")%>
            </th>
        </tr>
        <tr>
            <th>
                微信号
            </th>
            <td align="left" colspan="2">
                <input type="text" class="input" id="platform_weixin_number" name="platform_weixin_number"
                       shop="true" style="width: 200px;" value="<%=model.platform_weixin_number %>" />
                <em></em>
            </td>
        </tr>
        <tr>
            <th>
                Appid
            </th>
            <td align="left" colspan="2">
                <input type="text" class="input" id="platform_weixin_id" name="platform_weixin_id"
                       shop="true" style="width: 200px;" value="<%=model.platform_weixin_id %>" />
                <em></em>
            </td>
        </tr>
        <tr>
            <th>
                AppSecret
            </th>
            <td align="left" colspan="2">
                <input type="text" class="input" id="platform_weixin_secret" name="platform_weixin_secret"
                       shop="true" style="width: 200px;" value="<%=model.platform_weixin_secret %>" />
                <em></em>
            </td>
        </tr>
       
        <tr>
            <th>
                <%=Tag("二维码") %>
            </th>
            <td align="left" colspan="2">
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
        <tr>
            <th>
                Token
            </th>
            <td align="left" colspan="2">
                <input type="text" class="input" id="platform_weixin_custemtoken" name="platform_weixin_custemtoken"
                       shop="true" style="width: 200px;" value="<%=model.platform_weixin_custemtoken %>" />
                <em></em>
            </td>
        </tr>
        <tr>
            <th>
                关注自动回复消息
            </th>
            <td align="left" colspan="2">
                <input type="text" class="input" id="platform_weixin_subscribe_automsg" name="platform_weixin_subscribe_automsg"
                       shop="true" style="width: 200px;" value="<%=model.platform_weixin_subscribe_automsg %>" />
                <em></em>
            </td>
        </tr>
       
    </table>
    <table id="table2" style="display: none" class="table">
        <tr>
            <td colspan="2">
            <%=Shop.Bussiness.Language.AdminLanguageTab(model.id, Tag("添加语种"), "AddLanguage("+model.id+")")%>
            </td>
        </tr>
        <%foreach (Shop.Model.Lebi_Language lang in Shop.Bussiness.Language.SiteLanguages(model.id))
          {%>
        <tbody id="lang_<%=lang.Code %>" class="lang_table" style="display: none">
            <tr>
                <th>
                    <%=Tag("操作")%>：
                </th>
                <td>
                    <a href="javascript:void(0);" onclick="CreateTheme(<%=lang.id %>);">
                        <%=Tag("生成页面")%></a> <a href="javascript:void(0);" onclick="Del(<%=lang.id %>);">
                            <%=Tag("删除语种")%></a>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("网站名称")%>：
                </th>
                <td>
                    <input type="text" id="Name<%=lang.Code %>" name="Name<%=lang.Code %>" class="input"
                        style="width: 550px;" value="<%=Shop.Bussiness.Language.Content(model.Name, lang.Code)%>"
                        shop="true" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("网站标题")%>：
                </th>
                <td>
                    <input type="text" id="Title<%=lang.Code %>" name="Title<%=lang.Code %>" class="input"
                        style="width: 550px;" value="<%=Shop.Bussiness.Language.Content(model.Title, lang.Code)%>"
                        shop="true" />
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("网站关键词")%>：
                </th>
                <td>
                    <textarea id="Keywords<%=lang.Code %>" cols="80" rows="3" class="textarea" style="height: 60px;
                        width: 550px;" name="Keywords<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.Keywords, lang.Code)%></textarea>
                    <div class="tools clear">
                        <ul>
                            <li class="plus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Keywords<%=lang.Code %>',100);">
                                <b></b><span>
                                    <%=Tag("展开")%></span></a></li>
                            <li class="minus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Keywords<%=lang.Code %>',-100)">
                                <b></b><span>
                                    <%=Tag("收缩")%></span></a></li>
                        </ul>
                    </div>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("网站描述")%>：
                </th>
                <td>
                    <textarea id="Description<%=lang.Code %>" cols="80" rows="3" class="textarea" style="height: 60px;
                        width: 550px;" name="Description<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.Description, lang.Code)%></textarea>
                    <div class="tools clear">
                        <ul>
                            <li class="plus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Description<%=lang.Code %>',100);">
                                <b></b><span>
                                    <%=Tag("展开")%></span></a></li>
                            <li class="minus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Description<%=lang.Code %>',-100)">
                                <b></b><span>
                                    <%=Tag("收缩")%></span></a></li>
                        </ul>
                    </div>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("QQ号码")%>：
                </th>
                <td>
                    <input type="text" class="input" id="QQ<%=lang.Code %>" style="width: 200px;" name="QQ<%=lang.Code %>"
                        shop="true" value="<%=Shop.Bussiness.Language.Content(model.QQ, lang.Code)%>" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("电话号码")%>：
                </th>
                <td>
                    <input type="text" class="input" id="Phone<%=lang.Code %>" name="Phone<%=lang.Code %>"
                        shop="true" value="<%=Shop.Bussiness.Language.Content(model.Phone, lang.Code)%>"
                        style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("传真号码")%>：
                </th>
                <td>
                    <input type="text" class="input" id="Fax<%=lang.Code %>" name="Fax<%=lang.Code %>"
                        shop="true" value="<%=Shop.Bussiness.Language.Content(model.Fax, lang.Code)%>"
                        style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("电子邮件")%>：
                </th>
                <td>
                    <input type="text" class="input" id="Email<%=lang.Code %>" name="Email<%=lang.Code %>"
                        shop="true" value="<%=Shop.Bussiness.Language.Content(model.Email, lang.Code)%>"
                        style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("底部Html")%>：
                </th>
                <td>
                    <textarea id="FootHtml<%=lang.Code %>" cols="80" rows="3" class="textarea" style="height: 60px;
                        width: 550px;" shop="true" name="FootHtml<%=lang.Code %>"><%=Shop.Bussiness.Language.Content(model.FootHtml, lang.Code)%></textarea>
                    <div class="tools clear">
                        <ul>
                            <li class="plus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Copyright<%=lang.Code %>',100);">
                                <b></b><span>
                                    <%=Tag("展开")%></span></a></li>
                            <li class="minus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Copyright<%=lang.Code %>',-100)">
                                <b></b><span>
                                    <%=Tag("收缩")%></span></a></li>
                        </ul>
                    </div>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("底部版权")%>：
                </th>
                <td>
                    <textarea id="Copyright<%=lang.Code %>" cols="80" rows="3" class="textarea" style="height: 60px;
                        width: 550px;" shop="true" name="Copyright<%=lang.Code %>"><%=Shop.Bussiness.Language.Content(model.Copyright, lang.Code)%></textarea>
                    <div class="tools clear">
                        <ul>
                            <li class="plus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Copyright<%=lang.Code %>',100);">
                                <b></b><span>
                                    <%=Tag("展开")%></span></a></li>
                            <li class="minus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Copyright<%=lang.Code %>',-100)">
                                <b></b><span>
                                    <%=Tag("收缩")%></span></a></li>
                        </ul>
                    </div>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("网站Logo")%>：
                </th>
                <td>
                    <div id="image_Logoimg<%=lang.Code %>">
                        <%if (Lang(model.Logoimg, lang.Code) != "")
                          {%>
                        <img height="30" src="<%=site.WebPath + Lang(model.Logoimg,lang.Code)%>" />
                        <%} %>
                    </div>
                    <input type="text" shop="true" id="Logoimg<%=lang.Code %>" name="Logoimg<%=lang.Code %>"
                        class="input" style="width: 200px;" value="<%=Lang(model.Logoimg,lang.Code)%>" />
                    <input id="file_Logoimg<%=lang.Code %>" name="file_Logoimg<%=lang.Code %>" type="file"
                        onchange="uploadImage('Logoimg<%=lang.Code %>')" class="input" />
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("服务协议")%>：
                </th>
                <td>
                    <textarea id="ServiceP<%=lang.Code %>" cols="80" rows="5" class="textarea" style="height: 60px;
                        width: 550px;" name="ServiceP<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.ServiceP, lang.Code)%></textarea>
                    <div class="tools clear">
                        <ul>
                            <li class="plus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('ServiceP<%=lang.Code %>',100);">
                                <b></b><span>
                                    <%=Tag("展开")%></span></a></li>
                            <li class="minus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('ServiceP<%=lang.Code %>',-100)">
                                <b></b><span>
                                    <%=Tag("收缩")%></span></a></li>
                        </ul>
                    </div>
                </td>
            </tr>
            <%Shop.Model.Lebi_Language clang = GetLanguage(lang.Code, model.id); %>
            <tr>
                <th>
                    <%=Tag("语言名称")%>：
                </th>
                <td>
                    <input type="text" class="input" id="Name<%=clang.id %>" name="Name<%=clang.id %>"
                        shop="true" style="width: 200px;" value="<%=clang.Name %>" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("图标")%>：
                </th>
                <td>
                    <div id="image_ImageUrl<%=clang.id %>">
                        <%if (clang.ImageUrl != "")
                          {%>
                        <img src="<%=site.WebPath + clang.ImageUrl%>" />
                        <%} %>
                    </div>
                    <input type="text" shop="true" id="ImageUrl<%=clang.id %>" name="ImageUrl<%=clang.id %>"
                        class="input" style="width: 200px;" value="<%=clang.ImageUrl%>" />
                    <input id="file_ImageUrl<%=clang.id %>" name="file_ImageUrl<%=clang.id %>" type="file"
                        class="input" onchange="uploadImage('ImageUrl<%=clang.id %>')" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("货币")%>：
                </th>
                <td>
                    <select id="Currency_id" name="Currency_id<%=clang.id %>" shop="true">
                        <option value="0">
                            <%=Tag("请选择")%></option>
                        <%=Currencylist(clang.Currency_id)%>
                    </select>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("收货区域")%>：
                </th>
                <td>
                    <select id="TopAreaid<%=clang.id %>" name="TopAreaid<%=clang.id %>" shop="true">
                        <option value="0">
                            <%=Tag("全部") %></option>
                        <%=areas(clang.TopAreaid)%>
                    </select>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("使用主题")%>：
                </th>
                <td>
                    <select id="Theme_id<%=clang.id %>" name="Theme_id<%=clang.id %>" shop="true">
                        <option value="0">
                            <%=Tag("请选择")%></option>
                        <%=Themeslist(clang.Theme_id)%>
                    </select>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("生成路径")%>：
                </th>
                <td>
                    <em class="pathem"></em>
                    <input type="text" id="Path<%=clang.id %>" name="Path<%=clang.id %>" class="input"
                        shop="true" min="notnull" style="width: 200px;" value="<%=clang.Path %>" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("图片延迟加载")%>：
                </th>
                <td>
                    <label><input type="radio" name="IsLazyLoad<%=clang.id %>" value="1" shop="true" <%=clang.IsLazyLoad==1?"checked":"" %> /><%=Tag("开启")%></label>
                    <label><input type="radio" name="IsLazyLoad<%=clang.id %>" value="0" shop="true" <%=clang.IsLazyLoad==0?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
        </tbody>
        <%} %>
    </table>
    
    <script type="text/javascript">
        function Edit(id1) {
            $("#p"+id1+"").addClass("selected");
            $("#table" + id1).show();
            var id2 = 2;
            switch (id1) {
                case 1:
                    id2 = 2;break;
                case 2:
                    id2 = 1;break;
            }
            $("#p" + id2).removeClass("selected");
            $("#table" + id2).hide();
        }
        function AddLanguage(id) {
            var title_ ="<%=Tag("添加语种")%>"
            var url_ = "language_add_window.aspx?id=" + id;
            var width_ = 300;
            var height_ = 150;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Del(id) {
            if (!confirm("<%=Tag("确认要删除吗？")%>"))
                return false;
            var postData = { "id": id };
        var url = "<%=site.AdminPath %>/ajax/ajax_site.aspx?__Action=SiteLanguage_Del";
        RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?id=<%=model.id %>&tab=language")});
        }
        function DelSite(id)
        {
            if (!confirm("<%=Tag("确认要删除吗？")%>"))
                return false;
            var postData = { "id": id };
        var url = "<%=site.AdminPath %>/ajax/ajax_site.aspx?__Action=Site_Del";
        RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function AddSite(id)
        {
            if (!confirm("<%=Tag("确认操作吗？")%>"))
                return false;
            var postData = '';
            var url = "<%=site.AdminPath %>/ajax/ajax_site.aspx?__Action=AddSite";
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", "?id=<%=model.id %>&tab=language")});
        }
        function CreateTheme(Language_id) {
            var postData = { "Language_id": Language_id };
            var url="<%=site.AdminPath %>/ajax/ajax_aspx.aspx?__Action=CreateLanguageTheme";
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", "")});
        }
        function SaveObj()
        {
            var postData = GetFormJsonData("shop");
            var url = "<%=site.AdminPath %>/ajax/ajax_site.aspx?__Action=Site_Edit&id=<%=model.id %>";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "")});
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
                                $("#image_" + id + "").html('<img height="30" src=' + WebPath + imageUrl + '>');
                                $("#" + id + "").val(imageUrl);
                            }
                        }
                    },
                    error: function (data, status, e) {
                        MsgBox(2, data.msg, "");
                    }
                }
            )
        }
        function setpath(){
            var path=$("#Path").val();
            if(path=='/')
                path='';
            path=WebPath+path;
            $('.pathem').html(path);
        }
        setpath();
        LanguageTab_EditPage('<%=defalutlang.Code %>'); //加载默认语言
        <%if (tab=="language"){ %>Edit(2);<%} %>
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
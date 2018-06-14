<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.user.UserLevel_Edit" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Shop.Bussiness.Language.Content(model.Name, CurrentLanguage.Code) %>-<%=Tag("会员分组")%>-<%=site.title%></title>

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
        <a href="<%=site.AdminPath %>/ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><img src="<%=site.AdminImagePath%>/sys_logo.jpg" /></a>
    </div>
    <%=LicenseString %>
    <%=Version %>
    <a href="<%=site.AdminPath %>/config/Version.aspx" id="versiona" style="display:none;"><%=Tag("发现新版本")%> <%=Tag("点击此处更新")%> </a>
    <div id="service">
        <div class="layout">
            <span><em><%=Tag("您好！")%></em>[<%=Lang(CurrentAdminGroup.Name)%>]<%=CurrentAdmin.UserName%>&nbsp;&nbsp;<a href="javascript:AdminPWD(0);"><%=Tag("改密")%></a>&nbsp;|&nbsp;<a href="<%=site.AdminPath %>/Logout.aspx" onclick="return quit()"><%=Tag("注销")%></a>&nbsp;|&nbsp;<a href="<%=site.WebPath %>/" target="_blank"><%=Tag("网站前台")%></a></span>
        </div>
    </div>
    <div class="clearfix">
    </div>
    <div class="navmenu">
        <ul class="menu">
            <%foreach (Shop.Model.Lebi_Menu menu in TopMenus)
                { %>
            <li class="<%=CurrentTopMenu.id==menu.id?"current":"" %>"><a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=<%=menu.id %>"><span><%if (menu.Image != ""){ %><img src="<%=GetImage(site.WebPath + menu.Image) %>" height="15px" /><%} %><%=Tag(menu.Name)%></span></a> </li>
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
            <%foreach (Shop.Model.Lebi_Menu menu in GetIndexMenus()){ %><li><a href="<%=MenuUrl(menu.URL,1) %>"><span><%=Tag(menu.Name)%></span></a></li><%}%>
        </ul>
        <% }else{ %>
        <%foreach (Shop.Model.Lebi_Menu pmenu in GetMenus(CurrentTopMenu.Code)){ %>
        <h2><span><img mid="<%=pmenu.id %>" src="<%=site.AdminImagePath %>/<%=MenuShow(pmenu.id)==true?"minus":"plus" %>.gif" id="imgStatis" /> <%=Tag(pmenu.Name)%></span></h2>
        <ul class="clear" <%=MenuShow(pmenu.id)==true?"":"style=\"display:none;\"" %>>
            <%foreach (Shop.Model.Lebi_Menu menu in GetMenus(pmenu.Code)){ %><li><a href="<%=MenuUrl(menu.URL,0) %>"><span><%=Tag(menu.Name)%></span></a></li><%}%>
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
    <li class="submit"><a href="javascript:void(0);" onclick="SaveObj();"><b></b><span><%=Tag("保存")%></span></a></li>
    <li class="rotate"><a href="javascript:void(0);" onclick="history.back();"><b></b><span><%=Tag("返回")%></span></a></li>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="<%=site.AdminPath %>/user/default.aspx"><%=Tag("会员管理")%></a> > <a href="<%=site.AdminPath %>/user/UserLevel.aspx"><%=Tag("会员分组")%></a> > <%=Shop.Bussiness.Language.Content(model.Name, CurrentLanguage.Code) %></span></li>
    </ul>
    </div>

    </div>
      
      
    <div class="mainbody" id="body_main">
        <div id="body_main_form" style="min-width:1200px;width:100%">
          
    <style type="text/css">.bottom{display:none;height:0;overflow:hidden}</style>
    <%=Shop.Bussiness.Language.AdminLanguageTab("") %>
    <table cellspacing="0" cellpadding="0" border="0" width="100%" class="table">
        <%foreach (Shop.Model.Lebi_Language_Code lang in Shop.Bussiness.Language.Languages())
          {%>
        <tbody id="lang_<%=lang.Code %>" class="lang_table" style="display: none">
            <tr>
                <th>
                    <%=Tag("分组名称")%>：
                </th>
                <td>
                    <input type="text" id="Name<%=lang.Code %>" shop="true"  style="width: 400px;" name="Name<%=lang.Code %>"
                        value="<%=Shop.Bussiness.Language.Content(model.Name, lang.Code) %>" class="input" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("价格文字")%>：
                </th>
                <td>
                    <input type="text" id="PriceName<%=lang.Code %>" shop="true" style="width: 400px;"
                        name="PriceName<%=lang.Code %>" value="<%=Shop.Bussiness.Language.Content(model.PriceName, lang.Code) %>"
                        class="input" />
                </td>
            </tr>
        </tbody>
        <%} %>
        </table>
        <ul id="tablistmain"><li class="selected"><a><span><%=Tag("通用信息")%></span></a></li></ul>
        <table cellspacing="0" cellpadding="0" border="0" width="100%" id="common" class="table">
        <tr>
            <th>
                <%=Tag("等级ID")%>：
            </th>
            <td>
                <input type="text" id="Grade" name="Grade" onkeyup="value=value.replace(/[^\d]/g,'')" value="<%=model.Grade %>" class="input" shop="true" min="notnull" />
                &nbsp;<span id="Span1"><em><%=Tag("填0表示未登录的访客")%></em></span>
            </td>
        </tr>
        
        <tr>
            <th>
                <%=Tag("升级积分")%>：
            </th>
            <td>
                <input type="text" id="Lpoint" name="Lpoint" value="<%=model.Lpoint %>" class="input" onkeyup="value=value.replace(/[^\d]/g,'')" shop="true" min="notnull" />&nbsp;<span id="sp_fen"><em><%=Tag("升级会员等级所需积分")%></em></span>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("会员价格")%>：
            </th>
            <td>
                <%=Tag("销售价")%>× <input type="text" id="Price" name="Price" value="<%=model.Price %>" class="input" shop="true" min="notnull" onkeyup="value=value.replace(/[^\d.]/g,'')" maxlength="20"/>
                %&nbsp;<span id="sp_price"><em><%=Tag("1~100的数字")%></em></span>
            </td>
        </tr>
        <tr>
            <th valign="top">
                <%=Tag("等级图标")%>：
            </th>
            <td>
            <div id="image_ImageUrl">
                <%if (model.ImageUrl != "")
                    {%>
                <img height="30" src="<%=site.WebPath + model.ImageUrl%>" />
                <%} %>
            </div>
            <input type="text" shop="true" id="ImageUrl" name="ImageUrl" class="input" style="width: 200px;" value="<%=model.ImageUrl%>" />
            <input id="file_ImageUrl" name="file_ImageUrl" type="file" class="input" onchange="uploadImage('ImageUrl')" />
            
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("积分比率")%>：
            </th>
            <td>
                <%=Tag("消费1元可获得积分")%> <input type="text" id="MoneyToPoint" name="MoneyToPoint" onkeyup="value=value.replace(/[^\d\.]/g,'')" value="<%=model.MoneyToPoint %>" class="input" shop="true" min="notnull" />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("积分兑换规则")%>：
            </th>
            <td>
                <input type="text" id="PointToMoney" name="PointToMoney"  style="width: 400px;" value="<%=model.PointToMoney %>" class="input" shop="true" min="notnull" /> <span class="FormALT">100:1,200:2,500:5,1000:10</span>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("购买权限")%>：
            </th>
            <td>
                <input type="radio" id="rdo_buyright_open" name="BuyRight" checked value="1" shop="true" <%=model.BuyRight==1?"checked":"" %>/><%=Tag("开启")%>
                <input type="radio" id="rdo_buyright_close" name="BuyRight" value="0" shop="true" <%=model.BuyRight==0?"checked":"" %>/><%=Tag("关闭")%>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("评论审核")%>：
            </th>
            <td>
                <input type="radio" id="Radio1" name="Comment" checked value="1" shop="true" <%=model.Comment==1?"checked":"" %>/><%=Tag("开启")%>
                <input type="radio" id="Radio2" name="Comment" value="0" shop="true" <%=model.Comment==0?"checked":"" %>/><%=Tag("关闭")%>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("订单提交")%>：
            </th>
            <td>
                <%=Tag("金额大于")%> <input type="text" id="OrderSubmit" name="OrderSubmit" value="<%=model.OrderSubmit %>" onkeyup="value=value.replace(/[^\d\.]/g,'')" class="input" shop="true" min="notnull" />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("登录积分")%>：
            </th>
            <td>
                <%=Tag("增加")%>：<input type="text" id="LoginPointCut" name="LoginPointCut" shop="true" min="notnull" size="3" value="<%=model.LoginPointCut %>" class="input" onkeyup="value=value.replace(/[^\d]/g,'')" />&nbsp;&nbsp;
                <%=Tag("减少")%>：<input type="text" id="LoginPointAdd" name="LoginPointAdd" shop="true" min="notnull" size="3" value="<%=model.LoginPointAdd %>" class="input" onkeyup="value=value.replace(/[^\d]/g,'')" />
            </td>
        </tr>
        <tr>
            <th valign="top">
                <%=Tag("内部备注")%>：
            </th>
            <td>
                <textarea id="remark" name="remark" class="textarea" shop="true" cols="40" rows="5" style="height: 60px;width: 550px;"><%=model.remark%></textarea>
                <div class="tools clear">
                    <ul>
                        <li class="plus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('remark',100);"><b></b><span><%=Tag("展开")%></span></a></li>
                        <li class="minus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('remark',-100)"><b></b><span><%=Tag("收缩")%></span></a></li>
                    </ul>
                </div>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
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
	                MsgBox(2, data.error, "");
	            }
	        }
        )
        }
        LanguageTab_EditPage('<%=CurrentLanguage.Code %>'); //加载默认语言
        function SaveObj() {
            var postData = GetFormJsonData("shop");
            if (!CheckForm("shop", "span"))
                return false;
            var url= "<%=site.AdminPath %>/ajax/ajax_user.aspx?__Action=UserLevel_Edit&id=<%=model.id %>";
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", "userLevel.aspx");});
        }
    </script>

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
            <div class="menu"><a href="javascript:void(0);" onclick="UpdateCache(0);"><%=Tag("更新缓存")%></a><a href="javascript:void(0);" onclick="UpdateCache(1);"><%=Tag("数据同步")%></a></div>
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
<script type="text/javascript">
    function Copyright() {
        var title_ = "<%=Tag("关于")%>";
        var url_ = "<%=site.AdminPath %>/Config/Copyright_window.aspx";
        var width_ = 500;
        var height_ = 310;
        var modal_ = true;
        EditWindow(title_, url_, width_, height_, modal_);
    }
    function UpdateCache(type) {
        var postData = ""; 
        if (type == 0){
            postData = {'datatype':'languagetag,producttype,config,themepage'};
        }else{
            postData = {'datatype':'lebitype,lebimenu,lebipage,datatype'};
        }
        var url = "<%=site.AdminPath %>/ajax/ajax_db.aspx?__Action=CacheReset";
        RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "")});
    }
</script>
</body>
</html>
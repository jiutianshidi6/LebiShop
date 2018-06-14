<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.user.User_Edit" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%if (model.id != 0)
      { %>
    <%=Tag("编辑会员")%> <%=model.UserName %>
    <%}else{ %><%=Tag("会员添加")%>
    <%}%>-<%=Tag("会员管理")%>-<%=site.title%></title>

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
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="<%=site.AdminPath %>/user/default.aspx"><%=Tag("会员管理")%></a> > 
    <%if (model.id != 0)
      { %>
    <%=Tag("编辑会员")%> <%=model.UserName %>
    <%}else{ %><%=Tag("会员添加")%>
    <%}%></span></li>
    </ul>
    </div>

    </div>
      
      
    <div class="mainbody" id="body_main">
        <div id="body_main_form" style="min-width:1200px;width:100%">
          
    <div class="searchbox clear">
        <ul class="tabmenus">
            <li class="current"><a href="user_edit.aspx?id=<%=model.id %>"><span><%if (model.id != 0)
      { %><%=Tag("编辑会员")%><%}else{ %><%=Tag("会员添加")%><%}%></span></a></li>
            <li><a href="javascript:void(0)" onclick="EditPassword(<%=model.id %>);"><span><%=Tag("改密")%></span></a></li>
            <li><a href="javascript:void(0)" onclick="Question(<%=model.id %>);"><span><%=Tag("安全问题")%></span></a></li>
            <li><a href="UserMoney.aspx?user_id=<%=model.id %>"><span><%=Tag("资金")%></span></a></li>
            <li><a href="UserPoint.aspx?user_id=<%=model.id %>"><span><%=Tag("积分")%></span></a></li>
            <li><a href="../promotion/cardlist.aspx?user_id=<%=model.id %>&type=312"><span><%=Tag("代金券")%></span></a></li>
            <li><a href="Message.aspx?user_id=<%=model.id %>"><span><%=Tag("站内信")%></span></a></li>
            <li><a href="OftenBuy.aspx?user_id=<%=model.id %>"><span><%=Tag("常购清单")%></span></a></li>
        </ul>
        </div>
    </div>
    <table class="table" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <th>
                <%=Tag("会员帐号")%>：
            </th>
            <td>
                <%if (model.id == 0){ %><input name="UserName" id="UserName" value="<%=model.UserName %>" onchange="CheckUserName();" shop="true" type="text" class="input" style="width: 200px;" />
                <%}else{ %>
                <%=model.UserName %>
                <%}%>

                <span id="FormUserName"></span>
            </td>
            <%if (domain3admin)
              { %>
            <th>
               <%=Tag("站点")%>：
            </th>
            <td >
                <%=SiteName(model.Site_id)%>
            </td>
            <%}
              else
              {%>
            <th>&nbsp;</th>
            <td >&nbsp;</td>
            <%} %>
        </tr>
        <tr>
            <th>
                 <%=Tag("性别")%>：
            </th>
            <td>
                <input type="radio" name="Sex" shop="true" value="男" <%=model.Sex=="男"?"checked":""%> /><%=Tag("男")%>
                <input type="radio" name="Sex" shop="true" value="女" <%=model.Sex=="女"?"checked":""%> /><%=Tag("女")%>
            </td>
            <th>
                <%=Tag("绑定")%>：
            </th>
            <td > 
                <%
                  if (model.bind_weixin_id != "")
                  {
                      Response.Write("<img src=\"" + SYS.platform_weixin_image + "\" height=\"24px\" />");
                  }
                  if (model.bind_weibo_id != "")
                  {
                      Response.Write("<img src=\"" + SYS.platform_weibo_image + "\" height=\"24px\" />");
                  }
                  if (model.bind_qq_id != "")
                  {
                      Response.Write("<img src=\"" + SYS.platform_qq_image + "\" height=\"24px\" />");
                  }
                  if (model.bind_taobao_id != "")
                  {
                      Response.Write("<img src=\"" + SYS.platform_taobao_image + "\" height=\"24px\" />");
                  }
                  if (model.bind_facebook_id != "")
                  {
                      Response.Write("<img src=\"" + SYS.platform_facebook_image + "\" height=\"24px\" />");
                  }
                %>&nbsp;
            </td>
        </tr>
         <tr  >
            <th>
                <%=Tag("会员编号")%>：
            </th>
            <td >
                <input name="UserNumber" value="<%=model.UserNumber %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
            <th>
                <%=Tag("有效期")%>：
            </th>
            <td >
                <input name="Time_End" value="<%=FormatDate(model.Time_End)%>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <%--<tr  >
            <th style="width:12%">
                <%=Tag("密码问题")%>：
            </th>
            <td style="width:38%">
                <input name="pwdwen" value="<%=model.pwdwen %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
            <th style="width:12%">
                <%=Tag("密码答案")%>：
            </th>
            <td style="width:38%">
                <input name="pwdda" value="<%=model.pwdda %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>--%>
        <tr  >
            <th>
                <%=Tag("真实姓名")%>：
            </th>
            <td >
                <input name="RealName" value="<%=model.RealName %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
            <th>
                <%=Tag("昵称")%>：
            </th>
            <td >
                <input name="NickName" value="<%=model.NickName %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr  >
            <th>
                <%=Tag("出生日期")%>：
            </th>
            <td >
                <input name="Birthday" value="<%if (model.id > 0){Response.Write(FormatDate(model.Birthday));} %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
            <th>
                <%=Tag("手机号码")%>：
            </th>
            <td >
                <input name="MobilePhone" value="<%=model.MobilePhone %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr  >
            <th>
                <%=Tag("电话号码")%>：
            </th>
            <td >
                <input name="Phone" value="<%=model.Phone %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
            <th>
                <%=Tag("传真号码")%>：
            </th>
            <td >
                <input name="Fax" value="<%=model.Fax %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("QQ号码")%>：
            </th>
            <td >
                <input name="QQ" value="<%=model.QQ %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
            <th>
                <%=Tag("Email地址")%>：
            </th>
            <td >
                <input name="Email" value="<%=model.Email %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("会员分组")%>：
            </th>
            <td>
                <select name="UserLevel_id" shop="true">
                <option value="0">┌ <%=Tag("会员分组")%></option>
                <%=Shop.Bussiness.EX_User.TypeOption("grade > 0", model.UserLevel_id, CurrentLanguage.Code)%>
                </select>
            </td>
            <th>
                <%=Tag("语言")%>：
            </th>
            <td>
                <select name="Language" id="Language" shop="true">
                    <%= Shop.Bussiness.Language.LanguageOption(model.Language)%>
                </select>
            </td>
        </tr>
        <tr  >
            <th valign="top">
                <%=Tag("内部备注")%>：<br>
                <em>≤ <span id="remLen">255</span></em>
            </th>
            <td colspan="3">
                <textarea name="Introduce" id="Introduce" shop="true" rows="3" cols="60" class="input" onKeyDown="checkMaxInput(this.form)" onKeyUp="checkMaxInput(this.form)" style="height: 55px;width: 550px;"><%=model.Introduce%></textarea>
                <div class="tools clear">
                    <ul>
                        <li class="plus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Introduce',100);"><b></b><span><%=Tag("展开")%></span></a></li>
                        <li class="minus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Introduce',-100)"><b></b><span><%=Tag("收缩")%></span></a></li>
                    </ul>
                </div>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        var maxLen = 255;
        var Introduce = document.getElementById("Introduce");
        function checkMaxInput(form) {
        if (Introduce.value.length > maxLen)
        Introduce.value = Introduce.value.substring(0, maxLen);
        else document.getElementById("remLen").innerHTML = maxLen - Introduce.value.length;
        }
        function SaveObj() {
            var postData = GetFormJsonData("shop");
            var url = "<%=site.AdminPath %>/ajax/ajax_user.aspx?__Action=User_Edit&id=<%=model.id %>";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "default.aspx")});
        }
        function CheckUserName()
        {
            var UserName=$("#UserName").val();
            var postData={"UserName":UserName};
            var url = "<%=site.AdminPath %>/ajax/ajax_user.aspx?__Action=CheckUserName&id=<%=model.id %>";
            $.ajax({
            type: "POST",
            url: url,
            data: postData,
            dataType: 'json',
            success: function (res) {
                if(res.msg=="OK")
                    CheckOK("UserName",'');
                else
                    CheckNO("UserName",'<%=Tag("用户名已经存在") %>');
                }
            });
        }
        function EditPassword(id) {
            var title_ = "<%=Tag("改密")%>";
            var url_ = "userpassword_edit_window.aspx?id="+id;
            var width_ = 500;
            var height_ = 220;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Question(id) {
            var title_ = "<%=Tag("安全问题")%>";
            var url_ = "userquestion_edit_window.aspx?id="+id;
            var width_ = 500;
            var height_ = 260;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
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
<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.user.UserPoint" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("会员积分")%>-<%=Tag("会员管理")%>-<%=site.title%></title>

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
            <li class="add"><a href="javascript:void(0);" onclick="EditObj('<%=user.UserName %>',0);"><b></b><span><%=Tag("添加")%></span></a></li>
            <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="<%=site.AdminPath %>/user/default.aspx"><%=Tag("会员管理")%></a> > <a href="<%=site.AdminPath %>/user/UserPoint.aspx"><%=Tag("会员积分")%></a><%if (user.UserName != ""){ %> > <%=user.UserName%><%} %></span>
           </li>
        </ul>
    </div>

    </div>
      
      
    <div class="mainbody" id="body_main">
        <div id="body_main_form" style="min-width:1200px;width:100%">
          
    <script type="text/javascript" src="<%=site.AdminJsPath %>/My97DatePicker/WdatePicker.js"></script> 
    <div class="searchbox">
        <select name="status" id="status">
            <option value="0">┌ <%=Tag("状态")%></option>
            <%=Shop.Bussiness.EX_Type.TypeOption("PointStatus", status)%>
        </select>
        <input type="text" name="dateFrom" id="dateFrom" size="12" class="input-calendar" value="<%=dateFrom %>" onClick="WdatePicker()" /> - <input type="text" name="dateTo" id="dateTo" size="12" class="input-calendar" value="<%=dateTo %>" onClick="WdatePicker()" />
        <input name="key" type="text" id="key" class="input-query" value="<%=key %>" onkeydown="if(event.keyCode==13){search_();}" /><input type="button" id="btnSou" class="btn-query" onclick="search_();" align="absmiddle" />
    </div>
    <table cellpadding="0" cellspacing="0" width="100%" border="0" class="datalist">
        <tr class="title">
            <th style="width: 150px">
                <%=Tag("会员帐号")%>
            </th>
            <th style="width: 150px">
                <%=Tag("姓名")%>
            </th>
            <th style="width: 100px">
                <%=Tag("积分")%>
            </th>
            <th style="width: 100px">
               <%=Tag("状态")%>
            </th>
            <th style="width: 130px">
                <%=Tag("时间")%>
            </th>
            <th style="width: 120px">
                <%=Tag("管理员")%>
            </th>
            <th style="width: 130px">
                <%=Tag("操作时间")%>
            </th>
            <th>
                <%=Tag("操作")%>
            </th>
        </tr>
        <%foreach (Shop.Model.Lebi_User_Point model in models)
          {
              Shop.Model.Lebi_User muser = GetUser(model.User_id);%>
        <tr class="list" ondblclick="EditObj(<%=model.User_id+","+ model.id %>);">
            <td>
                <a href="?user_id=<%=muser.id %>"><%=model.User_UserName %></a>
            </td>
             <td>
                <a href="?user_id=<%=muser.id %>"><%=model.User_RealName%></a>
            </td>
            <td>
                <%=model.Point %>
            </td>
            <td>
                <%=Shop.Bussiness.EX_Type.TypeName(model.Type_id_PointStatus) %>
            </td>
            <td>
                <%=FormatTime(model.Time_Add) %>
            </td>
            <td>
                <%=model.Admin_UserName %>
            </td>
            <td>
                <%if (model.Admin_UserName != "")
                  {%><%=FormatTime(model.Time_Update) %><%}else{%>&nbsp;<%} %>
            </td>
            <td>
                <a href="javascript:void(0)" onclick="EditObj('<%=model.User_UserName%>',<%=model.id %>);"><%=Tag("编辑")%></a> 
            </td>
        </tr>
        <%} %>
    </table>
    <script type="text/javascript">
        function search_() {
            var key = $("#key").val();
            var dateFrom = $("#dateFrom").val();
            var dateTo = $("#dateTo").val();
            var status = $("#status").val();
            window.location = "?key=" + escape(key) + "&dateFrom=" + dateFrom + "&dateTo=" + dateTo + "&status=" + status;
        }
        function EditObj(User_Name,id) {
            var title_ = "<%=Tag("编辑积分")%>";
            if (id ==0)
                var title_ = "<%=Tag("添加积分")%>";
            var url_ = "userpoint_edit_window.aspx?User_Name=" + User_Name+"&id="+id;
            var width_ = 600;
            var height_ = 300;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
    </script>

        </div>
    </div>
    
    <div class="bottom" id="body_bottom">
        <%=PageString%>
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
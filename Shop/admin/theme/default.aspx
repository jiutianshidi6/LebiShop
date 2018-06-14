<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.theme.Default" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("模板管理")%>-<%=site.title%></title>

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
            <li class="add"><a href="javascript:void(0);" onclick="Edit(0);"><b></b><span>
                <%=Tag("添加")%></span></a></li>
            <li class="skin"><a href="ThemeOnline.aspx"><b></b><span>
                <%=Tag("在线模板")%></span></a></li>
            <%if (Shop.Tools.RequestTool.GetConfigKey("ThemeUpdate").Trim() != "0"){ %>
                <li class="down"><a href="javascript:void(0);" onclick="CheckVersion();"><b></b><span><%=Tag("检查更新")%></span></a></li>
            <%}%>
            <%}%>
            <li class="name"><span id="navIgation">
                <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a>
                >
                <%=Tag("模板管理")%></span></li>
        </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <table class="datalist">
        <tr class="title">
            <th style="width: 100px;">
                <%=Tag("缩略图")%>
            </th>
            <th style="width: 150px;">
                <%=Tag("名称")%>
            </th>
            <th style="width: 100px;">
                <%=Tag("支持语言")%>
            </th>
            <th style="width: 100px;">
                <%=Tag("启用语言")%>
            </th>
            <th style="width: 150px;">
                <%=Tag("路径")%>
            </th>
            <th style="width: 130px;">
                <%=Tag("添加时间")%>
            </th>
            <th>
                <%=Tag("操作")%>
            </th>
        </tr>
        <%foreach (Shop.Model.Lebi_Theme model in models)
          {%>
        <tr class="list" ondblclick="Theme(<%=model.id %>);">
            <td>
             <a href="<%=Shop.Bussiness.ThemeUrl.CheckURL(WebPath + model.Path_Files+"/"+model.ImageUrl) %>" data-lightbox="image<%=model.id %>"><img src="<%=Shop.Bussiness.ThemeUrl.CheckURL(WebPath + model.Path_Files+"/"+model.ImageSmallUrl) %>" /></a>
            </td>
            <td>
                <%=model.Name %><br /><em><%=Tag("版本")%>：<%=model.Version %></em><br /><em><%=Tag("排序")%>：<%=model.Sort%></em>
            </td>
            <td>
                <%=model.Language %>
            </td>
            <td>
                <%=GetLanguage(model)%>
            </td>
            <td>
                <%=model.Path_Files %>
            </td>
            <td>
                <%=FormatTime(model.Time_Add) %>
            </td>
            <td>
                <a href="javascript:void(0)" onclick="Edit(<%=model.id %>);">
                    <%=Tag("编辑")%></a> | <a href="javascript:void(0)" onclick="Theme(<%=model.id %>);">
                        <%=Tag("编辑模板")%></a> | <a href="javascript:void(0)" onclick="CreateTheme(<%=model.id %>);">
                            <%=Tag("生成模板")%></a> | <a href="javascript:void(0)" onclick="Advert(<%=model.id %>);">
                                <%=Tag("广告位")%></a> | <a href="javascript:void(0)" onclick="Copy(<%=model.id %>);">
                                    <%=Tag("复制")%></a> | <a href="javascript:void(0)" onclick="Del(<%=model.id %>);">
                                    <%=Tag("删除")%></a>
                <%if (model.IsUpdate == 1){%>
                <%if (model.IsNew==1 && model.LebiUser!=SYS.LicenseUserName && Shop.Tools.RequestTool.GetConfigKey("ThemeUpdate").Trim() != "0")
                  { %>
                  | <a href="javascript:void(0)" onclick="DownLoad(<%=model.id %>);"><%=Tag("升级")%></a>
                <%} %>
                <%} %>
            </td>
        </tr>
        <%} %>
    </table>
    <script type="text/javascript">
        function Theme(id) {
            window.location = "skin.aspx?id="+id;
        }
        function Edit(id) {
            var title_ = "<%=Tag("编辑模板")%>";
            if (id == 0)
                var title_ = "<%=Tag("添加模板")%>";
            var url_ = "theme_edit_window.aspx?id=" + id;
            var width_ = 800;
            var height_ = "auto";
            var modal_ = true;
            //EditWindow(title_, url_, width_, height_, modal_);
            window.location = "theme_edit.aspx?id="+id;
        }
        function Theme(id) {
            window.location = "skin.aspx?id=" + id;
        }
        function Del(id) {
            if (!confirm("<%=Tag("确认要删除吗？")%>"))
                return false;
            var postData = { "id": id };
            var url="<%=site.AdminPath %>/ajax/ajax_theme.aspx?__Action=Theme_Del";
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function CreateTheme(Theme_id) {
            var postData = { "Theme_id": Theme_id };
            var url="<%=site.AdminPath %>/ajax/ajax_aspx.aspx?__Action=CreateTheme";
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", "")});
        }
        function Advert(id){
            window.location = "advert.aspx?id=" + id;
        }
        function DownLoad(id) {
            if (!confirm("<%=Tag("确认操作吗？升级将覆盖模板中所有修改！")%>"))
                return false;
            var postData = { "id": id };
            var url="<%=site.AdminPath %>/ajax/ajax_theme.aspx?__Action=Theme_Update";
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function Copy(id) {
            if (!confirm("<%=Tag("确认操作吗？")%>"))
                return false;
            var postData = { "id": id };
            var url="<%=site.AdminPath %>/ajax/ajax_theme.aspx?__Action=Theme_Copy";
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function CheckVersion()
        {
            var url="<%=site.AdminPath %>/ajax/ajax_theme.aspx?__Action=Theme_CheckVersion";
            RequestAjax(url,'',function(res){MsgBox(1, "<%=Tag("发现更新")%>", "?")});
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
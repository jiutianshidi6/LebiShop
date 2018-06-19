<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.product.Comment" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("商品评价")%>-<%=site.title%></title>

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
    <li class="submit"><a href="javascript:void(0);" onclick="Update();"><b></b><span><%=Tag("保存")%></span></a></li>
    <li class="del"><a href="javascript:void(0);" onclick="Del();"><b></b><span><%=Tag("删除")%></span></a></li>
    <%}%>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <%=Tag("商品评价")%></span></li>
    </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <div class="searchbox">
        <select id="lang">
            <option value="">┌<%=Tag("语言")%></option>
            <%=Shop.Bussiness.Language.LanguageOption(lang)%>
        </select>
        <select name="status" id="status">
            <option value="0">┌<%=Tag("状态")%></option>
            <%=Shop.Bussiness.EX_Type.TypeOption("CommentStatus", status, CurrentLanguage.Code)%>
        </select>
        <input type="text" name="dateFrom" id="dateFrom" size="12" class="input-calendar" value="<%=dateFrom %>" /> - <input type="text" name="dateTo" id="dateTo" size="12" class="input-calendar" value="<%=dateTo %>" />
        <input type="text" id="key" name="key" class="input-query" value="<%=key %>" onkeydown="if(event.keyCode==13){search_();}" /><input type="button" id="btnSou" class="btn-query" onclick="search_();" />
    </div>
    <table class="datalist">
        <tr class="title">
            <th style="width: 40px" class="selectAll">
                <a href="javascript:void(0);" onclick="$('input[name=\'Delid\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));"><%=Tag("全选")%></a>
            </th>
            <th style="width: 40px">
                <%=Tag("图片")%>
            </th>
            <th style="width: 300px;">
                <%=Tag("商品名称")%>
            </th>
            <th>
                <%=Tag("内容")%>
            </th>
            <th style="width: 120px">
                <%=Tag("会员账号")%>
            </th>
            <th style="width: 80px">
                <%=Tag("状态")%>
            </th>
            <th style="width: 80px">
                <%=Tag("操作")%>
            </th>
        </tr>
        <%foreach (Shop.Model.Lebi_Comment model in models)
          {%>

        <tr class="list" ondblclick="Edit(<%=model.id %>);" >
            <td style="text-align:center">
                <input type="checkbox" name="Delid" del="true" value="<%=model.id %>" />
                <input type="hidden" name="IDS" shop="true" value="<%=model.id %>" />
            </td>
            <td>
                <div class="piclist<%=model.id %>"><% if (GetProduct(model.Keyid).ImageSmall == "")
                   { %>
                &nbsp;
                <%}else
                   { %>
                <a href="<%=Image(GetProduct(model.Keyid).ImageOriginal,"big") %>" data-lightbox="image<%=model.id %>" ><img style="height: 30px;width: 30px;vertical-align:middle" src="<%=Image(GetProduct(model.Keyid).ImageOriginal,50,50) %>" /></a>
                <%} %></div>
            </td>
            <td style="width:300px;word-break:break-all;word-wrap:break-word;">
                <%=Lang(GetProduct(model.Keyid).Name)%>&nbsp;<a target="_blank" href="<%=Shop.Bussiness.ThemeUrl.GetURL("P_Product",model.Keyid.ToString(),"",CurrentLanguage.Code)%>"><img src="<%=AdminImage("icon/newWindow.png")%>" /></a>
            </td>
            <td>
            <%=model.Content.Replace("\r\n", "<br/>")%><em>(<%=FormatTime(model.Time_Add)%>)</em>
            <ul class="sharepiclist<%=model.id %> clearfix">
                <%
                    string[] images = model.ImagesSmall.Split('@');
                    string[] bigs = model.Images.Split('@');
                    for (int i = 0; i < images.Count();i++)
                    {
                        if (images[i] == "")
                            continue;
                %>
                <li class="imagespreviewlist">
                    <span class="image"><a href="<%=WebPath+bigs[i] %>" data-lightbox="image<%=model.id %>"><img src="<%=WebPath+images[i] %>" /></a></span>
                </li>
                    <%} %>
            </ul>
            </td>
            <td>
                <%=model.User_UserName %>
            </td>
            <td>
                <select name="status<%=model.id %>" shop="true">
                    <%=Shop.Bussiness.EX_Type.TypeOption("CommentStatus", model.Status, CurrentLanguage.Code)%>
                </select>
            </td>
            <td>
                <a href="javascript:void(0)" onclick="Edit(<%=model.id %>);"><%=Tag("编辑")%></a>
            </td>
        </tr>
        <%} %>
    </table>
    <script type="text/javascript">
        function search_() {
            var status = $("#status").val();
            var lang = $("#lang").val();
            var key = $("#key").val();
            var dateFrom = $("#dateFrom").val();
            var dateTo = $("#dateTo").val();
            window.location = "?key=" + escape(key) + "&lang=" + lang + "&status=" + status + "&dateFrom=" + dateFrom + "&dateTo=" + dateTo;
        }
        function Edit(id) {
            var title_ = "<%=Tag("回复商品评价")%>";
            var url_ = "comment_edit_window.aspx?id=" + id;
            var width_ = 600;
            var height_ = "auto";
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Del() {
            if (!confirm("<%=Tag("确认要删除吗？")%>"))
                return false;
            var postData = GetFormJsonData("del");
            var url = "<%=site.AdminPath %>/ajax/ajax_product.aspx?__Action=Comment_Del";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function Update() {
            var postData = GetFormJsonData("shop");
            var url = "<%=site.AdminPath %>/ajax/ajax_product.aspx?__Action=Comment_Update";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
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
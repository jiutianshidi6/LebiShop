<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.Config.Version" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title>
        <%=Tag("版本管理")%>-<%=site.title%></title>

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
            <li class="submit"><a><span>
                <%=Tag("当前版本")%>: <%=SYS.Version %>.<%=SYS.Version_Son %></span></a></li>
            <%if (PageReturnMsg == ""){%>
            <li class="down"><a href="javascript:void(0);" onclick="CheckVersion();"><b></b><span>
                <%=Tag("检查新版本")%></span></a></li>
            <%}%>
            <li class="name"><span id="navIgation">
                <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a>
                >
                <%=Tag("版本管理") %></span></li>
        </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <% LicenseWord(); %>
    <table class="datalist">
        <tr class="title">
            <th style="width: 80px">
                <%=Tag("版本号")%>
            </th>
            <th style="width: 80px">
                <%=Tag("文件大小")%>
            </th>
            <th style="width: 150px">
                <%=Tag("文件路径")%>
            </th>
            <th style="width: 60px">
                <%=Tag("文件状态")%>
            </th>
            <th>
                <%=Tag("描述")%>
            </th>
            <th style="width: 130px">
                <%=Tag("更新时间")%>
            </th>
            <th style="width: 220px">
                <%=Tag("操作")%>
            </th>
        </tr>
        <%foreach (Shop.Model.Lebi_Version model in models)
          {%>
        <tr class="list" ondblclick="Edit(<%=model.id %>);">
            <td>
                <%=model.Version %>.<%=model.Version_Son %>
            </td>
            <td>
                <%=model.Size%>
                KB
            </td>
            <td>
              <%=model.Path_rar == "" ? "-" : model.Path_rar%>
            </td>
            <td>
               <%if (model.Path_rar != "")
                 {
                     if (IsDown(model))
                     { %>
              <img src="<%=PageImage("icon/toolsSubmit.png") %>" />
              <%}
                     else
                     { %>
              <img src="<%=PageImage("icon/toolsDel2.png") %>" />
              <%}
                 } %>
            </td>
            <td>
              <%=Shop.Tools.Utils.GetUnicodeSubString(model.Description, 70, "...")%>
            </td>
            <td>
                <%=model.IsUpdate==1?model.Time_Update.ToString():""%>
            </td>
            <td>
                <%if (model.IsUpdate == 0)
                  {
                      if (Shop.LebiAPI.Service.Instanse.ISRightVersion(SYS, model))
                      {
                          if (model.Path_rar != "")
                          {%>
                           <a href="javascript:void(0)" onclick="Version_UpdateOK(<%=model.id%>);"><%=Tag("已更新")%></a> | 
                           <a href="<%=Shop.LebiAPI.Service.Instanse.downurl %><%=model.Path_rar%>" target="_blank" ><%=Tag("下载")%></a> |
                           <%}%>
                        
                        <a href="<%=site.AdminPath %>/update.aspx?id=<%=model.id%>" target="_blank" ><%=Tag("升级")%></a> | 
                      <%
                       }
                  }
                  %>
                <a href="javascript:void(0)" onclick="Show(<%=model.id %>);"><%=Tag("详情")%></a> |
                <a href="javascript:void(0)" onclick="Del(<%=model.id %>);"><%=Tag("删除")%></a>
                <div style="display:none;" id="show_<%=model.id %>">
                <div style="text-align:left;" ><%=model.Content %></div>
                </div>
            </td>
        </tr>
        <%} %>
    </table>
    <div id="dss"></div>
    <script type="text/javascript">
        function Show(id) {
            var title_ = "<%=Tag("详细")%>";
            var div_ = "show_" + id;
            var width_ = 400;
            var height_ = 400;
            var modal_ = true;
            ShowWindow(title_, div_, width_, height_, modal_);
        }
        function SaveObj() {
            var postData = GetFormJsonData("shop");
            var url="<%=site.AdminPath %>/ajax/ajax_service.aspx?__Action=CheckType";
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", "")});
        }
        function CheckVersion() {
            var postData = '';
            var url="<%=site.AdminPath %>/ajax/ajax_service.aspx?__Action=CheckVersion";
            RequestAjax(url,postData,function(res){
                if(res.count>0)
                    MsgBox(1, "<%=Tag("发现新版本")%>", "?");
                else
                    MsgBox(2, "<%=Tag("未发现新版本")%>", "");
            });
        }
         function DownLoad(id) {
            var postData = {"id":id};
            var url="<%=site.AdminPath %>/ajax/ajax_service.aspx?__Action=Version_DownLoad";
            $.ajax({
                type: "POST",
                url: url,
                data: postData,
                dataType: "json",
                beforeSend: function () {
                    MsgBox(4, "<%=Tag("下载文件") %> ……", "-");
                },
                success: function (res) {
                    if(res.msg=="OK"){
                        MsgBox(4, "<%=Tag("下载文件完毕") %>", "-");
                        FileUpdate(id);
                        //CheckVersion();
                    }else{
                        MsgBox(2, res.msg, "");
                    }
                }
            }); 
        }
        //部署文件
         function Version_UpdateOK(id) {
            if (!confirm("<%=Tag("确认已经手动更新了吗？")%>"))
                return false;
            var postData = {"id":id};
            var url="<%=site.AdminPath %>/ajax/ajax_service.aspx?__Action=Version_UpdateOK";
            $.ajax({
                type: "POST",
                url: url,
                data: postData,
                dataType: "json",
                beforeSend: function () {
                    MsgBox(4, "<%=Tag("正在提交") %> ……", "-");
                },
                success: function (res) {
                    if(res.msg=="OK"){
                        MsgBox(1, "<%=Tag("操作成功")%>", "?");
                    }else{
                        MsgBox(2, res.msg, "");
                    }
                }
            }); 
        }
        function Del(id) {
            if (!confirm("<%=Tag("确认要删除吗？")%>"))
                return false;
            var postData = { "id": id };
            var url = "<%=site.AdminPath %>/ajax/ajax_service.aspx?__Action=Version_Del";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
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
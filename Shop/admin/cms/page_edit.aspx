<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.cms.Page_Edit" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=pnode.Name%>-<%=Tag(node.Name)%>-<%=site.title%></title>

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
    <script type="text/javascript" src="<%=site.WebPath %>/Editor/ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="<%=site.WebPath %>/Editor/ckfinder/ckfinder.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/bigcolorpicker/jquery.bigcolorpicker.css" /> 
    <script type="text/javascript" src="<%=site.AdminJsPath %>/bigcolorpicker/jquery.bigcolorpicker.min.js"></script> 
    <script type="text/javascript" src="<%=site.AdminJsPath %>/My97DatePicker/WdatePicker.js"></script> 
    <script type="text/javascript">
        $(function () {
            $("#NameColor").bigColorpicker("NameColor");
            $("#s_NameColor").bigColorpicker(function (el, color) { $(el).css("background-color", color); $("#NameColor").val(color); $("#Name").css("color", color); });
        });
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
            <li class="submit"><a href="javascript:void(0);" onclick="SaveObj();"><b></b><span>
                <%=Tag("保存")%></span></a></li>
            <li class="rotate"><a href="javascript:void(0);" onclick="history.go(-1);"><b></b><span>
                <%=Tag("返回")%></span></a></li>
            <li class="name"><span id="navIgation">
                <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a>
                > <a href="UserNodeList.aspx?code=<%=pnode.Code %>">
                    <%=pnode.Name%></a> > <a href="<%=Shop.Bussiness.NodePage.AdminIndexPage(node) %>">
                        <%=Tag(node.Name)%></a><%if (page.Name != "")
                                                 {%>
                >
                <%=page.Name%><%} %></span></li>
        </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <table class="table">
        <%if (node.haveson == 1)
          { %>
        <tr>
            <th>
                <%=Tag("分类")%>：
            </th>
            <td>
                <select name="Node_id" id="Node_id" shop="true">
                    <%=GetOptionTreeString(0, pnode.id, node.id)%>
                </select>
            </td>
        </tr>
        <%}
          else
          { %>
        <input type="hidden" name="Node_id" id="Node_id" value="<%=node.id %>" shop="true">
        <%} %>
        <tr>
            <th>
                <%=Tag("标题")%>：
            </th>
            <td>
                <input type="text" id="Name" name="Name" class="input" shop="true" min="notnull"
                    style="width: 500px; color: <%=page.NameColor %>" value="<%=page.Name %>" />&nbsp;<input
                        id="NameColor" name="NameColor" type="hidden" shop="true" value="<%=page.NameColor %>"><img
                            id="s_NameColor" border="0" src="<%=AdminImage("rect.gif")%>" width="18" align="absmiddle"
                            style="cursor: pointer; background-color: <%=page.NameColor %>">
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("副标题")%>：
            </th>
            <td>
                <input type="text" id="SubName" name="SubName" class="input" shop="true" style="width: 500px;" value="<%=page.SubName %>" />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("跳转页面")%>：
            </th>
            <td>
                <input type="text" id="url" name="url" class="input" style="width: 500px;" shop="true"
                    value="<%=page.url %>" />
            </td>
        </tr>
        <tr>
            <th style="vertical-align:top">
                <%=Tag("摘要")%>：
            </th>
            <td>
                <textarea id="Description" name="Description" shop="true" cols="95" rows="4" class="textarea"
                    style="width: 500px; height: 60px;"><%=page.Description%></textarea>
                <div class="tools clear">
                    <ul>
                        <li class="plus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Description',100);">
                            <b></b><span>
                                <%=Tag("展开")%></span></a></li>
                        <li class="minus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Description',-100)">
                            <b></b><span>
                                <%=Tag("收缩")%></span></a></li>
                    </ul>
                </div>
            </td>
        </tr>
        <tr>
            <th style="vertical-align:top">
                <%=Tag("内容")%>：
            </th>
            <td>
                <textarea name="Content" id="Content" style="width: 800px; height: 200px;" shop="true"
                    class="textarea"><%=page.Content%></textarea>
            </td>
        </tr>
        <%if (node.Code != "News" && node.Code != "Help" && node.Code != "About")
          { %>
        <tr>
            <th>
                <%=Tag("来源")%>：
            </th>
            <td>
                <input type="text" id="source" name="source" shop="true" class="input" style="width: 220px"
                    value="<%=page.source %>" />
            </td>
        </tr>
        <tr>
            <th style="vertical-align:top">
                <%=Tag("图文")%>：
            </th>
            <td>
                <div id="image_ImageSmall">
                    <%if (page.ImageSmall != "")
                      {%><img height="80" src="<%=site.WebPath + page.ImageSmall%>" /><%} %></div>
                <input type="text" shop="true" id="ImageSmall" name="ImageSmall" class="input" style="width: 200px;"
                    value="<%=page.ImageSmall%>" />
                <input id="file_ImageSmall" name="file_ImageSmall" class="input" type="file" onchange="uploadImage('ImageSmall')" />
                
            </td>
        </tr>
        <%} %>
        <tr>
            <th>
                <%=Tag("浏览次数")%>：
            </th>
            <td>
                <input type="text" id="Count_Views" name="Count_Views" shop="true" style="width: 50px"
                    class="input" value="<%=page.Count_Views %>" />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("提交时间")%>：
            </th>
            <td>
                <input type="text" id="Time_Add" name="Time_Add" shop="true" class="calendar" style="width: 150px"
                    onclick="WdatePicker()" value="<%=page.Time_Add %>" />
            </td>
        </tr>
        <tr>
            <th style="vertical-align:top">
                <%=Tag("语言")%>：
            </th>
            <td>
                <%= Shop.Bussiness.Language.SiteLanguageCheckbox("Language_ids", page.Language_ids,CurrentLanguage.Code,CurrentAdmin)%>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("排序序号")%>：
            </th>
            <td>
                <input type="text" id="Sort" name="Sort" shop="true" class="input" style="width: 70px"
                    maxlength="4" value="<%=page.Sort %>" onkeyup="value=value.replace(/[^\d]/g,'')" />
            </td>
        </tr>
        <tr>
            <th class="head" colspan="2" onclick="ShowChild('0,1,2','seo')">
                <img src="<%=PageImage("plus.gif")%>" name="imgseo" id="imgseo" style="cursor: pointer;" />
                <%=Tag("SEO优化")%>
            </th>
        </tr>
        <tr style="display: none;" name="trseo" id="tr0">
            <th>
                <%=Tag("网页标题")%>：
            </th>
            <td>
                <input type="text" id="SEO_Title" name="SEO_Title" class="input" style="width: 500px;"
                    shop="true" value="<%=page.SEO_Title %>" />
            </td>
        </tr>
        <tr style="display: none;" name="trseo" id="tr1">
            <th>
                <%=Tag("关键词")%>：
            </th>
            <td>
                <input type="text" id="SEO_Keywords" name="SEO_Keywords" class="input" style="width: 500px;"
                    shop="true" value="<%=page.SEO_Keywords %>" />
            </td>
        </tr>
        <tr style="display: none;" name="trseo" id="tr2">
            <th>
                <%=Tag("网页描述")%>：
            </th>
            <td>
                <input type="text" id="SEO_Description" name="SEO_Description" class="input" style="width: 500px;"
                    shop="true" value="<%=page.SEO_Description %>" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        CKEDITOR.replace('Content', {
            height: '200',
            width: '98%',
            language: '<%=Tag("CKEditor语言")%>'
		});  
        function uploadImage(id) {
            $.ajaxFileUpload
        (
	        {
	            url: WebPath + '/ajax/imageuploadone.aspx?path=cms',
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
	                        $("#image_" + id + "").html('<img height="80" src=' + WebPath + imageUrl + '>');
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
        function SaveObj() {
            editor = CKEDITOR.instances.Content;
            $("#Content").val(editor.getData());
            var postData = GetFormJsonData("shop");
            var nodeid = $("#Node_id").val();
            if (!CheckForm("shop", "span"))
                return false;
            var url = "<%=site.AdminPath %>/ajax/ajax_node.aspx?__Action=Page_Edit&id=<%=page.id %>";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "pagelist.aspx?Node_id=" + nodeid + "")});
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
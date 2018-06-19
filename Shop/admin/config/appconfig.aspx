<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.storeConfig.appconfig" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("APP设置") %>-<%=site.title%></title>

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
    <link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/bigcolorpicker/jquery.bigcolorpicker.css" />
    <script type="text/javascript" src="<%=site.AdminJsPath %>/bigcolorpicker/jquery.bigcolorpicker.min.js"></script>
    <style>
        .table tr td table th {text-align:left;padding-left:5px}
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
            <%}%>
            <li class="name"><span id="navIgation">
                <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a>
                >
                <%=Tag("APP设置") %></span></li>
        </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <%=Shop.Bussiness.Language.AdminLanguageTab("") %>
    <table class="table">
        <tbody>
            <%
            int mi=0;
            foreach (Shop.Model.Lebi_Language_Code lang in Shop.Bussiness.Language.Languages())
            {%>
            <script type="text/javascript">
                $(function () {
                    $("#s_app_topbackground<%=lang.Code %>").bigColorpicker(function (el, color) { $(el).css("background-color", color); $("#app_topbackground<%=lang.Code %>").val(color); });
                    $("#s_app_topline<%=lang.Code %>").bigColorpicker(function (el, color) { $(el).css("background-color", color); $("#app_topline<%=lang.Code %>").val(color); });
                    $("#s_app_topcolor<%=lang.Code %>").bigColorpicker(function (el, color) { $(el).css("background-color", color); $("#app_topcolor<%=lang.Code %>").val(color); });
                    $("#s_app_bottombackground<%=lang.Code %>").bigColorpicker(function (el, color) { $(el).css("background-color", color); $("#app_bottombackground<%=lang.Code %>").val(color); });
                    $("#s_app_bottomline<%=lang.Code %>").bigColorpicker(function (el, color) { $(el).css("background-color", color); $("#app_bottomline<%=lang.Code %>").val(color); });
                    $("#s_app_bottomcolor<%=lang.Code %>").bigColorpicker(function (el, color) { $(el).css("background-color", color); $("#app_bottomcolor<%=lang.Code %>").val(color); });
                });
            </script>
            <tbody id="lang_<%=lang.Code %>" class="lang_table" width="100%" style="display: none">
            <tr>
                 <th style="vertical-align:top"><%=Tag("名称")%>：</th>
                 <td><input type="text" class="input"  shop="true"  name="app_name<%=lang.Code %>" style="width: 200px;" value="<%=Lang(app_name,lang.Code) %>" /></td>
            </tr>
            <tr>
                 <th ><%=Tag("顶部Logo")%>：</th>
                 <td>
                    <img src="<%=Lang(app_toplogo,lang.Code) %>" id="imgapp_toplogo<%=lang.Code %>" style="max-width:30px;max-height:30px;" />
                    <input type="text" class="input" shop="true" name="app_toplogo<%=lang.Code %>" id="app_toplogo<%=lang.Code %>" style="width: 100px;" value="<%=Lang(app_toplogo,lang.Code) %>" />
                    <input id="file_app_toplogo<%=lang.Code %>" name="file_app_toplogo<%=lang.Code %>" type="file" class="input" onchange="uploadImage('app_toplogo<%=lang.Code %>')" style="width:150px;"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <%=Tag("链接")%>：<input type="text" class="input"  shop="true"  name="app_toplogourl<%=lang.Code %>" style="width: 200px;" value="<%=Lang(app_toplogourl,lang.Code) %>" />
                 </td>
            </tr>
            <tr>
                 <th ><%=Tag("左上角图标")%>：</th>
                 <td>
                    <img src="<%=Lang(app_lefticon,lang.Code) %>" id="imgapp_lefticon<%=lang.Code %>" style="max-width:30px;max-height:30px;" />
                    <input type="text" class="input" shop="true" name="app_lefticon<%=lang.Code %>" id="app_lefticon<%=lang.Code %>" style="width: 100px;" value="<%=Lang(app_lefticon,lang.Code) %>" />
                    <input id="file_app_lefticon<%=lang.Code %>" name="file_app_lefticon<%=lang.Code %>" type="file" class="input" onchange="uploadImage('app_lefticon<%=lang.Code %>')" style="width:150px;"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <%=Tag("链接")%>：<input type="text" class="input"  shop="true"  name="app_lefturl<%=lang.Code %>" style="width: 200px;" value="<%=Lang(app_lefturl,lang.Code) %>" />
                 </td>
            </tr>
            <tr>
                 <th ><%=Tag("右上角图标")%>：</th>
                 <td>
                    <img src="<%=Lang(app_righticon,lang.Code) %>" id="imgapp_righticon<%=lang.Code %>" style="max-width:30px;max-height:30px;" />
                    <input type="text" class="input" shop="true" name="app_righticon<%=lang.Code %>" id="app_righticon<%=lang.Code %>" style="width: 100px;" value="<%=Lang(app_righticon,lang.Code) %>" />
                    <input id="file_app_righticon<%=lang.Code %>" name="file_app_righticon<%=lang.Code %>" type="file" class="input" onchange="uploadImage('app_righticon<%=lang.Code %>')" style="width:150px;"/>
                 </td>
            </tr>
            <tr>
                 <th style="vertical-align:top"><%=Tag("顶部区域")%>：</th>
                 <td><%=Tag("背景颜色")%>：<input type="text" class="input"  shop="true" id="app_topbackground<%=lang.Code %>" name="app_topbackground<%=lang.Code %>" style="width: 60px;" value="<%=Lang(app_topbackground,lang.Code) %>" /><img id="s_app_topbackground<%=lang.Code %>" border="0" src="<%=AdminImage("rect.gif")%>" width="18" align="absmiddle" style="cursor: pointer; background-color: <%=Lang(app_topbackground,lang.Code) %>">
                     &nbsp;&nbsp;&nbsp;&nbsp;<%=Tag("边框颜色")%>：<input type="text" class="input" shop="true" id="app_topline<%=lang.Code %>" name="app_topline<%=lang.Code %>" style="width: 60px;" value="<%=Lang(app_topline,lang.Code) %>" /><img id="s_app_topline<%=lang.Code %>" border="0" src="<%=AdminImage("rect.gif")%>" width="18" align="absmiddle" style="cursor: pointer; background-color: <%=Lang(app_topline,lang.Code) %>">
                     &nbsp;&nbsp;&nbsp;&nbsp;<%=Tag("文字颜色")%>：<input type="text" class="input" shop="true" id="app_topcolor<%=lang.Code %>" name="app_topcolor<%=lang.Code %>" style="width: 60px;" value="<%=Lang(app_topcolor,lang.Code) %>" /><img id="s_app_topcolor<%=lang.Code %>" border="0" src="<%=AdminImage("rect.gif")%>" width="18" align="absmiddle" style="cursor: pointer; background-color: <%=Lang(app_topcolor,lang.Code) %>">
                 </td>
            </tr>
            <tr>
                 <th style="vertical-align:top"><%=Tag("底部区域")%>：</th>
                 <td><%=Tag("背景颜色")%>：<input type="text" class="input" shop="true" id="app_bottombackground<%=lang.Code %>" name="app_bottombackground<%=lang.Code %>" style="width: 60px;" value="<%=Lang(app_bottombackground,lang.Code) %>" /><img id="s_app_bottombackground<%=lang.Code %>" border="0" src="<%=AdminImage("rect.gif")%>" width="18" align="absmiddle" style="cursor: pointer; background-color: <%=Lang(app_bottombackground,lang.Code) %>">
                     &nbsp;&nbsp;&nbsp;&nbsp;<%=Tag("边框颜色")%>：<input type="text" class="input" shop="true" id="app_bottomline<%=lang.Code %>" name="app_bottomline<%=lang.Code %>" style="width: 60px;" value="<%=Lang(app_bottomline,lang.Code) %>" /><img id="s_app_bottomline<%=lang.Code %>" border="0" src="<%=AdminImage("rect.gif")%>" width="18" align="absmiddle" style="cursor: pointer; background-color: <%=Lang(app_bottomline,lang.Code) %>">
                     &nbsp;&nbsp;&nbsp;&nbsp;<%=Tag("文字颜色")%>：<input type="text" class="input" shop="true" id="app_bottomcolor<%=lang.Code %>" name="app_bottomcolor<%=lang.Code %>" style="width: 60px;" value="<%=Lang(app_bottomcolor,lang.Code) %>" /><img id="s_app_bottomcolor<%=lang.Code %>" border="0" src="<%=AdminImage("rect.gif")%>" width="18" align="absmiddle" style="cursor: pointer; background-color: <%=Lang(app_bottomcolor,lang.Code) %>">
                 </td>
            </tr>
            <tr>
                 <th ><%=Tag("启动图片")%>：</th>
                 <td>
                    <img src="<%=Lang(app_startimage,lang.Code) %>" id="imgapp_startimage<%=lang.Code %>" style="max-width:30px;max-height:30px;" />
                    <input type="text" class="input" shop="true" name="app_startimage<%=lang.Code %>" id="app_startimage<%=lang.Code %>"" style="width: 100px;" value="<%=Lang(app_startimage,lang.Code) %>" />
                    <input id="file_app_startimage<%=lang.Code %>" name="file_app_startimage<%=lang.Code %>" type="file" class="input" onchange="uploadImage('app_startimage<%=lang.Code %>')" style="width:150px;"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <%=Tag("链接")%>：<input type="text" class="input"  shop="true"  name="app_starturl<%=lang.Code %>" style="width: 200px;" value="<%=Lang(app_starturl,lang.Code) %>" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <%=Tag("停留时间")%>：<input type="text" class="input"  shop="true"  name="app_waittimes<%=lang.Code %>" style="width: 60px;" value="<%=Lang(app_waittimes,lang.Code) %>" />
                 </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("APP菜单")%>：
                </th>
                <td>
                    <table cellpadding="0" cellspacing="0" style="width:800px" align="left" id="menustable<%=lang.Code %>">
                        <tr>
                            <th style="width:60px;">
                                <%=Tag("排序")%>
                            </th>
                            <th style="width:100px;">
                                <%=Tag("文字")%>
                            </th>
                            <th style="width:340px;">
                                <%=Tag("图标")%>
                            </th>
                            <th style="width:200px;">
                                <%=Tag("链接")%>
                            </th>
                            <th style="width:100px;">
                                <%=Tag("操作")%> [<a href="javascript:addrow('<%=lang.Code %>');"><%=Tag("增加")%></a>]
                            </th>
                        </tr>
                        <%
                        foreach(Shop.Model.BaseConfigAppMenu menu in Getmenus(Lang(val,lang.Code))){ 
                        mi++;
                        %>
                        <tr id="tr<%=mi %>">
                            <td>
                                <input type="text" class="input"  shop="true"  name="menu_sort<%=lang.Code %>" style="width: 40px;" value="<%=menu.Sort %>" onkeyup="value=value.replace(/[^\d]/g,'')" />
                            </td>
                            <td>
                                <input type="text" class="input"  shop="true"  name="menu_name<%=lang.Code %>" style="width: 100px;" value="<%=menu.Name %>" />
                            </td>
                            <td>
                                <img src="<%=menu.Icon %>" id="img<%=mi %>" style="max-width:30px;max-height:30px;" />
                                <input type="text" class="input" shop="true" name="menu_icon<%=lang.Code %>" id="menu_icon<%=mi %>" style="width: 100px;" value="<%=menu.Icon %>" />
                                <input id="file_<%=mi %>" name="file_<%=mi %>" type="file" class="input" onchange="uploadImage('<%=mi %>')" style="width:150px;"/>
                            </td>
                            <td>
                                <input type="text" class="input"  shop="true"  name="menu_url<%=lang.Code %>" style="width: 200px;" value="<%=menu.URL %>" />
                            </td>
                            <td>
                                <input type="hidden" class="input"  shop="true"  name="mi<%=lang.Code %>"  value="<%=mi %>" />
                                <a href="javascript:void(0);" onclick="$(this).parent().parent().remove();"><%=Tag("删除")%></a>
                            </td>
                        </tr>
                            <%
                            if(menu.Son!=null){
                            foreach(Shop.Model.BaseConfigAppMenuSon son in menu.Son){ 
                            //mi++;
                            %>
                            <tr >
                                <td>
                                    &nbsp;|-<input type="text" class="input"  shop="true"  name="<%=mi %>menu_sort<%=lang.Code %>" style="width: 40px;" value="<%=son.Sort %>" onkeyup="value=value.replace(/[^\d]/g,'')" />
                                </td>
                                <td>
                                    <input type="text" class="input"  shop="true"  name="<%=mi %>menu_name<%=lang.Code %>" style="width: 100px;" value="<%=son.Name %>" />
                                </td>
                                <td>
                                    
                                </td>
                                <td>
                                    <input type="text" class="input"  shop="true"  name="<%=mi %>menu_url<%=lang.Code %>" style="width: 200px;" value="<%=son.URL %>" />
                                </td>
                                <td>
                                    
                                    <a href="javascript:void(0);" onclick="$(this).parent().parent().remove();"><%=Tag("删除")%></a> | 
                                </td>
                            </tr>
                            <%}} %>
                        <%} %>
                    </table>
                </td>
            </tr>
            </tbody>
            <%} %>   
        </tbody>
    </table>
    <script type="text/javascript">
        var mi=<%=mi %>;
        LanguageTab_EditPage('<%=CurrentLanguage.Code %>'); //加载默认语言
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
	                        MsgBox(2, data.error, "");
	                    }
	                    else {
	                        var imageUrl = data.ImageUrl;
	                        if (imageUrl.length > 0) {
	                            $("#img" + id + "").attr('src',imageUrl);
	                            $("#menu_icon" + id + "").val(imageUrl);
                                $("#" + id + "").val(imageUrl);
                                $("#img" + id + "").show();
	                        }
	                    }

	                },
	                error: function (data, status, e) {
	                    MsgBox(2, data.msg, "");
	                }
	            }
            )
        }
        function SaveObj() {
            var postData = GetFormJsonData("shop");
            var url="<%=site.AdminPath %>/ajax/ajax_site.aspx?__Action=APPMenu_Edit";
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", "")});
        }
        function addrow(code)
        {
            mi++;
            var row='<tr id="tr'+mi+'"><td><input type="text" class="input"  shop="true"  name="menu_sort'+code+'" style="width: 40px;" value="0" onkeyup="value=value.replace(/[^\\d]/g,\'\')" /></td>';
            row+='<td><input type="text" class="input"  shop="true"  name="menu_name'+code+'" style="width: 100px;" value="" /></td>';
            row+='<td><img src="" id="img'+mi+'" style="width:30px;height:30px;display:none;" />';
            row+='<input type="text" class="input" shop="true" name="menu_icon'+code+'" id="menu_icon'+mi+'" style="width: 100px;" value="" />';
            row+='<input id="file_'+mi+'" name="file_'+mi+'" type="file" class="input" onchange="uploadImage(\''+mi+'\')" style="width:150px;"/></td>';
            row+='<td><input type="text" class="input"  shop="true"  name="menu_url'+code+'" style="width: 200px;" value="" /></td>';
            row+='<td><a href="javascript:void(0);" onclick="$(this).parent().parent().remove();"><%=Tag("删除")%></a>';
            //row+=' | <a href="javascript:void(0);" onclick="addsonrow(\''+code+'\','+mi+');"><%=Tag("添加子菜单")%></a>';
            row+='<input type="hidden" class="input"  shop="true"  name="mi"  value="'+mi+'" />';
            row+='</td></tr>';
            $("#menustable"+code).append(row);
        }
        function addsonrow(code,i)
        {
            //mi++;
            var row='<tr><td>&nbsp;|-<input type="text" class="input"  shop="true"  name="'+i+'menu_sort'+code+'" style="width: 40px;" value="0" onkeyup="value=value.replace(/[^\\d]/g,\'\')" /></td>';
            row+='<td><input type="text" class="input"  shop="true"  name="'+i+'menu_name'+code+'" style="width: 100px;" value="" /></td>';
            row+='<td>';
            row+='';
            row+='</td>';
            row+='<td><input type="text" class="input"  shop="true"  name="'+i+'menu_url'+code+'" style="width: 200px;" value="" /></td>';
            row+='<td><a href="javascript:void(0);" onclick="$(this).parent().parent().remove();"><%=Tag("删除")%></a></td></tr>';
            $("#tr"+i).after(row);
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
<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.agent.User" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("会员管理")%>-<%=Tag("代理")%>-<%=site.title%></title>

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
    <li class="submit"><a href="javascript:void(0);" onclick="Update();"><b></b><span><%=Tag("批量设置")%></span></a></li>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <%=Tag("会员列表")%></span></li>
    </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <div class="searchbox">
        <%--<select id="lang">
            <option value="">┌<%=Tag("语言")%></option>
            <%=Shop.Bussiness.Language.LanguageOption(lang)%>
        </select>
        <select name="level" id="level">
            <option value="0">┌ <%=Tag("会员分组")%></option>
            <%=Shop.Bussiness.EX_User.TypeOption("grade > 0", level, CurrentLanguage.Code)%>
        </select>
        <select name="datetype" id="datetype">
            <option value="">┌ <%=Tag("日期类型")%></option>
            <option value="1">┌ <%=Tag("注册日期")%></option>
            <option value="2">┌ <%=Tag("最后登录日期")%></option>
            <option value="3">┌ <%=Tag("会员生日")%></option>
        </select>
        <input type="text" name="dateFrom" id="dateFrom" size="12" class="input-calendar" value="<%=dateFrom %>" /> - <input type="text" name="dateTo" id="dateTo" size="12" class="input-calendar" value="<%=dateTo %>" />--%>
        <input name="key" type="text" id="key" class="input-query" value="<%=key %>" onkeydown="if(event.keyCode==13){search_();}" /><input type="button" id="btnSou" class="btn-query" onclick="search_();" align="absmiddle" />
        <div style="margin-top:5px;">
        <a href="javascript:void(0);" onclick="SearchWindow();"><%=Tag("高级搜索")%></a>
        <%=su.Description%>
        </div>
    </div>
    <table class="datalist">
        <tr class="title">
            <th style="width: 40px" class="selectAll">
                <a href="javascript:void(0);" onclick="$('input[name=\'sid\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));"><%=Tag("全选")%></a>
            </th>
            <th style="width: 40px">
                <%=Tag("ID")%>
            </th>
            <th style="width: 100px">
                <%=Tag("会员编号")%>
            </th>
            <th style="width: 160px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "UserNameDesc"){Response.Write("UserNameAsc");}else{Response.Write("UserNameDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("会员帐号")%><%if (OrderBy == "UserNameDesc") { Response.Write("↓"); } else if (OrderBy == "UserNameAsc") { Response.Write("↑"); }%></a>
            </th>
            <th style="width: 100px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "RealNameDesc"){Response.Write("RealNameAsc");}else{Response.Write("RealNameDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("姓名")%><%if (OrderBy == "RealNameDesc") { Response.Write("↓"); } else if (OrderBy == "RealNameAsc") { Response.Write("↑"); }%></a>
            </th>
            <th style="width: 80px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "UserLevelDesc"){Response.Write("UserLevelAsc");}else{Response.Write("UserLevelDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("等级")%><%if (OrderBy == "UserLevelDesc") { Response.Write("↓"); } else if (OrderBy == "UserLevelAsc") { Response.Write("↑"); }%></a>
            </th>
            <th style="width: 100px">
                <%=Tag("一级佣金")%>
            </th>
            <th style="width: 100px">
                <%=Tag("二级佣金")%>
            </th>
            <th style="width: 100px">
                <%=Tag("三级佣金")%>
            </th>
            <th style="width: 150px">
                <%=Tag("分销商") %>
            </th>
           
            <%if (domain3admin)
              { %>
            <th style="width: 70px">
               <%=Tag("站点") %> 
            </th>
            <%} %>
            <th>
                <%=Tag("操作")%>
            </th>
        </tr>
        <%foreach (Shop.Model.Lebi_User model in models)
          {%>
        <tr class="list" ondblclick="Edit(<%=model.id %>);">
            <td style="text-align:center">
                <input type="checkbox" name="sid" value="<%=model.id %>" />
            </td>
            <td>
                <%=model.id%>
            </td>
            <td>
                <%=model.UserNumber %>&nbsp;
            </td>
            <td title="<%=Tag("昵称")%>：<%=model.NickName %>">
                <%=model.UserName %>
            </td>
            <td>
                <%=model.RealName %>&nbsp;
            </td>
            <td><%=Shop.Bussiness.EX_User.TypeName(model.UserLevel_id, CurrentLanguage.Code)%>
            </td>
            <td>
                <%=User_Commission(model.id).Angent1_Commission %> %
            </td>
            <td>
                <%=User_Commission(model.id).Angent2_Commission %> %
            </td>
            <td>
                <%=User_Commission(model.id).Angent3_Commission %> %
            </td>
            <td><%=GetDTName(model.DT_id)%></td>
            <%if (domain3admin){ %>
            <td><%if (site.SiteCount > 1){ %><%=SiteName(model.Site_id)%><%} %></td>
            <%} %>
            <td>
                <a href="javascript:void(0)" onclick="Edit(<%=model.id %>);"><%=Tag("编辑")%></a>
            </td>
        </tr>
        <%} %>
    </table>

          <%}else{%>
            <%=PageReturnMsg%>
          <%}%>
        </div>
    </div>
    
<div class="bottom" id="body_bottom">
    <%=PageString%>
</div>
<script type="text/javascript">
    function search_(scurl) {
        var key = $("#key").val();
        if(scurl==undefined || scurl=='')
            scurl='<%=su.URL %>';
        window.location = "?key=" + escape(key) + "&OrderBy=<%=OrderBy%>&"+scurl;
    }
    function OrderBy(url) {
        MsgBox(4, "<%=Tag("正在排序，请稍后")%> ……", url+"&<%=su.URL %>");
    }
    function Edit(id) {
        var title_ = "<%=Tag("编辑")%>";
        var url_ = "user_edit_window.aspx?id=" + id;
        var width_ = 400;
        var height_ = 200;
        var modal_ = true;
        EditWindow(title_, url_, width_, height_, modal_);
    }
    function Update() {
        var ids = GetChkCheckedValues("sid");
        var title_ = "<%=Tag("批量设置")%>";
        var url_ = "user_update_window.aspx?id=" + ids;
        var width_ = 400;
        var height_ = 200;
        var modal_ = true;
        EditWindow(title_, url_, width_, height_, modal_);
    }
    function SearchWindow() {
        var title_ = "<%=Tag("会员查询")%>";
        var url_ = "../user/user_search_window.aspx?callback=search_&<%=su.URL %>";
        var width_ = 500;
        var height_ = 505;
        var modal_ = true;
        EditWindow(title_, url_, width_, height_, modal_);
    }
</script>

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
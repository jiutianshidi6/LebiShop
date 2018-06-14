<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.user.Default" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("会员管理")%>-<%=site.title%></title>

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
    <li class="add"><a href="javascript:void(0);" onclick="Edit(0);"><b></b><span><%=Tag("添加")%></span></a></li>
    <li class="del"><a href="javascript:void(0);" onclick="Del();"><b></b><span><%=Tag("删除")%></span></a></li>
    <li class="email"><a href="javascript:void(0);" onclick="Write('');"><b></b><span><%=Tag("发信息")%></span></a></li>
    <li class="sms"><a href="javascript:void(0);" onclick="WriteSMS('');"><b></b><span><%=Tag("手机短信")%></span></a></li>
    <li class="bonus"><a href="javascript:void(0);" onclick="EditMoney('');"><b></b><span><%=Tag("调资金")%></span></a></li>
    <li class="point"><a href="javascript:void(0);" onclick="EditPoint('');"><b></b><span><%=Tag("调积分")%></span></a></li>
    <li class="moneycard"><a href="javascript:void(0);" onclick="SendCard(311,'<%=Tag("购物卡")%>','');"><b></b><span><%=Tag("购物卡")%></span></a></li>
    <li class="coupon"><a href="javascript:void(0);" onclick="SendCard(312,'<%=Tag("代金券")%>','');"><b></b><span><%=Tag("代金券")%></span></a></li>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <%=Tag("会员列表")%></span></li>
    </ul>
    </div>

    </div>
      
      
    <div class="mainbody" id="body_main">
        <div id="body_main_form" style="min-width:1200px;width:100%">
          
    <script type="text/javascript" src="<%=site.AdminJsPath %>/My97DatePicker/WdatePicker.js"></script> 
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
        <input type="text" name="dateFrom" id="dateFrom" size="12" class="input-calendar" value="<%=dateFrom %>" onClick="WdatePicker()" /> - <input type="text" name="dateTo" id="dateTo" size="12" class="input-calendar" value="<%=dateTo %>" onClick="WdatePicker()" />--%>
        <input name="key" type="text" id="key" class="input-query" value="<%=key %>" onkeydown="if(event.keyCode==13){search_();}" /><input type="button" id="btnSou" class="btn-query" onclick="search_();" align="absmiddle" />
        <div style="margin-top:5px;">
        <a href="javascript:void(0);" onclick="SearchWindow();"><%=Tag("高级搜索")%></a>
        <%=su.Description%>
        </div>
        
    </div>
    <table cellpadding="0" cellspacing="0" width="100%" border="0" class="datalist">
        <tr class="title">
            <th style="width: 40px" class="selectAll">
                <a href="javascript:void(0);" onclick="$('input[name=\'sid\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));"><%=Tag("全选")%></a>
            </th>
            <th style="width: 160px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "UserNameDesc"){Response.Write("UserNameAsc");}else{Response.Write("UserNameDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("会员帐号")%><%if (OrderBy == "UserNameDesc") { Response.Write("↓"); } else if (OrderBy == "UserNameAsc") { Response.Write("↑"); }%></a>
            </th>
            <th style="width: 120px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "RealNameDesc"){Response.Write("RealNameAsc");}else{Response.Write("RealNameDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("姓名")%><%if (OrderBy == "RealNameDesc") { Response.Write("↓"); } else if (OrderBy == "RealNameAsc") { Response.Write("↑"); }%></a>
            </th>
            <th style="width: 30px">
                <%=Tag("短信")%>
            </th>
            <th style="width: 80px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "UserLevelDesc"){Response.Write("UserLevelAsc");}else{Response.Write("UserLevelDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("等级")%><%if (OrderBy == "UserLevelDesc") { Response.Write("↓"); } else if (OrderBy == "UserLevelAsc") { Response.Write("↑"); }%></a>
            </th>
            <th style="width: 60px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "MoneyDesc"){Response.Write("MoneyAsc");}else{Response.Write("MoneyDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("余额")%>(<%=DefaultCurrency.Msige%>)<%if (OrderBy == "MoneyDesc") { Response.Write("↓"); } else if (OrderBy == "MoneyAsc") { Response.Write("↑"); }%></a>
            </th>
            <th style="width: 60px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "PointDesc"){Response.Write("PointAsc");}else{Response.Write("PointDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("积分")%><%if (OrderBy == "PointDesc") { Response.Write("↓"); } else if (OrderBy == "PointAsc") { Response.Write("↑"); }%></a>
            </th>
            <%if (domain3admin)
              { %>
            <th style="width: 70px">
               <%=Tag("站点") %> 
            </th>
            <%} %>
            <th style="width: 130px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "Time_RegDesc"){Response.Write("Time_RegAsc");}else{Response.Write("Time_RegDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("注册日期")%><%if (OrderBy == "Time_RegDesc") { Response.Write("↓"); } else if (OrderBy == "Time_RegAsc") { Response.Write("↑"); }%></a>
            </th>
            <th style="width: 130px">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "Time_LastDesc"){Response.Write("Time_LastAsc");}else{Response.Write("Time_LastDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("最后登陆")%><%if (OrderBy == "Time_LastDesc") { Response.Write("↓"); } else if (OrderBy == "Time_LastAsc") { Response.Write("↑"); }%></a>
            </th>
            <th>
                <%=Tag("操作")%>
            </th>
        </tr>
        <%foreach (Shop.Model.Lebi_User model in models)
          {%>
        <tr class="list" ondblclick="Edit(<%=model.id %>);">
            <td align="center">
                <input type="checkbox" name="sid" value="<%=model.id %>" />
            </td>
            <td title="<%=Tag("昵称")%>：<%=model.NickName %>">
                <%=model.UserName %>
            </td>
            <td>
                <%=model.RealName %>&nbsp;
            </td>
            <td>
            <a href="javascript:void(0);" onclick="Write('<%=model.UserName %>');"><img src="<%=PageImage("icon/Email.png")%>" title="<%=Tag("发信息")%>" /></a>
            </td>
            <td><%=Shop.Bussiness.EX_User.TypeName(model.UserLevel_id, CurrentLanguage.Code)%>
            </td>
            
            <td>
                <%=model.Money %>
            </td>
            <td>
                <%=model.Point %>
            </td>
            <%if (domain3admin){ %>
            <td><%if (site.SiteCount > 1){ %><%=SiteName(model.Site_id)%><%} %></td>
            <%} %>
            <td>
                <%=FormatTime(model.Time_Reg) %>
            </td>
            <td>
                <%=FormatTime(model.Time_Last) %>
            </td>
            <td>
                <a href="javascript:void(0)" onclick="Edit(<%=model.id %>);"><%=Tag("编辑")%></a> 
                | <a href="javascript:void(0)" onclick="EditPassword(<%=model.id %>);"><%=Tag("改密")%></a> 
                | <a href="UserMoney.aspx?user_id=<%=model.id %>"><%=Tag("资金")%></a> 
                | <a href="UserPoint.aspx?user_id=<%=model.id %>"><%=Tag("积分")%></a> 
                | <a href="../promotion/cardlist.aspx?user_id=<%=model.id %>&type=312"><%=Tag("代金券")%></a>
                | <a href="Message.aspx?user_id=<%=model.id %>"><%=Tag("站内信")%></a>
                | <a href="OftenBuy.aspx?user_id=<%=model.id %>"><%=Tag("常购清单")%></a>
            </td>
        </tr>
        <%} %>
    </table>
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
            window.location = "user_edit.aspx?id=" + id;
        }
        function Del() {
            if (!confirm("<%=Tag("确认要删除吗？")%>"))
                return false;
            var ids = GetChkCheckedValues("sid");
            var postData = { "ids": ids };
            var url = "<%=site.AdminPath %>/ajax/ajax_user.aspx?__Action=User_Del";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function Write(User_Name) {
            var title_ = "<%=Tag("发信息")%>";
            var ids = GetChkCheckedValues("sid");
            if (User_Name !=""){
            var url_ = "message_write_window.aspx?User_Name="+User_Name+"&<%=su.URL %>";
            }else{
            var url_ = "message_write_window.aspx?ids="+ids+"&<%=su.URL %>";
            }
            var width_ = 600;
            var height_ = 375;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function WriteSMS(User_Name) {
            var title_ = "<%=Tag("手机短信")%>";
            var ids = GetChkCheckedValues("sid");
            if (User_Name !=""){
            var url_ = "sms_write_window.aspx?User_Name="+User_Name+"&<%=su.URL %>";
            }else{
            var url_ = "sms_write_window.aspx?ids="+ids+"&<%=su.URL %>";
            }
            var width_ = 600;
            var height_ = 320;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function EditPassword(id) {
            var title_ = "<%=Tag("改密")%>";
            var url_ = "userpassword_edit_window.aspx?id="+id;
            var width_ = 500;
            var height_ = 220;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function EditMoney(User_Name) {
            var title_ = "<%=Tag("添加资金")%>";
            var ids = GetChkCheckedValues("sid");
            if (User_Name !=""){
            var url_ = "usermoney_edit_window.aspx?User_Name="+User_Name+"&<%=su.URL %>";
            }else{
            var url_ = "usermoney_edit_window.aspx?ids="+ids+"&<%=su.URL %>";
            }
            var width_ = 600;
            var height_ = 365;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function EditPoint(User_Name) {
            var title_ = "<%=Tag("添加积分")%>";
            var ids = GetChkCheckedValues("sid");
            if (User_Name !=""){
            var url_ = "UserPoint_Edit_window.aspx?User_Name="+User_Name+"&<%=su.URL %>";
            }else{
            var url_ = "UserPoint_Edit_window.aspx?ids="+ids+"&<%=su.URL %>";
            }
            var width_ = 600;
            var height_ = 325;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function SendCard(id,title_,User_Name) {
            //var title_ = "<%=Tag("")%>";
            var ids = GetChkCheckedValues("sid");
            if (User_Name !=""){
            var url_ = "usercard_edit_window.aspx?cardtype="+id+"&User_Name="+User_Name+"&<%=su.URL %>";
            }else{
            var url_ = "usercard_edit_window.aspx?cardtype="+id+"&ids="+ids+"&<%=su.URL %>";
            }
            var width_ = 600;
            var height_ = 260;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function SearchWindow() {
            var title_ = "<%=Tag("会员查询")%>";
            var url_ = "user_search_window.aspx?callback=search_&<%=su.URL %>";
            var width_ = 500;
            var height_ = 505;
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
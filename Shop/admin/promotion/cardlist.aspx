<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.Config.cardtlist" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("优惠券")%>-<%=site.title%></title>

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

    <style type="text/css">.mainbody_top{display:none;height:0;overflow:hidden}</style>

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
    <li class="add"><a href="javascript:void(0);" onclick="AddObj(0);"><b></b><span><%=Tag("添加")%></span></a></li>
    <li class="del"><a href="javascript:void(0);" onclick="Delete();"><b></b><span><%=Tag("删除")%></span></a></li>
    <li class="edit"><a href="javascript:void(0);" onclick="cardexport();"><b></b><span><%=Tag("导出")%></span></a></li>
    <li class="edit"><a  href="javascript:void(0);" onclick="EditObj(0);"><b></b><span><%=Tag("批量修改")%></span></a></li>
    <%}%>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <%=Tag("优惠券")%></span></li>
    </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <div class="searchbox">
        <%--状态：<select id="status">
            <option value="0">┌<%=Tag("全部")%></option>
            <%=Shop.Bussiness.EX_Type.TypeOption("CardStatus", status)%>
        </select>
        面值：<input name="money" type="text" id="money" class="input-query" value="<%=money %>" style="width:70px;"/>
        有效期：<input type="text" name="dateFrom" id="dateFrom" size="12" class="input-calendar" value="<%=dateFrom %>" /> - <input type="text" name="dateTo" id="dateTo" size="12" class="input-calendar" value="<%=dateTo %>" />
        &nbsp;--%>
        <input name="key" type="text" id="key" class="input-query" value="<%=key %>" onkeydown="if(event.keyCode==13){search_();}" /><input type="button" id="btnSou" class="btn-query" onclick="search_();" align="absmiddle" />
        <div style="margin-top:5px;">
        <a href="javascript:void(0);" onclick="SearchWindow();"><%=Tag("高级搜索")%></a>
        <%=su.Description%>
        </div>
    </div>
    <table id="list" class="datalist">
        <tr class="title">
            <th style="width: 40px" class="selectAll">
                <a href="javascript:void(0);" onclick="$('input[name=\'id\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));"><%=Tag("全选")%></a>
            </th>
            <th style="width: 100px">
                <%=Tag("名称")%>
            </th>
             <th style="width: 100px">
                <%=Tag("编号")%>
            </th>
            <% if (type == 311)
               { %>
            <th style="width: 100px">
                <%=Tag("密码")%>
            </th>
            <%} %>
            <th style="width: 100px">
                <%=Tag("会员")%>
            </th>
            <th style="width: 60px">
                <%=Tag("面值")%>
            </th>
            <th style="width: 60px">
                <%=Tag("剩余")%>
            </th>
            <th style="width: 60px">
                <%=Tag("最低消费")%>
            </th>
            <th style="width: 60px">
                <%=Tag("找零")%>
            </th>
            <th style="width: 60px">
                <%=Tag("单独使用")%>
            </th>
            <th style="width: 60px">
                <%=Tag("状态")%>
            </th>
            <th >
                <%=Tag("有效期")%>
            </th>
            <th >
                <%=Tag("限制分类")%>
            </th>
        </tr>
        <%foreach (Shop.Model.Lebi_Card model in models)
          {%>
        <tr class="list" ondblclick="EditObj(<%=model.id %>);" >
            <td style="text-align:center">
                <input type="checkbox" name="id" value="<%=model.id %>" del="true" />
            </td>
            <td>
                <%=TypeName(model.CardOrder_id)%>
            </td>
            <td>
                <%=model.Code%>
            </td>
             <% if (type == 311)
               { %>
            <td>
                <%=model.Password%>
            </td>
            <%} %>
            <td>
                <%=model.User_UserName%>
            </td>
            <td>
                <%=FormatMoney(model.Money)%>
            </td>
            <td>
                <%=FormatMoney(model.Money_Last)%>
            </td>
            <td>
                <%=FormatMoney(model.Money_Buy)%>
            </td>
            <td>
                <%=model.IsPayOnce == 1 ? Tag("否") : Tag("是")%>
            </td>
             <td>
                <%=model.IsCanOtherUse == 0 ? Tag("是") : Tag("否")%>
            </td>
            <td>
                <%=Shop.Bussiness.EX_Type.TypeName(model.Type_id_CardStatus,CurrentLanguage)%>
            </td>
            <td>
                <%=FormatDate(model.Time_Begin)+"-"+FormatDate(model.Time_End)%>
            </td>
            <td><%=Shop.Bussiness.EX_Product.TypeNames(model.Pro_Type_ids,CurrentLanguage.Code) %>&nbsp;</td>
        </tr>
        <%} %>
    </table>
    <script type="text/javascript">
        function AddObj(id) {
            window.location="cardtype.aspx?type=<%=type %>";
        }
        function CreateObj(id) {
            var title_ = "<%=Tag("生成优惠券")%>";
            var url_ = "card_create_window.aspx?id=" + id;
            var width_ = 450;
            var height_ = "auto";
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Update() {
            var postData = GetFormJsonData("shop");
            var url = "<%=site.AdminPath %>/ajax/ajax_site.aspx?__Action=Pay_Update";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function DeleteObj() {
            if (!confirm("<%=Tag("确认要删除吗？")%>"))
                return false;
            var postData = GetFormJsonData("del");
            var url = "<%=site.AdminPath %>/ajax/ajax_site.aspx?__Action=Pay_Del";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function Delete() {
            if (!confirm("<%=Tag("确认要删除吗？")%>"))
                return false;
            var postData = GetFormJsonData("del");
            var url = "<%=site.AdminPath %>/Ajax/ajax_sale.aspx?__Action=Card_Del";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
         function search_(scurl) {
            var key = $("#key").val();
            if(scurl==undefined || scurl=='')
                scurl='<%=su.URL %>';
            window.location = "?key=" + escape(key) + "&user_id=<%=user_id %>&"+scurl;
        }
        function cardexport()
        {
            var key = $("#key").val();
            var dateFrom = $("#dateFrom").val();
            var dateTo = $("#dateTo").val();
            var status = $("#status").val();
            var money = $("#money").val();
            window.location = "<%=site.AdminPath %>/ajax/export.aspx?__Action=Card&key=" + escape(key) + "&user_id=<%=user_id %>&<%=su.URL %>";
        }
        function SearchWindow() {
            var title_ = "<%=Tag("卡券查询")%>";
            var url_ = "card_search.aspx?callback=search_&<%=su.URL %>";
            var width_ = 500;
            var height_ = "auto";
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function EditObj(ids) {
            if (ids == 0){
                var ids = GetChkCheckedValues("id");
            }
            var url_ = "card_edit_window.aspx?ids="+ids+"&<%=su.URL %>";
            var title_="<%=Tag("批量修改") %>";
            var width_ = 500;
            var height_ = "auto";
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
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
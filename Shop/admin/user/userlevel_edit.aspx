<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.user.UserLevel_Edit" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Shop.Bussiness.Language.Content(model.Name, CurrentLanguage.Code) %>-<%=Tag("会员分组")%>-<%=site.title%></title>

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
    <%if (PageReturnMsg == ""){%>
    <li class="submit"><a href="javascript:void(0);" onclick="SaveObj();"><b></b><span><%=Tag("保存")%></span></a></li>
    <%}%>
    <li class="rotate"><a href="javascript:void(0);" onclick="history.back();"><b></b><span><%=Tag("返回")%></span></a></li>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="<%=site.AdminPath %>/user/default.aspx"><%=Tag("会员管理")%></a> > <a href="<%=site.AdminPath %>/user/UserLevel.aspx"><%=Tag("会员分组")%></a> > <%=Shop.Bussiness.Language.Content(model.Name, CurrentLanguage.Code) %></span></li>
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
        <%foreach (Shop.Model.Lebi_Language_Code lang in Shop.Bussiness.Language.Languages())
          {%>
        <tbody id="lang_<%=lang.Code %>" class="lang_table" style="display: none">
            <tr>
                <th>
                    <%=Tag("分组名称")%>：
                </th>
                <td>
                    <input type="text" id="Name<%=lang.Code %>" shop="true"  style="width: 400px;" name="Name<%=lang.Code %>"
                        value="<%=Shop.Bussiness.Language.Content(model.Name, lang.Code) %>" class="input" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("价格文字")%>：
                </th>
                <td>
                    <input type="text" id="PriceName<%=lang.Code %>" shop="true" style="width: 400px;"
                        name="PriceName<%=lang.Code %>" value="<%=Shop.Bussiness.Language.Content(model.PriceName, lang.Code) %>"
                        class="input" />
                </td>
            </tr>
        </tbody>
        <%} %>
        </table>
        <ul id="tablistmain"><li class="selected"><a><span><%=Tag("通用信息")%></span></a></li></ul>
        <table class="table">
        <tr>
            <th>
                <%=Tag("等级ID")%>：
            </th>
            <td>
                <input type="text" id="Grade" name="Grade" onkeyup="value=value.replace(/[^\d]/g,'')" value="<%=model.Grade %>" class="input" style="width: 70px;" shop="true" min="notnull" />
                &nbsp;<span id="Span1"><em><%=Tag("填0表示未登录的访客")%></em></span>
            </td>
        </tr>
        
        <tr>
            <th>
                <%=Tag("升级积分")%>：
            </th>
            <td>
                <input type="text" id="Lpoint" name="Lpoint" value="<%=model.Lpoint %>" class="input" style="width: 70px;" onkeyup="value=value.replace(/[^\d]/g,'')" shop="true" min="notnull" />&nbsp;<span id="sp_fen"><em><%=Tag("升级会员等级所需积分")%></em></span>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("会员价格")%>：
            </th>
            <td>
                <%=Tag("销售价")%>× <input type="text" id="Price" name="Price" value="<%=model.Price %>" class="input" shop="true" min="notnull" onkeyup="value=value.replace(/[^\d.]/g,'')" maxlength="20"/>
                %&nbsp;<span id="sp_price"><em><%=Tag("1~100的数字")%></em></span>
            </td>
        </tr>
        <tr>
            <th style="vertical-align:top">
                <%=Tag("等级图标")%>：
            </th>
            <td>
            <div id="image_ImageUrl">
                <%if (model.ImageUrl != "")
                    {%>
                <img src="<%=site.WebPath + model.ImageUrl%>" style="max-height:30px" />
                <%} %>
            </div>
            <input type="text" shop="true" id="ImageUrl" name="ImageUrl" class="input" style="width: 200px;" value="<%=model.ImageUrl%>" />
            <input id="file_ImageUrl" name="file_ImageUrl" type="file" class="input" onchange="uploadImage('ImageUrl')" />
            
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("积分比率")%>：
            </th>
            <td>
                <%=Tag("消费1元可获得积分")%> <input type="text" id="MoneyToPoint" name="MoneyToPoint" onkeyup="value=value.replace(/[^\d\.]/g,'')" value="<%=model.MoneyToPoint %>" class="input" style="width: 70px;" shop="true" min="notnull" />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("积分兑换规则")%>：
            </th>
            <td>
                <input type="text" id="PointToMoney" name="PointToMoney"  style="width: 400px;" value="<%=model.PointToMoney %>" class="input" shop="true" min="notnull" /> <span class="FormALT">100:1,200:2,500:5,1000:10</span>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("会员注册")%>：
            </th>
            <td>
                <label><input type="radio" name="RegisterType" value="1" shop="true" <%=model.RegisterType==1?"checked":"" %>/><%=Tag("开启")%></label>
                <label><input type="radio" name="RegisterType" value="0" shop="true" <%=model.RegisterType==0?"checked":"" %>/><%=Tag("关闭")%></label>
                <label><input type="radio" name="RegisterType" value="2" shop="true" <%=model.RegisterType==2?"checked":"" %>/><%=Tag("邀请")%></label>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("推广佣金")%>：
            </th>
            <td>
                <label><input type="radio" name="IsUsedAgent" value="1" shop="true" <%=model.IsUsedAgent==1?"checked":"" %>/><%=Tag("开启")%></label>
                <label><input type="radio" name="IsUsedAgent" value="0" shop="true" <%=model.IsUsedAgent==0?"checked":"" %>/><%=Tag("关闭")%></label>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("隐藏价格")%>：
            </th>
            <td>
                <label><input type="radio" name="IsHidePrice" value="1" shop="true" <%=model.IsHidePrice==1?"checked":"" %>/><%=Tag("开启")%></label>
                <label><input type="radio" name="IsHidePrice" value="0" shop="true" <%=model.IsHidePrice==0?"checked":"" %>/><%=Tag("关闭")%></label>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("购买权限")%>：
            </th>
            <td>
                <label><input type="radio" id="rdo_buyright_open" name="BuyRight"  value="1" shop="true" <%=model.BuyRight==1?"checked":"" %>/><%=Tag("开启")%></label>
                <label><input type="radio" id="rdo_buyright_close" name="BuyRight" value="0" shop="true" <%=model.BuyRight==0?"checked":"" %>/><%=Tag("关闭")%></label>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("评论审核")%>：
            </th>
            <td>
                <label><input type="radio" id="Radio1" name="Comment" checked value="1" shop="true" <%=model.Comment==1?"checked":"" %>/><%=Tag("开启")%></label>
                <label><input type="radio" id="Radio2" name="Comment" value="0" shop="true" <%=model.Comment==0?"checked":"" %>/><%=Tag("关闭")%></label>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("订单提交")%>：
            </th>
            <td>
                <%=Tag("金额大于")%> <input type="text" id="OrderSubmit" name="OrderSubmit" value="<%=model.OrderSubmit %>" onkeyup="value=value.replace(/[^\d\.]/g,'')" class="input" style="width: 70px;" shop="true" min="notnull" />&nbsp;&nbsp;
                <%=Tag("数量大于")%> <input type="text" id="OrderSubmitCount" name="OrderSubmitCount" value="<%=model.OrderSubmitCount %>" onkeyup="value=value.replace(/[^\d\.]/g,'')" class="input" style="width: 70px;" shop="true" min="notnull" />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("登录积分")%>：
            </th>
            <td>
                <%=Tag("增加")%>：<input type="text" id="LoginPointCut" name="LoginPointCut" shop="true" min="notnull" value="<%=model.LoginPointCut %>" class="input" style="width: 70px;" onkeyup="value=value.replace(/[^\d]/g,'')" />&nbsp;&nbsp;
                <%=Tag("减少")%>：<input type="text" id="LoginPointAdd" name="LoginPointAdd" shop="true" min="notnull" value="<%=model.LoginPointAdd %>" class="input" style="width: 70px;" onkeyup="value=value.replace(/[^\d]/g,'')" />
            </td>
        </tr>
        <tr>
            <th style="vertical-align:top">
                <%=Tag("内部备注")%>：
            </th>
            <td>
                <textarea id="remark" name="remark" class="textarea" shop="true" cols="40" rows="5" style="height: 60px;width: 550px;"><%=model.remark%></textarea>
                <div class="tools clear">
                    <ul>
                        <li class="plus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('remark',100);"><b></b><span><%=Tag("展开")%></span></a></li>
                        <li class="minus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('remark',-100)"><b></b><span><%=Tag("收缩")%></span></a></li>
                    </ul>
                </div>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
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
	                    MsgBox(2, data.msg, "");
	                }
	                else {
	                    var imageUrl = data.ImageUrl;
	                    if (imageUrl.length > 0) {
	                        $("#image_" + id + "").html('<img src="' + WebPath + imageUrl + '" style="max-height:30px">');
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
        LanguageTab_EditPage('<%=CurrentLanguage.Code %>'); //加载默认语言
        function SaveObj() {
            var postData = GetFormJsonData("shop");
            if (!CheckForm("shop", "span"))
                return false;
            var url= "<%=site.AdminPath %>/ajax/ajax_user.aspx?__Action=UserLevel_Edit&id=<%=model.id %>";
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", "userLevel.aspx");});
        }
    </script>

          <%}else{%>
            <%=PageReturnMsg%>
          <%}%>
        </div>
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
<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.user.User_Edit" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%if (model.id != 0)
      { %>
    <%=Tag("编辑会员")%> <%=model.UserName %>
    <%}else{ %><%=Tag("会员添加")%>
    <%}%>-<%=Tag("会员管理")%>-<%=site.title%></title>

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
    <li class="submit"><a href="javascript:void(0);" onclick="SaveObj();"><b></b><span><%=Tag("保存")%></span></a></li>
    <li class="rotate"><a href="javascript:void(0);" onclick="history.back();"><b></b><span><%=Tag("返回")%></span></a></li>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="<%=site.AdminPath %>/user/default.aspx"><%=Tag("会员管理")%></a> > 
    <%if (model.id != 0)
      { %>
    <%=Tag("编辑会员")%> <%=model.UserName %>
    <%}else{ %><%=Tag("会员添加")%>
    <%}%></span></li>
    </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <%
Lebi.ERP.PLebi_User puser=new Lebi.ERP.PLebi_User(model.id);
%>
    <div class="searchbox clear">
        <ul class="tabmenus">
            <li class="current"><a href="user_edit.aspx?id=<%=model.id %>"><span><%if (model.id != 0)
      { %><%=Tag("编辑会员")%><%}else{ %><%=Tag("会员添加")%><%}%></span></a></li>
            <li><a href="javascript:void(0)" onclick="EditPassword(<%=model.id %>);"><span><%=Tag("改密")%></span></a></li>
            <li><a href="javascript:void(0)" onclick="Question(<%=model.id %>);"><span><%=Tag("安全问题")%></span></a></li>
            <li><a href="UserMoney.aspx?user_id=<%=model.id %>" target="_blank"><span><%=Tag("资金")%></span></a></li>
            <li><a href="UserPoint.aspx?user_id=<%=model.id %>" target="_blank"><span><%=Tag("积分")%></span></a></li>
            <li><a href="../promotion/cardlist.aspx?user_id=<%=model.id %>&type=312" target="_blank"><span><%=Tag("代金券")%></span></a></li>
            <li><a href="Message.aspx?user_id=<%=model.id %>" target="_blank"><span><%=Tag("站内信")%></span></a></li>
            <li><a href="OftenBuy.aspx?user_id=<%=model.id %>" target="_blank"><span><%=Tag("常购清单")%></span></a></li>
            <li><a href="../cms/imagelist.aspx?user_id=<%=model.id %>" target="_blank"><span><%=Tag("照片")%></span></a></li>
            <%if (Shop.LebiAPI.Service.Instanse.Check("plugin_agent")){ %><li><a href="../agent/agentmoney.aspx?user_id=<%=model.id %>" target="_blank"><span><%=Tag("佣金")%></span></a></li><%} %>
        </ul>
        </div>
    </div>
    <table class="table">
        <tr>
            <th>
                <%=Tag("会员帐号")%>：
            </th>
            <td>
                <input name="UserName" id="UserName" value="<%=model.UserName %>" onchange="CheckUserName();" shop="true" type="text" class="input" style="width: 200px;" />

                <span id="FormUserName"></span>
            </td>
            <%if (domain3admin)
              { %>
            <th>
               <%=Tag("站点")%>：
            </th>
            <td >
                <%=SiteName(model.Site_id)%>
            </td>
            <%}
              else
              {%>
            <th>&nbsp;</th>
            <td >&nbsp;</td>
            <%} %>
        </tr>
        <tr>
           
            <th>
                <%=Tag("绑定")%>：
            </th>
            <td colspan="3"> 
                <%
                  if (model.bind_weixin_id != "")
                  {
                      Response.Write("<img src=\"" + SYS.platform_weixin_image + "\" height=\"24px\" />");
                  }
                  if (model.bind_weibo_id != "")
                  {
                      Response.Write("<img src=\"" + SYS.platform_weibo_image + "\" height=\"24px\" />");
                  }
                  if (model.bind_qq_id != "")
                  {
                      Response.Write("<img src=\"" + SYS.platform_qq_image + "\" height=\"24px\" />");
                  }
                  if (model.bind_taobao_id != "")
                  {
                      Response.Write("<img src=\"" + SYS.platform_taobao_image + "\" height=\"24px\" />");
                  }
                  if (model.bind_facebook_id != "")
                  {
                      Response.Write("<img src=\"" + SYS.platform_facebook_image + "\" height=\"24px\" />");
                  }
                %>&nbsp;
            </td>
        </tr>
      
        <tr>
            <th>
                <%=Tag("有效期")%>：
            </th>
            <td colspan="3">
                <input name="Time_End" value="<%=FormatDate(model.Time_End)%>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr>
            <th>
                公司名称：
            </th>
            <td colspan="3">
                <input name="NickName" value="<%=puser.NickName %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr>
            <th>
                公司域名：
            </th>
            <td colspan="3">
                <input name="Company_Domain" value="<%=puser.Company_Domain %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr>
            <th>
                公司地址：
            </th>
            <td colspan="3">
                <input name="Company_Address" value="<%=puser.Company_Address %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr>
            <th>
                照片：
            </th>
            <td colspan="3">
                <%if(puser.Company_yingyezhizhao!=""){%>
                <a href="<%=puser.Company_yingyezhizhao%>" target="_blank"><img src="<%=puser.Company_yingyezhizhao%>" style="width:60px;height:60px;"/></a>
                <%}%>

                <%if(puser.Company_shuiwu!=""){%>
                <a href="<%=puser.Company_shuiwu%>" target="_blank">
                    <img src="<%=puser.Company_shuiwu%>" style="width:60px;height:60px;" />
                </a>
                    <%}%>

                    <%if(puser.Company_photo!=""){%>
                <a href="<%=puser.Company_photo%>" target="_blank">
                    <img src="<%=puser.Company_photo%>" style="width:60px;height:60px;" />
                </a>
                        <%}%>

</td>
        </tr>
        <tr  >
            <th>
                负责人姓名：
            </th>
            <td colspan="3">
                <input name="RealName" value="<%=model.RealName %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
         </tr>

        <tr>
            <th>
                负责人手机号码：
            </th>
            <td colspan="3">
                <input name="MobilePhone" value="<%=model.MobilePhone %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr>
            <th>
                负责人Email：
            </th>
            <td colspan="3">
                <input name="Email" value="<%=model.Email %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr>
            <th>
                负责人QQ号码：
            </th>
            <td colspan="3">
                <input name="QQ" value="<%=model.QQ %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
         </tr>
        <tr>
            <th>
                负责人微信：
            </th>
            <td colspan="3">
                <input name="weixin" value="<%=model.weixin %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
         </tr>
         <tr  >
            <th>
                收货人姓名：
            </th>
            <td colspan="3">
                <input name="Company_shouhuo_name" value="<%=puser.Company_shouhuo_name %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
         </tr>
         <tr  >
            <th>
                收货地址：
            </th>
            <td colspan="3">
                <input name="Company_shouhuo_address" value="<%=puser.Company_shouhuo_address %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
         </tr>
        <tr>
            <th>
                收货人手机号码：
            </th>
            <td colspan="3">
                <input name="Company_shouhuo_phone" value="<%=puser.Company_shouhuo_phone %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr>
            <th>
                收货人QQ号码：
            </th>
            <td colspan="3">
                <input name="Company_shouhuo_qq" value="<%=puser.Company_shouhuo_qq %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
         </tr>
        <tr>
            <th>
                收货人微信：
            </th>
            <td colspan="3">
                <input name="Company_shouhuo_weixin" value="<%=puser.Company_shouhuo_weixin %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
         </tr>
        <tr  >
            <th>
                采购人姓名：
            </th>
            <td colspan="3">
                <input name="Company_caigou_name" value="<%=puser.Company_caigou_name %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
         </tr>
        <tr>
            <th>
                采购人手机号码：
            </th>
            <td colspan="3">
                <input name="Company_caigou_phone" value="<%=puser.Company_caigou_phone %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr>
            <th>
                采购人QQ号码：
            </th>
            <td colspan="3">
                <input name="Company_caigou_qq" value="<%=puser.Company_caigou_qq %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
         </tr>
        <tr>
            <th>
                采购人微信：
            </th>
            <td colspan="3">
                <input name="Company_caigou_weixin" value="<%=puser.Company_caigou_weixin %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
         </tr>
        <tr>
            <th>
                技术负责人姓名：
            </th>
            <td colspan="3">
                <input name="Company_cto_name" value="<%=puser.Company_cto_name %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
         </tr>
        <tr>
            <th>
                技术负责人手机号码：
            </th>
            <td colspan="3">
                <input name="Company_cto_phone" value="<%=puser.Company_cto_phone %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr>
            <th>
                技术负责人QQ号码：
            </th>
            <td colspan="3">
                <input name="Company_cto_qq" value="<%=puser.Company_cto_qq %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
         </tr>
        <tr>
            <th>
                技术负责人微信：
            </th>
            <td colspan="3">
                <input name="Company_cto_weixin" value="<%=puser.Company_cto_weixin %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
         </tr>
        <tr>
            <th>
                <%=Tag("会员分组")%>：
            </th>
            <td colspan="3">
                <select name="UserLevel_id" shop="true">
                <option value="0">┌ <%=Tag("会员分组")%></option>
                <%=Shop.Bussiness.EX_User.TypeOption("grade > 0", model.UserLevel_id, CurrentLanguage.Code)%>
                </select>
            </td>
         </tr>
        <tr>
            <th>
                <%=Tag("语言")%>：
            </th>
            <td colspan="3">
                <select name="Language" id="Language" shop="true">
                    <%= Shop.Bussiness.Language.LanguageOption(model.Language)%>
                </select>
            </td>
        </tr>
        <%if (Shop.LebiAPI.Service.Instanse.Check("plugin_agent")){ %>
        <tr>
            <th>
                <%=Tag("上级用户")%>：
            </th>
            <td colspan="3">
                <input name="User_id_parent" value="<%=model.User_id_parent %>" shop="true" type="text" class="input" style="width: 200px;" /> <a href="../agent/agentuser.aspx?parent_id=<%=model.User_id_parent %>" target="_blank"><%=Shop.Bussiness.EX_User.GetUser(model.User_id_parent).UserName%></a>
            </td>
         </tr>
        <tr>
            <th>
                <%=Tag("下级用户")%>：
            </th>
            <td colspan="3">
                <a href="../agent/agentuser.aspx?id=<%=model.id %>" target="_blank"><%=model.Count_sonuser %></a>
            </td>
        </tr>
        <%} %>
        <tr>
            <th>
                <%=Tag("注册日期")%>：
            </th>
            <td colspan="3">
                <%=FormatTime(model.Time_Reg) %>
            </td>
         </tr>
        <tr>
            <th>
                <%=Tag("上次登陆")%>：
            </th>
            <td colspan="3">
                <%=FormatTime(model.Time_Last) %>&nbsp;&nbsp;<%=Tag("IP")%>：<a href="http://www.ip138.com/ips138.asp?ip=<%=model.IP_Last%>&action=2" target="_blank"><%=model.IP_Last %></a> <%=Shop.Tools.RequestTool.getIpInfoOne(model.IP_Last)%>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("最后登陆")%>：
            </th>
            <td colspan="3">
                <%=FormatTime(model.Time_This) %>&nbsp;&nbsp;<%=Tag("IP")%>：<a href="http://www.ip138.com/ips138.asp?ip=<%=model.IP_This%>&action=2" target="_blank"><%=model.IP_This %></a> <%=Shop.Tools.RequestTool.getIpInfoOne(model.IP_This)%>
           
                &nbsp; &nbsp; &nbsp;
                <%=Tag("登录次数")%>：
           
                <%=model.Count_Login %>
            </td>
        </tr>
        <tr  >
            <th style="vertical-align:top">
                <%=Tag("内部备注")%>：<br>
                <em>≤ <span id="remLen">255</span></em>
            </th>
            <td colspan="3">
                <textarea name="Introduce" id="Introduce" shop="true" rows="3" cols="60" class="input" onKeyDown="checkMaxInput(this.form)" onKeyUp="checkMaxInput(this.form)" style="height: 55px;width: 550px;"><%=model.Introduce%></textarea>
                <div class="tools clear">
                    <ul>
                        <li class="plus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Introduce',100);"><b></b><span><%=Tag("展开")%></span></a></li>
                        <li class="minus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Introduce',-100)"><b></b><span><%=Tag("收缩")%></span></a></li>
                    </ul>
                </div>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        var maxLen = 255;
        var Introduce = document.getElementById("Introduce");
        function checkMaxInput(form) {
        if (Introduce.value.length > maxLen)
        Introduce.value = Introduce.value.substring(0, maxLen);
        else document.getElementById("remLen").innerHTML = maxLen - Introduce.value.length;
        }
        function SaveObj() {
            var postData = GetFormJsonData("shop");
            var url = "<%=site.AdminPath %>/ajax/ajax_ex.aspx?__Action=User_Edit&id=<%=model.id %>";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "default.aspx")});
        }
        function CheckUserName()
        {
            var UserName=$("#UserName").val();
            var postData={"UserName":UserName};
            var url = "<%=site.AdminPath %>/ajax/ajax_user.aspx?__Action=CheckUserName&id=<%=model.id %>";
            $.ajax({
            type: "POST",
            url: url,
            data: postData,
            dataType: 'json',
            success: function (res) {
                if(res.msg=="OK")
                    CheckOK("UserName",'');
                else
                    CheckNO("UserName",'<%=Tag("用户名已经存在") %>');
                }
            });
        }
        function EditPassword(id) {
            var title_ = "<%=Tag("改密")%>";
            var url_ = "userpassword_edit_window.aspx?id="+id;
            var width_ = 500;
            var height_ = 'auto';
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Question(id) {
            var title_ = "<%=Tag("安全问题")%>";
            var url_ = "userquestion_edit_window.aspx?id="+id;
            var width_ = 500;
            var height_ = 'auto';
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
<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.promotion.PromotionType_Edit" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title>
        <%if (model.id != 0)
          { %>
        <%=Tag("编辑促销")%>
        <%}
          else
          { %><%=Tag("添加促销")%>
        <%}%>-<%=Tag("优惠促销")%>-<%=site.title%></title>

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

    <script type="text/javascript" src="<%=site.WebPath %>/Editor/ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="<%=site.WebPath %>/Editor/ckfinder/ckfinder.js"></script>
    <script type="text/javascript" src="<%=site.AdminJsPath %>/jquery-ui/timepicker-addon.js"></script>
    <%if (CurrentLanguage.Code=="CN"){%><script type="text/javascript" src="<%=site.AdminJsPath %>/jquery-ui/timepicker-zh-CN.js"></script><%}%>
    <link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/jquery-ui/timepicker-addon.css" />
    <script type="text/javascript">
        $(function () {
            $(".input-calendar").datetimepicker({dateFormat:"yy-mm-dd",showSecond:true,timeFormat:"HH:mm:ss",stepHour:1,stepMinute:1,tepSecond:1});
        });
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
            <li class="submit"><a href="javascript:void(0);" onclick="SaveObj();"><b></b><span><%=Tag("保存")%></span></a></li>
            <li class="submit"><a href="javascript:void(0);" onclick="PromotionEdit(<%=model.id %>);"><b></b><span><%=Tag("编辑规则")%></span></a></li>
            <%}%>
            <li class="name"><span id="navIgation">
                <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> >
                <%=Tag("营销")%>
                > <a href="<%=site.AdminPath %>/Promotion/default.aspx">
                    <%=Tag("优惠促销")%></a> >
                <%=model.id == 0 ? Tag("添加促销") : Tag("编辑促销")%></span></li>
        </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <%=Shop.Bussiness.Language.AdminLanguageTab("") %>
    <table
        id="lang" class="table">
        <%foreach (Shop.Model.Lebi_Language_Code lang in Shop.Bussiness.Language.Languages())
          {%>
        <tbody id="lang_<%=lang.Code %>" class="lang_table" style="display: none">
            <tr>
                <th>
                    <%=Tag("名称")%>：
                </th>
                <td>
                    <input type="text" id="Name<%=lang.Code %>" name="Name<%=lang.Code %>" class="input"
                        style="width: 550px;" value="<%=Shop.Bussiness.Language.Content(model.Name, lang.Code)%>"
                        shop="true" />
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("介绍")%>：
                </th>
                <td>
                    <textarea id="Content<%=lang.Code %>" cols="80" rows="5" class="textarea" style="height: 60px;
                        width: 550px;" name="Content<%=lang.Code %>" shop="true"><%=Shop.Bussiness.Language.Content(model.Content, lang.Code)%></textarea>
                    <script type="text/javascript">
                        CKEDITOR.replace('Content<%=lang.Code %>', {
                                height: '150',
                                toolbar: 'Basic',
                                language: '<%=Tag("CKEditor语言")%>'
		                });
                    </script>
                </td>
            </tr>
        </tbody>
        <%} %>
    </table>
    <ul id="tablistmain">
        <li class="selected"><a><span><%=Tag("通用信息")%></span></a></li></ul>
    <table
        id="common" class="table">
        <tbody>
            <tr>
                <th style="width:200px;">
                    <%=Tag("会员分组")%>：
                </th>
                <td>
                    <%foreach (Shop.Model.Lebi_UserLevel l in userlevels)
                      { %>
                      <label><input type="checkbox" name="UserLevel_ids" value="<%=l.id %>" <%=CheckStatus(model.UserLevel_ids,l.id) %> shop="true" /><%=Lang(l.Name) %></label>
                    <%} %>
                </td>
            </tr>
            <tr>
                <th style="width:200px;">
                    <%=Tag("时间")%>：
                </th>
                <td>
                    <input type="text" value="<%=FormatTime(model.Time_Start) %>" class="input-calendar" id="Time_Start" name="Time_Start" shop="true" style="width: 150px" />
                    -
                    <input type="text" value="<%=FormatTime(model.Time_End) %>" class="input-calendar" name="Time_End" shop="true" style="width: 150px" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("类型")%>：
                </th>
                <td>
                    <%=Shop.Bussiness.EX_Type.TypeRadio("PromotionType", "Type_id_PromotionType", model.Type_id_PromotionType, "shop=\"true\" onclick=\"ChangeType();\"")%>

                    <select style="display:none;" shop="true" id="Supplier_id" name="Supplier_id"><%=GetShops(model.Supplier_id)%></select>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("状态")%>：
                </th>
                <td>
                    <%=Shop.Bussiness.EX_Type.TypeRadio("PromotionStatus", "Type_id_PromotionStatus", model.Type_id_PromotionStatus, "shop=\"true\"")%>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("排斥其它")%>：
                </th>
                <td>
                    <label><input type="radio" name="IsRefuseOther" shop="true" value="1" <%=model.IsRefuseOther==1?"checked":"" %> /><%=Tag("是")%></label>
                    <label><input type="radio" name="IsRefuseOther" shop="true" value="0" <%=model.IsRefuseOther==0?"checked":"" %>><%=Tag("否")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("优先级")%>：
                </th>
                <td>
                    <input type="text" id="Sort" name="Sort" style="width: 70px" shop="true" class="input"
                        value="<%=model.Sort %>" onkeyup="value=value.replace(/[^\d]/g,'')" maxlength="4" />
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("内部备注")%>：<br>
                    <em>≤ <span id="remLen">255</span></em>
                </th>
                <td>
                    <textarea name="Remark" id="Remark" shop="true" rows="3" cols="60" class="textarea" onkeydown="checkMaxInput(this.form)" onkeyup="checkMaxInput(this.form)" style="height: 60px; width: 550px;"><%=model.Remark%></textarea>
                    <div class="tools clear">
                        <ul>
                            <li class="plus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Remark',100);"><b></b><span><%=Tag("展开")%></span></a></li>
                            <li class="minus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Remark',-100)"><b></b><span><%=Tag("收缩")%></span></a></li>
                        </ul>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <script type="text/javascript">
        function SaveObj() {
          var editor
            <%foreach (Shop.Model.Lebi_Language_Code lang in Shop.Bussiness.Language.Languages())
          {%>
            editor = CKEDITOR.instances.Content<%=lang.Code %>;
            $("#Content<%=lang.Code %>").val(editor.getData());
          <%} %>
            var postData = GetFormJsonData("shop");
            var url="<%=site.AdminPath %>/ajax/ajax_sale.aspx?__Action=PromotionType_Edit&id=<%=model.id %>";
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", "?id="+res.id)});
        }
        function PromotionEdit(id)
        {
            window.location="promotion.aspx?tid="+id;
        }
        function ChangeType()
        {
            var t=$("input[name='Type_id_PromotionType']:checked").val();
            if(t==422)
                $('#Supplier_id').show();
            else
                $('#Supplier_id').hide();
                
        }
        LanguageTab_EditPage('<%=CurrentLanguage.Code %>'); //加载默认语言
        ChangeType();
    </script>

          <%}else{%>
            <%=PageReturnMsg%>
          <%}%>
        </div>
    </div>
    
<div class="bottom" id="body_bottom"></div>

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
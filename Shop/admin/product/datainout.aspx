<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.admin.product.datainout" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title>
        <%=Tag("数据导入导出")%>-<%=site.title%></title>

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
            <li class="name"><span id="navIgation">
                <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a>
                >
                <%=Tag("数据导入导出") %></span></li>
        </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <div class="proBox clear">
        <ul class="btns clear">
            <li class="menu"><%=Tag("数据导入")%></li>
        </ul>
        <div class="iTabHead">
            <table
                id="common" class="table">
                <tbody>
                    <tr>
                        <th>
                            <%=Tag("导入分类")%>：
                        </th>
                        <td id="shopnick">
                            <select id="tb_typeid" name="tb_typeid">
                                <%=Shop.Bussiness.EX_Product.TypeOption(0,0,0,CurrentLanguage.Code)%>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("数据格式")%>：
                        </th>
                        <td>
                            <label><input type="radio" name="datatype" id="datatype" value="1" checked /><%=Tag("淘宝CSV")%></label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("数据文件")%>：
                        </th>
                        <td>
                            <input type="text" shop="true" id="tb_file" name="tb_file" class="input" style="width: 300px;" value="" /> 
                            <input id="file_tb_file" name="file_tb_file" class="input" type="file" /> 
                            <input id="Button2" onclick="uploadFile('tb_file');" value="<%=Tag("上传") %>" class="button" type="button" />
                            <span id="status_tb_file"></span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("图片文件夹")%>：
                        </th>
                        <td>
                            <input type="text" shop="true" id="tb_folder" name="tb_folder" class="input" style="width: 300px;" value="" />
                            <em>相对安装路径，以"/"开头和结尾</em>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("分隔符")%>：
                        </th>
                        <td>
                            <label><input type="radio" shop="true" name="tb_split" class="input" value="2" checked />逗号(,)</label>
                            <label><input type="radio" shop="true" name="tb_split" class="input" value="1" />制表符(/t)</label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("语言")%>：
                        </th>
                        <td>
                            <select id="tbin_lang" name="tbin_lang" shop="true">
                                <%=Shop.Bussiness.Language.LanguageOption(CurrentLanguage.Code)%>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <th>
                        </th>
                        <td>
                        <div class="tools tools-m clear">
                            <ul>
                                <li class="submit"><a href="javascript:void(0);" onclick="tb_product_in();"><b></b><span><%=Tag("提交")%></span></a></li>
                            </ul>
                        </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div class="proBox clear">
        <ul class="btns clear">
            <li class="menu"><%=Tag("数据导出")%></li>
        </ul>
        <div class="iTabHead">
            <table
                id="Table1" class="table">
                <tbody>
                    <tr>
                        <th>
                            <%=Tag("导出范围")%>：
                        </th>
                        <td>
                            <a href="javascript:void(0);" onclick="SearchWindow();"><%=Tag("高级搜索")%></a>
                            <%=sp.Description%>
                            
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("数量")%>：
                        </th>
                        <td>
                            <%=Shop.Bussiness.B_Lebi_Product.Counts("Product_id=0 "+sp.SQL) %>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("语言")%>：
                        </th>
                        <td>
                            <select id="tb_lang" name="tb_lang">
                                <%=Shop.Bussiness.Language.LanguageOption(CurrentLanguage.Code)%>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("数据格式")%>：
                        </th>
                        <td>
                            <label><input type="radio" name="datatype2" id="datatype2" value="1" checked /><%=Tag("淘宝CSV")%></label>
                        </td>
                    </tr>
                    <tr id="tr_down" style="display:none">
                        <th>
                            <%=Tag("下载")%>：
                        </th>
                        <td id="down_url">
                            
                        </td>
                    </tr>
                    <tr>
                        <th>
                        </th>
                        <td>
                        <div class="tools tools-m clear">
                            <ul>
                                <li class="submit"><a href="javascript:void(0);" onclick="tb_product_out();"><b></b><span><%=Tag("提交")%></span></a></li>
                            </ul>
                        </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        function tb_product_in() {
            var tb_typeid = $("#tb_typeid").val();
            var tb_file = $("#tb_file").val();
            var tb_folder = $("#tb_folder").val();
            var tb_split=$("input[name='tb_split']:checked").val();
            var tbin_lang=$("#tbin_lang").val();
            var url = "<%=site.AdminPath %>/ajax/export.aspx?__Action=taobao_product_in";
            var postData = { "tb_typeid": tb_typeid, "tb_file": tb_file,"tb_folder":tb_folder,"tb_split":tb_split,"tbin_lang":tbin_lang };
            $.ajax({
                type: "POST",
                url: url,
                data: postData,
                dataType: 'json',
                beforeSend: function () {
                    MsgBox(4, "正在处理 ……", "-");
                },
                success: function (res) {
                    if (res.msg == "OK") {
                        MsgBox(1, "<%=Tag("操作成功") %>："+res.count, "");
                    }
                    else {
                        MsgBox(2, res.msg, "");
                        return false;
                    }
                }
            });
        }
        function SearchWindow() {
            var title_ = "<%=Tag("商品查询")%>";
            var url_ = "../product/product_search_window.aspx?callback=search_&<%=sp.URL %>";
            var width_ = 700;
            var height_ = 505;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
       function search_(scurl) {
            window.location = "?"+scurl;
       }

        function tb_product_out()
        {
           var lang=$("#tb_lang").val();
           var url = "<%=site.AdminPath %>/ajax/export.aspx?__Action=taobao_product_out&lang="+lang+"&<%=sp.URL %>"; 
           $.ajax({
                type: "POST",
                url: url,
                data: '',
                dataType: 'json',
                beforeSend: function () {
                    MsgBox(4, "<%=Tag("正在处理") %> ……", "-");
                },
                success: function (res) {
                    if (res.msg == "OK") {
                        $("#tr_down").show()
                        $("#down_url").html("<a href=\""+res.url+"\" target=\"_blank\">"+res.url+"</a>");
                        MsgBox(1, "<%=Tag("操作成功") %>", "");
                    }
                    else {
                        MsgBox(2, res.msg, "");
                        return false;
                    }
                }
            });
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
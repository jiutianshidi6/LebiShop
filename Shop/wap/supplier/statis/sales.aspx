<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Supplier.Statis.Statis_Sales" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("销售报表")%>-<%=site.title%></title>

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
      <span><a href="<%=site.AdminPath %>/ajax/ajax_supplier.aspx?__Action=MenuJump&pid=0"><%=Lang(CurrentSupplier.Name)%></a></span>
    </div>
    <div id="service">
        <div class="layout">
          <span><em><%=Tag("您好！")%></em>[<%=CurrentSupplier.SubName%>|<%=CurrentSupplierUserGroup.Name%>]<%=CurrentSupplierUser.RemarkName%>&nbsp;&nbsp;<a href="<%=site.AdminPath %>/config/password.aspx"><%=Tag("改密")%></a>&nbsp;|&nbsp;<a href="<%=site.AdminPath %>/Logout.aspx" onclick="return quit()"><%=Tag("注销")%></a>&nbsp;|&nbsp;<a href="<%=Shop.Bussiness.ThemeUrl.GetURL("P_ShopIndex",CurrentSupplier.id.ToString(),"",CurrentLanguage.Code) %>" target="_blank"><%=Tag("网站前台")%></a></span>
        </div>
    </div>
    <div class="clearfix">
    </div>
    <div class="navmenu">
        <ul class="menu">
            <%foreach (Shop.Model.Lebi_Supplier_Menu menu in TopMenus)
                { %>
            <li class="<%=CurrentTopMenu.id==menu.id?"current":"" %>"><a href="<%=site.AdminPath %>/Ajax/ajax_supplier.aspx?__Action=MenuJump&pid=<%=menu.id %>"><span><%if (menu.Image != ""){ %><img src="<%=GetImage(site.WebPath + menu.Image) %>" height="15px" /><%} %><%=Tag(menu.Name)%></span></a> </li>
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
            <%foreach (Shop.Model.Lebi_Supplier_Menu menu in GetIndexMenus()){ %><li><a href="<%=MenuUrl(menu.URL,1) %>"><span><%=Tag(menu.Name)%></span></a></li><%}%>
        </ul>
        <% }else{ %>
        <%foreach (Shop.Model.Lebi_Supplier_Menu pmenu in GetMenus(CurrentTopMenu.id)){ %>
        <h2><span><img mid="<%=pmenu.id %>" src="<%=site.AdminImagePath %>/<%=MenuShow(pmenu.id)==true?"minus":"plus" %>.gif" id="imgStatis" /> <%=Tag(pmenu.Name)%></span></h2>
        <ul class="clear" <%=MenuShow(pmenu.id)==true?"":"style=\"display:none;\"" %>>
            <%foreach (Shop.Model.Lebi_Supplier_Menu menu in GetMenus(pmenu.id)){ %><li><a href="<%=MenuUrl(menu.URL,0) %>"><span><%=Tag(menu.Name)%></span></a></li><%}%>
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
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_supplier.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="<%=site.AdminPath %>/statis/sales.aspx"><%=Tag("销售报表")%></a></span></li>
    </ul>
    </div>

    </div>
      
      
    <div class="mainbody" id="body_main">
        <div id="body_main_form" style="min-width:1200px;width:100%">
          
    <script type="text/javascript" src="<%=site.AdminJsPath %>/My97DatePicker/WdatePicker.js"></script>
    <div class="proBox clear">
    <ul class="btns clear">
        <li class="submit" onclick="submit();"><%=Tag("提交")%></li>
    </ul>
    <div class="iTabHead">
        <table cellpadding="0" cellspacing="0" width="100%" class="table">
        <tr>
            <th>
                <%=Tag("订购日期")%>：
            </th>
            <td>
                <input type="text" name="dateFrom" id="dateFrom" size="12" class="input-calendar" value="<%=dateFrom%>" onClick="WdatePicker()" readonly /> - <input type="text" name="dateTo" id="dateTo" size="12" class="input-calendar" value="<%=dateTo%>" onClick="WdatePicker()" readonly />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("支付方式")%>：
            </th>
            <td>
                <select name="Pay_id" id="Pay_id">
                    <option value="0">┌<%=Tag("全部")%></option>
                    <%foreach (Shop.Model.Lebi_Pay pay in pays){%>
                    <option value="<%=pay.id %>" <%=Pay_id == pay.id?"selected":"" %>><%=Shop.Bussiness.Language.Content(pay.Name, CurrentLanguage.Code)%></option>
                    <%} %>
                </select>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("配送方式")%>：
            </th>
            <td>
                <select name="Transport_id" id="Transport_id">
                    <option value="0">┌<%=Tag("全部")%></option>
                    <%foreach (Shop.Model.Lebi_Transport transport in transports)
                      {%>
                    <option value="<%=transport.id %>" <%=Transport_id == transport.id?"selected":"" %>><%=transport.Name%></option>
                    <%} %>
                </select>
            </td>
        </tr>
    </table>
    </div>
    </div>
    <%if (display == 1){ %>
        <table cellpadding="0" cellspacing="0" width="100%" border="0" class="datalist">
            <tr class="title">
                <th>&nbsp;</th>
                <th><%=Tag("销售数量")%></th>
                <th><%=Tag("订单金额")%></th>
                <th><%=Tag("商品金额")%></th>
                <th><%=Tag("运费")%></th>
                <th><%=Tag("税金")%></th>
                <th><%=Tag("成本")%></th>
                <th><%=Tag("利润")%></th>
            </tr>
            <tbody id="monthparts"></tbody>
            <script type="text/javascript">
                function getmonthparts() {
                    $.ajax({
                        type: "POST",
                        url: "sales_part.aspx?dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&Pay_id=<%=Pay_id %>&Transport_id=<%=Transport_id%>",
                        data: '',
                        success: function (res) {
                            $("#div_error").dialog('close');
                            $("#monthparts").html(res);
                        }
                    });
                }
                $(function () {
                    getmonthparts();
                    addtrbg(".datalist");
                });
            </script>
        </table> 
    <%} %>
    <script type="text/javascript">
        function submit() {
            var dateFrom = $("#dateFrom").val();
            var dateTo = $("#dateTo").val();
            var Pay_id = $("#Pay_id").val();
            var Transport_id = $("#Transport_id").val();
            if (dateFrom == "" || dateTo == "") {
                MsgBox(1, "<%=Tag("请选择订购日期")%>", "")
            }
            window.location = "?display=1&dateFrom=" + dateFrom + "&dateTo=" + dateTo + "&Pay_id=" + Pay_id + "&Transport_id=" + Transport_id;
        }
    </script>

        </div>
    </div>
    
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
                      if (CurrentLanguage.Name == "")
                        {%><%=Tag("语言选择")%><%}else{%><%=CurrentLanguage.Name%><%} %></a>
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
</script>
</body>
</html>
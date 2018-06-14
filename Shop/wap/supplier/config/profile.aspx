<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Supplier.Config.Profile" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("编辑资料")%>-<%=site.title%></title>

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
      
<style type="text/css">.mainbody_top{display:none;height:0;overflow:hidden}</style>
    <div class="tools">
    <ul>
    <li class="submit"><a href="javascript:void(0);" onclick="SaveObj(0);"><b></b><span><%=Tag("保存")%></span></a></li>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_supplier.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <%=Tag("编辑资料")%></span></li>
    </ul>
    </div>

    </div>
      
      
    <div class="mainbody" id="body_main">
        <div id="body_main_form" style="min-width:1200px;width:100%">
          
<div class="searchbox clear">
    <div class="searchbox-l">
    <ul class="tabmenus">
        <li class="current"><a href="profile.aspx"><span><%=Tag("编辑资料")%></span></a></li>
        <li><a href="description.aspx"><span><%=Tag("店铺信息")%></span></a></li>
    </ul>
    </div>
    <div class="searchbox-r">
    </div>
</div>
<table cellspacing="0" border="0" style="width: 100%; border-collapse: collapse;" id="common" class="table">
    <tr>
        <th>
            Logo：
        </th>
        <td>
            <div id="image_Logo">
                <%if (model.Logo != "")
                    {%>
                <img height="60" src="<%=site.WebPath + model.Logo%>" />
                <%} %>
            </div>
            <input type="hidden" shop="true" id="Logo" name="Logo" class="input" style="width: 200px;" value="<%=model.Logo%>" readonly /> 
            <input id="file_Logo" name="file_Logo" type="file" class="input" />
            <input type="button" value="上传" onclick="uploadImage('Logo')" />
            <em>width:200px | height:200px</em>
        </td>
    </tr>
    <tr>
        <th>
            <%=Tag("公司名称")%>：
        </th>
        <td>
            <input type="text" shop="true" min="notnull" id="Company" name="Company" size="50" class="input" value="<%=model.Company %>" />
        </td>
    </tr>
    <tr>
        <th>
            <%=Tag("店铺简称")%>：
        </th>
        <td>
            <%=model.SubName %>
        </td>
    </tr>
    <tr>
        <th>
            <%=Tag("联系人")%>：
        </th>
        <td>
            <input type="text" shop="true" min="notnull" id="RealName" name="RealName" class="input" value="<%=model.RealName %>" style="width:200px" />
        </td>
    </tr>
    
    <tr>
        <th>
            <%=Tag("手机号码")%>：
        </th>
        <td>
            <input type="text" shop="true" min="notnull" id="MobilePhone" name="MobilePhone" class="input" value="<%=model.MobilePhone %>" style="width:200px" />
        </td>
    </tr>
    <tr>
        <th>
            <%=Tag("电话号码")%>：
        </th>
        <td>
            <input type="text" shop="true" min="notnull" id="Phone" name="Phone" class="input" value="<%=model.Phone %>" style="width:200px" />
        </td>
    </tr>
    <tr>
        <th>
            <%=Tag("QQ号码")%>：
        </th>
        <td>
            <input type="text" shop="true" min="notnull" id="QQ" name="QQ" class="input" value="<%=model.QQ %>" style="width:200px" />
        </td>
    </tr>
    <tr>
        <th>
            <%=Tag("Email地址")%>：
        </th>
        <td>
            <input type="text" shop="true" min="notnull" id="Email" name="Email" class="input" value="<%=model.Email %>" style="width:200px" />
        </td>
    </tr>
    <tr>
        <th>
            <%=Tag("地区")%>：
        </th>
        <td id="Area_id_div">
        </td>
    </tr>
    <tr>
        <th>
            <%=Tag("联系地址")%>：
        </th>
        <td>
            <input type="text" shop="true" min="notnull" id="Address" name="Address" size="50" class="input" value="<%=model.Address %>" />
        </td>
    </tr>
    <tr>
        <th>
            <%=Tag("邮政编码")%>：
        </th>
        <td>
            <input type="text" shop="true" min="notnull" id="Postalcode" name="Postalcode" class="input" value="<%=model.Postalcode %>" style="width:200px" />
        </td>
    </tr>
    <tr>
        <th>
            <%=Tag("状态")%>：
        </th>
        <td>
            <%=Shop.Bussiness.EX_Type.TypeName(model.Type_id_SupplierStatus,CurrentLanguage.Code)%>
        </td>
    </tr>
    <tr>
        <th>
            <%=Tag("金额")%>：
        </th>
        <td>
            <%=FormatMoney(model.Money) %>
        </td>
    </tr>
    <tr>
        <th>
            <%=Tag("保证金")%>：
        </th>
        <td>
            <%=FormatMoney(model.Money_Margin) %>
            &nbsp;&nbsp;&nbsp;
            <%=Tag("状态")%>：<%=(model.Money_Margin_pay>=model.Money_Margin?Tag("已缴"):Tag("未缴"))%>
            <%if(model.Money_Margin_pay<model.Money_Margin){ %>
            <a href="javascript:void(0);" onclick="PayWindow('suppliermargin',0,'<%=Tag("缴纳保证金")%>',<%=model.Money_Margin-model.Money_Margin_pay%>);" ><%=Tag("缴费") %></a>
            <%} %>
        </td>
    </tr>
    <tr>
        <th>
            <%=Tag("服务费")%>：
        </th>
        <td>
            <%=FormatMoney(model.Money_Service) %>
            &nbsp;&nbsp;&nbsp;
            <a href="javascript:void(0);" onclick="PayWindow('supplierservice',0,'<%=Tag("服务费续费")%>',<%=model.Money_Service%>);" ><%=Tag("续费") %></a>
        </td>
    </tr>
    <tr>
        <th>
            <%=Tag("结账天数")%>：
        </th>
        <td>
            <%=model.BillingDays %>
        </td>
    </tr>
    <%if (model.ProductTop > 0)
      { %>
    <tr>
        <th>
            <%=Tag("商品上限")%>：
        </th>
        <td>
            <%=model.ProductTop%>
        </td>
    </tr>
    <%} %>
    <tr>
        <th>
            <%=Tag("服务期限")%>：
        </th>
        <td>
            <%=FormatDate(model.Time_Begin) %> - <%=FormatDate(model.Time_End)%>
        </td>
    </tr>
</table>
<script type="text/javascript">
    GetAreaList(<%=SYS.TopAreaid %>, <%=model.Area_id %>); //加载地区下拉框
    function SaveObj() {
        var postData = GetFormJsonData("shop");
        if (!CheckForm("shop", "span"))
            return false;
        var Area_id = $("#Area_id").val();
        if (Area_id == 0) {
            CheckNO('Area_id','','span');
            return false;
        }
        var url = "<%=site.AdminPath %>/ajax/ajax_config.aspx?__Action=Profile_Edit&Area_id="+ Area_id;
        RequestAjax(url,postData,function(){
        <%if (model.Type_id_SupplierStatus==9010){ %>MsgBox(1, "<%=Tag("请进行身份验证")%>", "verified.aspx")}
        <%}else{ %>
        MsgBox(1, "<%=Tag("操作成功")%>", "")}
        <%} %>
        );
    }
    function uploadImage(id) {
        $.ajaxFileUpload
        (
	        {
	            url: WebPath + '/ajax/imageuploadone.aspx?path=supplierlogo',
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
	                            $("#image_" + id + "").html('<img height="60" src=' + WebPath + imageUrl + '>');
	                            $("#" + id + "").val(imageUrl);
	                        }
	                    }
	            }
	        }
        )
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
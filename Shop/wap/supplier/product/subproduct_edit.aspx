<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.supplier.product.subproduct_Edit" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%if (modelp.id > 0) { Response.Write(Shop.Bussiness.Language.Content(modelp.Name, CurrentLanguage.Code) + "-"); } %><%=Tag("商品管理")%>-<%=site.title%></title>

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
    <li class="add"><a href="javascript:void(0);" onclick="CreateProduct();"><b></b><span><%=Tag("生成")%></span></a></li>
    <li class="submit"><a href="javascript:void(0);" onclick="Product_Edit_muti();"><b></b><span><%=Tag("保存")%></span></a></li>
    <li class="del"><a href="javascript:void(0);" onclick="Product_Del();"><b></b><span><%=Tag("删除")%></span></a></li>
    <li class="edit"><a href="javascript:void(0);" onclick="Product_Image_Edit();"><b></b><span><%=Tag("修改图片")%></span></a></li>
    <li class="up"><a href="javascript:void(0);" onclick="Product_Status_Edit_muti(1);"><b></b><span><%=Tag("上架")%></span></a></li>
    <li class="down"><a href="javascript:void(0);" onclick="Product_Status_Edit_muti(0);"><b></b><span><%=Tag("下架")%></span></a></li>
    <li class="rotate"><a href="javascript:void(0);" onclick="javascript:history.back();"><b></b><span><%=Tag("返回")%></span></a></li>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="<%=site.AdminPath %>/product/default.aspx"><%=Tag("商品管理")%></a> > <%=Shop.Tools.Utils.CutString(Shop.Bussiness.Language.Content(modelp.Name, CurrentLanguage.Code),30,true) %></span></li>
    </ul>
    </div>

    </div>
      
      
<div class="mainbody_top">
        <table cellpadding="0" cellspacing="0" width="100%" class="table">
            <tr>
                <th>
                    <%=Tag("主规格")%>：
                </th>
                <td>
                    <select id="ProPertyMain" name="ProPertyMain" shop="true" sonproduct="true">
                        <option value="0"><%=Tag("不设置")%></option>
                        <%
                            foreach (Shop.Model.Lebi_ProPerty pro in ggs)
                            {
                        %>
                        <option value="<%=pro.id %>" <%=modelp.ProPertyMain==pro.id?"selected":"" %> ><%=Lang(pro.Name)%></option>
                        <%} %>
                    </select>
                </td>
            </tr>
            <%
                foreach (Shop.Model.Lebi_ProPerty pro in ggs)
                {
            %>
            <tr>
                <th>
                    <%=Lang(pro.Name)%>：
                </th>
                <td>
                    <%=Getpro131List(pro.id)%>
                </td>
            </tr>
            <%} %>
        </table>
</div>

    <div class="mainbody" id="body_main">
        <div id="body_main_form" style="min-width:1200px;width:100%">
          
    <table cellpadding="0" cellspacing="0" width="100%" class="datalist">
        <tr class="title">
            <th style="width: 24px;">
                <a href="javascript:void(0);" onclick="$('input[name=\'sonproductid\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));">
                    <%=Tag("全选")%></a>
            </th>
            <th style="width: 30px">
                <%=Tag("图片")%>
            </th>
            <th style="width: 80px">
                <%=Tag("编号")%>
            </th>
            <th style="width: 80px">
                <%=Tag("规格")%>
            </th>
            <th>
                <%=Tag("商品名称")%>
            </th>
            <th style="width: 80px">
                <%=Tag("市场价")%>
            </th>
            <th style="width: 80px">
                <%=Tag("销售价")%>
            </th>
            <th style="width: 80px">
                <%=Tag("成本价")%>
            </th>
            <th style="width: 80px">
                <%=Tag("库存")%>
            </th>
            <th style="width: 80px">
                <%=Tag("冻结库存")%>
            </th>
            <th style="width: 80px">
                <%=Tag("显示销量")%>
            </th>
            <th style="width: 50px">
                <%=Tag("状态")%>
            </th>
            <th style="width: 50px">
                <%=Tag("操作")%>
            </th>
        </tr>
        <tbody id="subproducts"></tbody>
    </table>

        </div>
    </div>
    
    <script type="text/javascript">
        function uploadImage(id) {
            $.ajaxFileUpload
        (
	        {
	            url: WebPath + '/ajax/imageupload.aspx',
	            secureuri: false,
	            fileElementId: 'file_' + id,
	            dataType: 'json',
	            success: function (data, status) {
	               
	                    if (data.msg != 'OK') {
	                        MsgBox(2, data.msg, "");
	                    }
	                    else {
	                        var imageUrl = data.ImageSmall;
	                        if (imageUrl.length > 0) {
	                            $("#image_" + id + "").html('<img height="30" src=' +WebPath+ imageUrl + '>');
	                            $("#" + id + "").val(imageUrl);
                                $("#ImageOriginal").val(data.ImageOriginal);
                                $("#ImageBig").val(data.ImageBig);
                                $("#ImageMedium").val(data.ImageMedium);
                                
	                        }
	                    }
	                
	            }
	        }
        )
        }
        function CreateProduct(){
            if (!confirm("<%=Tag("确认要生成同款的商品数据吗？")%>"))
                return false;
            var ggs=GetChkCheckedValues("Property131");
            var pid=<%=id %>;
            var tid=$("#Pro_Type_id").val();
            var postData={ "ggs": ggs,"pid":pid,"tid":tid };
            var url = "<%=site.AdminPath %>/ajax/ajax_product.aspx?__Action=CreateProductGuiGe";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "");getsubproducts();});
        }
        function Product_Del() {
            if (!confirm("<%=Tag("确认要删除吗？")%>"))
                return false;
            var postData = GetFormJsonData("ShopKeyID");
            var url = "<%=site.AdminPath %>/ajax/ajax_product.aspx?__Action=Product_Del";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "");getsubproducts();});
        }
        function Product_Edit_muti() {
            var postData = GetFormJsonData("sonproduct");
            var url = "<%=site.AdminPath %>/ajax/ajax_product.aspx?__Action=Product_Edit_muti_price_store&pid=<%=id %>";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "#")});
        }
        function Product_Status_Edit_muti(status) {
            var postData = GetFormJsonData("ShopKeyID");
            var url = "<%=site.AdminPath %>/ajax/ajax_product.aspx?__Action=Product_Status_Edit_muti&status="+status;
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "");getsubproducts();});
        }
        function Product_Name_Edit(id) {
            var title_ = "<%=Tag("编辑商品名称")%>";
            var url_ = "product_name_edit_window.aspx?pid=<%=id %>&subproduct=1&id=" + id;
            var width_ = 560;
            var height_ = 200;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Product_Remark_Edit(id) {
            var title_ = "<%=Tag("内部备注")%>";
            var url_ = "product_remark_edit_window.aspx?pid=<%=id %>&subproduct=1&id=" + id;
            var width_ = 560;
            var height_ = 200;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Product_Image_Edit() {
            var ids = GetChkCheckedValues("sonproductid");
            if (ids == "") {
                MsgBox(2, "<%=Tag("请选择要修改的商品")%>", "");
                return;
            }
            var title_ = "<%=Tag("批量编辑商品图片")%>";
            var url_ = "product_image_edit_window.aspx?id=<%=id %>&subproduct=1&ids=" + ids;
            var width_ = 600;
            var height_ = 300;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function getsubproducts() {
            $.ajax({
                type: "POST",
                url: "subproduct_list.aspx?pid=<%=modelp.id %>",
                data: '',
                success: function (res) {
                    $("#div_error").dialog('close'); 
                    $("#subproducts").html(res);
                }
            });
        }
        $(function () {
            getsubproducts();
        });
    </script>

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
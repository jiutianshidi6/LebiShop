<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.supplier.product.subproduct_edit_all" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%if (model.id > 0) { Response.Write(Shop.Bussiness.Language.Content(model.Name, CurrentLanguage.Code) + "-"); } %><%=Tag("商品管理")%>-<%=site.title%></title>
    <script type="text/javascript" src="<%=site.AdminJsPath %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=site.AdminJsPath %>/dialog.js"></script>
    <script type="text/javascript" src="<%=site.AdminJsPath %>/as.js"></script>

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
    <%if (id > 0 && randnum > 0){ %><li class="tip"><a href="javascript:void(0);"><b></b><span><%=Tag("复制")%></span></a></li><%} %>
    <%if (model.id > 0 && randnum == 0) {%>
    <li class="submit"><a href="javascript:void(0);" onclick="SaveObj(0);"><b></b><span><%=Tag("保存")%></span></a></li>
    <%}else{ %>
    <li class="submit"><a href="javascript:void(0);" onclick="SaveObj(1);"><b></b><span><%=Tag("保存并返回")%></span></a></li>
    <li class="submit"><a href="javascript:void(0);" onclick="SaveObj(2);"><b></b><span><%=Tag("保存并添加")%></span></a></li>
    <%} %>
    <li class="rotate"><a href="javascript:void(0);" onclick="javascript:history.back();"><b></b><span><%=Tag("返回")%></span></a></li>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="<%=site.AdminPath %>/product/default.aspx"><%=Tag("商品管理")%></a> > <%=Shop.Tools.Utils.CutString(Shop.Bussiness.Language.Content(model.Name, CurrentLanguage.Code),30,true) %><%if (id > 0 && randnum > 0){ %>（<%=Tag("复制")%>）<%} %></span></li>
    </ul>
    </div>

    </div>
      
      
<div class="mainbody_top">
    <ul class="tablist">
        <li onclick="Edit(1)" id="p1" class="selected"><a><span><%=Tag("基本信息")%></span></a></li>
        <li onclick="Edit(2)" id="p2"><a><span><%=Tag("通用信息")%></span></a></li>
        <li onclick="Edit(3);getproducts();" id="p3"><a><span><%=Tag("属性规格")%></span></a></li>
    </ul>
</div>

    <div class="mainbody" id="body_main">
        <div id="body_main_form" style="min-width:1200px;width:100%">
          
    <table id="table1" cellpadding="0" cellspacing="0" width="100%" class="table">
        <tr>
            <td colspan="2">
                <%=Shop.Bussiness.Language.AdminLanguageTab("") %>
            </td>
        </tr>
        <%foreach (Shop.Model.Lebi_Language_Code lang in Shop.Bussiness.Language.Languages())
          {%>
        <tbody id="lang_<%=lang.Code %>" class="lang_table" style="display: none">
            <tr>
                <th>
                    <%=Tag("商品名称")%>：
                </th>
                <td>
                    <input type="text" id="Name<%=lang.Code %>" shop="true" style="width: 500px;" name="Name<%=lang.Code %>" value="<%=Shop.Bussiness.Language.Content(model.Name, lang.Code) %>" class="input" />
                </td>
            </tr>
            <tr>
                <th valign="top">
                    <%=Tag("详细介绍")%>：
                </th>
                <td>
                    <textarea name="Description<%=lang.Code %>" shop="true" id="Description<%=lang.Code %>" class="text"><%=Shop.Bussiness.Language.Content(model.Description, lang.Code)%></textarea>
                    <script type="text/javascript">
                        CKEDITOR.replace('Description<%=lang.Code %>', {
                            height: '200',
                            width: '98%',
                            language: '<%=Tag("CKEditor语言")%>'
                        });
                    </script>
                </td>
            </tr>
            <%if (wap)
              { %>
            <tr>
                <th valign="top">
                    <%=Tag("WAP端描述")%>：
                </th>
                <td>
                    <textarea style="height: 60px; width: 500px;" shop="true" name="MobileDescription<%=lang.Code %>" id="MobileDescription<%=lang.Code %>" class="input"><%=Shop.Bussiness.Language.Content(model.MobileDescription, lang.Code)%></textarea>
                    <script type="text/javascript">
                        CKEDITOR.replace('MobileDescription<%=lang.Code %>', {
                            height: '150',
                            width: '98%',
                            language: '<%=Tag("CKEditor语言")%>'
                        });
                    </script>
                </td>
            </tr>
            <%} %>
        </tbody>
        <%} %>
    </table>
    <table id="table2" cellpadding="0" cellspacing="0" width="100%" class="table" style="display: none">
    <input type="hidden" name="Pro_Type_id" shop="true" id="Pro_Type_id" value="<%=model.Pro_Type_id %>" />
        <tr>
            <th>
                <%=Tag("商品编号")%>：
            </th>
            <td>
                <input type="text" id="Number" shop="true" min="notnull" name="Number" class="input" value="<%=model.Number %>" />
            </td>
        </tr>
        
        <tr>
            <th>
                <%=Tag("商品货号")%>：
            </th>
            <td>
                <input type="text" id="Code" shop="true" name="Code" class="input" value="<%=model.Code %>" />
            </td>
        </tr>
        
        <tr>
            <th>
                <%=Tag("商品单位")%>：
            </th>
            <td>
                <select id="Units_id" shop="true" name="Units_id">
                    <%=Shop.Bussiness.EX_Product.UnitOption(model.Units_id)%>
                </select>
            </td>
        </tr>
        
        <%if (!Shop.Bussiness.EX_Product.IsHaveSon(model.id))
          { %>
        <tr>
            <th>
                <%=Tag("库存数量")%>：
            </th>
            <td>
                <input type="text" id="Count_Stock" shop="true" min="notnull" onkeyup="value=value.replace(/[^\d]/g,'')" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" name="Count_Stock" class="input" style="width: 70px;" value="<%=model.Count_Stock %>" />
            </td>
        </tr>
        <%} %>
        <tr>
            <th>
                <%=Tag("警戒库存")%>：
            </th>
            <td>
                <input type="text" shop="true" min="notnull" onkeyup="value=value.replace(/[^\d]/g,'')" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" id="Count_StockCaution" name="Count_StockCaution" class="input" style="width: 70px;" value="<%=model.Count_StockCaution %>" />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("成本价")%>(<%=DefaultCurrency.Msige%>)：
            </th>
            <td>
                <input type="text" class="input" shop="true" min="notnull" id="Price_Cost" name="Price_Cost" style="width: 70px;" value="<%=model.Price_Cost %>" onkeyup="value=value.replace(/[^.\d]/g,'')" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^.\d]/g,''))" />
            </td>
        </tr>
       <%if (CurrentSupplierGroup.IsSubmit == 1)
         { %>
        <tr>
            <th>
                <%=Tag("市场价")%>(<%=DefaultCurrency.Msige%>)：
            </th>
            <td>
                <input type="text" id="Price_Market" shop="true" min="notnull" name="Price_Market" class="input" style="width: 70px;" value="<%=model.Price_Market %>" onkeyup="value=value.replace(/[^.\d]/g,'')" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^.\d]/g,''))" />
            </td>
        </tr>
        <tr>
            <th><%=Tag("销售价")%>(<%=DefaultCurrency.Msige%>)：</th>
            <td>
                <input type="text" class="input" id="Price" shop="true" min="notnull" name="Price" style="width: 70px;" value="<%=model.Price %>" onkeyup="value=value.replace(/[^.\d]/g,'')" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^.\d]/g,''))" />
            </td>
        </tr>
        <%} %>
        <tr>
            <th>
                <%=Tag("包装率")%>：
            </th>
            <td>
                <input type="text" shop="true" name="PackageRate" value="<%=model.PackageRate %>" onkeyup="value=value.replace(/[^\d]/g,'')" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" id="PackageRate" class="input" style="width: 70px;" />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("商品毛重")%>：
            </th>
            <td>
                <input type="text" shop="true" min="notnull" value="<%=model.Weight %>" class="input" onkeyup="value=value.replace(/[^\d]/g,'')" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" id="Weight" name="Weight" style="width: 70px;" /> <em><%=Tag("单位g，用来计算订单配送费用")%></em>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("商品净重")%>：
            </th>
            <td>
                <input type="text" shop="true" min="notnull" value="<%=model.NetWeight %>" class="input" onkeyup="value=value.replace(/[^\d]/g,'')" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" id="NetWeight" name="NetWeight" style="width: 70px;" />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("包装尺寸")%>：
            </th>
            <td>
                <%=Tag("L")%>：<input type="text" shop="true" name="VolumeL" value="<%=model.VolumeL %>" onkeyup="value=value.replace(/[^.\d]/g,'')" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^.\d]/g,''))" id="VolumeL" class="input" style="width: 70px;" />
                <%=Tag("W")%>：<input type="text" shop="true" name="VolumeW" value="<%=model.VolumeW %>" onkeyup="value=value.replace(/[^.\d]/g,'')" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^.\d]/g,''))" id="VolumeW" class="input" style="width: 70px;" />
                <%=Tag("H")%>：<input type="text" shop="true" name="VolumeH" value="<%=model.VolumeH %>" onkeyup="value=value.replace(/[^.\d]/g,'')" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^.\d]/g,''))" id="VolumeH" class="input" style="width: 70px;" /> <em><%=Tag("单位CM")%></em>
            </td>
        </tr>
        <tr>
            <th valign="top">
                <%=Tag("商品主图")%>：
            </th>
            <td>
                <div id="image_ImageSmall">
                    <%if (model.ImageSmall != "")
                      {%>
                    <img height="30" src="<%=WebPath+ model.ImageSmall%>" />
                    <%} %>
                </div>
                <input type="hidden" shop="true" id="ImageSmall" name="ImageSmall" value="<%=model.ImageSmall%>" />
                <input type="hidden" shop="true" id="ImageMedium" name="ImageMedium" value="<%=model.ImageMedium%>" />
                <input type="hidden" shop="true" id="ImageBig" name="ImageBig" value="<%=model.ImageBig%>" />
                <input type="hidden" shop="true" id="ImageOriginal" name="ImageOriginal" value="<%=model.ImageOriginal%>" />
                <input id="file_ImageSmall" name="file_ImageSmall" class="input" type="file" onchange="uploadImage('ImageSmall')" />
                
                <em><%=Tag("如果含有子商品，将使用自动提取首个子商品图片")%></em>
            </td>
        </tr>
         <%if (!Shop.Bussiness.EX_Product.IsHaveSon(model.id))
           { %>
        <tr>
            <th valign="top">
                <%=Tag("展示图")%>：
            </th>
            <td>
                <textarea id="Images" name="Images" shop="true" class="textarea" style="height: 60px; width: 450px;display:none"><%=model.Images%></textarea>
                <div id="imagesdiv"></div>
            </td>
        </tr>
        <%} %>
        
        <tr>
            <th>
                <%=Tag("商品类型")%>：
            </th>
            <td style="text-align: left;">
                <%=Shop.Bussiness.EX_Type.TypeRadio("ProductType", "Type_id_ProductType", model.Type_id_ProductType, "shop=\"true\" onclick=\"ChangeProductType();\"",CurrentLanguage.Code)%>
            </td>
        </tr>
        <tbody id="qianggoubody">
        <tr>
            <th><%=Tag("抢购价")%>(<%=DefaultCurrency.Msige%>)：</th>
            <td>
                <input type="text" class="input" id="Price_Sale" shop="true" min="notnull" name="Price_Sale" style="width: 70px;" value="<%=model.Price_Sale %>" onkeyup="value=value.replace(/[^.\d]/g,'')" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^.\d]/g,''))" />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("限购数量")%>：
            </th>
            <td>
                <input type="text" shop="true" name="Count_Limit" value="<%=model.Count_Limit %>" onkeyup="value=value.replace(/[^\d]/g,'')" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" id="Count_Limit" class="input" style="width: 70px;" />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("截止日期")%>：
            </th>
            <td>
                <input type="text" shop="true" name="Time_Expired" value="<%=model.Time_Expired %>" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" id="Time_Expired" class="input-calendar" style="width:200px" /> <em></em>
            </td>
        </tr>
        </tbody>
        <tr>
            <th>
                <%=Tag("商品状态")%>：
            </th>
            <td style="text-align: left;">
                <%=Shop.Bussiness.EX_Type.TypeRadio("ProductStatus", "Type_id_ProductStatus", model.Type_id_ProductStatus, "shop=\"true\"")%>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("上架日期")%>：
            </th>
            <td>
                <input type="text" shop="true" name="Time_OnSale" value="<%=model.Time_OnSale %>" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" id="Time_OnSale" class="input-calendar" style="width:200px" />
            </td>
        </tr>
        <tr>
            <th valign="top">
                <%=Tag("内部备注")%>：
            </th>
            <td>
                <textarea id="Remarks" shop="true" name="Remarks" class="textarea" style="height: 60px; width: 500px;"><%=model.Remarks %></textarea>
                <div class="tools clear">
                    <ul>
                        <li class="plus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Remarks',100);"><b></b><span><%=Tag("展开")%></span></a></li>
                        <li class="minus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Remarks',-100)"><b></b><span><%=Tag("收缩")%></span></a></li>
                    </ul>
                </div>
            </td>
        </tr>
    </table>
    <table id="table3" cellpadding="0" cellspacing="0" width="100%" class="table" style="display:none">
        <tbody id="shuxing">
        </tbody>
    </table>
    <div id="table4" style="display:none">
    </div>

        </div>
    </div>
    
    <input type="hidden" value="<%=action %>" id="action" />
    <script type="text/javascript">
        LanguageTab_EditPage('<%=CurrentLanguage.Code %>'); //加载默认语言
        function SaveObj(type) {
            <%foreach (Shop.Model.Lebi_Language_Code lang in Shop.Bussiness.Language.Languages()){%>
            var editor<%=lang.Code %> = CKEDITOR.instances.Description<%=lang.Code %>;
            $("#Description<%=lang.Code %>").val(editor<%=lang.Code %>.getData());
            <%if (wap){ %>
            var editor4<%=lang.Code %> = CKEDITOR.instances.MobileDescription<%=lang.Code %>;
            $("#MobileDescription<%=lang.Code %>").val(editor4<%=lang.Code %>.getData());
            <%} %>
            <%} %>
            if (!CheckForm("shop", "span"))
                return false;
            var postData = GetFormJsonData("shop");
            var action = $("#action").val();
            var url = "<%=site.AdminPath %>/ajax/ajax_product.aspx?__Action=SubProduct_Edit&id=<%=model.id %>";
            if (type == 0){
                var backurl = "#";
            }else if (type == 1){
                var backurl = "default.aspx";
            }else if (type == 2){
                var backurl = '';
            }
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", backurl)});
        }
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
        function ChangePro_Type() {
            var id = $("#Pro_Type_id").val();
            $.ajax({
                type: "POST",
                url: "product_edit_part.aspx?tid=" + id + "&pid=<%=model.id %>",
                data: '',
                success: function (res) {
                    $("#shuxing").html(res);
                }
            });
        }
        
        function Edit(id1) {
            $("#p"+id1+"").addClass("selected");
            $("#table" + id1).show();
            $("#action").val(id1);
            var id2 = 2;
            var id3 = 3;
            switch (id1) {
                case 1:
                    id2 = 2;
                    id3 = 3;
                    break;
                case 2:
                    id2 = 1;
                    id3 = 3;
                    break;
                case 3:
                    id2 = 2;
                    id3 = 1;
                    break;
            }
            $("#p" + id2).removeClass("selected");
            $("#p" + id3).removeClass("selected");
            $("#table" + id2).hide();
            $("#table" + id3).hide();
            if(id1==3)
                $("#table4").show();
            else
                $("#table4").hide();
        }
        function getproducts() {
            <%if (model.id > 0 && model.Product_id != 0) {%>
               return false;
            <%} %>
            var id = $("#Pro_Type_id").val();
            var Property131=GetChkCheckedValues("Property131");
            var ProPertyMain=$("#ProPertyMain").val();
            $.ajax({
                type: "POST",
                url: "product_edit_list.aspx?tid="+ id +"&randnum=<%=randnum %>&pid=<%=model.id %>&Property131="+ Property131 +"&ProPertyMain="+ProPertyMain,
                data: '',
                success: function (res) {
                    $("#div_error").dialog('close'); 
                    $("#table4").html(res);
                }
            });
        }
        function getImages() {
            var images = $("#Images").val();
            $.ajax({
                type: "POST",
                url: "<%=site.AdminPath %>/product/imagesupload.aspx?input=Images&pid=<%=model.id %>&randnum=<%=randnum %>",
                data: { "images": images },
                success: function (res) {
                    $("#imagesdiv").html(res);
                }
            });
        }
        function ChangeProductType(){
            var Type_id_ProductType=$("input[name='Type_id_ProductType']:checked").val();
            if(Type_id_ProductType==321)
                $("#qianggoubody").show();
            else
                $("#qianggoubody").hide();
        }
        $(function () {
            ChangePro_Type();
            getImages();
            getproducts();
            ChangeProductType();
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
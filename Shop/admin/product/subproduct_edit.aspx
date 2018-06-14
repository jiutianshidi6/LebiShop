<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.product.subproduct_Edit" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%if (modelp.id > 0) { Response.Write(Shop.Bussiness.Language.Content(modelp.Name, CurrentLanguage.Code) + "-"); } %><%=Tag("商品管理")%>-<%=site.title%></title>

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
    <li class="add"><a href="javascript:void(0);" onclick="CreateProduct();"><b></b><span><%=Tag("生成")%></span></a></li>
    <li class="submit"><a href="javascript:void(0);" onclick="Product_Edit_muti();"><b></b><span><%=Tag("保存")%></span></a></li>
    <li class="del"><a href="javascript:void(0);" onclick="Product_Del();"><b></b><span><%=Tag("删除")%></span></a></li>
    <li class="edit"><a href="javascript:void(0);" onclick="Product_Image_Edit();"><b></b><span><%=Tag("修改图片")%></span></a></li>
    <li class="up"><a href="javascript:void(0);" onclick="Product_Status_Edit_muti(1);"><b></b><span><%=Tag("上架")%></span></a></li>
    <li class="down"><a href="javascript:void(0);" onclick="Product_Status_Edit_muti(0);"><b></b><span><%=Tag("下架")%></span></a></li>
    <%}%>
    <li class="rotate"><a href="javascript:void(0);" onclick="javascript:history.back();"><b></b><span><%=Tag("返回")%></span></a></li>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="<%=site.AdminPath %>/product/default.aspx"><%=Tag("商品管理")%></a> > <%=Shop.Bussiness.Language.Content(modelp.Name, CurrentLanguage.Code) %></span></li>
    </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <table class="table">
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
    <table cellpadding="0" cellspacing="0" width="100%" class="datalist">
        <tr class="title">
            <th style="width: 40px;">
                <a href="javascript:void(0);" onclick="$('input[name=\'sonproductid\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));">
                    <%=Tag("全选")%></a>
            </th>
            <th style="width: 40px">
                <%=Tag("图片")%>
            </th>
            <th style="width: 100px">
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
            <%if (modelp.Type_id_ProductType == 321)
              { %>
            <th style="width: 80px">
                <%=Tag("抢购价")%>
            </th>
            <%}else if (modelp.Type_id_ProductType == 322)
              { %>
            <th style="width: 80px">
                <%=Tag("团购价")%>
            </th>
            <%}else if (modelp.Type_id_ProductType == 323)
              { %>
            <th style="width: 80px">
                <%=Tag("换购积分")%>
            </th>
            <%} %>
            <%if (Shop.Bussiness.EX_Admin.CheckPower("product_price_cost")){ %>
            <th style="width: 80px">
                <%=Tag("成本价")%>
            </th>
            <%} %>
            <th style="width: 80px">
                <%=Tag("库存")%>
            </th>
            <th style="width: 80px">
                <%=Tag("冻结库存")%>
            </th>
            <th style="width: 80px">
                <%=Tag("销量")%>
            </th>
            <th style="width: 80px">
                <%=Tag("显示销量")%>
            </th>
            <th style="width: 80px">
                <%=Tag("状态")%>
            </th>
            <th style="width: 80px">
                <%=Tag("操作")%>
            </th>
        </tr>
        <tbody id="subproducts"></tbody>
    </table>

          <%}else{%>
            <%=PageReturnMsg%>
          <%}%>
        </div>
    </div>
    
    <div class="bottom" id="body_bottom">
     <input type="hidden" id="Pro_Type_id" name="Pro_Type_id" shop="true" sonproduct="true" value="<%=modelp.Pro_Type_id %>">
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
	                        var imageUrl = data.img;
	                        if (imageUrl.length > 0) {
	                            $("#image_" + id + "").html('<img height="30" src="<%=webconfig.ImageURL%>'+ imageUrl + '">');
	                            $("#" + id + "").val(imageUrl);
                                //$("#ImageOriginal").val(data.ImageOriginal);
                                //$("#ImageBig").val(data.ImageBig);
                                //$("#ImageMedium").val(data.ImageMedium);
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
            var height_ = 'auto';
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Product_Remark_Edit(id) {
            var title_ = "<%=Tag("内部备注")%>";
            var url_ = "product_remark_edit_window.aspx?pid=<%=id %>&subproduct=1&id=" + id;
            var width_ = 560;
            var height_ = 'auto';
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
            var height_ = 'auto';
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
<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_SupplierRegister" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_SupplierRegister"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_SupplierRegister","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_SupplierRegister","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_SupplierRegister","description")%>" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="format-detection" content="telephone=no" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" />
<meta name="apple-mobile-web-app-status-bar-style" content="black" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<meta name="twcClient" content="false" id="twcClient" />
<meta name="revisit-after" content="1 days" />
<meta name="CurrenctCurrency" content="<%=CurrentCurrency.Code %>" />
<meta name="CurrenctCurrencyMsige" content="<%=CurrentCurrency.Msige %>" />
<meta name="CurrentExchangeRate" content="<%=CurrentCurrency.ExchangeRate %>" />
<meta name="CurrenctCurrencyLength" content="<%=CurrentCurrency.DecimalLength %>" />
<meta name="CurrentLanguage" content="<%=CurrentLanguage.Code %>" />
<meta name="generator" content="LebiShop V<%=SYS.Version+"."+SYS.Version_Son %>" />
<meta name="copyright" content="2003-<%=DateTime.Now.Year %> lebi.cn" />
<script src="/Theme/system/wap/js/jquery-3.1.0.min.js" type="text/javascript"></script>
<script src="/Theme/system/wap/js/jquery-ias.min.js"></script>
<%if (CurrentLanguage.IsLazyLoad==1){ %><script src="/Theme/system/wap/js/jquery.lazyload.min.js" type="text/javascript"></script><%} %>
<script src="/Theme/system/wap/js/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
<%if (CurrentLanguage.Code=="CN"){%><script type="text/javascript" src="/Theme/system/wap/js/jquery-ui/datepicker-zh-CN.js"></script><%}%>
<script src="<%=WebPath %>/ajax/js.aspx" type="text/javascript"></script>
<script src="/Theme/system/wap/js/main.js" type="text/javascript"></script>
<script src="/Theme/system/wap/js/messagebox.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="/Theme/system/wap/css/system.css" />
<link rel="stylesheet" type="text/css" href="/Theme/system/wap/js/jquery-ui/jquery-ui.min.css" />
<link rel="stylesheet" type="text/css" href="/Theme/system/wap/js/jquery-ui/jquery-ui.theme.min.css" />
<link rel="stylesheet" type="text/css" href="/theme/wap/css/css.css" />
<link rel="stylesheet" type="text/css" href="/theme/wap/css/<%=CurrentLanguage.Code %>.css" />

    
</head>
<body class="default">
    
<div class="mhead clearfix">
	<a href="javascript:history.go(-1);" class="a-back"><span>返回</span></a>
	<h2 id="pagename"><%=ThemePageMeta("P_SupplierRegister","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>
<script>
    var pagetitle = $("#pagename").html();
    if (pagetitle.indexOf(" - ") > -1) {
        $("#pagename").html(pagetitle.split(' - ')[0]);
    }
</script>

    <div class="body">
        <div class="bodymain">
            


<script type="text/javascript" src="/Theme/system/wap/js/ajaxfileupload.js"></script>
<div class="nbbox clearfix">
    <div class="user">
        <div class="reg clearfix">
            <div class="mt clearfix">
                <h2>
                    商家注册</h2>
            </div>
            <%if(supplier.Type_id_SupplierStatus==443){ %>
             <div class="mc">
                您的商家账号已停用
             </div>
            <%}else{ %>
            <div class="mc">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            <font color="red">*</font>申请类型：
                        </th>
                        <td>
                            <select id="Supplier_Group_id" name="Supplier_Group_id" shop="true" onchange="selectverified();">
                                <%=GroupOption(0) %>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <font color="red">*</font>店铺名称：
                        </th>
                        <td>
                            <input type="text" name="Name" id="Name" style="width: 200px;" value="<%=Lang(supplier.Name) %>" maxlength="100" min="4" max="100" class="input" shop="true" />
                        </td>
                    </tr>
                    
                    <tr>
                        <th>
                            <font color="red">*</font>店铺简称：
                        </th>
                        <td>
                            <input type="text" name="SubName" id="SubName" style="width: 200px;" value="<%=supplier.SubName %>" min="notnull" maxlength="6"
                                class="input" shop="true" /><span id="FormSubName" class="FormALT">审核通过后将不能修改</span>
                        </td>
                    </tr>
                     <tr>
                        <th>
                            <font color="red">*</font>公司名称：
                        </th>
                        <td>
                            <input type="text" name="Company" id="Company" style="width: 200px;" value="<%=supplier.Company %>" min="4" max="100"
                                class="input" shop="true" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <font color="red">*</font>联系人：
                        </th>
                        <td>
                            <input type="text" name="RealName" id="RealName" shop="true" style="width: 200px;" min="notnull" maxlength="100" value="<%=supplier.RealName %>" class="input" />
                        </td>
                    </tr>
                    
                    <tr>
                        <th>
                            <font color="red">*</font>手机号码：
                        </th>
                        <td>
                            <input type="text" shop="true" name="MobilePhone" id="MobilePhone" style="width: 200px;" onkeyup="value=value.replace(/[^\d]/g,'')" min="notnull" maxlength="11" value="<%=supplier.MobilePhone %>" class="input" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            电话号码：
                        </th>
                        <td>
                            <input type="text" name="Phone" id="Phone" style="width: 200px;" class="input" shop="true" value="<%=supplier.Phone %>" />
                            <span id="FormPhone" class="FormALT"></span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            QQ号码：
                        </th>
                        <td>
                            <input type="text" name="QQ" id="QQ" style="width: 200px;" class="input" shop="true" onkeyup="value=value.replace(/[^\d]/g,'')" value="<%=supplier.QQ %>"/>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <font color="red">*</font>EMAIL：
                        </th>
                        <td>
                            <input type="text" name="Email" id="Email" style="width: 200px;" class="input" shop="true" min="email" maxlength="100" value="<%=supplier.Email %>"/>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <font color="red">*</font>邮编：
                        </th>
                        <td>
                            <input type="text" name="Postalcode" id="Postalcode" style="width: 200px;" class="input" shop="true" min="notnull" maxlength="100" value="<%=supplier.Postalcode %>"/>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <font color="red">*</font>地区：
                        </th>
                        <td id="Area_id_div">
                            
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <font color="red">*</font>地址：
                        </th>
                        <td>
                            <input type="text" name="Address" id="Address" style="width: 200px;" class="input" shop="true" min="notnull" maxlength="100" value="<%=supplier.Address %>"/>
                        </td>
                    </tr>
                    <%foreach (Shop.Model.Lebi_Supplier_Verified model in verifieds)
                    {
                        string img=GetVerifiedImage(model.id);
                    %>
                    <tr class="verified" vid="<%=model.id %>" style="display:none;">
                        <th>
                            <font color="red">*</font><%=Lang(model.Name)%>：
                        </th>
                        <td>
                            <div id="image_Image<%=model.id %>">
                               <%if(img!=""){ %>
                               <img height="60" src="<%=Image(img) %>">
                               <%} %>
                            </div>
                            <input type="hidden" shop="true" min="notnull" id="Image<%=model.id %>" name="Image<%=model.id %>" class="input" style="width: 200px;" value="<%=img %>" />
                            <input id="file_Image<%=model.id %>" name="file_Image<%=model.id %>" type="file" class="input" onchange="uploadImage('Image<%=model.id %>')" />
                        </td>
                    </tr>
                    <%} %>
                    <%if (SYS.Verifycode_SupplierRegister == "1"){ %>
                    <tr>
                        <th>
                            <font color="red">*</font>验证码：
                        </th>
                        <td>
                            <input name="verifycode" type="text" shop="true" id="verifycode" min="notnull" shop="true" size="6"
                                class="input" />
                            <img class="img_c" align="absmiddle" style="width: 80px; height: 25px;" title="点击重新获取验证码"
                                id="img1" src="<%=WebPath%>/code.aspx" language="javascript" onclick="this.src=this.src+'?'">
                            <span id="Formverifycode"></span>
                        </td>
                    </tr>
                    <%} %>
                </table>
            </div>
            <table cellpadding="0" cellspacing="0" align="center">
                <tbody>
                    <tr>
                        <th>
                            &nbsp;
                        </th>
                        <td height="50">
                            <a href="javascript:void(0)" onclick="submit();" class="btn btn-6"><s></s>提交注册</a>
                        </td>
                    </tr>
                </tbody>
            </table>
            <%} %>
        </div>
    </div>
</div>
<div id="overlay" class="overlay"></div>
<script type="text/javascript">
    GetAreaList(<%=SYS.TopAreaid %>, <%=supplier.Area_id %>); //加载地区下拉框
    function submit() {
        
        if (!CheckForm("shop"))
            return false;
        var Area_id = $("#Area_id").val();
        if (Area_id == 0) {
            CheckNO('Area_id','','span');
            return false;
        }
        var postData = GetFormJsonData("shop");
        var url = "<%=site.AdminPath%>/ajax/ajax_user.aspx?__Action=User_Reg&Area_id="+Area_id+"&url=<%=backurl %>";
        RequestAjax(url, postData, function (res) { MsgBox(1, "注册成功", '<%=backurl %>') });
    }
    function selectverified()
    {
         var vid=$("#Supplier_Group_id").find("option:selected").attr('vids');
         vid=','+vid+',';
         $(".verified").each(function(i){
             if(vid.indexOf(','+$(this).attr('vid')+',')>-1){
                 $(this).show();
                 $("#Image" + $(this).attr('vid') + "").attr("min", "notnull");
             }else{
                 $(this).hide();
                 $("#Image" + $(this).attr('vid') + "").attr("min", "");
             }
         });
    }
    function uploadImage(id) {
        $.ajaxFileUpload
        (
	        {
	            url: path + '/ajax/imageuploadone.aspx?path=verified',
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
	                            $("#image_" + id + "").html('<img height="60" src=' + path + imageUrl + '>');
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
    selectverified();
</script>



        </div>
    </div>
    
<%
if(!IsAPP()){
%>
<div id="footnav">
<ul>
<li><a href="<%=URL("P_Index", "")%>"><img src="/Theme/system/wap/images/home.png" alt="首页" /><span>首页</span></a></li>
<li><a href="<%=URL("P_AllProductCategories", "")%>"><img src="/Theme/system/wap/images/category.png" alt="商品分类" /><span>商品分类</span></a></li>
<li><a href="<%=URL("P_Basket", "")%>"><img src="/Theme/system/wap/images/cart.png" alt="购物车" /><span>购物车</span></a></li>
<li><a href="<%=URL("P_UserCenter", "")%>"><img src="/Theme/system/wap/images/user.png" alt="会员中心" /><span>会员中心</span></a></li>
</ul>
</div>
<%}%>

    
</body>
</html><div style="width:100%;text-align:center;font-size:12px;color:#999">Powered by <a style="font-size:12px;color:#00497f" href="http://www.lebi.cn/support/license/?url=" target="_blank" title="LebiShop多语言网店系统">LebiShop</a> V<%=SYS.Version%>.<%=SYS.Version_Son%></div>
<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_UserReturnApply" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_UserReturnApply"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_UserReturnApply","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_UserReturnApply","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_UserReturnApply","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_UserReturnApply","title")%></h2>
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
          
    

<div class="nbbox clearfix">
<div class="user">
    <div class="table-list">
    <%
    foreach (Shop.Model.Lebi_Order_Product o_p in order_products){
    if(o_p.Type_id_OrderProductType==252)
    continue;
    %>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td style="width:50px" valign="top" rowspan="2"><a href="<%=URL("P_Product",o_p.Product_id) %>"><img src="<%=Image(o_p.ImageSmall) %>" style="width:50px;height:50px;" /></a></td>
        <td style="text-align:left" valign="top">
        <input type="checkbox" name="opid" shop="true" value="<%=o_p.id %>" />
        <%if(o_p.Type_id_OrderProductType==252){Response.Write("["+Tag("赠品")+"]");} %><a href="<%=URL("P_Product",o_p.Product_id) %>"><%=Lang(o_p.Product_Name) %></a></td>
        <td style="width:60px" valign="top">×<%=o_p.Count%></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align:left">退货数量：<input type="text" id="Text1" name="product_<%=o_p.id %>" shop="true" style="width: 50px;" value="<%=o_p.Count%>" />&nbsp;&nbsp;已退数量：<%=o_p.Count_Return %></td>
    </tr>
    </table>
    <%} %>
    </div>
</div>
</div>
<div class="nbbox clearfix">
<div class="userbox">
    <div class="mt">
        <h2>收货人信息</h2>
    </div>
    <div class="mc clearfix">
    <div class="dl-table clearfix">
    <dl>
        <dt>收货人：</dt>
        <dd><%=shouhuoren %></dd>
    </dl>
    <dl>
        <dt>收货地址：</dt>
        <dd><%=shouhuodizhi %></dd>
    </dl>
    <dl>
        <dt>电话：</dt>
        <dd><%=shouhuodianhua %></dd>
    </dl>
    <dl>
        <dt>邮编：</dt>
        <dd><%=shouhuoyoubian %></dd>
    </dl>
    <dl>
        <dt>退货原因：</dt>
        <dd><textarea class="textarea" style="width: 400px; height: 50px;" id="say" name="say" min="notnull" shop="true"></textarea>
        <span id="Formsay"></span></dd>
    </dl>
    <dl class="dl-btn">
        <dt></dt>
        <dd><a href="javascript:void(0)" onclick="submit();" class="btn btn-12"><s></s>提交</a></dd>
    </dl>
    </div>
    </div>
</div>
</div>
<script type="text/javascript" >
    function submit() {
        if (!CheckForm("shop", "span"))
            return false;
        var postData = GetFormJsonData("shop");
        var url = path+"/ajax/Ajax_order.aspx?__Action=torder_save&order_id=<%=order.id %>";
        RequestAjax(url, postData, function () { MsgBox(1, "操作成功", "<%=URL("P_UserReturn","") %>") });
    }
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
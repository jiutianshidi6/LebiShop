<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_AllProductCategories" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_AllProductCategories"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_AllProductCategories","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_AllProductCategories","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_AllProductCategories","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_AllProductCategories","title")%></h2>
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
            


<style>
.categories-body{position:relative;z-index:10}
.categories {
	position: relative;
	z-index: 0;
	overflow: hidden;
	background: #f9f9f9;
}
.categories li,.categories ul {
	margin: 0;
	padding: 0;
	list-style: none;
}
.categories .categories-block {
	position: relative;
	float: left;
	margin-right: 1px;
	border-right: 1px solid #ddd;
	background: #e6e6e6;
}
.categories .categories-block ul {
	position: relative;
	padding-top: 0px;
	background: #e6e6e6;
}
.categories .categories-block .fixed {
	position: fixed;
	top: 0;
}
.categories .categories-block .to-bottom {
	position: absolute;
	bottom: 0;
	left: 0;
}
.categories .categories-block li {
	border-top: 1px solid #e6e6e6;
	border-bottom: 1px solid #ddd;
}
.categories .categories-block li:first-child {
	border-top: 0px;
	border-bottom: 1px solid #e6e6e6;
}
.categories .categories-block li a {
	display: block;
	padding: 0 5px;
	height:35px;
	line-height:35px;
	font-size: 14px;
	-webkit-tap-highlight-color: transparent;
}
.categories .categories-block li.current {
	border-top: 1px solid #ddd;
	border-bottom: 1px solid #ddd;
	background: #f9f9f9;
}
.categories .categories-block li:first-child.current {
	border-top: 0px solid #ddd;
	border-bottom: 1px solid #ddd;
	background: #f9f9f9;
}
.categories .categories-block li.current a {
	padding-right: 6px;
	background: #f9f9f9;
	color: #f60;
}
.categories .categories-sub {
	overflow: hidden;padding:0;
}
.categories .categories-sub h2{
	height:35px;line-height:35px;color:#000;font-size:1.2em;padding:0 10px
}
.categories .categories-sub ul {
	margin: 0;
}
.categories .categories-sub .categories-single-sub {
	float:left;width:28.5%;margin-left:10px;
}
.categories .categories-sub .categories-single-sub:last-child {
	border-bottom: none;
}
.categories .categories-sub .img{
    display:block;width:100%;height:100%;
}
.categories .categories-sub .img img{
    width:100%;height:100%;
}
.categories .categories-sub h3{
    text-align:center;height:30px;line-height:30px;color:#000;font-size:1.2em;overflow:hidden
}
</style>
<div class="categories-body">                             
    <div class="categories clearfix">
        <div class="categories-block">
            <ul>
            <%
            int id = Shop.Tools.RequestTool.RequestInt("id",0);
            if (id == 0){
                id = EX_Product.ShowTypes(0,CurrentSite.id).FirstOrDefault().id;
            }
            foreach(Lebi_Pro_Type c0 in EX_Product.ShowTypes(0,CurrentSite.id))
            {
            %>
            <li <%if (id == c0.id){ %>class="current"<%} %>>
                <a href="<%=URL("P_AllProductCategories",c0.id) %>"><%=Lang(c0.Name) %></a>
            </li>
            <%}%>
            </ul>
        </div>
        <div class="categories-sub">
            <%
            foreach(Lebi_Pro_Type c1 in EX_Product.ShowTypes(id,CurrentSite.id))
            {     
            %>
            <h2><a href="<%=URL("P_ProductCategory",""+c1.id+"",Lang(c1.Url)) %>"><%=Lang(c1.Name) %></a></h2>
            <ul class="clearfix">
                <%
                foreach(Lebi_Pro_Type c2 in EX_Product.ShowTypes(c1.id,CurrentSite.id))
                {
                %>
                <li class="categories-single-sub clearfix">
                    <div class="img"><a href="<%=URL("P_ProductCategory",""+c2.id+"",Lang(c2.Url)) %>"><img src="<%=Image(c2.ImageSmall) %>" /></a></div>
                    <h3><a href="<%=URL("P_ProductCategory",""+c2.id+"",Lang(c2.Url)) %>"><%=Lang(c2.Name) %></a></h3>
                </li>
                <%}%>
            </ul>
            <%}%>
        </div>
    </div>
</div>


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
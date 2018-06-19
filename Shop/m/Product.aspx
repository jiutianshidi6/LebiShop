<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_Product" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_Product"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_Product","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_Product","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_Product","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_Product","title")%></h2>
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
            
<div class="productdetail">


<style>
    .slider img {
        max-height: 320px;
        max-width: 320px;
    }
</style>
<div id="lightBox" class="embed">
	<div class="pagingArea">
		<div id="slider" class="slider">
			<ul>
			</ul>
		</div>
	</div>
</div>
<script type="text/javascript">
<% 
string ims="";
foreach(LBimage image in images){
string temp="{\"img_id\":\"\",\"img_url\":\""+Image(image.original,"big")+"\",\"thumb_url\":\""+Image(image.original,"big")+"\",\"img_original\":\""+Image(image.original)+"\",\"img_desc\":\"\"}";
if(ims=="")
    ims=temp;
else
    ims+=","+temp;
} %>
var myarr = [<%=ims %>];
    var promoteItems=new Array();
promoteItems[0]=new Array(); 
promoteItems[0][0] = "<%=Image(product.ImageOriginal,"big") %>";
promoteItems[0][1] = "<%=Image(product.ImageOriginal,"big") %>";
                 
for (i = 0; i < myarr.length; i++)
{
    promoteItems[i+1]=new Array(); 
    promoteItems[i+1][0]=myarr[i]["img_url"];
    promoteItems[i+1][1]=myarr[i]["img_original"];                   
}
				
var noImg = 0;
var slider = new Swipe($('#slider')[0],{
	items:promoteItems,
	gestureAllowed:true,//滑动
	tapAllowed:true,	//点击
	zoomingAllowed:true,//浮起 显示指定的大图
    autoPlay:3000

});
</script>



<div id="productinfo"></div>
<script type="text/javascript">
    LoadPage(path+'/inc/product_info.aspx?id=<%=product.id %>','productinfo');
</script>



<script type="text/javascript">
    $(document).ready(function () {
        <%if (CurrentLanguage.IsLazyLoad==1){ %>$("img.contentlazy").lazyload({ placeholder: "/Theme/system/wap/images/lazy.gif", effect: "fadeIn" });<%} %>
        var ul = $("div.product-tab ul");
        var li = $("div.product-tab ul li");
        var divShow = $("div.product-cont");
        $(li).each(function (i) {
            var _this = this;
            $(_this).click(function () {
                ul.find("li").removeClass("selected");
                $(_this).addClass("selected");
                divShow.find("div.cont").hide();
                var divindex = divShow.find("div.cont")[i];
                $(divindex).show();
                SetCookie("Product-<%=product.id %>", i, 1);
                if (i == 1) { getcommentlist(); }
                if (i == 2) { getasklist(); }
                if (i == 3) { getrelatedlist(); }
            });
        });
        var i = GetCookie("Product-<%=product.id %>");
        if (i == "" || i == null)
            i = 0;
        if (i != "") {
            $(li).each(function () {
                ul.find("li").removeClass("selected");
                divShow.find("div.cont").hide();
                var divindex = divShow.find("div.cont")[i];
                $(li[i]).addClass("selected");
                $(divindex).show();
            });
            if (i == 1) { getcommentlist(); }
            if (i == 2) { getasklist(); }
            if (i == 3) { getrelatedlist(); }
        }
    });
    function ask() {
        var postData = GetFormJsonData("shop");
        var url = path + "/ajax/Ajax_userin.aspx?__Action=Ask_Write&id=<%=product.id %>";
        RequestAjax(url, postData, function () { MsgBox(1, "发送成功", "?"); $("#Content").val(""); getasklist(); });
    }
    function getasklist() {
        var url = path + "/inc/product_ask.aspx?id=<%=product.id %>&product_id=<%=product.Product_id %>";
        LoadPage(url, 'asklist');
    }
    function getcommentlist() {
        var url = path + "/inc/product_comment.aspx?id=<%=product.id %>&product_id=<%=product.Product_id %>";
        LoadPage(url, 'commentlist');
    }
    function getrelatedlist() {
        var url = path + "/inc/product_related.aspx?id=<%=product.id %>&tag=<%=Uri.EscapeDataString(product.Tags) %>&Count=20";
        LoadPage(url, 'relatedlist');
    }
</script>
<div class="product-tab clearfix">
    <ul class="tablist">
        <li class="selected"><a href="javascript:void(0);"><span>
            详细介绍</span></a></li>
        <li><a href="javascript:void(0);"><span>
            商品评价</span></a></li>
        <li><a href="javascript:void(0);"><span>
            商品咨询</span></a></li>
        <li><a href="javascript:void(0);"><span>
            相关商品</span></a></li>
    </ul>
</div>
<div class="product-cont">
    <div style="display: block" class="cont">
        <%if (CurrentSite.IsMobile==0){ %>
            <%=ImgSrc(Lang(product.Description),CurrentLanguage.IsLazyLoad) %>
        <%}else{ %>
            <%=ImgSrc(Lang(product.MobileDescription),CurrentLanguage.IsLazyLoad) %>
            <%if (Lang(product.MobileDescription)==""){ %><%=ImgSrc(Lang(product.Description),CurrentLanguage.IsLazyLoad) %><%} %>
        <%} %>
    </div>
    <div style="display: none" class="cont clearfix">
        <div id="commentlist">
        </div>
    </div>
    <div style="display: none" class="cont clearfix">
        <%if (CurrentUser.id > 0){%>
        <table class="tableform">
            <tbody>
                <tr>
                    <td>
                        <textarea id="Content" name="Content" cols="80" rows="3" class="textarea" shop="true"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="javascript:void(0)" onclick="ask();" class="btn btn-11"><s></s>发送</a>
                    </td>
                </tr>
            </tbody>
        </table>
        <%}else{%>
        <div class="mes">您还没有登录，请登录后咨询。</div>
        <%} %>
        <div id="asklist">
        </div>
    </div>
    <div style="display: none" class="cont clearfix">
        <div id="relatedlist">
        </div>
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
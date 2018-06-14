<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_Index" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",8,"CN","P_Index"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_Index","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_Index","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_Index","description")%>" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="format-detection" content="telephone=no" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" />
<meta name="apple-mobile-web-app-status-bar-style" content="black" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<meta name="twcClient" content="false" id="twcClient" />
<meta name="revisit-after" content="1 days" />
<meta name="CurrenctCurrency" content="<%=CurrentCurrency.Code %>" />
<meta name="CurrentExchangeRate" content="<%=CurrentCurrency.ExchangeRate %>" />
<meta name="CurrentLanguage" content="<%=CurrentLanguage.Code %>" />
<meta name="generator" content="LebiShop V<%=SYS.Version+"."+SYS.Version_Son %>" />
<meta name="copyright" content="2003-<%=DateTime.Now.Year %> lebi.cn" />
<script type="text/javascript">var path = "<%=WebPath %>";var sitepath = "/";var langpath = "/";</script>
<script src="http://192.168.1.188/Theme/system/wap/js/jquery.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="http://192.168.1.188/Theme/system/wap/css/system.css" />
<script src="<%=WebPath %>/ajax/js.aspx" type="text/javascript"></script>
<script src="http://192.168.1.188/Theme/system/wap/js/main.js" type="text/javascript"></script>
<script src="http://192.168.1.188/Theme/system/wap/js/messagebox.js" type="text/javascript"></script>
<script src="http://192.168.1.188/Theme/system/wap/js/my97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script src="http://192.168.1.188/Theme/system/wap/js/jquery-ui.min.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="http://192.168.1.188/Theme/system/wap/js/jqueryuicss/redmond/jquery-ui.css" />
<link rel="stylesheet" type="text/css" href="http://192.168.1.188/theme/wap/css/css.css" />
<link rel="stylesheet" type="text/css" href="http://192.168.1.188/theme/wap/css/<%=CurrentLanguage.Code %>.css" />

</head>
<body class="default">
    
<div id="header" class="clearfix">
    <div class="logo">

<a href="/"><img src="<%=Image(Lang(SYS.Logoimg)) %>" alt="<%=Lang(SYS.Name)%>" title="<%=Lang(SYS.Name)%>" /></a>
</div>
    <ul class="toplink">
		<li>
		<%if(CurrentUser.id>0){ %>
			<a href="<%=URL("P_UserCenter", "")%>"><%=CurrentUser.NickName %></a> <a href="javascript:void(0);" onclick="LoginOut();">退出登录</a>
		<%}else{ %>
			<a href="<%=URL("P_Login", "")%>">登录</a>
		<%} %>
		</li>
        
        <li><a href="<%=URL("P_Basket", "")%>" class="btnCart"><em id="cart_items"><%=Basket_Product_Count() %></em></a></li>
    </ul>
</div>
<div class="search">
	

<script type="text/javascript">
$(function () {
    blurInput('#keyword', '<%if (Rstring("Keyword")!=""){ %><%=Rstring("Keyword")%><%}else{%><%Table="Lebi_Searchkey";Where="Type=1";Order="Sort desc,id desc";PageSize=1;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int lzAq_index=1;
List<Lebi_Searchkey> lzAqs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey lzAq in lzAqs){%><%=Lang(lzAq.Name)%><%lzAq_index++;}%><%} %>');
    $("#keyword").click(function () {
        $("#keyword").val();
        $("#keywords").show();
    })
    $("#keywords").hover(function () {
        $("#keywords").show();
    }, function () {
        $("#keywords").hide();
    });
})
</script>
<div id="searchform">
<div class="searchform">
<input id="keyword" value="" type="text" name="keyword" onkeydown="if(event.keyCode==13){search();}" />
<input type="button" value="搜索" class="button" onclick="search();" />
<script type="text/javascript">
    function search() {
        var url = "<%=URL("P_Search","[key]") %>";
        location.href = url.replace("[key]",escape($("#keyword").val()));
    }
</script>
</div>
<div id="keywords">
    <div class="mbox clearfix">
    <div class="searchkeyword">
    <div class="mt">
        <h2>热搜排行</h2>
    </div>
    <div class="mc clearfix">
    <ul class="text">
        <%Table="Lebi_Searchkey";Where="";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int TJBX_index=1;
List<Lebi_Searchkey> TJBXs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey TJBX in TJBXs){%>
        <li><%if (TJBX.Type==1){ %><a href="<%=URL("P_Search",""+Lang(TJBX.Name)+"") %>"><%}else{ %><a href="<%=TJBX.URL%>"><%} %><%=Lang(TJBX.Name)%></a></li>
        <%TJBX_index++;}%>
    </ul>
    </div>
    </div>
    </div>
    <div class="mbox clearfix">
    <div class="searchbrand">
    <div class="mt">
        <h2>品牌推荐</h2>
    </div>
    <div class="mc clearfix">
    <ul class="text">
        <%Table="Lebi_Brand";Where="IsRecommend=1";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Brand.Counts(Where);int vakJ_index=1;
List<Lebi_Brand> vakJs = B_Lebi_Brand.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Brand vakJ in vakJs){%>
        <li><a href="<%=URL("P_Brand",vakJ.id)%>" title="<%=Lang(vakJ.Name) %>"><%=Lang(vakJ.Name) %></a></li>
        <%vakJ_index++;}%>
    </ul>
    </div>
    </div>
    </div>
</div>
</div>

</div>

    <div class="body">
        <div class="bodymain">
            
<div class="navmenu clearfix">
<ul>
	<li><a href="<%=URL("P_AllProductCategories","")%>"><span>商品分类</span></a><em>|</em></li>
	<li><a href="<%=URL("P_LimitBuy","")%>"><span>限时抢购</span></a><em>|</em></li>
	<li><a href="<%=URL("P_Exchange","")%>"><span>积分换购</span></a><em>|</em></li>
	<li><a href="<%=URL("P_GroupPurchase","")%>"><span>团购</span></a><em>|</em></li>
	<li><a href="<%=URL("P_ProductCommentIndex","")%>"><span>晒单</span></a></li>
</ul>
</div>
<div id="homePromote" class="pagingArea">
	<div id="slider" class="slider">
		<ul>
		</ul>
	</div>
</div>
<div class="banner clearfix">
	<% Advertisement("Index"); %>
</div>


<%Table="Lebi_Pro_Type";Where=""+ProductCategoryWhere+" and Parentid = 0 and IsShow = 1 and IsIndexShow = 1";Order="Sort desc,id desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Pro_Type.Counts(Where);int category_index=1;
List<Lebi_Pro_Type> categorys = B_Lebi_Pro_Type.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Pro_Type category in categorys){%>
<div class="nbbox clearfix">
<div class="categoryproducttop clearfix">
    <div class="mt clearfix">
        <div class="left">
            <h2><%=Lang(category.Name) %></h2>
        </div>
        <div class="right"><a href="<%=URL("P_ProductCategory",category.id,Lang(category.Url))%>"<%if (CurrentSite.IsMobile==0){ %> target="_blank"<%} %>>更多</a></div>
    </div>
    <div class="mc clearfix">
        <div class="productshow">
            <ul class="image">
                <%Table="Lebi_Product";Where=""+ProductWhere+" and Type_id_ProductType = 320 and "+ CategoryWhere(category.id) +"";Order="Sort desc,id desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Product.Counts(Where);int pro_index=1;
List<Lebi_Product> pros = B_Lebi_Product.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Product pro in pros){%>
                <li>
                    <div class="proimg"><p><a href="<%=URL("P_Product",pro.id) %>"><img border="0" src="<%=Image(pro.ImageOriginal,"medium") %>" alt="<%=Lang(pro.Name) %>" title="<%=Lang(pro.Name) %>" /></a></p></div>
                    <div class="proname"><a href="<%=URL("P_Product",pro.id) %>" title="<%=Lang(pro.Name) %>"><%=Lang(pro.Name) %></a></div>
                    <div class="proprice"><div class="marketprice"><i>市场价：</i><strong><%=FormatMoney(pro.Price_Market) %></strong></div><div class="buyprice"><i><%=Lang(CurrentUserLevel.PriceName) %>：</i><strong><%=FormatMoney(ProductPrice(pro)) %></strong></div></div>                    
                </li>
                <%pro_index++;}%>
            </ul>
            <div class="clear"></div>
        </div>
    </div>
</div>
</div>
<%category_index++;}%>
 


<div class="mbox clearfix">
<div class="brandtop">
<div class="mt">
    <h2>品牌推荐</h2>
</div>
<div class="mc clearfix">
<ul class="text">
    <%Table="Lebi_Brand";Where="Type_id_BrandStatus = 452 and IsRecommend=1";Order="Sort desc,id desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Brand.Counts(Where);int eHgQ_index=1;
List<Lebi_Brand> eHgQs = B_Lebi_Brand.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Brand eHgQ in eHgQs){%>
    <li><a href="<%=URL("P_Brand",eHgQ.id)%>" title="<%=Lang(eHgQ.Name) %>"><%=Lang(eHgQ.Name) %></a></li>
    <%eHgQ_index++;}%>
</ul>
</div>
</div>
</div>


        </div>
    </div>
    
<div id="footer" class="clearfix">
    <div class="copyright">
        <%=Lang(SYS.Copyright) %>
    </div>
    <div class="lang">
        

<div class="language">
<%List<Shop.Model.Lebi_Language> LcHUs=Languages();RecordCount=LcHUs.Count;int LcHU_index=1;
foreach (Shop.Model.Lebi_Language LcHU in LcHUs){%>
<a <%if (LcHU_index==RecordCount){%>class="last"<%} %> href="javascript:SetLanguage(<%=LcHU.id%>,'<%=LcHU.Code%>','<%=LcHU.Path%>');"><img src="<%=Image(LcHU.ImageUrl) %>" title="<%=LcHU.Name%>" /><%=LcHU.Name%></a>
<%LcHU_index++;}%>
</div>

    </div>
    <div class="currency">
        

<div class="currency"><ul class="dropcurrency"><li class="currency_li"><a class="noclick"><span>币种：</span><s><%=CurrentCurrency.Code %></s></a><dl class="currency_li_content">
<%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int TfKt_index=1;
List<Lebi_Currency> TfKts = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency TfKt in TfKts){%>
<dd <%if (TfKt_index==RecordCount){%>class="last"<%} %>><a href="javascript:SetCurrency(<%=TfKt.id%>,'<%=TfKt.Code%>',<%=TfKt.ExchangeRate%>,'<%=TfKt.Msige%>');"><%=TfKt.Code%></a></dd>
<%TfKt_index++;}%>
</dl></li></ul></div>

    </div>
    
<div id="footnav">
<ul>
<li><a href="<%=URL("P_Index", "")%>"><img src="http://192.168.1.188/Theme/system/wap/images/home.png" alt="首页" /><span>首页</span></a></li>
<li><a href="<%=URL("P_ProductCommentIndex", "")%>"><img src="http://192.168.1.188/Theme/system/wap/images/message.png" alt="晒单" /><span>晒单</span></a></li>
<li><a href="<%=URL("P_Basket", "")%>"><img src="http://192.168.1.188/Theme/system/wap/images/cart.png" alt="购物车" /><span>购物车</span></a></li>
<li><a href="<%=URL("P_UserCenter", "")%>"><img src="http://192.168.1.188/Theme/system/wap/images/user.png" alt="会员中心" /><span>会员中心</span></a></li>
</ul>
</div>

</div>


    
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_Index" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_Index"); %>

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
    
<%
if(!IsAPP()){
%>
<div id="header" class="clearfix">
    <div class="logo">

<a href="/m/"><img src="<%=Image(Lang(SYS.Logoimg)) %>" alt="<%=Lang(SYS.Name)%>" title="<%=Lang(SYS.Name)%>" /></a>
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
<%}%>
<div class="search">
	

<script type="text/javascript">
    $(function () {
        blurInput('#keyword', '<%if (Rstring("Keyword")!=""){ %><%=Rstring("Keyword")%><%}else{%><%Table="Lebi_Searchkey";Where="Type=1";Order="Sort desc,id desc";PageSize=1;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int WwYz_index=1;
List<Lebi_Searchkey> WwYzs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey WwYz in WwYzs){%><%=Lang(WwYz.Name)%><%WwYz_index++;}%><%} %>');
        $(".searchform .button").click(function(){
            var typename = $('#searchtype').attr('typename');
            var url = "";
            if (typename=="product")
            {
                var url = "<%=URL("P_Search","[key]") %>";
            }
            if (typename=="shop")
            {
                url = "<%=URL("P_ShopSearch","[key]") %>";
            }
            location.href = url.replace("[key]",escape($("#keyword").val()));
            return false;
        });
        $(".searchform dd a").click(function(){
            $(".searchform dl span").text($(this).text());
            $(".searchform dl span").attr("typename",$(this).attr("typename"));
            $(".searchform dd").hide();
        });
        $(".searchform-type dt").click(function () {
            $(".searchform dd").show();
        });
        $(".searchform dd a").click(function () {
            $(".searchform dl span").text($(this).text());
            $(".searchform dl span").attr("typename", $(this).attr("typename"));
            $(".searchform dd").hide();
            $("#keyword").val("");
        });
        <%if(!IsAPP()){%>
        $(".searchform-ipt input").click(function(){
            $("#keywords").show();
        });
        $("#keywords .mbox").hover(function(){
            $("#keywords").show();
        }, function () {
            $("#keywords").hide();
        });
        <%}%>
    });		
</script>
<div id="searchform">
<div class="searchform">
<div class="searchform-type">
<dl>
    <dt><span id="searchtype" typename="product">商品</span><em class="ico-jtb"></em></dt>
    <dd>
        <a typename="product" href="javascript:void(0)">商品</a>
        <%if (Shop.LebiAPI.Service.Instanse.Check("plugin_gongyingshang")){ %>
        <a typename="shop" href="javascript:void(0)">店铺</a>
        <%}%>
    </dd>
</dl>
</div>
<div class="searchform-ipt">
<input id="keyword" value="" type="text" name="keyword" onkeydown="if(event.keyCode==13){search();}" />
</div>
<div class="searchform-btn">
<input type="button" value="搜索" class="button" />
</div>
</div>
<%if(!IsAPP()){%>
<div id="keywords">
    <div class="mbox clearfix">
    <div class="searchkeyword">
    <div class="mt">
        <h2>热搜排行</h2>
    </div>
    <div class="mc clearfix">
    <ul class="text">
        <%Table="Lebi_Searchkey";Where="";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int JESL_index=1;
List<Lebi_Searchkey> JESLs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey JESL in JESLs){%>
        <li><%if (JESL.Type==1){ %><a href="<%=URL("P_Search",""+Lang(JESL.Name)+"") %>"><%}else{ %><a href="<%=JESL.URL%>"><%} %><%=Lang(JESL.Name)%></a></li>
        <%JESL_index++;}%>
    </ul>
    </div>
    </div>
    <div class="searchbrand">
    <div class="mt">
        <h2>品牌推荐</h2>
    </div>
    <div class="mc clearfix">
    <ul class="text">
        <%Table="Lebi_Brand";Where="IsRecommend=1";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Brand.Counts(Where);int NhRM_index=1;
List<Lebi_Brand> NhRMs = B_Lebi_Brand.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Brand NhRM in NhRMs){%>
        <li><a href="<%=URL("P_Brand",NhRM.id)%>" title="<%=Lang(NhRM.Name) %>"><%=Lang(NhRM.Name) %></a></li>
        <%NhRM_index++;}%>
    </ul>
    </div>
    </div>
    </div>
</div>
</div>
<%}%>

</div>

    <div class="body">
        <div class="bodymain">
            

<div class="navmenu clearfix">
<ul>
<%Table="Lebi_Page";Where="Node_id="+Node("HeadMenu").id+" and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int sXQD_index=1;
List<Lebi_Page> sXQDs = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page sXQD in sXQDs){%>
	<li><a href="<%=URL("","",sXQD.url)%>"><span style="color:<%=sXQD.NameColor%>"><%=sXQD.Name%></span></a><em>|</em></li>
<%sXQD_index++;}%>
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
                    <div class="proimg"><p><a href="<%=URL("P_Product",pro.id) %>"><img <%if (CurrentLanguage.IsLazyLoad==1){ %>class="lazy" src="/Theme/system/wap/images/lazy.gif" data-original<%}else{ %>src<%} %>="<%=Image(pro.ImageOriginal,"medium") %>" alt="<%=Lang(pro.Name) %>" title="<%=Lang(pro.Name) %>" /></a></p></div>
                    <div class="proname"><a href="<%=URL("P_Product",pro.id) %>" title="<%=Lang(pro.Name) %>"><%=Lang(pro.Name) %></a></div>
                    <div class="proprice"><%if (pro.Price_Market>0){ %><div class="marketprice"><i>市场价：</i><strong><%=FormatMoney(ProductPrice_Market(pro)) %></strong></div><%} %><div class="buyprice"><i><%=Lang(CurrentUserLevel.PriceName) %>：</i><strong><%=FormatMoney(ProductPrice(pro)) %></strong></div></div>                    
                </li>
                <%pro_index++;}%>
            </ul>
            <div class="clear"></div>
        </div>
    </div>
</div>
</div>
<%category_index++;}%>
 

        </div>
    </div>
    
<div id="footer" class="clearfix">
    <div class="copyright">
        <%=Lang(SYS.Copyright) %>
    </div>
    <div class="lang">
        

<div class="language">
<%List<Shop.Model.Lebi_Language> HyEjs=Languages();RecordCount=HyEjs.Count;int HyEj_index=1;
foreach (Shop.Model.Lebi_Language HyEj in HyEjs){%>
<a <%if (HyEj_index==RecordCount){%>class="last"<%} %> href="javascript:SetLanguage(<%=HyEj.id%>,'<%=HyEj.Code%>','<%=HyEj.Path%>');"><%if (HyEj.ImageUrl!=""){%><img src="<%=Image(HyEj.ImageUrl) %>" title="<%=HyEj.Name%>" /><%}%><%=HyEj.Name%></a>
<%HyEj_index++;}%>
</div>

    </div>
    <div class="currency">
        

<%if(SYS.IsMutiCurrencyShow=="0"){ %>
<div class="currency">
    <ul class="dropcurrency">
        <li class="currency_li"><a class="noclick"><span>币种：</span><s><%=CurrentCurrency.Code %></s></a><dl
            class="currency_li_content">
            <%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int YEtO_index=1;
List<Lebi_Currency> YEtOs = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency YEtO in YEtOs){%>
            <dd <%if (YEtO_index==RecordCount){%>class="last" <%} %>>
                <a href="javascript:SetCurrency(<%=YEtO.id%>,'<%=YEtO.Code%>',<%=YEtO.ExchangeRate%>,'<%=YEtO.Msige%>','<%=YEtO.DecimalLength%>');"><%=YEtO.Code%></a></dd>
            <%YEtO_index++;}%>
        </dl>
        </li>
    </ul>
</div>
<%} %>


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

</div>


    
</body>
</html><div style="width:100%;text-align:center;font-size:12px;color:#999">Powered by <a style="font-size:12px;color:#00497f" href="http://www.lebi.cn/support/license/?url=" target="_blank" title="LebiShop多语言网店系统">LebiShop</a> V<%=SYS.Version%>.<%=SYS.Version_Son%></div>
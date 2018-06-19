﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_LimitBuy" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("wangdayu523@163.com_37",1,"EN","P_LimitBuy"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>


<title><%=ThemePageMeta("P_LimitBuy","title")%></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" />
<meta name="keywords" content="<%=ThemePageMeta("P_LimitBuy","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_LimitBuy","description")%>" />
<meta name="CurrenctCurrency" content="<%=CurrentCurrency.Code %>" />
<meta name="CurrenctCurrencyMsige" content="<%=CurrentCurrency.Msige %>" />
<meta name="CurrentExchangeRate" content="<%=CurrentCurrency.ExchangeRate %>" />
<meta name="CurrentLanguage" content="<%=CurrentLanguage.Code %>" />
<meta name="generator" content="LebiShop V<%=SYS.Version+"."+SYS.Version_Son %>" />
<meta name="copyright" content="2003-<%=DateTime.Now.Year %> lebi.cn" />
<link rel="shortcut icon" href="/theme/newdefault/images/favicon.ico"/>
<link rel="bookmark" href="/theme/newdefault/images/favicon.ico"/> 
<script type="text/javascript">
    var path = "<%=WebPath %>";
    var sitepath = "/";
    var langpath = "/EN/";
</script>
<script src="/Theme/system/js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="/Theme/system/js/jquery-ui.min.js" type="text/javascript"></script>
<script src="/Theme/system/js/main.js" type="text/javascript"></script>
<script src="<%=WebPath %>/ajax/js.aspx" type="text/javascript"></script>
<script src="/Theme/system/js/my97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script src="/Theme/system/js/msclass.js" type="text/javascript"></script>
<script src="/Theme/system/js/prettyphoto/jquery.prettyphoto.js" type="text/javascript"></script>
<script src="/theme/newdefault/js/<%=CurrentLanguage.Code %>.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="/Theme/system/css/system.css" />
<link rel="stylesheet" type="text/css" href="/Theme/system/js/jqueryuicss/redmond/jquery-ui.css" />
<link rel="stylesheet" type="text/css" href="/Theme/system/js/prettyphoto/css/prettyPhoto.css" />
<link rel="stylesheet" type="text/css" href="/theme/newdefault/css/css.css" />
<link rel="stylesheet" type="text/css" href="/theme/newdefault/css/<%=CurrentLanguage.Code %>.css" />
<link rel="stylesheet" type="text/css" href="/theme/newdefault/css/weiyu.css" />
<script src="/theme/newdefault/js/all-jquery.js" type="text/javascript"></script>
<script type="text/javascript">
    var bForcepc = fGetQuery("dv") == "pc";
    function fBrowserRedirect() {
        var sUserAgent = navigator.userAgent.toLowerCase();
        var bIsIphoneOs = sUserAgent.match(/iphone os/i) == "iphone os";
        var bIsMidp = sUserAgent.match(/midp/i) == "midp";
        var bIsUc7 = sUserAgent.match(/rv:1.2.3.4/i) == "rv:1.2.3.4";
        var bIsUc = sUserAgent.match(/ucweb/i) == "ucweb";
        var bIsAndroid = sUserAgent.match(/android/i) == "android";
        var bIsCE = sUserAgent.match(/windows ce/i) == "windows ce";
        var bIsWM = sUserAgent.match(/windows mobile/i) == "windows mobile";
        if (bIsIphoneOs || bIsAndroid) {
            var sUrl = location.href;
            if (!bForcepc) {
                window.location.href = "/m/";
            }
        }
        if (bIsMidp || bIsUc7 || bIsUc || bIsCE || bIsWM) {
            var sUrl = location.href;
            if (!bForcepc) {
                window.location.href = "/m/";
            }
        }
    }
    function fGetQuery(name) {//获取参数值
        var sUrl = window.location.search.substr(1);
        var r = sUrl.match(new RegExp("(^|&)" + name + "=([^&]*)(&|$)"));
        return (r == null ? null : unescape(r[2]));
    }
    fBrowserRedirect();
</script>
 

</head>
<body>
  
<div class="head">
    <div class="top">
        <div class="center clearfix">
            <ul class="sns">
            	
                <li><a href="https://www.youtube.com/channel/UCuP7zVB_1u94BzaLCcMXYZA?view_as=subscriber" class="youtube" target="_blank"></a></li>
                
                <li><a href="https://plus.google.com/u/0/107335425411617972609/posts/p/pub" class="google" target="_blank"></a></li>
                <li><a href="https://twitter.com/crw_bathrooms" class="twitter" target="_blank"></a></li>
                <li><a href="https://www.facebook.com/profile.php?id=100009518509235&pnref=story" class="facebook" target="_blank"></a></li>
                <span class="userstatus" id="userstatus"><a href="<%=URL("P_Register", "") %>"><%=Tag("免费注册")%></a> ┊ <a href="<%=URL("P_Login", "") %>"><%=Tag("登录")%></a></span>
            </ul>
            <ul>
                <li>

<div class="shoppingcart" id="basketstatus" >
</div>
<script type="text/javascript">    LoadPage(path + '/inc/basketstatus.aspx', 'basketstatus');</script>
</li>
                <li>

<div class="language">
    <ul class="droplanguage">
        <li class="language_li"><a class="noclick"><span>Site Language：</span><s><%if (CurrentLanguage.ImageUrl!=""){%><img src="<%=Image(CurrentLanguage.ImageUrl) %>" /><%}%><%=CurrentLanguage.Name %></s></a><dl
            class="language_li_content">
            <%List<Shop.Model.Lebi_Language> LLyms=Languages();RecordCount=LLyms.Count;int LLym_index=1;
foreach (Shop.Model.Lebi_Language LLym in LLyms){%>
            <dd <%if (LLym_index==RecordCount){%>class="last" <%} %>>
                <a href="javascript:SetLanguage(<%=LLym.id%>,'<%=LLym.Code%>','<%=LLym.Path%>');"><%if (LLym.ImageUrl!=""){%><img src="<%=Image(LLym.ImageUrl) %>" /><%}%><%=LLym.Name%></a></dd>
            <%LLym_index++;}%>
        </dl>
        </li>
    </ul>
</div>
</li>
                <li>

<%if(SYS.IsMutiCurrencyShow=="0"){ %>
<div class="currency">
    <ul class="dropcurrency">
        <li class="currency_li"><a class="noclick"><span>Currency：</span><s><%=CurrentCurrency.Code %></s></a><dl
            class="currency_li_content">
            <%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int bplW_index=1;
List<Lebi_Currency> bplWs = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency bplW in bplWs){%>
            <dd <%if (bplW_index==RecordCount){%>class="last" <%} %>>
                <a href="javascript:SetCurrency(<%=bplW.id%>,'<%=bplW.Code%>',<%=bplW.ExchangeRate%>,'<%=bplW.Msige%>','<%=bplW.DecimalLength%>');"><%=bplW.Code%></a></dd>
            <%bplW_index++;}%>
        </dl>
        </li>
    </ul>
</div>
<%} %>

</li>
            </ul>
        </div>
    </div>
    <script type="text/javascript">        LoadPage(path + '/inc/userstatus.aspx', 'userstatus');</script>
    <div class="head-main">
        <h1 class="logo">
           

<a href="/EN/"><img src="<%=Image(Lang(SYS.Logoimg)) %>" alt="<%=Lang(SYS.Name)%>" title="<%=Lang(SYS.Name)%>" /></a>
</h1>
        <div class="search">
            

<script type="text/javascript">
    $(function () {
        blurInput('#keyword', '<%if (Rstring("Keyword")!=""){ %><%=Rstring("Keyword")%><%}else{%><%Table="Lebi_Searchkey";Where="Type=1";Order="Sort desc,id desc";PageSize=1;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int kGci_index=1;
List<Lebi_Searchkey> kGcis = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey kGci in kGcis){%><%=Lang(kGci.Name)%><%kGci_index++;}%><%} %>');
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
        $(".searchform-type").hover(function () {
            $(".searchform dd").show();
        }, function () {
            $(".searchform dd").hide();
        });
    });		
</script>
<div class="searchform">
<div class="searchform-type">
<dl>
    <dt><span id="searchtype" typename="product">Product</span><em class="ico-jtb"></em></dt>
    <dd>
        <a typename="product" href="javascript:void(0)">Product</a>
        <%if (Shop.LebiAPI.Service.Instanse.Check("plugin_gongyingshang")){ %>
        <a typename="shop" href="javascript:void(0)">shop</a>
        <%}%>
    </dd>
</dl>
</div>
<input id="keyword" value="" type="text" name="keyword" onfocus="if (this.value != '') {this.value = '';}" />
<input type="button" value="Search" class="button" />
</div>

            

<div class="searchkeyword">
<%Table="Lebi_Searchkey";Where="";Order="Sort desc,id desc";PageSize=5;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int qWKo_index=1;
List<Lebi_Searchkey> qWKos = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey qWKo in qWKos){%>
<%if (qWKo.Type==1){ %><a href="<%=URL("P_Search",""+Lang(qWKo.Name)+"") %>"><%}else{ %><a href="<%=qWKo.URL%>" target="_blank"><%} %><span><%=Lang(qWKo.Name)%></span></a>
<%qWKo_index++;}%>
</div>

        </div>
        <div class="toplink">
            <a href="<%=URL("P_UserCenter","") %>">
                <img src="/theme/newdefault/images/topIco1.png">My Account</a> <a href="<%=URL("P_Basket","") %>">
                    <img src="/theme/newdefault/images/topIco2.png">Shopping Cart</a>
        </div>
    </div>
</div>
  <div class="mainNav">
    <div class="mainNav-con">
      <div class="allnav">
        <h2 class="title">
          <a href="<%=URL("P_AllProductCategories", "")%>">All Categories</a><i class="title-icon"></i>
        </h2>
        <div class="allnav-show">
          <ul id="nav">
            <%
                        int ic0=0;
            foreach(Lebi_Pro_Type c0 in EX_Product.ShowTypes(0,CurrentSite.id))
            {
            ic0++;
            if(ic0>10)
            continue;
            %>
            <li id="mainCate-1" class="mainCate">
              <h3>
                <i class="nav-icon">
                  <%if(c0.ImageSmall!=""){ %>
                    <img src="<%=c0.ImageSmall %>" alt="<%=Lang(c0.Name) %>" style="width:18px;height:18px;" /><%} %></i><a href="<%=URL("P_ProductCategory",""+c0.id+"") %>"><%=Lang(c0.Name) %></a>
              </h3>
              <div class="subCate">
                <h4>
                  <a href="<%=URL("P_ProductCategory",""+c0.id+"") %>"><%=Lang(c0.Name) %> >></a>
                </h4>
                <ul>
                  <%
                                    int ic1=0;
                  foreach(Lebi_Pro_Type c1 in EX_Product.ShowTypes(c0.id,CurrentSite.id))
                  {
                  %>
                  <li>
                    <a href="<%=URL("P_ProductCategory",""+c1.id+"") %>"><%=Lang(c1.Name) %></a>
                  </li>
                  <%} %>
                </ul>
                <div class="nav-pic">
                  <img src="/theme/newdefault/images/w-ad.jpg" width="365" height="154" />
                </div>
              </div>
            </li>
            <%} %>
          </ul>
        </div>
      </div>
      
      <div class="other-menu">
        

<%Table="Lebi_Page";Where="Node_id="+Node("HeadMenu").id+" and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int rEtW_index=1;
List<Lebi_Page> rEtWs = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page rEtW in rEtWs){%>
<a class="menu" href="<%=URL("","",rEtW.url)%>"><span><%=rEtW.Name%></span></a>
<%rEtW_index++;}%>

      </div>
    </div>
  </div>
<script type="text/javascript">
$(document).ready(function(){
$('.allnav').mousemove(function(){
$(this).find('.allnav-show').slideDown("1000");//you can give it a speed
});
$('.allnav').mouseleave(function(){
$(this).find('.allnav-show').slideUp("fast");
});
});
jQuery("#nav").slide({
type:"menu", //效果类型
titCell:".mainCate", // 鼠标触发对象
targetCell:".subCate", // 效果对象，必须被titCell包含
delayTime:0, // 效果时间
triggerTime:0, //鼠标延迟触发时间
defaultPlay:false,//默认执行
returnDefault:true//返回默认
});
$(document).ready(function(){
$('.allnav').mousemove(function(){
$(this).find('.allnav-show').slideDown("1000");//you can give it a speed
});
$('.allnav').mouseleave(function(){
$(this).find('.allnav-show').slideUp("fast");
});
});
</script>

<div class="body clearfix">
    <div class="location"><div class="path"><%=path%></div></div>
    <div class="bodyside clearfix">
        


<div class="mbox clearfix">
<div class="producttop">
<div class="mt">
    <h2>Hot Goods</h2>
</div>
<div class="mc clearfix">
    <ul class="text">
        <%Table="Lebi_Product";Where=""+ProductWhere+" and Type_id_ProductType = 320";Order="Count_Views desc,id desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Product.Counts(Where);int producttop_index=1;
List<Lebi_Product> producttops = B_Lebi_Product.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Product producttop in producttops){%>
        <li>
            <a href="<%=URL("P_Product",producttop.id)%>" title="<%=Lang(producttop.Name)%>"><span><%=Lang(producttop.Name)%></span><strong><%=FormatMoney(ProductPrice(producttop))%></strong></a></li>
        <%producttop_index++;}%>
    </ul>
</div>
</div>
</div>



<div class="mbox clearfix">
<div class="articletop">
<div class="mt">
    <h2>Hot articles</h2>
</div>
<div class="mc clearfix">
    <ul>
        <%Table="Lebi_Page";Where="Node_id in (select id from Lebi_Node where parentid = "+ Node("Info").id +") and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Count_Views desc,id desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int pORh_index=1;
List<Lebi_Page> pORhs = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page pORh in pORhs){%>
        <li class="text"><a href="<%=URL("P_ArticleDetails",pORh.id,pORh.url)%>" target="<%=pORh.target%>" title="<%=pORh.Name%>"><span style="color:<%=pORh.NameColor%>"><%=pORh.Name%></span></a></li>
        <%pORh_index++;}%>
    </ul>
</div>
</div>
</div>


    </div>
    <div class="bodymain clearfix">
        


<%if (CurrentLanguage.IsLazyLoad==1){ %>
<script type="text/javascript">
    $(document).ready(
    function ($) {
        $("img.listlazy").lazyload({
            threshold: 300,
            effect: "fadeIn"
        });
    });
</script>
<%} %>
<div class="nbbox clearfix">
<div id="filter">
	<div class="fore1">
		<dl class="order">
			<dt>Sort：</dt>
			<dd <%if(sort == "" || sort == "1" || sort == "1a"){ %>class="curr <%if(sort == "" || sort == "1"){ %>up<%}else if(sort == "1a"){ %>down<%} %>"<%} %>><a href="<%=URL("P_LimitBuy",""+list+",1"+ordertmp+"") %>">Sales</a><b></b></dd>
			<dd <%if(sort == "2" || sort == "2a"){ %>class="curr <%if(sort == "2"){ %>up<%}else if(sort == "2a"){ %>down<%} %>"<%} %>><a href="<%=URL("P_LimitBuy",""+list+",2"+ordertmp+"") %>">Price</a><b></b></dd>
			<dd <%if(sort == "3" || sort == "3a"){ %>class="curr <%if(sort == "3"){ %>up<%}else if(sort == "3a"){ %>down<%} %>"<%} %>><a href="<%=URL("P_LimitBuy",""+list+",3"+ordertmp+"") %>">Reviews</a><b></b></dd>
			<dd <%if(sort == "4" || sort == "4a"){ %>class="curr <%if(sort == "4"){ %>up<%}else if(sort == "4a"){ %>down<%} %>"<%} %>><a href="<%=URL("P_LimitBuy",""+list+",4"+ordertmp+"") %>">Shelf Time</a><b></b></dd>
		</dl>
        <div class="list-cutover">
			<a id="list-unselected"  href="<%=URL("P_LimitBuy","2,"+ sort) %>" class="modfiy-url list-unselected <%=list=="2"?"list-curr":"" %>"><b></b>List</a>
			<a id="grid-unselected"  href="<%=URL("P_LimitBuy","1,"+ sort) %>" class="modfiy-url grid-unselected <%=(list=="1" || list=="")?"grid-curr":"" %>"><b></b>Grid</a>
		</div>
		<div class="pagin pagin-m" id="top_pagi">
			<%=HeadPage%>
		</div>
		<div class="total">
			<span>Total <strong><%=B_Lebi_Product.Counts(where) %></strong> Items</span>
		</div>
		<span class="clr"></span>
	</div>
</div>
<div class="mc clearfix">
    <div class="productlist limitbuylist loadlist"><ul>
        <%foreach (Shop.Model.Lebi_Product pro in products)
        {
        if (list == "" || list == "1"){ %>
        <li class="grid loadli">
            <div class="proimg">
                <p><a href="<%=URL("P_Product",pro.id) %>"><img <%if (CurrentLanguage.IsLazyLoad==1){ %>class="listlazy" src="/Theme/system/images/lazy.gif" data-original<%}else{ %>src<%} %>="<%=Image(pro,"medium")%>" alt="<%=Lang(pro.Name) %>" title="<%=Lang(pro.Name) %>" /></a></p></div>
            <div class="proname">
                <a href="<%=URL("P_Product",pro.id) %>" title="<%=Lang(pro.Name) %>"><%=Lang(pro.Name) %></a>
            </div>
            <div class="proinfo">
            <div class="buyprice"><i>Sales Price：</i><strong><%=FormatMoney(pro.Price_Sale) %></strong><em><%=Discount(pro.Price_Market,pro.Price_Sale) %>% OFF</em></div>
            <%if (pro.Price > 0){ %><div class="marketprice"><i>Sales Price：</i><strong><%=FormatMoney(pro.Price) %></strong></div><%} %>
            <div class="time_expired" endDate="<%if (System.DateTime.Now < pro.Time_Start){ %><%=DateFormat(pro.Time_Start)%><%}else{ %><%=DateFormat(pro.Time_Expired)%><%} %>" Product="<%=pro.id %>" id="time_expired_<%=pro.id %>">
                <%if (System.DateTime.Now < pro.Time_Start){ %>Time Left<%}else{ %>Time left<%} %>：<span><span id="dayEnd_<%=pro.id %>">0</span><em>Day</em><span id="hourEnd_<%=pro.id %>">0</span><em>H</em><span id="minEnd_<%=pro.id %>">0</span><em>M</em><span id="secEnd_<%=pro.id %>">0</span><em>S</em></span>
            </div>
            <div class="probtn">
            <%if (System.DateTime.Now < pro.Time_Start){ %>
            <strong>Start：<%= FormatTime(pro.Time_Start) %></strong>
            <%}else if (System.DateTime.Now > pro.Time_Expired){ %>
            <strong>Expired</strong>
            <%}else{ %>
                <%if(ProductStock(pro)<1){ %>
                <strong>Sold Out</strong>
                <%}else{ %>
                <a href="javascript:void(0)" onclick="UserProduct_Edit(<%=pro.id%>,142,$('#pro_num<%=pro.id%>').val());" class="buy btn btn-12"><s></s>Add to Cart</a>
                <%} %>
            <%} %>
            </div>
            </div>
        </li>
        <%}else{ %>
        <li class="list loadli">
            <div class="proimg">
                <p><a href="<%=URL("P_Product",pro.id) %>"><img <%if (CurrentLanguage.IsLazyLoad==1){ %>class="listlazy" src="/Theme/system/images/lazy.gif" data-original<%}else{ %>src<%} %>="<%=Image(pro,"medium")%>" alt="<%=Lang(pro.Name) %>" title="<%=Lang(pro.Name) %>" /></a></p></div>
            <div class="proname">
                <a href="<%=URL("P_Product",pro.id) %>" title="<%=Lang(pro.Name) %>"><%=Lang(pro.Name) %></a>
            </div>
            <div class="proinfo">
            <%if (pro.Price > 0){ %><div class="marketprice"><i>Sales Price：</i><strong><%=FormatMoney(pro.Price) %></strong></div><%} %>
            <div class="buyprice"><i>Sales Price：</i><strong><%=FormatMoney(pro.Price_Sale) %></strong><em><%=Discount(pro.Price_Market,pro.Price_Sale) %>% OFF</em></div>
            <div class="time_expired" endDate="<%if (System.DateTime.Now < pro.Time_Start){ %><%=DateFormat(pro.Time_Start)%><%}else{ %><%=DateFormat(pro.Time_Expired)%><%} %>" Product="<%=pro.id %>" id="time_expired_<%=pro.id %>">
                <%if (System.DateTime.Now < pro.Time_Start){ %>Time Left<%}else{ %>Time left<%} %>：<span><span id="dayEnd_<%=pro.id %>">0</span><em>Day</em><span id="hourEnd_<%=pro.id %>">0</span><em>H</em><span id="minEnd_<%=pro.id %>">0</span><em>M</em><span id="secEnd_<%=pro.id %>">0</span><em>S</em></span>
            </div>
            <div class="introduction"><%=Lang(pro.Introduction)%></div>
            <div class="probtn">
            <%if (System.DateTime.Now < pro.Time_Start){ %>
            <strong>Start：<%= FormatTime(pro.Time_Start) %></strong>
            <%}else if (System.DateTime.Now > pro.Time_Expired){ %>
            <strong>Expired</strong>
            <%}else{ %>
                <%if(ProductStock(pro)<1){ %>
                <strong>Sold Out</strong>
                <%}else{ %>
                <a href="javascript:void(0)" onclick="UserProduct_Edit(<%=pro.id%>,142,$('#pro_num<%=pro.id%>').val());" class="buy btn btn-12"><s></s>Add to Cart</a>
                <a href="javascript:void(0)" onclick="UserProduct_Edit(<%=pro.id%>,141);" class="fav btn btn-12"><s></s>Wish List</a>
                <%} %>
            <%} %>
            </div>
            </div>
        </li>
        <%} %>
        <%} %>
    </ul></div>
    <div class="clear"></div>
</div>
<%if (CurrentSite.IsMobile==0){ %>
<div class="footpage">
    <%=FootPage%>
</div>
<%}else{%>
<div class="loadpage">
    <a data-next="<%=NextPage%>"></a>
</div>
<script>
    $(document).ready(function () {
        var container = document.querySelector('.loadlist');
        var ias = $.ias({
            container: ".loadlist",
            item: ".loadli",
            pagination: ".loadpage",
            next: ".loadpage a"
        });
        ias.on('render', function (items) {
            //$(items).css({ opacity: 0 });
        });
        ias.on("rendered", function (items) {
        });
        ias.extension(new IASSpinnerExtension({ html: "<li class=\"loadinginfo\"><img src=\"{src}\" />&nbsp;Downloading</li>" }));
        ias.extension(new IASTriggerExtension({ text: 'Show more', offset: 100, html: "<li class=\"loadinginfo more\"><p>{text}</p></li>" }));
        ias.extension(new IASNoneLeftExtension({
            text: '', html: ""
        }));
    });
</script>
<%}%>
</div>


    </div>
</div>

<div class="footer">
    <%=Lang(SYS.FootHtml) %>
    <div class="copyright f11 footer_logos">
        <div class="footer_logos-list">
            <%Table="Lebi_FriendLink";Where="IsShow=1 and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc,id desc";PageSize=7;pageindex=1;RecordCount=B_Lebi_FriendLink.Counts(Where);int EumY_index=1;
List<Lebi_FriendLink> EumYs = B_Lebi_FriendLink.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_FriendLink EumY in EumYs){%>
            
                <% if (EumY.Logo != "" && EumY.IsPic == 1){ %><a href="<%=EumY.Url%>" target="_blank"><img src="<%=Image(EumY.Logo) %>" alt="<%=EumY.Name%>" /></a><%}else{%><a href="<%=EumY.Url%>" target="_blank"><%=EumY.Name%></a><%} %>     
           
            <%EumY_index++;}%>
         </div>
    </div>
</div>
<div class="copyright">
    

<%if (servicepannel.Status == "1"){%>
<%if (servicepannel.Style == "1"){%>
<script type="text/javascript" src="/Theme/system/js/ServicePanel.js"></script>
<div id="divStayTopLeft" onmouseout="Showservicepannel(event);" style="z-index:9998;width: 170px; position:absolute; right:0">
<layer id="divStayTopLeft">
<div id="divOnline" style="display:none;">
<div class="servicepannel">
<div class="menutop"><img src="/Theme/system/images/<%=CurrentLanguage.Code %>/ServicePanel/<%=servicepannel.Theme%>_1.gif" alt="" /></div>
<div class="menucenter"><div style="background:url(/Theme/system/images/<%=CurrentLanguage.Code %>/ServicePanel/<%=servicepannel.Theme%>_2.gif) repeat-y">
<%Table="Lebi_ServicePanel_Group";Where="Supplier_id = 0 and ','+Language_ids+',' like '%,"+ CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_ServicePanel_Group.Counts(Where);int group_index=1;
List<Lebi_ServicePanel_Group> groups = B_Lebi_ServicePanel_Group.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ServicePanel_Group group in groups){%>
<ul class="group clearfix">
<h2><%=group.Name%></h2>
<ul class="group-user clearfix">
<%Table="Lebi_ServicePanel";Where="Supplier_id = 0 and ServicePanel_Group_id = "+group.id+" and ','+Language_ids+',' like '%,"+ CurrentLanguage.id + ",%'";Order="Sort desc,id desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_ServicePanel.Counts(Where);int user_index=1;
List<Lebi_ServicePanel> users = B_Lebi_ServicePanel.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ServicePanel user in users){%>
<%
    string url = GetServicePanelType(user.ServicePanel_Type_id).Url;
    url = url.Replace("{@uid}",user.Account);
    url = url.Replace("{@uname}",user.Name);
%>
<li><a target="blank" href="<%=url%>"><img src="<%if (GetServicePanelType(user.ServicePanel_Type_id).IsOnline == 1){
    Response.Write(GetServicePanelType(user.ServicePanel_Type_id).Code.Replace("{@uid}",user.Account));
}else{
    Response.Write(Image(GetServicePanelType(user.ServicePanel_Type_id).Face));
}%>" border="0" align="absmiddle" />&nbsp;<%=user.Name%></a></li>
<%user_index++;}%>
</ul>
</li></ul>
<%group_index++;}%>
</div></div>
<div class="menufoot" style="background:url(/Theme/system/images/<%=CurrentLanguage.Code %>/ServicePanel/<%=servicepannel.Theme%>_3.gif) top no-repeat"><img src="/Theme/system/images/<%=CurrentLanguage.Code %>/ServicePanel/<%=servicepannel.Theme%>_3.gif" /></div>
</div>
</div></layer>
<div id="divMenu" onmouseover="servicepannelOver();"><img src="/Theme/system/images/<%=CurrentLanguage.Code %>/ServicePanel/menu_<%=servicepannel.Theme%>.gif" style="right:0;border:none;cursor:pointer;width:26px;height:136px;position: absolute;" /></div>
</div>
<%} else{%>
<div class="servicepannel-fix clearfix">
<ul class="group">
<%Table="Lebi_ServicePanel_Group";Where="Supplier_id = 0 and ','+Language_ids+',' like '%,"+ CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_ServicePanel_Group.Counts(Where);int group_index=1;
List<Lebi_ServicePanel_Group> groups = B_Lebi_ServicePanel_Group.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ServicePanel_Group group in groups){%>
<li>
<h2><%=group.Name%></h2>
<ul class="group-user">
<%Table="Lebi_ServicePanel";Where="Supplier_id = 0 and ServicePanel_Group_id = "+group.id+" and ','+Language_ids+',' like '%,"+ CurrentLanguage.id + ",%'";Order="Sort desc,id desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_ServicePanel.Counts(Where);int user_index=1;
List<Lebi_ServicePanel> users = B_Lebi_ServicePanel.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ServicePanel user in users){%>
<%
    string url = GetServicePanelType(user.ServicePanel_Type_id).Url;
    url = url.Replace("{@uid}",user.Account);
    url = url.Replace("{@uname}",user.Name);
%>
<li><a target="blank" href="<%=url%>"><img src="<%if (GetServicePanelType(user.ServicePanel_Type_id).IsOnline == 1){
    Response.Write(GetServicePanelType(user.ServicePanel_Type_id).Code.Replace("{@uid}",user.Account));
}else{
    Response.Write(Image(GetServicePanelType(user.ServicePanel_Type_id).Face));
}%>" border="0" align="absmiddle" />&nbsp;<%=user.Name%></a></li>
<%user_index++;}%>
</ul>
</li>
<%group_index++;}%>
</ul></div>
<%}}%>

    <%=Lang(SYS.Copyright) %>
    <%=GetCNZZ() %>
</div>


</body>
</html><div style="width:100%;text-align:center;font-size:12px;color:#999">Powered by <a style="font-size:12px;color:#00497f" href="http://www.lebi.cn/support/license/?url=" target="_blank" title="LebiShop多语言网店系统">LebiShop</a> V<%=SYS.Version%>.<%=SYS.Version_Son%></div>
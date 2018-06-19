<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_Basket" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("wangdayu523@163.com_37",1,"EN","P_Basket"); %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">


<title><%=ThemePageMeta("P_Basket","title")%></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" />
<meta name="keywords" content="<%=ThemePageMeta("P_Basket","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_Basket","description")%>" />
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
            <%List<Shop.Model.Lebi_Language> GXuas=Languages();RecordCount=GXuas.Count;int GXua_index=1;
foreach (Shop.Model.Lebi_Language GXua in GXuas){%>
            <dd <%if (GXua_index==RecordCount){%>class="last" <%} %>>
                <a href="javascript:SetLanguage(<%=GXua.id%>,'<%=GXua.Code%>','<%=GXua.Path%>');"><%if (GXua.ImageUrl!=""){%><img src="<%=Image(GXua.ImageUrl) %>" /><%}%><%=GXua.Name%></a></dd>
            <%GXua_index++;}%>
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
            <%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int nqhF_index=1;
List<Lebi_Currency> nqhFs = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency nqhF in nqhFs){%>
            <dd <%if (nqhF_index==RecordCount){%>class="last" <%} %>>
                <a href="javascript:SetCurrency(<%=nqhF.id%>,'<%=nqhF.Code%>',<%=nqhF.ExchangeRate%>,'<%=nqhF.Msige%>','<%=nqhF.DecimalLength%>');"><%=nqhF.Code%></a></dd>
            <%nqhF_index++;}%>
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
        blurInput('#keyword', '<%if (Rstring("Keyword")!=""){ %><%=Rstring("Keyword")%><%}else{%><%Table="Lebi_Searchkey";Where="Type=1";Order="Sort desc,id desc";PageSize=1;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int yGaF_index=1;
List<Lebi_Searchkey> yGaFs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey yGaF in yGaFs){%><%=Lang(yGaF.Name)%><%yGaF_index++;}%><%} %>');
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
<%Table="Lebi_Searchkey";Where="";Order="Sort desc,id desc";PageSize=5;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int wrov_index=1;
List<Lebi_Searchkey> wrovs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey wrov in wrovs){%>
<%if (wrov.Type==1){ %><a href="<%=URL("P_Search",""+Lang(wrov.Name)+"") %>"><%}else{ %><a href="<%=wrov.URL%>" target="_blank"><%} %><span><%=Lang(wrov.Name)%></span></a>
<%wrov_index++;}%>
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
        

<%Table="Lebi_Page";Where="Node_id="+Node("HeadMenu").id+" and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int Qndh_index=1;
List<Lebi_Page> Qndhs = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page Qndh in Qndhs){%>
<a class="menu" href="<%=URL("","",Qndh.url)%>"><span><%=Qndh.Name%></span></a>
<%Qndh_index++;}%>

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
  
<div class="process-min">
<ul>
	<li class="current"><span>Add to Cart</span></li>
	<li class="over"><span class="con">Enter order information</span></li>
	<li class="over"><span class="con">Order Successfully Submitted</span></li>
    <li class="last"><span>Pending Shipping</span></li>
</ul>
</div>


<div id="basket">
<%if (basket.Products.Count == 0 && basket.FreeProducts.Count == 0){%>
    <table align="center" cellpadding="0" cellspacing="0">
    <tr><td class="basketempty">Shopping cart is empty，please add to cart first</td></tr>
    </table>
<%}else{ %>
<%foreach(Shop.Model.BasketShop shop in basket.Shops){ %>
<%if (shop.Shop.id==0 && basket.Shops.Count==1){%><%}else{ %>
<div class="shop"><span><%if (shop.Shop.id==0){%>Import goods<%}else {%><%=Lang(shop.Shop.Name) %><%} %></span></div>
<%} %>
<div class="basketlist">
    <table align="center" cellpadding="0" cellspacing="0">
        <tr>
            <th>
                Product Name
            </th>
            <th style="width: 100px" >
                Market Price
            </th>
            <th style="width: 100px" >
                Purchase Price
            </th>
            <th style="width: 100px">
                Discount
            </th>
            <th style="width: 100px">
                QTY
            </th>
            <th style="width: 100px" >
                Subtotal
            </th>
            <th style="width: 100px" >
                Operate
            </th>
        </tr>
        <% 
            foreach (Shop.Model.Lebi_User_Product p in shop.Products)
            {
                Shop.Model.Lebi_Product model = GetProduct(p.Product_id);
                int levelcount=ProductLevelCount(model);
        %>
        <tr valign="middle">
            <td class="list">
                <table cellspacing="0" cellpadding="3">
                    <tr>
                        <td width="60" style="text-align:center">
                            <img src="<%=Image(model.ImageOriginal,50,50) %>" width="50" height="50" class="picb">
                        </td>
                        <td>
                            <a href="<%=URL("P_Product",model.id) %>" target="_blank"><%=Lang(model.Name) %></a><br />
                            Item No.：<%=model.Number %>
                            <%=Shop.Bussiness.EX_Product.ProPertyNameStr(model, CurrentLanguage.Code)%>
                            <%if (p.ProPerty134 !=""){ %><br /><%=p.ProPerty134 %><%} %>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="list" style="text-align: center">
                <%=FormatMoney(Shop.Bussiness.EX_Product.ProductMarketPrice(model)) %>
            </td>
            <td class="list" style="text-align: center">
                <%
                if(model.Type_id_ProductType==323 && model.Time_Expired > System.DateTime.Now)
                    Response.Write(Tag("积分")+":"+model.Price_Sale);
                else
                    Response.Write(FormatMoney(p.Product_Price));
                %>
            </td>
            <td class="list" style="text-align: center">
                <%=p.Discount==100?"-":p.Discount+"%" %>
            </td>
            <td class="list" style="text-align: center">
                <%if ((model.Type_id_ProductType == 321 || model.Type_id_ProductType == 322) && (System.DateTime.Now > model.Time_Expired))
                {
                    model.Count_Limit=0; 
                }
                %>
                <input type="button" <%if (p.count > 1){ %>onclick="UserProduct_Edit(<%=model.id %>,142,$('#BasketCount<%=model.id %>').val()/1-1,'edit',<%=model.Count_Limit %>,<%=levelcount %>)" class="qty-reduce"<%}else{ %> class="qty-reduce-gray"<%} %> value="" /><input name="BasketCount<%=model.id %>" id="BasketCount<%=model.id %>" type="text" value="<%=p.count %>" onkeyup="value=value.replace(/[^\d]/g,'');" onchange="UserProduct_Edit(<%=model.id %>,142,this.value,'edit',<%=model.Count_Limit %>,<%=levelcount %>)"; Basket="true" size="3" maxlength="5" class="qty-input" /><input type="button" onclick="UserProduct_Edit(<%=model.id %>,142,$('#BasketCount<%=model.id %>').val()/1+1,'edit',<%=model.Count_Limit %>,<%=levelcount %>)" value="" class="qty-add" />
            </td>
            <td class="list" style="text-align: center">
                <%=FormatMoney(p.Product_Price*p.count*p.Discount/100) %>
            </td>
            <td class="list" style="text-align: center">
                <a href="javascript:void(0)" onclick="UserProduct_Del(<%=p.Product_id %>,142);" class="btn btn-12"><s></s>Remove</a>
            </td>
        </tr>
        <%} %>  
        </table>
    <%if(shop.FreeProducts.Count>0){ %>
    <table align="center" cellpadding="0" cellspacing="0">
        <tr>
            <th>
                Free Gift
            </th>
            <th style="width: 100px">
                Market Price
            </th>
            <th style="width: 100px">
                QTY
            </th>
            <th>
            </th>
        </tr>
        <% 
                    foreach(Shop.Model.Lebi_User_Product p in shop.FreeProducts){
                        Shop.Model.Lebi_Product model = GetProduct(p.Product_id);
        %>
        <tr valign="middle">
            <td class="list">
                <table cellspacing="0" cellpadding="3">
                    <tr>
                        <td width="60" style="text-align:center">
                            <img src="<%=Image(model.ImageOriginal,50,50) %>" width="50" height="50" class="picb">
                        </td>
                        <td>
                            <a href="<%=URL("P_Product",model.id) %>" target="_blank"><%=Lang(model.Name) %></a><br />
                            Item No.：<%=model.Number %>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="list" style="text-align: center">
                <%=FormatMoney(model.Price_Market) %>
            </td>
            <td class="list" style="text-align: center">
                <%=p.count %>
            </td>
            <td >
                        
            </td>
        </tr>
        <%} %>
    </table>
    <%} %>
    <%if(shop.PromotionTypes.Count>0){ %>
    <div class="promotion">
    Promotions：<%
        foreach(Lebi_Promotion_Type pt in shop.PromotionTypes){ %>
        <%=shop.Shop.id>0?"["+Lang(shop.Shop.Name)+"]":"" %><%=Lang(pt.Name) %>&nbsp;&nbsp;
        <%} %>
    </div>
    <%} %>
    <%if (shop.Products.Count > 0 || shop.FreeProducts.Count > 0)
      {%>
    <div class="money">
        <%if (shop.Money_Market > 0){ %>Market Price：<span><%=FormatMoney(shop.Money_Market)%></span>&nbsp;&nbsp;<%} %>
        <%if (shop.Money_Cut>0){ %>Save：<span><%=FormatMoney(shop.Money_Cut)%></span>&nbsp;&nbsp;<%} %>
        Purchase Price：<span><%=FormatMoney(shop.Money_Product-shop.Money_Cut)%></span>&nbsp;&nbsp;
        <%if(shop.Money_Property>0){ %>
        Other expenses：<span><%=FormatMoney(shop.Money_Property)%></span>&nbsp;&nbsp;
        <%} %>
        <%if (shop.Money_Market - shop.Money_Product - shop.Money_Cut >0){ %>Save：<s><span><%=FormatMoney(shop.Money_Market - shop.Money_Product-shop.Money_Cut)%></span></s>&nbsp;&nbsp;<%} %>
        <%if(shop.Point_Buy>0){ %>
        Points Required：<span><%=shop.Point_Buy%></span>&nbsp;&nbsp;
        <%} %>
        <%if(shop.Point>0){ %>
        Earn points：<span><%=shop.Point%></span>&nbsp;&nbsp;
        <%} %>
        <%if (shop.Weight>0){ %>Total Weight：<span><%=shop.Weight%> KG</span><%} %>
    </div>
   <%} %>
    <%if(IsMutiCash==true){ %>
    <div class="basketbtn">
        <a href="javascript:void(0)" onclick="location.href='<%=URL("P_CheckOut",shop.Shop.id) %>'" class="btn btn-7"><s></s>Checkout</a>
    </div>
    <%} %>
<%} %>
<%if(IsMutiCash==false){ %>
<%if (basket.Shops.Count > 1){%>
    <div class="money">
        <%if (basket.Money_Market > 0){ %><p>Market Price：<span><%=FormatMoney(basket.Money_Market)%></span></p><%} %>
        <%if (basket.Money_Cut>0){ %><p>Save：<span><%=FormatMoney(basket.Money_Cut)%></span></p><%} %>
        <p>Purchase Price：<span><%=FormatMoney(basket.Money_Product-basket.Money_Cut)%></span></p>
        <%if(basket.Money_Property>0){ %>
        <p>Other expenses：<span><%=FormatMoney(basket.Money_Property)%></span></p>
        <%} %>
        <%if (basket.Money_Market - basket.Money_Product - basket.Money_Cut >0){ %><p>Save：<s><span><%=FormatMoney(basket.Money_Market - basket.Money_Product-basket.Money_Cut)%></span></s></p><%} %>
        <%if(basket.Point_Buy>0){ %>
        <p>Points Required：<span><%=basket.Point_Buy%></span></p>
        <%} %>
        <%if(basket.Point>0){ %>
        <p>Earn points：<span><%=basket.Point%></span></p>
        <%} %>
        <%if (basket.Weight>0){ %><p>Total Weight：<span><%=basket.Weight%> KG</span></p><%} %>
    </div>
<%} %>
<%} %>
<%if(basket.Money_Refund_VAT>0){ %>
    <div class="money">
        <%if(basket.Money_Refund>0){ %>
        <p>The total refund：<span><%=FormatMoney(basket.Money_Refund)%></span></p>
        <%} %>
        <%if(basket.Money_Refund>basket.OtherSite_Money_Refund && basket.OtherSite_Money_Refund>0){ %>
        <p>High Street Tax Credit：<span><%=FormatMoney(basket.OtherSite_Money_Refund)%></span></p>
        <%} %>
        <%if(basket.Money_Refund - basket.OtherSite_Money_Refund>0){ %>
        <p>This is expected to have more shopping your tax rebate：<span><%=FormatMoney(basket.Money_Refund - basket.OtherSite_Money_Refund)%></span></p>
        <%} %>
    </div>
<%} %>
<%if(basket.Money_Tax>0){ %>
    <div class="money">
        <p>Taxes：<span><%=FormatMoney(basket.Money_Tax)%></span></p>
    </div>
<%} %>
<div class="basketbtn">
    <a href="javascript:void(0)" onclick="javascript:history.back();" class="btn btn-11"><s></s>Continue Shopping</a>
    <a href="javascript:void(0)" onclick="UserProduct_Del('all',142);" class="btn btn-11"><s></s>Empty Shopping Cart</a>
    <%if(IsMutiCash==false){ %>
    <a href="<%=URL("P_CheckOut","") %>" class="btn btn-7"><s></s>Checkout</a>
    <%} %>
</div>
<%} %>
</div>
</div>
<script type="text/javascript">
    function UserBasket_Edit() {
        var postData = GetFormJsonData("Basket");
        var url = path+"/ajax/ajax_user.aspx?__Action=UserBasket_Edit";
        RequestAjax(url, postData, function () { MsgBoxClose("?", ""); });
    }
    function UserProduct_Edit(id, type, num,action,limit,levelcount) {
        limit=limit==undefined?0:limit;
        num=num==undefined?0:num;
        if(limit>0)
        {
            if(num>limit){
                $("BasketCount"+id).val(limit);
                return false;
            }
        }else{
            if (num < levelcount){
                $("BasketCount"+id).val(levelcount);
                return false;
            }
        }
        $("BasketCount"+id).val(num);
        if (action == undefined){action = "add";}
        var postData = { "pid": id, "type": type, "num": num };
        var url = path+"/ajax/ajax_user.aspx?__Action=UserProduct_Edit";
        RequestAjax(url, postData, function () { if (type == 142 && action == "add") { window.location = "BasketOK.aspx"; } else { MsgBoxClose("?", ""); } });
    }
    function UserProduct_Del(id, type) {
        var postData = { "pid": id, "type": type };
        var url = path+"/ajax/ajax_user.aspx?__Action=UserProduct_Del";
        RequestAjax(url, postData, function () { MsgBoxClose("?", ""); });
    }
</script>


</div>

<div class="footer">
    <%=Lang(SYS.FootHtml) %>
    <div class="copyright f11 footer_logos">
        <div class="footer_logos-list">
            <%Table="Lebi_FriendLink";Where="IsShow=1 and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc,id desc";PageSize=7;pageindex=1;RecordCount=B_Lebi_FriendLink.Counts(Where);int atjm_index=1;
List<Lebi_FriendLink> atjms = B_Lebi_FriendLink.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_FriendLink atjm in atjms){%>
            
                <% if (atjm.Logo != "" && atjm.IsPic == 1){ %><a href="<%=atjm.Url%>" target="_blank"><img src="<%=Image(atjm.Logo) %>" alt="<%=atjm.Name%>" /></a><%}else{%><a href="<%=atjm.Url%>" target="_blank"><%=atjm.Name%></a><%} %>     
           
            <%atjm_index++;}%>
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




<link rel="stylesheet" type="text/css" href="/Theme/system/js/sidebar/base.css" />
<script type="text/javascript" src="/Theme/system/js/sidebar/sidebar.js"></script>
<div class="mui-mbar-tabs">
	<div class="quick_link_mian">
		<div class="quick_links_panel">
			<div id="quick_links" class="quick_links">
				<li>
					<a href="javascript:void(0);" class="ico_account"><i class="i_ico_account"></i></a>
					<div class="ibar_login_box status_login">
						<div class="avatar_box">
							<p class="avatar_imgbox">
                                <%if(CurrentUser.Face.Trim()!=""){ %>
                                <img src="<%=CurrentUser.Face %>" />
                                <%}else{ %>
                                <img src="/Theme/system/js/sidebar/no-img_mid_.jpg" />
                                <%} %>
                            </p>
							<ul class="user_info">
								<li><%=Tag("用户名") %>：<%=Shop.Bussiness.EX_User.LoginStatus()?CurrentUser.UserName:Tag("未登录") %></li>
								<li><%=Tag("级别") %>：<%=Lang(CurrentUserLevel.Name) %></li>
							</ul>
						</div>
						<div class="login_btnbox">
                            <%if(Shop.Bussiness.EX_User.LoginStatus()){ %>
							<a href="<%=URL("P_UserOrders","") %>" class="login_order"><%=Tag("我的订单") %></a>
							<a href="<%=URL("P_UserLike","")%>" class="login_favorite"><%=Tag("我的收藏") %></a>
                            <%}else{ %>
                            <a href="<%=URL("P_Login","") %>" class="login_order"><%=Tag("登录") %></a>
							<a href="<%=URL("P_Register","")%>" class="login_favorite"><%=Tag("注册") %></a>
                            <%} %>
						</div>
						<i class="icon_arrow_white"></i>
					</div>
				</li>
				<li id="shopCart">
					<a href="<%=URL("P_Basket", "") %>" class="ico_basket" ><i class="i_ico_basket"></i><div class="span"><%=Tag("购物车") %></div><span class="cart_num"><%=Basket_Product_Count() %></span></a>
				</li>
				<li>
					<a class="ico_history"><i class="i_ico_history"></i></a>
					<div class="mp_tooltip"><%=Tag("我的足迹") %><i class="icon_arrow_right_black"></i></div>
				</li>
				<li>
					<a href="<%=URL("P_UserLike", "") %>" class="ico_like"><i class="i_ico_like"></i></a>
					<div class="mp_tooltip"><%=Tag("我的收藏") %><i class="icon_arrow_right_black"></i></div>
				</li>
			</div>
			<div class="quick_toggle">
				<li>
					<a href="<%=URL("P_Help","") %>" class="ico_service"><i class="i_ico_service"></i></a>
					<div class="mp_service" style="display:none;">
                        <div class="servicepannel">
                        <%Table="Lebi_ServicePanel_Group";Where="Supplier_id = 0 and ','+Language_ids+',' like '%,"+ CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_ServicePanel_Group.Counts(Where);int siderbargroup_index=1;
List<Lebi_ServicePanel_Group> siderbargroups = B_Lebi_ServicePanel_Group.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ServicePanel_Group siderbargroup in siderbargroups){%>
                            <ul class="group clearfix"><li>
                            <h2><%=siderbargroup.Name%></h2>
                            <ul class="group-user clearfix">
                            <%Table="Lebi_ServicePanel";Where="Supplier_id = 0 and ServicePanel_Group_id = "+siderbargroup.id+" and ','+Language_ids+',' like '%,"+ CurrentLanguage.id + ",%'";Order="Sort desc,id desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_ServicePanel.Counts(Where);int buser_index=1;
List<Lebi_ServicePanel> busers = B_Lebi_ServicePanel.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ServicePanel buser in busers){%>
                            <%
                                string url = GetServicePanelType(buser.ServicePanel_Type_id).Url;
                                url = url.Replace("{@uid}",buser.Account);
                                url = url.Replace("{@uname}",buser.Name);
                            %>
                            <li><a target="blank" href="<%=url%>"><img src="<%if (GetServicePanelType(buser.ServicePanel_Type_id).IsOnline == 1){
                                Response.Write(GetServicePanelType(buser.ServicePanel_Type_id).Code.Replace("{@uid}",buser.Account));
                            }else{
                                Response.Write(Image(GetServicePanelType(buser.ServicePanel_Type_id).Face));
                            }%>" border="0" align="absmiddle" />&nbsp;<%=buser.Name%></a></li>
                            <%buser_index++;}%>
                            </ul>
                            </li></ul>
                            <%siderbargroup_index++;}%>
                        </div>
                        <i class="icon_arrow_white"></i>

                    </div>
				</li>
				<li id="mp_qrcode">
					<a href="#none" class="ico_qrcode"><i class="i_ico_qrcode"></i></a>
					<div class="mp_qrcode" style="display:none;"><img src="<%=SYS.platform_weixin_image_qrcode%>" width="150" height="150" /><i class="icon_arrow_white"></i></div>
				</li>
				<li><a href="#top" class="return_top"><i class="top"></i></a></li>
			</div>
		</div>
		<div id="quick_links_pop" class="quick_links_pop hide"></div>
	</div>
</div>

<script type="text/javascript" src="/Theme/system/js/sidebar/parabola.js"></script>
<script type="text/javascript">
    $(".quick_links_panel li").mouseenter(function () {
        $(this).children(".mp_tooltip").animate({ left: -92, queue: true });
        $(this).children(".mp_tooltip").css("visibility", "visible");
        $(this).children(".ibar_login_box").css("display", "block");
    });
    $(".quick_links_panel li").mouseleave(function () {
        $(this).children(".mp_tooltip").css("visibility", "hidden");
        $(this).children(".mp_tooltip").animate({ left: -121, queue: true });
        $(this).children(".ibar_login_box").css("display", "none");
    });
    $(".quick_toggle li:first").mouseover(function () {
        $(".mp_service").show();
    });
    $(".quick_toggle li:first").mouseleave(function () {
        $(".mp_service").hide();
    });
    $(".quick_toggle li#mp_qrcode").mouseover(function () {
        $(".mp_qrcode").show();
    });
    $(".quick_toggle li#mp_qrcode").mouseleave(function () {
        $(".mp_qrcode").hide();
    });
</script>

</body>
</html><div style="width:100%;text-align:center;font-size:12px;color:#999">Powered by <a style="font-size:12px;color:#00497f" href="http://www.lebi.cn/support/license/?url=" target="_blank" title="LebiShop多语言网店系统">LebiShop</a> V<%=SYS.Version%>.<%=SYS.Version_Son%></div>
<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_CheckOut" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("wangdayu523@163.com_37",1,"tcn","P_CheckOut"); %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">


<title><%=ThemePageMeta("P_CheckOut","title")%></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" />
<meta name="keywords" content="<%=ThemePageMeta("P_CheckOut","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_CheckOut","description")%>" />
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
    var langpath = "/tw/";
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
        <li class="language_li"><a class="noclick"><span>網站語言：</span><s><%if (CurrentLanguage.ImageUrl!=""){%><img src="<%=Image(CurrentLanguage.ImageUrl) %>" /><%}%><%=CurrentLanguage.Name %></s></a><dl
            class="language_li_content">
            <%List<Shop.Model.Lebi_Language> TJlis=Languages();RecordCount=TJlis.Count;int TJli_index=1;
foreach (Shop.Model.Lebi_Language TJli in TJlis){%>
            <dd <%if (TJli_index==RecordCount){%>class="last" <%} %>>
                <a href="javascript:SetLanguage(<%=TJli.id%>,'<%=TJli.Code%>','<%=TJli.Path%>');"><%if (TJli.ImageUrl!=""){%><img src="<%=Image(TJli.ImageUrl) %>" /><%}%><%=TJli.Name%></a></dd>
            <%TJli_index++;}%>
        </dl>
        </li>
    </ul>
</div>
</li>
                <li>

<%if(SYS.IsMutiCurrencyShow=="0"){ %>
<div class="currency">
    <ul class="dropcurrency">
        <li class="currency_li"><a class="noclick"><span>幣種：</span><s><%=CurrentCurrency.Code %></s></a><dl
            class="currency_li_content">
            <%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int SIGi_index=1;
List<Lebi_Currency> SIGis = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency SIGi in SIGis){%>
            <dd <%if (SIGi_index==RecordCount){%>class="last" <%} %>>
                <a href="javascript:SetCurrency(<%=SIGi.id%>,'<%=SIGi.Code%>',<%=SIGi.ExchangeRate%>,'<%=SIGi.Msige%>','<%=SIGi.DecimalLength%>');"><%=SIGi.Code%></a></dd>
            <%SIGi_index++;}%>
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
           

<a href="/tw/"><img src="<%=Image(Lang(SYS.Logoimg)) %>" alt="<%=Lang(SYS.Name)%>" title="<%=Lang(SYS.Name)%>" /></a>
</h1>
        <div class="search">
            

<script type="text/javascript">
    $(function () {
        blurInput('#keyword', '<%if (Rstring("Keyword")!=""){ %><%=Rstring("Keyword")%><%}else{%><%Table="Lebi_Searchkey";Where="Type=1";Order="Sort desc,id desc";PageSize=1;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int LHpU_index=1;
List<Lebi_Searchkey> LHpUs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey LHpU in LHpUs){%><%=Lang(LHpU.Name)%><%LHpU_index++;}%><%} %>');
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
    <dt><span id="searchtype" typename="product">商品</span><em class="ico-jtb"></em></dt>
    <dd>
        <a typename="product" href="javascript:void(0)">商品</a>
        <%if (Shop.LebiAPI.Service.Instanse.Check("plugin_gongyingshang")){ %>
        <a typename="shop" href="javascript:void(0)">店鋪</a>
        <%}%>
    </dd>
</dl>
</div>
<input id="keyword" value="" type="text" name="keyword" onfocus="if (this.value != '') {this.value = '';}" />
<input type="button" value="搜索" class="button" />
</div>

            

<div class="searchkeyword">
<%Table="Lebi_Searchkey";Where="";Order="Sort desc,id desc";PageSize=5;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int sdXm_index=1;
List<Lebi_Searchkey> sdXms = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey sdXm in sdXms){%>
<%if (sdXm.Type==1){ %><a href="<%=URL("P_Search",""+Lang(sdXm.Name)+"") %>"><%}else{ %><a href="<%=sdXm.URL%>" target="_blank"><%} %><span><%=Lang(sdXm.Name)%></span></a>
<%sdXm_index++;}%>
</div>

        </div>
        <div class="toplink">
            <a href="<%=URL("P_UserCenter","") %>">
                <img src="/theme/newdefault/images/topIco1.png">我的賬號</a> <a href="<%=URL("P_Basket","") %>">
                    <img src="/theme/newdefault/images/topIco2.png">購物車</a>
        </div>
    </div>
</div>
  <div class="mainNav">
    <div class="mainNav-con">
      <div class="allnav">
        <h2 class="title">
          <a href="<%=URL("P_AllProductCategories", "")%>">全部商品分類</a><i class="title-icon"></i>
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
        

<%Table="Lebi_Page";Where="Node_id="+Node("HeadMenu").id+" and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int MwVY_index=1;
List<Lebi_Page> MwVYs = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page MwVY in MwVYs){%>
<a class="menu" href="<%=URL("","",MwVY.url)%>"><span><%=MwVY.Name%></span></a>
<%MwVY_index++;}%>

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
	<li class="over"><span>加入購物車</span></li>
	<li class="current"><span class="con">填寫訂單信息</span></li>
	<li class="over"><span class="con">成功提交訂單</span></li>
    <li class="last"><span>等待發貨</span></li>
</ul>
</div>


<script type="text/javascript">
    var BillFlag=<%=SYS.BillFlag %>;
    <%
    if(basket.Products.Count==0){ %>
    MsgBox(2, "購物車為空，請將您要購買的商品放入購物車", "<%=LanguagePath%>");
    <%
    } %>
</script>
<script src="<%=WebPath %>/theme/system/js/order.js" type="text/javascript"></script>
<div id="checkout">
    <div class="checkout">
        <div class="mt">
            <h2>
                收貨人信息</h2>
        </div>
        <div class="mc">
            <div id="checkout_address">
            </div>
        </div>
        <div class="mt">
            <h2>
                配送方式</h2>
        </div>
        <div class="mc">
            <div id="checkout_transport">
            </div>
        </div>
        <div class="mt">
            <h2>
                支付方式</h2>
        </div>
        <div class="mc">
            <div id="checkout_pay">
            </div>
        </div>
        <%if (SYS.BillFlag == "1")
      { %>
        <div class="mt">
            <h2>
                發票信息</h2>
        </div>
        <div class="mc">
            <div id="checkout_bill">
            </div>
        </div>
        <%} %>
        <div class="clear">
        </div>
    </div>
    <div id="orderinfo">
        <div class="mt">
            <strong>
                訂單信息</strong></div>
        <div class="mc">
            <%if (basket.Products.Count > 0)
          {%>
            <dl style="border-top: 0px solid #EDEDED;">
                <dt>
                    訂單清單</dt>
                <dd class="p-list">
                    <table width="100%" cellspacing="0" cellpadding="0">
                        <tbody>
                            <tr>
                                <th style="width: 100px">
                                    商品編號
                                </th>
                                <th>
                                    商品名稱
                                </th>
                                <th style="width: 100px">
                                    價格
                                </th>
                                <th style="width: 100px">
                                    折扣
                                </th>
                                <th style="width: 100px">
                                    數量
                                </th>
                                <th style="width: 100px">
                                    小計
                                </th>
                            </tr>
                            <% 
            foreach (Shop.Model.Lebi_User_Product p in basket.Products)
            {
                Shop.Model.Lebi_Product model = GetProduct(p.Product_id);

                            %>
                            <tr>
                                <td>
                                    <%=model.Number%>
                                </td>
                                <td style="text-align: left">
                                    <a href="<%=URL("P_Product",model.id) %>" target="_blank">
                                        <%=Lang(model.Name)%></a> <span>
                                            <%=Shop.Bussiness.EX_Product.ProPertyNameStr(model, CurrentLanguage.Code)%>
                                            <%if (p.ProPerty134 !=""){ %><br /><%=p.ProPerty134 %><%} %></span>
                                </td>
                                <td>
                                    <span class="ftx04">
                                        <%
                                        if(model.Type_id_ProductType==323 && model.Time_Expired > System.DateTime.Now)
                                            Response.Write(Tag("积分")+":"+model.Price_Sale);
                                        else
                                            Response.Write(FormatMoney(p.Product_Price));
                                        %>
                                    </span>
                                </td>
                                <td>
                                    <%=p.Discount==100?"-":p.Discount+"%" %>
                                </td>
                                <td>
                                    <%=p.count%>
                                </td>
                                <td>
                                    <%
                                        if(model.Type_id_ProductType==323 && model.Time_Expired > System.DateTime.Now)
                                            Response.Write(Tag("积分")+":"+model.Price_Sale* p.count);
                                        else
                                            Response.Write(FormatMoney(p.Product_Price * p.count * p.Discount / 100));
                                    %>
                                </td>
                            </tr>
                            <%} %>
                        </tbody>
                    </table>
                </dd>
            </dl>
            <%} %>
            <%if (basket.FreeProducts.Count > 0)
          {%>
            <dl style="border-top: 0px solid #EDEDED;">
                <dt>
                    贈品清單</dt>
                <dd class="p-list">
                    <table width="100%" cellspacing="0" cellpadding="0">
                        <tbody>
                            <tr>
                                <th style="width: 100px">
                                    商品編號
                                </th>
                                <th>
                                    商品名稱
                                </th>
                                <th style="width: 100px">
                                    數量
                                </th>
                            </tr>
                            <% 
            foreach (Shop.Model.Lebi_User_Product p in basket.FreeProducts)
            {
                Shop.Model.Lebi_Product model = GetProduct(p.Product_id);
                            %>
                            <tr>
                                <td>
                                    <%=model.Number%>
                                </td>
                                <td style="text-align: left">
                                    <a href="<%=URL("P_Product",model.id) %>" target="_blank">
                                        <%=Lang(model.Name)%></a>
                                </td>
                                <td>
                                    <%=p.count%>
                                </td>
                            </tr>
                            <%} %>
                        </tbody>
                    </table>
                </dd>
            </dl>
            <%} %>
        </div>
        <div class="ordertips">
            <div class="ordertotal">
                <%if (basket.Money_Market >0){ %>市場價：<font color="#ff3333"><%=FormatMoney(basket.Money_Market)%></font><%} %>
                <%if(basket.Point_Buy>0){ %>
                &nbsp;&nbsp;&nbsp;&nbsp;所需積分：<font color="#ff3333"><%=basket.Point_Buy%></font>
                <%} %>
                <%if(basket.Point>0){ %>
                &nbsp;&nbsp;&nbsp;&nbsp;獲得積分：<font color="#ff3333"><%=basket.Point%></font>
                <%} %>
                <%if(basket.Weight>0){ %>
                &nbsp;&nbsp;&nbsp;&nbsp;總重量：<font color="#ff3333"><%=basket.Weight%></font> KG
                <%} %>
                <%if(basket.Volume>0){ %>
                &nbsp;&nbsp;&nbsp;&nbsp;體積：<font color="#ff3333"><%=(basket.Volume/1000000).ToString("0.00")%></font> m&sup3;
                <%} %>
            </div>
            <%if (basket.PromotionTypes.Count > 0)
              { %>
            <div class="orderdiscount">
                優惠促銷：
                <%
                foreach(BasketShop shop in basket.Shops){ 
                foreach(Lebi_Promotion_Type pt in shop.PromotionTypes){ %>
                <%=shop.Shop.id>0?"["+shop.Shop.Company+"]":"" %><%=Lang(pt.Name) %>&nbsp;&nbsp;
                <%}} %>
            </div>
            <%} %>
        </div>
<div class="otherpay">
    <%if (cards.Count > 0)
      { %>
    <div class="item">
        <input type="text" id="money_card312" value="" style="display:none"/>
        <div class="title"><input type="checkbox" name="usermoneytype" value="1" order="true"/>使用代金券</div>
        <div class="content">
            <div class="tablebox">
            <table class="cardlist" width="100%" cellspacing="0" cellpadding="0" id="card312list">
                <tr>
                    <th style="width: 100px">
                        編號
                    </th>
                    <th style="width: 100px">
                        名稱
                    </th>
                    <th style="width: 100px">
                        金額
                    </th>
                    <th>
                        使用條件
                    </th>
                    <th style="width: 100px">
                        有效期
                    </th>
                </tr>
                <%foreach (Shop.Model.Lebi_Card c in cards)
                  { %>
                <tr>
                    <td class="code"><input type="checkbox" value="<%=c.id %>" <%=Shop.Bussiness.Basket.CheckCard(basket, c)?"":"disabled" %> money="<%=c.Money %>" name="pay312" id="pay312_<%=c.id %>" class="check" order="true" rflag="<%=c.IsCanOtherUse %>" onclick="select312(<%=c.id %>);"/><%=c.Code %></td>
                    <td class="code"><%=cardname(c.CardOrder_id) %></td>
                    <td class="money"><%=FormatMoney(c.Money) %></td>
                    <td class="des"><%=cardinfo(c)%><input type="hidden" name="cardmoney" value="<%=c.Money_Last %>" /></td>
                    <td class="time"><%=c.Time_End.ToString("yyyy-MM-dd")%></td>
                </tr>
                <%} %>
            </table>
            </div>
        </div>
    </div>
    <%} %>
    <div class="item">
        <input type="text" id="money_card311" value="" style="display:none"/>
        <div class="title"><input type="checkbox" name="usermoneytype" value="2" order="true"/>使用禮品卡</div>
        <div class="content">
            編號：<input type="text" id="moneycardcode" name="moneycardcode" order="true" value="" maxlength="20" size="15" class="input" /> 
            密碼：<input type="text" id="moneycardpwd" name="moneycardpwd" order="true" value="" maxlength="20" size="10" class="input" />
            <a href="javascript:void(0)" onclick="checkmoneycard();" class="btn btn-11"><s></s>查詢</a>
            <span id="moneycardstatus"></span>
            <div class="moneycardresult" >
                <div class="tablebox">
                <table class="cardlist" cellspacing="0" cellpadding="0" id="card311list">
                    <tr>
                        <th style="width: 100px">
                            編號
                        </th>
                        <th style="width: 100px">
                            名稱
                        </th>
                        <th style="width: 100px">
                            金額
                        </th>
                        <th style="width: 100px">
                            餘額
                        </th>
                        <th style="width: 100px">
                            使用
                        </th>
                        <th style="width: 100px">
                            有效期
                        </th>
                    </tr>
                    <%foreach (Shop.Model.Lebi_Card c in moneycards)
                    { %>
                    <tr>
                    <td class="code"><input type="checkbox" id="pay311_<%=c.id %>" value="<%=c.id %>" money="<%=c.Money_Last %>" order="true" name="pay311" class="check" onclick="select311();"/><%=c.Code %></td>
                    <td class="name"><%=cardname(c.CardOrder_id) %></td>
                    <td class="money"><%=FormatMoney(c.Money) %></td>
                    <td class="money_last"><%=FormatMoney(c.Money_Last) %></td>
                    <td class="use">
                        <span class="show_moneyuse"></span>
                        
                        <input type="hidden" name="cardmoney" value="<%=c.Money_Last %>" /> 
                        
                        <input type="hidden" name="Money_Card311" order="true" value="0" />
                    </td>
                    <td class="time"><%=c.Time_End.ToString("yyyy-MM-dd")%></td>
                    </tr>
                   <%} %>
                   <tr id="moneycardresult" style="display:none;" >
                    <td class="code"></td>
                    <td class="name"></td>
                    <td class="money"></td>
                    <td class="money_last"></td>
                    <td class="use">
                        <span class="show_moneyuse"></span>
                        
                        <input type="hidden" name="cardmoney" value="" /> 
                        
                        <input type="hidden" name="Money_Card311" order="true" value="0" />
                     </td>
                    <td class="time"></td>
                    </tr>
                </table>
                </div>
            </div>
        </div>
    </div>
    <%if (CurrentUser.Money > 0){ %>
    <div class="item">
        <div class="title"><input type="checkbox" value="3" id="payusermoney" name="usermoneytype" onclick="selectusermongy();" order="true"/>使用餘額</div>
        <div class="content">
            <table class="cardlist" cellspacing="0" cellpadding="0" id="usermoneyitem">
                <tr>
                    <td class="usermoney">
                    餘額：<%=FormatMoney(CurrentUser.Money) %>&nbsp;&nbsp;使用：<input type="hidden" id="Money_canused" name="Money_canused" value="<%=CurrentUser.Money%>" /><input type="hidden" id="CurrentExchangeRate" name="CurrentExchangeRate" value="<%=CurrentCurrency.ExchangeRate %>" /><span class="show_moneyuse"><%=FormatMoney(0) %></span><input type="hidden" name="Money_UserCut" order="true" value="0" />&nbsp;&nbsp;&nbsp;&nbsp;支付密碼：<%if (CurrentUser.Pay_Password!=""){ %><input type="password" id="Pay_Password" name="Pay_Password" size="20" value="" order="true" class="input" /> <a href="<%=URL("P_UserQuestion","1")%>" target="_blank">忘記密碼</a><%}else{%><a href="<%=URL("P_UserChangePassword","")%>" target="_blank">設置支付密碼</a><%}%>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <%} %>
</div>
        <div class="mt">
            <h2>訂單留言</h2>
        </div>
        <div class="mc">
            <input type="text" id="remark" name="remark" order="true" value="" maxlength="200" style="width:100%" class="input" />
        </div>
        <div class="total" id="orderform">
        </div>
    </div>
    <%if (ProPerty135.Count > 0){ %>
    <div class="checkout orderproperty">
    <div class="mt">
        <h2>訂單調查</h2>
    </div>
    <div class="mc">
        <table width="100%" cellspacing="0" cellpadding="0">
        <%foreach (Lebi_ProPerty p in ProPerty135){%>
         <tr>
            <th><%=Lang(p.Name) %><input type="hidden" name="Propertyid" value="<%=p.id%>" order="true" /></th>
         </tr>
         <tr>
            <td>
            <%
            List<Lebi_ProPerty> ProPerty135list = B_Lebi_ProPerty.GetList("parentid = "+ p.id +"", "Sort desc");
            if (ProPerty135list.Count > 0){
            foreach (Lebi_ProPerty pl in ProPerty135list)
            {
                %>
                <label><input type="radio" name="Property135<%=p.id%>" value="<%=pl.id%>" order="true" /><%=Lang(pl.Name) %></label>&nbsp;&nbsp;
                <%}}else{ %>
                <input type="text" name="Property135<%=p.id%>" value="" class="input" order="true" />
            <%
            }
            %>
            </td>
        </tr>
        <%
        }
        %>
        </table>
    </div>
    </div>
    <%} %>
    <div class="ordersubmit">
        <a href="<%=URL("P_Basket","") %>" class="btn btn-10"><s></s>
            返回修改</a><a href="javascript:void(0);" onclick="OrderSubmit();" class="btn btn-6"><s></s>立即提交</a>
    </div>
    <div id="overlay" class="overlay"></div>
</div>
<script type="text/javascript">
    $(function () {
        LoadPage("<%=WebPath%>/inc/CheckOut_Address.aspx?sid=<%=sid %>", "checkout_address");
        if (BillFlag == 1)
            LoadPage("<%=WebPath %>/inc/CheckOut_Bill.aspx?sid=<%=sid %>", "checkout_bill");
    });
    function OrderSubmit() {
        //if (!confirm("確認提交嗎？"))
        //    return false;
        //$("#overlay").show();
        var postData = GetFormJsonData("order");
        var url = path+"/ajax/ajax_order.aspx?__Action=order_save&sid=<%=sid %>";
        RequestAjax(url, postData, function (res) { MsgBox(1, "正在提交……", "<%=URL("P_Cashier","")%>?order_id=" + res.id +"") });
    }
    $(function () {
        $(".otherpay .item .title").each(function (i) {
            $(this).click(function () {
                var che = $(this).children("input");
                var t=che.val();
                if (che.is(":checked")) {
                    $(this).next().show();
                } else {
                    $(this).next().hide();
                    if(t==1){
                        $("input[type='checkbox'][name='pay312']").attr("checked",false);
                        select312();
                    }
                    if(t==2){
                        $("input[type='checkbox'][name='pay311']").attr("checked",false);
                        select311();
                    }
                    if(t==3){
                        selectusermongy();
                    }
                }
            });
        });
    });
    function select312(id) {
         
         if(id!=undefined)
         {
            var flag=$("#pay312_"+id).attr('rflag');
            var check=$("#pay312_"+id).is(":checked");
            if(flag==1)
            {
                $("input[type='checkbox'][name='pay312'][rflag='0']").attr("checked",false);
            }else{
                $("input[type='checkbox'][name='pay312']").attr("checked",false);
                if(check)
                    $("#pay312_"+id).attr("checked",true);
            }
         }
         SetMoneyCardAndUserMoney();
    }
    function select311() {
        SetMoneyCardAndUserMoney();
    }
    function selectusermongy() {
        SetMoneyCardAndUserMoney();
    }
    function checkmoneycard()
    {
        var moneycardcode=$("#moneycardcode").val();
        var moneycardpwd=$("#moneycardpwd").val();
        var postdata={"moneycardcode":moneycardcode,"moneycardpwd":moneycardpwd};
        var url=path+"/ajax/ajax_order.aspx?__Action=MoneyCardCheack&sid=<%=sid %>";
        $.ajax({
            type: "POST",
            url: url,
            data: postdata,
            dataType: 'json',
            success: function (res) {
                if (res.msg == "OK") {
                    if ($("#pay311_"+res.id)[0] == undefined){
                    $("#moneycardstatus").html('')
                    $("#moneycardresult").show();
                    $("#moneycardresult .name").html(res.name);
                    $("#moneycardresult .code").html('<input type="checkbox" value="'+res.id+'" money="'+res.money_lastvalue+'" name="pay311" order="true" class="check" onclick="select311();"/>'+res.code);
                    $("#moneycardresult .money").html(res.money);
                    $("#moneycardresult .money_last").html(res.money_last);
                    $("#moneycardresult .use input[name='cardmoney']").val(res.money_lastvalue);
                    $("#moneycardresult .time").html(res.timeend);
                    }
                }
                else {
                    $("#moneycardstatus").html(res.msg);
                    $("#moneycardresult").hide();
                    return false;
                }
            }
        });
    }
</script>



</div>

<div class="footer">
    <%=Lang(SYS.FootHtml) %>
    <div class="copyright f11 footer_logos">
        <div class="footer_logos-list">
            <%Table="Lebi_FriendLink";Where="IsShow=1 and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc,id desc";PageSize=7;pageindex=1;RecordCount=B_Lebi_FriendLink.Counts(Where);int mhrk_index=1;
List<Lebi_FriendLink> mhrks = B_Lebi_FriendLink.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_FriendLink mhrk in mhrks){%>
            
                <% if (mhrk.Logo != "" && mhrk.IsPic == 1){ %><a href="<%=mhrk.Url%>" target="_blank"><img src="<%=Image(mhrk.Logo) %>" alt="<%=mhrk.Name%>" /></a><%}else{%><a href="<%=mhrk.Url%>" target="_blank"><%=mhrk.Name%></a><%} %>     
           
            <%mhrk_index++;}%>
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
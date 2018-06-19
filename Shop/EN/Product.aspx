<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_Product" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("wangdayu523@163.com_37",1,"EN","P_Product"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>


<title><%=ThemePageMeta("P_Product","title")%></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" />
<meta name="keywords" content="<%=ThemePageMeta("P_Product","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_Product","description")%>" />
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
            <%List<Shop.Model.Lebi_Language> iADvs=Languages();RecordCount=iADvs.Count;int iADv_index=1;
foreach (Shop.Model.Lebi_Language iADv in iADvs){%>
            <dd <%if (iADv_index==RecordCount){%>class="last" <%} %>>
                <a href="javascript:SetLanguage(<%=iADv.id%>,'<%=iADv.Code%>','<%=iADv.Path%>');"><%if (iADv.ImageUrl!=""){%><img src="<%=Image(iADv.ImageUrl) %>" /><%}%><%=iADv.Name%></a></dd>
            <%iADv_index++;}%>
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
            <%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int HuXx_index=1;
List<Lebi_Currency> HuXxs = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency HuXx in HuXxs){%>
            <dd <%if (HuXx_index==RecordCount){%>class="last" <%} %>>
                <a href="javascript:SetCurrency(<%=HuXx.id%>,'<%=HuXx.Code%>',<%=HuXx.ExchangeRate%>,'<%=HuXx.Msige%>','<%=HuXx.DecimalLength%>');"><%=HuXx.Code%></a></dd>
            <%HuXx_index++;}%>
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
        blurInput('#keyword', '<%if (Rstring("Keyword")!=""){ %><%=Rstring("Keyword")%><%}else{%><%Table="Lebi_Searchkey";Where="Type=1";Order="Sort desc,id desc";PageSize=1;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int Ciip_index=1;
List<Lebi_Searchkey> Ciips = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey Ciip in Ciips){%><%=Lang(Ciip.Name)%><%Ciip_index++;}%><%} %>');
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
<%Table="Lebi_Searchkey";Where="";Order="Sort desc,id desc";PageSize=5;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int JfAz_index=1;
List<Lebi_Searchkey> JfAzs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey JfAz in JfAzs){%>
<%if (JfAz.Type==1){ %><a href="<%=URL("P_Search",""+Lang(JfAz.Name)+"") %>"><%}else{ %><a href="<%=JfAz.URL%>" target="_blank"><%} %><span><%=Lang(JfAz.Name)%></span></a>
<%JfAz_index++;}%>
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
        

<%Table="Lebi_Page";Where="Node_id="+Node("HeadMenu").id+" and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int CyLc_index=1;
List<Lebi_Page> CyLcs = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page CyLc in CyLcs){%>
<a class="menu" href="<%=URL("","",CyLc.url)%>"><span><%=CyLc.Name%></span></a>
<%CyLc_index++;}%>

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
<div class="viewhistory">
    <div class="mt">
        <h2>History</h2>
    </div>
    <div class="mc clearfix" id="viewhistory">
    </div>
</div>
</div>
<script type="text/javascript">LoadPage(path + '/inc/viewhistory.aspx', 'viewhistory');</script>



<div class="mbox clearfix">
<div class="newstop">
<div class="mt">
    <h2>Store News</h2>
</div>
<div class="mc clearfix">
    <ul class="text">
        <%Table="Lebi_Page";Where="Node_id="+Node("News").id+" and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Time_Add desc,id desc";PageSize=5;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int hkYC_index=1;
List<Lebi_Page> hkYCs = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page hkYC in hkYCs){%>
        <li><a href="<%if (hkYC.url == ""){Response.Write(URL("P_NewsDetails",hkYC.id));}else{Response.Write(hkYC.url);} %>" title="<%=hkYC.Name%>"><em><%=hkYC.Time_Add.ToString("MM-dd") %></em><span style="color:<%=hkYC.NameColor%>"><%=hkYC.Name%></span></a></li>
        <%hkYC_index++;}%>
    </ul>
</div>
</div>
</div>


    </div>
    <div class="bodymain clearfix">
        
<div class="nbbox">
<div class="productdetail">
<div class="image left">


<script type="text/javascript" src="/Theme/system/js/jquery.jqzoom.js"></script>
<link rel="stylesheet" type="text/css" href="/Theme/system/js/lightbox/lightbox.min.css" />
<script type="text/JavaScript">
    $(document).ready(function () {
        var liw = 0;var pw = $(".listimage .piclist").width();
        $(".list-h li").each(function () {liw += $(this).width() + 6;})
        $(".list-h").width(liw + "px");
        $("#PicList img").bind("mouseover", function () {var src = $(this).attr("imghead");var jqimg = $(this).attr("imghead");$("#jqzoom img").attr("src", src);$("#jqzoom img").attr("jqimg", jqimg);$(this).attr("class", "current");}).bind("mouseout", function () {$(this).attr("class", "");});
        $(".jqzoom").jqueryzoom({xzoom: 300,yzoom: 300,offset: 10,position: "right",preload: 1,lens: 1});
        $(".pic_next").click(function () {if ($(".list-h").is(":animated")) {$(".list-h").stop(true, true);}ml = parseInt($(".list-h").css("left"));r = liw - (pw - ml);if (r < pw) {s = r;} else {s = pw;}$(".list-h").animate({ left: ml - s + "px" }, "slow");})
        $(".pic_prev").click(function () {if ($(".list-h").is(":animated")) {$(".list-h").stop(true, true);}ml = parseInt($(".list-h").css("left"));if (ml > -pw) {s = ml;} else {s = -pw;}$(".list-h").animate({ left: ml - s + "px" }, "slow");})
    })
</script>
<div class="bigimage jqzoom clearfix" id="jqzoom">
    <img jqimg="<%=Image(product.ImageOriginal) %>" src="<%=Image(product.ImageOriginal) %>" name="prodView" id="Img1" />
</div>
<div class="clear"></div>
<div class="listimage">
	<div class="pic_prev"></div>
    <div id="PicList" class="piclist">
        <div class="piclistbox">
        <ul class="list-h">
            <li><a href="<%=Image(product.ImageOriginal)%>" data-lightbox="image"><img src="<%=Image(product.ImageOriginal,"small") %>" imghead="<%=Image(product.ImageOriginal,"big") %>"/></a></li>
            <% 
            foreach(LBimage image in images){
            %>
            <li><a href="<%=Image(image.original) %>" data-lightbox="image"><img src="<%=Image(image.original,"small") %>" imghead="<%=Image(image.original,"big") %>"></a></li>
            <%} %>
        </ul>
        </div>
    </div>
	<div class="pic_next"></div>
</div>
<script type="text/javascript" src="/Theme/system/js/lightbox/lightbox.min.js"></script>

<div class="jiathis-share">

<div class="jiathis_style">
	<a class="jiathis_button_email"></a>
	<a class="jiathis_button_fb"></a>
	<a class="jiathis_button_twitter"></a>
	<a class="jiathis_button_googleplus"></a>
	<a class="jiathis_button_stumbleupon"></a>
	<a class="jiathis_button_gmail"></a>
	<a class="jiathis_button_linkedin"></a>
	<a class="jiathis_button_pinterest"></a>
	<a class="jiathis_button_tumblr"></a>
	<a href="http://www.jiathis.com/share" class="jiathis jiathis_txt jtico jtico_jiathis" target="_blank"></a>
</div>
<script type="text/javascript" src="http://v3.jiathis.com/code/jia.js" charset="utf-8"></script>

</div>
</div>
<div class="con left">
                        


<div id="productinfo"></div>
<script type="text/javascript">
    LoadPage(path+'/inc/product_info.aspx?id=<%=product.id %>','productinfo');
</script>

</div>
<div class="clear"></div>
</div>
<div class="nbbox">


<script type="text/javascript">
    $(document).ready(function () {
        <%if (CurrentLanguage.IsLazyLoad==1){ %>$("img.contentlazy").lazyload({ placeholder: "/Theme/system/images/lazy.gif", effect: "fadeIn" });<%} %>
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
        RequestAjax(url, postData, function () { MsgBox(1, "Send successful", "?"); $("#Content").val(""); getasklist(); });
    }
    function getasklist() {
        var url = path + "/inc/product_ask.aspx?id=<%=product.id %>&product_id=<%=product.Product_id %>&page=<%=Shop.Tools.RequestTool.RequestInt("page", 1) %>";
        LoadPage(url, 'asklist');
    }
    function getcommentlist() {
        var url = path + "/inc/product_comment.aspx?id=<%=product.id %>&product_id=<%=product.Product_id %>&page=<%=Shop.Tools.RequestTool.RequestInt("page", 1) %>";
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
            Details</span></a></li>
        <li><a href="javascript:void(0);"><span>
            Reviews</span></a></li>
        <li><a href="javascript:void(0);"><span>
            Comment</span></a></li>
        <li><a href="javascript:void(0);"><span>
            Related Products</span></a></li>
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
                        <a href="javascript:void(0)" onclick="ask();" class="btn btn-11"><s></s>Send</a>
                    </td>
                </tr>
            </tbody>
        </table>
        <%}else{%>
        <div class="mes">You are not logged in. Please log in to consult.</div>
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
</div>

<div class="footer">
    <%=Lang(SYS.FootHtml) %>
    <div class="copyright f11 footer_logos">
        <div class="footer_logos-list">
            <%Table="Lebi_FriendLink";Where="IsShow=1 and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc,id desc";PageSize=7;pageindex=1;RecordCount=B_Lebi_FriendLink.Counts(Where);int vvfy_index=1;
List<Lebi_FriendLink> vvfys = B_Lebi_FriendLink.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_FriendLink vvfy in vvfys){%>
            
                <% if (vvfy.Logo != "" && vvfy.IsPic == 1){ %><a href="<%=vvfy.Url%>" target="_blank"><img src="<%=Image(vvfy.Logo) %>" alt="<%=vvfy.Name%>" /></a><%}else{%><a href="<%=vvfy.Url%>" target="_blank"><%=vvfy.Name%></a><%} %>     
           
            <%vvfy_index++;}%>
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
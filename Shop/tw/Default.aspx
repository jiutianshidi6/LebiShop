<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_Index" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("wangdayu523@163.com_37",1,"tcn","P_Index"); %>

<!DOCTYPE html>
<html>
<head id="Head1">
    

<title><%=ThemePageMeta("P_Index","title")%></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" />
<meta name="keywords" content="<%=ThemePageMeta("P_Index","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_Index","description")%>" />
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
            <%List<Shop.Model.Lebi_Language> EEnUs=Languages();RecordCount=EEnUs.Count;int EEnU_index=1;
foreach (Shop.Model.Lebi_Language EEnU in EEnUs){%>
            <dd <%if (EEnU_index==RecordCount){%>class="last" <%} %>>
                <a href="javascript:SetLanguage(<%=EEnU.id%>,'<%=EEnU.Code%>','<%=EEnU.Path%>');"><%if (EEnU.ImageUrl!=""){%><img src="<%=Image(EEnU.ImageUrl) %>" /><%}%><%=EEnU.Name%></a></dd>
            <%EEnU_index++;}%>
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
            <%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int DLPy_index=1;
List<Lebi_Currency> DLPys = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency DLPy in DLPys){%>
            <dd <%if (DLPy_index==RecordCount){%>class="last" <%} %>>
                <a href="javascript:SetCurrency(<%=DLPy.id%>,'<%=DLPy.Code%>',<%=DLPy.ExchangeRate%>,'<%=DLPy.Msige%>','<%=DLPy.DecimalLength%>');"><%=DLPy.Code%></a></dd>
            <%DLPy_index++;}%>
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
        blurInput('#keyword', '<%if (Rstring("Keyword")!=""){ %><%=Rstring("Keyword")%><%}else{%><%Table="Lebi_Searchkey";Where="Type=1";Order="Sort desc,id desc";PageSize=1;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int HiKJ_index=1;
List<Lebi_Searchkey> HiKJs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey HiKJ in HiKJs){%><%=Lang(HiKJ.Name)%><%HiKJ_index++;}%><%} %>');
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
<%Table="Lebi_Searchkey";Where="";Order="Sort desc,id desc";PageSize=5;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int ejlG_index=1;
List<Lebi_Searchkey> ejlGs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey ejlG in ejlGs){%>
<%if (ejlG.Type==1){ %><a href="<%=URL("P_Search",""+Lang(ejlG.Name)+"") %>"><%}else{ %><a href="<%=ejlG.URL%>" target="_blank"><%} %><span><%=Lang(ejlG.Name)%></span></a>
<%ejlG_index++;}%>
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
        

<%Table="Lebi_Page";Where="Node_id="+Node("HeadMenu").id+" and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int oBHc_index=1;
List<Lebi_Page> oBHcs = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page oBHc in oBHcs){%>
<a class="menu" href="<%=URL("","",oBHc.url)%>"><span><%=oBHc.Name%></span></a>
<%oBHc_index++;}%>

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

<script type="text/javascript">
    $(".allnav-show").attr("class","allnav-show-block");
</script>
<div class="ind-banner">
    <div class="bd">
        <% Advertisement("Index1"); %>
    </div>
    <div class="hd" style="z-index:0;"><ul></ul></div>
    <span class="prev"></span>
    <span class="next"></span>
</div>
<script type="text/javascript">
	/* 控制左右按钮显示 */
	jQuery(".ind-banner").hover(function(){ jQuery(this).find(".prev,.next").stop(true,true).fadeTo("show",0.5) },function(){ jQuery(this).find(".prev,.next").fadeOut() });
	/* 调用SuperSlide */
	jQuery(".ind-banner").slide({ titCell:".hd ul", mainCell:".bd ul", effect:"fold",  autoPlay:true, autoPage:true, trigger:"click",
		startFun:function(i){
			var curLi = jQuery(".ind-banner .bd li").eq(i); /* 当前大图的li */
			if( !!curLi.attr("_src") ){
				curLi.css("background-image",curLi.attr("_src")).removeAttr("_src") /* 将_src地址赋予li背景，然后删除_src */
			}
		}
	});
</script>
<div class="main-con">
	<div class="ind-left">
        <h2 class="title">熱銷商品</h2>
<%Table="Lebi_Product";Where=""+ProductWhere+" and Type_id_ProductType = 320";Order="Count_Views desc,id desc";PageSize=3;pageindex=1;RecordCount=B_Lebi_Product.Counts(Where);int producttop_index=1;
List<Lebi_Product> producttops = B_Lebi_Product.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Product producttop in producttops){%>
        <div class="ind-left-hot">
        	<a href="<%=URL("P_Product",producttop.id)%>"><img src="<%=Image(producttop,"medium") %>" /></a>
            <p class="shopname"><a href="<%=URL("P_Product",producttop.id)%>"><%=Lang(producttop.Name)%></a></p>
            <span class="shopprice"><%=FormatMoney(ProductPrice(producttop))%></span>
   	  </div>
<%producttop_index++;}%>
        <div class="ind-left-ad"><% Advertisement("IndexLeft01"); %></div>
        <h2 class="title">銷售排行榜</h2>
        <div class="tuijian">
<%Table="Lebi_Product";Where=""+ProductWhere+" and Type_id_ProductType = 320 and "+ TagWhere(34) +"";Order="Sort desc,id desc";PageSize=4;pageindex=1;RecordCount=B_Lebi_Product.Counts(Where);int tab_tag_pro_index=1;
List<Lebi_Product> tab_tag_pros = B_Lebi_Product.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Product tab_tag_pro in tab_tag_pros){%>
        	<div class="tuijian-list">
            	<div class="img"><a href="<%=URL("P_Product",tab_tag_pro.id) %>"><img src="<%=Image(tab_tag_pro,"medium") %>"></a></div>
                <p class="shopname"><a href="<%=URL("P_Product",tab_tag_pro.id) %>"><%=Lang(tab_tag_pro.Name) %></a></p>
            	<span class="shopprice"><%=FormatMoney(ProductPrice(tab_tag_pro)) %></span>
            </div>
<%tab_tag_pro_index++;}%>
        </div>
    </div>
    <div class="ind-right">
    	<div class="title">
        	<h2>精品推薦</h2>
        </div>
      <div class="ind-right-hot">
            <ul class="clearfix">
               <% Advertisement("IndexRightHot"); %>
            </ul>
        </div>
        <script type="text/javascript">
			$(document).ready(function(){	
				$(".ind-right-hot ul li .rsp").hide();	
				$(".ind-right-hot	 ul li").hover(function(){
					$(this).find(".rsp").stop().fadeTo(500,0.5)
					$(this).find(".text").stop().animate({left:'0'}, {duration: 500})
				},
				function(){
					$(this).find(".rsp").stop().fadeTo(500,0)
					$(this).find(".text").stop().animate({left:'300'}, {duration: "fast"})
					$(this).find(".text").animate({left:'-300'}, {duration: 0})
				});
			});
			</script>

<%Table="Lebi_Pro_Type";Where=""+ProductCategoryWhere+" and Parentid = 0 and IsShow = 1 and IsIndexShow = 1";Order="Sort desc,id desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Pro_Type.Counts(Where);int category_index=1;
List<Lebi_Pro_Type> categorys = B_Lebi_Pro_Type.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Pro_Type category in categorys){%>
         <div class="title">
        	<h2><%=Lang(category.Name) %></h2>
            <div class="more-key"> 
 	<%Table="Lebi_Pro_Type";Where=""+ProductCategoryWhere+" and Parentid = "+category.id+" and IsShow = 1 and IsIndexShow = 1";Order="Sort desc,id desc";PageSize=5;pageindex=1;RecordCount=B_Lebi_Pro_Type.Counts(Where);int category1_index=1;
List<Lebi_Pro_Type> category1s = B_Lebi_Pro_Type.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Pro_Type category1 in category1s){%>
            <a href="<%=URL("P_ProductCategory",category1.id,Lang(category1.Url))%>" target="_blank"><%=Lang(category1.Name) %></a>
 	<%category1_index++;}%>
            </div>
        </div>
        <div class="ind-right-list">
        	<ul>
       <%Table="Lebi_Product";Where=""+ProductWhere+" and Type_id_ProductType = 320 and "+ CategoryWhere(category.id) +"";Order="Sort desc,id desc";PageSize=4;pageindex=1;RecordCount=B_Lebi_Product.Counts(Where);int pro_index=1;
List<Lebi_Product> pros = B_Lebi_Product.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Product pro in pros){%>
                <li>
                	<i class="zhekou"></i>
                	<a href="<%=URL("P_Product",pro.id) %>"  class="shop-img"><img src="<%=Image(pro.ImageOriginal,"medium") %>"></a>
                    <p class="shopname">
                        <a href="<%=URL("P_Product",pro.id) %>"><%=Lang(pro.Name) %></a></p>
                    <span class="shopprice"><%=FormatMoney(ProductPrice(pro)) %></span> 
                    <a href="<%=URL("P_Product",pro.id) %>" class="buy-icon"></a>
                </li>
       <%pro_index++;}%>
            </ul>
        </div>
 <%category_index++;}%>
  </div>
</div>


<div class="ind-tabs">
	<div class="hd">
    	<ul>
        <%Table="Lebi_Brand";Where="Type_id_BrandStatus = 452 and IsRecommend=1";Order="Sort desc,id desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Brand.Counts(Where);int YHxG_index=1;
List<Lebi_Brand> YHxGs = B_Lebi_Brand.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Brand YHxG in YHxGs){%>
        	<li><%=Lang(YHxG.Name) %></li>
        <%YHxG_index++;}%>
        </ul>
    </div>
    <div class="bd">
      <%Table="Lebi_Brand";Where="Type_id_BrandStatus = 452 and IsRecommend=1";Order="Sort desc,id desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Brand.Counts(Where);int MoRd_index=1;
List<Lebi_Brand> MoRds = B_Lebi_Brand.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Brand MoRd in MoRds){%>
   	  <div class="lh">
        	<div class="pic"><a href="<%=URL("P_Brand",MoRd.id)%>"><img src="<%=Image(MoRd.ImageUrl) %>" alt="<%=Lang(MoRd.Name) %>" title="<%=Lang(MoRd.Name) %>" width="230" height="230" /></a></div>
            <div class="info">
            	<div class="desc"><%=Lang(MoRd.Description)%></div>
                <a href="<%=URL("P_Brand",MoRd.id)%>" class="read-more"><%=Lang(MoRd.Name) %> 商品列表 >></a>
            </div>
      </div>
      <%MoRd_index++;}%>
    </div>
</div>
<script type="text/javascript">jQuery(".ind-tabs").slide({ delayTime: 0 });</script>

<div class="clear"></div>
    
<div class="footer">
    <%=Lang(SYS.FootHtml) %>
    <div class="copyright f11 footer_logos">
        <div class="footer_logos-list">
            <%Table="Lebi_FriendLink";Where="IsShow=1 and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc,id desc";PageSize=7;pageindex=1;RecordCount=B_Lebi_FriendLink.Counts(Where);int Dyzd_index=1;
List<Lebi_FriendLink> Dyzds = B_Lebi_FriendLink.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_FriendLink Dyzd in Dyzds){%>
            
                <% if (Dyzd.Logo != "" && Dyzd.IsPic == 1){ %><a href="<%=Dyzd.Url%>" target="_blank"><img src="<%=Image(Dyzd.Logo) %>" alt="<%=Dyzd.Name%>" /></a><%}else{%><a href="<%=Dyzd.Url%>" target="_blank"><%=Dyzd.Name%></a><%} %>     
           
            <%Dyzd_index++;}%>
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
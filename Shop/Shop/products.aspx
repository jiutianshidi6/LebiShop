

<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Bussiness.ShopPage" %>
<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_49",1,"CN","P_ShopProducts"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>


<title><%=ThemePageMeta("P_ShopProducts","title")%></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="keywords" content="<%=ThemePageMeta("P_ShopProducts","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_ShopProducts","description")%>" />
<meta name="CurrenctCurrency" content="<%=CurrentCurrency.Code %>" />
<meta name="CurrenctCurrencyMsige" content="<%=CurrentCurrency.Msige %>" />
<meta name="CurrentExchangeRate" content="<%=CurrentCurrency.ExchangeRate %>" />
<meta name="CurrentLanguage" content="<%=CurrentLanguage.Code %>" />
<meta name="generator" content="LebiShop V<%=SYS.Version+"."+SYS.Version_Son %>" />
<meta name="copyright" content="2003-<%=DateTime.Now.Year %> lebi.cn" />
<link rel="shortcut icon" href="/theme/fashion_wewins/images/favicon.ico"/>
<link rel="bookmark" href="/theme/fashion_wewins/images/favicon.ico"/> 
<script type="text/javascript">
    var path = "<%=WebPath %>";
    var sitepath = "/";
    var langpath = "/";
</script>
<script src="/Theme/system/js/jquery-1.7.2.min.js" type="text/javascript"></script>

<script src="/theme/fashion_wewins/js/common.js" type="text/javascript"></script>
<script type="text/javascript" src="/theme/fashion_wewins/js/quick_links.js"></script>

<script src="/Theme/system/js/jquery-ui.min.js" type="text/javascript"></script>
<script src="/Theme/system/js/main.js" type="text/javascript"></script>
<script src="<%=WebPath %>/ajax/js.aspx" type="text/javascript"></script>
<script src="/Theme/system/js/my97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script src="/Theme/system/js/msclass.js" type="text/javascript"></script>
<script src="/Theme/system/js/prettyphoto/jquery.prettyphoto.js" type="text/javascript"></script>
<script src="/theme/fashion_wewins/js/<%=CurrentLanguage.Code %>.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="/Theme/system/css/system.css" />
<link rel="stylesheet" type="text/css" href="/Theme/system/js/jqueryuicss/redmond/jquery-ui.css" />
<link rel="stylesheet" type="text/css" href="/Theme/system/js/prettyphoto/css/prettyPhoto.css" />
<link rel="stylesheet" type="text/css" href="/theme/fashion_wewins/css/css.css" />
<link rel="stylesheet" type="text/css" href="/theme/fashion_wewins/css/<%=CurrentLanguage.Code %>.css" />
<link rel="stylesheet" type="text/css" href="/theme/fashion_wewins/css/fashion.css" />
<script src="/theme/fashion_wewins/js/all-jquery.js" type="text/javascript"></script>
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
                window.location.href = "/wap/";
            }
        }
        if (bIsMidp || bIsUc7 || bIsUc || bIsCE || bIsWM) {
            var sUrl = location.href;
            if (!bForcepc) {
                window.location.href = "/wap/";
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
 

<script type="text/javascript">
    function AddFavorite(sURL, sTitle) {
        try {
            window.external.addFavorite(sURL, sTitle);
        }
        catch (e) {
            try {
                window.sidebar.addPanel(sTitle, sURL, "");
            }
            catch (e) {
                alert("加入收藏失败，请使用Ctrl+D进行添加");
            }
        }
    }
</script>

</head>
<body>
  
<div class="head">
    <div class="top">
        <div class="center clearfix">
            <ul class="sns">
                <span class="userstatus" id="userstatus"><a href="<%=URL("P_Register", "") %>"><%=Tag("免费注册")%></a> ┊ <a href="<%=URL("P_Login", "") %>"><%=Tag("登录")%></a></span>
            </ul>
            <div class="UserInfo">
                <a href="<%=URL("P_UserCenter","") %>">我的账号</a><span class="line"></span><a href="<%=URL("P_Basket","") %>">购物车</a><span class="line"></span>

<div class="language">
    <ul class="droplanguage">
        <li class="language_li"><a class="noclick"><span>网站语言：</span><s><%if (CurrentLanguage.ImageUrl!=""){%><img src="<%=Image(CurrentLanguage.ImageUrl) %>" /><%}%><%=CurrentLanguage.Name %></s></a><dl
            class="language_li_content">
            <%List<Shop.Model.Lebi_Language> LuWts=Languages();RecordCount=LuWts.Count;int LuWt_index=1;
foreach (Shop.Model.Lebi_Language LuWt in LuWts){%>
            <dd <%if (LuWt_index==RecordCount){%>class="last" <%} %>>
                <a href="javascript:SetLanguage(<%=LuWt.id%>,'<%=LuWt.Code%>','<%=LuWt.Path%>');"><%if (LuWt.ImageUrl!=""){%><img src="<%=Image(LuWt.ImageUrl) %>" /><%}%><%=LuWt.Name%></a></dd>
            <%LuWt_index++;}%>
        </dl>
        </li>
    </ul>
</div>

            </div>
        </div>
    </div>
    <script type="text/javascript">        LoadPage(path + '/inc/userstatus.aspx', 'userstatus');</script>
    <div class="head-main">
        <h1 class="logo">

<a href="/"><img src="<%=Image(Lang(SYS.Logoimg)) %>" alt="<%=Lang(SYS.Name)%>" title="<%=Lang(SYS.Name)%>" /></a>
</h1>
        <div class="search">
            

<script type="text/javascript">
    $(function () {
        blurInput('#keyword', '<%if (Rstring("Keyword")!=""){ %><%=Rstring("Keyword")%><%}else{%><%Table="Lebi_Searchkey";Where="Type=1";Order="Sort desc,id desc";PageSize=1;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int FnAP_index=1;
List<Lebi_Searchkey> FnAPs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey FnAP in FnAPs){%><%=Lang(FnAP.Name)%><%FnAP_index++;}%><%} %>');
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
        <a typename="shop" href="javascript:void(0)">店铺</a>
        <%}%>
    </dd>
</dl>
</div>
<input id="keyword" value="" type="text" name="keyword" onfocus="if (this.value != '') {this.value = '';}" />
<input type="button" value="搜索" class="button" />
</div>

            

<div class="searchkeyword">
<%Table="Lebi_Searchkey";Where="";Order="Sort desc,id desc";PageSize=5;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int jvoe_index=1;
List<Lebi_Searchkey> jvoes = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey jvoe in jvoes){%>
<%if (jvoe.Type==1){ %><a href="<%=URL("P_Search",""+Lang(jvoe.Name)+"") %>"><%}else{ %><a href="<%=jvoe.URL%>" target="_blank"><%} %><span><%=Lang(jvoe.Name)%></span></a>
<%jvoe_index++;}%>
</div>

        </div>
    </div>
</div>
  <div class="mainNav">
    <div class="mainNav-con">
      <div class="allnav">
        <h2 class="title">
          <a href="<%=URL("P_AllProductCategories", "")%>">全部商品分类</a><i class="title-icon"></i>
        </h2>
        <div class="allnav-show">
          <ul id="nav">
            <%
                        int ic0=0;
            foreach(Lebi_Pro_Type c0 in EX_Product.ShowTypes(0,CurrentSite.id))
            {
            ic0++;
            if(ic0>11)
            continue;
            %>
            <li id="mainCate-1" class="mainCate">
                <h3>
                    <i class="nav-icon">
                        <%if(c0.ImageSmall!=""){ %>
                        <img src="<%=c0.ImageSmall %>" alt="<%=Lang(c0.Name) %>" style="width:18px;height:18px;" /><%} %>
                    </i><a href="<%=URL(" P_ProductCategory",""+c0.id+"") %>"><%=Lang(c0.Name) %></a>
                </h3>
                <div class="subCate">
                    <div class="menu-brand-lists">
                        <div class="menu-classify">
                            <div class="menu-classify-part">
                                <div class="menu-classify-mode">
                                    <%
                                    int ic1=0;
                                    foreach(Lebi_Pro_Type c1 in EX_Product.ShowTypes(c0.id,CurrentSite.id))
                                    {
                                    %>
                                    <div class="menu-classify-mode-title"><a target="_blank" href="<%=URL(" P_ProductCategory",""+c1.id+"") %>"><%=Lang(c1.Name) %></a></div>
                                    <ul>
                                        <%
                                        int ic2=0;
                                        foreach(Lebi_Pro_Type c2 in EX_Product.ShowTypes(c1.id,CurrentSite.id))
                                        {
                                        %>
                                        <li>
                                            <a target="_blank" href="<%=URL(" P_ProductCategory",""+c2.id+"") %>"><%=Lang(c2.Name) %></a>
                                        </li>
                                        <%} %>
                                    </ul>
                                    <%} %>
                                </div>
                            </div>
                            <div class="menu-classify-part right">
                                <div class="menu-classify-mode">
                                    <div class="menu-classify-mode-title right"><a>热门品牌</a></div>
                                    <ul class="brand-ul">
                                        <%Table="Lebi_Brand";Where="Type_id_BrandStatus = 452 and ','+Pro_Type_id+',' like '%,"+c0.id+",%'";Order="Sort desc";PageSize=16;pageindex=1;RecordCount=B_Lebi_Brand.Counts(Where);int wTjn_index=1;
List<Lebi_Brand> wTjns = B_Lebi_Brand.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Brand wTjn in wTjns){%>
                                            <li class="brand-box first"><a target="_blank" href="<%=URL("P_Brand",wTjn.id)%>"><img alt="<%=Lang(wTjn.Name) %>" src="<%=Image(wTjn.ImageUrl) %>"><span><%=Lang(wTjn.Name) %></span></a></li>
                                        <%wTjn_index++;}%> 
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
</li>
            <%} %>
          </ul>
        </div>
      </div>
      
      <div class="other-menu">
		

<%Table="Lebi_Page";Where="Node_id="+Node("HeadMenu").id+" and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int NhkA_index=1;
List<Lebi_Page> NhkAs = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page NhkA in NhkAs){%>
<a class="menu" href="<%=URL("","",NhkA.url)%>"><span><%=NhkA.Name%></span></a>
<%NhkA_index++;}%>

        
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
        
<div id="shopcategory">
    <h4>商品分类</h4>
    <div class="categories">
        <%Table="Lebi_Supplier_ProductType";Where="parentid = 0 and Supplier_id = "+id+"";Order="Sort desc,id desc";PageSize=20;pageindex=1;RecordCount=B_Lebi_Supplier_ProductType.Counts(Where);int kcaa_index=1;
List<Lebi_Supplier_ProductType> kcaas = B_Lebi_Supplier_ProductType.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Supplier_ProductType kcaa in kcaas){%>
        <dl <%if ((parentcid == 0 && kcaa_index == 1) || parentcid == kcaa.id){ %>class="current" <%} %>>
            <dt class="double">
                <label class="pic">
                </label>
                <a href="<%=URL("P_ShopProductCategory",""+id+","+kcaa.id+"") %>">
                    <%=Lang(kcaa.Name) %></a></dt>
            <dd>
                <ul>
                    <%Table="Lebi_Supplier_ProductType";Where="parentid = "+kcaa.id+" and Supplier_id = "+id+"";Order="Sort desc,id desc";PageSize=20;pageindex=1;RecordCount=B_Lebi_Supplier_ProductType.Counts(Where);int dTWr_index=1;
List<Lebi_Supplier_ProductType> dTWrs = B_Lebi_Supplier_ProductType.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Supplier_ProductType dTWr in dTWrs){%>
                    <li class="<%=cid==dTWr.id?"currentlink":"" %>"><a href="<%=URL("P_ShopProductCategory",""+id+","+dTWr.id+"") %>">
                        <%=Lang(dTWr.Name) %></a></li>
                    <%dTWr_index++;}%>
                </ul>
            </dd>
        </dl>
        <%kcaa_index++;}%>
    </div>
</div>


<%if (supplierservicepannel.Status == "1"){%>
<div id="shopservice" class="mbox clearfix">
<div class="shopinfo">
<div class="mt">
    <h2>店铺客服</h2>
</div>
<div class="mc">
<%Table="Lebi_ServicePanel_Group";Where="Supplier_id = "+ id +" and ','+Language_ids+',' like '%,"+ CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_ServicePanel_Group.Counts(Where);int shop_group_index=1;
List<Lebi_ServicePanel_Group> shop_groups = B_Lebi_ServicePanel_Group.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ServicePanel_Group shop_group in shop_groups){%>
<ul class="group clearfix">
<h2><%=shop_group.Name%></h2>
<ul class="group-user clearfix">
<%Table="Lebi_ServicePanel";Where="Supplier_id = "+ id +" and ServicePanel_Group_id = "+shop_group.id+" and ','+Language_ids+',' like '%,"+ CurrentLanguage.id + ",%'";Order="Sort desc,id desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_ServicePanel.Counts(Where);int shop_user_index=1;
List<Lebi_ServicePanel> shop_users = B_Lebi_ServicePanel.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ServicePanel shop_user in shop_users){%>
<%
    string url = GetServicePanelType(shop_user.ServicePanel_Type_id).Url;
    url = url.Replace("{@uid}",shop_user.Account);
    url = url.Replace("{@uname}",shop_user.Name);
%>
<li><a target="blank" href="<%=url%>"><img src="<%if (GetServicePanelType(shop_user.ServicePanel_Type_id).IsOnline == 1){
    Response.Write(GetServicePanelType(shop_user.ServicePanel_Type_id).Code.Replace("{@uid}",shop_user.Account));
}else{
    Response.Write(Image(GetServicePanelType(shop_user.ServicePanel_Type_id).Face));
}%>" border="0" align="absmiddle" />&nbsp;<%=shop_user.Name%></a></li>
<%shop_user_index++;}%>
</ul>
</li></ul>
<%shop_group_index++;}%>
</div>
</div>
</div>
<%}%>

<div class="banner"><a href="javascript:void(0);" onclick="AddFavorite(window.location,document.title)"><img src="/theme/fashion_wewins/images/shopcollect.jpg" /></a></div>

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
<div class="producttitle">
<div id="filter">
	<div class="fore1">
		<dl class="order">
			<dt>排序：</dt>
			<dd <%if(sort == "" || sort == "1" || sort == "1a"){ %>class="curr <%if(sort == "" || sort == "1"){ %>up<%}else if(sort == "1a"){ %>down<%} %>"<%} %>><a href="<%=URL("P_ShopProductCategory",""+id+","+cid+","+list+",1"+ordertmp+"") %>">销量</a><b></b></dd>
			<dd <%if(sort == "2" || sort == "2a"){ %>class="curr <%if(sort == "2"){ %>up<%}else if(sort == "2a"){ %>down<%} %>"<%} %>><a href="<%=URL("P_ShopProductCategory",id+","+cid+","+list+",2"+ordertmp+"") %>">价格</a><b></b></dd>
			<dd <%if(sort == "3" || sort == "3a"){ %>class="curr <%if(sort == "3"){ %>up<%}else if(sort == "3a"){ %>down<%} %>"<%} %>><a href="<%=URL("P_ShopProductCategory",id+","+cid+","+list+",3"+ordertmp+"") %>">评价数</a><b></b></dd>
			<dd <%if(sort == "4" || sort == "4a"){ %>class="curr <%if(sort == "4"){ %>up<%}else if(sort == "4a"){ %>down<%} %>"<%} %>><a href="<%=URL("P_ShopProductCategory",id+","+cid+","+list+",4"+ordertmp+"") %>">上架时间</a><b></b></dd>
		</dl>
        <div class="list-cutover">
			<a id="list-unselected"  href="<%=URL("P_ShopProductCategory",""+id+","+cid+",2,"+ sort +"") %>" class="modfiy-url list-unselected <%=list=="2"?"list-curr":"" %>"><b></b>列表</a>
			<a id="grid-unselected"  href="<%=URL("P_ShopProductCategory",""+id+","+cid+",1,"+ sort +"") %>" class="modfiy-url grid-unselected <%=(list=="1" || list=="")?"grid-curr":"" %>"><b></b>网格</a>
		</div>
		<div class="pagin pagin-m" id="top_pagi">
			<%=HeadPage%>
		</div>
		<div class="total">
			<span>共<strong> <%=B_Lebi_Product.Counts(where) %> </strong>个商品</span>
		</div>
		<span class="clr"></span>
	</div>
</div>
 </div>
<div class="mc clearfix">
    <div class="productlist loadlist"><ul>
        <%foreach (Shop.Model.Lebi_Product pro in products)
        {
        if (list == "" || list == "1"){ %>
        <li class="grid loadli">
            <div class="proimg">
                <p><a href="<%=URL("P_Product",pro.id) %>" target="_blank"><img <%if (CurrentLanguage.IsLazyLoad==1){ %>class="listlazy" src="/Theme/system/images/lazy.gif" data-original<%}else{ %>src<%} %>="<%=Image(pro,"medium")%>" alt="<%=Lang(pro.Name) %>" /></a></p></div>
            <div class="proname">
                <a href="<%=URL("P_Product",pro.id) %>" title="<%=Lang(pro.Name) %>" target="_blank"><%=Lang(pro.Name) %></a>
            </div>
            <div class="proinfo">
              <div class="price"><span><%if (pro.Type_id_ProductType == 321 && (System.DateTime.Now < pro.Time_Expired)){ %><%=FormatMoney(pro.Price_Sale) %><%}else {%><%=FormatMoney(ProductPrice(pro)) %><%} %></span><%if (pro.Price_Market > 0){ %><del><%=FormatMoney(pro.Price_Market) %></del><%} %></div>
              <div class="comment"><a href="<%=URL("P_Product",pro.id) %>">已有<%=pro.Count_Comment %>人评价</a><span>|</span><%if(ProductStock(pro)<1){ %>已售罄<%}else { %>有货<%} %></div>
            </div>
        </li>
        <%}else{ %>
        <li class="list loadli">
            <div class="proimg">
                <p><a href="<%=URL("P_Product",pro.id) %>" target="_blank"><img <%if (CurrentLanguage.IsLazyLoad==1){ %>class="listlazy" src="/Theme/system/images/lazy.gif" data-original<%}else{ %>src<%} %>="<%=Image(pro,"medium")%>" alt="<%=Lang(pro.Name) %>" /></a></p></div>
            <div class="proname">
                <a href="<%=URL("P_Product",pro.id) %>" title="<%=Lang(pro.Name) %>" target="_blank"><%=Lang(pro.Name) %></a>
            </div>
            <div class="proinfo">
            <%if (pro.Price_Market > 0){ %><div class="marketprice"><i>市场价：</i><strong><%=FormatMoney(pro.Price_Market) %></strong></div><%} %>
            <%if (pro.Type_id_ProductType == 321 && (System.DateTime.Now < pro.Time_Expired)){ %>
            <div class="buyprice"><i>抢购价：</i><strong><%=FormatMoney(pro.Price_Sale) %></strong><em><%=Discount(pro.Price_Market,pro.Price_Sale) %>% 折</em></div>
			<%}else{%>
			<div class="buyprice"><i><%=Lang(CurrentUserLevel.PriceName) %>：</i><strong><%=FormatMoney(ProductPrice(pro)) %></strong></div>
            <%} %>
            <div class="introduction"><%=Lang(pro.Introduction)%></div>
            <div class="probtn">
                <%if(ProductStock(pro)<1){ %>
                <strong>已售罄</strong>
                <%}else{ %>
                <a href="javascript:void(0)" onclick="UserProduct_Edit(<%=pro.id%>,142,$('#pro_num<%=pro.id%>').val());" class="buy btn btn-12"><s></s>加入购物车</a>
                <a href="javascript:void(0)" onclick="UserProduct_Edit(<%=pro.id%>,141);" class="fav btn btn-12"><s></s>收藏</a>
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
<div class="page"><%=FootPage%></div>
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
        ias.extension(new IASSpinnerExtension({ html: "<li class=\"loadinginfo\"><img src=\"{src}\" />&nbsp;加载中</li>" }));
        ias.extension(new IASTriggerExtension({ text: '加载更多', offset: 100, html: "<li class=\"loadinginfo more\"><p>{text}</p></li>" }));
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
</div>
<div class="copyright">
    <%=Lang(SYS.Copyright) %>
    <%=GetCNZZ() %>
</div>

  


<%if (supplierservicepannel.Status == "1"){%>
<%if (supplierservicepannel.Style == "1"){%>
<script type="text/javascript" src="/supplier/js/user/ServicePanel<%=id %>.js"></script>
<div id="divShopServicePannel" onmouseout="ShowShopServicePannel(event);" style="z-index:9998;width: 170px; position:absolute; right:0">
<layer id="divShopServicePannel">
<div id="ShopServicePannelOnline" style="display:none;">
<div class="servicepannel">
<div class="menutop"><img src="/Theme/system/images/<%=CurrentLanguage.Code %>/ServicePanel/<%=supplierservicepannel.Theme%>_1.gif" alt="" /></div>
<div class="menucenter"><div style="background:url(/Theme/system/images/<%=CurrentLanguage.Code %>/ServicePanel/<%=supplierservicepannel.Theme%>_2.gif) repeat-y">
<%Table="Lebi_ServicePanel_Group";Where="Supplier_id = "+ id +" and ','+Language_ids+',' like '%,"+ CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_ServicePanel_Group.Counts(Where);int group_index=1;
List<Lebi_ServicePanel_Group> groups = B_Lebi_ServicePanel_Group.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ServicePanel_Group group in groups){%>
<ul class="group clearfix">
<h2><%=group.Name%></h2>
<ul class="group-user clearfix">
<%Table="Lebi_ServicePanel";Where="Supplier_id = "+ id +" and ServicePanel_Group_id = "+group.id+" and ','+Language_ids+',' like '%,"+ CurrentLanguage.id + ",%'";Order="Sort desc,id desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_ServicePanel.Counts(Where);int user_index=1;
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
<div class="menufoot" style="background:url(/Theme/system/images/<%=CurrentLanguage.Code %>/ServicePanel/<%=servicepannel.Theme%>_3.gif) top no-repeat"><img src="/Theme/system/images/<%=CurrentLanguage.Code %>/ServicePanel/<%=supplierservicepannel.Theme%>_3.gif" /></div>
</div>
</div></layer>
<div id="ShopServicePannelMenu" onmouseover="ShopServicePannelOver();"><img src="/Theme/system/images/<%=CurrentLanguage.Code %>/ServicePanel/menu_<%=supplierservicepannel.Theme%>.gif" style="right:0;border:none;cursor:pointer;width:26px;height:136px;position: absolute;" /></div>
</div>
<%} }%>

<script type="text/javascript" src="/theme/fashion_wewins/js/shoplist.js"></script>

  

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
</html><div style="width:100%;text-align:center;font-size:12px;color:#999">Powered by <a style="font-size:12px;color:#00497f" href="http://www.lebi.cn/support/license/?url=localhost,,,,,,,,,,,,,,,,,,,,,,,,,,,,," target="_blank" title="LebiShop多语言网店系统">LebiShop</a> V<%=SYS.Version%>.<%=SYS.Version_Son%></div>
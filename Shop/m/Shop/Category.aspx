<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_ShopProductCategory" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_ShopProductCategory"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_ShopProductCategory","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_ShopProductCategory","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_ShopProductCategory","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_ShopProductCategory","title")%></h2>
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
            <div class="location"><div class="path"><%=path%></div></div>
            
            


<div class="mbox clearfix">
<div class="brandsearch">
<div class="mt">
    <h2>店内搜索</h2>
</div>
<div class="mc">
    <input id="shop_keyword" value="" type="text" name="shop_keyword" onkeydown="if(event.keyCode==13){shopsearch();}" /><input type="button" value="搜索" class="button" onclick="shopsearch();" />
</div>
</div>
</div>
<script type="text/javascript" >
    function shopsearch() {
        var url = "<%=URL("P_ShopProductCategory",""+ id +",0,1,1,1,[key]")%>";
        location.href = url.replace("[key]",escape($("#shop_keyword").val()));
    }
</script>



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
                <p><a href="<%=URL("P_Product",pro.id) %>" target="_blank"><img <%if (CurrentLanguage.IsLazyLoad==1){ %>class="listlazy" src="/Theme/system/wap/images/lazy.gif" data-original<%}else{ %>src<%} %>="<%=Image(pro,"medium")%>" alt="<%=Lang(pro.Name) %>" /></a></p></div>
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
                <p><a href="<%=URL("P_Product",pro.id) %>" target="_blank"><img <%if (CurrentLanguage.IsLazyLoad==1){ %>class="listlazy" src="/Theme/system/wap/images/lazy.gif" data-original<%}else{ %>src<%} %>="<%=Image(pro,"medium")%>" alt="<%=Lang(pro.Name) %>" /></a></p></div>
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



<div id="shopcategory">
<h4>商品分类</h4>
<div class="categories">
    <%Table="Lebi_Supplier_ProductType";Where="parentid = 0 and Supplier_id = "+id+"";Order="Sort desc,id desc";PageSize=20;pageindex=1;RecordCount=B_Lebi_Supplier_ProductType.Counts(Where);int MapQ_index=1;
List<Lebi_Supplier_ProductType> MapQs = B_Lebi_Supplier_ProductType.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Supplier_ProductType MapQ in MapQs){%>
    <dl <%if ((parentcid == 0 && MapQ_index == 1) || parentcid == MapQ.id){ %>class="current" <%} %>>
    <dt class="double">
        <label class="pic"></label>
        <a href="<%=URL("P_ShopProductCategory",""+id+","+MapQ.id+"") %>"><%=Lang(MapQ.Name) %></a>
    </dt>
    <dd>
        <ul>
            <%Table="Lebi_Supplier_ProductType";Where="parentid = "+MapQ.id+" and Supplier_id = "+id+"";Order="Sort desc,id desc";PageSize=20;pageindex=1;RecordCount=B_Lebi_Supplier_ProductType.Counts(Where);int CXCr_index=1;
List<Lebi_Supplier_ProductType> CXCrs = B_Lebi_Supplier_ProductType.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Supplier_ProductType CXCr in CXCrs){%>
            <li class="<%=cid==CXCr.id?"currentlink":"" %>"><a href="<%=URL("P_ShopProductCategory",""+id+","+CXCr.id+"") %>">
                <%=Lang(CXCr.Name) %></a></li>
            <%CXCr_index++;}%>
        </ul>
    </dd>
    </dl>
    <%MapQ_index++;}%>
</div>
</div>
<script type="text/javascript" src="/Theme/system/wap/js/shoplist.js"></script>



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
}
    
</body>
</html><div style="width:100%;text-align:center;font-size:12px;color:#999">Powered by <a style="font-size:12px;color:#00497f" href="http://www.lebi.cn/support/license/?url=" target="_blank" title="LebiShop多语言网店系统">LebiShop</a> V<%=SYS.Version%>.<%=SYS.Version_Son%></div>
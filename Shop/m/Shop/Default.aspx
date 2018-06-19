<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_ShopIndex" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_ShopIndex"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_ShopIndex","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_ShopIndex","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_ShopIndex","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_ShopIndex","title")%></h2>
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
            
<script src="/Theme/system/wap/js/msclass.js" type="text/javascript"></script>
<div class="mainbanner clearfix">

<%if (Getindeximages(5).Count>0){ %>
<link rel="stylesheet" type="text/css" href="/Theme/system/wap/css/royalslider.css" />
<div id="indexfocus" class="royalSlider rsDefault">
    <%foreach(shopindeximage img in Getindeximages(5)){ %>
    <div class="focusitem">
        <div class="pic"><a href="<%=img.url %>"><img src="<%=img.image %>" /></a></div>
        <h3><a href="<%=img.url %>"><%=img.title %></a></h3>
    </div>
    <%} %>
</div>
<script src="/Theme/system/wap/js/jquery.royalslider.min.js"></script>
<script>
    jQuery(document).ready(function ($) {
        $('#indexfocus').royalSlider({
            fullscreen: {
                enabled: false,
                nativeFS: false
            },
            controlNavigation: 'none',
            autoHeight: true,
            loop: true,
            imageScaleMode: 'fit-if-smaller',
            navigateByClick: true,
            numImagesToPreload: 2,
            arrowsNav: true,
            arrowsNavAutoHide: false,
            arrowsNavHideOnTouch: false,
            keyboardNavEnabled: true,
            fadeinLoadedSlide: true,
            globalCaption: false,
            globalCaptionInside: true,
            thumbs: {
                appendSpan: true,
                firstMargin: true,
                paddingBottom: 4
            }
        });
    });
</script>
<%} %>
</div>

            


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



<%Table="Lebi_Supplier_ProductType";Where="parentid = 0 and Supplier_id = "+id+"";Order="Sort desc,id desc";PageSize=20;pageindex=1;RecordCount=B_Lebi_Supplier_ProductType.Counts(Where);int Erjz_index=1;
List<Lebi_Supplier_ProductType> Erjzs = B_Lebi_Supplier_ProductType.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Supplier_ProductType Erjz in Erjzs){%>
<div class="nbbox clearfix">
<div class="categoryproducttop clearfix">
    <div class="mt clearfix">
        <div class="left">
            <h2><%=Lang(Erjz.Name) %></h2>
        </div>
        <div class="right"><a href="<%=URL("P_ShopProductCategory",""+id+","+Erjz.id+"") %>">更多</a></div>
    </div>
    <div class="mc clearfix">
        <div class="productshow">
            <ul class="image">
                <%Table="Lebi_Product";Where=""+ProductWhere+" and Type_id_ProductType = 320 and "+ ShopCategoryWhere(Erjz.id) +"";Order="Sort desc,id desc";PageSize=8;pageindex=1;RecordCount=B_Lebi_Product.Counts(Where);int pro_index=1;
List<Lebi_Product> pros = B_Lebi_Product.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Product pro in pros){%>
                <li>
                    <div class="proimg"><p><a href="<%=URL("P_Product",pro.id) %>"><img <%if (CurrentLanguage.IsLazyLoad==1){ %>class="lazy" src="/Theme/system/wap/images/lazy.gif" data-original<%}else{ %>src<%} %>="<%=Image(pro.ImageOriginal,"medium") %>" alt="<%=Lang(pro.Name) %>" title="<%=Lang(pro.Name) %>" /></a></p></div>
                    <div class="proname"><a href="<%=URL("P_Product",pro.id) %>" title="<%=Lang(pro.Name) %>"><%=Lang(pro.Name) %></a></div>
                    <div class="proprice"><%if (pro.Price_Market > 0){ %><div class="marketprice"><i>市场价：</i><strong><%=FormatMoney(pro.Price_Market) %></strong></div><%} %><div class="buyprice"><i><%=Lang(CurrentUserLevel.PriceName) %>：</i><strong><%=FormatMoney(ProductPrice(pro)) %></strong></div></div>                    
                </li>
                <%pro_index++;}%>
            </ul>
            <div class="clear"></div>
        </div>
    </div>
</div>
</div>
<%Erjz_index++;}%>



<div id="shopcategory">
<h4>商品分类</h4>
<div class="categories">
    <%Table="Lebi_Supplier_ProductType";Where="parentid = 0 and Supplier_id = "+id+"";Order="Sort desc,id desc";PageSize=20;pageindex=1;RecordCount=B_Lebi_Supplier_ProductType.Counts(Where);int CSWy_index=1;
List<Lebi_Supplier_ProductType> CSWys = B_Lebi_Supplier_ProductType.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Supplier_ProductType CSWy in CSWys){%>
    <dl <%if ((parentcid == 0 && CSWy_index == 1) || parentcid == CSWy.id){ %>class="current" <%} %>>
    <dt class="double">
        <label class="pic"></label>
        <a href="<%=URL("P_ShopProductCategory",""+id+","+CSWy.id+"") %>"><%=Lang(CSWy.Name) %></a>
    </dt>
    <dd>
        <ul>
            <%Table="Lebi_Supplier_ProductType";Where="parentid = "+CSWy.id+" and Supplier_id = "+id+"";Order="Sort desc,id desc";PageSize=20;pageindex=1;RecordCount=B_Lebi_Supplier_ProductType.Counts(Where);int VzsD_index=1;
List<Lebi_Supplier_ProductType> VzsDs = B_Lebi_Supplier_ProductType.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Supplier_ProductType VzsD in VzsDs){%>
            <li class="<%=cid==VzsD.id?"currentlink":"" %>"><a href="<%=URL("P_ShopProductCategory",""+id+","+VzsD.id+"") %>">
                <%=Lang(VzsD.Name) %></a></li>
            <%VzsD_index++;}%>
        </ul>
    </dd>
    </dl>
    <%CSWy_index++;}%>
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



<div id="shopinfo" class="mbox clearfix">
<div class="shopinfo">
<div class="mt">
    <h2>店铺资料</h2>
</div>
<div class="mc">
    <ul>
    <li>店铺简称：<%=Lang(supplier.Name) %></li>
    <li>公司名称：<%=supplier.Company %></li>
    <li>联系人：<%=supplier.RealName %></li>
    <li>手机号码：<%=supplier.MobilePhone %></li>
    <li>电话号码：<%=supplier.Phone %></li>
    <li>EMAIL：<%=supplier.Email %></li>
    <li>QQ号码：<%=supplier.QQ %></li>
    <li>邮编：<%=supplier.Postalcode %></li>
    <li>地区：<%=Shop.Bussiness.EX_Area.GetAreaName(supplier.Area_id)%></li>
    <li>地址：<%=supplier.Address %></li>
    </ul>
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
}
    
</body>
</html><div style="width:100%;text-align:center;font-size:12px;color:#999">Powered by <a style="font-size:12px;color:#00497f" href="http://www.lebi.cn/support/license/?url=" target="_blank" title="LebiShop多语言网店系统">LebiShop</a> V<%=SYS.Version%>.<%=SYS.Version_Son%></div>
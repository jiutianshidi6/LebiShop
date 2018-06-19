<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_Basket" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_Basket"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_Basket","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_Basket","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_Basket","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_Basket","title")%></h2>
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
            


<div id="basket">
<%if (basket.Products.Count == 0 && basket.FreeProducts.Count == 0){%>
    <table align="center" cellpadding="0" cellspacing="0">
    <tr><td class="basketempty">购物车为空，请将您要购买的商品放入购物车</td></tr>
    </table>
<%}else{ %>
<%foreach(Shop.Model.BasketShop shop in basket.Shops){ %>
<%if (shop.Shop.id==0 && basket.Shops.Count==1){%><%}else{ %>
<div class="shop"><span><%if (shop.Shop.id==0){%>自营商品<%}else {%><%=Lang(shop.Shop.Name) %><%} %></span></div>
<%} %>
<div class="basketlist">
    <div class="table-list">
        <% 
            foreach (Shop.Model.Lebi_User_Product p in shop.Products)
            {
                Shop.Model.Lebi_Product model = GetProduct(p.Product_id);
        %>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <th style="width:50px" valign="top" rowspan="3"><img src="<%=Image(model.ImageOriginal)%>" width="50" height="50" class="picb"></th>
            <th style="text-align:left" valign="top">
            <a href="<%=URL("P_Product",model.id) %>"><%=Lang(model.Name) %></a>
            <em><%if (Shop.Bussiness.EX_Product.ProPertyNameStr(model, CurrentLanguage.Code) !=""){ %><br /><%=Shop.Bussiness.EX_Product.ProPertyNameStr(model, CurrentLanguage.Code)%><%} %>
            <%if (p.ProPerty134 !=""){ %><br /><%=p.ProPerty134 %><%} %></em>
            </th>
            <th style="width:60px" valign="top">
            <%
            if(model.Type_id_ProductType==323 && model.Time_Expired > System.DateTime.Now)
                Response.Write(Tag("积分")+":"+model.Price_Sale);
            else
                Response.Write(FormatMoney(p.Product_Price));
            %>
            <br /><s><%=FormatMoney(Shop.Bussiness.EX_Product.ProductMarketPrice(model)) %></s>
            </th>
        </tr>
        <tr>
            <td colspan="2">数量：
                <%if (model.Type_id_ProductType != 321 || (System.DateTime.Now > model.Time_Expired))
                {
                    model.Count_Limit=0; 
                }
                %>
                <input type="button" <%if (p.count > 1){ %>onclick="UserProduct_Edit(<%=model.id %>,142,$('#BasketCount<%=model.id %>').val()/1-1,'edit',<%=model.Count_Limit %>)" class="qty-reduce"<%}else{ %> class="qty-reduce-gray"<%} %> value="" /><input name="BasketCount<%=model.id %>" id="BasketCount<%=model.id %>" type="text" value="<%=p.count %>" onkeyup="value=value.replace(/[^\d]/g,'');" onchange="UserProduct_Edit(<%=model.id %>,142,this.value,'edit',<%=model.Count_Limit %>)"; Basket="true" size="3" maxlength="5" class="qty-input" /><input type="button" onclick="UserProduct_Edit(<%=model.id %>,142,$('#BasketCount<%=model.id %>').val()/1+1,'edit',<%=model.Count_Limit %>)" value="" class="qty-add" />
            </td>
        </tr>
        <tr>
            <td colspan="2"><a href="javascript:void(0)" onclick="UserProduct_Del(<%=p.Product_id %>,142);" class="btn btn-12"><s></s>移除购物车</a></td>
        </tr>
        </table>
        <%} %>  
    </div>
    <%if(shop.FreeProducts.Count>0){ %>
    <div class="table-list">
        <% 
                    foreach(Shop.Model.Lebi_User_Product p in shop.FreeProducts){
                        Shop.Model.Lebi_Product model = GetProduct(p.Product_id);
        %>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <th style="width:50px" valign="top" rowspan="2"><img src="<%=Image(model.ImageOriginal)%>" width="50" height="50" class="picb"></th>
            <th style="text-align:left" valign="top">
            <a href="<%=URL("P_Product",model.id) %>">[赠品] <%=Lang(model.Name) %></a>
            <em><%if (Shop.Bussiness.EX_Product.ProPertyNameStr(model, CurrentLanguage.Code) !=""){ %><br /><%=Shop.Bussiness.EX_Product.ProPertyNameStr(model, CurrentLanguage.Code)%><%} %>
            <%if (p.ProPerty134 !=""){ %><br /><%=p.ProPerty134 %><%} %></em>
            </th>
            <th style="width:60px" valign="top">
            <s><%=FormatMoney(model.Price_Market) %></s>
            </th>
        </tr>
        <tr>
            <td colspan="2">数量：<%=p.count %>
            </td>
        </tr>
        </table>
        <%} %>
    </div>
    <%} %>
    <%if(shop.PromotionTypes.Count>0){ %>
    <div class="promotion">
    优惠促销：<%
        foreach(Lebi_Promotion_Type pt in shop.PromotionTypes){ %>
        <%=shop.Shop.id>0?"["+Lang(shop.Shop.Name)+"]":"" %><%=Lang(pt.Name) %>&nbsp;&nbsp;
        <%} %>
    </div>
    <%} %>
    <%if (shop.Products.Count > 0 || shop.FreeProducts.Count > 0)
      {%>
    <div class="money">
        <%if (shop.Money_Cut>0){ %><p>减免：<span><%=FormatMoney(shop.Money_Cut)%></span></p><%} %>
        <p>购买价：<span><%=FormatMoney(shop.Money_Product-shop.Money_Cut)%></span></p>
        <%if(shop.Money_Property>0){ %>
        <p>其它费用：<span><%=FormatMoney(shop.Money_Property)%></span></p>
        <%} %>
        <p>节省：<s><span><%=FormatMoney(shop.Money_Market - shop.Money_Product-shop.Money_Cut)%></span></s></p>
        <%if(shop.Point_Buy>0){ %>
        <p>所需积分：<span><%=shop.Point_Buy%></span></p>
        <%} %>
        <%if(shop.Point>0){ %>
        <p>获得积分：<span><%=shop.Point%></span></p>
        <%} %>
        <%if (shop.Weight>0){ %><p>总重量：<span><%=shop.Weight%> KG</span></p><%} %>
    </div>
   <%} %>
    <%if(IsMutiCash==true){ %>
    <div class="basketbtn">
        <a href="javascript:void(0)" onclick="location.href='<%=URL("P_CheckOut",shop.Shop.id) %>'" class="btn btn-7"><s></s>去收银台</a>
    </div>
    <%} %>
<%} %>
<%if(IsMutiCash==false){ %>
<%if (basket.Shops.Count > 1){%>
    <div class="money">
        <%if (basket.Money_Cut>0){ %><p>减免：<span><%=FormatMoney(basket.Money_Cut)%></span></p><%} %>
        <p>购买价：<span><%=FormatMoney(basket.Money_Product-basket.Money_Cut)%></span></p>
        <%if(basket.Money_Property>0){ %>
        <p>其它费用：<span><%=FormatMoney(basket.Money_Property)%></span></p>
        <%} %>
        <p>节省：<s><span><%=FormatMoney(basket.Money_Market - basket.Money_Product-basket.Money_Cut)%></span></s></p>
        <%if(basket.Point_Buy>0){ %>
        <p>所需积分：<span><%=basket.Point_Buy%></span></p>
        <%} %>
        <%if(basket.Point>0){ %>
        <p>获得积分：<span><%=basket.Point%></span></p>
        <%} %>
        <%if (basket.Weight>0){ %><p>总重量：<span><%=basket.Weight%> KG</span></p><%} %>
    </div>
<%} %>
<%} %>
<%if(basket.Money_Tax>0){ %>
    <div class="money">
        <p>税金：<span><%=FormatMoney(basket.Money_Tax)%></span></p>
    </div>
<%} %>
<div class="basketbtn">
    <a href="javascript:void(0)" onclick="javascript:history.back();" class="btn btn-11"><s></s>继续购物</a>
    <a href="javascript:void(0)" onclick="UserProduct_Del('all',142);" class="btn btn-11"><s></s>清空购物车</a>
    <%if(IsMutiCash==false){ %>
    <a href="<%=URL("P_CheckOut","") %>" class="btn btn-7"><s></s>去收银台</a>
    <%} %>
</div>
<%} %>
</div>
<script type="text/javascript">
    function UserBasket_Edit() {
        var postData = GetFormJsonData("Basket");
        var url = path+"/ajax/ajax_user.aspx?__Action=UserBasket_Edit";
        RequestAjax(url, postData, function () { MsgBoxClose("?", ""); });
    }
    function UserProduct_Edit(id, type, num,action,limit) {
        limit=limit==undefined?0:limit;
        num=num==undefined?0:num;
        if(limit>0)
        {
            if(num>limit){
                $("BasketCount"+id).val(limit);
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

    
</body>
</html><div style="width:100%;text-align:center;font-size:12px;color:#999">Powered by <a style="font-size:12px;color:#00497f" href="http://www.lebi.cn/support/license/?url=" target="_blank" title="LebiShop多语言网店系统">LebiShop</a> V<%=SYS.Version%>.<%=SYS.Version_Son%></div>
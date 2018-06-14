<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_Basket" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",8,"CN","P_Basket"); %>

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
<meta name="CurrentExchangeRate" content="<%=CurrentCurrency.ExchangeRate %>" />
<meta name="CurrentLanguage" content="<%=CurrentLanguage.Code %>" />
<meta name="generator" content="LebiShop V<%=SYS.Version+"."+SYS.Version_Son %>" />
<meta name="copyright" content="2003-<%=DateTime.Now.Year %> lebi.cn" />
<script type="text/javascript">var path = "<%=WebPath %>";var sitepath = "/";var langpath = "/";</script>
<script src="http://192.168.1.188/Theme/system/wap/js/jquery.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="http://192.168.1.188/Theme/system/wap/css/system.css" />
<script src="<%=WebPath %>/ajax/js.aspx" type="text/javascript"></script>
<script src="http://192.168.1.188/Theme/system/wap/js/main.js" type="text/javascript"></script>
<script src="http://192.168.1.188/Theme/system/wap/js/messagebox.js" type="text/javascript"></script>
<script src="http://192.168.1.188/Theme/system/wap/js/my97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script src="http://192.168.1.188/Theme/system/wap/js/jquery-ui.min.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="http://192.168.1.188/Theme/system/wap/js/jqueryuicss/redmond/jquery-ui.css" />
<link rel="stylesheet" type="text/css" href="http://192.168.1.188/theme/wap/css/css.css" />
<link rel="stylesheet" type="text/css" href="http://192.168.1.188/theme/wap/css/<%=CurrentLanguage.Code %>.css" />

    
</head>
<body class="default">
    
<div id="header" class="clearfix">
    <div class="logo">

<a href="/"><img src="<%=Image(Lang(SYS.Logoimg)) %>" alt="<%=Lang(SYS.Name)%>" title="<%=Lang(SYS.Name)%>" /></a>
</div>
    <ul class="toplink">
		<li><a href="#search" class="btnSearch"></a></li>
        
        <li><a href="<%=URL("P_Basket", "")%>" class="btnCart"><em id="cart_items"><%=Basket_Product_Count() %></em></a></li>
    </ul>
</div>
<div class="mhead clearfix">
	<a href="javascript:history.go(-1);" class="a-back"><span>返回</span></a>
	<h2><%=ThemePageMeta("P_Basket","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>

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
            <th style="width:50px" valign="top" rowspan="3"><img src="<%=Image(model.ImageSmall)%>" width="50" height="50" class="picb"></th>
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
            <br /><s><%=FormatMoney(model.Price_Market) %></s>
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
            <th style="width:50px" valign="top" rowspan="2"><img src="<%=Image(model.ImageSmall)%>" width="50" height="50" class="picb"></th>
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
        <%if (shop.Money_Cut>0){ %>减免：<span><%=FormatMoney(shop.Money_Cut)%></span>&nbsp;&nbsp;<%} %>
        购买价：<span><%=FormatMoney(shop.Money_Product-shop.Money_Cut)%></span>&nbsp;&nbsp;
        <%if(shop.Money_Property>0){ %>
        其它费用：<span><%=FormatMoney(shop.Money_Property)%></span>&nbsp;&nbsp;
        <%} %>
        节省：<s><span><%=FormatMoney(shop.Money_Market - shop.Money_Product-shop.Money_Cut)%></span></s>&nbsp;&nbsp;
        <%if(shop.Point_Buy>0){ %>
        所需积分：<span><%=shop.Point_Buy%></span>&nbsp;&nbsp;
        <%} %>
        <%if(shop.Point>0){ %>
        获得积分：<span><%=shop.Point%></span>&nbsp;&nbsp;
        <%} %>
        <%if (shop.Weight>0){ %>总重量：<span><%=shop.Weight%> KG</span><%} %>
    </div>
   <%} %>
</div>
<%if(IsMutiCash==true){ %>
<div class="basketbtn">
    <a href="javascript:void(0)" onclick="location.href='<%=URL("P_CheckOut",shop.Shop.id) %>'" class="btn btn-7"><s></s>去收银台</a>
</div>
<%} %>

<%} %>
<%if(IsMutiCash==false){ %>
<%if (basket.Shops.Count > 1){%>
    <div class="money">
        <%if (basket.Money_Cut>0){ %>减免：<span><%=FormatMoney(basket.Money_Cut)%></span>&nbsp;&nbsp;<%} %>
        购买价：<span><%=FormatMoney(basket.Money_Product-basket.Money_Cut)%></span>&nbsp;&nbsp;
        <%if(basket.Money_Property>0){ %>
        其它费用：<span><%=FormatMoney(basket.Money_Property)%></span>&nbsp;&nbsp;
        <%} %>
        节省：<s><span><%=FormatMoney(basket.Money_Market - basket.Money_Product-basket.Money_Cut)%></span></s>&nbsp;&nbsp;
        <%if(basket.Point_Buy>0){ %>
        所需积分：<span><%=basket.Point_Buy%></span>&nbsp;&nbsp;
        <%} %>
        <%if(basket.Point>0){ %>
        获得积分：<span><%=basket.Point%></span>&nbsp;&nbsp;
        <%} %>
        <%if (basket.Weight>0){ %>总重量：<span><%=basket.Weight%> KG</span><%} %>
    </div>
<%} %>
<%} %>
<div class="basketbtn">
    <a href="javascript:void(0)" onclick="javascript:history.back();" class="btn btn-11"><s></s>继续购物</a>
    <a href="javascript:void(0)" onclick="UserProduct_Del('all',142);" class="btn btn-11"><s></s>清空购物车</a>
    <%if(IsMutiCash==false){ %>
    <a href="javascript:void(0)" onclick="location.href='<%=URL("P_CheckOut","") %>'" class="btn btn-7"><s></s>去收银台</a>
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
        <div class="search">
	        <a name="search"></a>
	        

<script type="text/javascript">
$(function () {
    blurInput('#keyword', '<%if (Rstring("Keyword")!=""){ %><%=Rstring("Keyword")%><%}else{%><%Table="Lebi_Searchkey";Where="Type=1";Order="Sort desc,id desc";PageSize=1;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int zpeQ_index=1;
List<Lebi_Searchkey> zpeQs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey zpeQ in zpeQs){%><%=Lang(zpeQ.Name)%><%zpeQ_index++;}%><%} %>');
    $("#keyword").click(function () {
        $("#keyword").val();
        $("#keywords").show();
    })
    $("#keywords").hover(function () {
        $("#keywords").show();
    }, function () {
        $("#keywords").hide();
    });
})
</script>
<div id="searchform">
<div class="searchform">
<input id="keyword" value="" type="text" name="keyword" onkeydown="if(event.keyCode==13){search();}" />
<input type="button" value="搜索" class="button" onclick="search();" />
<script type="text/javascript">
    function search() {
        var url = "<%=URL("P_Search","[key]") %>";
        location.href = url.replace("[key]",escape($("#keyword").val()));
    }
</script>
</div>
<div id="keywords">
    <div class="mbox clearfix">
    <div class="searchkeyword">
    <div class="mt">
        <h2>热搜排行</h2>
    </div>
    <div class="mc clearfix">
    <ul class="text">
        <%Table="Lebi_Searchkey";Where="";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int yrzR_index=1;
List<Lebi_Searchkey> yrzRs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey yrzR in yrzRs){%>
        <li><%if (yrzR.Type==1){ %><a href="<%=URL("P_Search",""+Lang(yrzR.Name)+"") %>"><%}else{ %><a href="<%=yrzR.URL%>"><%} %><%=Lang(yrzR.Name)%></a></li>
        <%yrzR_index++;}%>
    </ul>
    </div>
    </div>
    </div>
    <div class="mbox clearfix">
    <div class="searchbrand">
    <div class="mt">
        <h2>品牌推荐</h2>
    </div>
    <div class="mc clearfix">
    <ul class="text">
        <%Table="Lebi_Brand";Where="IsRecommend=1";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Brand.Counts(Where);int OtuW_index=1;
List<Lebi_Brand> OtuWs = B_Lebi_Brand.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Brand OtuW in OtuWs){%>
        <li><a href="<%=URL("P_Brand",OtuW.id)%>" title="<%=Lang(OtuW.Name) %>"><%=Lang(OtuW.Name) %></a></li>
        <%OtuW_index++;}%>
    </ul>
    </div>
    </div>
    </div>
</div>
</div>

        </div>
        <div class="footmenu">
	        

<div class="nbbox clearfix">
<div class="quickmenu">
<div class="mc clearfix">
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_Index", "")%>">首页</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_Basket", "")%>">购物车 (<em><%=Basket_Product_Count() %></em>)</a></h3><s></s></span></div>
   <%if(CurrentUser.id>0){ %>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserCenter", "")%>">会员中心</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserOrders", "")%>">我的订单</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserCard", "")%>">我的卡券</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserLike", "")%>">我的收藏</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserOftenBuy", "")%>">常购清单</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserComment", "")%>">商品评价 (<em><%=Count_Comment(0) %></em>)</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserAsk", "")%>">商品咨询 (<em><%=Count_ProductAsk(0) %></em>)</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserMessage","0")%>">站内信 (<em><%=Count_Message(0) %></em>)</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserProfile", "")%>">资料管理</a></h3><s></s></span></div>
   <%if (Shop.Bussiness.B_API.Check("plugin_agent")){ %>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserAgent","")%>">推广佣金</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserAgentMoney","")%>">佣金查询</a></h3><s></s></span></div>
   <%} %>
   <%}else{ %>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_Login", "")%>">会员登录</a></h3><s></s></span></div>
   <%} %>
	<%Table="Lebi_Page";Where="Node_id="+Node("FootMenu").id+" and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int NVvg_index=1;
List<Lebi_Page> NVvgs = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page NVvg in NVvgs){%>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("","",NVvg.url)%>"><%=NVvg.Name%></a></h3><s></s></span></div>
	<%NVvg_index++;}%>
    <div class="item last"><span class="itemname"><h3><a href="">完整网站</a></h3><s></s></span></div>
</div>
</div>
</div>

        </div>
    </div>
    
<div id="footer" class="clearfix">
    <div class="copyright">
        <%=Lang(SYS.Copyright) %>
    </div>
    <div class="lang">
        

<div class="language">
<%List<Shop.Model.Lebi_Language> nxqas=Languages();RecordCount=nxqas.Count;int nxqa_index=1;
foreach (Shop.Model.Lebi_Language nxqa in nxqas){%>
<a <%if (nxqa_index==RecordCount){%>class="last"<%} %> href="javascript:SetLanguage(<%=nxqa.id%>,'<%=nxqa.Code%>','<%=nxqa.Path%>');"><img src="<%=Image(nxqa.ImageUrl) %>" title="<%=nxqa.Name%>" /><%=nxqa.Name%></a>
<%nxqa_index++;}%>
</div>

    </div>
    <div class="currency">
        

<div class="currency"><ul class="dropcurrency"><li class="currency_li"><a class="noclick"><span>币种：</span><s><%=CurrentCurrency.Code %></s></a><dl class="currency_li_content">
<%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int bqTp_index=1;
List<Lebi_Currency> bqTps = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency bqTp in bqTps){%>
<dd <%if (bqTp_index==RecordCount){%>class="last"<%} %>><a href="javascript:SetCurrency(<%=bqTp.id%>,'<%=bqTp.Code%>',<%=bqTp.ExchangeRate%>,'<%=bqTp.Msige%>');"><%=bqTp.Code%></a></dd>
<%bqTp_index++;}%>
</dl></li></ul></div>

    </div>
    
<div id="footnav">
<ul>
<li><a href="<%=URL("P_Index", "")%>"><img src="http://192.168.1.188/Theme/system/wap/images/home.png" alt="首页" /><span>首页</span></a></li>
<li><a href="<%=URL("P_ProductCommentIndex", "")%>"><img src="http://192.168.1.188/Theme/system/wap/images/message.png" alt="晒单" /><span>晒单</span></a></li>
<li><a href="<%=URL("P_Basket", "")%>"><img src="http://192.168.1.188/Theme/system/wap/images/cart.png" alt="购物车" /><span>购物车</span></a></li>
<li><a href="<%=URL("P_UserCenter", "")%>"><img src="http://192.168.1.188/Theme/system/wap/images/user.png" alt="会员中心" /><span>会员中心</span></a></li>
</ul>
</div>

</div>


    
</body>
</html>
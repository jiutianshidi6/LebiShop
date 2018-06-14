<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_Brand" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",8,"CN","P_Brand"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_Brand","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_Brand","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_Brand","description")%>" />
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
	<h2><%=ThemePageMeta("P_Brand","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>

    <div class="body">
        <div class="bodymain">
            


<div class="nbbox clearfix">
<div class="mt">
    <h2><%=Lang(brand.Name)%> 品牌介绍</h2>
</div>
<div class="mc">
    <div class="tips"><%=Lang(brand.Description)%></div>
</div>
</div>



<div class="nbbox clearfix">
<div id="filter">
	<div class="fore1">
		<dl class="order">
			<dt>排序：</dt>
			<dd <%if(sort == "1" || sort == "1a"){ %>class="curr <%if(sort == "1"){ %>up<%}else if(sort == "1a"){ %>down<%} %>"<%} %>><a href="<%=URL("P_Brand",""+id+","+cid+","+list+",1"+ordertmp+"") %>">销量</a><b></b></dd>
			<dd <%if(sort == "2" || sort == "2a"){ %>class="curr <%if(sort == "2"){ %>up<%}else if(sort == "2a"){ %>down<%} %>"<%} %>><a href="<%=URL("P_Brand",""+id+","+cid+","+list+",2"+ordertmp+"") %>">价格</a><b></b></dd>
			<dd <%if(sort == "3" || sort == "3a"){ %>class="curr <%if(sort == "3"){ %>up<%}else if(sort == "3a"){ %>down<%} %>"<%} %>><a href="<%=URL("P_Brand",""+id+","+cid+","+list+",3"+ordertmp+"") %>">评价数</a><b></b></dd>
			<dd <%if(sort == "4" || sort == "4a"){ %>class="curr <%if(sort == "4"){ %>up<%}else if(sort == "4a"){ %>down<%} %>"<%} %>><a href="<%=URL("P_Brand",""+id+","+cid+","+list+",4"+ordertmp+"") %>">上架时间</a><b></b></dd>
		</dl>
        <div class="list-cutover">
			<a id="list-unselected"  href="<%=URL("P_Brand",""+id+","+cid+",2,"+ sort) %>" class="modfiy-url list-unselected <%=list=="2"?"list-curr":"" %>"><b></b>列表</a>
			<a id="grid-unselected"  href="<%=URL("P_Brand",""+id+","+cid+",1,"+ sort) %>" class="modfiy-url grid-unselected <%=(list=="1" || list=="")?"grid-curr":"" %>"><b></b>网格</a>
		</div>
		<div class="pagin pagin-m" id="top_pagi">
			<%=HeadPage%>
		</div>
		<div class="total">
			<span>共 <strong><%=B_Lebi_Product.Counts(where) %></strong> 个商品</span>
		</div>
		<span class="clr"></span>
	</div>
</div>
<div class="mc clearfix">
    <div class="productlist"><ul>
        <%foreach (Shop.Model.Lebi_Product pro in products)
        {
        if (list == "" || list == "1"){ %>
        <li class="grid">
            <div class="proimg">
                <p><a href="<%=URL("P_Product",pro.id) %>"><img border="0" src="<%=Image(pro,"medium")%>" alt="<%=Lang(pro.Name) %>" title="<%=Lang(pro.Name) %>" /></a></p></div>
            <div class="proname">
                <a href="<%=URL("P_Product",pro.id) %>" title="<%=Lang(pro.Name) %>"><%=Lang(pro.Name) %></a>
            </div>
            <div class="proinfo">
            <div class="marketprice"><i>市场价：</i><strong><%=FormatMoney(pro.Price_Market) %></strong></div>
            <%if (pro.Type_id_ProductType == 321){ %>
            <div class="buyprice"><i>抢购价：</i><strong><%=FormatMoney(pro.Price_Sale) %></strong><em><%=Discount(pro.Price_Market,pro.Price_Sale) %>% 折</em></div>
			<%}else{%>
			<div class="buyprice"><i><%=Lang(CurrentUserLevel.PriceName) %>：</i><strong><%=FormatMoney(ProductPrice(pro)) %></strong></div>
            <%} %>
            <div class="probtn">
                <%if(ProductStock(pro)<1){ %>
                <strong>已售罄</strong>
                <%}else{ %>
                <a href="javascript:void(0)" onclick="UserProduct_Edit(<%=pro.id%>,142,$('#pro_num<%=pro.id%>').val());" class="buy btn btn-12"><s></s>加入购物车</a>
                <%} %>
            </div>
            </div>
        </li>
        <%}else{ %>
        <li class="list">
            <div class="proimg">
                <p><a href="<%=URL("P_Product",pro.id) %>"><img border="0" src="<%=Image(pro,"medium")%>" alt="<%=Lang(pro.Name) %>" title="<%=Lang(pro.Name) %>" /></a></p></div>
            <div class="proname">
                <a href="<%=URL("P_Product",pro.id) %>" title="<%=Lang(pro.Name) %>"><%=Lang(pro.Name) %></a>
            </div>
            <div class="proinfo">
            <div class="marketprice"><i>市场价：</i><strong><%=FormatMoney(pro.Price_Market) %></strong></div>
            <%if (pro.Type_id_ProductType == 321){ %>
            <div class="buyprice"><i>抢购价：</i><strong><%=FormatMoney(pro.Price_Sale) %></strong><em><%=Discount(pro.Price_Market,pro.Price_Sale) %>% 折</em></div>
			<%}else{%>
			<div class="buyprice"><i><%=Lang(CurrentUserLevel.PriceName) %>：</i><strong><%=FormatMoney(ProductPrice(pro)) %></strong></div>
            <%} %>
            <div class="introduction"><%=Lang(pro.Introduction)%></div>
            <div class="probtn">
                <%if(ProductStock(pro)<1){ %>
                <strong>已售罄</strong>
                <%}else{ %>
                <a href="javascript:void(0)" onclick="UserProduct_Edit(<%=pro.id%>,142,$('#pro_num<%=pro.id%>').val());" class="buy btn btn-12"><s></s>加入购物车</a><br />
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
<div class="footpage">
    <%=FootPage%>
</div>
</div>


        </div>
        <div class="search">
	        <a name="search"></a>
	        

<script type="text/javascript">
$(function () {
    blurInput('#keyword', '<%if (Rstring("Keyword")!=""){ %><%=Rstring("Keyword")%><%}else{%><%Table="Lebi_Searchkey";Where="Type=1";Order="Sort desc,id desc";PageSize=1;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int FYnG_index=1;
List<Lebi_Searchkey> FYnGs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey FYnG in FYnGs){%><%=Lang(FYnG.Name)%><%FYnG_index++;}%><%} %>');
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
        <%Table="Lebi_Searchkey";Where="";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int MEbk_index=1;
List<Lebi_Searchkey> MEbks = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey MEbk in MEbks){%>
        <li><%if (MEbk.Type==1){ %><a href="<%=URL("P_Search",""+Lang(MEbk.Name)+"") %>"><%}else{ %><a href="<%=MEbk.URL%>"><%} %><%=Lang(MEbk.Name)%></a></li>
        <%MEbk_index++;}%>
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
        <%Table="Lebi_Brand";Where="IsRecommend=1";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Brand.Counts(Where);int eeJC_index=1;
List<Lebi_Brand> eeJCs = B_Lebi_Brand.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Brand eeJC in eeJCs){%>
        <li><a href="<%=URL("P_Brand",eeJC.id)%>" title="<%=Lang(eeJC.Name) %>"><%=Lang(eeJC.Name) %></a></li>
        <%eeJC_index++;}%>
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
	<%Table="Lebi_Page";Where="Node_id="+Node("FootMenu").id+" and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int Hrtq_index=1;
List<Lebi_Page> Hrtqs = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page Hrtq in Hrtqs){%>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("","",Hrtq.url)%>"><%=Hrtq.Name%></a></h3><s></s></span></div>
	<%Hrtq_index++;}%>
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
<%List<Shop.Model.Lebi_Language> jqYds=Languages();RecordCount=jqYds.Count;int jqYd_index=1;
foreach (Shop.Model.Lebi_Language jqYd in jqYds){%>
<a <%if (jqYd_index==RecordCount){%>class="last"<%} %> href="javascript:SetLanguage(<%=jqYd.id%>,'<%=jqYd.Code%>','<%=jqYd.Path%>');"><img src="<%=Image(jqYd.ImageUrl) %>" title="<%=jqYd.Name%>" /><%=jqYd.Name%></a>
<%jqYd_index++;}%>
</div>

    </div>
    <div class="currency">
        

<div class="currency"><ul class="dropcurrency"><li class="currency_li"><a class="noclick"><span>币种：</span><s><%=CurrentCurrency.Code %></s></a><dl class="currency_li_content">
<%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int hJmq_index=1;
List<Lebi_Currency> hJmqs = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency hJmq in hJmqs){%>
<dd <%if (hJmq_index==RecordCount){%>class="last"<%} %>><a href="javascript:SetCurrency(<%=hJmq.id%>,'<%=hJmq.Code%>',<%=hJmq.ExchangeRate%>,'<%=hJmq.Msige%>');"><%=hJmq.Code%></a></dd>
<%hJmq_index++;}%>
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
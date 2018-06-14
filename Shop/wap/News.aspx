<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_News" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",8,"CN","P_News"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_News","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_News","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_News","description")%>" />
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
	<h2><%=ThemePageMeta("P_News","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>

    <div class="body">
        <div class="bodymain">
            


<div class="nbbox clearfix">
<div class="nodelist">
    <div class="mc clearfix">
        <div class="list">
        <ul>
        <%foreach (Shop.Model.Lebi_Page p in pages){%>
        <li><a href="<%=URL("P_NewsDetails",p.id,p.url)%>" title="<%=p.Name%>"><span style="color: <%=p.NameColor%>"><%=p.Name%></span></a><em><%=FormatDate(p.Time_Add)%></em></li>
        <%} %>
        </ul>
        </div>
        <div class="bottom clearfix"><%=PageString%></div>
    </div>
</div>
</div>



<div class="mbox clearfix">
<div class="articletop">
<div class="mt">
    <h2>热门文章</h2>
</div>
<div class="mc clearfix">
    <ul>
        <%Table="Lebi_Page";Where="Node_id in (select id from Lebi_Node where parentid = "+ Node("Info").id +") and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Count_Views desc,id desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int DWuG_index=1;
List<Lebi_Page> DWuGs = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page DWuG in DWuGs){%>
        <li class="text"><a href="<%=URL("P_ArticleDetails",DWuG.id,DWuG.url)%>" title="<%=DWuG.Name%>"><span style="color:<%=DWuG.NameColor%>"><%=DWuG.Name%></span></a></li>
        <%DWuG_index++;}%>
    </ul>
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
<%List<Shop.Model.Lebi_Language> xQvus=Languages();RecordCount=xQvus.Count;int xQvu_index=1;
foreach (Shop.Model.Lebi_Language xQvu in xQvus){%>
<a <%if (xQvu_index==RecordCount){%>class="last"<%} %> href="javascript:SetLanguage(<%=xQvu.id%>,'<%=xQvu.Code%>','<%=xQvu.Path%>');"><img src="<%=Image(xQvu.ImageUrl) %>" title="<%=xQvu.Name%>" /><%=xQvu.Name%></a>
<%xQvu_index++;}%>
</div>

    </div>
    <div class="currency">
        

<div class="currency"><ul class="dropcurrency"><li class="currency_li"><a class="noclick"><span>币种：</span><s><%=CurrentCurrency.Code %></s></a><dl class="currency_li_content">
<%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int lmYh_index=1;
List<Lebi_Currency> lmYhs = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency lmYh in lmYhs){%>
<dd <%if (lmYh_index==RecordCount){%>class="last"<%} %>><a href="javascript:SetCurrency(<%=lmYh.id%>,'<%=lmYh.Code%>',<%=lmYh.ExchangeRate%>,'<%=lmYh.Msige%>');"><%=lmYh.Code%></a></dd>
<%lmYh_index++;}%>
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
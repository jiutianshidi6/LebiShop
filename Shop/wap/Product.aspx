<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_Product" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",8,"CN","P_Product"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_Product","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_Product","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_Product","description")%>" />
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
	<h2><%=ThemePageMeta("P_Product","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>

    <div class="body">
        <div class="bodymain">
            
<div class="productdetail">


<div id="lightBox" class="embed">
	<div class="pagingArea">
		<div id="slider" class="slider">
			<ul>
			</ul>
		</div>
	</div>
</div>
<script type="text/javascript">
<% 
string ims="";
foreach(LBimage image in images){
string temp="{\"img_id\":\"\",\"img_url\":\""+Image(image.original,"medium")+"\",\"thumb_url\":\""+Image(image.original,"medium")+"\",\"img_original\":\""+Image(image.original)+"\",\"img_desc\":\"\"}";
if(ims=="")
    ims=temp;
else
    ims+=","+temp;
} %>
var myarr = [<%=ims %>];
    var promoteItems=new Array();
promoteItems[0]=new Array(); 
promoteItems[0][0] = "<%=Image(product.ImageOriginal,"medium") %>";
promoteItems[0][1] = "<%=Image(product.ImageOriginal,"medium") %>";
                 
for (i = 0; i < myarr.length; i++)
{
    promoteItems[i+1]=new Array(); 
    promoteItems[i+1][0]=myarr[i]["img_url"];
    promoteItems[i+1][1]=myarr[i]["img_original"];                   
}
				
var noImg = 0;
var slider = new Swipe($('#slider')[0],{
	items:promoteItems,
	gestureAllowed:true,//滑动
	tapAllowed:true,	//点击
	zoomingAllowed:true,//浮起 显示指定的大图
    autoPlay:3000

});
</script>



<div id="productinfo"></div>
<script type="text/javascript">
    LoadPage(path+'/inc/product_info.aspx?id=<%=product.id %>','productinfo');
</script>



<script type="text/javascript">
    $(document).ready(function () {
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
        RequestAjax(url, postData, function () { MsgBox(1, "发送成功", "?"); $("#Content").val(""); getasklist(); });
    }
    function getasklist() {
        var url = path + "/inc/product_ask.aspx?id=<%=product.id %>&product_id=<%=product.Product_id %>";
        LoadPage(url, 'asklist');
    }
    function getcommentlist() {
        var url = path + "/inc/product_comment.aspx?id=<%=product.id %>&product_id=<%=product.Product_id %>";
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
            详细介绍</span></a></li>
        <li><a href="javascript:void(0);"><span>
            商品评价</span></a></li>
        <li><a href="javascript:void(0);"><span>
            商品咨询</span></a></li>
        <li><a href="javascript:void(0);"><span>
            相关商品</span></a></li>
    </ul>
</div>
<div class="product-cont">
    <div style="display: block" class="cont">
        <%if (CurrentSite.IsMobile==0){ %>
            <%=Lang(product.Description) %>
        <%}else{ %>
            <%=Lang(product.MobileDescription) %>
            <%if (Lang(product.MobileDescription)==""){ %><%=Lang(product.Description) %><%} %>
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
                        <a href="javascript:void(0)" onclick="ask();" class="btn btn-11"><s></s>发送</a>
                    </td>
                </tr>
            </tbody>
        </table>
        <%}else{%>
        <div class="mes">您还没有登录，请登录后咨询。</div>
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
        <div class="search">
	        <a name="search"></a>
	        

<script type="text/javascript">
$(function () {
    blurInput('#keyword', '<%if (Rstring("Keyword")!=""){ %><%=Rstring("Keyword")%><%}else{%><%Table="Lebi_Searchkey";Where="Type=1";Order="Sort desc,id desc";PageSize=1;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int zadw_index=1;
List<Lebi_Searchkey> zadws = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey zadw in zadws){%><%=Lang(zadw.Name)%><%zadw_index++;}%><%} %>');
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
        <%Table="Lebi_Searchkey";Where="";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int bCNz_index=1;
List<Lebi_Searchkey> bCNzs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey bCNz in bCNzs){%>
        <li><%if (bCNz.Type==1){ %><a href="<%=URL("P_Search",""+Lang(bCNz.Name)+"") %>"><%}else{ %><a href="<%=bCNz.URL%>"><%} %><%=Lang(bCNz.Name)%></a></li>
        <%bCNz_index++;}%>
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
        <%Table="Lebi_Brand";Where="IsRecommend=1";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Brand.Counts(Where);int GUzx_index=1;
List<Lebi_Brand> GUzxs = B_Lebi_Brand.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Brand GUzx in GUzxs){%>
        <li><a href="<%=URL("P_Brand",GUzx.id)%>" title="<%=Lang(GUzx.Name) %>"><%=Lang(GUzx.Name) %></a></li>
        <%GUzx_index++;}%>
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
	<%Table="Lebi_Page";Where="Node_id="+Node("FootMenu").id+" and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int LLRO_index=1;
List<Lebi_Page> LLROs = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page LLRO in LLROs){%>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("","",LLRO.url)%>"><%=LLRO.Name%></a></h3><s></s></span></div>
	<%LLRO_index++;}%>
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
<%List<Shop.Model.Lebi_Language> NuJds=Languages();RecordCount=NuJds.Count;int NuJd_index=1;
foreach (Shop.Model.Lebi_Language NuJd in NuJds){%>
<a <%if (NuJd_index==RecordCount){%>class="last"<%} %> href="javascript:SetLanguage(<%=NuJd.id%>,'<%=NuJd.Code%>','<%=NuJd.Path%>');"><img src="<%=Image(NuJd.ImageUrl) %>" title="<%=NuJd.Name%>" /><%=NuJd.Name%></a>
<%NuJd_index++;}%>
</div>

    </div>
    <div class="currency">
        

<div class="currency"><ul class="dropcurrency"><li class="currency_li"><a class="noclick"><span>币种：</span><s><%=CurrentCurrency.Code %></s></a><dl class="currency_li_content">
<%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int aKwj_index=1;
List<Lebi_Currency> aKwjs = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency aKwj in aKwjs){%>
<dd <%if (aKwj_index==RecordCount){%>class="last"<%} %>><a href="javascript:SetCurrency(<%=aKwj.id%>,'<%=aKwj.Code%>',<%=aKwj.ExchangeRate%>,'<%=aKwj.Msige%>');"><%=aKwj.Code%></a></dd>
<%aKwj_index++;}%>
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
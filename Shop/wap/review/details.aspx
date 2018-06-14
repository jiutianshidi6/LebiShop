<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_ProductCommentDetails" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",8,"CN","P_ProductCommentDetails"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_ProductCommentDetails","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_ProductCommentDetails","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_ProductCommentDetails","description")%>" />
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

    
<script type="text/javascript">
    $(function () {
        $("#review_thumbImg").find("a").click(function () {
            var url = $(this).data("url");
            var type = $(this).data("type");
            enlarge(url);
            $("#review_thumbImg").find("li").removeClass("cur");
            $(this).parent("li").addClass('cur');

        });
        $("#review_thumbImg").find("a").eq(0).trigger("click");
    })
    //显示大图
    function enlarge(url) {
        $("#mediaShow").html("<a href='javascript:void(0);'><img src=\"" + url + "\" alt=\"\" /></a>");
    }
    function Comment() { 
        if (!CheckForm("shop"))
            return false;
        var postData = {"comment":$('#comment').val()};
        var url = path+"/Ajax/Ajax_userin.aspx?__Action=Comment_reply&id=<%=comment.id %>";
        RequestAjax(url, postData, function () { MsgBox(1, "<%=Tag("操作成功")%>", "?") });
    }
</script>

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
	<h2><%=ThemePageMeta("P_ProductCommentDetails","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>

    <div class="body">
        <div class="bodymain">
            
    <%if(DefaultImage!=""){ %>
    <div class="mbox">
        <div class="mt">
            <h2>
                <%=Lang(product.Name) %></h2>
        </div>
        <div class="mediaShow" id="mediaShow">
            <a href="javascript:void(0);"><img alt="" src="<%=DefaultImage %>"></a>
        </div>
        <div class="mediaChoice">
            <ul id="review_thumbImg" class="review_thumbImg">
                <%for(int imgi=1;imgi<smalls.Count();imgi++){ %>
                <li class=""><a data-url="<%=bigs[imgi] %>" data-type="1" href="javascript:void(0);">
                    <img width="50" src="<%=smalls[imgi] %>">
                </a></li>
                <%} %>
            </ul>
        </div>
        <div class="clear">
        </div>
    </div>
    <%} %>
    <div class="mbox">
        <div class="mt">
            <h2>
                评论</h2>
        </div>
        <div class="img_user_info">
            <strong>
                <%=comment.User_UserName %></strong>
            <p>
                <%=comment.Content %></p>
        </div>
        <div class="replyBox">
            <textarea placeholder="评论内容..." id="comment" name="comment" shop="true" min="notnull"></textarea>
            <div>
                <a class="msgPost" href="javascript:void(0);" onclick="Comment();">提交</a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="review_replyList">
            <ul>
                <%foreach(Lebi_Comment com in comments){ %>
                <li>
                    <div class="item">
                        <h5>
                            <%=com.User_UserName %></h5>
                        <p class="gray">
                            <%=com.Time_Add %></p>
                        <p>
                            <%=com.Content %></p>
                    </div>
                </li>
                <%} %>
            </ul>
        </div>
    </div>
    <div class="mbox clearfix">
        <div class="viewhistory">
            <div class="mt">
                <h2>
                    商品信息</h2>
            </div>
            <div class="mc clearfix">
                <ul class="image">
                    <li>
                        <div class="image">
                            <p>
                                <a href="<%=URL("P_Product",product.id) %>">
                                    <img src="<%=ProImg(product.ImageOriginal,"small") %>" title="<%=Lang(product.Name) %>" /></a></p>
                        </div>
                        <div class="name">
                            <a href="<%=URL("P_Product",product.id) %>">
                                <%=Lang(product.Name) %></a>
                        </div>
                        <div class="price">
                            <%=FormatMoney(ProductPrice(product)) %>
                        </div>
                        <div class="addbasket">
                            <a href="javascript:void(0);" onclick="UserProduct_Edit(<%=product.id %>,142,1);">加入购物车</a>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="mbox clearfix">
        <div class="mt">
            <h2>其它</h2>
        </div>
        <ul class="related_reviewLast">
            <%foreach(Lebi_Comment pc in productcomments){ %>
            <li>
                <p class="gray related_titel pb5 f14">
                    <%=pc.User_UserName %></p>
                <p>
                </p>
                <p><a href="<%=URL("P_ProductCommentDetails",pc.id) %>"><%=pc.Content %></a></p>
            </li>
            <%} %>
                   
        </ul>
        <p class="related_bottom">
            <a class="gray" href="<%=URL("P_Product",product.id) %>">更多 &gt;&gt;</a>
        </p>
    </div>

        </div>
        <div class="search">
	        <a name="search"></a>
	        

<script type="text/javascript">
$(function () {
    blurInput('#keyword', '<%if (Rstring("Keyword")!=""){ %><%=Rstring("Keyword")%><%}else{%><%Table="Lebi_Searchkey";Where="Type=1";Order="Sort desc,id desc";PageSize=1;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int gOGr_index=1;
List<Lebi_Searchkey> gOGrs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey gOGr in gOGrs){%><%=Lang(gOGr.Name)%><%gOGr_index++;}%><%} %>');
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
        <%Table="Lebi_Searchkey";Where="";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int bSTp_index=1;
List<Lebi_Searchkey> bSTps = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey bSTp in bSTps){%>
        <li><%if (bSTp.Type==1){ %><a href="<%=URL("P_Search",""+Lang(bSTp.Name)+"") %>"><%}else{ %><a href="<%=bSTp.URL%>"><%} %><%=Lang(bSTp.Name)%></a></li>
        <%bSTp_index++;}%>
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
        <%Table="Lebi_Brand";Where="IsRecommend=1";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Brand.Counts(Where);int ADeF_index=1;
List<Lebi_Brand> ADeFs = B_Lebi_Brand.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Brand ADeF in ADeFs){%>
        <li><a href="<%=URL("P_Brand",ADeF.id)%>" title="<%=Lang(ADeF.Name) %>"><%=Lang(ADeF.Name) %></a></li>
        <%ADeF_index++;}%>
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
	<%Table="Lebi_Page";Where="Node_id="+Node("FootMenu").id+" and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int WHri_index=1;
List<Lebi_Page> WHris = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page WHri in WHris){%>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("","",WHri.url)%>"><%=WHri.Name%></a></h3><s></s></span></div>
	<%WHri_index++;}%>
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
<%List<Shop.Model.Lebi_Language> UiqTs=Languages();RecordCount=UiqTs.Count;int UiqT_index=1;
foreach (Shop.Model.Lebi_Language UiqT in UiqTs){%>
<a <%if (UiqT_index==RecordCount){%>class="last"<%} %> href="javascript:SetLanguage(<%=UiqT.id%>,'<%=UiqT.Code%>','<%=UiqT.Path%>');"><img src="<%=Image(UiqT.ImageUrl) %>" title="<%=UiqT.Name%>" /><%=UiqT.Name%></a>
<%UiqT_index++;}%>
</div>

    </div>
    <div class="currency">
        

<div class="currency"><ul class="dropcurrency"><li class="currency_li"><a class="noclick"><span>币种：</span><s><%=CurrentCurrency.Code %></s></a><dl class="currency_li_content">
<%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int BQuw_index=1;
List<Lebi_Currency> BQuws = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency BQuw in BQuws){%>
<dd <%if (BQuw_index==RecordCount){%>class="last"<%} %>><a href="javascript:SetCurrency(<%=BQuw.id%>,'<%=BQuw.Code%>',<%=BQuw.ExchangeRate%>,'<%=BQuw.Msige%>');"><%=BQuw.Code%></a></dd>
<%BQuw_index++;}%>
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
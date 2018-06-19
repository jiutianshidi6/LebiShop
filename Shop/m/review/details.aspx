<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_ProductCommentDetails" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_ProductCommentDetails"); %>

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
    
<div class="mhead clearfix">
	<a href="javascript:history.go(-1);" class="a-back"><span>返回</span></a>
	<h2 id="pagename"><%=ThemePageMeta("P_ProductCommentDetails","title")%></h2>
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
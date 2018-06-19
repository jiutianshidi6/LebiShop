<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_UserAsk" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_UserAsk"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_UserAsk","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_UserAsk","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_UserAsk","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_UserAsk","title")%></h2>
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
          
    

<div class="nbbox clearfix">
<div class="user">
    <div class="searchbox clearfix">
        <select id="status">
            <option value="">┌ 状态</option>
            <option value="0" <%if (status == 0){%>selected<%} %>>全部</option>
            <%foreach (Shop.Model.Lebi_Type ctype in types){%>
            <option value="<%=ctype.id %>" <%if (status == ctype.id){%>selected<%} %>><%=Tag(ctype.Name)%></option>
            <%} %>
        </select>
        <input type="text" id="key" name="key" class="input-query" value="<%=key %>" onkeydown="if(event.keyCode==13){search_();}" />
        <a href="javascript:void(0)" onclick="search_();" class="btn btn-12"><s></s>查询</a>
    </div>
    <div class="table-list loadlist">
    <%foreach (Shop.Model.Lebi_Comment c in comments){%>
    <div class="loadli">
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <th style="width:50px" valign="top"><% if (GetProduct(c.Keyid).ImageOriginal == ""){ %>&nbsp;<%}else{ %><a href="<%=URL("P_Product",c.Keyid) %>"><img style="height: 50px;width: 50px;vertical-align:middle" src="<%=Image(GetProduct(c.Keyid).ImageOriginal,50,50) %>" /></a><%} %></th>
        <th style="text-align:left" valign="top"><a href="<%=URL("P_Product",c.Keyid) %>"><%=Lang(GetProduct(c.Keyid).Name)%></a></th>
        <th style="width:80px" valign="top"><%=TypeName(c.Status) %></th>
    </tr>
    <tr>
        <td colspan="3"><%=c.Content.Replace("\r\n", "<br/>")%><br /><%=FormatTime(c.Time_Add) %></td>
    </tr>
    <%
    List<Shop.Model.Lebi_Comment> cr = Shop.Bussiness.B_Lebi_Comment.GetList("Parentid = "+ c.id +"", "id desc");
    foreach (Shop.Model.Lebi_Comment creply in cr)
    {
    %>
    <tr><td colspan="3">客服回复：<%=creply.Content%> <em><%=FormatTime(creply.Time_Add)%></em></td></tr>
    <%} %>
    </table>
    </div>
    <%} %>
    </div>
    <%if (CurrentSite.IsMobile==0){ %>
        <div class="bottom clearfix"><div class="left"></div><div class="right"><%=PageString%></div></div>
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
            ias.extension(new IASSpinnerExtension({ html: "<div class=\"loadinginfo\"><img src=\"{src}\" />&nbsp;加载中</div>" }));
            ias.extension(new IASTriggerExtension({ text: '加载更多', offset: 100, html: "<div class=\"loadinginfo more\"><p>{text}</p></div>" }));
            ias.extension(new IASNoneLeftExtension({
                text: '', html: ""
            }));
        });
    </script>
    <%}%>
</div>
</div>
<script type="text/javascript">
    function search_() {
        var key = $("#key").val();
        var status = $("#status").val();
        window.location = "?key=" + escape(key) + "&status=" + status;
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
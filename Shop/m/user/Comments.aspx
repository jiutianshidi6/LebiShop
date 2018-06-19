<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_UserComment" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_UserComment"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_UserComment","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_UserComment","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_UserComment","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_UserComment","title")%></h2>
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
          
    

<link rel="stylesheet" type="text/css" href="<%=PageJS("lightbox/lightbox.min.css")%>" />
<div class="nbbox clearfix">
<div class="user">
    <ul class="tablist">
        <li <%if (type == 0){Response.Write("class=\"selected\"");} %>><a href="<%=URL("P_UserComment","0","")%>"><span>已评价商品</span></a></li>
        <li <%if (type == 1){Response.Write("class=\"selected\"");} %>><a href="<%=URL("P_UserComment","1","")%>"><span>待评价商品<em>(<%=Count_Comment(0) %>)</em></span></a></li>
    </ul>
    <div class="searchbox clearfix">
        <select id="status">
            <option value="">┌ 状态</option>
            <option value="0" <%if (status == 0){%>selected<%} %>>全部</option>
            <%foreach (Shop.Model.Lebi_Type t in types){%>
            <option value="<%=t.id %>" <%if (status == t.id){%>selected<%} %>><%=Tag(t.Name)%></option>
            <%} %>
        </select>
        <input type="text" id="key" name="key" class="input-query" value="<%=key %>" onkeydown="if(event.keyCode==13){search_();}" />
        <a href="javascript:void(0)" onclick="search_();" class="btn btn-12"><s></s>查询</a>
    </div>
    <%if (type == 0){ %>
    <div class="table-list loadlist">
    <%foreach (Shop.Model.Lebi_Comment c in comments)
    {%>
    <div class="loadli">
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <th style="width:50px" valign="top" rowspan="2"><% if (GetProduct(c.Keyid).ImageOriginal == ""){ %>&nbsp;<%}else{ %><a href="<%=URL("P_Product",c.Keyid) %>"><img style="height: 50px;width: 50px;vertical-align:middle" src="<%=Image(GetProduct(c.Keyid).ImageOriginal,50,50) %>" /></a><%} %></th>
        <th style="text-align:left" valign="top"><a href="<%=URL("P_Product",c.Keyid) %>"><%=Lang(GetProduct(c.Keyid).Name)%></a></th>
        <th style="width:70px" valign="top"><%=TypeName(c.Status) %></th>
    </tr>
    <tr>
        <td colspan="2"><ul class="comment_star"><li><em class="comments_bg stars_<%=c.Star%>"></em></li></ul></td>
    </tr>
    <tr><td colspan="3">
    <%=c.Content.Replace("\r\n", "<br/>")%><br /><%=FormatTime(c.Time_Add) %>
    <ul class="piclist<%=c.id %>">
        <%
            string[] images = c.ImagesSmall.Split('@');
            string[] bigs = c.Images.Split('@');
            for (int i = 0; i < images.Count();i++)
            {
                if (images[i] == "")
                    continue;
        %>
        <li class="imagespreviewlist">
            <span class="image"><a href="<%=WebPath+bigs[i] %>" data-lightbox="image<%=c.id %>"><img src="<%=WebPath+images[i] %>" /></a></span>
        </li>
            <%} %>
    </ul>
    </td></tr>
    <%
    List<Shop.Model.Lebi_Comment> cr = Shop.Bussiness.B_Lebi_Comment.GetList("Parentid = "+ c.id +"", "id desc");
    foreach (Shop.Model.Lebi_Comment creply in cr)
    {
    %>
    <tr><td colspan="3">客服回复：<%=creply.Content%><em><%=creply.Time_Add%></em></td></tr>
    <%} %>
    </table>
    </div>
    <%} %>
    </div>
    <%}else{ %>
    <div class="table-list loadlist">
        <%foreach (Shop.Model.Lebi_Order_Product op in order_products)
        {%>
        <div class="loadli">
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <th style="width:50px" valign="top" rowspan="2"><% if (op.ImageSmall == ""){ %>&nbsp;<%}else{ %><a href="<%=URL("P_Product",op.Product_id) %>"><img style="height: 50px;width: 50px;vertical-align:middle" src="<%=Image(op.ImageSmall) %>" /></a><%} %></th>
            <th style="text-align:left" valign="top"><a href="<%=URL("P_Product",op.Product_id) %>"><%=Lang(op.Product_Name)%></a></th>
            <th style="width:70px" valign="top"><a href="<%=URL("P_UserCommentWrite",op.id) %>">发表评价</a></th>
        </tr>
        <tr>
            <td colspan="2"><%=op.Time_Add %></td>
        </tr>
        </table>
        </div>
        <%} %>
    </div>
    <%} %>
    <%if (CurrentSite.IsMobile==0){ %>
        <div class="bottom clearfix"><div class="right"><%=PageString%></div></div>
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
<script type="text/javascript" src="<%=PageJS("lightbox/lightbox.min.js")%>"></script>
<script type="text/javascript">
    function search_() {
        var key = $("#key").val();
        var status = $("#status").val();
        window.location = "?type=<%=type %>&key=" + escape(key) + "&status=" + status;
    }
    function Delete() {
        if (!confirm("确认要删除吗？}"))
            return false;
        var ids = GetChkCheckedValues("id");
        var postData = { "ids": ids };
        var url = path+"/ajax/ajax_user.aspx?__Action=Comment_Delete";
        RequestAjax(url, postData, function () { MsgBox(1, "操作成功", "?") });
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
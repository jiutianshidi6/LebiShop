<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_Recharge" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_Recharge"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_Recharge","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_Recharge","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_Recharge","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_Recharge","title")%></h2>
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
<div class="userbox">
    <div class="mt clearfix">
        <h2>充值</h2>
    </div>
    <div class="mc clearfix">
    <div class="dl-table clearfix">
    <dl>
        <dt>充值金额(<%=DefaultCurrency.Msige %>)：</dt>
        <dd><input name="RMoney" id="RMoney" size="30" onkeyup="value=value.replace(/[^\d\.]/g,'');" class="input" /></dd>
    </dl>
    <dl>
        <dt>支付方式：</dt>
        <dd>
            <label onclick="changepaytype(0);"><input type="radio" name="paytype" value="0" checked order="true" /> <%=Tag("在线支付")%></label>
            &nbsp;
            <label onclick="changepaytype(1);"><input type="radio" name="paytype" value="1" order="true" /> <%=Tag("线下支付")%></label>
        </dd>
    </dl>
   <dl id="pt0">
        <dt>&nbsp;</dt>
        <dd><%foreach(Shop.Model.Lebi_OnlinePay op in onlinepays){ %>
            <label><input type="radio" name="onlinepay_id" value="<%=op.id %>" <%=op.id==CurrentUser.OnlinePay_id?"checked":"" %> url="<%=op.Url %>" order="true" /> <%=Lang(op.Name)%></label><br />
            <%}%></dd>
    </dl>
    <dl id="pt1" style="display:none">
        <dt>&nbsp;</dt>
        <dd><%foreach(Shop.Model.Lebi_Pay op in pays){ %>
            <label><input type="radio" name="Pay_id" value="<%=op.id %>" checked order="true" /> <%=Lang(op.Name)%></label><br />
            <%}%></dd>
    </dl>
    <dl class="dl-btn">
        <dt></dt>
        <dd id="message"><a href="javascript:void(0)" onclick="submit();" class="btn btn-11"><s></s>提交</a></dd>
    </dl>
    </div>
    </div>
    </div>
</div>
<script type="text/javascript">
    function submit() {
        var RMoney = $("#RMoney").val();
        var onlinepay_id = $("input[name='onlinepay_id']:checked").val();
        var paytype = $("input[name='paytype']:checked").val();
        var Pay_id = $("input[name='Pay_id']:checked").val();
        if (RMoney == "" || RMoney<=0) {
            CheckNO("RMoney", "充值金额必须大于0");
            return false;
        }
        var postData = { "RMoney": RMoney, "onlinepay_id": onlinepay_id, "Pay_id": Pay_id, "paytype": paytype };
        var url = path + "/ajax/ajax_order.aspx?__Action=CreateMoneyOrder";
        if (paytype == 1) {
            RequestAjax(url, postData, function (res) {
                MsgBox(1, '操作成功');
                $('#message').html('<span style="color:red;">操作成功!</span>');
            });
        }
        else {
            RequestAjax(url, postData, function (res) { MsgBoxClose(res.url, "") });
        }
    }
    function changepaytype(t) {
        if (t == 1) {
            $('#pt0').hide();
            $('#pt1').show();
        } else {
            $('#pt1').hide();
            $('#pt0').show();
        }
    }
    changepaytype(0);
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
<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_ForgetPassword" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_ForgetPassword"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_ForgetPassword","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_ForgetPassword","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_ForgetPassword","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_ForgetPassword","title")%></h2>
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
        <h2>忘记密码</h2>
    </div>
    <div class="mc clearfix">
    <div class="dl-table clearfix">
    <dl id="dl-email">
        <dt>您的邮箱：</dt>
        <dd><input name="Email" id="Email" shop="true" type="text" size="30" class="input" /></dd>
    </dl>
    <dl id="dl-username" style="display:none">
        <dt>登录帐号：</dt>
        <dd><input name="UserName" id="UserName" shop="true" type="text" size="30" class="input" /></dd>
    </dl>
    <dl>
        <dt>找回方式：</dt>
        <dd>
        <%if (ShopCache.GetBaseConfig().MailSign.ToLower().Contains("getpwd")){ %>
        <label><input type="radio" name="type" value="0" shop="true" onclick="GetType();" checked /><%=Tag("Email")%></label>
        <label><input type="radio" name="type" value="1" shop="true" onclick="GetType();" /><%=Tag("安全问题")%></label>
        <%}else{%>
        <label><input type="radio" name="type" value="1" shop="true" onclick="GetType();" checked /><%=Tag("安全问题")%></label>
        <%} %>
        <%if (ShopCache.GetBaseConfig().SMS_sendmode.Contains("SMSTPL_getnewpwd")){ %>
        <label><input type="radio" name="type" value="2" shop="true" onclick="GetType();" /><%=Tag("手机短信")%></label>
        <%} %>
        </dd>
    </dl>
    <%if (SYS.Verifycode_ForgetPassword == "1"){ %>
    <dl>
        <dt>验证码：</dt>
        <dd><input name="verifycode" type="text" shop="true" id="verifycode" shop="true" size="6" class="input" /><img class="verifycode" id="img1" src="<%=WebPath%>/code.aspx" /><img src="/Theme/system/wap/images/reload.gif" class="refresh" title="点击刷新验证码" onclick="refresh('img1')" /></dd>
    </dl>
    <%} %>
    <dl class="dl-btn">
        <dt></dt>
        <dd><a href="javascript:void(0)" onclick="submit();" class="btn btn-11"><s></s>提交</a></dd>
    </dl>
    <dl class="dl-msg">
        <dt></dt>
        <dd><div id="msg"></div></dd>
    </dl>
    </div>
    </div>
</div>
</div>
<script type="text/javascript">
    function submit() {
        var Email = $("#Email").val();
        var UserName = $("#UserName").val();
        var type = $("input[name='type']:checked").val();
        if (type == 0) {
            if (Email == "") {
                CheckNO("Email", "请输入您的邮箱");
                return false;
            }
            var postData = GetFormJsonData("shop");
            var url = path + "/ajax/ajax_user.aspx?__Action=User_forgetpwd&type=0";
            RequestAjax(url, postData, function () { $("#msg").html("找回密码邮件已发送至您的邮箱，请查收"); MsgBoxClose(); });
        } else {
            if (UserName == "") {
                CheckNO("UserName", "请输入您的登录账号");
                return false;
            }
            var postData = GetFormJsonData("shop");
            var url = path + "/ajax/ajax_user.aspx?__Action=User_forgetpwd&type=" + type + "";
            RequestAjax(url, postData, function (res) { if (type == 1) { location.href = res.url; } else { MsgBox(1, "新密码已发送至您的手机，请查收", res.url); } });
        }
    }
    function GetType() {
        var type = $("input[name='type']:checked").val();
        if (type == 0) {
            $("#dl-email").show();
            $("#dl-username").hide();
        } else {
            $("#dl-email").hide();
            $("#dl-username").show();
        }
    }
    GetType();
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
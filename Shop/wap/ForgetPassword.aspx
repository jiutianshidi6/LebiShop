<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_ForgetPassword" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",8,"CN","P_ForgetPassword"); %>

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
	<h2><%=ThemePageMeta("P_ForgetPassword","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>

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
        <%} %></dd>
    </dl>
    <dl>
        <dt>验证码：</dt>
        <dd><input name="verifycode" type="text" shop="true" id="verifycode" shop="true" size="6" class="input" /> <img class="img_c" align="absmiddle" style="width: 80px; height: 25px;" title="点击重新获取验证码" id="img1" src="<%=WebPath%>/code.aspx" language="javascript" onclick="this.src=this.src+'?'" /><span id="C_user_vcode"></span></dd>
    </dl>
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
            var url = path + "/ajax/ajax_user.aspx?__Action=User_forgetpwd&type=1";
            RequestAjax(url, postData, function (res) { location.href = res.url; });
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
    
<div id="footer" class="clearfix">
    <div class="copyright">
        <%=Lang(SYS.Copyright) %>
    </div>
    <div class="lang">
        

<div class="language">
<%List<Shop.Model.Lebi_Language> ujzps=Languages();RecordCount=ujzps.Count;int ujzp_index=1;
foreach (Shop.Model.Lebi_Language ujzp in ujzps){%>
<a <%if (ujzp_index==RecordCount){%>class="last"<%} %> href="javascript:SetLanguage(<%=ujzp.id%>,'<%=ujzp.Code%>','<%=ujzp.Path%>');"><img src="<%=Image(ujzp.ImageUrl) %>" title="<%=ujzp.Name%>" /><%=ujzp.Name%></a>
<%ujzp_index++;}%>
</div>

    </div>
    <div class="currency">
        

<div class="currency"><ul class="dropcurrency"><li class="currency_li"><a class="noclick"><span>币种：</span><s><%=CurrentCurrency.Code %></s></a><dl class="currency_li_content">
<%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int LPKu_index=1;
List<Lebi_Currency> LPKus = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency LPKu in LPKus){%>
<dd <%if (LPKu_index==RecordCount){%>class="last"<%} %>><a href="javascript:SetCurrency(<%=LPKu.id%>,'<%=LPKu.Code%>',<%=LPKu.ExchangeRate%>,'<%=LPKu.Msige%>');"><%=LPKu.Code%></a></dd>
<%LPKu_index++;}%>
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
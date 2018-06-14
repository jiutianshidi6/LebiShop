<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_Login" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",8,"CN","P_Login"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_Login","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_Login","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_Login","description")%>" />
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
	<h2><%=ThemePageMeta("P_Login","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>

    <div class="body">
        <div class="bodymain">
            


<div class="nbbox clearfix">
    <div class="user">
        <div class="login clearfix">
            <div class="userloginbox">
                <div class="mt clearfix">
                    <h2>会员登录</h2>
                </div>
                <div class="mc clearfix">
                    <div class="dl-table clearfix">
                    <dl>
                        <dt>用户名：</dt>
                        <dd><input name="UserName" id="UserName" shop="true" type="text" size="20" class="input" /></dd>
                    </dl>
                    <dl>
                        <dt>密码：</dt>
                        <dd><input type="password" name="Password" shop="true" id="Password" size="20" class="input" /></dd>
                    </dl>
                    <dl>
                        <dt>验证码：</dt>
                        <dd><input name="verifycode" type="text" id="verifycode" shop="true" size="6" class="input" /> <img class="img_c" align="absmiddle" style="width: 80px; height: 25px;" title="点击刷新验证码" id="img1" src="<%=WebPath%>/code.aspx" language="javascript" onclick="this.src=this.src+'?'" /></dd>
                    </dl>
                    <dl>
                        <dt></dt>
                        <dd><a href="javascript:void(0)" onclick="submitlogin();" class="btn btn-7"><s></s>登录</a>&nbsp;&nbsp;<a href="<%=URL("P_ForgetPassword","")%>">忘记密码</a></dd>
                    </dl>
                    </div>
                    <div class="platform">
                        <%if(SYS.platform_login.Contains("qq")){ %>
                        <a href="<%=Shop.Platform.QQ.Instance.LoginURL(backurl) %>">
                            <img src="<%=Image(Shop.Platform.QQ.Instance.ImageURL) %>" /></a>
                        <%} %>
                        <%if(SYS.platform_login.Contains("weibo")){ %>
                        <a href="<%=Shop.Platform.Weibo.Instance.LoginURL(backurl) %>">
                            <img src="<%=Image(Shop.Platform.Weibo.Instance.ImageURL) %>" /></a>
                        <%} %>
                        <%if(SYS.platform_login.Contains("taobao")){ %>
                        <a href="<%=Shop.Platform.Taobao.Instance.LoginURL(backurl) %>">
                            <img src="<%=Image(Shop.Platform.Taobao.Instance.ImageURL) %>" /></a>
                        <%} %>
                        <%if(SYS.platform_login.Contains("facebook")){ %>
                        <a href="<%=Shop.Platform.Facebook.Instance.LoginURL(backurl) %>">
                            <img src="<%=Image(Shop.Platform.Facebook.Instance.ImageURL) %>" /></a>
                        <%} %>
                    </div>
                </div>
                <div class="mes">
                    <h2>
                        <span>还不是商城会员？</span></h2>
                    <div class="cont">
                        一分钟轻松注册，就可以方便购物！<a href="<%=URL("P_Register", ""+HttpUtility.UrlEncode(backurl)+"," + GetUrlToken(backurl)+ "") %>">免费注册</a></div>
                </div>
            </div>
            <div id="advert">
            <% Advertisement("Login"); %>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    $(document).keyup(function (event) {
        if (event.keyCode == 13) {
            submitlogin();
        }
    });
    function submitlogin() {
        var Password = $("#Password").val();
        var UserName = $("#UserName").val();
        var verifycode = $("#verifycode").val();
        if (UserName == "") {
            CheckNO("UserName", "请输入用户名");
            return false;
        }
        if (Password == "") {
            CheckNO("Password", "请输入密码");
            return false;
        }
        if (verifycode == "") {
            CheckNO("verifycode", "请输入验证码");
            return false;
        }
        var postData = GetFormJsonData("shop");
        var url = path+"/ajax/ajax_user.aspx?__Action=User_Login&url=<%=backurl %>&token=<%=token %>";
        RequestAjax(url, postData, function (res) { MsgBox(1, "登录成功", res.url) });
    }
    function wechat(){
        if($("#weixin").is(":hidden")){
            $("#qrcode").html('<img src="'+path+'/ajax/ajax_user.aspx?__Action=GetQrCode&url=<%=backurl %>&token=<%=token %>" style="width:100px;height:100px"/>');  
            $("#weixin").show();
            $("#advert").hide();
            setInterval("wechatlogin()",3000);
        }else{
            $("#weixin").hide();
            $("#advert").show();
        }
    }
    <%if(SYS.platform_login.Contains("weixin")){ %>
    var wflag=0;
    function wechatlogin()
    {
        if(wflag==0){
            wflag=1;
            $.ajax({
                type: "POST",
                url: path+"/ajax/ajax_user.aspx?__Action=wechatlogin",
                data: '',
                dataType: 'json',
                success: function (res) {
                    if(res.msg=='OK')
                        window.location='<%=backurl %>';
                    else
                        wflag=0;
                }
            });
        }
    }
    <%} %>
</script>


        </div>
    </div>
    
<div id="footer" class="clearfix">
    <div class="copyright">
        <%=Lang(SYS.Copyright) %>
    </div>
    <div class="lang">
        

<div class="language">
<%List<Shop.Model.Lebi_Language> hFaWs=Languages();RecordCount=hFaWs.Count;int hFaW_index=1;
foreach (Shop.Model.Lebi_Language hFaW in hFaWs){%>
<a <%if (hFaW_index==RecordCount){%>class="last"<%} %> href="javascript:SetLanguage(<%=hFaW.id%>,'<%=hFaW.Code%>','<%=hFaW.Path%>');"><img src="<%=Image(hFaW.ImageUrl) %>" title="<%=hFaW.Name%>" /><%=hFaW.Name%></a>
<%hFaW_index++;}%>
</div>

    </div>
    <div class="currency">
        

<div class="currency"><ul class="dropcurrency"><li class="currency_li"><a class="noclick"><span>币种：</span><s><%=CurrentCurrency.Code %></s></a><dl class="currency_li_content">
<%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int hfKL_index=1;
List<Lebi_Currency> hfKLs = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency hfKL in hfKLs){%>
<dd <%if (hfKL_index==RecordCount){%>class="last"<%} %>><a href="javascript:SetCurrency(<%=hfKL.id%>,'<%=hfKL.Code%>',<%=hfKL.ExchangeRate%>,'<%=hfKL.Msige%>');"><%=hfKL.Code%></a></dd>
<%hfKL_index++;}%>
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